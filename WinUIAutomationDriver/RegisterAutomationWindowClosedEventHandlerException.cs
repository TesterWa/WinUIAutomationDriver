using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
   public class RegisterAutomationWindowClosedEventHandlerException:RegisterAutomationWindowEventHandlerException
    {
        public RegisterAutomationWindowClosedEventHandlerException(string message) : base(message)
        {
        }

        public RegisterAutomationWindowClosedEventHandlerException(string messsage, Exception innerException) : base(messsage, innerException)
        {
        }
    }
}
