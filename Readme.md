<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128606913/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2753)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/DXRichEdit_HoverMenu/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DXRichEdit_HoverMenu/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DXRichEdit_HoverMenu/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXRichEdit_HoverMenu/MainWindow.xaml.vb))
* [MySmileyCommand.cs](./CS/DXRichEdit_HoverMenu/MySmileyCommand.cs) (VB: [MySmileyCommand.vb](./VB/DXRichEdit_HoverMenu/MySmileyCommand.vb))
<!-- default file list end -->
# DXRichEdit for WPF: How to customize the hover menu


<p>This example demonstrates the following techniques:</p><p>1) Handling the <a href="http://documentation.devexpress.com/#WPF/DevExpressXpfRichEditRichEditControl_HoverMenuShowingtopic"><u>RichEditControl.HoverMenuShowing</u></a> event to add and remove menu items.<br />
2) Creating a new command to accomplish the required task. A command exposes the <strong>ICommand</strong> interface .<br />
3) Searching the text within the selected range using the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeSubDocument_FindAlltopic739"><u>FindAll</u></a> method and replacing it with an image using the <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXtraRichEditAPINativeSubDocument_InsertImagetopic"><strong><u>InsertImage</u></strong></a> method.</p><p>The following screenshot shows what the resulting application looks like:</p><p><img src="https://raw.githubusercontent.com/DevExpress-Examples/dxrichedit-for-wpf-how-to-customize-the-hover-menu-e2753/11.2.5+/media/1ea2eac5-aef9-43dc-b473-d10d18cbb946.png"></p>

<br/>


