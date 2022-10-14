using System.Collections.Generic;
using System.Windows;

namespace WatchYourself2
{

    public partial class MainWindow : Window
    {
        private enum Stages
        {
            Seven, Fourteen, TwentyOne
        }

        private readonly Dictionary<Stages, string> _stagesValues;
        private readonly CountdownTimer _stageTimer;

        public MainWindow()
        {
            InitializeComponent();

            _stagesValues = new Dictionary<Stages, string>
            {
                {Stages.Seven, "00:07"},
                {Stages.Fourteen, "00:14"},
                {Stages.TwentyOne, "00:21"}
            };

            _stageTimer = new CountdownTimer();
            _stageTimer.TimeChanged += StageTimerOnTimeChanged;
            _stageTimer.Reset();
        }

        private void StageTimerOnTimeChanged(object sender, TickEventArgs tickEventArgs)
        {
            TimerLbl.Content = tickEventArgs.TimeLeft.ToString(@"mm\:ss");
        }

        private void SetTimer(Stages stage)
        {
            _stageTimer.SetTimeLeft(_stagesValues[stage], true);
        }

        private void SevenBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SetTimer(Stages.Seven);
        }

        private void FourteenBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SetTimer(Stages.Fourteen);
        }

        private void TwentyOneBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SetTimer(Stages.TwentyOne);
        }

        private void StartBtn_OnClick(object sender, RoutedEventArgs e)
        {
            _stageTimer.Start();
        }

        private void ResetBtn_OnClick(object sender, RoutedEventArgs e)
        {
            _stageTimer.Reset();
        }

        private void StopBtn_OnClick(object sender, RoutedEventArgs e)
        {
            _stageTimer.Stop();
        }
    }
}
