using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ReactiveUI;

namespace Time2Brew.Core
{
	public partial class WaterProjectionsView : ContentPage, IViewFor<WaterProjectionsViewModel>
	{
		public WaterProjectionsView ()
		{
			InitializeComponent ();
		}

		public WaterProjectionsViewModel ViewModel {
			get { return (WaterProjectionsViewModel)GetValue (ViewModelProperty); }
			set { SetValue (ViewModelProperty, value); }
		}

		public static readonly BindableProperty ViewModelProperty =
			BindableProperty.Create<WaterProjectionsView, WaterProjectionsViewModel> (x => x.ViewModel, default(WaterProjectionsViewModel), BindingMode.OneWay);

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (WaterProjectionsViewModel)value; }
		}
	}
}

