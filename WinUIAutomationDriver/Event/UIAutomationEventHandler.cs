using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver.Event
{
    public delegate void UIAutomationHandler(object sender, UIAutomationEventArgs e);
    public class UIAutomationEventHandler : IUIAutomationEventHandler
    {
//        public event EventHandler UIAutomationClosedHandler;
//        public event EventHandler UIAutomationOpenedHandler;
        public event UIAutomationHandler UIAutomaitonEventHander;
        public virtual void HandleAutomationEvent(IUIAutomationElement sender, int eventId)
        {

            UIAutomationElementEvent e = (UIAutomationElementEvent)Enum.Parse(typeof(UIAutomationElementEvent), eventId.ToString());
            if(UIAutomaitonEventHander!=null)
                UIAutomaitonEventHander.Invoke(null, new UIAutomationEventArgs(sender, e));
//            if (e == UIAutomationElementEvent.WindowOpened && UIAutomationOpenedHandler != null)
//                UIAutomationOpenedHandler.Invoke(null, new UIAutomationEventArgs(sender, e));
//            else if (e == UIAutomationElementEvent.WindowClosed && UIAutomationClosedHandler != null)
//                UIAutomationClosedHandler.Invoke(null, new UIAutomationEventArgs(sender, e));
        }
    }
}
