// Copyright 2009, Novell, Inc.
// Copyright 2010, Novell, Inc.
// Copyright 2011, 2012, 2014-2015 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//
using System;
using System.Runtime.InteropServices;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif
using AvailabilityAttribute = XamCore.ObjCRuntime.Extensions.AvailabilityAttribute;
using Platform = XamCore.ObjCRuntime.Extensions.Platform;


namespace XamCore.AVFoundation {

	[iOS (9,0), Mac (10,11)]
	[StructLayout (LayoutKind.Sequential)]
	public struct AVAudioConverterPrimeInfo {
		public uint LeadingFrames;
		public uint TrailingFrames;

		public AVAudioConverterPrimeInfo (uint leadingFrames, uint trailingFrames)
		{
			LeadingFrames = leadingFrames;
			TrailingFrames = trailingFrames;
		}

		public override string ToString ()
		{
			return $"({LeadingFrames}:{TrailingFrames})";
		}

		public static bool operator == (AVAudioConverterPrimeInfo left, AVAudioConverterPrimeInfo right)
		{
			return left.Equals (right);
		}

		public static bool operator != (AVAudioConverterPrimeInfo left, AVAudioConverterPrimeInfo right)
		{
			return !left.Equals (right);
		}

		public override bool Equals (object obj)
		{
			if (!(obj is AVAudioConverterPrimeInfo))
				return false;

			return this.Equals ((AVAudioConverterPrimeInfo)obj);
		}

		public bool Equals (AVAudioConverterPrimeInfo other)
		{
			return LeadingFrames == other.LeadingFrames && TrailingFrames == other.TrailingFrames;
		}

		public override int GetHashCode ()
		{
			return LeadingFrames.GetHashCode () ^ TrailingFrames.GetHashCode ();
		}
	}
}
