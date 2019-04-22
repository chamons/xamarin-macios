using System;
using System.IO;

namespace Xamarin.Tests.Templating
{
	public class MacAppTemplateEngine : TemplateEngineWithReplacements, IApplicationTemplateEngine
	{
		public PListSubstitutions PlistReplacements { get; set; } = null;
		public bool IncludeAssets { get; set; } = false;

		public TestAppRunner Runner { get; set; } = null;

		public MacAppTemplateEngine (ProjectFlavor flavor, ProjectLanguage language = ProjectLanguage.CSharp) : base (new TemplateInfo (flavor, ProjectType.App, language))
		{
		}

		public MacAppTemplateEngine (TemplateInfo info) : base (info)
		{
		}

		public string AppLocation => DefaultMacAppLocation.GetAppLocation (ProjectName, IsRelease, OutputDirectory);

		public string Generate ()
		{
			FileSubstitutions.TestCode += Runner?.TestCode;

			PlistReplacements = PlistReplacements ?? PListSubstitutions.None;
			FileCopier templateEngine = CreateEngine (OutputDirectory);

			if (IncludeAssets) {
				templateEngine.CopyDirectory ("Icons/Assets.xcassets");

				ProjectSubstitutions.ItemGroup += @"<ItemGroup>
    <ImageAsset Include=""Assets.xcassets\AppIcon.appiconset\Contents.json"" />
    <ImageAsset Include=""Assets.xcassets\AppIcon.appiconset\AppIcon-128.png"" />
    <ImageAsset Include=""Assets.xcassets\AppIcon.appiconset\AppIcon-128%402x.png"" />
    <ImageAsset Include=""Assets.xcassets\AppIcon.appiconset\AppIcon-16.png"" />
    <ImageAsset Include=""Assets.xcassets\AppIcon.appiconset\AppIcon-16%402x.png"" />
    <ImageAsset Include=""Assets.xcassets\AppIcon.appiconset\AppIcon-256%402x.png"" />
    <ImageAsset Include=""Assets.xcassets\AppIcon.appiconset\AppIcon-32.png"" />
    <ImageAsset Include=""Assets.xcassets\AppIcon.appiconset\AppIcon-32%402x.png"" />
    <ImageAsset Include=""Assets.xcassets\Contents.json"" />
  </ItemGroup>";

				// HACK - Should process using CopyFileWithSubstitutions
				PlistReplacements.Replacements.Add ("</dict>", @"<key>XSAppIconAssets</key><string>Assets.xcassets/AppIcon.appiconset</string></dict>");
			}

			ReplacementGroup replacements = ReplacementGroup.Create (Replacement.Create ("%CODE%", FileSubstitutions.TestCode), Replacement.Create ("%DECL%", FileSubstitutions.TestDecl));
			templateEngine.CopyTextWithSubstitutions (GetAppMainSourceText (TemplateInfo.Language), TemplateInfo.SourceName, replacements);

			templateEngine.CopyFileWithSubstitutions ("Info-Unified.plist", PlistReplacements.CreateReplacementAction (), "Info.plist");

			return templateEngine.CopyFileWithSubstitutions (TemplateInfo.ProjectName, GetStandardProjectReplacement (ProjectSubstitutions));
		}

		public static string GetAppMainSourceText (ProjectLanguage language)
		{
			const string FSharpMainTemplate = @"
namespace FSharpUnifiedExample
open System
open AppKit

module main =
    %DECL%
 
    [<EntryPoint>]
    let main args =
        NSApplication.Init ()
        %CODE%
        0";

			const string MainTemplate = @"
using Foundation;
using AppKit;

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

			return language == ProjectLanguage.FSharp ? FSharpMainTemplate : MainTemplate;
		}
	}
}