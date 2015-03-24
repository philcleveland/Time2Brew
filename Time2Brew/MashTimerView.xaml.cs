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

			this.OneWayBind (ViewModel, vm => vm.ClockText, v => v.lblClockDisplay.Text);
			this.BindCommand (ViewModel, vm => vm.StartTimer, v => v.btnStart);
			this.BindCommand (ViewModel, vm => vm.PauseTimer, v => v.btnPause);
			this.BindCommand (ViewModel, vm => vm.ResetTimer, v => v.btnReset);

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

