using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.Enum1;
using WinUIAutomationDriver.Interface;

namespace WinUIAutomationDriver
{
    public class UIAutomationElement : IUIFindElementContext, IUIAutomationElement, IUIAutomationAutomationIdFind, IUIAutomationClassFind, IUIAutomationControlTypeFind, IUIAutomationLocalizedControlTypeFind, IUIAutomationNameFind, IUIAutomationConditionFind, IUIAutomationTreeScope
    {
        private CUIAutomationDriver _driver;
        private IUIAutomationElement _baseElement;
        public string Description = "UIAutomationElement";
        public UIAutomationElement(CUIAutomationDriver driver, IUIAutomationElement baseELement)
        {
            if (baseELement == null)
                throw new ArgumentNullException();
            this._driver = driver;
            this._baseElement = baseELement;
        }
        public UIAutomationElement FindElement(UIAutomationBy @by)
        {
            return by.FindElement(this);
        }

        public IList<UIAutomationElement> FindElements(UIAutomationBy @by)
        {
            return by.FindElements(this);
        }

        public void SetFocus()
        {
            this._baseElement.SetFocus();
        }

        public int[] GetRuntimeId()
        {
            return this._baseElement.GetRuntimeId();
        }

        public IUIAutomationElement FindFirst(TreeScope scope, IUIAutomationCondition condition)
        {
            return this._baseElement.FindFirst(scope, condition);
        }

        public IUIAutomationElementArray FindAll(TreeScope scope, IUIAutomationCondition condition)
        {
            return this._baseElement.FindAll(scope, condition);
        }

        public IUIAutomationElement FindFirstBuildCache(TreeScope scope, IUIAutomationCondition condition, IUIAutomationCacheRequest cacheRequest)
        {
            throw new NotImplementedException();
        }

        public IUIAutomationElementArray FindAllBuildCache(TreeScope scope, IUIAutomationCondition condition, IUIAutomationCacheRequest cacheRequest)
        {
            throw new NotImplementedException();
        }

        public IUIAutomationElement BuildUpdatedCache(IUIAutomationCacheRequest cacheRequest)
        {
            throw new NotImplementedException();
        }

        public object GetCurrentPropertyValue(int propertyId)
        {
            return this._baseElement.GetCurrentPropertyValue(propertyId);
        }

        public object GetCurrentPropertyValueEx(int propertyId, int ignoreDefaultValue)
        {
            return this._baseElement.GetCurrentPropertyValueEx(propertyId, ignoreDefaultValue);
        }

        public object GetCachedPropertyValue(int propertyId)
        {
            throw new NotImplementedException();
        }

        public object GetCachedPropertyValueEx(int propertyId, int ignoreDefaultValue)
        {
            throw new NotImplementedException();
        }

        public IntPtr GetCurrentPatternAs(int patternId, ref Guid riid)
        {
            return this._baseElement.GetCurrentPatternAs(patternId, riid);
        }

        public IntPtr GetCachedPatternAs(int patternId, ref Guid riid)
        {
            throw new NotImplementedException();
        }

        public object GetCurrentPattern(int patternId)
        {
            return this._baseElement.GetCurrentPattern(patternId);
        }

        public object GetCachedPattern(int patternId)
        {
            throw new NotImplementedException();
        }

        public IUIAutomationElement GetCachedParent()
        {
            throw new NotImplementedException();
        }

        public IUIAutomationElementArray GetCachedChildren()
        {
            throw new NotImplementedException();
        }

        public virtual void Click()
        {
           
            IUIAutomationInvokePattern uiAutomationInvokePattern = this.GetInvokePattern();
            uiAutomationInvokePattern.Invoke();
        }

        public virtual void DoubleClick()
        {
           
            IUIAutomationInvokePattern uiAutomationInvokePattern = this.GetInvokePattern();
            uiAutomationInvokePattern.Invoke();
            uiAutomationInvokePattern.Invoke();

        }

        public string GetValue()
        {
           
            IUIAutomationValuePattern uiAutomationValuePattern = GetValuePattern();
            string currentValue = uiAutomationValuePattern.CurrentValue;
            return currentValue;
        }

