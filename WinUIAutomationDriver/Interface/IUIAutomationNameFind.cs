using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver
{
   public interface IUIAutomationNameFind
   {
       UIAutomationElement FindElementByName(string name);
       IList<UIAutomationElement> FindElementsByName(string name);
   }
}
