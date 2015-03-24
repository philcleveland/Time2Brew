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

			this.OneWayBind (ViewModel, vm => vm.TotalWaterVolume, v => v.lblTotalWaterVolume.Text);
			this.OneWayBind (ViewModel, vm => vm.StrikeWaterVolume, v => v.lblStrikeVolume.Text);
			this.OneWayBind (ViewModel, vm => vm.StrikeWaterTemperature, v => v.lblStrikeTemp.Text);
			this.OneWayBind (ViewModel, vm => vm.SpargeWaterVolume, v => v.lblSpargeVolume.Text);
			this.OneWayBind (ViewModel, vm => vm.SpargeWaterTemperature, v => v.lblSpargeTemp.Text);
			this.BindCommand (ViewModel, vm => vm.NavigateToMashTimer, v => v.btnNext);

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

