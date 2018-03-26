using System;
using System.Collections.Generic;
using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new MainViewModel();
		}

		void New_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new NewEntryPage());
		}

		async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var trip = (TripLogEntry)e.Item;
			await Navigation.PushAsync(new DetailPage(trip));

			// Clear selection
			trips.SelectedItem = null;
		}
	}
}