        public void Clear()
        {
            

            IUIAutomationValuePattern uiAutomationValuePattern = GetValuePattern();
            uiAutomationValuePattern.SetValue("");

        }

        public UIAutomationElement GetNextFieldElementFormPoint()
        {
            tagRECT currentBoundingRectangle = this.CurrentBoundingRectangle;
            int x = currentBoundingRectangle.right+20;
            int y = currentBoundingRectangle.top + (currentBoundingRectangle.bottom - currentBoundingRectangle.top) / 2;
            UIAutomationElement uiAutomationElement = this._driver.ElementFromPoint(new Point(x,y));
            return uiAutomationElement;
        }
        public void Send(string value)
        {
           
            IUIAutomationValuePattern uiAutomationValuePattern = GetValuePattern();
            this.SetFocus();
            uiAutomationValuePattern.SetValue(value);
        }

        public void Select(string value)
        {
            if (this.CurrentControlType != (int)UIAutomationElementControlType.ComboBox)
                throw new UIAutomationElementNotSupportPattern("不支持该类型的此操作！");
            /**
            IUIAutomationLegacyIAccessiblePattern uiAutomationLegacyIAccessiblePattern = this.CheckElementSupportPattren<IUIAutomationLegacyIAccessiblePattern>(UIA_PatternIds.UIA_LegacyIAccessiblePatternId);
            uiAutomationLegacyIAccessiblePattern.SetValue(value);
             * **/
            //            IUIAutomationExpandCollapsePattern uiAutomationExpandCollapsePattern = this.CheckElementSupportPattren<IUIAutomationExpandCollapsePattern>(UIA_PatternIds.UIA_ExpandCollapsePatternId);
            //            uiAutomationExpandCollapsePattern.Collapse();
            //            IUIAutomationSelectionItemPattern uiAutomationSelectionItemPattern = this.CheckElementSupportPattren<IUIAutomationSelectionItemPattern>(UIA_PatternIds.UIA_SelectionItemPatternId);
            UIAutomationElement selectList = this.FindElement(UIAutomationBy.ControlType(UIAutomationElementControlType.List));
            if (selectList == null)
                throw new UIAutomationElementNotFoundException("未找到可选择列表！");
            IList<UIAutomationElement> uiAutomationElements = selectList.FindElementsByControlType(UIAutomationElementControlType.ListItem);
            if (uiAutomationElements == null || !uiAutomationElements.Any())
                throw new UIAutomationElementNotFoundException("该列表下没有任何可操作的项！");
            bool selected = false;
            foreach (UIAutomationElement uiAutomationElement in uiAutomationElements)
            {
                if (uiAutomationElement.CurrentName.Equals(value))
                {
                    IUIAutomationSelectionItemPattern automationSelectionItemPattern = uiAutomationElement.CheckElementSupportPattren<IUIAutomationSelectionItemPattern>(UIAutomationElementPattern.SelectionItemPattern);
                    automationSelectionItemPattern.Select();
                    selected = true;
                    break;

                }
            }
            if (!selected)
                throw new UIAutomationComboboxElementNotSelectItemException("选择项失败；没有匹配到项！");
        }

        public IUIAutomationInvokePattern GetInvokePattern()
        {
            IUIAutomationInvokePattern uiAutomationInvokePattern = this.CheckElementSupportPattren<IUIAutomationInvokePattern>(UIAutomationElementPattern.InvokePattern);
            return uiAutomationInvokePattern;
        }

        public IUIAutomationValuePattern GetValuePattern()
        {
            IUIAutomationValuePattern uiAutomationValuePattern = this.CheckElementSupportPattren<IUIAutomationValuePattern>(UIAutomationElementPattern.ValuePattern);
            return uiAutomationValuePattern;
        }

        public T CheckElementSupportPattren<T>(UIAutomationElementPattern patternId) where T : class
        {
            _driver.ThrowIsApplicationExitException();
            T currentPattern = this._baseElement.GetCurrentPattern((int)patternId) as T;
            if (currentPattern == null)
                throw new UIAutomationElementNotSupportPattern("不支持的操作模式！");
            return currentPattern;
        }

