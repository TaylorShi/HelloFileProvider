## 什么是文件提供程序

ASP.NET Core通过文件提供程序来抽象化文件系统访问。在ASP.NET Core框架中使用文件提供程序。例如：

- `IWebHostEnvironment`将应用的内容根目录和Web根目录作为`IFileProvider`类型公开。
- 静态文件中间件使用文件提供程序来查找静态文件。
- Razor使用文件提供程序来查找页面和视图。
- .NET Core工具使用文件提供程序和glob模式来指定应该发布哪些文件。

## 相关文章

* [乘风破浪，遇见最佳跨平台跨终端框架.Net Core/.Net生态 - 浅析ASP.NET Core文件提供程序，让你可以将文件存放在任何地方](https://www.cnblogs.com/taylorshi/p/16786705.html)