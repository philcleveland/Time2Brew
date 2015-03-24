using System;
using ReactiveUI;
using System.Runtime.Serialization;
using Splat;
using Xamarin.Forms;
using System.Reactive.Linq;

namespace Time2Brew.Core
{
	[DataContract]
	public class MashTimerViewModel : ReactiveObject, IRoutableViewModel
	{


		public MashTimerViewModel (IScreen hostScreen, BrewData data)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen> ();

			CurrentTimeRemaining = (int)data.MashTime.TotalSeconds;

			var canStartOrReset = this.WhenAnyValue (x => x.IsTimerRunning).Where (x => !x);

			StartTimer = ReactiveCommand.Create (canStartOrReset);
			var start = StartTimer.Select (x => true);

			PauseTimer = ReactiveCommand.Create (this.WhenAnyValue (x => x.IsTimerRunning).Where (x => x));
			var pause = PauseTimer.Select (x => false);

			Observable.Merge (start, pause)
				.StartWith (false)
				.ToProperty (this, vm => vm.IsTimerRunning, out _IsTimerRunning);

			ResetTimer = ReactiveCommand.Create (canStartOrReset);
			ResetTimer.Subscribe (_ => {
				CurrentTimeRemaining = (int)data.MashTime.TotalSeconds;
			});


			this.WhenAnyValue (x => x.IsTimerRunning)
				.Where (x => x == true)
				.Subscribe (_ => Device.StartTimer (TimeSpan.FromSeconds (1), () => {
				if (CurrentTimeRemaining > 0)
					CurrentTimeRemaining -= 1;
				return IsTimerRunning;
			}));




			this.WhenAnyValue (x => x.CurrentTimeRemaining)
				.Select (x => TimeSpan.FromSeconds (x).ToString ())
				.ToProperty (this, vm => vm.ClockText, out _ClockText);
		}

		[IgnoreDataMember]
		public string UrlPathSegment {
			get {
				return "Mash Timer";
			}
		}

		[IgnoreDataMember]
		public IScreen HostScreen { get; protected set; }

		[IgnoreDataMember]
		public ReactiveCommand<object> StartTimer { get; private set; }

		[IgnoreDataMember]
		public ReactiveCommand<object> PauseTimer { get; private set; }

		[IgnoreDataMember]
		public ReactiveCommand<object> ResetTimer { get; private set; }

		private ObservableAsPropertyHelper<bool> _IsTimerRunning;

		public bool IsTimerRunning { 
			get { return _IsTimerRunning.Value; }
		}

		private int _CurrentTimeRemaining;

		/// <summary>
		/// Gets or sets the current time remaining. Seconds remaining
		/// </summary>
		/// <value>The current time remaining.</value>
		public int CurrentTimeRemaining { 
			get { return _CurrentTimeRemaining; }
			set { this.RaiseAndSetIfChanged (ref _CurrentTimeRemaining, value); }	
		}

		private ObservableAsPropertyHelper<string> _ClockText;

		public string ClockText { 
			get { return _ClockText.Value; }
		}
	}
}

