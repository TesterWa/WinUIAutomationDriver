using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver.Pattern
{
   public class InvokePattern:BasePattern,IUIAutomationInvokePattern
   {
       private readonly int invokePattern = (int)UIAutomationElementPattern.InvokePattern;

        public InvokePattern(UIAutomationElement element) : base(element)
        {
            
        }
        
        public void Invoke()
        {
            IUIAutomationInvokePattern currentPattern = (IUIAutomationInvokePattern)base._element.GetCurrentPattern(invokePattern);
            currentPattern.Invoke();
        }
    }
}
