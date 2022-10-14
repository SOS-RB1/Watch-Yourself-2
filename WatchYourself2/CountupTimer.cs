using System;

namespace WatchYourself2
{

    class CountupTimer : Timer
    {
        public CountupTimer()
        {
            SetTimeLeft("00:00");
        }

        protected override void TimerOnTick(object sender, EventArgs eventArgs)
        {
            CurrentTime += TimeSpan.FromSeconds(1.0);
            OnTimeChange(new TickEventArgs(CurrentTime, false));
        }
    }
}
