using System;
using TripLog.Controls;
using TripLog.UWP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Application = Windows.UI.Xaml.Application;
using DataTemplate = Windows.UI.Xaml.DataTemplate;

[assembly: ExportRenderer(typeof(DatePickerEntryCell), typeof(DatePickerEntryCellRenderer))]
namespace TripLog.UWP.Renderers
{
	public class DatePickerEntryCellRenderer : EntryCellRenderer
	{
		public override DataTemplate GetTemplate(Cell cell)
		{
			return Application.Current.Resources["DatePickerEntryCellDataTemplate"] as DataTemplate;
		}
	}
}