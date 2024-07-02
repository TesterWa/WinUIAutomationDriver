using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver
{
   public interface IUIAutomationConditionBuilder
   {
       IUIAutomationCondition Build(CUIAutomationDriver driver);
       IUIAutomationConditionBuilder AddContition(UIAutomationElementProperty property, object value);
       void Clear();
   }
}
