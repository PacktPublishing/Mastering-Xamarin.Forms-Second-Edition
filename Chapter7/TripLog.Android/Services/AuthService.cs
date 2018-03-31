using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using TripLog.Services;
using Xamarin.Auth;
using Xamarin.Forms;

namespace TripLog.Droid.Services
{
	public class AuthService : IAuthService
	{
		public async Task SignInAsync(string clientId,
									  Uri authUrl,
									  Uri callbackUrl,
									  Action<string> tokenCallback,
									  Action<string> errorCallback)
		{
			var auth = new OAuth2Authenticator(clientId, string.Empty, authUrl,	callbackUrl);
			auth.AllowCancel = true;

			var intent = auth.GetUI(Forms.Context as Activity);
			intent.AddFlags(ActivityFlags.NewTask);

			(Forms.Context as Activity).StartActivity(intent);

			auth.Completed += (s, e) =>
			{
				if (e.Account != null && e.IsAuthenticated)
				{
					tokenCallback?.Invoke(e.Account.Properties["access_token"]);
				}
				else
				{
					errorCallback?.Invoke("Not authenticated");
				}
			};

			auth.Error += (s, e) =>
			{
				errorCallback?.Invoke(e.Message);
			};
		}
	}
}