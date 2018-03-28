using System;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using Windows.Devices.Geolocation;

namespace TripLog.UWP.Services
{
	public class LocationService : ILocationService
	{
		public async Task<GeoCoords> GetGeoCoordinatesAsync()
		{
			var locator = new Geolocator();
			var geoPosition = await locator.GetGeopositionAsync();

			return new GeoCoords
			{
				Latitude = geoPosition.Coordinate.Point.Position.Latitude,
				Longitude = geoPosition.Coordinate.Point.Position.Longitude
			};
		}
	}
}
