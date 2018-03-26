using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Models;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewEntryViewModel : BaseViewModel
    {
		string _title;
		public string Title
		{
			get { return _title; }
			set
			{
				_title = value;
				OnPropertyChanged();
				SaveCommand.ChangeCanExecute();
			}
		}

		double _latitude;
		public double Latitude
		{
			get { return _latitude; }
			set
			{
				_latitude = value;
				OnPropertyChanged();
			}
		}

		double _longitude;
		public double Longitude
		{
			get { return _longitude; }
			set
			{
				_longitude = value;
				OnPropertyChanged();
			}
		}

		DateTime _date;
		public DateTime Date
		{
			get { return _date; }
			set
			{
				_date = value;
				OnPropertyChanged();
			}
		}

		int _rating;
		public int Rating
		{
			get { return _rating; }
			set
			{
				_rating = value;
				OnPropertyChanged();
			}
		}

		string _notes;
		public string Notes
		{
			get { return _notes; }
			set
			{
				_notes = value;
				OnPropertyChanged();
			}
		}

		Command _saveCommand;
		public Command SaveCommand
		{
			get
			{
				return _saveCommand ?? (_saveCommand = new Command(ExecuteSaveCommand, CanSave));
			}
		}

		public NewEntryViewModel()
		{
			Date = DateTime.Today;
			Rating = 1;
		}

		void ExecuteSaveCommand()
		{
			var newItem = new TripLogEntry
			{
				Title = Title,
				Latitude = Latitude,
				Longitude = Longitude,
				Date = Date,
				Rating = Rating,
				Notes = Notes
			};

			// TODO: Persist Entry in a later chapter.
		}

		bool CanSave()
		{
			return !string.IsNullOrWhiteSpace(Title);
		}
	}
}
