using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.MobileCoreServices {

	[Partial]
	interface UTType {
		[Field ("kUTTypeItem", "+CoreServices")]
		NSString Item { get; }
		
		[Field ("kUTTypeContent", "+CoreServices")]
		NSString Content { get; }
		
		[Field ("kUTTypeCompositeContent", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString CompositeContent { get; }
		 
		[Field ("kUTTypeMessage", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Message { get; }
		
		[Field ("kUTTypeContact", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Contact { get; }
		
		[Field ("kUTTypeArchive", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Archive { get; }
		
		[Field ("kUTTypeDiskImage", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString DiskImage { get; }
		
		[Field ("kUTTypeData", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Data { get; }
		
		[Field ("kUTTypeDirectory", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Directory { get; }
		
		[Field ("kUTTypeResolvable", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Resolvable { get; }
		
		[Field ("kUTTypeSymLink", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString SymLink { get; }
		
		[Field ("kUTTypeExecutable", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)] // Symbol not found: _kUTTypeExecutable in 10.9
		NSString Executable { get; }
		
		[Field ("kUTTypeMountPoint", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString MountPoint { get; }
		
		[Field ("kUTTypeAliasFile", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString AliasFile { get; }
		
		[Field ("kUTTypeAliasRecord", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString AliasRecord { get; }
		
		[Field ("kUTTypeURLBookmarkData", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString URLBookmarkData { get; }
		
		[Field ("kUTTypeURL", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString URL { get; }
		
		[Field ("kUTTypeFileURL", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString FileURL { get; }
		
		[Field ("kUTTypeText", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Text { get; }
		
		[Field ("kUTTypePlainText", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString PlainText { get; }
		
		[Field ("kUTTypeUTF8PlainText", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString UTF8PlainText { get; }
		
		[Field ("kUTTypeUTF16ExternalPlainText", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString UTF16ExternalPlainText { get; }
		
		[Field ("kUTTypeUTF16PlainText", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString UTF16PlainText { get; }
		
		[Field ("kUTTypeDelimitedText", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString DelimitedText { get; }
		
		[Field ("kUTTypeCommaSeparatedText", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString CommaSeparatedText { get; }
		
		[Field ("kUTTypeTabSeparatedText", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString TabSeparatedText { get; }
		
		[Field ("kUTTypeUTF8TabSeparatedText", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString UTF8TabSeparatedText { get; }
		
		[Field ("kUTTypeRTF", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString RTF { get; }
		
		[Field ("kUTTypeHTML", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString HTML { get; }
		
		[Field ("kUTTypeXML", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString XML { get; }
		
		[Field ("kUTTypeSourceCode", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString SourceCode { get; }
		
		[Field ("kUTTypeAssemblyLanguageSource", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString AssemblyLanguageSource { get; }
		
		[Field ("kUTTypeCSource", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString CSource { get; }
		
		[Field ("kUTTypeObjectiveCSource", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString ObjectiveCSource { get; }
		
		[Field ("kUTTypeCPlusPlusSource", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString CPlusPlusSource { get; }
		
		[Field ("kUTTypeObjectiveCPlusPlusSource", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString ObjectiveCPlusPlusSource { get; }
		
		[Field ("kUTTypeCHeader", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString CHeader { get; }
		
		[Field ("kUTTypeCPlusPlusHeader", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString CPlusPlusHeader { get; }
		
		[Field ("kUTTypeJavaSource", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString JavaSource { get; }
		
		[Field ("kUTTypeScript", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString Script { get; }
		
		[Field ("kUTTypeAppleScript", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString AppleScript { get; }
		
		[Field ("kUTTypeOSAScript", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString OSAScript { get; }
		
		[Field ("kUTTypeOSAScriptBundle", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString OSAScriptBundle { get; }
		
		[Field ("kUTTypeJavaScript", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString JavaScript { get; }
		
		[Field ("kUTTypeShellScript", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString ShellScript { get; }
		
		[Field ("kUTTypePerlScript", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString PerlScript { get; }
		
		[Field ("kUTTypePythonScript", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString PythonScript { get; }
		
		[Field ("kUTTypeRubyScript", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString RubyScript { get; }
		
		[Field ("kUTTypePHPScript", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString PHPScript { get; }
		
		[Field ("kUTTypeJSON", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString JSON { get; }
		
		[Field ("kUTTypePropertyList", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString PropertyList { get; }
		
		[Field ("kUTTypeXMLPropertyList", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString XMLPropertyList { get; }
		
		[Field ("kUTTypeBinaryPropertyList", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString BinaryPropertyList { get; }
		
		[Field ("kUTTypePDF", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString PDF { get; }
		
		[Field ("kUTTypeRTFD", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString RTFD { get; }
		
		[Field ("kUTTypeFlatRTFD", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString FlatRTFD { get; }
		
		[Field ("kUTTypeTXNTextAndMultimediaData", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString TXNTextAndMultimediaData { get; }
		
		[Field ("kUTTypeWebArchive", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString WebArchive { get; }
		
		[Field ("kUTTypeImage", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Image { get; }
		
		[Field ("kUTTypeJPEG", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString JPEG { get; }
		
		[Field ("kUTTypeJPEG2000", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString JPEG2000 { get; }
		
		[Field ("kUTTypeTIFF", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString TIFF { get; }
		
		[Field ("kUTTypePICT", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString PICT { get; }
		
		[Field ("kUTTypeGIF", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString GIF { get; }
		
		[Field ("kUTTypePNG", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString PNG { get; }
		
		[Field ("kUTTypeQuickTimeImage", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString QuickTimeImage { get; }
		
		[Field ("kUTTypeAppleICNS", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString AppleICNS { get; }
		
		[Field ("kUTTypeBMP", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString BMP { get; }
		
		[Field ("kUTTypeICO", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString ICO { get; }
		
		[Field ("kUTTypeRawImage", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString RawImage { get; }
		
		[Field ("kUTTypeScalableVectorGraphics", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString ScalableVectorGraphics { get; }
		
		[Field ("kUTTypeAudiovisualContent", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString AudiovisualContent { get; }
		
		[Field ("kUTTypeMovie", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Movie { get; }
		
		[Field ("kUTTypeVideo", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Video { get; }
		
		[Field ("kUTTypeAudio", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Audio { get; }
		
		[Field ("kUTTypeQuickTimeMovie", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString QuickTimeMovie { get; }
		
		[Field ("kUTTypeMPEG", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString MPEG { get; }
		
		[Field ("kUTTypeMPEG2Video", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString MPEG2Video { get; }
		
		[Field ("kUTTypeMPEG2TransportStream", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString MPEG2TransportStream { get; }
		
		[Field ("kUTTypeMP3", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString MP3 { get; }
		
		[Field ("kUTTypeMPEG4", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString MPEG4 { get; }
		
		[Field ("kUTTypeMPEG4Audio", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString MPEG4Audio { get; }
		
		[Field ("kUTTypeAppleProtectedMPEG4Audio", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString AppleProtectedMPEG4Audio { get; }
		
		[Field ("kUTTypeAppleProtectedMPEG4Video", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString AppleProtectedMPEG4Video { get; }
		
		[Field ("kUTTypeAVIMovie", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString AVIMovie { get; }
		
		[Field ("kUTTypeAudioInterchangeFileFormat", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString AudioInterchangeFileFormat { get; }
		
		[Field ("kUTTypeWaveformAudio", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString WaveformAudio { get; }
		
		[Field ("kUTTypeMIDIAudio", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString MIDIAudio { get; }
		
		[Field ("kUTTypePlaylist", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString Playlist { get; }
		
		[Field ("kUTTypeM3UPlaylist", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString M3UPlaylist { get; }
		
		[Field ("kUTTypeFolder", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Folder { get; }
		
		[Field ("kUTTypeVolume", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Volume { get; }
		
		[Field ("kUTTypePackage", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Package { get; }
		
		[Field ("kUTTypeBundle", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Bundle { get; }
		
		[Field ("kUTTypePluginBundle", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString PluginBundle { get; }
		
		[Field ("kUTTypeSpotlightImporter", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString SpotlightImporter { get; }
		
		[Field ("kUTTypeQuickLookGenerator", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString QuickLookGenerator { get; }
		
		[Field ("kUTTypeXPCService", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString XPCService { get; }
		
		[Field ("kUTTypeFramework", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Framework { get; }
		
		[Field ("kUTTypeApplication", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString Application { get; }
		
		[Field ("kUTTypeApplicationBundle", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString ApplicationBundle { get; }
		
		[Field ("kUTTypeApplicationFile", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString ApplicationFile { get; }
		
		[Field ("kUTTypeUnixExecutable", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString UnixExecutable { get; }
		
		[Field ("kUTTypeWindowsExecutable", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString WindowsExecutable { get; }
		
		[Field ("kUTTypeJavaClass", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString JavaClass { get; }
		
		[Field ("kUTTypeJavaArchive", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString JavaArchive { get; }
		
		[Field ("kUTTypeSystemPreferencesPane", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString SystemPreferencesPane { get; }
		
		[Field ("kUTTypeGNUZipArchive", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString GNUZipArchive { get; }
		
		[Field ("kUTTypeBzip2Archive", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString Bzip2Archive { get; }
		
		[Field ("kUTTypeZipArchive", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString ZipArchive { get; }
		
		[Field ("kUTTypeSpreadsheet", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString Spreadsheet { get; }
		
		[Field ("kUTTypePresentation", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString Presentation { get; }
		
		[Field ("kUTTypeDatabase", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 8, 0)]
		NSString Database { get; }
		
		[Field ("kUTTypeVCard", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString VCard { get; }
		
		[Field ("kUTTypeToDoItem", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString ToDoItem { get; }
		
		[Field ("kUTTypeCalendarEvent", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString CalendarEvent { get; }
		
		[Field ("kUTTypeEmailMessage", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString EmailMessage { get; }
		
		[Field ("kUTTypeInternetLocation", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString InternetLocation { get; }
		
		[Field ("kUTTypeInkText", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 4), Introduced (PlatformName.iOS, 3, 0)]
		NSString InkText { get; }
		
		[Field ("kUTTypeFont", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString Font { get; }
		
		[Field ("kUTTypeBookmark", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString Bookmark { get; }
		
		[Field ("kUTType3DContent", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString ThreeDContent { get; }
		
		[Field ("kUTTypePKCS12", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString PKCS12 { get; }
		
		[Field ("kUTTypeX509Certificate", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString X509Certificate { get; }
		
		[Field ("kUTTypeElectronicPublication", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString ElectronicPublication { get; }
		
		[Field ("kUTTypeLog", "+CoreServices")]
		[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
		NSString Log { get; }

		[Field ("kUTExportedTypeDeclarationsKey", "+CoreServices")]
		NSString ExportedTypeDeclarationsKey { get; }

		[Field ("kUTImportedTypeDeclarationsKey", "+CoreServices")]
		NSString ImportedTypeDeclarationsKey { get; }

		[Field ("kUTTypeIdentifierKey", "+CoreServices")]
		NSString IdentifierKey { get; }
		
		[Field ("kUTTypeTagSpecificationKey", "+CoreServices")]
		NSString TagSpecificationKey { get; }
		
		[Field ("kUTTypeConformsToKey", "+CoreServices")]
		NSString ConformsToKey { get; }
		
		[Field ("kUTTypeDescriptionKey", "+CoreServices")]
		NSString DescriptionKey { get; }
		
		[Field ("kUTTypeIconFileKey", "+CoreServices")]
		NSString IconFileKey { get; }
		
		[Field ("kUTTypeReferenceURLKey", "+CoreServices")]
		NSString ReferenceURLKey { get; }
		
		[Field ("kUTTypeVersionKey", "+CoreServices")]
		NSString VersionKey { get; }

		[Field ("kUTTagClassFilenameExtension", "+CoreServices")]
		NSString TagClassFilenameExtension { get; }
		
		[Field ("kUTTagClassMIMEType", "+CoreServices")]
		NSString TagClassMIMEType { get; }
		
#if MONOMAC
		[Field ("kUTTagClassNSPboardType", "+CoreServices")]
		NSString TagClassNSPboardType { get; }
		
		[Field ("kUTTagClassOSType", "+CoreServices")]
		NSString TagClassOSType { get; }
#endif

		[Introduced (PlatformName.MacOSX, 10, 11), Introduced (PlatformName.iOS, 9, 0)]
		[Field ("kUTTypeSwiftSource", "+CoreServices")]
		NSString SwiftSource { get; }

// exclude from MonoMac classic
#if (XAMCORE_2_0 || !MONOMAC)
		[Unavailable (PlatformName.WatchOS)]
		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
		[Field ("kUTTypeAlembic", "ModelIO")]
		NSString Alembic { get; }

		[Unavailable (PlatformName.WatchOS)]
		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
		[Field ("kUTType3dObject", "ModelIO")]
		NSString k3dObject { get; }

		[Unavailable (PlatformName.WatchOS)]
		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
		[Field ("kUTTypePolygon", "ModelIO")]
		NSString Polygon { get; }

		[Unavailable (PlatformName.WatchOS)]
		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
		[Field ("kUTTypeStereolithography", "ModelIO")]
		NSString Stereolithography { get; }

		[Unavailable (PlatformName.WatchOS)]
		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("kUTTypeUniversalSceneDescription", "ModelIO")]
		NSString UniversalSceneDescription { get; }

		[Introduced (PlatformName.WatchOS, 2, 2)]
		[Introduced (PlatformName.iOS, 9, 1)][Introduced (PlatformName.TvOS, 9, 0)]
		[Unavailable (PlatformName.MacOSX)]
		[Field ("kUTTypeLivePhoto", "+CoreServices")]
		NSString LivePhoto { get; }
#endif
	}
}
