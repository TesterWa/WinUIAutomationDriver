using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver
{
    /// <summary>
    /// DatagridView的滚动组件
    /// </summary>
   public class UIAutomationDataGridScrollBarElement:UIAutomationElement
   {
       private readonly CUIAutomationDriver driver;
       private readonly IUIAutomationElement baseElement;
        public UIAutomationDataGridScrollBarElement(CUIAutomationDriver driver, IUIAutomationElement baseELement) : base(driver, baseELement)
        {
            this.driver = driver;
            this.baseElement = baseELement;
        }

        public void ScrollDown()
        {

        }

        public void ScrollUp()
        {

        }

        public void ScrollLeft()
        {

        }

        public void ScrollRight()
        {

        }
    }
}
