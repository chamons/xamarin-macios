using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Reflection;
using Xamarin.Utils;
using Xamarin.Tests;
using Xamarin.Tests.Templating;

namespace Xamarin.MMP.Tests
{
	public class OutputText
	{
		public string BuildOutput { get; private set; }
		public string RunOutput { get; private set; }

		public OutputText (string buildOutput, string runOutput)
		{
			BuildOutput = buildOutput;
			RunOutput = runOutput;
		}

		MessageTool messages;
		internal MessageTool Messages {
			get {
				if (messages == null) {
					messages = new MessageTool ();
					messages.Output.Append (BuildOutput);
					messages.ParseMessages ();
				}
				return messages;
			}
		}

		internal class MessageTool : Tool
		{
			protected override string ToolPath => throw new NotImplementedException ();

			protected override string MessagePrefix => "MM";
		}
	}

	static class FrameworkBuilder
	{
		const string PListText = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">
<plist version=""1.0"">
<dict>
	<key>BuildMachineOSBuild</key>
	<string>16B2657</string>
	<key>CFBundleDevelopmentRegion</key>
	<string>English</string>
	<key>CFBundleExecutable</key>
	<string>Foo</string>
	<key>CFBundleIdentifier</key>
	<string>com.test.Foo</string>
	<key>CFBundleInfoDictionaryVersion</key>
	<string>6.0</string>
	<key>CFBundleName</key>
	<string>Foo</string>
	<key>CFBundlePackageType</key>
	<string>FMWK</string>
	<key>CFBundleShortVersionString</key>
	<string>6.9</string>
	<key>CFBundleSignature</key>
	<string>????</string>
	<key>CFBundleSupportedPlatforms</key>
	<array>
		<string>MacOSX</string>
	</array>
	<key>CFBundleVersion</key>
	<string>1561.40.100</string>
	<key>DTCompiler</key>
	<string>com.apple.compilers.llvm.clang.1_0</string>
	<key>DTPlatformBuild</key>
	<string>9Q85j</string>
	<key>DTPlatformVersion</key>
	<string>GM</string>
	<key>DTSDKBuild</key>
	<string>17E138</string>
	<key>DTSDKName</key>
	<string>macosx10.13internal</string>
	<key>DTXcode</key>
	<string>0930</string>
	<key>DTXcodeBuild</key>
	<string>9Q85j</string>
</dict>
</plist>";
		
		public static string CreateFatFramework (string tmpDir)
		{
			Func<string, string> f = x => Path.Combine (tmpDir, x);
			File.WriteAllText (f ("foo.c"), "int Answer () { return 42; }");
			File.WriteAllText (f ("Info.plist"), PListText);

			TI.RunAndAssert ($"clang -m32 -c -o {f ("foo_32.o")} {f ("foo.c")}");
			TI.RunAndAssert ($"clang -m64 -c -o {f ("foo_64.o")} {f ("foo.c")}");
			TI.RunAndAssert ($"clang -m32 -dynamiclib -o {f ("foo_32.dylib")} {f ("foo_32.o")}");
			TI.RunAndAssert ($"clang -m64 -dynamiclib -o {f ("foo_64.dylib")} {f ("foo_64.o")}");
			TI.RunAndAssert ($"lipo -create {f ("foo_32.dylib")} {f ("foo_64.dylib")} -output {f ("Foo")}");
			TI.RunAndAssert ($"install_name_tool -id @rpath/Foo.framework/Foo {f ("Foo")}");
			TI.RunAndAssert ($"mkdir -p {f ("Foo.framework/Versions/A/Resources")}");
			TI.RunAndAssert ($"cp {f ("Foo")} {f ("Foo.framework/Versions/A/Foo")}");
			TI.RunAndAssert ($"cp {f ("Info.plist")} {f ("Foo.framework/Versions/A/Resources/")}");
			TI.RunAndAssert ($"ln -s Versions/A/Foo {f ("Foo.framework/Foo")}");
			TI.RunAndAssert ($"ln -s Versions/A/Resources  {f ("Foo.framework/Resources")}");
			TI.RunAndAssert ($"ln -s Versions/A  {f ("Foo.framework/Current")}");
			return f ("Foo.framework");
		}

