using System;
using ReactiveUI;
using Splat;
using System.Reactive.Linq;
using System.Runtime.Serialization;

namespace Time2Brew.Core
{
	[DataContract]
	public class GeneralBrewStatsViewModel : ReactiveObject, IRoutableViewModel
	{
		//lbs
		const double DefaultGrainBill = 10.0;
		//gallons
		const double DefaultFinishVolume = 5.5;
		//gallons
		const double DefaultWortLoss = 0.25;
		//gallons
		const double DefaultEquipmentLoss = 1.0;
		BrewData _brewData = new BrewData ();

		public GeneralBrewStatsViewModel () : this (null)
		{
		}

		public GeneralBrewStatsViewModel (IScreen hostScreen)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen> ();

			SetGrainBillWeightTo = ReactiveCommand.Create ();
			SetGrainBillWeightTo
				.StartWith (DefaultGrainBill) 
				.Select (x => (double)x)
				.Where (x => x > 0.0)
				.Select (x => _brewData.GrainBill = x)
				.ToProperty (this, x => x.GrainBillWeight, out _GrainBillWeight);

			SetFinishedBeerVolumeTo = ReactiveCommand.Create ();
			SetFinishedBeerVolumeTo
				.StartWith (DefaultFinishVolume)
				.Select (x => (double)x)
				.Where (x => x > 0.0)
				.Select (x => _brewData.FinishedBeerVolume = x)
				.ToProperty (this, x => x.FinishedBeerVolume, out _FinishedBeerVolume);

			SetWortLossTo = ReactiveCommand.Create ();
			SetWortLossTo
				.StartWith (DefaultWortLoss)
				.Select (x => (double)x)
				.Where (x => x > 0.0)
				.Select (x => _brewData.TrubLoss = x)
				.ToProperty (this, x => x.AnticipatedWortLossVolume, out _AnticipatedWortLossVolume);

			SetEquipmentLossTo = ReactiveCommand.Create ();
			SetEquipmentLossTo
				.StartWith (DefaultEquipmentLoss)
				.Select (x => (double)x)
				.Where (x => x > 0.0)
				.Select (x => _brewData.EquipmentLoss = x)
				.ToProperty (this, x => x.AnticipatedEquipmentLossVolume, out _AnticipatedEquipmentLossVolume);

			NavigateToMashStats = ReactiveCommand.Create ();
			NavigateToMashStats
				.ObserveOn (RxApp.MainThreadScheduler)
				.Subscribe (x => HostScreen.Router.Navigate.Execute (new MashStatsViewModel (HostScreen, _brewData)));
		}

		[IgnoreDataMember]
		public string UrlPathSegment {
			get {
				return "General Brew Stats";
			}
		}

		[IgnoreDataMember]
		public IScreen HostScreen { get; protected set; }

		[IgnoreDataMember] public ReactiveCommand<object> SetGrainBillWeightTo { get; private set; }

		[IgnoreDataMember] public ReactiveCommand<object> SetFinishedBeerVolumeTo { get; private set; }

		[IgnoreDataMember] public ReactiveCommand<object> SetWortLossTo { get; private set; }

		[IgnoreDataMember] public ReactiveCommand<object> SetEquipmentLossTo { get; private set; }

		[IgnoreDataMember] public ReactiveCommand<object> NavigateToMashStats { get; private set; }

		private ObservableAsPropertyHelper<double> _GrainBillWeight;

		[DataMember]
		public double GrainBillWeight { 
			get { return _GrainBillWeight.Value; }
		}

		private ObservableAsPropertyHelper<double> _FinishedBeerVolume;

		[DataMember]
		public double FinishedBeerVolume { 
			get { return _FinishedBeerVolume.Value; }
		}

		private ObservableAsPropertyHelper<double> _AnticipatedWortLossVolume;

		[DataMember]
		public double AnticipatedWortLossVolume { 
			get { return _AnticipatedWortLossVolume.Value; }
		}

		private ObservableAsPropertyHelper<double> _AnticipatedEquipmentLossVolume;

		[DataMember]
		public double AnticipatedEquipmentLossVolume { 
			get { return _AnticipatedEquipmentLossVolume.Value; }
		}

	}
}

