using System;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Xamarin.Utils;

namespace Xamarin.MMP.Tests
{
	public class BindingProjectTests
	{
		static string BindingName (bool full) => full ? "XM45Binding" : "MobileBinding";
		
		static Tuple<string, string> BuildLinkedTestProjects (string tmpDir, bool full = false, bool removeTFI = false)
		{
			string bindingName = BindingName (full);
			TI.UnifiedTestConfig test = new TI.UnifiedTestConfig (tmpDir) {
				ProjectName = bindingName + ".csproj",
				ItemGroup = MMPTests.CreateSingleNativeRef (Path.GetFullPath (MMPTests.SimpleDylibPath), "Dynamic"),
				StructsAndEnumsConfig = "public class UnifiedWithDepNativeRefLibTestClass {}"
			};

			if (removeTFI)
				test.CustomProjectReplacement = new Tuple<string, string> (@"<TargetFrameworkVersion>v4.5</TargetFrameworkVersion>", "");

			string projectPath = TI.GenerateBindingLibraryProject (test);
			string bindingBuildLog = TI.BuildProject (projectPath, true);

			string referenceCode = string.Format (@"<Reference Include=""{0}""><HintPath>{1}</HintPath></Reference>", bindingName, Path.Combine (tmpDir, "bin/Debug", bindingName + ".dll"));

			test = new TI.UnifiedTestConfig (tmpDir) {
				References = referenceCode,
				TestCode = "System.Console.WriteLine (typeof (ExampleBinding.UnifiedWithDepNativeRefLibTestClass));",
				XM45 = full					
			};
			string appBuildLog = TI.TestUnifiedExecutable (test).BuildOutput;

			return new Tuple<string, string> (bindingBuildLog, appBuildLog);
		}

		[Test]
		public void ShouldRemovePackagedLibrary_OnceInBundle ()
		{
			MMPTests.RunMMPTest (tmpDir => {
				BuildLinkedTestProjects (tmpDir);

				string libPath = Path.Combine (tmpDir, "bin/Debug/UnifiedExample.app/Contents/MonoBundle/MobileBinding.dll");
				Assert.True (File.Exists (libPath));
				string monoDisResults = TI.RunAndAssert ("/Library/Frameworks/Mono.framework/Commands/monodis", "--presources " + libPath, "monodis");
				Assert.IsFalse (monoDisResults.Contains ("SimpleClassDylib.dylib"));
			});
		}

		[TestCase (false, false)]
		[TestCase (true, false)]
		[TestCase (true, true)]
		public void ShouldBuildWithoutErrors_AndLinkCorrectFramework (bool full, bool removeTFI)
		{
			// TODO - Build and test BindingProjectWithNoTag.csproj which is Modern without tags
			// TODO - Abstract this into a helper called by multiple tests
			MMPTests.RunMMPTest (tmpDir => {
				var logs = BuildLinkedTestProjects (tmpDir, full, removeTFI);

				var bgenInvocation = logs.Item1.SplitLines ().First (x => x.Contains ("bgen execution started with arguments"));
				var bgenParts = bgenInvocation.Split (new char[] { ' ' });
				var mscorlib = bgenParts.First (x => x.Contains ("mscorlib.dll"));
				var system = bgenParts.First (x => x.Contains ("System.dll"));

				if (full) {
					Assert.True (mscorlib.EndsWith("lib/mono/4.5/mscorlib.dll", StringComparison.Ordinal), "mscorlib not found in expected Full location: " + mscorlib);
					Assert.True (system.EndsWith ("lib/mono/4.5/System.dll", StringComparison.Ordinal), "system not found in expected Full location: " + system);
				} else {
					Assert.True (mscorlib.EndsWith ("lib/mono/Xamarin.Mac/mscorlib.dll", StringComparison.Ordinal), "mscorlib not found in expected Modern location: " + mscorlib);
					Assert.True (system.EndsWith ("lib/mono/Xamarin.Mac/System.dll", StringComparison.Ordinal), "system not found in expected Modern location: " + system);
				}

				Assert.False (logs.Item1.Contains ("CS1685"), "Binding should not contains CS1685 multiple definition warning:\n" + logs.Item1);


				string libPath = Path.Combine (tmpDir, $"bin/Debug/{(full ? "XM45Example.app" : "UnifiedExample.app")}/Contents/MonoBundle/{BindingName (full)}.dll");
				Assert.True (File.Exists (libPath));
				string results = TI.RunAndAssert ("/Library/Frameworks/Mono.framework/Commands/monop", "--refs -r:" + libPath, "monop");
				string mscorlibLine = results.Split (new char[] { '\n' }).First (x => x.Contains ("mscorlib"));

				string expectedVersion = full ? "4.0.0.0" : "2.0.5.0";
				Assert.True (mscorlibLine.Contains (expectedVersion), $"{mscorlibLine} did not contain expected version {expectedVersion}");
			});
		}
	}
}
