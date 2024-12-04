using TodoApp.Repository;

namespace TodoApp;

public partial class App : Application
{
    // Add a public static *Repository property
    public static TodoRepository TodoRepo { get; private set; }
    public static DailynoteRepositosy _notesRepo { get; private set; }
    public App(TodoRepository repo, DailynoteRepositosy dailynoteRepositosy)
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
        // Initialize the PersonRepository property with the PersonRespository singleton object

        TodoRepo = repo;
        _notesRepo = dailynoteRepositosy;
    }
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 400;
        const int newHeight = 650;

        window.Width = newWidth;
        window.Height = newHeight;

        return window;
    }
}
