using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Ninject;
using Ninject.Modules;
using TripLog.Modules;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog
{
	public partial class App : Application
	{
		public IKernel Kernel { get; set; }

		public bool IsSignedIn
		{
			get
			{
				return !string.IsNullOrWhiteSpace(Helpers.Settings.TripLogApiAuthToken);
			}
		}

		public App (params INinjectModule[] platformModules)
		{
			InitializeComponent();

			var mainPage = new NavigationPage(new MainPage());

			// Register core services
			Kernel = new StandardKernel(new TripLogCoreModule(), new TripLogNavModule(mainPage.Navigation));

			// Register platform specific services
			Kernel.Load(platformModules);
			
			// Get the MainViewModel from the IoC
			mainPage.BindingContext = Kernel.Get<MainViewModel>();

			MainPage = mainPage;
		}

		protected override void OnStart ()
		{
			AppCenter.Start("ios={Your iOS app secret here};"
				+ "android={Your Android app secret here};"
				+ "uwp={Your UWP app secret here}",
				typeof(Analytics), typeof(Crashes));
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