        public Point GetClickPoint()
        {
            tagPOINT tagPoint = new tagPOINT();
            int clickablePoint = this.GetClickablePoint(out tagPoint);
            if (clickablePoint == 0)
                throw new UIAutomationClickableNotFoundException("未找到可点击的点！");
            return new Point() { X = tagPoint.x, Y = tagPoint.y };
        }

        public Point GetClickPoint2(ClickablePosition clickablePosition)
        {
            tagRECT boundingRectangle = this.CurrentBoundingRectangle;
            int width = boundingRectangle.right - boundingRectangle.left;
            int height = boundingRectangle.bottom - boundingRectangle.top;
            switch (clickablePosition)
            {
                case ClickablePosition.CENTER:
                    return new Point() { X = boundingRectangle.left + width / 2, Y = boundingRectangle.top + height / 2 };
                case ClickablePosition.LEFT_BOTTOM:
                    return new Point() { X = boundingRectangle.left, Y = boundingRectangle.bottom };
                case ClickablePosition.LEFT_TOP:
                    return new Point() { X = boundingRectangle.left, Y = boundingRectangle.top };
                case ClickablePosition.RIGHT_BOTTOM:
                    return new Point() { X = boundingRectangle.right, Y = boundingRectangle.bottom };
                case ClickablePosition.RIGHT_TOP:
                    return new Point() { X = boundingRectangle.right, Y = boundingRectangle.top };
                case ClickablePosition.LEFT_CENTER_TOP:
                    return new Point(){X = boundingRectangle.left+width/2,Y= boundingRectangle.top};
                case ClickablePosition.TOP_CENTER_LEFT:
                    return new Point() { X = boundingRectangle.left, Y = boundingRectangle.top + height / 2 };
            }

            return default(Point);
        }
        private UIAutomationElement GetNextElementInternal()
        {
            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this._driver, this._driver.RawTreeWalker.GetNextSiblingElement(this._baseElement));
        }

