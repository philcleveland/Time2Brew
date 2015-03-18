using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ReactiveUI;

namespace Time2Brew.Core
{
	public partial class MashTimerView : ContentPage, IViewFor<MashTimerViewModel>
	{
		public MashTimerView ()
		{
			InitializeComponent ();
		}

		public MashTimerViewModel ViewModel {
			get { return (MashTimerViewModel)GetValue (ViewModelProperty); }
			set { SetValue (ViewModelProperty, value); }
		}

		public static readonly BindableProperty ViewModelProperty =
			BindableProperty.Create<MashTimerView, MashTimerViewModel> (x => x.ViewModel, default(MashTimerViewModel), BindingMode.OneWay);

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (MashTimerViewModel)value; }
		}
	}
}

