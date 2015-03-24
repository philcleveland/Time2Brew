using System;
using System.Runtime.Serialization;
using ReactiveUI;

namespace Time2Brew.Core
{
	[DataContract]
	public class BoilTimerViewModel : ReactiveObject, IRoutableViewModel
	{
		public BoilTimerViewModel (IScreen hostScreen)
		{
			HostScreen = hostScreen;

			StartTimer = ReactiveCommand.Create ();
			StartTimer.Subscribe ();

			PauseTimer = ReactiveCommand.Create ();
			PauseTimer.Subscribe ();

			ResetTimer = ReactiveCommand.Create ();
			ResetTimer.Subscribe ();
		}

		[IgnoreDataMember]
		public string UrlPathSegment {
			get {
				return "Boil Timer";
			}
		}

		[IgnoreDataMember]
		public IScreen HostScreen { get; protected set; }

		public ReactiveCommand<object> StartTimer { get; private set; }

		public ReactiveCommand<object> PauseTimer { get; private set; }

		public ReactiveCommand<object> ResetTimer { get; private set; }
	}
}

