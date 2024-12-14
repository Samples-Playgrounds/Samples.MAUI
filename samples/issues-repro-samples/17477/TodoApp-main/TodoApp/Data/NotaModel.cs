using SQLite;

namespace TodoApp.Data
{
    [Table("todo")]
    public class NotaModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        public string Titulo { get; set; }
        [MaxLength(250)]
        public string Descricao { get; set; }
        public bool Feito { get; set; }
    }
}
