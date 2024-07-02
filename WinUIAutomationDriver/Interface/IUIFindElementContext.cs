using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver
{
   public interface IUIFindElementContext
   {
       UIAutomationElement FindElement(UIAutomationBy by);
       IList<UIAutomationElement> FindElements(UIAutomationBy by);
   }
}
