using CleanApp.Models;

namespace CleanApp.Pages
{
    public partial class AnnouncementPage : BasePage
    {

        public AnnouncementPage()
        {
            InitializeComponent();
           Content = new AnnouncementView();
        }

        public AnnouncementPage(Announcement announcement)
        {
            InitializeComponent();
            Content = announcement.AnnId == 0 ? new AnnouncementView() : new AnnouncementView(announcement);
        }

        public AnnouncementPage(List<Announcement> announcementList )
        {
            InitializeComponent();
            Content = new AnnouncementView(announcementList);
        }

    }
}
