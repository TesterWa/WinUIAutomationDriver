using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Interface;

namespace WinUIAutomationDriver
{
   public class TreeScopedContext:IUIAutomationTreeScope
   {
       private TreeScope scope = TreeScope.TreeScope_Descendants;
       /// <summary>
       /// 设置查找元素的作用域
       /// 多线程环境可能会出现作用域错乱的问题
       /// </summary>
       /// <param name="scope"></param>
        public void SetScoped(TreeScope scope)
        {
            this.scope = scope;
        }

        public TreeScope GetScoped()
        {
            return this.scope;
        }
    }
}
