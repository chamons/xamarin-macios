using System;

using NUnit.Framework;
using Xamarin.Tests;
using Xamarin.Tests.Templating;

namespace Xamarin.MMP.Tests
{
	[TestFixture]
	public class SmokeTests
	{
		[TestCase (false)]
		[TestCase (true)]
		public void Unified_SmokeTest (bool full)
		{
			var engine = new MacAppTemplateEngine (full ? ProjectFlavor.FullXM : ProjectFlavor.ModernXM, ProjectLanguage.CSharp);
			string projectPath = engine.Generate (TestDirectory.Path);
			ProjectBuilder.BuildProject (projectPath);
		}

		[TestCase (false)]
		[TestCase (true)]
		public void FSharp_SmokeTest (bool full)
		{
			var engine = new MacAppTemplateEngine (full ? ProjectFlavor.FullXM : ProjectFlavor.ModernXM, ProjectLanguage.FSharp);
			string projectPath = engine.Generate (TestDirectory.Path);
			ProjectBuilder.BuildProject (projectPath);
		}

		[Test]
		public void Modern_SmokeTest_LinkSDK ()
		{
			var engine = new MacAppTemplateEngine (ProjectFlavor.ModernXM, ProjectLanguage.CSharp);
			var projectSubstitutions = new ProjectSubstitutions { CSProjConfig = "<LinkMode>SdkOnly</LinkMode>" };
			string projectPath = engine.Generate (TestDirectory.Path, projectSubstitutions);
			ProjectBuilder.BuildProject (projectPath);
		}

		[Test]
		public void Modern_SmokeTest_LinkAll ()
		{
			var engine = new MacAppTemplateEngine (ProjectFlavor.ModernXM, ProjectLanguage.CSharp);
			var projectSubstitutions = new ProjectSubstitutions { CSProjConfig = "<LinkMode>Full</LinkMode>" };
			string projectPath = engine.Generate (TestDirectory.Path, projectSubstitutions);
			ProjectBuilder.BuildProject (projectPath);
		}

		[TestCase ("")]
		[TestCase ("4.5")]
		[TestCase ("4.5.1")]
		[TestCase ("4.6")]
		[TestCase ("4.6.1")]
		[TestCase ("4.7")]
		public void SystemMono_SmokeTest (string version)
		{
			if (TI.FindMonoVersion () < new Version ("4.3"))
				return;

			var engine = new MacSystemMonoTemplateEngine ();
			var projectSubstitutions = new ProjectSubstitutions { TargetFrameworkVersion = version };
			string projectPath = engine.Generate (TestDirectory.Path, projectSubstitutions);
			ProjectBuilder.BuildProject (projectPath);
		}
	}
}
