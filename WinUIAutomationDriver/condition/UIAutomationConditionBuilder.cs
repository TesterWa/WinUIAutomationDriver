using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver.condition
{
    public class UIAutomationConditionBuilder : IUIAutomationConditionBuilder
    {
        private UIAutomationElementProperty property;
        private object value;
        public UIAutomationConditionBuilder()
        {

        }
        public IUIAutomationCondition Build(CUIAutomationDriver driver)
        {
            return driver.CreateCondition(property, value);
        }

        public IUIAutomationConditionBuilder AddContition(UIAutomationElementProperty property, object value)
        {
            this.property = property;
            this.value = value;

            return this;
        }

        public void Clear()
        {
            this.property = default(UIAutomationElementProperty);
            this.value = null;
        }
    }
}
