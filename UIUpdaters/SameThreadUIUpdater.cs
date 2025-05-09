using ClockViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock.UIUpdaters
{
    internal class SameThreadUIUpdater : IUIUpdater
    {
        public string Name { get; } = nameof(SameThreadUIUpdater);

        public Exception LastException { get; private set; }

        public void UpdateUI(Action updateAction)
        {
            try
            {
                updateAction?.Invoke();
            }
            catch (Exception e)
            {
                LastException = e;
            }
        }
    }
}
