using System;
using Xamarin.Forms;

namespace TripLog.Controls
{
	public class DatePickerEntryCell : EntryCell
	{
		public new event EventHandler Completed;

		public static readonly BindableProperty DateProperty = BindableProperty.Create(nameof(Date),
			typeof(DateTime),
			typeof(DatePickerEntryCell),
			DateTime.Now,
			BindingMode.TwoWay);

		public DateTime Date
		{
			get { return (DateTime)GetValue(DateProperty); }
			set { SetValue(DateProperty, value); }
		}

		public void SendCompleted()
		{
			Completed?.Invoke(this, EventArgs.Empty);
		}
	}
}
