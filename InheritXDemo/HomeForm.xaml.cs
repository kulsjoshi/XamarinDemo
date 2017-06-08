using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InheritXDemo
{
	public partial class HomeForm : ContentPage
	{
		public HomeForm()
		{
			InitializeComponent();

			String isLoggedIn = SharedPreference.GetLoginStatus;

			showDisplayAlert(isLoggedIn);

			if (isLoggedIn.Equals("true"))
			{
				startLoginScreen();
			}


			//var toolbar = new ToolbarItem
			//{
			//	Text = "Side"

			//};

			//toolbar.Clicked += async (sender, e) =>
			//		{
			//			await DisplayAlert("Inx Demo", "Under constraction..", "Ok");
			//		};
			//ToolbarItems.Add(toolbar);
		}

		async private void startLoginScreen()
		{
			await Navigation.PushModalAsync(new LoginForm());
		}

		async void showDisplayAlert(String strMessage)
		{
			await DisplayAlert("", strMessage, "OK");
		}

	}


}
