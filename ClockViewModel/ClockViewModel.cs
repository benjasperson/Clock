using GalaSoft.MvvmLight.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Timers;

namespace ClockViewModel
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        const int TIMER_INTERVAL_MILLISECONDS = 1000;
        public event PropertyChangedEventHandler PropertyChanged;
        readonly Timer _Timer = new Timer(TIMER_INTERVAL_MILLISECONDS);
        public RelayCommand RefreshErrorCommand { get; }
        public IEnumerable<IUIUpdater> UIUpdaters { get; set; }
        public IUIUpdater SelectedUIUpdater { get; set; }
        public string Time => DateTime.Now.ToString();
        public string ErrorMessage => 
            SelectedUIUpdater?.LastException?.Message ?? string.Empty;
        public ClockViewModel()
        {
            RefreshErrorCommand = new RelayCommand(RefreshErrorMessage);
            _Timer.Elapsed += Timer_Elapsed;
            _Timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SelectedUIUpdater?.UpdateUI(() =>
            {
                RaisePropertyChanged(nameof(Time));
            });
        }

        public void RefreshErrorMessage() =>
            RaisePropertyChanged(nameof(ErrorMessage));

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                    sender: this,
                    e: new PropertyChangedEventArgs(propertyName));

        }
    }
}
