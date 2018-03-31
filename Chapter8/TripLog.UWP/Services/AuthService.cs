using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Security.Authentication.Web;
using TripLog.Services;

namespace TripLog.UWP.Services
{
	public class AuthService : IAuthService
	{
		public async Task SignInAsync(string clientId,
									  Uri authUrl, 
									  Uri callbackUrl, 
									  Action<string> tokenCallback, 
									  Action<string> errorCallback)
		{
			var fullAuthUrl = string.Format(authUrl.OriginalString + "?client_id={0}&redirect_uri={1}&response_type=token", clientId, callbackUrl.OriginalString);

			var result = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, new Uri(fullAuthUrl), callbackUrl);

			switch (result.ResponseStatus)
			{
				case WebAuthenticationStatus.Success:
					tokenCallback?.Invoke(GetAccessToken(result.ResponseData));
					break;
				case WebAuthenticationStatus.ErrorHttp:
					errorCallback?.Invoke(result.ResponseErrorDetail.ToString());
					break;
				case WebAuthenticationStatus.UserCancel:
					tokenCallback?.Invoke("");
					break;
			}
		}

		string GetAccessToken(string responseData)
		{
			try
			{
				responseData = responseData.Replace("#access_token", "access_token");

				var responseUri = new Uri(responseData);
				var urlDecoder = new WwwFormUrlDecoder(responseUri.Query);

				return urlDecoder.GetFirstValueByName("access_token");
			}
			catch
			{
				return string.Empty;
			}
		}
	}
}
