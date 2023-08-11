using Microsoft.Maui.Controls.Shapes;
using System.Xml.Linq;

namespace PathGeometryTest;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
    }

    private async Task LoadPath(string fileName)
    {
        using Stream fileStream = await FileSystem.OpenAppPackageFileAsync(fileName);

        var geometryData = ReadGeometryFromSvg(fileStream);

        var pathFigureCollection = new PathFigureCollection();
        PathFigureCollectionConverter.ParseStringToPathFigureCollection(pathFigureCollection, geometryData);

        path1.Data = new PathGeometry(pathFigureCollection);
    }

    private static string ReadGeometryFromSvg(Stream fileStream)
    {
        var symbolDocument = XDocument.Load(fileStream);

        if (symbolDocument.Root is not XElement svgElement)
        {
            throw new InvalidDataException("No SVG element at the root");
        }

        if (!svgElement.Name.LocalName.Equals("svg", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidDataException("First element is not SVG");
        }

        var pathElements = svgElement.Descendants().Where(e => e.Name.LocalName.Equals("Path", StringComparison.OrdinalIgnoreCase)).ToArray();

        if (pathElements.Length == 0)
        {
            throw new InvalidDataException("SVG does not contain a Path element");
        }

        if (pathElements.Length > 1)
        {
            throw new InvalidDataException("SVG has more than one Path element");
        }

        var pathElement = pathElements[0];

        if (pathElement.Attribute("d") is not XAttribute pathData)
        {
            throw new InvalidDataException("SVG Path element does not contain a data attribute");
        }

        return pathData.Value;
    }

    private async void BrokenButton_Clicked(object sender, EventArgs e)
    {
        await LoadPath("broken.svg");
    }

    private async void WorkingButton_Clicked(object sender, EventArgs e)
    {
        await LoadPath("working.svg");
    }
}