using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
  public  class UIAutomationApplicaitonException:Exception
  {
      public UIAutomationApplicaitonException()
      {
          
      }

      public UIAutomationApplicaitonException(string message):base(message)
      {
          
      }
  }
}
