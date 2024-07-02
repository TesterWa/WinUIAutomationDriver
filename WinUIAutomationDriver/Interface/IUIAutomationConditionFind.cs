using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver.Interface
{
   public interface IUIAutomationConditionFind
   {
       UIAutomationElement FindElementByCondition(IUIAutomationCondition condition);
       IList<UIAutomationElement> FindElementsByCondition(IUIAutomationCondition condition);

   }
}
