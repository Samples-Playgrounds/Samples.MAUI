using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using StopwatchMaui.Models;

namespace StopwatchMaui.ViewModels
{
    public class StopWatchViewModel : BaseViewModel
    {
        readonly Stopwatch stopwatch = new();
        public ObservableCollection<LapTime> LapTimes { get; private set; } = new ObservableCollection<LapTime>();

        private TimeSpan _elapsed;
        public TimeSpan Elapsed
        {
            get => _elapsed;
            set => SetProperty(ref _elapsed, value);
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        private bool _hasLaps;
        public bool HasLaps
        {
            get => _hasLaps;
            set => SetProperty(ref _hasLaps, value);
        }

        private string _elapsedTime;
        public string ElapsedTime
        {
            get => _elapsedTime;
            set => SetProperty(ref _elapsedTime, value);
        }

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand LapCommand { get; }
        public ICommand ClearCommand { get; }

        private string FormatElapsedTime(TimeSpan timeSpan)
        {
            return timeSpan.ToString(@"mm\:ss\.fff");
        }

        private void Start()
        {
            stopwatch.Restart();

            IsRunning = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ElapsedTime = FormatElapsedTime(stopwatch.Elapsed);
                });
                return _isRunning;
            });
        }

        private void Stop()
        {
            stopwatch.Stop();
            IsRunning = false;
        }

        private void Lap()
        {
            LapTimes.Add(new LapTime { LapNumber = LapTimes.Count + 1, ElapsedTime = ElapsedTime });

            HasLaps = true;
        }

        private void Clear()
        {
            LapTimes.Clear();
            ElapsedTime = "00:00.000";
            HasLaps = false;
        }

        public StopWatchViewModel()
        {
            ElapsedTime = "00:00.000";
            IsRunning = false;
            StartCommand = new Command(() => Start());
            StopCommand = new Command(() => Stop());
            LapCommand = new Command(() => Lap());
            ClearCommand = new Command(() => Clear());
        }
    }
}
