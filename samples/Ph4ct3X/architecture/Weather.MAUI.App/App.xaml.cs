using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

using WeatherTwentyOne.Pages;

namespace Weather.MAUI.App
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			/*
			System.InvalidOperationException: 'Both MainPage was set and CreateWindow was overridden to provide a page.'
			 */
			//MainPage = new MainPage();
			//MainPage = new HomePage();
		}


		protected override Window CreateWindow(IActivationState activationState) =>
			new Window(new NavigationPage(new HomePage())) { Title = "Weather TwentyOne" };
	}
}
