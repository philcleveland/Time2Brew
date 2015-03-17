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

			this.WhenAnyValue (x => x.ViewModel.HostScreen.Router)
				.Select (x => x.NavigateCommandFor<GeneralBrewStatsViewModel> ())
				.BindTo (this, x => x.btnStartBrewing.Command);

//			this.WhenAnyValue (x => x.ViewModel.HostScreen.Router)
//				.Select (x => x.NavigateCommandFor<Page1ViewModel> ())
//				.BindTo (this, x => x.btnNewRecipe.Command);
//
//			this.WhenAnyValue (x => x.ViewModel.HostScreen.Router)
//				.Select (x => x.NavigateCommandFor<Page1ViewModel> ())
//				.BindTo (this, x => x.btnImportRecipe.Command);


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

