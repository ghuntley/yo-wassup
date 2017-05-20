using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactiveSearch.Features.AppShell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class AppShellMaster : ContentPage
    {
        public AppShellMaster()
        {
            InitializeComponent();
            BindingContext = new AppShellMasterViewModel();
        }

        public ListView ListView => ListViewMenuItems;


        private class AppShellMasterViewModel : INotifyPropertyChanged
        {
            public AppShellMasterViewModel()
            {
                AppShellMenuItems = new ObservableCollection<AppShellMenuItem>(new[]
                {
                    new AppShellMenuItem {Id = 0, Title = "Page 1"},
                    new AppShellMenuItem {Id = 1, Title = "Page 2"},
                    new AppShellMenuItem {Id = 2, Title = "Page 3"},
                    new AppShellMenuItem {Id = 3, Title = "Page 4"},
                    new AppShellMenuItem {Id = 4, Title = "Page 5"}
                });
            }

            public ObservableCollection<AppShellMenuItem> MenuItems { get; }
            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}