using System;
using ReactiveUI;
using System.Reactive.Linq;

namespace Time2Brew.Core
{
	public class UserPreferencesPageViewModel :ReactiveObject, IRoutableViewModel
	{
		public UserPreferencesPageViewModel (IScreen hostScreen, UserSettings userSettings)
		{
			HostScreen = hostScreen;

			var tempPrefChanged = this.WhenAnyValue (x => x.TemperaturePreference).StartWith (userSettings.TemperaturePreference);

			tempPrefChanged
				.Subscribe (x => userSettings.TemperaturePreference = x);
			
			tempPrefChanged
				.Select (x => x == TemperatureUnit.Celsius ? "C" : "F")
				.ToProperty (this, vm => vm.TempPreferenceLabel, out _TempPreferenceLabel);



//			var volumePrefChanged = this.WhenAnyValue (x => x.VolumePreference);
			
//			volumePrefChanged
//				.StartWith (userSettings.VolumePreference)
//				.Do (x => System.Diagnostics.Debug.WriteLine ("setting vol pref {0}", x))
//				.Subscribe (x => userSettings.VolumePreference = x);
//
//			var equipLossChanged = this.WhenAnyValue (x => x.EquipmentLossVolume);
//
//			equipLossChanged
//				.StartWith (userSettings.EquipmentLossVolume)
//				.Subscribe (x => userSettings.EquipmentLossVolume = x);
//
//			var trubLossChanged = this.WhenAnyValue (x => x.TrubLossVolume);
//
//			trubLossChanged
//				.StartWith (userSettings.TrubLossVolume)
//				.Subscribe (x => userSettings.TrubLossVolume = x);
		}

		private TemperatureUnit _TemperaturePreference;

		public TemperatureUnit TemperaturePreference { 
			get { return _TemperaturePreference; }
			set { this.RaiseAndSetIfChanged (ref _TemperaturePreference, value); }	
		}

		private ObservableAsPropertyHelper<string> _TempPreferenceLabel;

		public string TempPreferenceLabel { 
			get { return _TempPreferenceLabel.Value; }
		}

		private VolumeUnit _VolumePreference;

		public VolumeUnit VolumePreference { 
			get { return _VolumePreference; }
			set { this.RaiseAndSetIfChanged (ref _VolumePreference, value); }	
		}

		private double _EquipmentLossVolume;

		public double EquipmentLossVolume { 
			get { return _EquipmentLossVolume; }
			set { this.RaiseAndSetIfChanged (ref _EquipmentLossVolume, value); }	
		}

		private double _TrubLossVolume;

		public double TrubLossVolume { 
			get { return _TrubLossVolume; }
			set { this.RaiseAndSetIfChanged (ref _TrubLossVolume, value); }	
		}

		public string UrlPathSegment {
			get {
				return "User Preferences Page";
			}
		}

		public IScreen HostScreen { get; protected set; }
	}
}

