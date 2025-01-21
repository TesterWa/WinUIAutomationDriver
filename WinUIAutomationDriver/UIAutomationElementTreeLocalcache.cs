using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinUIAutomationDriver
{
    public class UIAutomationElementTreeLocalcache
    {
        public UIAutomationElementTreeLocalcache()
        {
            localcache = new List<UIAutomationElement>();
        }

        private IList<UIAutomationElement> localcache;


        public IList<UIAutomationElement> GetLocalcaches()
        {
            return this.localcache;

        }

        public UIAutomationElement GetLocalcache(string guid)
        {
            try
            {
                return this.localcache.FirstOrDefault(s => s.Id.Equals(guid));
            }
            catch
            {

            }

            return null;
        }

        public void Clear()
        {
            this.localcache.Clear();
        }

        public void Add(UIAutomationElement element)
        {
            this.localcache.Add(element);
        }

       
        
    }
}
