namespace CleanApp.Models
{
    public class Announcement
    {
        public int AnnId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime StartDate { get; set; }
        public bool ShowCount { get; set; }
        public int Count { get; set; }
    }
}