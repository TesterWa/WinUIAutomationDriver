using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver.condition
{
    public class UIAutoamtionAndConditionBuilder : IUIAutomationAndConditionBuilder
    {
        //private CUIAutomationDriver driver;
        //private IList<IUIAutomationCondition> builder = new List<IUIAutomationCondition>();
        private Dictionary<UIAutomationElementProperty, object> _builder = new Dictionary<UIAutomationElementProperty, object>();

        public UIAutoamtionAndConditionBuilder()
        {

        }
//        public UIAutoamtionAndConditionBuilder(CUIAutomationDriver driver)
//        {
//            this.driver = driver;
//        }
        public IUIAutomationCondition Build(CUIAutomationDriver driver)
        {
            if (driver == null)
            {
                return null;
            }
            List<IUIAutomationCondition> conditions = new List<IUIAutomationCondition>();
            foreach (KeyValuePair<UIAutomationElementProperty, object> item in _builder)
            {
                IUIAutomationCondition condition = driver.CreateCondition(item.Key, item.Value);
                conditions.Add(condition);
            }
            return driver.CreateAndCondition(conditions.ToArray());
        }

        public IUIAutomationConditionBuilder AddContition(UIAutomationElementProperty property, object value)
        {
            _builder.Add(property, value);
            return this;
        }

        public void Clear()
        {
            _builder.Clear();
            //this.builder.Clear();
        }

        public UIAutoamtionAndConditionBuilder AddAndCondition(UIAutomationElementProperty propertyId, object value)
        {
            //IUIAutomationCondition uiAutomationCondition = driver.CreateCondition(propertyId, value);
            //builder.Add(uiAutomationCondition);

            return (UIAutoamtionAndConditionBuilder)AddContition(propertyId,value);
        }

        public UIAutoamtionAndConditionBuilder AddAndControlType(UIAutomationElementControlType controlType)
        {

            return AddAndCondition(UIAutomationElementProperty.ControlType, controlType); ;
        }

        public UIAutoamtionAndConditionBuilder AddAndClassName(string className)
        {
            return AddAndCondition(UIAutomationElementProperty.ClassName, className); ;

        }

        public UIAutoamtionAndConditionBuilder AddAndName(string name)
        {
            return AddAndCondition(UIAutomationElementProperty.Name, name); ;
        }

        public UIAutoamtionAndConditionBuilder AddAndAutomationId(string automationId)
        {
            return AddAndCondition(UIAutomationElementProperty.AutomationId, automationId); ;
        }

        public UIAutoamtionAndConditionBuilder AddAndLocalizedControlType(string controlType)
        {
            return AddAndCondition(UIAutomationElementProperty.LocalizedControlType, controlType); ;
        }

        public UIAutoamtionAndConditionBuilder AddAndIsEnabled(bool isEnable)
        {
            return AddAndCondition(UIAutomationElementProperty.IsEnabled, isEnable);
        }

        public UIAutoamtionAndConditionBuilder AddAndIsOffScreen(bool isOffScreen)
        {
            return AddAndCondition(UIAutomationElementProperty.IsOffScreen, isOffScreen);
        }

        public UIAutoamtionAndConditionBuilder AddAndIsControl(bool isControl)
        {
            return AddAndCondition(UIAutomationElementProperty.IsControlElement, isControl);
        }

        public UIAutoamtionAndConditionBuilder AddAndIsContent(bool isContent)
        {
            return AddAndCondition(UIAutomationElementProperty.IsContentElement, isContent);
        }
    }
}
