using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver
{
   public interface IUIAutomationLocalizedControlTypeFind
   {
       UIAutomationElement FindElementByLocalizedControlType(string localizedControlType);
       IList<UIAutomationElement> FindElementsByLocalizedControlType(string localizedControlType);
   }
}
