using System;

namespace Xamarin.Tests.Templating
{
	public class MacBindingTemplateEngine : TemplateEngineWithReplacements
	{
		public MacBindingTemplateEngine (ProjectFlavor flavor, ProjectLanguage language = ProjectLanguage.CSharp) : base (new TemplateInfo (flavor, ProjectType.Binding, language))
		{
		}

		public MacBindingTemplateEngine (TemplateInfo info) : base (info)
		{
		}

		public string Generate ()
		{
			FileCopier templateEngine = CreateEngine (OutputDirectory);

			templateEngine.CopyFileWithSubstitutions ("ApiDefinition.cs", Replacement.Create ("%CODE%", FileSubstitutions.ApiDefinition));
			templateEngine.CopyFileWithSubstitutions ("StructsAndEnums.cs", Replacement.Create ("%CODE%", FileSubstitutions.StructsAndEnums));

			return templateEngine.CopyFileWithSubstitutions (TemplateInfo.ProjectName, GetStandardProjectReplacement (ProjectSubstitutions));
		}
	}
}
