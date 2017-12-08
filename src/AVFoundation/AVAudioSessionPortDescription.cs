// 
// AVAudioSessionPortDescription.cs
//
// Authors: Rolf Bjarne Kvinge <rolf@xamarin.com>
//     
// Copyright 2015 Xamarin Inc.
//

using System;

using XamCore.Foundation;
using XamCore.CoreFoundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.AudioToolbox;

#if !MONOMAC
namespace XamCore.AVFoundation {
	public partial class AVAudioSessionPortDescription {
#if !XAMCORE_3_0
		[Obsolete ("Use 'DataSourceDescriptions' instead.")]
		public virtual AVAudioSessionChannelDescription [] DataSources {
			get {
				throw new InvalidOperationException ("Call DataSourceDescriptions instead.");
			}
		}
#endif	       
	}
}
#endif

