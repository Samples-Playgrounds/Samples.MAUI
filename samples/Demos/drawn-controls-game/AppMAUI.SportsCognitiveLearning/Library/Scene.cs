namespace HolisticWare.MAUI.OrbitEngine.SportsCognitiveLearning;

public partial class
                                        Scene
                                        :
                                        Orbit.Engine.GameScene
{
    Target target = new Target();

    public
                                        Scene
                                        (
                                        )
    {
        Add(target);

        return;
    }

    public override
        void
                                        Render
                                        (
                                            ICanvas canvas,
                                            RectF dimensions
                                        )
    {
        base.Render(canvas, dimensions);

        // Render the state of your scene.

        return;
    }

    public override
        void
                                        Update
                                        (
                                            double ms_since_last_update
                                        )
    {
        base.Update(ms_since_last_update);

        // Update the state of your scene.

        return;
    }
}
