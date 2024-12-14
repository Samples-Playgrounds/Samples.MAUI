namespace HolisticWare.MAUI.OrbitEngine.SportsCognitiveLearning;

public partial class
                                        Target
                                        :
                                        Orbit.Engine.GameObject
{
    public override
        void
                                        Render
                                        (
                                            ICanvas canvas,
                                            RectF dimensions
                                        )
    {
        base.Render(canvas, dimensions);

        // Render the state of your object.
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
    }
}
