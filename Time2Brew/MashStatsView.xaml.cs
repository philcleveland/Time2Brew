using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ReactiveUI;
using System.Reactive.Linq;

namespace Time2Brew.Core
{
	public partial class MashStatsView : ContentPage, IViewFor<MashStatsViewModel>
	{
		public MashStatsView ()
		{
			InitializeComponent ();

			this.BindCommand (ViewModel, vm => vm.NavigateToWaterProjections, v => v.btnNext);

			//Mash Temp
			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.stpMashTemp.Value)
					.Skip (1)
					.SelectMany (x => ViewModel.SetMashTempTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.entryMashTemp.Text)
					.Skip (1)
					.Select (x => {
					double val = 0.0;
					return double.TryParse (x, out val) ? val : 0.0;
				})
					.SelectMany (x => ViewModel.SetMashTempTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.OneWayBind (ViewModel, vm => vm.MashTemperature, v => v.stpMashTemp.Value);
			this.OneWayBind (ViewModel, vm => vm.MashTemperature, v => v.entryMashTemp.Text);


			//Grain Temp
			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.stpGrainTemp.Value)
					.Skip (1)
					.SelectMany (x => ViewModel.SetGrainTempTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.entryGrainTemp.Text)
					.Skip (1)
					.Select (x => {
					double val = 0.0;
					return double.TryParse (x, out val) ? val : 0.0;
				})
					.SelectMany (x => ViewModel.SetGrainTempTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.OneWayBind (ViewModel, vm => vm.GrainTemperature, v => v.stpGrainTemp.Value);
			this.OneWayBind (ViewModel, vm => vm.GrainTemperature, v => v.entryGrainTemp.Text);


			//Mash Thickness
			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.stpMashThickness.Value)
					.Skip (1)
					.SelectMany (x => ViewModel.SetMashThicknessTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.entryMashThickness.Text)
					.Skip (1)
					.Select (x => {
					double val = 0.0;
					return double.TryParse (x, out val) ? val : 0.0;
				})
					.SelectMany (x => ViewModel.SetMashThicknessTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.OneWayBind (ViewModel, vm => vm.MashThickness, v => v.stpMashThickness.Value);
			this.OneWayBind (ViewModel, vm => vm.MashThickness, v => v.entryMashThickness.Text);
		}

		public MashStatsViewModel ViewModel {
			get { return (MashStatsViewModel)GetValue (ViewModelProperty); }
			set { SetValue (ViewModelProperty, value); }
		}

		public static readonly BindableProperty ViewModelProperty =
			BindableProperty.Create<MashStatsView, MashStatsViewModel> (x => x.ViewModel, default(MashStatsViewModel), BindingMode.OneWay);

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (MashStatsViewModel)value; }
		}
	}
}

