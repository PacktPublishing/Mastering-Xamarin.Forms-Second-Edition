using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
	public class SignInViewModel : BaseViewModel
	{
		readonly IAuthService _authService;
		readonly ITripLogDataService _tripLogService;

		ICommand _signInCommand;
		public ICommand SignInCommand
		{
			get
			{
				return _signInCommand ?? (_signInCommand = new Command(async () => await ExecuteSignInCommand()));
			}
		}

		public SignInViewModel(INavService navService, IAuthService authService, ITripLogDataService tripLogService)
			: base(navService)
		{
			_authService = authService;
			_tripLogService = tripLogService;
		}

		public override async Task Init()
		{
			await NavService.ClearBackStack();
		}

		async Task ExecuteSignInCommand()
		{
			// TODO: Update with your Facebook Client Id
			await _authService.SignInAsync("YOUR-FACEBOOK-CLIENTID", 
				new Uri("https://m.facebook.com/dialog/oauth"),
				new Uri("https://<your-service-name>.azurewebsites.net/.auth/login/facebook/callback"), 
				tokenCallback: async t =>
				{
					// Use Facebook token to get Azure auth token
					var response = await _tripLogService.GetAuthTokenAsync("facebook", t);

					// Save auth token in local settings
					Helpers.Settings.TripLogApiAuthToken = response.AuthenticationToken;

					// Navigate to Main
					await NavService.NavigateTo<MainViewModel>();
					await NavService.RemoveLastView();
				},
				errorCallback: e =>
				{
					// TODO: Handle invalid authentication here
				});
		}
	}
}
