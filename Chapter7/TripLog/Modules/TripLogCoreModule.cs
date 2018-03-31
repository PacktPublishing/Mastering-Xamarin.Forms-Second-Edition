using System;
using Ninject.Modules;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog.Modules
{
	public class TripLogCoreModule : NinjectModule
	{
		public override void Load()
		{
			// ViewModels
			Bind<MainViewModel>().ToSelf();
			Bind<DetailViewModel>().ToSelf();
			Bind<NewEntryViewModel>().ToSelf();

			// Core services
			var tripLogService = new TripLogApiDataService(new	Uri("https://<your-service-name>.azurewebsites.net"));

			Bind<ITripLogDataService>().ToMethod(x => tripLogService).InSingletonScope();

			Bind<Akavache.IBlobCache>().ToConstant(Akavache.BlobCache.LocalMachine);
		}
	}
}
