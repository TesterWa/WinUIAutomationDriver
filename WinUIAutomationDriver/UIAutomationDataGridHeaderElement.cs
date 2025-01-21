using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver
{
   public class UIAutomationDataGridHeaderElement:UIAutomationElement
   {
       private CUIAutomationDriver driver;
        public IList<UIAutomationDataGridHeaderItemElement> HeaderItems
        {
            get
            {
                IList<UIAutomationElement>  headers = this.GetChildsByControlType(UIAutomationElementControlType.Header);
                IList<UIAutomationDataGridHeaderItemElement> items = new List<UIAutomationDataGridHeaderItemElement>();
                foreach (UIAutomationElement header in headers)
                {
                    items.Add(new UIAutomationDataGridHeaderItemElement(driver,header));
                }

                return items;
            }
        }
        public UIAutomationDataGridHeaderElement(CUIAutomationDriver driver, IUIAutomationElement baseELement) : base(driver, baseELement)
        {
           
            this.driver = driver;
        }

    }
}
