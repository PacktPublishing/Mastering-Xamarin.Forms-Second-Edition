using System;
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

		public DetailViewModel(INavService navService) : base(navService)
		{
		}

		public override async Task Init()
		{
			throw new EntryNotProvidedException();
		}

		public override async Task Init(TripLogEntry logEntry)
		{
			Entry = logEntry;
		}
	}
}
