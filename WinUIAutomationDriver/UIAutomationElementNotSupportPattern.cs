using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
    public class UIAutomationElementNotSupportPattern : Exception
    {
        public UIAutomationElementNotSupportPattern()
        {

        }

        public UIAutomationElementNotSupportPattern(string message)
            : base(message : message)
        {

        }
    }
}
