using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
    public class RegisterAutomationWindowOpendEventHandlerException : RegisterAutomationWindowEventHandlerException
    {
        public RegisterAutomationWindowOpendEventHandlerException(string message) : base(message)
        {
        }

        public RegisterAutomationWindowOpendEventHandlerException(string messsage, Exception innerException) : base(messsage, innerException)
        {
        }
    }
}
