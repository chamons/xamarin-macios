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

using System;

using Foundation;

namespace AppKit {

	public partial class NSArrayController {

		// note: if needed override the protected Get|Set methods
		public NSIndexSet SelectionIndexes { 
			get { return GetSelectionIndexes (); }
			// ignore return value (bool)
			set { SetSelectionIndexes (value); }
		}

		// note: if needed override the protected Get|Set methods
		public nuint_compat_int SelectionIndex { 
			get { return (nuint_compat_int) GetSelectionIndex (); }
			// ignore return value (bool)
			set { SetSelectionIndex ((nuint) value); }
		}

		// note: if needed override the protected Get|Set methods
		public NSObject [] SelectedObjects { 
			get { return GetSelectedObjects (); }
			// ignore return value (bool)
			set { SetSelectedObjects (value); }
		}
	}
}