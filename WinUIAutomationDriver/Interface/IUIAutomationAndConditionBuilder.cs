

using WinUIAutomationDriver.condition;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver
{
   public interface IUIAutomationAndConditionBuilder:IUIAutomationConditionBuilder
   {
       UIAutoamtionAndConditionBuilder AddAndCondition(UIAutomationElementProperty property, object value);
       UIAutoamtionAndConditionBuilder AddAndControlType(UIAutomationElementControlType controlType);
       UIAutoamtionAndConditionBuilder AddAndClassName(string className);
       UIAutoamtionAndConditionBuilder AddAndName(string name);
       UIAutoamtionAndConditionBuilder AddAndAutomationId(string automationId);
       UIAutoamtionAndConditionBuilder AddAndLocalizedControlType(string controlType);
       UIAutoamtionAndConditionBuilder AddAndIsEnabled(bool isEnable);
       UIAutoamtionAndConditionBuilder AddAndIsOffScreen(bool isOffScreen);
       UIAutoamtionAndConditionBuilder AddAndIsControl(bool isControl);
       UIAutoamtionAndConditionBuilder AddAndIsContent(bool isContent);
   }
}
