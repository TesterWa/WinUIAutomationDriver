using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Interop.UIAutomationClient;
using WinUIAutomationDriver.condition;
using WinUIAutomationDriver.Enum1;
using WinUIAutomationDriver.Event;
using WinUIAutomationDriver.Interface;
using TreeScope = Interop.UIAutomationClient.TreeScope;

namespace WinUIAutomationDriver
{
    public class CUIAutomationDriver : IUIFindElementContext, IUIAutomationAutomationIdFind, IUIAutomationClassFind, IUIAutomationControlTypeFind, IUIAutomationLocalizedControlTypeFind, IUIAutomationNameFind, IUIAutomationConditionFind, IUIAutomationTreeScope, IUIAutomationAutomationXpathFind
    {
        private IntPtr _proIntPtr;
        private IUIAutomation _client;
        private UIAutomationElement _root;
        private string _appPath;
        private Process _appProc;
        private bool isStartApp;
        private TreeScope scope = TreeScope.TreeScope_Descendants;
        private TreeScopedContext treeScopedContext;
        private Func<IUIAutomationCondition, object> searcher;
        private IList<UIAutomationElement> handles;
        private readonly object lockobj = new object();
        private UIAutomationElement currentHandle;
        private XDocument currentdom;
        private UIAutomationDocumentContext documentContext;
        private const string dialogClass = "#32770";
        //private IList<UIAutomationElement> localcacheUiautomationElements = new List<UIAutomationElement>();
        public UIAutomationElement CurrentHandle
        {
            get
            {
                if (currentHandle == null)
                    return this.Root;
                return currentHandle;
            }
            set
            {
                currentHandle = value;
            }
        }
        public IUIAutomationTreeWalker RawTreeWalker
        {
            get
            {
                return this._client.RawViewWalker;
            }
        }

        public IUIAutomationTreeWalker ContenTreeWalker
        {
            get
            {
                return this._client.ContentViewWalker;
            }
        }

        public IUIAutomationTreeWalker ControlTreeWalker
        {
            get
            {
                return this._client.ControlViewWalker;
            }
        }

        public IntPtr ProIntPtr
        {
            get
            {
                return _proIntPtr;
            }
            set
            {
                _proIntPtr = value;
            }
        }

        public UIAutomationElement Root
        {
            get
            {
                return _root;

            }
            set
            {
                _root = value;
            }
        }

        /// <summary>
        /// test application appPath cotr
        /// </summary>
        /// <param name="appPath"></param>
        public CUIAutomationDriver(WinUIAutomationOptions options)
        {
            bool optionsIsStartApplication = options.IsStartApplication;
            string appPath = options.ApplicaitonPath;
            IntPtr appIntPtr = options.ApplicaitonHandler;
            _client = new CUIAutomation8Class();
            if (optionsIsStartApplication)
            {
                if (!File.Exists(appPath))
                    throw new FileNotFoundException();
                this._appPath = appPath;
                StartApp();
                if (this._appProc == null)
                    throw new Exception("启动被测Application异常");
                appIntPtr = this._appProc.MainWindowHandle;
            }

            this._proIntPtr = appIntPtr;
            UIAutomationElement root = this.ElementFromHandle(appIntPtr);
            this.treeScopedContext = new TreeScopedContext();
            _root = root;
            this.handles = new List<UIAutomationElement>() { root };
            this.documentContext = new UIAutomationDocumentContext(this);

        }
        /// <summary>
        /// 注册window的关闭监听事件
        /// </summary>
        /// <param name="window">当前window</param>
        public void RegisterAutomationWindowClosedEventHandler(UIAutomationElement window)
        {
            try
            {
                this.RegisterAutomationEventHandler(window, UIAutomationElementEvent.WindowClosed, TreeScope.TreeScope_Element);
            }
            catch (Exception e)
            {
                throw new RegisterAutomationWindowClosedEventHandlerException("register window closed event handler error", e);
            }

        }

