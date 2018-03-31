using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace TripLog.Helpers
{
	public static class Settings
	{
		private static ISettings AppSettings => CrossSettings.Current;
		
		private const string ApiAuthTokenKey = "apitoken_key";
		private static readonly string AuthTokenDefault = string.Empty;

		public static string TripLogApiAuthToken
		{
			get => AppSettings.GetValueOrDefault(ApiAuthTokenKey, AuthTokenDefault);
			set => AppSettings.AddOrUpdateValue(ApiAuthTokenKey, value);
		}
	}
}