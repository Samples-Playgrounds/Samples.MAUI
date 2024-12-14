namespace AppMAUI.SportsCognitiveLearning;


using Scene=HolisticWare.MAUI.OrbitEngine.SportsCognitiveLearning.Scene;

public partial class
                                        PageSportsCognitiveLearningScene
                                        :
                                        ContentPage
{
	public
                                        PageSportsCognitiveLearningScene
                                        (
                                        )
	{
		InitializeComponent();

        Content = new Orbit.Engine.GameSceneView();

        return;
	}

    public
                                        PageSportsCognitiveLearningScene
                                        (
                                            Orbit.Engine.IGameSceneManager game_scene_manager
                                        )
    {
	    InitializeComponent();

        game_scene_manager.LoadScene<Scene>(ViewSportsCognitiveLearningScene);

        game_scene_manager.Start();

        return;
    }
}

