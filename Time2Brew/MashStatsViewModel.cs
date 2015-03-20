using System;
using ReactiveUI;
using System.Runtime.Serialization;
using Splat;
using System.Reactive.Linq;

namespace Time2Brew.Core
{
	[DataContract]
	public class MashStatsViewModel : ReactiveObject, IRoutableViewModel
	{
		const double DefaultMashTemp = 152.0;
		const double DefaultMashThickness = 1.33;
		const double DefaultGrainTemp = 69.0;
		const double DefaultMashLength = 60.0;
		const double DefaultBoilLength = 60.0;

		public MashStatsViewModel (IScreen hostScreen, BrewData data)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen> ();

			SetMashTempTo = ReactiveCommand.Create ();
			SetMashTempTo
				.StartWith (DefaultMashTemp)
				.Select (x => (double)x)
				.Where (x => x > 0.0)
				.Select (x => data.MashTemperature = x)
				.ToProperty (this, vm => vm.MashTemperature, out _MashTemperature);

			SetGrainTempTo = ReactiveCommand.Create ();
			SetGrainTempTo
				.StartWith (DefaultGrainTemp)
				.Select (x => (double)x)
				.Where (x => x > 0.0)
				.Select (x => data.GrainTemperature = x)
				.ToProperty (this, vm => vm.GrainTemperature, out _GrainTemperature);

			SetMashThicknessTo = ReactiveCommand.Create ();
			SetMashThicknessTo
				.StartWith (DefaultMashThickness)
				.Select (x => (double)x)
				.Where (x => x > 0.0)
				.Select (x => data.MashThickness = x)
				.ToProperty (this, vm => vm.MashThickness, out _MashThickness);

			SetMashLengthTo = ReactiveCommand.Create ();
			SetMashLengthTo
				.StartWith (DefaultMashLength)
				.Select (x => data.MashTime = TimeSpan.FromMinutes ((double)x))
				.Select (x => x.TotalMinutes)
				.ToProperty (this, vm => vm.MashLength, out _MashLength);

			SetBoilLengthTo = ReactiveCommand.Create ();
			SetBoilLengthTo
				.StartWith (DefaultBoilLength)
				.Select (x => data.BoilTime = TimeSpan.FromMinutes ((double)x))
				.Select (x => x.TotalMinutes)
				.ToProperty (this, vm => vm.BoilLength, out _BoilLength);

			NavigateToWaterProjections = ReactiveCommand.Create ();
			NavigateToWaterProjections
				.Select (x => new WaterProjectionsViewModel (HostScreen, data))
				.Subscribe (HostScreen.Router.Navigate.Execute);
		}

		[IgnoreDataMember]
		public string UrlPathSegment {
			get {
				return "Mash Stats";
			}
		}

		[IgnoreDataMember]
		public IScreen HostScreen { get; protected set; }

		[IgnoreDataMember] public ReactiveCommand<object> SetMashTempTo { get; private set; }

		[IgnoreDataMember] public ReactiveCommand<object> SetGrainTempTo { get; private set; }

		[IgnoreDataMember] public ReactiveCommand<object> SetMashThicknessTo { get; private set; }

		[IgnoreDataMember] public ReactiveCommand<object> SetMashLengthTo { get; private set; }

		[IgnoreDataMember] public ReactiveCommand<object> SetBoilLengthTo { get; private set; }

		[IgnoreDataMember] public ReactiveCommand<object> NavigateToWaterProjections { get; private set; }

		private ObservableAsPropertyHelper<double> _MashTemperature;

		[DataMember]
		public double MashTemperature { 
			get { return _MashTemperature.Value; }
		}

		private ObservableAsPropertyHelper<double> _GrainTemperature;

		[DataMember]
		public double GrainTemperature { 
			get { return _GrainTemperature.Value; }
		}

		private ObservableAsPropertyHelper<double> _MashThickness;

		[DataMember]
		public double MashThickness { 
			get { return _MashThickness.Value; }
		}

		private ObservableAsPropertyHelper<double> _MashLength;

		[DataMember]
		public double MashLength { 
			get { return _MashLength.Value; }
		}

		private ObservableAsPropertyHelper<double> _BoilLength;

		[DataMember]
		public double BoilLength { 
			get { return _BoilLength.Value; }
		}
	}
}

