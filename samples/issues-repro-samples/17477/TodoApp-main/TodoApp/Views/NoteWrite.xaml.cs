using CommunityToolkit.Maui.Views;
using TodoApp.Data;

namespace TodoApp.Views;

public partial class NoteWrite 
{
    private DailyNote _note;
    CancellationTokenSource ct = new();
    public NoteWrite(DailyNote note)
    {
        InitializeComponent();
        
        _note = note;
        entry.Text = _note.Text;
        //80% of screen Height,
        //entry.HeightRequest = Convert.ToInt32(Math.Round(App.Current.MainPage.Height * .99));
        //Size = new Size(Convert.ToInt32(Math.Round(App.Current.MainPage.Width * .99)),( Convert.ToInt32(Math.Round(App.Current.MainPage.Height * .99)) - 30));

    }

    private async void CloseButton_Clicked(object sender, EventArgs e)
    {
        await App.Current.MainPage.Navigation.PopAsync();
    }
    //private async void OnFocused(object sender, EventArgs e)
    //{
    //    if (KeyboardExtensions.IsSoftKeyboardShowing(entry))
    //    {
    //        await KeyboardExtensions.HideKeyboardAsync(entry, default);
    //    }
    //    else
    //    {
    //        await KeyboardExtensions.ShowKeyboardAsync(entry, default);

    //    }

    //}
    //private void CloseButton_Clicked(object sender, EventArgs e)
    //{
    //    Close(entry.Text?.Trim());
    //}
    //protected override Task OnDismissedByTappingOutsideOfPopup()
    //{
    //    Close(entry.Text?.Trim());
    //    return Task.CompletedTask;
    //}

    //private async void OnFocused(object sender, FocusEventArgs e)
    //{
    //    if (KeyboardExtensions.IsSoftKeyboardShowing(entry))
    //    {
    //        await KeyboardExtensions.HideKeyboardAsync(entry, default);
    //    }
    //    else
    //    {
    //        await KeyboardExtensions.ShowKeyboardAsync(entry, default);

    //    }


    //protected override bool OnBackButtonPressed()
    //{
    //    if(_note.Id == 0 && !string.IsNullOrEmpty(entry.Text.Trim()))
    //    {
    //        _ = App._notesRepo.AddNewEntryAsync(entry.Text, _note.Time);
    //    }
    //    else
    //    {
    //        if(_note.Text != entry.Text)
    //        {
    //            _note.Text = entry.Text;
    //            _ = App._notesRepo.UpdateNoteAsync(_note);
    //        }
    //    }

    //    return base.OnBackButtonPressed();
    //}

}