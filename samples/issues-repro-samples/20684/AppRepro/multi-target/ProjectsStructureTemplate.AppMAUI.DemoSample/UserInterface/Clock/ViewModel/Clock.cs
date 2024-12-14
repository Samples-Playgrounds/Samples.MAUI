using System.ComponentModel;

namespace AppMAUI.UserInterface.ViewModels.MAUI.Simple;

public partial class 
										Clock 
                                        :
                                        INotifyPropertyChanged
{
	public
										Clock
										(											
										)
	{
		return;
	}

    public event 
        PropertyChangedEventHandler
                                        PropertyChanged;

    public
        void
                                        OnPropertyChanged
                                        (
                                            [System.Runtime.CompilerServices.CallerMemberName] 
                                            string name = ""
                                        )
                                        =>
                                        PropertyChanged?.Invoke
                                                            (
                                                                this, 
                                                                new PropertyChangedEventArgs(name)
                                                            );
}