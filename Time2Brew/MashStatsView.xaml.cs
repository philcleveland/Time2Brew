using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ReactiveUI;

namespace Time2Brew.Core
{
	public partial class MashStatsView : ContentPage, IViewFor<MashStatsViewModel>
	{
		public MashStatsView ()
		{
			InitializeComponent ();
		}

		public MashStatsViewModel ViewModel {
			get { return (MashStatsViewModel)GetValue (ViewModelProperty); }
			set { SetValue (ViewModelProperty, value); }
		}

		public static readonly BindableProperty ViewModelProperty =
			BindableProperty.Create<MashStatsView, MashStatsViewModel> (x => x.ViewModel, default(MashStatsViewModel), BindingMode.OneWay);

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (MashStatsViewModel)value; }
		}
	}
}

