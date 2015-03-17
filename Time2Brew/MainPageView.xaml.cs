using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ReactiveUI;
using System.Reactive.Linq;

namespace Time2Brew.Core
{
	public partial class MainPageView : ContentPage, IViewFor<MainPageViewModel>
	{
		public MainPageView ()
		{
			InitializeComponent ();

			this.BindCommand (ViewModel, vm => vm.NavigateStartBrewing, v => v.btnStartBrewing);
			//TODO
//			this.BindCommand (ViewModel, vm => vm.NavigateNewRecipe, v => v.btnNewRecipe);
//			this.BindCommand (ViewModel, vm => vm.NavigateImportRecipe, v => v.btnImportRecipe);
		}

		public MainPageViewModel ViewModel {
			get { return (MainPageViewModel)GetValue (ViewModelProperty); }
			set { SetValue (ViewModelProperty, value); }
		}

		public static readonly BindableProperty ViewModelProperty =
			BindableProperty.Create<MainPageView, MainPageViewModel> (x => x.ViewModel, default(MainPageViewModel), BindingMode.OneWay);

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (MainPageViewModel)value; }
		}
	}
}

