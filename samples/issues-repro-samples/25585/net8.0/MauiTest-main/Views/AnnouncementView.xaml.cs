using CleanApp.Models;
using CleanApp.Pages;

namespace CleanApp
{
    public partial class AnnouncementView : ContentView
    {
        public const string HtmlPage = @"<!DOCTYPE html><html><head><meta name='viewport' content='width=device-width, initial-scale=1' /><style>{0}</style></head><body>{1}</body></html>";
        public const string MessageCss = "div.wysiwygtext p img {max-width: 100%;height: auto;}";

        private readonly bool _isDashboard = false;
        private readonly string _title;

        public AnnouncementView()
        {
            InitializeComponent();
            DisplayView();
        }

        public AnnouncementView(bool isDashboard, string title)
        {
            InitializeComponent();
            _isDashboard = isDashboard;
            _title = title;
            DisplayView();
        }

        public AnnouncementView(Announcement announcement)
        {
            InitializeComponent();
            DisplayMessage(announcement);
        }

        public AnnouncementView(List<Announcement> announcementList)
        {
            DisplayList(announcementList);
        }

        public void DisplayView()
        {
            DisplayList(GetAnnouncementList());
        }

        public void DisplayList(List<Announcement> announcementList)
        {
            if (!announcementList.Any())
            {
                NoAnnMsg.Text = "You do not have any announcements at this time";
                NoAnnLayout.IsVisible = true;
                OneAnnLayout.IsVisible = false;
                AnnListView.IsVisible = false;
                return;
            }
            if (announcementList.Count == 1)
            {
                DisplayMessage(announcementList.FirstOrDefault());
            }
            else
            {
                NoAnnLayout.IsVisible = false;
                OneAnnLayout.IsVisible = false;
                AnnListView.IsVisible = true;

                AnnListView.ItemsSource = announcementList;
            }
        }

        public async void DisplayMessage(Announcement announcement)
        {
            NoAnnLayout.IsVisible = false;
            OneAnnLayout.IsVisible = true;
            AnnListView.IsVisible = false;
            FromLabel.Text = announcement.Author;
            DateLabel.Text = announcement.StartDate.ToString("d") + " " + announcement.StartDate.ToLocalTime().ToString("t");
            HtmlDescription.Source = new HtmlWebViewSource { Html = string.Format(HtmlPage, MessageCss, announcement.Details) };
			TitleLabel.Text = announcement.Title;
        }


        private void OnItemClicked(object sender, SelectedItemChangedEventArgs e)
        {
            // Skip if deselected
            if (e.SelectedItem == null)
            {
                return;
            }

            var item = (Announcement)e.SelectedItem;

            // Load the selected Announcement
            // Deselect the list item
            var page = Utilities.GetPage<NavigationPage>(this);
            if (page == null) return;
            var nextPage = item.AnnId == 0 ? new AnnouncementPage() : new AnnouncementPage(item);
            Utilities.PushPageNoBackAsync((NavigationPage)page, nextPage);
            AnnListView.SelectedItem = null;
        }

        private List<Announcement> GetAnnouncementList()
        {
            var list = new List<Announcement>
            {
                new()
                {
                    AnnId = 1,
                    Title = "Closed on Monday",
                    Author = "Amanda Jones",
                    StartDate = new DateTime(2024, 2, 26),
                    Details = "All offices will be closed next Monday, sorry for any inconvenience",
                    ShowCount = true,
                    Count = 2
                },
                new()
                {
                    AnnId = 2,
                    Title = "Movies in the Park",
                    Author = "Sam Walters",
                    StartDate = new DateTime(2024, 2, 24),
                    Details = "This coming Friday we will be showing 'Back to the future' at the park.  Bring your chairs or blankets and something to drink, popcorn will be provided.",
                    ShowCount = false,
                    Count = 0
                },
                new()
                {
                    AnnId = 3,
                    Title = "Pickleball Tournament",
                    Author = "Robert Allen",
                    StartDate = new DateTime(2024, 2, 14),
                    Details = "The next pickleball tournament will start saturday morning at 9am.  Please arrive about 15 min early if you wish to register.",
                    ShowCount = true,
                    Count = 5
                }
            };
            return list;
        }

        private void OnBackTapped(object sender, TappedEventArgs e)
        {
            var page = Utilities.GetPage<NavigationPage>(this);
            if (page == null) return;
            ((NavigationPage)page).PopAsync();
        }
    }
}

