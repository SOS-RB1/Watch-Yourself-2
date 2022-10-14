using System;
using System.Media;
using System.Windows;

namespace WatchYourself2
{

    class CountdownTimer : Timer
    {

        private readonly SoundPlayer sound;

        public CountdownTimer()
        {
            SetTimeLeft("00:28");

            sound = new SoundPlayer("bell.wav");

        }

        protected override void TimerOnTick(object sender, EventArgs eventArgs)
        {
            CurrentTime -= TimeSpan.FromSeconds(1.0);

            if (CurrentTime == TimeSpan.Zero)
            {
                OnTimeChange(new TickEventArgs(CurrentTime, true));
                Tim.Stop();

                sound.Load();
                sound.Play();

                MessageBox.Show("Easy man, slow down", "Watch Yourself 2");

            }
            else
            {
                OnTimeChange(new TickEventArgs(CurrentTime, false));
            }
        }
    }
}
