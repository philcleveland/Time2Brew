using System;

namespace Time2Brew.Core
{
	public class BrewData
	{
		public BrewData ()
		{
		}

		/// <summary>
		/// Gets or sets the grain bill. Lbs
		/// </summary>
		/// <value>The grain bill.</value>
		public double GrainBill {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the finished beer volume. Gallons
		/// </summary>
		/// <value>The finished beer volume.</value>
		public double FinishedBeerVolume {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the trub loss. Gallons
		/// </summary>
		/// <value>The trub loss.</value>
		public double TrubLoss {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the equipment loss. Gallons
		/// </summary>
		/// <value>The equipment loss.</value>
		public double EquipmentLoss {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the mash thickness. Quarts per gallon
		/// </summary>
		/// <value>The mash thickness.</value>
		public double MashThickness {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the mash temperature. Degrees Farenheit
		/// </summary>
		/// <value>The mash temperature.</value>
		public double MashTemperature {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the grain temperature. Degrees Farenheit
		/// </summary>
		/// <value>The grain temperature.</value>
		public double GrainTemperature {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the mash time. Minutes
		/// </summary>
		/// <value>The mash time.</value>
		public TimeSpan MashTime {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the boil time. Minutes
		/// </summary>
		/// <value>The boil time.</value>
		public TimeSpan BoilTime {
			get;
			set;
		}
	}
}

