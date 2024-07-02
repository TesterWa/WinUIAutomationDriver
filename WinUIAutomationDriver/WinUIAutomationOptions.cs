using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIAutomationDriver
{
   public class WinUIAutomationOptions
    {
        public string ApplicaitonPath { get; set; }
        public bool IsStartApplication { get; set; }
        public IntPtr ApplicaitonHandler { get; set; }

        public WinUIAutomationOptions()
        {
            
        }
    }
}
