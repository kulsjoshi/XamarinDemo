using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InheritXDemo
{
	public partial class NavigationDrawerDetailForm : MasterDetailPage
	{

		String strLoginStatus;

		public NavigationDrawerDetailForm()
		{
			InitializeComponent();

			strLoginStatus = SharedPreference.GetLoginStatus;

			if (strLoginStatus.ToLower().Equals("false"))
			{
				Navigation.PushModalAsync(new LoginForm());
			}
			else
			{
				changeNavigationPage(new HomeForm());
			}
		}





		void openHome(object sender, System.EventArgs e)
		{
			changeNavigationPage(new HomeForm());
		}

		void openChangePassword(object sender, System.EventArgs e)
		{
			changeNavigationPage(new ChangePasswordForm());
		}

		void openAboutUs(object sender, System.EventArgs e)
		{
			changeNavigationPage(new AboutUsForm());
		}

		void openLogout(object sender, System.EventArgs e)
		{
			changeNavigationPage(new LoginForm());
		}

		private void changeNavigationPage(ContentPage contentPage)
		{
			Detail = new NavigationPage(contentPage);
		}
	}
}
