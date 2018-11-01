using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Xamarin.MMP.Tests
{
	[TestFixture]
	public class PackageReferenceTests
	{
		const string PackageReference = @"<ItemGroup><PackageReference Include = ""Newtonsoft.Json"" Version = ""10.0.3"" /></ItemGroup>";
		const string TestCode = @"var output = Newtonsoft.Json.JsonConvert.SerializeObject (new int[] { 1, 2, 3 });";

		// [TestCase (true)] https://github.com/xamarin/xamarin-macios/issues/4110
		// [TestCase (false)] https://github.com/xamarin/xamarin-macios/issues/4110
		public void AppsWithPackageReferencs_BuildAndRun (bool full)
		{
			MMPTests.RunMMPTest (tmpDir => {
				var config = new TI.UnifiedTestConfig (tmpDir) {
					ItemGroup = PackageReference,
					TestCode = TestCode + @"			if (output == ""[1,2,3]"")
				",
					XM45 = full
				};
				TI.AddGUIDTestCode (config);

				string project = TI.GenerateAppProject (config);
				TI.NugetRestore (project);
				TI.BuildProject (project, true);
				TI.RunGeneratedUnifiedExecutable (config);
			});
		}

		// [Test] https://github.com/xamarin/xamarin-macios/issues/4110
		public void ExtensionProjectPackageReferencs_Build ()
		{
			MMPTests.RunMMPTest (tmpDir => {
				TI.CopyDirectory (Path.Combine (TI.FindSourceDirectory (), @"Today"), tmpDir);

				TI.NugetRestore (Path.Combine (tmpDir, "Today/TodayExtensionTest.csproj"));
				string output = TI.BuildProject (Path.Combine (tmpDir, "Today/TodayExtensionTest.csproj"), isUnified: true);
				Assert.IsTrue (!output.Contains ("MM2013"));
			});
		}
	}
}
