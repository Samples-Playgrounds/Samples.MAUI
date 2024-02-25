using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestAlignment.ViewModels;

public partial class DocViewModel : INotifyPropertyChanged
{
	public static DocViewModel Instance { get; } = new DocViewModel();

	private DocViewModel()
	{ }

	public IEnumerable<string> DocList => new string[] { "A.o", "B.o", "C.o" }.Select(Path.GetFileNameWithoutExtension);

	public Command UpdateCommand => new(() => OnPropertyChanged(nameof(DocList)));

	/// <inheritdoc/>
	public event PropertyChangedEventHandler PropertyChanged;

	/// <inheritdoc/>
	public void OnPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}