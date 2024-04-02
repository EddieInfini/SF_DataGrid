using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using SF_DataGrid.Contracts.Services;
using SF_DataGrid.Helpers;
using SF_DataGrid.Properties;

using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.Windows.Shared;

namespace SF_DataGrid.ViewModels
{
    public class ShellViewModel : Observable
    {
        private readonly INavigationService _navigationService;
        private object _selectedMenuItem;
        private RelayCommand _goBackCommand;
        private ICommand _menuItemInvokedCommand;
        private ICommand _loadedCommand;
        private ICommand _unloadedCommand;

        public object SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (value as NavigationPaneItem == null)
                {
                    Set(ref _selectedMenuItem, ((FrameworkElement)value).DataContext, "SelectedMenuItem");
                }
                else
                {
                    Set(ref _selectedMenuItem, value, "SelectedMenuItem");
                }
                //NavigateTo((_selectedMenuItem as NavigationPaneItem).TargetType);
				if (_selectedMenuItem is NavigationPaneItem navigationPaneItem && navigationPaneItem.TargetType != null)
                {
                    NavigateTo(navigationPaneItem.TargetType);
                }
            }
        }

        public void UpdateFillColor(SolidColorBrush FillColor)
        {
            foreach (var item in MenuItems)
            {
                (item as NavigationPaneItem).Path.Fill = FillColor;
            }
            SetttingsIconColor = FillColor;
        }

        private SolidColorBrush setttingsIconColor;

        public SolidColorBrush SetttingsIconColor
        {
            get { return setttingsIconColor; }
            set
            {
                setttingsIconColor = value;
                OnPropertyChanged(nameof(SetttingsIconColor));
            }
        }

        // TODO WTS: Change the icons and titles for all HamburgerMenuItems here.
        public ObservableCollection<NavigationPaneItem> MenuItems { get; set; } = new ObservableCollection<NavigationPaneItem>()
        {
        	new NavigationPaneItem() { 
                        Label = Resources.ShellMainPage,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse("M28.414 4H7V44H39V14.586ZM29 7.414 35.586 14H29ZM9 42V6H27V16H37V42Z"),
                            Fill = new SolidColorBrush(Colors.Black),
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(MainViewModel) 
            },
        	new NavigationPaneItem() { 
                        Label = Resources.ShellGridControlPage,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse("M0 6C0 2.68629 2.68629 0 6 0H42C45.3137 0 48 2.68629 48 6V14V25V27C48 27.5523 47.5523 28 47 28C46.4477 28 46 27.5523 46 27V26H35H25V36V46H27C27.5523 46 28 46.4477 28 47C28 47.5523 27.5523 48 27 48H24H13H6C2.68629 48 0 45.3137 0 42V36V25V14V6ZM2 26V35H12V26H2ZM12 24H2V15H12V24ZM14 26V35H23V26H14ZM23 24H14V15H23V24ZM25 24H34V15H25V24ZM24 13H35H46V6C46 3.79086 44.2091 2 42 2H6C3.79086 2 2 3.79086 2 6V13H13H24ZM46 15H36V24H46V15ZM23 37H14V46H23V37ZM12 46V37H2V42C2 44.2091 3.79086 46 6 46H12ZM34.7151 28.6816C35.5946 26.701 38.4054 26.701 39.2849 28.6816L39.9068 30.0821C40.0149 30.3256 40.2948 30.4415 40.5434 30.3458L41.9734 29.7953C43.9958 29.0166 45.9834 31.0042 45.2047 33.0266L44.6542 34.4566C44.5585 34.7052 44.6744 34.9851 44.9179 35.0932L46.3184 35.7151C48.299 36.5946 48.299 39.4054 46.3184 40.2849L44.9179 40.9068C44.6744 41.0149 44.5585 41.2948 44.6542 41.5434L45.2047 42.9734C45.9834 44.9958 43.9958 46.9834 41.9734 46.2047L40.5434 45.6542C40.2948 45.5585 40.0149 45.6744 39.9068 45.9179L39.2849 47.3184C38.4054 49.299 35.5946 49.299 34.7151 47.3184L34.0932 45.9179C33.9851 45.6744 33.7052 45.5585 33.4566 45.6542L32.0266 46.2047C30.0042 46.9834 28.0166 44.9958 28.7953 42.9734L29.3458 41.5434C29.4415 41.2948 29.3256 41.0149 29.0821 40.9068L27.6816 40.2849C25.701 39.4054 25.701 36.5946 27.6816 35.7151L29.0821 35.0932C29.3256 34.9851 29.4415 34.7052 29.3458 34.4566L28.7953 33.0266C28.0166 31.0042 30.0042 29.0166 32.0266 29.7953L33.4566 30.3458C33.7052 30.4415 33.9851 30.3256 34.0932 30.0821L34.7151 28.6816ZM37.457 29.4933C37.2811 29.0971 36.7189 29.0971 36.543 29.4933L35.9211 30.8938C35.3807 32.111 33.9809 32.6908 32.738 32.2123L31.308 31.6617C30.9035 31.506 30.506 31.9035 30.6617 32.308L31.2123 33.738C31.6908 34.9809 31.111 36.3807 29.8938 36.9211L28.4933 37.543C28.0971 37.7189 28.0971 38.2811 28.4933 38.457L29.8938 39.0789C31.111 39.6193 31.6908 41.0191 31.2123 42.262L30.6617 43.692C30.506 44.0965 30.9035 44.494 31.308 44.3383L32.738 43.7877C33.9809 43.3092 35.3807 43.889 35.9211 45.1062L36.543 46.5067C36.7189 46.9029 37.2811 46.9029 37.457 46.5067L38.0789 45.1062C38.6193 43.889 40.0191 43.3092 41.262 43.7877L42.692 44.3383C43.0965 44.494 43.494 44.0965 43.3383 43.692L42.7877 42.262C42.3092 41.0191 42.889 39.6193 44.1062 39.0789L45.5067 38.457C45.9029 38.2811 45.9029 37.7189 45.5067 37.543L44.1062 36.9211C42.889 36.3807 42.3092 34.9809 42.7877 33.738L43.3383 32.308C43.494 31.9035 43.0965 31.506 42.692 31.6617L41.262 32.2123C40.0191 32.6908 38.6193 32.111 38.0789 30.8938L37.457 29.4933ZM35 38C35 36.8954 35.8954 36 37 36C38.1046 36 39 36.8954 39 38C39 39.1046 38.1046 40 37 40C35.8954 40 35 39.1046 35 38ZM37 34C34.7909 34 33 35.7909 33 38C33 40.2091 34.7909 42 37 42C39.2091 42 41 40.2091 41 38C41 35.7909 39.2091 34 37 34Z"),
                            Fill = new SolidColorBrush(Colors.Black),
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(GridControlViewModel) 
            },
        };

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ICommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnUnloaded));

        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SetttingsIconColor = new SolidColorBrush(Colors.Black);
        }

        private void OnLoaded()
        {
            _navigationService.Navigated += OnNavigated;
        }

        private void OnUnloaded()
        {
            _navigationService.Navigated -= OnNavigated;
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private void NavigateTo(Type targetViewModel)
        {
            if (targetViewModel != null)
            {
                _navigationService.NavigateTo(targetViewModel.FullName);
            }
        }

        private void OnNavigated(object sender, string viewModelName)
        {
            var item = MenuItems
                        .OfType<NavigationPaneItem>()
                        .FirstOrDefault(i => viewModelName == i.TargetType?.FullName);
            if (item != null)
            {
                SelectedMenuItem = item;
            }

            GoBackCommand.OnCanExecuteChanged();
        }
    }

    public class NavigationPaneItem
    {
        public string Label { get; set; }
        public Path Path { get; set; }
        public Type TargetType { get; set; }

    }
}
