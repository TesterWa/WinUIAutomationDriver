using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
    public class RegisterAutomationWindowEventHandlerException : Exception
    {
        public RegisterAutomationWindowEventHandlerException(string message)
            : base(message)
        {

        }

        public RegisterAutomationWindowEventHandlerException(string messsage, Exception innerException)
            : base(messsage, innerException)
        {

        }
    }
}
