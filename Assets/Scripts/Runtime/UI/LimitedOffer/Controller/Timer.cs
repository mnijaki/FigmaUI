namespace MN.Runtime.UI.LimitedOffer.Controller
{
	// MN:TODO: this class is written in hurry, so it is not optimal.
	// MN:TODO: needs to be refactored if used in production.
	public class Timer
	{
		public string TimeLeftTxt { get; private set; }
		
		// 1 hour, 2 minutes, 3 seconds
		private float _timeLeft = 3723000;
		private bool _isTimerRunning = true;
		
		public void Tick(float deltaTime)
		{
			if(!_isTimerRunning)
			{
				return;
			}
			
			if (_timeLeft > 0)
			{
				_timeLeft -= deltaTime * 1000;
				SetTimeLeft(_timeLeft);
			}
			else
			{
				_timeLeft = 0;
				_isTimerRunning = false;
			}
		}

		private void SetTimeLeft(float timeToDisplay)
		{
			int hours = (int)(timeToDisplay / (1000 * 60 * 60));
			int minutes = (int)((timeToDisplay % (1000 * 60 * 60)) / (1000 * 60));
			int seconds = (int)((timeToDisplay % (1000 * 60)) / 1000);
			TimeLeftTxt = $"{hours:00}:{minutes:00}:{seconds:00}";
		}
	}
}