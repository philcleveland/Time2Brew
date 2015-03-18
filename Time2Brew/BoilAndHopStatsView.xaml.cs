using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ReactiveUI;

namespace Time2Brew.Core
{
	public partial class BoilAndHopStatsView : ContentPage, IViewFor<BoilAndHopStatsViewModel>
	{
		public BoilAndHopStatsView ()
		{
			InitializeComponent ();
		}

		public BoilAndHopStatsViewModel ViewModel {
			get { return (BoilAndHopStatsViewModel)GetValue (ViewModelProperty); }
			set { SetValue (ViewModelProperty, value); }
		}

		public static readonly BindableProperty ViewModelProperty =
			BindableProperty.Create<BoilAndHopStatsView, BoilAndHopStatsViewModel> (x => x.ViewModel, default(BoilAndHopStatsViewModel), BindingMode.OneWay);

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (BoilAndHopStatsViewModel)value; }
		}
	}
}

