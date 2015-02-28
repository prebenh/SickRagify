using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using SickRagify.Model;

namespace SickRagify
{
	partial class ShowInfoViewController : UITabBarController
	{


		public ShowInfoViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		private Show _show;
		public Show Show { 
			private get 
			{ 
				return _show; 
			} 
			set 
			{
				_show = value; 
				ConfigureView ();
			}  
		}


		private void ConfigureView()
		{
			if (Show != null) 
			{
				Title = Show.ToString();
			}
		}
	}
}
