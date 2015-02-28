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

			if(section == 0)
				return "Specials";

			return string.Format ("Season {0}", section);
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("cell");

			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, "cell");

			if (_seasonList [indexPath.Section].ContainsKey (indexPath.Row + 1)) {
				cell.TextLabel.Text = _seasonList [indexPath.Section] [indexPath.Row + 1].Name;
			}

			return cell;
		}

		public override int RowsInSection (UITableView tableView, int section)
		{
			if(_seasonList.ContainsKey(section))
				return _seasonList[section].Count;
			return 0;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return _seasonList.Count;
		}

	}
}
