using System;
using System.Collections.ObjectModel;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
		ObservableCollection<TripLogEntry> _logEntries;
		public ObservableCollection<TripLogEntry> LogEntries
		{
			get { return _logEntries; }
			set
			{
				_logEntries = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel()
		{
			LogEntries = new ObservableCollection<TripLogEntry>();

			LogEntries.Add(new TripLogEntry
			{
				Title = "Washington Monument",
				Notes = "Amazing!",
				Rating = 3,
				Date = new DateTime(2017, 2, 5),
				Latitude = 38.8895,
				Longitude = -77.0352
			});

			LogEntries.Add(new TripLogEntry
			{
				Title = "Statue of Liberty",
				Notes = "Inspiring!",
				Rating = 4,
				Date = new DateTime(2017, 4, 13),
				Latitude = 40.6892,
				Longitude = -74.0444
			});

			LogEntries.Add(new TripLogEntry
			{
				Title = "Golden Gate Bridge",
				Notes = "Foggy, but beautiful.",
				Rating = 5,
				Date = new DateTime(2017, 4, 26),
				Latitude = 37.8268,
				Longitude = -122.4798
			});
		}
	}
}
