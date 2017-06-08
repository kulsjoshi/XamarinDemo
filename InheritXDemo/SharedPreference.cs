using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace InheritXDemo
{
	public class SharedPreference
	{

		private const String MobileNumberKey = "_mobileNumber";
		private static readonly String MobileNumberDefault = String.Empty;
		private const String IsLoggedInKey = "_isLoggedIn";
		private static readonly String IsLoggedInDefault = "false";

		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		public static String UserMobileNumber
		{
			get { return AppSettings.GetValueOrDefault<string>(MobileNumberKey, MobileNumberDefault);}
			set {AppSettings.AddOrUpdateValue<string>(MobileNumberKey,value); }
		}

		public static String GetLoginStatus
		{
			get { return AppSettings.GetValueOrDefault<String>(IsLoggedInKey,IsLoggedInDefault); }
			set { AppSettings.AddOrUpdateValue<string>(IsLoggedInKey, value);}
		}
	}
}

 
