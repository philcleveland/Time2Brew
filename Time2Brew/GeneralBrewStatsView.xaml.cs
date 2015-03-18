using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI;
using Xamarin.Forms;

namespace Time2Brew.Core
{
	public partial class GeneralBrewStatsView : ContentPage, IViewFor<GeneralBrewStatsViewModel>
	{
		public GeneralBrewStatsView ()
		{
			InitializeComponent ();

			this.BindCommand (ViewModel, vm => vm.NavigateToMashStats, v => v.btnNext);

			//Grain bill
			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.stpGrainBill.Value)
						.SelectMany (x => ViewModel.SetGrainBillWeightTo.ExecuteAsync (x))
						.Subscribe ());
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.entryGrainBill.Text)
					.Select (x => {
					double val = 0.0;
					return double.TryParse (x, out val) ? val : 0.0;
				})
					.SelectMany (x => ViewModel.SetGrainBillWeightTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.ViewModel.GrainBillWeight).Subscribe (x => this.stpGrainBill.Value = x));
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.ViewModel.GrainBillWeight).Subscribe (x => this.entryGrainBill.Text = x.ToString ()));
			});

			//Finished Beer
			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.stpFinishedBeer.Value)
					.SelectMany (x => ViewModel.SetFinishedBeerVolumeTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.entryFinishedBeer.Text)
					.Select (x => {
					double val = 0.0;
					return double.TryParse (x, out val) ? val : 0.0;
				})
					.SelectMany (x => ViewModel.SetFinishedBeerVolumeTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.ViewModel.FinishedBeerVolume).Subscribe (x => this.stpFinishedBeer.Value = x));
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.ViewModel.FinishedBeerVolume).Subscribe (x => this.entryFinishedBeer.Text = x.ToString ()));
			});

			//Anticipated Wort Loss
			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.stpWortLoss.Value)
					.SelectMany (x => ViewModel.SetWortLossTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.entryWortLoss.Text)
					.Select (x => {
					double val = 0.0;
					return double.TryParse (x, out val) ? val : 0.0;
				})
					.SelectMany (x => ViewModel.SetWortLossTo.ExecuteAsync (x))
					.Subscribe ());
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.ViewModel.AnticipatedWortLossVolume).Subscribe (x => this.stpWortLoss.Value = x));
			});

			this.WhenActivated (d => {
				d (this.WhenAnyValue (x => x.ViewModel.AnticipatedWortLossVolume).Subscribe (x => this.entryWortLoss.Text = x.ToString ()));
			});


		}

		public GeneralBrewStatsViewModel ViewModel {
			get { return (GeneralBrewStatsViewModel)GetValue (ViewModelProperty); }
			set { SetValue (ViewModelProperty, value); }
		}

		public static readonly BindableProperty ViewModelProperty =
			BindableProperty.Create<GeneralBrewStatsView, GeneralBrewStatsViewModel> (x => x.ViewModel, default(GeneralBrewStatsViewModel), BindingMode.OneWay);

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (GeneralBrewStatsViewModel)value; }
		}
	}
}

