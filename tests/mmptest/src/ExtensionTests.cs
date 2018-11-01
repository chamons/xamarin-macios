using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;

namespace Xamarin.MMP.Tests
{
	[TestFixture]
	public class ExtensionTests 
	{
		[Test]
		public void TodayExtension_SmokeTest ()
		{
			if (!PlatformHelpers.CheckSystemVersion (10, 10))
				return;

			MMPTests.RunMMPTest (tmpDir =>
			{
				TI.CopyDirectory (Path.Combine (TI.FindSourceDirectory (), @"Today"), tmpDir);
				TI.BuildProject (Path.Combine (tmpDir, "Today/TodayExtensionTest.csproj"), isUnified: true);
			});
		}

		[Test]
		public void FinderExtension_SmokeTest ()
		{
			if (!PlatformHelpers.CheckSystemVersion (10, 10))
				return;

			MMPTests.RunMMPTest (tmpDir =>
			{
				TI.CopyDirectory (Path.Combine (TI.FindSourceDirectory (), @"Finder"), tmpDir);
				TI.BuildProject (Path.Combine (tmpDir, "Finder/FinderExtensionTest.csproj"), isUnified: true);
			});
		}

		[Test]
		public void ShareExtension_SmokeTest ()
		{
			if (!PlatformHelpers.CheckSystemVersion (10, 10))
				return;

			MMPTests.RunMMPTest (tmpDir =>
			{
				TI.CopyDirectory (Path.Combine (TI.FindSourceDirectory (), @"Share"), tmpDir);
				TI.BuildProject (Path.Combine (tmpDir, "Share/ShareExtensionTest.csproj"), isUnified: true);
			});
		}
	}
}
