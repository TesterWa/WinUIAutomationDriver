using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver.Event
{
    public class UIAutomationEventArgs:EventArgs
    {
        public IUIAutomationElement Element;
        public UIAutomationElementEvent Event;
        public UIAutomationEventArgs(IUIAutomationElement element, UIAutomationElementEvent eventId)
        {
            this.Element = element;
            this.Event = eventId;
        }
    }
}
