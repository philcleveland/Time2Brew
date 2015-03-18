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
		const double DefaultGrainBill = 10.0;
		const double DefaultFinishVolume = 5.5;
		const double DefaultWortLoss = 0.25;

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
				.ToProperty (this, x => x.GrainBillWeight, out _GrainBillWeight);

			SetFinishedBeerVolumeTo = ReactiveCommand.Create ();
			SetFinishedBeerVolumeTo
				.StartWith (DefaultFinishVolume)
				.Select (x => (double)x)
				.Where (x => x > 0.0)
				.ToProperty (this, x => x.FinishedBeerVolume, out _FinishedBeerVolume);

			SetWortLossTo = ReactiveCommand.Create ();
			SetWortLossTo
				.StartWith (DefaultWortLoss)
				.Select (x => (double)x)
				.Where (x => x > 0.0)
				.ToProperty (this, x => x.AnticipatedWortLossVolume, out _AnticipatedWortLossVolume);

			NavigateToMashStats = ReactiveCommand.Create ();
			NavigateToMashStats
				.ObserveOn (RxApp.MainThreadScheduler)
				.Subscribe (x => HostScreen.Router.Navigate.Execute (new MashStatsViewModel (HostScreen)));
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

	}
}

