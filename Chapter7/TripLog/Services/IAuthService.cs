using System;
using System.Threading.Tasks;

namespace TripLog.Services
{
	public interface IAuthService
	{
		Task SignInAsync(string clientId,
						 Uri authUrl,
						 Uri callbackUrl,
						 Action<string> tokenCallback,
						 Action<string> errorCallback);
	}
}
