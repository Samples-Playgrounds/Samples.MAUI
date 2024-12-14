using SQLite;
using TodoApp.Data;

namespace TodoApp.Repository
{
    public class TodoRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        // TODO: Add variable for the SQLite connection
        private SQLiteConnection conn;

        private void Init()
        {
            // TODO: Add code to initialize the repository         
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<NotaModel>();
        }

        public TodoRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewTodo(string title, string description)
        {
            int result = 0;
            try
            {
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(title))
                    throw new Exception("Valid title required");

                // TODO: Insert the new person into the database
                result = conn.Insert(new NotaModel { Titulo = title , Descricao = description});

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, title);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", title, ex.Message);
            }

        }

        public List<NotaModel> GetAllTodos()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                Init();
                return conn.Table<NotaModel>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<NotaModel>();
        }

        public void UpdateTodo(NotaModel todo)
        {
            int result = 0;
            try
            {
                Init();

                // basic validation to ensure a name was entered
                result = conn.Update(todo);

                StatusMessage = string.Format("{0} record(s) Updateds)", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update {0}. Error: {1}", todo.Titulo, ex.Message);
            }

        }

        public void DeleteTodo(NotaModel todo)
        {
            int result = 0;
            try
            {
                Init();

                result = conn.Delete(todo);

                StatusMessage = string.Format("{0} record(s) deleted)", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", todo.Titulo, ex.Message);
            }

        }

    }
}
