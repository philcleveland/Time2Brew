using System;
using System.Collections.Generic;
using ReactiveUI;
using Xamarin.Forms;
using ReactiveUI.XamForms;
using System.Reactive.Linq;

namespace Time2Brew.Core
{
	public partial class UserPreferencesPage : ReactiveContentPage<UserPreferencesPageViewModel>
	{
		const double QuartsPerGallon = 4;
		const double LitersPerGallon = 3.78541;
		const double QuartsPerLiter = 1.05669;

		public UserPreferencesPage ()
		{
			InitializeComponent ();

			pickerVolumePreference.Items.Add ("Gallons");
			pickerVolumePreference.Items.Add ("Quarts");
			pickerVolumePreference.Items.Add ("Liters");

			this.Bind (ViewModel, vm => vm.TemperaturePreference, v => v.switchTempPreference.IsToggled);
			this.OneWayBind (ViewModel, vm => vm.TempPreferenceLabel, v => v.lblTempPreference.Text);

			this.Bind (ViewModel, vm => vm.EquipmentLossVolume, v => v.entryEquipmentLoss.Text);
			this.Bind (ViewModel, vm => vm.TrubLossVolume, v => v.entryTrubLoss.Text);

			this.WhenAnyValue (x => x.pickerVolumePreference.SelectedIndex)
				.Where (x => x > -1)
				.Select (x => pickerVolumePreference.Items [x])
				.Subscribe (x => {
				switch (x) {
				case "Gallons":
					ViewModel.VolumePreference = VolumeUnit.Gallons;
					break;
				case "Quarts":
					ViewModel.VolumePreference = VolumeUnit.Quarts;
					break;
				case "Liters":
					ViewModel.VolumePreference = VolumeUnit.Liters;
					break;
				default:
					ViewModel.VolumePreference = VolumeUnit.Gallons;
					break;
				}
			});

			this.WhenAnyValue (x => x.ViewModel.VolumePreference)
				.Subscribe (x => {
				switch (x) {
				case VolumeUnit.Gallons:
					pickerVolumePreference.SelectedIndex = pickerVolumePreference.Items.IndexOf ("Gallons");
					break;
				case VolumeUnit.Quarts:
					pickerVolumePreference.SelectedIndex = pickerVolumePreference.Items.IndexOf ("Quarts");
					break;
				case VolumeUnit.Liters:
					pickerVolumePreference.SelectedIndex = pickerVolumePreference.Items.IndexOf ("Liters");
					break;
				default:
					pickerVolumePreference.SelectedIndex = pickerVolumePreference.Items.IndexOf ("Gallons");
					break;
				}
			});


		}
	}
}

