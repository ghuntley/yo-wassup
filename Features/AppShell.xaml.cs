using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactiveSearch.Features.AppShell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class AppShell : MasterDetailPage
    {
        public AppShell()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as AppShellMenuItem;
            if (item == null)
                return;

            var page = (Page) Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            Detail = new NavigationPage(page);
            MasterPage.ListView.SelectedItem = null;
            IsPresented = false;
        }
    }
}