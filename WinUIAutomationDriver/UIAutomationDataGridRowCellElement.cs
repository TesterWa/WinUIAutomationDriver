using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver
{
   public class UIAutomationDataGridRowCellElement:UIAutomationElement
    {
        public UIAutomationDataGridRowCellElement(CUIAutomationDriver driver, IUIAutomationElement baseELement) : base(driver, baseELement)
        {
        }

        //public override void Click()
        //{
        //    IntPtr handle = this.CurrentNativeWindowHandle;
        //    IntPtr postMessage = NativeMethod.NativeMethods.PostMessage(new HandleRef(handle, handle), 0xf5, IntPtr.Zero, IntPtr.Zero);
        //    if (postMessage == IntPtr.Zero)
        //        throw new Exception("use win32.dll native function click element error!");
        //}

        //public override void DoubleClick()
        //{
        //    this.Click();
        //    this.Click();
        //}
    }
}
