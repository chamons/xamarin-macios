using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.Tests.Templating;
using Xamarin.Utils;

namespace Xamarin.MMP.Tests
{
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

	public class CodeStrippingTests
	{
		static Func<string, bool> LipoStripConditional = s => s.Contains ("lipo") && s.Contains ("-thin");
		static Func<string, bool> LipoStripSkipPosixConditional = s => LipoStripConditional (s) && !s.Contains ("libMonoPosixHelper.dylib");

		static Func<string, bool> DidAnyLipoStrip = output => output.SplitLines ().Any (LipoStripConditional);
		static Func<string, bool> DidAnyLipoStripSkipPosix = output => output.SplitLines ().Any (LipoStripSkipPosixConditional);

		static TI.UnifiedTestConfig CreateStripTestConfig (bool? strip, string tmpDir, string additionalMMPArgs = "")
		{
			TI.UnifiedTestConfig test = new TI.UnifiedTestConfig (tmpDir) { };

			if (strip.HasValue)
				test.CSProjConfig = $"<MonoBundlingExtraArgs>--optimize={(strip.Value ? "+" : "-")}trim-architectures {additionalMMPArgs}</MonoBundlingExtraArgs>";
			else if (!string.IsNullOrEmpty (additionalMMPArgs))
				test.CSProjConfig = $"<MonoBundlingExtraArgs>{additionalMMPArgs}</MonoBundlingExtraArgs>";
			
			return test;
		}

		void AssertStrip (string libPath, bool shouldStrip)
		{
			var archsFound = Xamarin.Tests.MachO.GetArchitectures (libPath);
			if (shouldStrip) {
				Assert.AreEqual (1, archsFound.Count, "Did not contain one archs");
				Assert.True (archsFound.Contains ("x86_64"), "Did not contain x86_64");
			} else {
				Assert.AreEqual (2, archsFound.Count, "Did not contain two archs");
				Assert.True (archsFound.Contains ("i386"), "Did not contain i386");
				Assert.True (archsFound.Contains ("x86_64"), "Did not contain x86_64");
			}
		}

		void StripTestCore (TI.UnifiedTestConfig test, bool debugStrips, bool releaseStrips, string libPath, bool shouldWarn)
		{
			string buildOutput = TI.TestUnifiedExecutable (test).BuildOutput;
			Assert.AreEqual (debugStrips, DidAnyLipoStrip (buildOutput), "Debug lipo usage did not match expectations");
			AssertStrip (Path.Combine (test.TmpDir, "bin/Debug/UnifiedExample.app/", libPath), shouldStrip: debugStrips);
			Assert.AreEqual (shouldWarn && debugStrips, buildOutput.Contains ("MM2108"), "Debug warning did not match expectations");

			test.Release = true;
			buildOutput = TI.TestUnifiedExecutable (test).BuildOutput;
			Assert.AreEqual (releaseStrips, DidAnyLipoStrip (buildOutput), "Release lipo usage did not match expectations");
			AssertStrip (Path.Combine (test.TmpDir, "bin/Release/UnifiedExample.app/", libPath), shouldStrip: releaseStrips);
			Assert.AreEqual (shouldWarn && releaseStrips, buildOutput.Contains ("MM2108"), "Release warning did not match expectations");
		}

		[TestCase (null, false, true)]
		[TestCase (true, true, true)]
		[TestCase (false, false, false)]
		public void ShouldStripMonoPosixHelper (bool? strip, bool debugStrips, bool releaseStrips)
		{
			MMPTests.RunMMPTest (tmpDir =>
			{
				TI.UnifiedTestConfig test = CreateStripTestConfig (strip, tmpDir);
				// Mono's linker is smart enough to remove libMonoPosixHelper unless used (DeflateStream uses it)
				test.TestCode = "using (var ms = new System.IO.MemoryStream ()) { using (var gz = new System.IO.Compression.DeflateStream (ms, System.IO.Compression.CompressionMode.Compress)) { }}";
				StripTestCore (test, debugStrips, releaseStrips, "Contents/MonoBundle/libMonoPosixHelper.dylib", shouldWarn: false);
			});
		}

