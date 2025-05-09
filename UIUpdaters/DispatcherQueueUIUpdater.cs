using ClockViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace Clock.UIUpdaters
{
    internal class DispatcherQueueUIUpdater : IUIUpdater
    {
        readonly DispatcherQueue _DispatcherQueue;
        public string Name { get; } = nameof(DispatcherQueueUIUpdater);

        public Exception LastException { get; private set; }

        public DispatcherQueueUIUpdater(DispatcherQueue dispatcherQueue)
        {
            _DispatcherQueue = dispatcherQueue;
        }
        public void UpdateUI(Action updateAction)
        {
            try
            {
                _DispatcherQueue.TryEnqueue(() =>
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
