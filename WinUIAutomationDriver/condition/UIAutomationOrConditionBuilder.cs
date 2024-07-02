using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;
using WinUIAutomationDriver.Interface;

namespace WinUIAutomationDriver.condition
{
    public class UIAutomationOrConditionBuilder : IUIAutomationOrConditionBuilder
    {
        //private CUIAutomationDriver driver;
        //private IList<IUIAutomationCondition> builder = new List<IUIAutomationCondition>();
        private Dictionary<UIAutomationElementProperty, object> _builder = new Dictionary<UIAutomationElementProperty, object>();

        public UIAutomationOrConditionBuilder()
        {

        }
        //        public UIAutomationOrConditionBuilder(CUIAutomationDriver driver)
        //        {
        //            this.driver = driver;
        //        }
        public IUIAutomationCondition Build(CUIAutomationDriver driver)
        {
            //return driver.CreateOrCondition(builder.ToArray());
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
            return driver.CreateOrCondition(conditions.ToArray());
        }

        public IUIAutomationConditionBuilder AddContition(UIAutomationElementProperty property, object value)
        {
            _builder.Add(property, value);
            return this;
        }

        public void Clear()
        {
            _builder.Clear();
        }


        #region IUIAutomationOrConditionBuilder 成员

        public UIAutomationOrConditionBuilder AddOrCondition(UIAutomationElementProperty propertyId, object value)
        {
            //IUIAutomationCondition uiAutomationCondition = driver.CreateCondition(propertyId, value);
            //builder.Add(uiAutomationCondition);

            return (UIAutomationOrConditionBuilder)AddContition(propertyId, value);
        }

        public UIAutomationOrConditionBuilder AddOrControlType(UIAutomationElementControlType controlType)
        {
            return AddOrCondition(UIAutomationElementProperty.ControlType, controlType);

        }

        public UIAutomationOrConditionBuilder AddOrClassName(string className)
        {
            return AddOrCondition(UIAutomationElementProperty.ClassName, className);

        }

        public UIAutomationOrConditionBuilder AddOrName(string name)
        {
            return AddOrCondition(UIAutomationElementProperty.Name, name);
        }

        public UIAutomationOrConditionBuilder AddOrAutomationId(string automationId)
        {
            return AddOrCondition(UIAutomationElementProperty.AutomationId, automationId);
        }

        public UIAutomationOrConditionBuilder AddOrLocalizedControlType(string controlType)
        {
            return AddOrCondition(UIAutomationElementProperty.LocalizedControlType, controlType);
        }

        public UIAutomationOrConditionBuilder AddOrIsEnabled(bool isEnable)
        {
            return AddOrCondition(UIAutomationElementProperty.IsEnabled, isEnable);
        }

        public UIAutomationOrConditionBuilder AddOrIsOffScreen(bool isOffScreen)
        {
            return AddOrCondition(UIAutomationElementProperty.IsOffScreen, isOffScreen);
        }

        public UIAutomationOrConditionBuilder AddOrIsControl(bool isControl)
        {
            return AddOrCondition(UIAutomationElementProperty.IsControlElement, isControl);
        }

        public UIAutomationOrConditionBuilder AddOrIsContent(bool isContent)
        {
            return AddOrCondition(UIAutomationElementProperty.IsContentElement, isContent);
        }

        #endregion
    }
}