		public static string CreateThinFramework (string tmpDir, bool sixtyFourBits = true)
		{
			Func<string, string> f = x => Path.Combine (tmpDir, x);
			File.WriteAllText (f ("foo.c"), "int Answer () { return 42; }");
			File.WriteAllText (f ("Info.plist"), PListText);

			string bitnessArg = sixtyFourBits ? "-m64" : "-m32";
			TI.RunAndAssert ($"clang {bitnessArg} -c -o {f ("foo.o")} {f ("foo.c")}");
			TI.RunAndAssert ($"clang {bitnessArg} -dynamiclib -o {f ("Foo")} {f ("foo.o")}");
			TI.RunAndAssert ($"install_name_tool -id @rpath/Foo.framework/Foo {f ("Foo")}");
			TI.RunAndAssert ($"mkdir -p {f ("Foo.framework/Versions/A/Resources")}");
			TI.RunAndAssert ($"cp {f ("Foo")} {f ("Foo.framework/Versions/A/Foo")}");
			TI.RunAndAssert ($"cp {f ("Info.plist")} {f ("Foo.framework/Versions/A/Resources/")}");
			TI.RunAndAssert ($"ln -s Versions/A/Foo {f ("Foo.framework/Foo")}");
			TI.RunAndAssert ($"ln -s Versions/A/Resources  {f ("Foo.framework/Resources")}");
			TI.RunAndAssert ($"ln -s Versions/A  {f ("Foo.framework/Current")}");
			return f ("Foo.framework");
		}
	}

	// Hide the hacks and provide a nice interface for writting tests that build / run XM projects
	static class TI 
	{
		public class UnifiedTestConfig
		{
			public string TmpDir { get; set; }

			// Not necessarly required
			public bool FSharp { get; set; }
			public bool XM45 { get; set; }
			public bool Release { get; set; } = false;

			public string ProjectName { get; set; } = "";
			public string TestCode { get; set; } = "";
			public string TestDecl { get; set; } = "";
			public string CSProjConfig { get; set; } = "";
			public string References { get; set; } = "";
			public string ReferencesBeforePlatform { get; set; } = "";
			public string AssemblyName { get; set; } = "";
			public string ItemGroup { get; set; } = "";
			public string SystemMonoVersion { get; set; } = "";
			public string TargetFrameworkVersion { get; set; } = "";
			public Dictionary<string, string> PlistReplaceStrings { get; set; } = new Dictionary<string, string>();
			public Tuple<string, string> CustomProjectReplacement { get; set; } = null;

			// Binding project specific
			public string APIDefinitionConfig { get; set; }
			public string StructsAndEnumsConfig { get; set; }

			// Unified Executable Specific
			public bool AssetIcons { get; set; }

			// Generated by TestUnifiedExecutable/TestSystemMonoExecutable and added to TestCode
			public Guid guid { get; set; }

			public UnifiedTestConfig (string tmpDir)
			{
				TmpDir = tmpDir;
			}
		}

