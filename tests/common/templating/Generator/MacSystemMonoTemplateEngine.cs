using System;
namespace Xamarin.Tests.Templating
{
	public class MacSystemMonoTemplateEngine : TemplateEngineBase, IApplicationTemplateEngine
	{
		public MacSystemMonoTemplateEngine () : base (TemplateInfo.FromFiles ("SystemMonoExample.csproj", "Main.cs"))
		{
		}

		public MacSystemMonoTemplateEngine (TemplateInfo info) : base (info)
		{
		}

		public string GetAppLocation (bool isRelease = false, string testDirectory = null) => DefaultMacAppLocation.GetAppLocation (ProjectName, isRelease, testDirectory);

		public string Generate (string outputDirectory = null, ProjectSubstitutions projectSubstitutions = null, FileSubstitutions fileSubstitutions = null, TestAppRunner runner = null)
		{
			outputDirectory = outputDirectory ?? TestDirectory.Path;
			projectSubstitutions = projectSubstitutions ?? new ProjectSubstitutions ();
			fileSubstitutions = fileSubstitutions ?? new FileSubstitutions ();

			fileSubstitutions.TestCode += runner?.TestCode;

			FileCopier templateEngine = CreateEngine (outputDirectory);

			ReplacementGroup replacements = ReplacementGroup.Create (Replacement.Create ("%CODE%", fileSubstitutions.TestCode), Replacement.Create ("%DECL%", fileSubstitutions.TestDecl));
			templateEngine.CopyTextWithSubstitutions (MacAppTemplateEngine.GetAppMainSourceText (ProjectLanguage.CSharp), TemplateInfo.SourceName, replacements);

			templateEngine.CopyFile ("Info-Unified.plist", "Info.plist");

			return templateEngine.CopyFileWithSubstitutions (TemplateInfo.ProjectName, GetStandardProjectReplacement (projectSubstitutions));
		}
	}
}
