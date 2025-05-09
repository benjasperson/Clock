using ClockViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Clock.UIUpdaters
{
    internal class DispatcherFromCoreWindowUIUpdater : IUIUpdater
    {
        public string Name { get; } = nameof(DispatcherFromCoreWindowUIUpdater);

        public Exception LastException { get; private set; }

        public async void UpdateUI(Action updateAction)
        {
            try
            {
                var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
                await dispatcher.TryRunAsync(
                    priority: CoreDispatcherPriority.Normal,
                    agileCallback: () =>
                    {
                        try
                        {
                            updateAction?.Invoke();
                        }
                        catch (Exception e)
                        {
                            LastException = e;
                        }
                    });
            }
            catch (Exception e)
            {
                LastException = e;
            }
        }
    }
}