		public static string AssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly ().CodeBase;
				UriBuilder uri = new UriBuilder (codeBase);
				string path = Uri.UnescapeDataString (uri.Path);
				return Path.GetDirectoryName (path);
			}
		}

		public static Version FindMonoVersion ()
		{
			string output = RunAndAssert ("/Library/Frameworks/Mono.framework/Commands/mono", new StringBuilder ("--version"), "FindMonoVersion");

			Regex versionRegex = new Regex("compiler version \\d+.\\d+.\\d+(.\\d+)?", RegexOptions.IgnoreCase);
			return new Version (versionRegex.Match (output).Value.Split (' ')[2]);
		}

		public static string RunAndAssert (string exe)
		{
			var parts = exe.Split (new char [] { ' ' }, 2);
			if (parts.Length == 1)
				return RunAndAssert (exe, "", "Command: " + exe);
			else
				return RunAndAssert (parts[0], parts[1], "Command: " + exe);
		}

		public static string RunAndAssert (string exe, string args, string stepName, bool shouldFail = false, Func<string> getAdditionalFailInfo = null, string[] environment = null)
		{
			StringBuilder output = new StringBuilder ();
			Environment.SetEnvironmentVariable ("MONO_PATH", null);
			int compileResult = Invoker.RunCommand (exe, args != null ? args.ToString() : string.Empty, environment, output, suppressPrintOnErrors: shouldFail);
			if (!shouldFail && compileResult != 0) {
				// Driver.RunCommand won't print failed output unless verbosity > 0, so let's do it ourselves.
				Console.WriteLine ($"Execution failed; exit code: {compileResult}");
				Console.WriteLine (output);
			}
			Func<string> getInfo = () => getAdditionalFailInfo != null ? getAdditionalFailInfo() : "";
			if (!shouldFail)
				Assert.AreEqual (0, compileResult, stepName + " failed:\n\n'" + output + "' " + exe + " " + args + getInfo ());
			else
				Assert.AreNotEqual (0, compileResult, stepName + " did not fail as expected:\n\n'" + output + "' " + exe + " " + args + getInfo ());

			return output.ToString ();
		}

		public static string RunAndAssert (string exe, StringBuilder args, string stepName, bool shouldFail = false, Func<string> getAdditionalFailInfo = null, string[] environment = null)
		{
			return RunAndAssert (exe, args.ToString (), stepName, shouldFail, getAdditionalFailInfo, environment);
		}

		// In most cases we generate projects in tmp and this is not needed. But nuget and test projects can make that hard
		public static void CleanUnifiedProject (string csprojTarget)
		{
			RunAndAssert ("/Library/Frameworks/Mono.framework/Commands/msbuild", new StringBuilder (csprojTarget + " /t:clean"), "Clean");
		}

		public static string BuildProject (string csprojTarget, bool isUnified, bool shouldFail = false, bool release = false, string[] environment = null)
		{
			string rootDirectory = FindRootDirectory ();

			// TODO - This is not enough for MSBuild to really work. We need stuff to have it not use system targets!
			// These are required to have xbuild use are local build instead of system install
			Environment.SetEnvironmentVariable ("TargetFrameworkFallbackSearchPaths", rootDirectory + "/Library/Frameworks/Mono.framework/External/xbuild-frameworks");
			Environment.SetEnvironmentVariable ("MSBuildExtensionsPathFallbackPathsOverride", rootDirectory + "/Library/Frameworks/Mono.framework/External/xbuild");
			Environment.SetEnvironmentVariable ("XAMMAC_FRAMEWORK_PATH", rootDirectory + "/Library/Frameworks/Xamarin.Mac.framework/Versions/Current");
			Environment.SetEnvironmentVariable ("XamarinMacFrameworkRoot", rootDirectory + "/Library/Frameworks/Xamarin.Mac.framework/Versions/Current");

			// This is to force build to use our mmp and not system mmp
			StringBuilder buildArgs = new StringBuilder ();
			if (isUnified) {
				buildArgs.Append (" /verbosity:diagnostic ");
				buildArgs.Append (" /property:XamarinMacFrameworkRoot=" + rootDirectory + "/Library/Frameworks/Xamarin.Mac.framework/Versions/Current ");

				if (release)
					buildArgs.Append ("/property:Configuration=Release ");
				else
					buildArgs.Append ("/property:Configuration=Debug ");

			} else {
				buildArgs.Append (" build ");
			}

			buildArgs.Append (StringUtils.Quote (csprojTarget));

			Func <string> getBuildProjectErrorInfo = () => {
				string csprojText = "\n\n\n\tCSProj: \n" + File.ReadAllText (csprojTarget);
				string csprojLocation = Path.GetDirectoryName (csprojTarget);
				string fileList = "\n\n\tFiles: " + String.Join (" ", Directory.GetFiles (csprojLocation).Select (x => x.Replace (csprojLocation + "/", "")));
				return csprojText + fileList;
			};

			if (isUnified)
				return RunAndAssert ("/Library/Frameworks/Mono.framework/Commands/msbuild", buildArgs, "Compile", shouldFail, getBuildProjectErrorInfo, environment);
			else
				return RunAndAssert ("/Applications/Visual Studio.app/Contents/MacOS/vstool", buildArgs, "Compile", shouldFail, getBuildProjectErrorInfo, environment);
		}

		static ProjectSubstitutions CreateDefaultSubstitutions (UnifiedTestConfig config)
		{
			return new ProjectSubstitutions {
				CSProjConfig = config.CSProjConfig,
				References = config.References,
				ReferencesBeforePlatform = config.ReferencesBeforePlatform,
				AssemblyNameOverride = config.AssemblyName ?? Path.GetFileNameWithoutExtension (config.ProjectName),
				ItemGroup = config.ItemGroup,
				TargetFrameworkVersion = config.TargetFrameworkVersion,
				CustomProjectReplacement = config.CustomProjectReplacement
			};
		}

		public static string RunEXEAndVerifyGUID (string tmpDir, Guid guid, string path)
		{
			// Assert that the program actually runs and returns our guid
			Assert.IsTrue (File.Exists (path), string.Format ("{0} did not generate an exe?", path));
			string output = RunAndAssert (path, (string)null, "Run");

			string guidPath = Path.Combine (tmpDir, guid.ToString ());
			Assert.IsTrue(File.Exists (guidPath), "Generated program did not create expected guid file: " + output);

			// Let's delete the guid file so re-runs inside same tests are accurate
			File.Delete (guidPath);
			return output;
		}

		public static string GenerateBindingLibraryProject (UnifiedTestConfig config)
		{
			var info = TemplateInfo.FromCustomProject (ProjectType.Binding, ProjectLanguage.CSharp, config.ProjectName);

			var engine = new MacBindingTemplateEngine (info);
			var fileSubstitutions = new FileSubstitutions {
				ApiDefinition = config.APIDefinitionConfig,
				StructsAndEnums = config.StructsAndEnumsConfig
			};

			return engine.Generate (config.TmpDir, CreateDefaultSubstitutions (config), fileSubstitutions);
		}

		public static string GenerateUnifiedLibraryProject (UnifiedTestConfig config)
		{
			var engine = new MacLibraryTemplateEngine (config.XM45 ? ProjectFlavor.FullXM : ProjectFlavor.ModernXM, config.FSharp ? ProjectLanguage.FSharp : ProjectLanguage.CSharp);
			var fileSubstitutions = new FileSubstitutions { TestCode = config.TestCode };

			return engine.Generate (config.TmpDir, CreateDefaultSubstitutions (config), fileSubstitutions);
		}

		public static string GenerateNetStandardProject (UnifiedTestConfig config)
		{
			NetStandardLibraryTemplateEngine engine = new NetStandardLibraryTemplateEngine ();
			return engine.Generate (config.TmpDir);
		}

		public static string GenerateAppProject (UnifiedTestConfig config)
		{
			ProjectLanguage language = config.FSharp ? ProjectLanguage.FSharp : ProjectLanguage.CSharp;
			ProjectFlavor flavor = config.XM45 ? ProjectFlavor.FullXM : ProjectFlavor.ModernXM;

			TemplateInfo info;
			if (!string.IsNullOrEmpty (config.ProjectName)) {
				info = TemplateInfo.FromCustomProject (ProjectType.App, language, config.ProjectName);
			} else {
				info = new TemplateInfo (flavor, ProjectType.App, language);
				config.ProjectName = info.ProjectName;
			}

			var engine = new MacAppTemplateEngine (info);
			var fileSubstitutions = new FileSubstitutions {
				TestCode = config.TestCode,
				TestDecl = config.TestDecl,
			};
			PListSubstitutions pListSubstitutions = new PListSubstitutions () {
				Replacements = config.PlistReplaceStrings
			};

			return engine.Generate (config.TmpDir, CreateDefaultSubstitutions (config), fileSubstitutions, pListSubstitutions);
		}

		public static string GenerateAndBuildUnifiedExecutable (UnifiedTestConfig config, bool shouldFail = false, string[] environment = null)
		{
			string csprojTarget = GenerateAppProject (config);
			return BuildProject (csprojTarget, isUnified: true, shouldFail: shouldFail, release: config.Release, environment: environment);
		}

		public static string RunGeneratedUnifiedExecutable (UnifiedTestConfig config)
		{
			string bundleName = config.AssemblyName != "" ? config.AssemblyName : config.ProjectName.Split ('.')[0];
			string exePath = Path.Combine (config.TmpDir, "bin/" + (config.Release ? "Release/" : "Debug/") + bundleName + ".app/Contents/MacOS/" + bundleName);
			return RunEXEAndVerifyGUID (config.TmpDir, config.guid, exePath);
		}

		public static OutputText TestUnifiedExecutable (UnifiedTestConfig config, bool shouldFail = false, string[] environment = null)
		{
			AddGUIDTestCode (config);

			string buildOutput = GenerateAndBuildUnifiedExecutable (config, shouldFail, environment);
			if (shouldFail)
				return new OutputText (buildOutput, "");

			string runOutput = RunGeneratedUnifiedExecutable (config);

			return new OutputText (buildOutput, runOutput);
		}

		public static void AddGUIDTestCode (UnifiedTestConfig config)
		{
			// If we've already generated guid bits for this config, don't tack on a second copy
			if (config.guid == Guid.Empty) {
				config.guid = Guid.NewGuid ();
				config.TestCode += GenerateOutputCommand (config.TmpDir, config.guid);
			}
		}

		public static OutputText TestClassicExecutable (string tmpDir, string testCode = "", string csprojConfig = "", bool shouldFail = false, bool includeMonoRuntime = false)
		{
			Guid guid = Guid.NewGuid ();
			testCode += GenerateOutputCommand (tmpDir, guid);

			var engine = new MacClassicAppTemplateEngine ();
			ProjectSubstitutions projectSubstitutions = new ProjectSubstitutions { CSProjConfig = csprojConfig };
			FileSubstitutions fileSubstitutions = new FileSubstitutions { TestCode = testCode };
			string csprojTarget = engine.Generate (tmpDir, projectSubstitutions, fileSubstitutions, includeMonoRuntime);

			string buildOutput = BuildProject (csprojTarget, isUnified : false, shouldFail : shouldFail);
			if (shouldFail)
				return new OutputText (buildOutput, "");

			string exePath = Path.Combine (tmpDir, "bin/Debug/ClassicExample.app/Contents/MacOS/ClassicExample");
			string runOutput = RunEXEAndVerifyGUID (tmpDir, guid, exePath);
			return new OutputText (buildOutput, runOutput);
		}

		public static OutputText TestSystemMonoExecutable (UnifiedTestConfig config, bool shouldFail = false)
		{
			config.guid = Guid.NewGuid ();
			config.TestCode += GenerateOutputCommand (config.TmpDir, config.guid);

			var engine = new MacSystemMonoTemplateEngine ();
			ProjectSubstitutions projectSubstitutions = CreateDefaultSubstitutions (config);
			FileSubstitutions fileSubstitutions = new FileSubstitutions () { TestCode = config.TestCode };
			string csprojTarget = engine.Generate (config.TmpDir, projectSubstitutions, fileSubstitutions);

			string buildOutput = BuildProject (csprojTarget, isUnified: true, shouldFail: shouldFail, release: config.Release);
			if (shouldFail)
				return new OutputText (buildOutput, "");

			string exePath = Path.Combine (config.TmpDir, "bin", config.Release ? "Release" : "Debug", "SystemMonoExample.app/Contents/MacOS/SystemMonoExample");
			string runOutput = RunEXEAndVerifyGUID (config.TmpDir, config.guid, exePath);
			return new OutputText (buildOutput, runOutput);
		}

		static string GetTargetFrameworkValue (UnifiedTestConfig config)
		{
			string version = config.SystemMonoVersion == "" ? "4.5" : config.SystemMonoVersion;
			return string.Format ("<TargetFrameworkVersion>v{0}</TargetFrameworkVersion>", version);
		}

		public static string TestDirectory => Path.Combine (FindRootDirectory (), "..", "tests") + "/";

		public static string FindSourceDirectory ()
		{
			string codeBase = System.Reflection.Assembly.GetExecutingAssembly ().CodeBase;
			UriBuilder uri = new UriBuilder (codeBase);
			string path = Uri.UnescapeDataString (uri.Path);
			string assemblyDirectory = Path.GetDirectoryName (path);
			return Path.Combine(assemblyDirectory, TestDirectory + "common/mac");
		}

		public static void CopyDirectory (string src, string target)
		{
			Invoker.RunCommand ("/bin/cp", $"-r {src} {target}");
		}

		public static string FindRootDirectory ()
		{
			var current = Assembly.GetExecutingAssembly ().Location;
			while (!Directory.Exists (Path.Combine (current, "_mac-build")) && current.Length > 1)
				current = Path.GetDirectoryName (current);
			if (current.Length <= 1)
				throw new DirectoryNotFoundException (string.Format ("Could not find the root directory starting from {0}", Environment.CurrentDirectory));
			return Path.GetFullPath (Path.Combine (current, "_mac-build"));
		}

		static string GenerateOutputCommand (string tmpDir, Guid guid)
		{
			return string.Format ("System.IO.File.Create(\"{0}\").Dispose();",  Path.Combine (tmpDir, guid.ToString ()));
		}

		public static void NugetRestore (string project)
		{
			var rv = ExecutionHelper.Execute ("nuget", $"restore {StringUtils.Quote (project)}", out var output);
			if (rv != 0) {
				Console.WriteLine ("nuget restore failed:");
				Console.WriteLine (output);
				Assert.Fail ($"'nuget restore' failed for {project}");
			}
		} 
	}

	static class PlatformHelpers
	{
		// Yes, this is a copy of the one in PlatformAvailability.cs. However, right now
		// we don't depend on Xamarin.Mac.dll, so moving to it was too painful. If we start
		// using XM, we can revisit.
		const int sys1 = 1937339185;
		const int sys2 = 1937339186;

		// Deprecated in OSX 10.8 - but no good alternative is (yet) available
		[System.Runtime.InteropServices.DllImport ("/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon")]
		static extern int Gestalt (int selector, out int result);

		static int osx_major, osx_minor;

		public static bool CheckSystemVersion (int major, int minor)
		{
			if (osx_major == 0) {
				Gestalt (sys1, out osx_major);
				Gestalt (sys2, out osx_minor);
			}
			return osx_major > major || (osx_major == major && osx_minor >= minor);
		}
	}
}
