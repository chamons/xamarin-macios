using System;
namespace Xamarin.Tests.Templating
{
	public class MacSystemMonoTemplateEngine : TemplateEngineWithReplacements, IApplicationTemplateEngine
	{
		TestAppRunner Runner { get; set; } = null;

		public MacSystemMonoTemplateEngine () : base (TemplateInfo.FromFiles ("SystemMonoExample.csproj", "Main.cs"))
		{
		}

		public MacSystemMonoTemplateEngine (TemplateInfo info) : base (info)
		{
		}

		public string AppLocation => DefaultMacAppLocation.GetAppLocation (ProjectName, IsRelease, OutputDirectory);

		public string Generate ()
		{
			FileSubstitutions.TestCode += Runner?.TestCode;

			FileCopier templateEngine = CreateEngine (OutputDirectory);

			ReplacementGroup replacements = ReplacementGroup.Create (Replacement.Create ("%CODE%", FileSubstitutions.TestCode), Replacement.Create ("%DECL%", FileSubstitutions.TestDecl));
			templateEngine.CopyTextWithSubstitutions (MacAppTemplateEngine.GetAppMainSourceText (ProjectLanguage.CSharp), TemplateInfo.SourceName, replacements);

			templateEngine.CopyFile ("Info-Unified.plist", "Info.plist");

			return templateEngine.CopyFileWithSubstitutions (TemplateInfo.ProjectName, GetStandardProjectReplacement (ProjectSubstitutions));
		}
	}
}
