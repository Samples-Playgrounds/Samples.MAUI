using CSnakes.Runtime;

namespace DemoMauiPython.Models;

public class Planet
{
    public string Name { get; set; }
    public string Subtitle { get; set; }
    public string HeroImage { get; set; }
    public string Description { get; set; }
    public Color AccentColorStart { get; set; }
    public Color AccentColorEnd { get; set; }
    public List<string> Images { get; set; }
    public ISpacePlotter SpacePlotter { get; set; }


    // Background
    public Brush Background
    {
        get
        {
            var gradientStops = new GradientStopCollection
            {
                new GradientStop(AccentColorStart, 0.0f),
                new GradientStop(AccentColorEnd, 1.0f)
            };

            var bgBrush = new LinearGradientBrush(
                gradientStops,
                new Point(0.0, 0.0),
                new Point(1.0, 1.0));

            return bgBrush;
        }
    }

    public ImageSource PlanetImageSource => ImageSource.FromStream(() =>
                                                     {
                                                         var buffer = SpacePlotter.PlotEarthAndPlanet(Name);
                                                         return new MemoryStream(buffer.AsReadOnlySpan<byte>().ToArray());
                                                     });
}
