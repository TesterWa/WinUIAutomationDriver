using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
   public class UIAutomationClickableNotFoundException:Exception
    {
        public UIAutomationClickableNotFoundException()
        {
            
        }
        public UIAutomationClickableNotFoundException(string message) : base(message = message) { }
    }
}
