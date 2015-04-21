using System;
using Lager;
using Akavache;

namespace Time2Brew.Core
{

	public enum TemperatureUnit
	{
		Celsius = 0,
		Fahrenheit
	}

	public enum VolumeUnit
	{
		Gallons = 0,
		Quarts,
		Liters
	}

	public class UserSettings : SettingsStorage
	{
		public UserSettings ()
			: base ("51e560f6-6af9-4681-9d91-056de03625b2", BlobCache.UserAccount)
		{
		}

		public TemperatureUnit TemperaturePreference {
			get { 
				var val = this.GetOrCreate (TemperatureUnit.Fahrenheit); 
				System.Diagnostics.Debug.WriteLine ("Got TemperaturePreference from UserSettings {0}", val);
				return val;
			}
			set { 
				System.Diagnostics.Debug.WriteLine ("setting TemperaturePreference in UserSettings to {0}", value);
				this.SetOrCreate (value); 
			}
		}

		//		public VolumeUnit VolumePreference {
		//			get {
		//				var val = this.GetOrCreate (VolumeUnit.Gallons);
		//				System.Diagnostics.Debug.WriteLine ("Got VolumePreference from UserSettings {0}", val);
		//				return val;
		//			}
		//			set {
		//				System.Diagnostics.Debug.WriteLine ("setting VolumePreference in UserSettings to {0}", value);
		//				this.SetOrCreate (value);
		//			}
		//		}
		//
		//		public double EquipmentLossVolume {
		//			get {
		//				var val = this.GetOrCreate (1.0);
		//				System.Diagnostics.Debug.WriteLine ("Got EquipmentLossVolume from UserSettings {0}", val);
		//				return val;
		//			}
		//			set {
		//				System.Diagnostics.Debug.WriteLine ("setting EquipmentLossVolume in UserSettings to {0}", value);
		//				this.SetOrCreate (value);
		//			}
		//		}
		//
		//		public double TrubLossVolume {
		//			get {
		//				var val = this.GetOrCreate (0.25);
		//				System.Diagnostics.Debug.WriteLine ("Got TrubLossVolume from UserSettings {0}", val);
		//				return val;
		//			}
		//			set {
		//				System.Diagnostics.Debug.WriteLine ("setting TrubLossVolume in UserSettings to {0}", value);
		//				this.SetOrCreate (value);
		//			}
		//		}
	}
}

