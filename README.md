# title

适用于.net的自动化类库
基于Interop.UIAutomationClient 封装而来

了解Interop.UIAutomationClient 请访问 nuget https://www.nuget.org/packages/Interop.UIAutomationClient。

目前没有对 CacheRequest 进行支持。

增加了 xpath的功能，由于本地构建元素树性能损耗极大，非特殊情况不建议使用。

支持以类似 WebDriver风格编程调用，如果你之前使用 appium\selenium 那么入门成本极低。

支持了UIAutomationElement的作用域链式调用。

极少的 Windows nativeApi支持。

暂不支持屏幕录制、截屏操作，对于 Windows 平台可以自行使用 ffmpeg 集成。

支持了类似 fromework中 UIAutomationElementCondition 的条件构建器。

不完整的 UIAutomationElement Control Type 支持，由于 Windows 平台控件的行为不唯一性，就没有进行封装

实验性功能：自动窗口管理，类似于 seleniium的 windowhandles

开始使用 

var options = new UIAutomationOptions();

var driver = new CUIAutomationDriver(options);

//实例化以后就要调用注册事件,管理窗口

RegisterAutomationWindowOpenedEventHandler();

RegisterAutomationWindowClosedEventHandler();

# api

//获取所有窗口

driver. GetWindowHandles();

//查找多个元素

List<UIAutomantionElement> eles = driver.FindElements();

//查找单个元素

UIAutomantionElement ele = driver.FindElement();

//在当前作用域中查找

ele.FindElements();

//获取当前元素结构快照

driver.GetPageSource();

//退出被测应用

driver.StopApp();

//全局通过条件器查找

driver.FindElementByCondition(condition);

//当前作用域通过条件器查找

ele.FindElementByCondition(condition);

//点击控件

ele.Click();

//双击控件

ele.DoubleClick();

//获取值

ele.GetValue();

//清空值

ele.Clear();

//输入值

ele.Send(value);

//选择值 （combobox）

ele.Select(value);

//获取可点击的点

ele.GetClickPoint();

//获取当前层级下一个元素

ele.GetNextElement();

//获取当前层级第一个元素

ele.GetFirstChildElement();

//获取父元素

ele.GetParentElement();

//获取当前层级上一个元素

ele.GetPreviousElement();

//获取当前层级最后一个元素

ele.GetLastElement();

//获取子元素

ele.GetChilds();

//通过索引获取子元素

ele.GetChildElementByIndex(index);



