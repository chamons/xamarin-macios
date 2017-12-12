//
// This file describes the API that the generator will produce
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2012 Xamarin Inc.
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
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif
using AvailabilityAttribute = XamCore.ObjCRuntime.Extensions.AvailabilityAttribute;
using Platform = XamCore.ObjCRuntime.Extensions.Platform;

using XamCore.CoreFoundation;
using XamCore.Foundation;
using XamCore.CoreGraphics;
#if !WATCH
using XamCore.CoreMedia;
#endif

namespace XamCore.Foundation {
	public enum NSCalendarType {
		Gregorian, Buddhist, Chinese, Hebrew, Islamic, IslamicCivil, Japanese, [Obsolete] RepublicOfChina, Persian, Indian, ISO8601,
		Coptic, EthiopicAmeteAlem, EthiopicAmeteMihret,
		[Availability (Introduced = Platform.Mac_10_10 | Platform.iOS_8_0)]
		IslamicTabular,
		[Availability (Introduced = Platform.Mac_10_10 | Platform.iOS_8_0)]
		IslamicUmmAlQura,
#pragma warning disable 612 // RepublicOfChina is obsolete
		Taiwan = RepublicOfChina
#pragma warning restore 612
	}
	
	public partial class NSCalendar {
		static NSString GetCalendarIdentifier (NSCalendarType type)
		{
			switch (type){
			case NSCalendarType.Gregorian:
				return NSGregorianCalendar;
			case NSCalendarType.Buddhist:
				return NSBuddhistCalendar;
			case NSCalendarType.Chinese:
				return NSChineseCalendar;
			case NSCalendarType.Hebrew:
				return NSHebrewCalendar;
			case NSCalendarType.Islamic:
				return NSIslamicCalendar; 
			case NSCalendarType.IslamicCivil:
				return NSIslamicCivilCalendar;
			case NSCalendarType.Japanese:
				return NSJapaneseCalendar;
#pragma warning disable 612 // RepublicOfChina is obsolete
			case NSCalendarType.RepublicOfChina:
#pragma warning restore 612
				return NSRepublicOfChinaCalendar;
			case NSCalendarType.Persian:
				return NSPersianCalendar;
			case NSCalendarType.Indian:
				return NSIndianCalendar;
			case NSCalendarType.ISO8601:
				return NSISO8601Calendar;
			case NSCalendarType.Coptic:
				return CopticCalendar;
			case NSCalendarType.EthiopicAmeteAlem:
				return EthiopicAmeteAlemCalendar;
			case NSCalendarType.EthiopicAmeteMihret:
				return EthiopicAmeteMihretCalendar;
			case NSCalendarType.IslamicTabular:
				return IslamicTabularCalendar;
			case NSCalendarType.IslamicUmmAlQura:
				return IslamicUmmAlQuraCalendar;
			default:
				throw new ArgumentException ("Unknown NSCalendarType value");
			}
		}
		
		public NSCalendar (NSCalendarType calendarType) : this (GetCalendarIdentifier (calendarType)) {}
	}
}
