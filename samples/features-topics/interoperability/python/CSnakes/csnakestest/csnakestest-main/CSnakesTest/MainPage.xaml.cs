﻿using CSnakes.Runtime;

namespace CSnakesTest {
	public partial class MainPage : ContentPage {
		int count = 0;
		private IHelloWorld helloWorld;

		public MainPage(IHelloWorld helloWorld) {
			InitializeComponent();
			this.helloWorld = helloWorld;
		}

		private void OnCounterClicked(object sender, EventArgs e) {
			count++;

			if (count == 1)
				CounterBtn.Text = $"Clicked {count} time";
			else
				CounterBtn.Text = $"Clicked {count} times";

			SemanticScreenReader.Announce(CounterBtn.Text);

			PythonOutput.Text = helloWorld.HelloWorld(PythonInput.Text);
		}
	}

}
