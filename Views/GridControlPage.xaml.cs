using System;
using System.Windows.Controls;
using SF_DataGrid.ViewModels;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Tools.Controls;
namespace SF_DataGrid.Views
{
    public partial class GridControlPage : Page
    {
		public string themeName = App.Current.Properties["Theme"]?.ToString()!= null? App.Current.Properties["Theme"]?.ToString(): "Windows11Light";
        public GridControlPage(GridControlViewModel viewModel)
        {
            InitializeComponent();			
            DataContext = viewModel;
			 //Specifying row and column count

			SfSkinManager.SetTheme(this, new Theme(themeName));
        }	
		private void GridControl_QueryAllowDragColumn(object sender, GridQueryDragColumnHeaderEventArgs e)
        {
            //To disable dragging of First column
            if (e.Column == 0 && e.Reason == GridQueryDragColumnHeaderReason.HitTest)
                e.AllowDrag = false;
            //To disable dropping in First column
            if (e.InsertBeforeColumn == 0 &&
                 (e.Reason == GridQueryDragColumnHeaderReason.MouseUp || e.Reason == GridQueryDragColumnHeaderReason.MouseMove))
                e.AllowDrag = false;
        }
    }
}
