using System;
using System.IO;
using NUnit.Framework;

namespace Xamarin.Tests.Templating
{
	public class TestAppRunner
	{
		IApplicationTemplateEngine AppEngine;
		readonly string ExpectedPath;
		public string TestCode => string.Format ("System.IO.File.Create(\"{0}\").Dispose();", ExpectedPath);

		public TestAppRunner (IApplicationTemplateEngine appEngine)
		{
			AppEngine = appEngine;

			var guid = Guid.NewGuid ();
			ExpectedPath = Path.Combine (AppEngine.OutputDirectory, guid.ToString ());
			AppEngine.FileSubstitutions.TestCode += TestCode;
		}

		public void BuildAndExecute ()
		{
			string projectPath = AppEngine.Generate ();
			ProjectBuilder.BuildProject (projectPath);
			Execute (AppEngine.AppLocation);
		}

		void Execute (string path)
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
