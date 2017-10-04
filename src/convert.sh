#!/usr/bin/env bash

selfdir="$(dirname "$0")"
profile="../tools/pmcs/profiles/unified"

/Library/Frameworks/Mono.framework/Commands/mono --debug "/Users/donblas/Programming/macios/master/xamarin-macios/src/build/common/pmcs.exe" \
	-profile:"$profile" \
	-compiler:/Library/Frameworks/Mono.framework/Versions/Current/bin/mcs -lib:/Users/donblas/Programming/macios/master/xamarin-macios/_ios-build/Library/Frameworks/Xamarin.iOS.framework/Versions/git/lib/mono/2.1 -nostdlib -r:mscorlib.dll \
	"$@"
