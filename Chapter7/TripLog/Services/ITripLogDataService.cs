using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public interface ITripLogDataService
    {
		Task<IList<TripLogEntry>> GetEntriesAsync();
		Task<TripLogEntry> GetEntryAsync(string id);
		Task<TripLogEntry> AddEntryAsync(TripLogEntry entry);
		Task<TripLogEntry> UpdateEntryAsync(TripLogEntry entry);
		Task RemoveEntryAsync(TripLogEntry entry);
	}
}
