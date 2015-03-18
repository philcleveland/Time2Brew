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

		public MashStatsViewModel ()
		{
		}

		public MashStatsViewModel (IScreen hostScreen)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen> ();

			SetMashTempTo = ReactiveCommand.Create ();
			SetMashTempTo
				.StartWith (DefaultMashTemp)
				.Select (x => (double)x)
				.ToProperty (this, vm => vm.MashTemperature, out _MashTemperature);

			SetGrainTempTo = ReactiveCommand.Create ();
			SetGrainTempTo
				.StartWith (DefaultGrainTemp)
				.Select (x => (double)x)
				.ToProperty (this, vm => vm.GrainTemperature, out _GrainTemperature);

			SetMashThicknessTo = ReactiveCommand.Create ();
			SetMashThicknessTo
				.StartWith (DefaultMashThickness)
				.Select (x => (double)x)
				.ToProperty (this, vm => vm.MashThickness, out _MashThickness);

			SetMashLengthTo = ReactiveCommand.Create ();
			SetMashLengthTo
				.Select (x => (TimeSpan)x)
				.ToProperty (this, vm => vm.MashLength, out _MashLength);

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

		private ObservableAsPropertyHelper<TimeSpan> _MashLength;

		[DataMember]
		public TimeSpan MashLength { 
			get { return _MashLength.Value; }
		}
	}
}

