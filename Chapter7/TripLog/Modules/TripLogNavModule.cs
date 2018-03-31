using System;
using Ninject.Modules;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog.Modules
{
    public class TripLogNavModule : NinjectModule
    {
		readonly INavigation _xfNav;

		public TripLogNavModule(INavigation xamarinFormsNavigation)
		{
			_xfNav = xamarinFormsNavigation;
		}

		public override void Load()
		{
			var navService = new XamarinFormsNavService();
			navService.XamarinFormsNav = _xfNav;

			// Register view mappings
			navService.RegisterViewMapping(typeof(SignInViewModel), typeof(SignInPage));
			navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
			navService.RegisterViewMapping(typeof(DetailViewModel), typeof(DetailPage));
			navService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryPage));

			Bind<INavService>().ToMethod(x => navService).InSingletonScope();
		}
	}
}
