﻿using Clock.UIUpdaters;
using ClockViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Clock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ClockViewModel.ClockViewModel ViewModel { get; set; }

        public MainPage()
        {
            ViewModel = new ClockViewModel.ClockViewModel
            {
                UIUpdaters = new List<IUIUpdater>
                {
                    new SameThreadUIUpdater(),
                    new DispatcherFromCoreWindowUIUpdater(),
                    new DispatcherQueueUIUpdater(
                        dispatcherQueue: DispatcherQueue.GetForCurrentThread()),
                    new SynchronizationContextUIUpdater(),
                }
            };
            this.InitializeComponent();
        }
    }
}
