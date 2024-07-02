using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver
{
   public interface IUIAutomationControlTypeFind
   {
       UIAutomationElement FindElementByControlType(UIAutomationElementControlType controlId);
       IList<UIAutomationElement> FindElementsByControlType(UIAutomationElementControlType controlId);
   }
}
