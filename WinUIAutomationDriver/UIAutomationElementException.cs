using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
   public class UIAutomationElementException:Exception
    {
        public UIAutomationElementException()
        {
            
        }

        public UIAutomationElementException(string message):base(message:message)
        {
            
        }
    }
}
