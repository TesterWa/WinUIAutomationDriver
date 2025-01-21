using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;

namespace WinUIAutomationDriver
{
    public class UIAutomationDocumentContext
    {
        private XDocument document;
        private CUIAutomationDriver _driver;
        private UIAutomationElementTreeLocalcache localcache;
        public UIAutomationDocumentContext(CUIAutomationDriver driver)
        {
            this._driver = driver;
            this.document = new XDocument();
            this.localcache = new UIAutomationElementTreeLocalcache();
        }

        public void Flush()
        {
            this.document.RemoveNodes();//清空树结构
            this.localcache.Clear();//清空缓存
        }
        public string DumpCurrentWindowXml()
        {
            if (this._driver.Root == null)
                throw new UIAutomationElementNotFoundException("生成dump失败，根节点为空！");
            XElement rootElement = CopyUIAutomationAttribute(this._driver.Root);
            this.localcache.Add(this._driver.Root);
            RecurTreeview(this._driver.Root, rootElement);
            this.document.Add(rootElement);
            return this.document.ToString();
        }
        private void RecurTreeview(UIAutomationElement parentNode, XElement parentElement)
        {
            if (parentElement == null)
                return;
            IList<UIAutomationElement> uiAutomationElements = parentNode.GetChilds();
            foreach (UIAutomationElement child in uiAutomationElements)
            {
                if (child != null)
                {
                    this.localcache.Add(child);
                    XElement element = CopyUIAutomationAttribute(child);
                    parentElement.Add(element);
                    RecurTreeview(child, element);
                }
            }
        }

        private XElement CopyUIAutomationAttribute(UIAutomationElement element)
        {
            XAttribute xname = new XAttribute("Name", string.IsNullOrEmpty(element.CurrentName) ? "" : element.CurrentName);
            XAttribute xclass = new XAttribute("Class", element.CurrentClassName);
            XAttribute xautomaitonid = new XAttribute("AutomaitonId", element.CurrentAutomationId);
            XAttribute xframeworkid = new XAttribute("FrameworkId", element.CurrentFrameworkId);
            XAttribute xhelpText = new XAttribute("HelpText", string.IsNullOrEmpty(element.CurrentHelpText) ? "" : element.CurrentHelpText);
            XAttribute xkeyboardfocusable = new XAttribute("KeyboardFocusable", element.CurrentIsKeyboardFocusable == 0);
            XAttribute xhandleid = new XAttribute("HandleId", element.CurrentNativeWindowHandle);
            XAttribute xparocessid = new XAttribute("ProcessId", element.CurrentProcessId);
            XAttribute xenable = new XAttribute("Enable", element.CurrentIsEnabled == 0);
            XAttribute xdisplay = new XAttribute("Display", element.CurrentIsOffscreen == 0);
            tagRECT rectangle = element.CurrentBoundingRectangle;
            XAttribute xleft = new XAttribute("Left", rectangle.left);
            XAttribute xright = new XAttribute("Right", rectangle.right);
            XAttribute xtop = new XAttribute("Top", rectangle.top);
            XAttribute xbottom = new XAttribute("Bottom", rectangle.bottom);
            XAttribute xid = new XAttribute("Id", element.Id);
            //XAttribute xbounds = new XAttribute("bounds", element.CurrentBoundingRectangle);
            object[] attributes = new object[] { xname, xclass, xid, xautomaitonid, xframeworkid, xhelpText, xkeyboardfocusable, xhandleid, xparocessid, xenable, xdisplay, xleft, xright, xtop, xbottom };
            XElement xElement = new XElement(GetControlTypeString(element.CurrentControlType), attributes);
            return xElement;

        }
        /// <summary>
        /// 获取当前元素类型的字符串表示形式
        /// </summary>
        /// <param name="controlType"></param>
        /// <returns></returns>
        private string GetControlTypeString(int controlType)
        {
            UIAutomationElementControlType uiaControlType;
            if (Enum.TryParse(controlType.ToString(), out uiaControlType))
            {
                return uiaControlType.ToString();
            }

            return UIAutomationElementControlType.Custom.ToString();
        }
        public UIAutomationElement QuerySelectElementByXpath(string xpath, string currGuid = "")
        {
            if (string.IsNullOrEmpty(xpath))
                return null;
            this.Flush();
            this.DumpCurrentWindowXml();
            XElement xElement = null;
            if (string.IsNullOrEmpty(currGuid))
            {
                xElement = this.document.XPathSelectElement(xpath);
            }
            else
            {
                XElement currentNode = this.document.XPathSelectElement(string.Format("//*[@Id='{0}']", currGuid));
                xElement = currentNode.XPathSelectElement(xpath);
            }
            if (xElement == null)
                throw new UIAutomationElementNotFoundException();
            XAttribute xAttribute = xElement.Attribute("Id");
            if (xAttribute == null)
                throw new NullReferenceException("获取引用Id异常！");
            string id = xAttribute.Value;
            UIAutomationElement uiAutomationElement = this.localcache.GetLocalcache(id);
            if (uiAutomationElement == null)
                throw new UIAutomationElementNotFoundException("页面已刷新，从缓存中取元素失败！");
            return uiAutomationElement;
        }
        public IList<UIAutomationElement> QuerySelectElemenstByXpath(string xpath, string currGuid = "")
        {
            if (string.IsNullOrEmpty(xpath))
                return null;
            this.Flush();
            this.DumpCurrentWindowXml();
            IList<UIAutomationElement> elements = new List<UIAutomationElement>();
            if (string.IsNullOrEmpty(currGuid))
            {
                IEnumerable<XElement> xElements = this.document.XPathSelectElements(xpath);
                IEnumerator<XElement> enumerator = xElements.GetEnumerator();
                XElement context = null;


                do
                {
                    var current = enumerator.Current;
                    XAttribute attribute = current.Attribute("Id");
                    if (attribute == null)
                        continue;
                    string id = attribute.Value;
                    UIAutomationElement element = this.localcache.GetLocalcache(id);
                    if (element != null)
                        elements.Add(element);
                } while (enumerator.MoveNext());
                return elements;
            }
            else
            {

                XElement currentNode = this.document.XPathSelectElement(string.Format("//*[@Id='{0}']", currGuid));
                IEnumerable<XElement> xElements = currentNode.XPathSelectElements(xpath);
                IEnumerator<XElement> enumerator = xElements.GetEnumerator();
                do
                {
                    var current = enumerator.Current;
                    XAttribute attribute = current.Attribute("Id");
                    if (attribute == null)
                        continue;
                    string id = attribute.Value;
                    UIAutomationElement element = this.localcache.GetLocalcache(id);
                    if (element != null)
                        elements.Add(element);
                } while (enumerator.MoveNext());
                return elements;

            }
        }
    }
}
