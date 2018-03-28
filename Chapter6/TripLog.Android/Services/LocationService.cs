using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.Droid.Services
{
	public class LocationService : Java.Lang.Object, ILocationService, ILocationListener
	{
		TaskCompletionSource<Location> _tcs;

		public async Task<GeoCoords> GetGeoCoordinatesAsync()
		{
			var manager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);

			_tcs = new TaskCompletionSource<Location>();

			manager.RequestSingleUpdate("gps", this, null);

			var location = await _tcs.Task;

			return new GeoCoords
			{
				Latitude = location.Latitude,
				Longitude = location.Longitude
			};
		}

		public void OnLocationChanged(Location location)
		{
			_tcs.TrySetResult(location);
		}

		public void OnProviderDisabled(string provider)
		{
		}

		public void OnProviderEnabled(string provider)
		{
		}

		public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
		{
		}
	}
}