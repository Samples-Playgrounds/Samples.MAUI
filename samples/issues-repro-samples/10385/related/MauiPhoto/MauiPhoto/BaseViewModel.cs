using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiPhoto;

public partial class BaseViewModel:ObservableObject
{
    [ObservableProperty]
    //[AlsoNotifyChangeFor(nameof(IsNotBusy))]
    bool isBusy = true;

    //public bool IsNotBusy => !IsBusy;
}
