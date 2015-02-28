using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using SickRagify.Model;
using SickRagify;

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



				var client = new Client ("http://xamarindp.cloudapp.net:8081/", "bb489ffc84457f84ad3ffe8b54e76d49");

				var poster = client.Show.GetPoster (Show.TvdbId);

				var seasons = client.Show.GetSeasons (Show.TvdbId);
			}
		}

	}
}
