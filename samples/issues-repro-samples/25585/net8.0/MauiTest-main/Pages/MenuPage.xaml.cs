using CleanApp.Models;
using MenuItem = CleanApp.Models.MenuItem;

namespace CleanApp.Pages;

public partial class MenuPage : ContentPage
{
    public MenuItemsViewModel MenuItemsViewModel;
    public MenuPage()
	{
		InitializeComponent();
        MenuItemsViewModel = new MenuItemsViewModel();
        MenuListView.ItemsSource = MenuItemsViewModel.MenuItems;
    }

    private void MenuListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Page nextPage;
        switch (((MenuItem)e.SelectedItem).PageName)
        {
            case "Announcements":
                nextPage = new AnnouncementPage();
                break;
            case "TitleIssue":
                nextPage = new TitleIssuePage();
                break;
            case "GridTap":
                nextPage = new GridTapPage();
                break;
            case "DisplayPrompt":
                nextPage = new DisplayPromptPage();
                break;
            default:
                nextPage = new MainPage();
                break;
        }

        var flyoutPage = (FlyoutPage)Parent;
        flyoutPage.Detail = new NavigationPage(nextPage);
        flyoutPage.IsPresented = false;
    }
}