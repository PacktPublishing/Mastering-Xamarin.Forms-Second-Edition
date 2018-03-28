using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Services
{
	public class XamarinFormsNavService : INavService
	{
		readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();

		public event PropertyChangedEventHandler CanGoBackChanged;

		public INavigation XamarinFormsNav { get; set; }

		public bool CanGoBack
		{
			get
			{
				return XamarinFormsNav.NavigationStack != null
					&& XamarinFormsNav.NavigationStack.Count > 0;
			}
		}

		public async Task GoBack()
		{
			if (CanGoBack)
			{
				await XamarinFormsNav.PopAsync(true);
			}

			OnCanGoBackChanged();
		}

		public async Task NavigateTo<TVM>() where TVM : BaseViewModel
		{
			await NavigateToView(typeof(TVM));

			if (XamarinFormsNav.NavigationStack.Last().BindingContext is BaseViewModel)
			{
				await ((BaseViewModel)(XamarinFormsNav.NavigationStack.Last().BindingContext)).Init();
			}
		}
		public async Task NavigateTo<TVM, TParameter>(TParameter parameter)	where TVM : BaseViewModel
		{
			await NavigateToView(typeof(TVM));

			if (XamarinFormsNav.NavigationStack.Last().BindingContext is BaseViewModel<TParameter>)
			{
				await ((BaseViewModel<TParameter>)(XamarinFormsNav.NavigationStack.Last().BindingContext)).Init(parameter);
			}
		}

		public async Task RemoveLastView()
		{
			if (XamarinFormsNav.NavigationStack.Any())
			{
				var lastView = XamarinFormsNav.NavigationStack[XamarinFormsNav.NavigationStack.Count - 2];

				XamarinFormsNav.RemovePage(lastView);
			}
		}

		public async Task ClearBackStack()
		{
			if (XamarinFormsNav.NavigationStack.Count <= 1)
			{
				return;
			}

			for (var i = 0; i < XamarinFormsNav.NavigationStack.Count - 1; i++)
			{
				XamarinFormsNav.RemovePage(XamarinFormsNav.NavigationStack[i]);
			}
		}

		public async Task NavigateToUri(Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentException("Invalid URI");
			}

			Device.OpenUri(uri);
		}


		public void RegisterViewMapping(Type viewModel, Type view)
		{
			_map.Add(viewModel, view);
		}

		async Task NavigateToView(Type viewModelType)
		{
			Type viewType;

			if (!_map.TryGetValue(viewModelType, out viewType))
			{
				throw new ArgumentException("No view found in view mapping for " + viewModelType.FullName + ".");
}
			var constructor = viewType.GetTypeInfo()
									  .DeclaredConstructors
									  .FirstOrDefault(dc => dc.GetParameters().Count() <= 0);

			var view = constructor.Invoke(null) as Page;

			var vm = ((App)Application.Current).Kernel.GetService(viewModelType);

			view.BindingContext = vm;

			await XamarinFormsNav.PushAsync(view, true);
		}

		void OnCanGoBackChanged()
		{
			CanGoBackChanged?.Invoke(this, new PropertyChangedEventArgs("CanGoBack"));
		}
	}
}
