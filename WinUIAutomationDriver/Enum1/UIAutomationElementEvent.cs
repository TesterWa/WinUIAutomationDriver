using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver.Enum1
{
    /// <summary>
    /// automation 事件枚举
    /// </summary>
    public enum UIAutomationElementEvent
    {
        WindowClosed = UIA_EventIds.UIA_Window_WindowClosedEventId,
        WindowOpened = UIA_EventIds.UIA_Window_WindowOpenedEventId,
        Invoked = UIA_EventIds.UIA_Invoke_InvokedEventId,
        TextChanged = UIA_EventIds.UIA_Text_TextChangedEventId,
        SystemAlert = UIA_EventIds.UIA_SystemAlertEventId,
        TextSelectionChanged = UIA_EventIds.UIA_Text_TextSelectionChangedEventId,
        Notification = UIA_EventIds.UIA_NotificationEventId
    }
}
