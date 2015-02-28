// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace SickRagify
{
	[Register ("ShowDetailViewController")]
	partial class ShowDetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView poster { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (poster != null) {
				poster.Dispose ();
				poster = null;
			}
		}
	}
}
