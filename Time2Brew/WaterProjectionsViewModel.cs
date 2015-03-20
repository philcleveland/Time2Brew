using System;
using System.Runtime.Serialization;
using ReactiveUI;
using Splat;

namespace Time2Brew.Core
{
	[DataContract]
	public class WaterProjectionsViewModel : ReactiveObject, IRoutableViewModel
	{
		const double ShrinkageFactor = 0.04;

		const double EvaporatationFactor = 0.075;

		const double GrainRetentionFactor = 0.2;

		const double MinutesPerHour = 60.0;

		const double QuartsPerGallon = 4.0;

		public WaterProjectionsViewModel (IScreen hostScreen, BrewData data)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen> ();

			TotalWaterVolume = CalculateTotalWaterVolume (data);
			StrikeWaterVolume = CalculateStrikeWaterVolume (data);
			StrikeWaterTemperature = CaluclateStrikeWaterTemperature (data);
			SpargeWaterVolume = TotalWaterVolume - StrikeWaterVolume;
			//TODO: Research sparge water temp. In a single infusion it seems to always be 
			//170.  Not sure why. Is is like a second infusion or just empirically good
			//for the grain wash
			SpargeWaterTemperature = 170.0; 

		}

		[IgnoreDataMember]
		public string UrlPathSegment {
			get {
				return "Water Projections";
			}
		}

		[IgnoreDataMember]
		public IScreen HostScreen { get; protected set; }

		[DataMember]
		public double TotalWaterVolume {
			get;
			private set;
		}

		[DataMember]
		public double StrikeWaterTemperature {
			get;
			private set;
		}

		[DataMember]
		public double StrikeWaterVolume {
			get;
			private set;
		}

		[DataMember]
		public double SpargeWaterVolume {
			get;
			private set;
		}

		[DataMember]
		public double SpargeWaterTemperature {
			get;
			private set;
		}

		static double CalculateTotalWaterVolume (BrewData data)
		{
			//Designing Great Beers by Ray Daniels pg. 65
			var runoffVolume = (data.FinishedBeerVolume + data.TrubLoss) / (1.0 - ShrinkageFactor) / CalculateEvaportation (data);
			var grainWaterRetention = GrainRetentionFactor * data.GrainBill;
			return runoffVolume + data.EquipmentLoss + grainWaterRetention;
		}

		static double CalculateEvaportation (BrewData data)
		{
			return 1 - ((EvaporatationFactor / MinutesPerHour) * data.BoilTime.TotalMinutes);
		}

		static double CalculateStrikeWaterVolume (BrewData data)
		{
			return (data.GrainBill * data.MashThickness) / QuartsPerGallon;
		}

		static double CaluclateStrikeWaterTemperature (BrewData data)
		{
			//http://www.howtobrew.com/section3/chapter16-3.html
			//Initial infusion equation
			//Tw = (.2 / r) * (T2 - T1) + T2;
//			r = The ratio of water to grain in quarts per pound.
//			Wa = The amount of boiling water added (in quarts).
//			Wm = The total amount of water in the mash (in quarts).
//			T1 = The initial temperature (¡F) of the mash.
//			T2 = The target temperature (¡F) of the mash.
//			Tw = The actual temperature (¡F) of the infusion water.
//			G = The amount of grain in the mash (in pounds).

			return (.2 / data.MashThickness) * (data.MashTemperature - data.GrainTemperature) + data.MashTemperature;
		}
	}
}

