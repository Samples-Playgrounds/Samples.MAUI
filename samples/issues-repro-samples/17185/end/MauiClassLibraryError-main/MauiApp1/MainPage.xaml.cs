using Com.Example.Libs;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var myClass = new MyClass();
            var msg = myClass.Message;
        }
    }
}