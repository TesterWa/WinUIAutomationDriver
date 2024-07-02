using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver
{
    public static class UIAutomationUntil
    {



        /////
        ///
        /// 废弃
        /// <summary>
        /// 用于取标签与之匹配的上一个或下一个输入域
        /// </summary>
        /// <param name="currentLabel"></param>
        /// <returns></returns>
        public static UIAutomationElement GetCurrentLabelInput(this UIAutomationElement currentLabel)
        {
            if (currentLabel == null)
                return null;
            string currentLabelCurrentName = currentLabel.CurrentName;
            UIAutomationElement nextElement = currentLabel.GetNextElement();
            //当前元素的name值为空无法上下关联直接默认返回下一个
            if (string.IsNullOrEmpty(currentLabelCurrentName))
                return nextElement;
            if (!string.IsNullOrEmpty(nextElement.CurrentAutomationId) && nextElement != null && nextElement.CurrentAutomationId.Contains(currentLabelCurrentName))
                return nextElement;
            UIAutomationElement previousElement = currentLabel.GetPreviousElement();
            if (previousElement == null)
                return nextElement;
            //上个元素不是输入框就返回下一个
            if (previousElement.CurrentControlType != UIA_ControlTypeIds.UIA_EditControlTypeId && previousElement.CurrentControlType != UIA_ControlTypeIds.UIA_ComboBoxControlTypeId)
                return nextElement;
            //计算相似度
            if (!string.IsNullOrEmpty(previousElement.CurrentAutomationId) && Weight(currentLabelCurrentName, previousElement.CurrentAutomationId))
                return previousElement;
            return nextElement;
        }

        private static bool Weight(string orgcomp, string comple2)
        {
            int comple1Length = orgcomp.Length;
            int comple2Length = comple2.Length;
            IEnumerable<char> except = orgcomp.Intersect(comple2);
            string s = except.ToString();
            return comple1Length / 3 < except.Count();
        }
    }
}
