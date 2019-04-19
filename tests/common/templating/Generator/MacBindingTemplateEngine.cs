using System;

namespace Xamarin.Tests.Templating
{
	public class MacBindingTemplateEngine : TemplateEngineBase
	{
		public MacBindingTemplateEngine (ProjectFlavor flavor, ProjectLanguage language = ProjectLanguage.CSharp) : base (new TemplateInfo (flavor, ProjectType.Binding, language))
		{
		}

		public MacBindingTemplateEngine (TemplateInfo info) : base (info)
		{
		}

		public string Generate (string outputDirectory, ProjectSubstitutions projectSubstitutions = null, FileSubstitutions fileSubstitutions = null)
		{
			projectSubstitutions = projectSubstitutions ?? new ProjectSubstitutions ();
			fileSubstitutions = fileSubstitutions ?? new FileSubstitutions ();

			FileCopier templateEngine = CreateEngine (outputDirectory);

			templateEngine.CopyFileWithSubstitutions ("ApiDefinition.cs", Replacement.Create ("%CODE%", fileSubstitutions.ApiDefinition));
			templateEngine.CopyFileWithSubstitutions ("StructsAndEnums.cs", Replacement.Create ("%CODE%", fileSubstitutions.StructsAndEnums));

			return templateEngine.CopyFileWithSubstitutions (TemplateInfo.ProjectName, GetStandardProjectReplacement (projectSubstitutions));
		}
	}
}
