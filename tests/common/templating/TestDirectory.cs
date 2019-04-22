using System;
using System.Linq;

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
					path = Cache.CreateTemporaryDirectory (FindTestName ());
				return path;
			}
		}

		static string FindTestName ()
		{
			var trace = new System.Diagnostics.StackTrace ();
			var calling_method = trace.GetFrames ().First (x => !x.GetMethod ().DeclaringType.FullName.StartsWith ("Xamarin.Tests.Templating", StringComparison.Ordinal)).GetMethod ();
			return calling_method.DeclaringType.FullName + "." + calling_method.Name;
		}
	}
}
