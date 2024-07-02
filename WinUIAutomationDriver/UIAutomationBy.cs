using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver
{
    public class UIAutomationBy
    {
        private Func<IUIFindElementContext, UIAutomationElement> findElementMethod;
        private Func<IUIFindElementContext, IList<UIAutomationElement>> findElementsMethod;

        public virtual UIAutomationElement FindElement(IUIFindElementContext context)
        {
            return this.findElementMethod(context);
        }

        public virtual IList<UIAutomationElement> FindElements(IUIFindElementContext context)
        {

            return this.findElementsMethod(context);
        }

        public static UIAutomationBy AutomationId(string automationId)
        {
            return new UIAutomationBy()
            {
                findElementMethod = (Func<IUIFindElementContext, UIAutomationElement>)(context => ((IUIAutomationAutomationIdFind)context).FindElementByAutomationId(automationId)),
                findElementsMethod = (Func<IUIFindElementContext, IList<UIAutomationElement>>)(context => { throw new NotImplementedException("AutomationId应该是全局唯一，请使用单个查找~！"); })
            };

        }

        public static UIAutomationBy Name(string name)
        {

            return new UIAutomationBy()
            {
                findElementMethod = context => ((IUIAutomationNameFind)context).FindElementByName(name),
                findElementsMethod = context => (context as IUIAutomationNameFind).FindElementsByName(name)

            };
        }

        public static UIAutomationBy Class(string className)
        {

            return new UIAutomationBy()
            {
                findElementMethod = context => (context as IUIAutomationClassFind).FindElementByClass(className),
                findElementsMethod = context => (context as IUIAutomationClassFind)
                    .FindElementsByClass(className)
            };
        }

        public static UIAutomationBy ControlType(UIAutomationElementControlType controlTypeId)
        {


            return new UIAutomationBy()
            {
                findElementMethod = context => (context as IUIAutomationControlTypeFind).FindElementByControlType(controlTypeId),
                findElementsMethod = context => (context as IUIAutomationControlTypeFind)
                    .FindElementsByControlType(controlTypeId)
            };
        }


        public static UIAutomationBy LocalizedControlType(string controlType)
        {


            return new UIAutomationBy()
            {
                findElementMethod = context => (context as IUIAutomationLocalizedControlTypeFind).FindElementByLocalizedControlType(controlType),
                findElementsMethod = context => (context as IUIAutomationLocalizedControlTypeFind)
                    .FindElementsByLocalizedControlType(controlType)
            };
        }


    }
}
