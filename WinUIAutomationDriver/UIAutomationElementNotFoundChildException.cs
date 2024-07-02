using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
   public class UIAutomationElementNotFoundChildException:Exception
    {
        public UIAutomationElementNotFoundChildException()
        {
            
        }
        public UIAutomationElementNotFoundChildException(string message):base(message:message)
        {
            
        }
    }
}
