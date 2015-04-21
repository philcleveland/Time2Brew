using System;
using ReactiveUI;

namespace Time2Brew.Core
{
	public class BoolToTemperatureConverter: IBindingTypeConverter
	{
		#region IBindingTypeConverter implementation

		public int GetAffinityForObjects (Type fromType, Type toType)
		{
			if (fromType == typeof(bool) && toType == typeof(TemperatureUnit))
				return 10;
			if (fromType == typeof(TemperatureUnit) && toType == typeof(bool))
				return 10;
			return 0;
		}

		public bool TryConvert (object from, Type toType, object conversionHint, out object result)
		{
			if (toType == typeof(TemperatureUnit)) {
				result = (bool)from ? TemperatureUnit.Fahrenheit : TemperatureUnit.Celsius;
				return true;
			} else if (toType == typeof(bool)) {
				result = (TemperatureUnit)from == TemperatureUnit.Fahrenheit ? true : false;
				return true;
			}

			result = null;
			return false;
		}

		#endregion
	}
		
}

