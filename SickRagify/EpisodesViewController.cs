using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using SickRagify.Model;
using System.Linq;

namespace SickRagify
{
	partial class EpisodesViewController : UIViewController
	{
		public EpisodesViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SeasonTable.DataSource = new SeasonsDataSource(Seasons);
		}


		public SeasonList Seasons { get; set; }
	}

	public class SeasonsDataSource : UITableViewDataSource
	{
		public SeasonsDataSource(SeasonList seasonList)
		{
			_seasonList = seasonList;
		}

		private SeasonList _seasonList;

		public override string TitleForHeader (UITableView tableView, int section)
		{
			//var seasonNumber = _seasonList [section];

			return string.Format ("Season {0}", section+1);
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("cell");

			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, "cell");

			if (_seasonList [1].ContainsKey (indexPath.Row + 1)) {
				cell.TextLabel.Text = _seasonList [1] [indexPath.Row + 1].Name;
			}

				return cell;
		}

		public override int RowsInSection (UITableView tableView, int section)
		{
			return _seasonList[1].Count;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return _seasonList.Count;
		}

	}
}
