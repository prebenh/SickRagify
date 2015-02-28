using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace SickRagify
{
	partial class ShowDetailViewController : UIViewController
	{
		public ShowDetailViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.poster.Image = new UIImage (NSData.FromArray (PosterImage));
		}


		public  byte[] PosterImage { get; set; }

	}
}
