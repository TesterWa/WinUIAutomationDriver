using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver
{
   public class UIAutomationDataGridElement:UIAutomationElement
   {
       private CUIAutomationDriver driver;
       public IList<UIAutomationDataGridRowElement> Rows
        {
            get
            {
                IList<UIAutomationElement> rows = this.GetChildsByControlType(UIAutomationElementControlType.Custom);
                rows.RemoveAt(0);
                IList<UIAutomationDataGridRowElement> rows1 = new List<UIAutomationDataGridRowElement>();
                foreach (UIAutomationElement uiAutomationElement in rows)
                {
                    rows1.Add(new UIAutomationDataGridRowElement(driver,uiAutomationElement));
                }
                return rows1;
            }
        }

        public UIAutomationDataGridHeaderElement Header
        {
            get
            {
                UIAutomationElement uiAutomationElement = this.GetChildsByControlType(UIAutomationElementControlType.Custom)[0];
                return  new UIAutomationDataGridHeaderElement(this.driver,uiAutomationElement);
            }
        }

        public UIAutomationDataGridElement(CUIAutomationDriver driver, IUIAutomationElement baseELement) : base(driver, baseELement)
        {
           
            this.driver = driver;

        }

       

        public void Previous()
        {


        }

        public void Next()
        {


        }
    }
}