        /// <summary>
        /// 注册window的窗口打开事件，窗口打开完毕后应该立即给窗口注册关闭事件
        /// </summary>
        /// <param name="window">window可以是当前window下的treeScope作用域范围内的window</param>
        public void RegisterAutomationWindowOpenedEventHandler(UIAutomationElement window)
        {
            try
            {
                this.RegisterAutomationEventHandler(window, UIAutomationElementEvent.WindowOpened);
            }
            catch (Exception ex)
            {
                throw new RegisterAutomationWindowOpendEventHandlerException("register window opened event handler error", ex);
            }
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="element">目标控件</param>
        /// <param name="e">事件枚举 类型 UIAutomationElementEvent</param>
        /// <param name="scope">注册事件的作用域</param>
        public void RegisterAutomationEventHandler(UIAutomationElement element, UIAutomationElementEvent e, TreeScope scope = TreeScope.TreeScope_Descendants)
        {
            RegisterAutomationEventHandlerInternal(element, scope, e);
        }

        private void RegisterAutomationEventHandlerInternal(UIAutomationElement element, TreeScope scope, UIAutomationElementEvent e)
        {
            if (element == null)
                throw new UIAutomationElementException("注册事件对象不能为空！");
            IUIAutomationElement baseComElement = element.GetBaseCOMElement();
            UIAutomationEventHandler uiAutomationEventHandler = new UIAutomationEventHandler();
            uiAutomationEventHandler.UIAutomaitonEventHander += UIAutomaitonEventHander;
            this._client.AddAutomationEventHandler((int)e, baseComElement, scope, null, uiAutomationEventHandler);
        }
        private void UIAutomaitonEventHander(object sender, UIAutomationEventArgs args)
        {

            UIAutomationElementEvent uiAutomationElementEvent = args.Event;
            UIAutomationElement window = Convert2UIAutomationElement.ConvertCOM2LocalElement(this, args.Element);
            if (uiAutomationElementEvent == UIAutomationElementEvent.WindowOpened)
            {
                this.AddWindowHandle(window);
                this.Root = window;
                this.currentHandle = window;
                //给新的window窗口绑定关闭事件
                this.RegisterAutomationWindowClosedEventHandler(window);
            }
            else if (uiAutomationElementEvent == UIAutomationElementEvent.WindowClosed)
            {
                this.RemoveWindowHandle(window);
                UIAutomationElement lastWindow = this.handles.LastOrDefault();
                this.Root = lastWindow;
                this.currentHandle = lastWindow;
            }
        }
        public IUIAutomationCondition CreateCondition(UIAutomationElementProperty automationPropertyId, object value)
        {
            IUIAutomationCondition uiAutomationCondition = this._client.CreatePropertyCondition((int)automationPropertyId, value);
            return uiAutomationCondition;
        }

        public IUIAutomationCondition CreateAndCondition(IUIAutomationCondition[] conditions)
        {
            return this._client.CreateAndConditionFromArray(conditions);
        }

        public IUIAutomationCondition CreateOrCondition(IUIAutomationCondition[] conditions)
        {
            return this._client.CreateOrConditionFromArray(conditions);
        }

        public UIAutomationElement GetDesktopInElement(string name)
        {
            IUIAutomationElement uiAutomationElement = this._client.GetRootElement();
            var automationCondition = this.CreateCondition(UIAutomationElementProperty.AutomationId, string.IsNullOrEmpty(name) ? "frmMain" : name);
            UIAutomationElement com2LocalElement = Convert2UIAutomationElement.ConvertCOM2LocalElement(this, uiAutomationElement.FindFirst(TreeScope.TreeScope_Children, automationCondition));
            this._root = com2LocalElement;
            return com2LocalElement;
        }


        public UIAutomationElement FindAlert(string alertTitle, string alertContent, bool isFuzzMatchContent, bool isInnerApplication)
        {
            return this.FindAlertInternal(alertTitle, alertContent, isFuzzMatchContent, isInnerApplication);

        }

        public UIAutomationElement GetDesktopElement()
        {
            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this, this._client.GetRootElement());
        }

        private UIAutomationElement FindAlertInternal(string alertTitle, string alertContent, bool isFuzzMatchContent, bool isInnerApplication)
        {
            UIAutomationElement domain = (UIAutomationElement) (isInnerApplication ? GetDesktopInElement(null) : GetDesktopElement());
                UIAutoamtionAndConditionBuilder builder = new UIAutoamtionAndConditionBuilder();
                builder.AddAndCondition(UIAutomationElementProperty.ControlType, UIAutomationElementControlType.Window).AddAndCondition(UIAutomationElementProperty.ClassName, dialogClass);
                if (!string.IsNullOrEmpty(alertTitle))
                {
                    builder.AddAndCondition(UIAutomationElementProperty.Name, alertTitle);
                }

                IList<UIAutomationElement> uiAutomationElements = domain.FindElementsByCondition(isInnerApplication ? TreeScope.TreeScope_Descendants : TreeScope.TreeScope_Children, builder.Build(this));
                if (uiAutomationElements == null || !uiAutomationElements.Any())
                    return default(UIAutomationElement);
                if (string.IsNullOrEmpty(alertContent))
                    return uiAutomationElements.FirstOrDefault();
                foreach (UIAutomationElement dialog in uiAutomationElements)
                {
                    //                IUIAutomationElement textElement = dialog.FindElement(UIAutomationBy.Name(alertContent));
                    //                if (textElement == null)
                    //                    continue;
                    //                var check_result = isFuzzMatchContent ? textElement.CurrentName.Contains(alertContent) : textElement.CurrentName.Equals(alertContent);
                    //                if (check_result)
                    IList<UIAutomationElement> elementsByControlType = dialog.FindElementsByControlType(UIAutomationElementControlType.Text);
                    foreach (UIAutomationElement label in elementsByControlType)
                    {
                        var check_result = isFuzzMatchContent ? label.CurrentName.Contains(alertContent) : label.CurrentName.Equals(alertContent);
                        if (check_result)
                            return dialog;
                    }

                }
           

            return default(UIAutomationElement);
        }


