using ClockViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clock.UIUpdaters
{
    internal class SynchronizationContextUIUpdater : IUIUpdater
    {
        public string Name { get; } = nameof(SynchronizationContextUIUpdater);

        public Exception LastException { get; private set; }

        public void UpdateUI(Action updateAction)
        {
            try
            {
                SynchronizationContext.Current.Send(
                    d: _ =>
                    {
                        try
                        {
                            updateAction?.Invoke();
                        }
                        catch (Exception e)
                        {
                            LastException = e;
                        }
                    },
                    state: null);
            }
            catch (Exception e)
            {
                LastException = e;
            }
        }
    }
}
