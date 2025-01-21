适用于.net的自动化类库
基于Interop.UIAutomationClient 封装而来，了解Interop.UIAutomationClient 请访问 nuget https://www.nuget.org/packages/Interop.UIAutomationClient。
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
