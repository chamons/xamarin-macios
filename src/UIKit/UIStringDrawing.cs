#if IOS

using System;

using XamCore.UIKit;
using XamCore.CoreGraphics;
using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.UIKit {
	public unsafe static partial class UIStringDrawing  {
		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.DrawString(CGPoint, UIStringAttributes) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.DrawString(CGPoint, UIStringAttributes) instead.")]
		public static CGSize DrawString (this string This, CGPoint point, UIFont font)
		{
			using (var self = ((NSString) This))
				return self.DrawString (point, font);
		}

		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead.")]
		public static CGSize DrawString (this string This, CGPoint point, global::System.nfloat width, UIFont font, UILineBreakMode breakMode)
		{
			using (var self = ((NSString) This))
				return self.DrawString (point, width, font, breakMode);
		}

		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead.")]
		public static CGSize DrawString (this string This, CGPoint point, global::System.nfloat width, UIFont font, global::System.nfloat fontSize, UILineBreakMode breakMode, UIBaselineAdjustment adjustment)
		{
			using (var self = ((NSString) This))
				return self.DrawString (point, width, font, fontSize, breakMode, adjustment);
		}

		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead.")]
		public static CGSize DrawString (this string This, CGPoint point, global::System.nfloat width, UIFont font, global::System.nfloat minFontSize, ref global::System.nfloat actualFontSize, UILineBreakMode breakMode, UIBaselineAdjustment adjustment)
		{
			using (var self = ((NSString) This))
				return self.DrawString (point, width, font, minFontSize, ref actualFontSize, breakMode, adjustment);
		}

		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead.")]
		public static CGSize DrawString (this string This, CGRect rect, UIFont font)
		{
			using (var self = ((NSString) This))
				return self.DrawString (rect, font);
		}

		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead.")]
		public static CGSize DrawString (this string This, CGRect rect, UIFont font, UILineBreakMode mode)
		{
			using (var self = ((NSString) This))
				return self.DrawString (rect, font, mode);
		}

		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.DrawString(CGRect, UIStringAttributes) instead.")]
		public static CGSize DrawString (this string This, CGRect rect, UIFont font, UILineBreakMode mode, UITextAlignment alignment)
		{
			using (var self = ((NSString) This))
				return self.DrawString (rect, font, mode, alignment);
		}

		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.GetSizeUsingAttributes(UIStringAttributes) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.GetSizeUsingAttributes(UIStringAttributes) instead.")]
		public static CGSize StringSize (this string This, UIFont font)
		{
			using (var self = ((NSString) This))
				return self.StringSize (font);
		}

		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.GetBoundingRect (CGSize, NSStringDrawingOptions, UIStringAttributes, NSStringDrawingContext) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.GetBoundingRect (CGSize, NSStringDrawingOptions, UIStringAttributes, NSStringDrawingContext) instead.")]
		public static CGSize StringSize (this string This, UIFont font, global::System.nfloat forWidth, UILineBreakMode breakMode)
		{
			using (var self = ((NSString) This))
				return self.StringSize (font, forWidth, breakMode);
		}

		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.GetBoundingRect (CGSize, NSStringDrawingOptions, UIStringAttributes, NSStringDrawingContext) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.GetBoundingRect (CGSize, NSStringDrawingOptions, UIStringAttributes, NSStringDrawingContext) instead.")]
		public static CGSize StringSize (this string This, UIFont font, CGSize constrainedToSize)
		{
			using (var self = ((NSString) This))
				return self.StringSize (font, constrainedToSize);
		}

		[Introduced (PlatformName.iOS, 2, 0, message: "Use NSString.GetBoundingRect (CGSize, NSStringDrawingOptions, UIStringAttributes, NSStringDrawingContext) instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use NSString.GetBoundingRect (CGSize, NSStringDrawingOptions, UIStringAttributes, NSStringDrawingContext) instead.")]
		public static CGSize StringSize (this string This, UIFont font, CGSize constrainedToSize, UILineBreakMode lineBreakMode)
		{
			using (var self = ((NSString) This))
				return self.StringSize (font, constrainedToSize, lineBreakMode);
		}

		[Introduced (PlatformName.iOS, 2, 0), Deprecated (PlatformName.iOS, 7, 0)]
		public static CGSize StringSize (this string This, UIFont font, global::System.nfloat minFontSize, ref global::System.nfloat actualFontSize, global::System.nfloat forWidth, UILineBreakMode lineBreakMode)
		{
			using (var self = ((NSString) This))
				return self.StringSize (font, minFontSize, ref actualFontSize, forWidth, lineBreakMode);
		}
	}
}

#endif // IOS
