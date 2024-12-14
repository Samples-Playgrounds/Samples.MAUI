using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestAlignment.ViewModels;

public partial class DocViewModel : INotifyPropertyChanged
{
	public static DocViewModel Instance { get; } = new DocViewModel();

	private DocViewModel()
	{ }

	public ObservableCollection<DateTime> DateList { get; set; } = new ObservableCollection<DateTime>();

	public Command UpdateCommand => new(() => DateList.Add(new DateTime(1921, 1, 1)));

	/// <inheritdoc/>
	public event PropertyChangedEventHandler PropertyChanged;

	/// <inheritdoc/>
	public void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}