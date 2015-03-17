using System;
using ReactiveUI;

namespace Time2Brew.Core
{
	public class MashStatsViewModel : ReactiveObject
	{
		public MashStatsViewModel ()
		{
		}

		private double _MashTemperature;

		public double MashTemperature { 
			get { return _MashTemperature; }
			set { this.RaiseAndSetIfChanged (ref _MashTemperature, value); }	
		}

		private double _GrainTemperature;

		public double GrainTemperature { 
			get { return _GrainTemperature; }
			set { this.RaiseAndSetIfChanged (ref _GrainTemperature, value); }	
		}

		private double _MashThickness;

		public double MashThickness { 
			get { return _MashThickness; }
			set { this.RaiseAndSetIfChanged (ref _MashThickness, value); }	
		}

		private TimeSpan _MashLength;

		public TimeSpan MashLength { 
			get { return _MashLength; }
			set { this.RaiseAndSetIfChanged (ref _MashLength, value); }	
		}
	}
}

