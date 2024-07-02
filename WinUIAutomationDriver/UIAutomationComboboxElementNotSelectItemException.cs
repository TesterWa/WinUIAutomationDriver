using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
    public class UIAutomationComboboxElementNotSelectItemException : Exception
    {
        public UIAutomationComboboxElementNotSelectItemException()
        {
            
        }

        public UIAutomationComboboxElementNotSelectItemException(string message):base(message)
        {
            
        }
    }
}
