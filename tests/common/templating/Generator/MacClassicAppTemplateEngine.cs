using System;
namespace Xamarin.Tests.Templating
{
	public class MacClassicAppTemplateEngine : TemplateEngineBase, IApplicationTemplateEngine
	{
		public MacClassicAppTemplateEngine () : base (TemplateInfo.FromFiles ("ClassicExample.csproj", "Main.cs"))
		{
		}

		public MacClassicAppTemplateEngine (TemplateInfo info) : base (info)
		{
		}

		public string Generate (string outputDirectory, ProjectSubstitutions projectSubstitutions = null, FileSubstitutions fileSubstitutions = null, bool includeMonoRuntime = false)
		{
			projectSubstitutions = projectSubstitutions ?? new ProjectSubstitutions ();
			fileSubstitutions = fileSubstitutions ?? new FileSubstitutions ();

			const string TestCode = @"using MonoMac.Foundation;
using MonoMac.AppKit;

namespace TestCase
{
	class MainClass
	{
		%DECL%

		static void Main (string[] args)
		{
			NSApplication.Init ();
			%CODE%
		}
	}
}";
			FileCopier templateEngine = CreateEngine (outputDirectory);

			ReplacementGroup replacements = ReplacementGroup.Create (Replacement.Create ("%CODE%", fileSubstitutions.TestCode), Replacement.Create ("%DECL%", fileSubstitutions.TestDecl));
			templateEngine.CopyTextWithSubstitutions (TestCode, TemplateInfo.SourceName, replacements);

			templateEngine.CopyFile ("Info-Classic.plist", "Info.plist");

			ReplacementGroup replacementGroup = ReplacementGroup.Create (Replacement.Create ("%CODE%", projectSubstitutions.CSProjConfig), Replacement.Create ("%INCLUDE_MONO_RUNTIME%", includeMonoRuntime.ToString ()));
			return templateEngine.CopyFileWithSubstitutions (TemplateInfo.ProjectName, replacementGroup);
		}
	}
}
