using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver.Interface
{
    public interface IUIAutomationAutomationXpathFind
    {
        UIAutomationElement FindElementByXpath(string xpath);
        IList<UIAutomationElement> FindElementsByXpath(string xpath);
    }
}
