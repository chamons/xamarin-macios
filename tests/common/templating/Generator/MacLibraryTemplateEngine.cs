using System;
namespace Xamarin.Tests.Templating
{
	public class MacLibraryTemplateEngine : TemplateEngineWithReplacements
	{
		public MacLibraryTemplateEngine (ProjectFlavor flavor, ProjectLanguage language = ProjectLanguage.CSharp) : base (new TemplateInfo (flavor, ProjectType.Library, language))
		{
		}

		public MacLibraryTemplateEngine (TemplateInfo info) : base (info)
		{
		}

		public string Generate ()
		{
			FileCopier templateEngine = CreateEngine (OutputDirectory);

			templateEngine.CopyFileWithSubstitutions (TemplateInfo.SourceName, Replacement.Create ("%CODE%", FileSubstitutions.TestCode));

			return templateEngine.CopyFileWithSubstitutions (TemplateInfo.ProjectName, GetStandardProjectReplacement (ProjectSubstitutions));
		}
	}
}
