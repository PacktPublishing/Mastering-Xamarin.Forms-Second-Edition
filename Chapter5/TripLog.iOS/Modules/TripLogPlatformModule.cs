using System;
using Ninject.Modules;
using TripLog.iOS.Services;
using TripLog.Services;

namespace TripLog.iOS.Modules
{
	public class TripLogPlatformModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ILocationService>().To<LocationService>().InSingletonScope();
		}
	}
}