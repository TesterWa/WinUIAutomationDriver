using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver
{
    public class UIAutomationDataGridRowElement : UIAutomationElement
    {
        private CUIAutomationDriver driver;
        public IList<UIAutomationDataGridRowCellElement> Cells
        {
            get
            {
                IList<UIAutomationElement> cells = this.FindElementsByControlType(UIAutomationElementControlType.DataGridItem);
                IList<UIAutomationDataGridRowCellElement> cells1 = new List<UIAutomationDataGridRowCellElement>();
                foreach (UIAutomationElement uiAutomationElement in cells)
                {
                    cells1.Add(new UIAutomationDataGridRowCellElement(driver,uiAutomationElement));
                }

                return cells1;
            }
        }
        public UIAutomationDataGridRowElement(CUIAutomationDriver driver, IUIAutomationElement baseELement)
            : base(driver, baseELement)
        {
            this.driver = driver;
        }

        public string GetRowValue()
        {

            return GetRowValueInternal();

            return string.Empty;
        }

        private string GetRowValueInternal()
        {
            IUIAutomationLegacyIAccessiblePattern legacyIAccessiblePattern = this.CheckElementSupportPattren<IUIAutomationLegacyIAccessiblePattern>(UIAutomationElementPattern.LegacyIAccessiblePattern) as IUIAutomationLegacyIAccessiblePattern;
            if (legacyIAccessiblePattern != null)
                return legacyIAccessiblePattern.CurrentValue;
            return string.Empty;
        }
    }
}
