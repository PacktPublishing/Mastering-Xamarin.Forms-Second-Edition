using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TripLog.Services;

namespace TripLog.ViewModels
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected INavService NavService { get; private set; }

		bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				_isBusy = value;
				OnPropertyChanged();
				OnIsBusyChanged();
			}
		}


		protected BaseViewModel(INavService navService)
		{
			NavService = navService;
		}

		public abstract Task Init();

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual void OnIsBusyChanged()
		{
		}
	}

	public abstract class BaseViewModel<TParameter> : BaseViewModel
	{
		protected BaseViewModel(INavService navService) : base(navService)
		{
		}

		public override async Task Init()
		{
			await Init(default(TParameter));
		}

		public abstract Task Init(TParameter parameter);
	}
}
