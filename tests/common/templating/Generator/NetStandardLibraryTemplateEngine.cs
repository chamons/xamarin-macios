using System;
using System.IO;

namespace Xamarin.Tests.Templating
{
	public class NetStandardLibraryTemplateEngine : TemplateEngineBase
	{
		public NetStandardLibraryTemplateEngine () : base (TemplateInfo.FromFiles ("NetStandardLib.csproj", "Class1.cs"))
		{
		}

		const string NetStandardSubDir = "NetStandard";

		public string Generate ()
		{
			Directory.CreateDirectory (Path.Combine (OutputDirectory, NetStandardSubDir));

			FileCopier templateEngine = CreateEngine (OutputDirectory);
			templateEngine.CopyFile (TemplateInfo.SourceName);
			return templateEngine.CopyFile (TemplateInfo.ProjectName);
		}

		protected override FileCopier CreateEngine (string outputDirectory) => FileCopier.WithSubdirectory (DirectoryFinder.FindSourceDirectory (), outputDirectory, NetStandardSubDir);
	}
}
