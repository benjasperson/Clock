using System;
using System.Collections.Generic;
using System.Text;

namespace ClockViewModel
{
    public interface IUIUpdater
    {
        string Name { get; }
        Exception LastException { get; }
        void UpdateUI(Action updateAction);
    }
}
