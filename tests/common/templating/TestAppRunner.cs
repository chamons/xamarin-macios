using System;
using System.IO;
using NUnit.Framework;

namespace Xamarin.Tests.Templating
{
	public class TestAppRunner
	{
		readonly string ExpectedPath;
		public FileSubstitutions FileSubstitutions { get; private set; }

		string OutputCommand => string.Format ("System.IO.File.Create(\"{0}\").Dispose();", ExpectedPath);

		public TestAppRunner (string testDirectory = null)
		{
			testDirectory = testDirectory ?? TestDirectory.Path;

			var guid = Guid.NewGuid ();
			ExpectedPath = Path.Combine (testDirectory, guid.ToString ());
			FileSubstitutions = new FileSubstitutions () { TestCode = OutputCommand };
		}

		public void Execute (string path)
		{
			// Assert that the program actually runs and returns our guid
			Assert.IsTrue (File.Exists (path), $"{0} not found. Project was not built?");
			ProcessInvoker.RunAndAssert (path);

			Assert.IsTrue (File.Exists (ExpectedPath), $"Generated app did not create expected file: {ExpectedPath}");

			// Let's delete the guid file so re-runs inside same tests are accurate
			File.Delete (ExpectedPath);
		}
	}
}
