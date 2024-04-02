using System.Windows.Controls;

using SF_DataGrid.ViewModels;

namespace SF_DataGrid.Views
{
    public partial class MainPage : Page
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
