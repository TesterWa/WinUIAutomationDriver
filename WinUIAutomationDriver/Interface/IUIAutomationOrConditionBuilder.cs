using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUIAutomationDriver.condition;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver.Interface
{
   public interface IUIAutomationOrConditionBuilder:IUIAutomationConditionBuilder
   {
       UIAutomationOrConditionBuilder AddOrCondition(UIAutomationElementProperty property, object value);
       UIAutomationOrConditionBuilder AddOrControlType(UIAutomationElementControlType controlType);
       UIAutomationOrConditionBuilder AddOrClassName(string className);
       UIAutomationOrConditionBuilder AddOrName(string name);
       UIAutomationOrConditionBuilder AddOrAutomationId(string automationId);
       UIAutomationOrConditionBuilder AddOrLocalizedControlType(string controlType);
       UIAutomationOrConditionBuilder AddOrIsEnabled(bool isEnable);
       UIAutomationOrConditionBuilder AddOrIsOffScreen(bool isOffScreen);
       UIAutomationOrConditionBuilder AddOrIsControl(bool isControl);
       UIAutomationOrConditionBuilder AddOrIsContent(bool isContent);
   }
}
