using System;
using Xamarin.Forms;

namespace Time2Brew.Core
{
	public class DecimalConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is decimal)
				return value.ToString ();
			return value;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			decimal dec;
			return decimal.TryParse (value as string, out dec) ? dec : value;
		}

		#endregion
	}
}

