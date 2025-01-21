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
    public class UIAutomationDataGridElement : UIAutomationElement
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
                    rows1.Add(new UIAutomationDataGridRowElement(driver, uiAutomationElement));
                }
                return rows1;
            }
        }

        public IList<UIAutomationDataGridScrollBarElement> ScrollBar
        {
            get
            {
                IList<UIAutomationElement> scrollBars = this.GetChildsByControlType(UIAutomationElementControlType.ScrollBar);
                IList<UIAutomationDataGridScrollBarElement> scrollBarElements = new List<UIAutomationDataGridScrollBarElement>();
                foreach (UIAutomationElement uiAutomationElement in scrollBars)
                {
                    scrollBarElements.Add(new UIAutomationDataGridScrollBarElement(driver, uiAutomationElement));
                }
                return scrollBarElements;
            }
        }
        public UIAutomationDataGridHeaderElement Header
        {
            get
            {
                UIAutomationElement uiAutomationElement = this.GetChildsByControlType(UIAutomationElementControlType.Custom)[0];
                return new UIAutomationDataGridHeaderElement(this.driver, uiAutomationElement);
            }
        }

        public UIAutomationDataGridElement(CUIAutomationDriver driver, IUIAutomationElement baseELement)
            : base(driver, baseELement)
        {

            this.driver = driver;

        }



        public void Previous()
        {


        }

        public void Next()
        {


        }

        public void ScrollToRow(UIAutomationDataGridRowElement row)
        {
            if (row == null)
                return;
            IList<UIAutomationDataGridScrollBarElement> uiAutomationDataGridScrollBarElements = this.ScrollBar;
            if (uiAutomationDataGridScrollBarElements == null || !uiAutomationDataGridScrollBarElements.Any())
                return;
            UIAutomationDataGridScrollBarElement scroll = uiAutomationDataGridScrollBarElements.FirstOrDefault(s => s.CurrentName.Contains("垂直滚动条"));
            if(scroll==null)
                return;
            IList<UIAutomationElement> scrollButtons = scroll.GetChildsByControlType(UIAutomationElementControlType.Button);
            if (scrollButtons == null || !scrollButtons.Any())
                throw new UIAutomationElementNotFoundException("未找到滚动器下的翻页按钮！");
            UIAutomationElement prvious = scrollButtons.FirstOrDefault(s => s.CurrentName.Contains("上一行"));
            UIAutomationElement next = scrollButtons.FirstOrDefault(s => s.CurrentName.Contains("下一行"));
            tagRECT gridRect = this.CurrentBoundingRectangle;
            Console.WriteLine("当前grid边界：" + gridRect);
            while (row.CurrentIsOffscreen != 0)
            {
                //                tagRECT rowRect = row.CurrentBoundingRectangle;
                //                Console.WriteLine("目标行边界："+rowRect);
                //                //判断当前行是否超出grid容器边界
                //                if(rowRect.bottom<gridRect.top)
                //                    prvious.Click();
                //                else if (rowRect.top > gridRect.bottom)
                //                    next.Click();
                //                else
                //                    break;


                next.Click();
            }
        }

        public void ScrollToCell(UIAutomationDataGridRowCellElement cell)
        {
            if (cell == null)
                return;
            IList<UIAutomationDataGridScrollBarElement> uiAutomationDataGridScrollBarElements = this.ScrollBar;
            if (uiAutomationDataGridScrollBarElements == null || !uiAutomationDataGridScrollBarElements.Any())
                return;
            UIAutomationDataGridScrollBarElement scroll = uiAutomationDataGridScrollBarElements.FirstOrDefault(s => s.CurrentName.Contains("水平滚动条"));
            if(scroll==null)
                return;
            IList<UIAutomationElement> scrollButtons = scroll.GetChildsByControlType(UIAutomationElementControlType.Button);
            if (scrollButtons == null || !scrollButtons.Any())
                throw new UIAutomationElementNotFoundException("未找到滚动器下的翻页按钮！");
            UIAutomationElement left = scrollButtons.FirstOrDefault(s => s.CurrentName.Contains("左移一列"));
            UIAutomationElement right = scrollButtons.FirstOrDefault(s => s.CurrentName.Contains("右移一列"));
            tagRECT gridRect = this.CurrentBoundingRectangle;
            Console.WriteLine("当前grid边界：" + gridRect);
            while (cell.CurrentIsOffscreen != 0)
            {
                //                tagRECT cellRect = cell.CurrentBoundingRectangle;
                //                Console.WriteLine("目标单元格边界：" + cellRect);
                //                //判断当前行是否超出grid容器边界
                //                if (cellRect.right < gridRect.left)
                //                    left.Click();
                //                else if (cellRect.left > gridRect.right)
                //                    right.Click();
                //                else
                //                    break;
                right.Click();
            }
        }
    }
}
