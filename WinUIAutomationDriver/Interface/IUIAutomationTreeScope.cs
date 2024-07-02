using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver.Interface
{
    public interface IUIAutomationTreeScope
    {
          void SetScoped(TreeScope scope);
          TreeScope GetScoped();
    }
}
