using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver
{
   public static class Convert2UIAutomationElement
   {
       /// <summary>
       /// 将COM对象转为本地对象
       /// </summary>
       /// <param name="targetElement"></param>
       /// <returns></returns>
        public static UIAutomationElement ConvertCOM2LocalElement(CUIAutomationDriver driver,IUIAutomationElement targetElement)
       {    if(targetElement==null)
                return null;
           return new UIAutomationElement(driver,targetElement);
       }
   }
}
