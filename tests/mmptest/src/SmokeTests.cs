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

			var appRunner = new TestAppRunner (engine);
			appRunner.BuildAndExecute ();
		}

		[TestCase (false)]
		[TestCase (true)]
		public void FSharp_SmokeTest (bool full)
		{
			var engine = new MacAppTemplateEngine (full ? ProjectFlavor.FullXM : ProjectFlavor.ModernXM, ProjectLanguage.FSharp);

			var appRunner = new TestAppRunner (engine);
			appRunner.BuildAndExecute ();
		}

		[TestCase ("SdkOnly")]
		[TestCase ("Full")]
		public void Modern_SmokeTest_LinkSDK (string linkMode)
		{
			var engine = new MacAppTemplateEngine (ProjectFlavor.ModernXM, ProjectLanguage.CSharp) {
				ProjectSubstitutions = new ProjectSubstitutions { CSProjConfig = $"<LinkMode>{linkMode}</LinkMode>" }
			};
			
			var appRunner = new TestAppRunner (engine);
			appRunner.BuildAndExecute ();
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

			var engine = new MacSystemMonoTemplateEngine () {
				ProjectSubstitutions = new ProjectSubstitutions { TargetFrameworkVersion = version }
			};

			var appRunner = new TestAppRunner (engine);
			appRunner.BuildAndExecute ();
		}
	}
}
