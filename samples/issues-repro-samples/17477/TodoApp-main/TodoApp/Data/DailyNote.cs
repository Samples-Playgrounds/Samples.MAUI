using SQLite;

namespace TodoApp.Data
{
    [Table("DailyNote")]
    public class DailyNote
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}
