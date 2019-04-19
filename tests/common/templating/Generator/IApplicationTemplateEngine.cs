using System;

namespace Xamarin.Tests.Templating
{
	public interface IApplicationTemplateEngine
	{
		// Right now you have to bounce back and forth between classes like:

		//var engine = new MacAppTemplateEngine (full ? ProjectFlavor.FullXM : ProjectFlavor.ModernXM, ProjectLanguage.CSharp);
		//var appRunner = new TestAppRunner ();
		//string projectPath = engine.Generate (appRunner);

		//ProjectBuilder.BuildProject(projectPath);
		//appRunner.Execute(engine.GetAppLocation ());

		// This is confusing.
		// The root problem is that the app runner doesn't know what an app
		// template engine looks like, so it can't generate the app
		// However, the app runner _has_ to modify the file substitutions to 
		// add the test code.
		// If we could have an interface between the various project types
		// We could do something like:

		//var engine = new MacAppTemplateEngine (full ? ProjectFlavor.FullXM : ProjectFlavor.ModernXM, ProjectLanguage.CSharp);
		//var appRunner = new TestAppRunner (engine);
		//appRunner.Execute(engine.GetAppLocation ());

		// possibling passing in extra subs.

		// The problem to solve is that each template engine has some "extras" parmas
	}
}
