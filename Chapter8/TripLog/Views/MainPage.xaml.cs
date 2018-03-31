using System;
using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
	public partial class MainPage : ContentPage
	{
		MainViewModel _vm
		{
			get { return BindingContext as MainViewModel; }
		}

		public MainPage()
		{
			InitializeComponent();
		}

		void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var trip = (TripLogEntry)e.Item;
			_vm.ViewCommand.Execute(trip);

			// Clear selection
			trips.SelectedItem = null;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			
			// Initialize MainViewModel
			if (_vm != null)
			{
				await _vm.Init();
			}
		}
	}
}
