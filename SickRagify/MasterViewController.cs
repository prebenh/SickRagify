using System;
using System.Drawing;
using System.Collections.Generic;
using System.Net.Http;
using SickRagify;
using SickRagify.Model;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SickRagify
{
	public partial class MasterViewController : UITableViewController
	{
		DataSource dataSource;

		public MasterViewController (IntPtr handle) : base (handle)
		{}

		void AddNewItem (object sender, EventArgs args)
		{
			dataSource.Objects.Insert (0, (Show)sender);

			using (var indexPath = NSIndexPath.FromRowSection (0, 0))
				TableView.InsertRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Automatic);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			//NavigationItem.LeftBarButtonItem = EditButtonItem;

			//var addButton = new UIBarButtonItem (UIBarButtonSystemItem.Add, AddNewItem);
			//NavigationItem.RightBarButtonItem = addButton;

			TableView.Source = dataSource = new DataSource (this);
		}

		class DataSource : UITableViewSource
		{
			static readonly NSString CellIdentifier = new NSString ("Cell");
			readonly List<Show> objects = new List<Show> ();
			readonly MasterViewController controller;

			public DataSource (MasterViewController controller)
			{
				this.controller = controller;

				var client = new Client ("http://xamarindp.cloudapp.net:8081/", "bb489ffc84457f84ad3ffe8b54e76d49");

				var shows = client.Show.GetShows ();

				foreach(var show in shows)
				{
					var banner = client.Show.GetBanner(show.TvdbId);
					show.Banner = banner;
					objects.Add(show);
				}

				//objects.AddRange(shows);
			}

			public IList<Show> Objects {
				get { return objects; }
			}

			// Customize the number of sections in the table view.
			public override int NumberOfSections (UITableView tableView)
			{
				return 1;
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return objects.Count;
			}

			// Customize the appearance of table view cells.
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = (UITableViewCell)tableView.DequeueReusableCell (CellIdentifier, indexPath);


				var show = objects [indexPath.Row];

				cell.ImageView.Image = new UIImage (NSData.FromArray (show.Banner));

				return cell;
			}





			public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the specified item to be editable.
				return false;
			}

			public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				if (editingStyle == UITableViewCellEditingStyle.Delete) {
					// Delete the row from the data source.
					objects.RemoveAt (indexPath.Row);
					controller.TableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
				} else if (editingStyle == UITableViewCellEditingStyle.Insert) {
					// Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
				}
			}

			/*
			// Override to support rearranging the table view.
			public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
			{
			}
			*/

			/*
			// Override to support conditional rearranging of the table view.
			public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the item to be re-orderable.
				return true;
			}
			*/
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showDetail") {
				var indexPath = TableView.IndexPathForSelectedRow;
				var show = (Show) dataSource.Objects [indexPath.Row];

				((ShowInfoViewController)segue.DestinationViewController).Show = show;
			}
		}
	}
}

