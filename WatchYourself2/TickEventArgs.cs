using System;

namespace WatchYourself2
{

    public class TickEventArgs : EventArgs
    {
        public TimeSpan TimeLeft { get; private set; }
        public bool TimesUp { get; private set; }

        public TickEventArgs(TimeSpan timeLeft, bool timesUp)
        {
            TimeLeft = timeLeft;
            TimesUp = timesUp;
        }
    }
}
