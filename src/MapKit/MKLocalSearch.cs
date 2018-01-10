//
// Authors:
//   Rodrigo Kumpera
//
// Copyright 2013 Xamarin Inc.
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
#pragma warning disable 414

#if !WATCH // doesn't show up in watch headers
#if XAMCORE_2_0 || !MONOMAC

using System;
using System.Threading.Tasks;
using System.Threading;
using Foundation;

namespace MapKit {
	public partial class MKLocalSearch {

		public virtual Task<MKLocalSearchResponse> StartAsync (CancellationToken token)
		{
			var tcs = new TaskCompletionSource<MKLocalSearchResponse> ();

			if (token.IsCancellationRequested) {
				tcs.SetCanceled ();
			} else {
				var tcr = token.Register (() => { this.Cancel (); tcs.TrySetCanceled (); });
				Start((response, error) => {
					tcr.Dispose ();
					if (token.IsCancellationRequested) {
						tcs.TrySetCanceled ();
					} else {
						if (error != null)
							tcs.SetException (new NSErrorException(error));
						else
							tcs.SetResult (response);
					}
				});

			}
			return tcs.Task;
		}
	}
}
#endif
#endif // !WATCH
