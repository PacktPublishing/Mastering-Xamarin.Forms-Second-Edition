using System;
using Ninject.Modules;
using TripLog.Services;
using TripLog.UWP.Services;

namespace TripLog.UWP.Modules
{
	public class TripLogPlatformModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ILocationService>().To<LocationService>().InSingletonScope();
		}
	}
}
