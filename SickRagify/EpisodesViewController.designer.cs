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
	[Register ("EpisodesViewController")]
	partial class EpisodesViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView SeasonTable { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (SeasonTable != null) {
				SeasonTable.Dispose ();
				SeasonTable = null;
			}
		}
	}
}
