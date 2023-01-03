using OnLocationEVMT.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using OnLocationEVMT.iOS.CustomRenders;

[assembly: ExportRenderer(typeof(ViewCell), typeof(ExtendedViewCellRenderer))]

namespace OnLocationEVMT.iOS.CustomRenders
{
    class ExtendedViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            //First Method
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            //SecondMethod
            //var view = item as ExtendedViewCell;
            //      cell.SelectedBackgroundView = new UIView
            //      {
            //          BackgroundColor = [UIColor colorWithRed: 1.0 green: 1.0 blue: 1.0 alpha: 0.5], 
            //};
            return cell;
        }

    }
}
