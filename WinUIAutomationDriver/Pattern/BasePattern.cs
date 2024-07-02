using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver.Pattern
{
   public class BasePattern
   {
       public UIAutomationElement _element;
        public BasePattern(UIAutomationElement element)
        {
            this._element = element;
        }
    }
}
