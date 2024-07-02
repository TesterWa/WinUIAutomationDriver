using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver
{
  public interface IUIAutomationClassFind
  {
      UIAutomationElement FindElementByClass(string classNmae);
      IList<UIAutomationElement> FindElementsByClass(string classNmae);
  }
}