        public UIAutomationElement GetNextElement()
        {
            return GetNextElementInternal();
        }
        private UIAutomationElement GetFirstChildElementInternal()
        {
            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this._driver, this._driver.RawTreeWalker.GetFirstChildElement(this._baseElement));
        }
        public UIAutomationElement GetFirstChildElement()
        {
            return GetFirstChildElementInternal();
        }
        public UIAutomationElement GetParentElementInternal()
        {
            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this._driver, this._driver.RawTreeWalker.GetParentElement(this._baseElement));
        }

        public UIAutomationElement GetParentElement()
        {
            return GetParentElementInternal();
        }
        public UIAutomationElement GetPreviousElementInternal()
        {
            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this._driver, this._driver.RawTreeWalker.GetPreviousSiblingElement(this._baseElement));
        }

        public UIAutomationElement GetPreviousElement()
        {
            return GetPreviousElementInternal();
        }
        public UIAutomationElement GetNormalizeElementInternal()
        {

            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this._driver, this._driver.RawTreeWalker.NormalizeElement(this._baseElement));
        }
        public UIAutomationElement GetNormalizeElement()
        {

            return GetNormalizeElementInternal();
        }
        public UIAutomationElement GetLastElementInternal()
        {

            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this._driver, this._driver.RawTreeWalker.GetLastChildElement(this._baseElement));
        }
        public UIAutomationElement GetLastElement()
        {

            return GetLastElementInternal();
        }

        public UIAutomationElement GetChildByName(string name)
        {
            return this.FindElementChildByCondition(_driver.CreateCondition(UIAutomationElementProperty.Name, name));
        }
        public UIAutomationElement GetChildByAutomationId(string automationId)
        {
            return this.FindElementChildByCondition(_driver.CreateCondition(UIAutomationElementProperty.AutomationId, automationId));
        }
        public UIAutomationElement GetChildByControlType(UIAutomationElementControlType type)
        {
            return this.FindElementChildByCondition(_driver.CreateCondition(UIAutomationElementProperty.ControlType, type));
        }
        public IList<UIAutomationElement> GetChildsByControlType(UIAutomationElementControlType type)
        {
            return this.FindElementsChildByCondition(_driver.CreateCondition(UIAutomationElementProperty.ControlType, type));
        }
        public UIAutomationElement FindElementChildByCondition(IUIAutomationCondition condition)
        {
            return this.FindElementByCondition(TreeScope.TreeScope_Children, condition);
        }
        public IList<UIAutomationElement> FindElementsChildByCondition(IUIAutomationCondition condition)
        {
            return this.FindElementsByCondition(TreeScope.TreeScope_Children, condition);
        }
        public IList<UIAutomationElement> GetChilds()
        {
            IList<UIAutomationElement> eles = new List<UIAutomationElement>();
            UIAutomationElement first = this.GetFirstChildElement();
            eles.Add(first);
            while (first != null)
            {
                first = first.GetNextElement();
                if (first == null)
                    break;
                eles.Add(first);
            }

            return eles;
        }

        public UIAutomationElement GetChildElementByIndex(int index)
        {

            UIAutomationElement first = this.GetFirstChildElement();
            if (first == null)
                throw new UIAutomationElementNotFoundChildException();
            int idx = 0;
            while (first != null)
            {
                if (idx != index)
                {
                    first = first.GetNextElement();
                    idx++;
                    continue;
                }
                return first;
            }

            return null;
        }
        public int GetClickablePoint(out tagPOINT clickable)
        {

            int result = this._baseElement.GetClickablePoint(out clickable);
            return result;
        }

        public int CurrentProcessId
        {
            get
            {
                return this._baseElement.CurrentProcessId;
            }
        }

        public int CurrentControlType
        {
            get
            {
                return this._baseElement.CurrentControlType;
            }
        }
        public string CurrentLocalizedControlType
        {
            get
            {
                return this._baseElement.CurrentLocalizedControlType;
            }

        }

        public string CurrentName
        {
            get
            {
                return this._baseElement.CurrentName;
            }
        }

        public string CurrentAcceleratorKey
        {
            get
            {

                return this._baseElement.CurrentAcceleratorKey;

            }
        }

        public string CurrentAccessKey
        {
            get
            {
                return this._baseElement.CurrentAccessKey;
            }
        }

        public int CurrentHasKeyboardFocus
        {
            get
            {
                return this._baseElement.CurrentHasKeyboardFocus;
            }
        }

        public int CurrentIsKeyboardFocusable
        {
            get
            {
                return this._baseElement.CurrentIsKeyboardFocusable;
            }
        }

        public int CurrentIsEnabled
        {
            get
            {
                return this._baseElement.CurrentIsEnabled;
            }
        }

        public string CurrentAutomationId { get { return this._baseElement.CurrentAutomationId; } }
        public string CurrentClassName { get { return this._baseElement.CurrentClassName; } }
        public string CurrentHelpText { get { return this._baseElement.CurrentHelpText; } }
        public int CurrentCulture
        {
            get
            {
                return this._baseElement.CurrentCulture;
            }
        }
        public int CurrentIsControlElement { get { return this._baseElement.CurrentIsControlElement; } }
        public int CurrentIsContentElement { get { return this._baseElement.CurrentIsContentElement; } }
        public int CurrentIsPassword { get { return this._baseElement.CurrentIsPassword; } }
        public IntPtr CurrentNativeWindowHandle { get { return this._baseElement.CurrentNativeWindowHandle; } }

        public string CurrentItemType { get { return this._baseElement.CurrentItemType; } }
        public int CurrentIsOffscreen { get { return this._baseElement.CurrentIsOffscreen; } }
        public OrientationType CurrentOrientation { get { return this._baseElement.CurrentOrientation; } }
        public string CurrentFrameworkId { get { return this._baseElement.CurrentFrameworkId; } }
        public int CurrentIsRequiredForForm { get { return this._baseElement.CurrentIsRequiredForForm; } }
        public string CurrentItemStatus { get { return this._baseElement.CurrentItemStatus; } }
        public tagRECT CurrentBoundingRectangle { get { return this._baseElement.CurrentBoundingRectangle; } }
        public IUIAutomationElement CurrentLabeledBy { get { return this._baseElement.CurrentLabeledBy; } }
        public string CurrentAriaRole { get { return this._baseElement.CurrentAriaRole; } }
        public string CurrentAriaProperties { get { return this._baseElement.CurrentAriaProperties; } }
        public int CurrentIsDataValidForForm { get { return this._baseElement.CurrentIsDataValidForForm; } }
        public IUIAutomationElementArray CurrentControllerFor { get { return this._baseElement.CurrentControllerFor; } }
        public IUIAutomationElementArray CurrentDescribedBy { get { return this._baseElement.CurrentDescribedBy; } }
        public IUIAutomationElementArray CurrentFlowsTo { get { return this._baseElement.CurrentFlowsTo; } }
        public string CurrentProviderDescription { get { return this._baseElement.CurrentProviderDescription; } }
        public int CachedProcessId { get; private set; }
        public int CachedControlType { get; private set; }
        public string CachedLocalizedControlType { get; private set; }
        public string CachedName { get; private set; }
        public string CachedAcceleratorKey { get; private set; }
        public string CachedAccessKey { get; private set; }
        public int CachedHasKeyboardFocus { get; private set; }
        public int CachedIsKeyboardFocusable { get; private set; }
        public int CachedIsEnabled { get; private set; }
        public string CachedAutomationId { get; private set; }
        public string CachedClassName { get; private set; }
        public string CachedHelpText { get; private set; }
        public int CachedCulture { get; private set; }
        public int CachedIsControlElement { get; private set; }
        public int CachedIsContentElement { get; private set; }
        public int CachedIsPassword { get; private set; }
        public IntPtr CachedNativeWindowHandle { get; private set; }
        public string CachedItemType { get; private set; }
        public int CachedIsOffscreen { get; private set; }
        public OrientationType CachedOrientation { get; private set; }
        public string CachedFrameworkId { get; private set; }
        public int CachedIsRequiredForForm { get; private set; }
        public string CachedItemStatus { get; private set; }
        public tagRECT CachedBoundingRectangle { get; private set; }
        public IUIAutomationElement CachedLabeledBy { get; private set; }
        public string CachedAriaRole { get; private set; }
        public string CachedAriaProperties { get; private set; }
        public int CachedIsDataValidForForm { get; private set; }
        public IUIAutomationElementArray CachedControllerFor { get; private set; }
        public IUIAutomationElementArray CachedDescribedBy { get; private set; }
        public IUIAutomationElementArray CachedFlowsTo { get; private set; }
        public string CachedProviderDescription { get; private set; }
        public UIAutomationElement FindElementByAutomationId(string autoamtionId)
        {
            IUIAutomationCondition uiAutomationCondition = this._driver.CreateCondition(UIAutomationElementProperty.AutomationId, autoamtionId);

            return this.FindElementByCondition(uiAutomationCondition); ;
        }

        public UIAutomationElement FindElementByClass(string classNmae)
        {
            IUIAutomationCondition uiAutomationCondition = this._driver.CreateCondition(UIAutomationElementProperty.ClassName, classNmae);

            return this.FindElementByCondition(uiAutomationCondition); ;
        }

        public IList<UIAutomationElement> FindElementsByClass(string classNmae)
        {
            IUIAutomationCondition uiAutomationCondition = this._driver.CreateCondition(UIAutomationElementProperty.ClassName, classNmae);

            return this.FindElementsByCondition(uiAutomationCondition); ;
        }

        public UIAutomationElement FindElementByControlType(UIAutomationElementControlType controlId)
        {
            IUIAutomationCondition uiAutomationCondition = this._driver.CreateCondition(UIAutomationElementProperty.ControlType, controlId);
            return this.FindElementByCondition(uiAutomationCondition); ;
        }

        public IList<UIAutomationElement> FindElementsByControlType(UIAutomationElementControlType controlId)
        {
            IUIAutomationCondition uiAutomationCondition = this._driver.CreateCondition(UIAutomationElementProperty.ControlType, controlId);

            return this.FindElementsByCondition(uiAutomationCondition); ;
        }

        public UIAutomationElement FindElementByLocalizedControlType(string localizedControlType)
        {
            IUIAutomationCondition uiAutomationCondition = this._driver.CreateCondition(UIAutomationElementProperty.LocalizedControlType, localizedControlType);
            return this.FindElementByCondition(uiAutomationCondition); ;
        }

        public IList<UIAutomationElement> FindElementsByLocalizedControlType(string localizedControlType)
        {
            IUIAutomationCondition uiAutomationCondition = this._driver.CreateCondition(UIAutomationElementProperty.LocalizedControlType, localizedControlType);

            return this.FindElementsByCondition(uiAutomationCondition); ;
        }

        public UIAutomationElement FindElementByName(string name)
        {
            IUIAutomationCondition uiAutomationCondition = this._driver.CreateCondition(UIAutomationElementProperty.Name, name);
            IUIAutomationElement uiAutomationElement = this.FindFirst(this.GetScoped(), uiAutomationCondition);
            return this.FindElementByCondition(uiAutomationCondition);
        }

        public IList<UIAutomationElement> FindElementsByName(string name)
        {
            IUIAutomationCondition uiAutomationCondition = this._driver.CreateCondition(UIAutomationElementProperty.Name, name);

            return this.FindElementsByCondition(uiAutomationCondition);
        }

        public void SetScoped(TreeScope scope)
        {
            this._driver.SetScoped(scope);
        }

        public TreeScope GetScoped()
        {
            return this._driver.GetScoped();
        }
        public UIAutomationElement FindElementByCondition(IUIAutomationCondition condition)
        {
            return FindElementByCondition(this.GetScoped(), condition);
        }
        public UIAutomationElement FindElementByCondition(TreeScope scope, IUIAutomationCondition condition)
        {
            _driver.ThrowIsApplicationExitException();
            IUIAutomationElement uiAutomationElement = this.FindFirst(scope, condition);
            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this._driver, uiAutomationElement);
        }
        public UIAutomationElement FindElementByCondition(IUIAutomationConditionBuilder condition)
        {
            return FindElementByCondition(this.GetScoped(), condition);
        }
        public UIAutomationElement FindElementByCondition(TreeScope scope, IUIAutomationConditionBuilder condition)
        {

            return FindElementByCondition(scope, condition.Build(this._driver));
        }
        public IList<UIAutomationElement> FindElementsByCondition(TreeScope scope, IUIAutomationConditionBuilder condition)
        {

            return FindElementsByCondition(scope, condition.Build(this._driver));

        }

        public IList<UIAutomationElement> FindElementsByCondition(TreeScope scope, IUIAutomationCondition condition)
        {
            _driver.ThrowIsApplicationExitException();
            IUIAutomationElementArray uiAutomationElementArray = this.FindAll(scope, condition);
            IList<UIAutomationElement> elements = new List<UIAutomationElement>();
            for (int i = 0; i < uiAutomationElementArray.Length; i++)
            {
                elements.Add(Convert2UIAutomationElement.ConvertCOM2LocalElement(_driver, uiAutomationElementArray.GetElement(i)));
            }
            return elements;

        }
        public IList<UIAutomationElement> FindElementsByCondition(IUIAutomationCondition condition)
        {
            IList<UIAutomationElement> uiAutomationElementArray = FindElementsByCondition(this.GetScoped(), condition);

            return uiAutomationElementArray;

        }
        public IList<UIAutomationElement> FindElementsByCondition(IUIAutomationConditionBuilder condition)
        {
            IList<UIAutomationElement> uiAutomationElementArray = FindElementsByCondition(this.GetScoped(), condition);

            return uiAutomationElementArray;

        }

        public static bool operator ==(UIAutomationElement one, UIAutomationElement two)
        {
            if ((object)one == (object)two)
                return true;
            if ((object)one == null || (object)two == null)
                return false;
            return one.Equals((object)two);
        }

        public static bool operator !=(UIAutomationElement one, UIAutomationElement two)
        {
            return !(one == two);
        }

        public override bool Equals(object obj)
        {
            if (obj is UIAutomationElement)
            {
                return this._driver.CompareElements(this._baseElement, (obj as UIAutomationElement)._baseElement);

            }

            return false;
        }
    }
}
