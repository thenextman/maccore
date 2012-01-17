// Copyright 2009, Novell, Inc.
// Copyright 2010, Novell, Inc.
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
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;
using System;

namespace MonoMac.AVFoundation {

	public partial class AVAudioRecorder {
		[Obsolete ("Use the factory AVAudioRecorder.ToUrl as this method had an invalid signature up to MonoMac 1.4.4")]
		public AVAudioRecorder (NSUrl url, NSDictionary settings, NSError outError)
		{
			throw new Exception ("Use AVAudioRecorder.ToUrl to create instances of AVAudioRecorder");
		}

		public static AVAudioRecorder ToUrl (NSUrl url, NSDictionary settings, out NSError error)
		{
			unsafe {
				IntPtr errhandle;
				IntPtr ptrtohandle = (IntPtr) (&errhandle);

				var ap = new AVAudioRecorder (url, settings, ptrtohandle);
				if (ap.Handle == IntPtr.Zero){
					error = (NSError) Runtime.GetNSObject (errhandle);
					return null;
				} else
					error = null;
				return ap;
			}
		}

	}
}
