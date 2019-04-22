using System;
namespace Xamarin.Tests.Templating
{
	public class MacClassicAppTemplateEngine : TemplateEngineWithReplacements
	{
		public bool IncludeMonoRuntime { get; set; } = false;

		public MacClassicAppTemplateEngine () : base (TemplateInfo.FromFiles ("ClassicExample.csproj", "Main.cs"))
		{
		}

		public MacClassicAppTemplateEngine (TemplateInfo info) : base (info)
		{
		}

		public string Generate ()
		{
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
			FileCopier templateEngine = CreateEngine (OutputDirectory);

			ReplacementGroup replacements = ReplacementGroup.Create (Replacement.Create ("%CODE%", FileSubstitutions.TestCode), Replacement.Create ("%DECL%", FileSubstitutions.TestDecl));
			templateEngine.CopyTextWithSubstitutions (TestCode, TemplateInfo.SourceName, replacements);

			templateEngine.CopyFile ("Info-Classic.plist", "Info.plist");

			ReplacementGroup replacementGroup = ReplacementGroup.Create (Replacement.Create ("%CODE%", ProjectSubstitutions.CSProjConfig), Replacement.Create ("%INCLUDE_MONO_RUNTIME%", IncludeMonoRuntime.ToString ()));
			return templateEngine.CopyFileWithSubstitutions (TemplateInfo.ProjectName, replacementGroup);
		}
	}
}
