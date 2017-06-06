using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InheritXDemo
{
	public partial class LoginForm : ContentPage
	{

		private String strMobileNumber = "", strPassword = "";

		public LoginForm()
		{
			InitializeComponent();
			displayDatabaseData();



		}
		async void displayDatabaseData()
		{

			foreach (var item in await App.Database.GetPersonListing())
			{

				Debug.WriteLine("strId >> " + item.id);
				Debug.WriteLine("strId >> " + item.personMobileNumber);
				Debug.WriteLine("strId >> " + item.personName);
				Debug.WriteLine("strId >> " + item.personPassword);

			}

		}

		async void SignUp_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SignUpForm());
		}

		void Login_Clicked(object sender, System.EventArgs e)
		{

			strMobileNumber = entryMobileNumber.Text;
			strPassword = entryPassword.Text;

			if (isDataValidate())
			{
				//We have one method in App class which clear all the activity stack
				//

				performAction(App.Database.isUserAuthenticated(strMobileNumber,strPassword));

				//await Navigation.PushAsync(new HomeForm());
			}
		}

		async void performAction(Boolean result)
		{
			if (result)
			{
				var answer = await DisplayAlert(Constant.APP_NAME, Constant.LOGIN_SUCCESS, null, "OK");
				if (answer == true)
				{
					App.Instance.ClearNavigationAndGoToPage(new HomeForm());
				}
			}
			else
			{
				var answer = await DisplayAlert(Constant.APP_NAME, Constant.LOGIN_FAILURE, null, "OK");
			}
		}

		private Boolean isDataValidate()
		{
			if (strMobileNumber.Length == 0)
			{
				DisplayAlert(Constant.APP_NAME, Constant.ENTER_MOBILE, Constant.OK);
				return false;
			}
			else if (strPassword.Length == 0)
			{
				DisplayAlert(Constant.APP_NAME, Constant.ENTER_PASSWORD, Constant.OK);
				return false;
			}
			else if (strPassword.Length < 6)
			{
				DisplayAlert(Constant.APP_NAME, Constant.ENTER_VALID_PASSWORD, Constant.OK);
				return false;
			}

			return true;
		}
	}
}
