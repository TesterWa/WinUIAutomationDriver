using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
    public class UIAutomationElementNotFoundException : Exception
    {
        public UIAutomationElementNotFoundException()
        {
            
        }
        public UIAutomationElementNotFoundException(string message)
            : base(message: message)
        {

        }
    }
}
