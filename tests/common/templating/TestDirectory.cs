using System;

namespace Xamarin.Tests.Templating
{
	// Syntatic sugar for test temporary directory
	public static class TestDirectory
	{
		static string path;

		public static string Path
		{
			get
			{
				if (path == null)
					path = Cache.CreateTemporaryDirectory ();
				return path;
			}
		}
	}
}
