using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;
using Akavache;

namespace TripLog.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		readonly ITripLogDataService _tripLogService;
		readonly IBlobCache _cache;

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

		Command<TripLogEntry> _viewCommand;
		public Command<TripLogEntry> ViewCommand
		{
			get
			{
				return _viewCommand	?? (_viewCommand = new Command<TripLogEntry>(async (entry) => await ExecuteViewCommand(entry)));
			}
		}

		Command _newCommand;
		public Command NewCommand
		{
			get
			{
				return _newCommand ?? (_newCommand = new Command(async () => await ExecuteNewCommand()));
			}
		}

		Command _refreshCommand;
		public Command RefreshCommand
		{
			get
			{
				return _refreshCommand ?? (_refreshCommand = new Command(LoadEntries));
			}
		}

		public MainViewModel(INavService navService, ITripLogDataService tripLogService, IBlobCache cache, IAnalyticsService analyticsService) 
			: base(navService, analyticsService)
		{
			_tripLogService = tripLogService;
			_cache = cache;

			LogEntries = new ObservableCollection<TripLogEntry>();
		}

		public override async Task Init()
		{
			if (!((App)Application.Current).IsSignedIn)
			{
				await NavService.NavigateTo<SignInViewModel>();
			}
			else
			{
				LoadEntries();
			}
		}

		void LoadEntries()
		{
			if (IsBusy)
			{
				return;
			}

			IsBusy = true;

			LogEntries.Clear();

			try
			{
				// Load from local cache and then immediately load from API
				_cache.GetAndFetchLatest("entries", async () => await _tripLogService.GetEntriesAsync())
					  .Subscribe(entries => LogEntries = new ObservableCollection<TripLogEntry>(entries));
			}
			catch (Exception e)
			{
				AnalyticsService.TrackError(e, new Dictionary<string, string>
				{
					{ "Method", "MainViewModel.LoadEntries()" }
				});
			}
			finally
			{
				IsBusy = false;
			}
		}

		async Task ExecuteViewCommand(TripLogEntry entry)
		{
			await NavService.NavigateTo<DetailViewModel, TripLogEntry>(entry);
		}

		async Task ExecuteNewCommand()
		{
			await NavService.NavigateTo<NewEntryViewModel>();
		}
	}
}
