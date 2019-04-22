﻿using System;

namespace Xamarin.Tests.Templating
{
	public interface IApplicationTemplateEngine
	{
		string Generate ();

		string AppLocation { get; }
		string OutputDirectory { get; set; }
		FileSubstitutions FileSubstitutions { get; set; }
	}

	static class DefaultMacAppLocation
	{
		public static string GetAppLocation (string projectName, bool isRelease = false, string testDirectory = null)
		{
			testDirectory = testDirectory ?? TestDirectory.Path;
			return $"{testDirectory}/bin/{(isRelease ? "Release" : "Debug")}/{projectName}.app/Contents/MacOS/{projectName}";
		}
	}
}