		[TestCase (null, false, true)]
		[TestCase (true, true, true)]
		[TestCase (false, false, false)]
		public void ShouldStripUserFramework (bool? strip, bool debugStrips, bool releaseStrips)
		{
			MMPTests.RunMMPTest (tmpDir =>
			{
				var frameworkPath = FrameworkBuilder.CreateFatFramework (tmpDir);
				TI.UnifiedTestConfig test = CreateStripTestConfig (strip, tmpDir, $"--native-reference={frameworkPath}");

				StripTestCore (test, debugStrips, releaseStrips, "Contents/Frameworks/Foo.framework/Foo", shouldWarn: true);
			});
		}

		const string MonoPosixOffset = "Library/Frameworks/Xamarin.Mac.framework/Versions/Current/lib/libMonoPosixHelper.dylib";

		[TestCase (true, true)]
		[TestCase (false, false)]
		public void ExplictStripOption_ThirdPartyLibrary_AndWarnsIfSo (bool? strip, bool shouldStrip)
		{
			MMPTests.RunMMPTest (tmpDir =>
			{
				string originalLocation = Path.Combine (TI.FindRootDirectory (), MonoPosixOffset);
				string newLibraryLocation =  Path.Combine (tmpDir, "libTest.dylib");
				File.Copy (originalLocation, newLibraryLocation);

				TI.UnifiedTestConfig test = CreateStripTestConfig (strip, tmpDir, $" --native-reference=\"{newLibraryLocation}\"");
				test.Release = true;

				string buildOutput = TI.TestUnifiedExecutable (test).BuildOutput;
				Assert.AreEqual (shouldStrip, DidAnyLipoStrip (buildOutput), "lipo usage did not match expectations");
				Assert.AreEqual (shouldStrip, buildOutput.Contains ("MM2108"), "Warning did not match expectations");
			});
		}

		void AssertNoLipoOrWarning (string buildOutput, string context)
		{
			Assert.False (DidAnyLipoStrip (buildOutput), "lipo incorrectly run in context: " + context + "\n" + buildOutput);
			Assert.False (buildOutput.Contains ("MM2108"), "MM2108 incorrectly given in in context: " + context + "\n" + buildOutput);
		}

		void AssertLipoOnlyMonoPosix (string buildOutput, string context)
		{
			Assert.False (DidAnyLipoStripSkipPosix (buildOutput), "lipo incorrectly run in context outside of libMonoPosixHelper: " + context + "\n" + buildOutput);
			Assert.False (buildOutput.Contains ("MM2108"), "MM2108 incorrectly given in in context: " + context + "\n" + buildOutput);
		}

		[TestCase (false)]
		[TestCase (true)]
		public void ThirdPartyLibrary_WithIncorrectBitness_ShouldWarnOnRelease (bool sixtyFourBits)
		{
			MMPTests.RunMMPTest (tmpDir =>
			{
				var frameworkPath = FrameworkBuilder.CreateFatFramework (tmpDir);

				TI.UnifiedTestConfig test = CreateStripTestConfig (null, tmpDir, $" --native-reference=\"{frameworkPath}\"");

				// Should always skip lipo/warning in Debug
				string buildOutput = TI.TestUnifiedExecutable(test).BuildOutput;
				AssertNoLipoOrWarning (buildOutput, "Debug");

				// Should always lipo/warn in Release
				test.Release = true;
				buildOutput = TI.TestUnifiedExecutable (test).BuildOutput;
				Assert.True (DidAnyLipoStrip (buildOutput), $"lipo did not run in release\n{buildOutput}");
				Assert.True (buildOutput.Contains ("MM2108"), $"MM2108 not given in release\n{buildOutput}");

			});
		}

		[TestCase]
		public void ThirdPartyLibrary_WithCorrectBitness_ShouldNotStripOrWarn ()
		{
			MMPTests.RunMMPTest (tmpDir =>
			{
				var frameworkPath = FrameworkBuilder.CreateThinFramework (tmpDir);

				TI.UnifiedTestConfig test = CreateStripTestConfig (null, tmpDir, $" --native-reference=\"{frameworkPath}\"");

				string buildOutput = TI.TestUnifiedExecutable (test).BuildOutput;
				AssertNoLipoOrWarning (buildOutput, "Debug");

				test.Release = true;
				buildOutput = TI.TestUnifiedExecutable (test).BuildOutput;
				AssertLipoOnlyMonoPosix (buildOutput, "Release"); // libMonoPosixHelper.dylib will lipo in Release
			});
		}
	}
}
