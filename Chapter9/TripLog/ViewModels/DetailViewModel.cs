using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripLog.Exceptions;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class DetailViewModel : BaseViewModel<TripLogEntry>
    {
		TripLogEntry _entry;
		public TripLogEntry Entry
		{
			get { return _entry; }
			set
			{
				_entry = value;
				OnPropertyChanged();
			}
		}

		public DetailViewModel(INavService navService, IAnalyticsService analyticsService) 
			: base(navService, analyticsService)
		{
		}

		public override async Task Init()
		{
			throw new EntryNotProvidedException();
		}

		public override async Task Init(TripLogEntry logEntry)
		{
			AnalyticsService.TrackEvent("Entry Detail Page", new Dictionary<string, string>
			{
				{ "Title", logEntry.Title }
			});

			Entry = logEntry;
		}
	}
}