        private void StartApp()
        {

            ProcessStartInfo psi = new ProcessStartInfo(this._appPath);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.RedirectStandardError = false;
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = false;
            psi.WorkingDirectory = Directory.GetCurrentDirectory();
            this._appProc = Process.Start(psi);
            this._appProc.Exited += _appProc_Exited;
            this._appProc.EnableRaisingEvents = true;
            Thread.Sleep(2000);
            this.isStartApp = true;
            WaitForProcessExit();//监听应用程序是否被手动关闭了
        }

        private void _appProc_Exited(object sender, EventArgs e)
        {
            this._appProc = null;
            this.isStartApp = false;

        }

        internal void ThrowIsApplicationExitException()
        {
            if (!this.isStartApp)
                throw new UIAutomationApplicaitonException("应用程序退出或进程被终止！");
        }
        private void WaitForProcessExit()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (WaitForPorcessExit())
                    {
                        this.isStartApp = false;
                        ThrowIsApplicationExitException();
                    }
                    Thread.Sleep(1000);
                }

            });
        }

        private bool WaitForPorcessExit()
        {
            Process appProc = this._appProc;
            //            IntPtr appProcHandle = appProc.Handle;
            int appProcId = appProc.Id;
            Process process = Process.GetProcesses().FirstOrDefault(s=>s.Id.Equals(appProcId));
            bool appProcHasExited = appProc.HasExited;
            return appProcHasExited || process == null;
        }
        public void StopApp()
        {
            if (isStartApp && this._appProc != null)
            {
                try
                {
                    this.ClearWindowHandles();
                    this._appProc.Kill();
                    this._appProc = null;
                    this.isStartApp = false;
                }
                catch (Exception e)
                {
                }

            }
        }

        ~CUIAutomationDriver()
        {
            StopApp();
        }

        public UIAutomationElement FindElementByAutomationId(string autoamtionId)
        {
            IUIAutomationCondition uiAutomationCondition = this.CreateCondition(UIAutomationElementProperty.AutomationId, autoamtionId);
            return FindElementByCondition(uiAutomationCondition);
        }

        public UIAutomationElement FindElement(UIAutomationBy @by)
        {
            return by.FindElement((this as IUIFindElementContext));
        }

        public IList<UIAutomationElement> FindElements(UIAutomationBy @by)
        {
            return by.FindElements((this as IUIFindElementContext));
        }

        public UIAutomationElement FindElementByClass(string classNmae)
        {
            IUIAutomationCondition uiAutomationCondition = this.CreateCondition(UIAutomationElementProperty.ClassName, classNmae);
            return this.FindElementByCondition(uiAutomationCondition);
        }

        public IList<UIAutomationElement> FindElementsByClass(string classNmae)
        {
            IUIAutomationCondition uiAutomationCondition = this.CreateCondition(UIAutomationElementProperty.ClassName, classNmae);

            return this.FindElementsByCondition(uiAutomationCondition);
        }

        public UIAutomationElement FindElementByControlType(UIAutomationElementControlType controlId)
        {
            IUIAutomationCondition uiAutomationCondition = this.CreateCondition(UIAutomationElementProperty.ControlType, controlId);
            return this.FindElementByCondition(uiAutomationCondition);
        }

        public IList<UIAutomationElement> FindElementsByControlType(UIAutomationElementControlType controlId)
        {
            IUIAutomationCondition uiAutomationCondition = this.CreateCondition(UIAutomationElementProperty.ControlType, controlId);

            return this.FindElementsByCondition(uiAutomationCondition); ;
        }

        public UIAutomationElement FindElementByLocalizedControlType(string localizedControlType)
        {
            IUIAutomationCondition uiAutomationCondition = this.CreateCondition(UIAutomationElementProperty.LocalizedControlType, localizedControlType);
            return this.FindElementByCondition(uiAutomationCondition);
        }

        public IList<UIAutomationElement> FindElementsByLocalizedControlType(string localizedControlType)
        {
            IUIAutomationCondition uiAutomationCondition = this.CreateCondition(UIAutomationElementProperty.LocalizedControlType, localizedControlType);

            return this.FindElementsByCondition(uiAutomationCondition);
        }

        public UIAutomationElement FindElementByName(string name)
        {
            IUIAutomationCondition uiAutomationCondition = this.CreateCondition(UIAutomationElementProperty.Name, name);
            return this.FindElementByCondition(uiAutomationCondition);
        }

        public IList<UIAutomationElement> FindElementsByName(string name)
        {
            IUIAutomationCondition uiAutomationCondition = this.CreateCondition(UIAutomationElementProperty.Name, name);

            return this.FindElementsByCondition(uiAutomationCondition); ;
        }

        public UIAutomationElement ElementFromPoint(Point point)
        {
            tagPOINT tagPoint = new tagPOINT()
            {
                x = (int)point.X,
                y = (int)point.Y
            };
            IUIAutomationElement uiAutomationElement = this._client.ElementFromPoint(tagPoint);
            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this, uiAutomationElement);
        }

        public UIAutomationElement ElementFromHandle(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new Exception("句柄不能为空！");
            IUIAutomationElement uiAutomationElement = this._client.ElementFromHandle(handle);
            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this, uiAutomationElement);
        }

        //        public UIAutomationElement __()
        //        {
        //
        //            this._client.ElementFromIAccessible()
        //        }

        public void SetScoped(TreeScope scope)
        {
            this.treeScopedContext.SetScoped(scope);
        }

        public TreeScope GetScoped()
        {
            return this.treeScopedContext.GetScoped();
        }

        public UIAutomationElement FindElementByCondition(IUIAutomationCondition condition)
        {
            this.ThrowIsApplicationExitException();
            IUIAutomationElement uiAutomationElement = (this.Root as UIAutomationElement).FindFirst(this.scope, condition);
            return Convert2UIAutomationElement.ConvertCOM2LocalElement(this, uiAutomationElement);
        }


        public UIAutomationElement FindElementByCondition(IUIAutomationConditionBuilder condition)
        {

            return FindElementByCondition(condition.Build(this));
        }
        public IList<UIAutomationElement> FindElementsByCondition(IUIAutomationConditionBuilder condition)
        {

            return FindElementsByCondition(condition.Build(this));
        }
        public IList<UIAutomationElement> FindElementsByCondition(IUIAutomationCondition condition)
        {
            this.ThrowIsApplicationExitException();
            IUIAutomationElementArray uiAutomationElement = (this.Root as UIAutomationElement).FindAll(this.scope, condition);
            IList<UIAutomationElement> elements = new List<UIAutomationElement>();
            for (int i = 0; i < uiAutomationElement.Length; i++)
            {
                elements.Add(Convert2UIAutomationElement.ConvertCOM2LocalElement(this, uiAutomationElement.GetElement(i)));
            }
            return elements;
        }

        public bool CompareElements(IUIAutomationElement element1, IUIAutomationElement element2)
        {
            return this._client.CompareElements(element1, element2) == 1;
        }
        /// <summary>
        /// 轮询方法
        /// </summary>
        /// <param name="func">委托</param>
        /// <param name="timeout">轮询时长，秒</param>
        /// <returns></returns>
        public static bool WaitUtil(Func<bool> func, int timeout = 30)
        {


            DateTime dateTime = DateTime.Now.AddSeconds(timeout);
            while ((DateTime.Now - dateTime).Seconds <= 0)
            {
                try
                {
                    if (func())
                        return true;
                }
                catch (ThreadAbortException exception)
                {
                    throw exception;
                }
                catch (UIAutomationApplicaitonException exception2)
                {
                    throw exception2;
                }
                catch (Exception exception1)
                {

                }
                Thread.Sleep(1000);
            }

            return false;
        }
        /// <summary>
        /// 获取应用内所有的window窗口
        /// </summary>
        /// <returns></returns>
        public IList<UIAutomationElement> GetWindowHandles()
        {
            return this.handles;
        }

        private void AddWindowHandle(UIAutomationElement window)
        {
            lock (lockobj)
            {
                this.handles.Add(window);
            }
        }

        private void RemoveWindowHandle(UIAutomationElement window)
        {
            lock (lockobj)
            {
                this.handles.Remove(window);
            }
        }
        private void ClearWindowHandles()
        {
            lock (lockobj)
            {

                this.handles.Clear();
            }
        }

        internal UIAutomationDocumentContext GetAutomationDocumentContext()
        {
            return this.documentContext;
        }
        public UIAutomationElement FindElementByXpath(string xpath)
        {
            return this.documentContext.QuerySelectElementByXpath(xpath);
        }

        public IList<UIAutomationElement> FindElementsByXpath(string xpath)
        {
            return this.documentContext.QuerySelectElemenstByXpath(xpath);
        }

        public string GetPageSource()
        {
            return this.documentContext.DumpCurrentWindowXml();
        }
    }
}
