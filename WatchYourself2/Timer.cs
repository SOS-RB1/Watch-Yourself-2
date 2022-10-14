﻿using System;
using System.Windows.Threading;

namespace WatchYourself2
{
    public delegate void TickEventHandler(object sender, TickEventArgs e);

    abstract class Timer
    {
        protected readonly DispatcherTimer Tim;
        protected TimeSpan CurrentTime;
        protected TimeSpan LastSetTime;

        public event TickEventHandler TimeChanged;

        protected abstract void TimerOnTick(object sender, EventArgs eventArgs);

        protected Timer()
        {
            Tim = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 1) };
            Tim.Tick += TimerOnTick;
        }

        public void SetTimeLeft(string period, bool start = false)
        {
            Tim.Stop();
            LastSetTime = CurrentTime = TimeSpan.Parse(period);
            OnTimeChange(new TickEventArgs(CurrentTime, false));
            if (start) Tim.Start();
        }

        public void Start()
        {
            if (CurrentTime <= TimeSpan.Zero)
                Reset();
            Tim.Start();
        }

        public void Reset()
        {
            Tim.Stop();
            CurrentTime = LastSetTime;
            OnTimeChange(new TickEventArgs(CurrentTime, false));
        }

        public void Stop()
        {
            Tim.Stop();
        }

        public bool IsRunning()
        {
            return Tim.IsEnabled;
        }

        protected virtual void OnTimeChange(TickEventArgs e)
        {
            TimeChanged?.Invoke(this, e);
        }
    }
}
