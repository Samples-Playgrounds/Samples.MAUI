namespace AppMAUI.SportsCognitiveLearning;

public partial class
                                        AppShell
                                        :
                                        Shell
{
	public
                                        AppShell
                                        (
                                        )
	{
		InitializeComponent();
        RegisterRoutes();

        return;
	}

    private
        void
                                        RegisterRoutes
                                        (
                                        )
    {
        Routing.RegisterRoute
                        (
                            "PageSportsCognitiveLearningScene",
                            typeof(PageSportsCognitiveLearningScene)
                        );

        return;
    }
}
