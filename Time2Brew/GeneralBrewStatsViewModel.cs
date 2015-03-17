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
		public GeneralBrewStatsViewModel () : this (null)
		{
		}

		public GeneralBrewStatsViewModel (IScreen hostScreen)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen> ();

			SetGrainBillWeightTo = ReactiveCommand.Create ();
			SetGrainBillWeightTo
				.Select (x => (double)x)
				.ToProperty (this, x => x.GrainBillWeight, out _GrainBillWeight);

			SetFinishedBeerVolumeTo = ReactiveCommand.Create ();
			SetFinishedBeerVolumeTo
				.Select (x => (double)x)
				.ToProperty (this, x => x.FinishedBeerVolume, out _FinishedBeerVolume);

			SetWortLossTo = ReactiveCommand.Create ();
			SetWortLossTo
				.Select (x => (double)x)
				.ToProperty (this, x => x.AnticipatedWortLossVolume, out _AnticipatedWortLossVolume);

			NavigateToMashStats
				.ObserveOn (RxApp.MainThreadScheduler)
				.Subscribe (x => HostScreen.Router.Navigate.Execute (new MashStatsViewModel ()));
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

