using System;
using Windows.UI.Xaml.Data;

namespace TripLog.UWP.Converters
{
	public class DateTimeToDateTimeOffsetConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is DateTime)
				return new DateTimeOffset((DateTime)value);

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			if (value is DateTimeOffset)
				return ((DateTimeOffset)value).DateTime;

			return value;
		}
	}
}