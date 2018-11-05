using System;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Utils;
using Xamarin.Tests;

namespace Xamarin.Tests.Templating
{
	public static class TemplateBuilder
	{
		public static string BuildProject (string csprojTarget, bool isUnified, bool shouldFail = false, bool release = false, string[] environment = null)
		{
			// These are required to have {ms,x}build use are local build instead of system install
			Environment.SetEnvironmentVariable ("TargetFrameworkFallbackSearchPaths", Configuration.TargetDirectoryXM + "/Library/Frameworks/Mono.framework/External/xbuild-frameworks");
			Environment.SetEnvironmentVariable ("MSBuildExtensionsPathFallbackPathsOverride", Configuration.TargetDirectoryXM + "/Library/Frameworks/Mono.framework/External/xbuild");
			Environment.SetEnvironmentVariable ("XAMMAC_FRAMEWORK_PATH", Configuration.SdkRootXM);
			Environment.SetEnvironmentVariable ("XamarinMacFrameworkRoot", Configuration.SdkRootXM);

			// This is to force build to use our mmp and not system mmp
			StringBuilder buildArgs = new StringBuilder ();
			if (isUnified) {
				buildArgs.Append (" /verbosity:diagnostic ");
				buildArgs.Append (" /property:XamarinMacFrameworkRoot=" + Configuration.SdkRootXM);

				if (release)
					buildArgs.Append ("/property:Configuration=Release ");
				else
					buildArgs.Append ("/property:Configuration=Debug ");

			} else {
				buildArgs.Append (" build ");
			}

			buildArgs.Append (StringUtils.Quote (csprojTarget));

			Func<string> getBuildProjectErrorInfo = () => {
				string csprojText = "\n\n\n\tCSProj: \n" + File.ReadAllText (csprojTarget);
				string csprojLocation = Path.GetDirectoryName (csprojTarget);
				string fileList = "\n\n\tFiles: " + String.Join (" ", Directory.GetFiles (csprojLocation).Select (x => x.Replace (csprojLocation + "/", "")));
				return csprojText + fileList;
			};

			if (isUnified)
				return Invoker.RunAndAssert ("/Library/Frameworks/Mono.framework/Commands/msbuild", buildArgs, "Compile", shouldFail, getBuildProjectErrorInfo, environment);
			else
				return Invoker.RunAndAssert ("/Applications/Visual Studio.app/Contents/MacOS/vstool", buildArgs, "Compile", shouldFail, getBuildProjectErrorInfo, environment);
		}
	}
}
