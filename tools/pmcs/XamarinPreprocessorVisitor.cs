//
// XamarinPreprocessorVisitor.cs
//
// Author:
//   Aaron Bockover <abock@xamarin.com>
//
// Copyright 2015 Xamarin Inc. All rights reserved.

using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Pmcs.CSharp;
using Xamarin.Pmcs.CSharp.Ast;

namespace Xamarin.Pmcs
{
	class XamarinPreprocessorVisitor : Preprocessor.PreprocessorVisitor
	{
		public XamarinPreprocessorVisitor (Preprocessor preprocessor) : base (preprocessor)
		{
		}

		public override void VisitInvocationExpression (InvocationExpression invocationExpression)
		{
			var target = invocationExpression.Target as LiteralExpression;
			if (target == null)
				return;

			switch (target.Value) {
 			case "Availability":
 			case "AvailabilityAttribute":
 				VisitAvailabilityAttribute (invocationExpression);
 				break;
			default:
				base.VisitInvocationExpression (invocationExpression);
				break;
			}
		}

		void VisitAvailabilityAttribute (InvocationExpression invocationExpression)
		{
			new AvailabilityAttributeVisitor ().ProcessAvailabilityAttribute (invocationExpression);
		}

		class AvailabilityAttributeVisitor : DepthFirstAstVisitor
		{
			readonly List<InvocationExpression> invocations = new List<InvocationExpression> ();

			string currentAvailability;
			string message;
			int originalArgIndex;

			public void ProcessAvailabilityAttribute (InvocationExpression invocationExpression)
			{
				originalArgIndex = 0;
				message = null;
				invocations.Clear ();

				foreach (var arg in invocationExpression.Arguments) {
					currentAvailability = null;

					arg.AcceptVisitor (this);

					foreach (var newAttr in invocations) {
						if (message != null)
							newAttr.AddArgument (new NamedExpression (
								new LiteralExpression ("message"),
								TokenType.Colon,
								new LiteralExpression (message)
							));

						invocationExpression.Parent.InsertChildBefore (
							invocationExpression, newAttr);
					}

					originalArgIndex++;
				}

				invocationExpression.Remove ();
			}

			public override void VisitNamedExpression (NamedExpression namedExpression)
			{
				VisitBinaryExpression (namedExpression);
			}

			public override void VisitBinaryExpression (BinaryExpression binaryExpression)
			{
				var nameExpr = binaryExpression.LeftOperand as LiteralExpression;
				if (nameExpr != null && (binaryExpression.Operator == TokenType.Assign ||
					binaryExpression.Operator == TokenType.Colon)) {
					switch (nameExpr.Value) {
					case "Introduced":
					case "introduced":
						currentAvailability = "Introduced";
						break;
					case "Deprecated":
					case "deprecated":
						currentAvailability = "Deprecated";
						break;
					case "Obsoleted":
					case "obsoleted":
						currentAvailability = "Obsoleted";
						break;
					case "Unavailable":
					case "unavailable":
						currentAvailability = "Obsoleted";
						break;
					case "Message":
					case "message":
						var messageExpr = binaryExpression.RightOperand as LiteralExpression;
						if (messageExpr != null)
							message = messageExpr.Value;
						break;
					}
				}

				base.VisitBinaryExpression (binaryExpression);
			}

			public override void VisitLiteralExpression (LiteralExpression literalExpression)
			{
				var parts = literalExpression?.Value?.Split ('_');
				if (parts == null || parts.Length < 2)
					return;

				string platformName;
				switch (parts [0]) {
				case "Platform.Mac":
					platformName = "PlatformName.MacOSX";
					break;
				case "Platform.iOS":
					platformName = "PlatformName.iOS";
					break;
				default:
					return;
				}

				if (currentAvailability == null) {
					switch (originalArgIndex) {
					case 0:
						currentAvailability = "Introduced";
						break;
					case 1:
						currentAvailability = "Deprecated";
						break;
					case 2:
						currentAvailability = "Obsoleted";
						break;
					case 3:
						currentAvailability = "Unavailable";
						break;
					}
				}

				var attr = new InvocationExpression (currentAvailability);
				attr.AddArgument (new LiteralExpression (platformName));

				if (parts.Length == 2) {
					switch (parts [1]) {
					case "Version":
						break;
					case "Arch32":
						attr.AddArgument (new LiteralExpression ("PlatformArchitecture.Arch32"));
						break;
					case "Arch64":
						attr.AddArgument (new LiteralExpression ("PlatformArchitecture.Arch64"));
						break;
					}
				} else {
					for (int i = 1; i < parts.Length; i++)
						attr.AddArgument (new LiteralExpression (parts [i]));
				}

				invocations.Add (attr);
			}
		}
	}
}
