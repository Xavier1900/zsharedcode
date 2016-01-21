﻿#summary JQueryElement 折叠列表
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementAccordionDoc'>Translate this page</a></font>

<h3>简介</h3>
<blockquote>使用 JQueryElement 的 Accordion 控件即可实现 jQuery UI 中的折叠列表.</blockquote>

<h3>前提条件</h3>
<ol><li>请在 <a href='Download.md'>下载资源</a> 中的 JQueryElement.dll 下载一节下载 JQueryElement 3.0 或更高版本的 dll, 并为项目引用对应 .NET 版本的 dll.</li></ol>

<blockquote>2. 在页面添加如下指令:<br>
<pre><code>&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui" TagPrefix="je" %&gt;
</code></pre></blockquote>

<blockquote>3. JQueryElement 并没有将 jQuery UI 的脚本和样式作为资源嵌入, 所以请将 jQuery UI 所需的脚本和样式复制到项目中并在页面中引用, 比如:<br>
<pre><code>&lt;script type="text/javascript" src="../js/jquery-1.5.1.min.js"&gt;&lt;/script&gt;
&lt;script type="text/javascript" src="../js/jquery-ui-1.8.11.custom.min.js"&gt;&lt;/script&gt;
&lt;link type="text/css" rel="Stylesheet" href="../css/smoothness/jquery-ui-1.8.15.custom.css" /&gt;
</code></pre></blockquote>

<blockquote>4. 添加如下 js 脚本:<br>
<pre><code>&lt;script type="text/javascript"&gt;
	function navigate(url) {
		window.location = url;
	}
	function writeLine(selector, html) {
		$(selector).html($(selector).html() + html + '&lt;br /&gt;');
	}
&lt;/script&gt;
</code></pre></blockquote>

<blockquote>5. 页面包含如下自定义样式, 请参考文章尾部的 main.css.<br>
<pre><code>&lt;link type="text/css" rel="Stylesheet" href="../css/main.css" /&gt;
</code></pre></blockquote>

<h3>添加 ScriptPackage 控件</h3>
<blockquote>添加 ScriptPackage 控件, 用来统一存放控件产生的 js 脚本, 也可以不添加. 需要将控件放到页面代码的尾部, 否则有些 js 脚本可能不会被包含.<br>
<pre><code>&lt;je:ScriptPackage ID="package" runat="server" /&gt;
</code></pre></blockquote>

<h3>通过选择器实现折叠列表</h3>
<blockquote>在页面中添加如下代码:<br>
<pre><code>&lt;div id="dA" style="width: 200px;"&gt;
	&lt;h1&gt;
		&lt;a href="#"&gt;搜索&lt;/a&gt;
	&lt;/h1&gt;
	&lt;div&gt;
		&lt;a href="#" onclick="navigate('http://www.google.com.hk/')"&gt;谷歌&lt;/a&gt;
		&lt;br /&gt;
		&lt;a href="#" onclick="navigate('http://www.bing.com/')"&gt;Bing&lt;/a&gt;
	&lt;/div&gt;
	&lt;h1&gt;
		&lt;a href="#"&gt;学习&lt;/a&gt;
	&lt;/h1&gt;
	&lt;div&gt;
		&lt;a href="#" onclick="navigate('http://msdn.microsoft.com/')"&gt;MSDN&lt;/a&gt;
	&lt;/div&gt;
&lt;/div&gt;
&lt;je:Accordion ID="aA" runat="server" ScriptPackageID="package" Selector="'#dA'"&gt;
&lt;/je:Accordion&gt;
</code></pre>
这里实现了一个可折叠列表, 通过 Selector 属性, 将其设置为一个选择器, 比如: <code>'#dA'</code>, 表示选择页面中 id 为 dA 的元素, 注意使用了单引号, 那么 dA 将成为一个折叠列表, 在 dA 内部标题 h1 和内容 div 交替出现, 其对应的 js 脚本将生成到刚才添加的 ScriptPackage 控件中.</blockquote>

<h3>效果说明</h3>
<blockquote>通过设置 Accordion 的属性实现的部分效果如下, 具体请参考 accordion.aspx:<br>
</blockquote><ul><li>设置某个列表为选中状态<br>
</li><li>所有列表的高度以最高的列表为准<br>
</li><li>点击展开的列表可以将其折叠<br>
</li><li>设置触发列表展开的事件<br>
</li><li>所有列表的高度以某个容器的高度为准</li></ul>

<h3>事件说明</h3>
<blockquote>Accordion 控件具有如下事件, 具体请参考 accordion.aspx:<br>
</blockquote><ul><li>创建时<br>
</li><li>选中的列表改变之前<br>
</li><li>选中的列表改变时</li></ul>

<h3>accordion.aspx</h3>
<pre><code>&lt;%@ Page Language="C#" %&gt;

&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui"
	TagPrefix="je" %&gt;
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;
&lt;head runat="server"&gt;
	&lt;title&gt;JQuery UI 的 accordion&lt;/title&gt;
	&lt;script type="text/javascript" src="../js/jquery-1.5.1.min.js"&gt;&lt;/script&gt;
	&lt;script type="text/javascript" src="../js/jquery-ui-1.8.11.custom.min.js"&gt;&lt;/script&gt;
	&lt;link type="text/css" rel="Stylesheet" href="../css/smoothness/jquery-ui-1.8.15.custom.css" /&gt;
	&lt;link type="text/css" rel="Stylesheet" href="../css/main.css" /&gt;
	&lt;script type="text/javascript"&gt;
		function navigate(url) {
			window.location = url;
		}
		function writeLine(selector, html) {
			$(selector).html($(selector).html() + html + '&lt;br /&gt;');
		}
	&lt;/script&gt;
&lt;/head&gt;
&lt;body&gt;
	&lt;form id="formAccordion" runat="server"&gt;
	&lt;div id="dA" style="width: 200px;"&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;搜索&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#" onclick="navigate('http://www.google.com.hk/')"&gt;谷歌&lt;/a&gt;
			&lt;br /&gt;
			&lt;a href="#" onclick="navigate('http://www.bing.com/')"&gt;Bing&lt;/a&gt;
		&lt;/div&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;学习&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#" onclick="navigate('http://msdn.microsoft.com/')"&gt;MSDN&lt;/a&gt;
		&lt;/div&gt;
	&lt;/div&gt;
	&lt;je:Accordion ID="aA" runat="server" ScriptPackageID="package" Selector="'#dA'"&gt;
	&lt;/je:Accordion&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;-&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;div id="dB" style="width: 200px;"&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;搜索&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#"&gt;谷歌&lt;/a&gt;
		&lt;/div&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;学习, 默认激活&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#"&gt;MSDN&lt;/a&gt;
		&lt;/div&gt;
	&lt;/div&gt;
	&lt;je:Accordion ID="aB" runat="server" ScriptPackageID="package" Selector="'#dB'" Active="1"&gt;
	&lt;/je:Accordion&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Active="1"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;div id="dC" style="width: 200px;"&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;搜索&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#"&gt;谷歌&lt;/a&gt;
			&lt;br /&gt;
			&lt;a href="#"&gt;Bing&lt;/a&gt;
		&lt;/div&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;学习, 不与 "搜索" 同高&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#"&gt;MSDN&lt;/a&gt;
		&lt;/div&gt;
	&lt;/div&gt;
	&lt;je:Accordion ID="aC" runat="server" ScriptPackageID="package" Selector="'#dC'" AutoHeight="False"&gt;
	&lt;/je:Accordion&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;AutoHeight="False"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;div id="dD" style="width: 200px;"&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;搜索, 点击激活的列表, 可将所有列表折叠&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#"&gt;谷歌&lt;/a&gt;
			&lt;br /&gt;
			&lt;a href="#"&gt;Bing&lt;/a&gt;
		&lt;/div&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;学习, 点击激活的列表, 可将所有列表折叠&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#"&gt;MSDN&lt;/a&gt;
		&lt;/div&gt;
	&lt;/div&gt;
	&lt;je:Accordion ID="aD" runat="server" ScriptPackageID="package" Selector="'#dD'" Collapsible="True"&gt;
	&lt;/je:Accordion&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Collapsible="True"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;div id="dE" style="width: 200px;"&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;搜索, 鼠标进入展开&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#"&gt;谷歌&lt;/a&gt;
			&lt;br /&gt;
			&lt;a href="#"&gt;Bing&lt;/a&gt;
		&lt;/div&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;学习, 鼠标进入展开&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#"&gt;MSDN&lt;/a&gt;
		&lt;/div&gt;
	&lt;/div&gt;
	&lt;je:Accordion ID="aE" runat="server" ScriptPackageID="package" Selector="'#dE'" Event="mouseenter"&gt;
	&lt;/je:Accordion&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Event="mouseenter"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;div style="height: 500px;"&gt;
		&lt;div id="dF" style="width: 200px;"&gt;
			&lt;h1&gt;
				&lt;a href="#"&gt;搜索, 与父容器同高&lt;/a&gt;
			&lt;/h1&gt;
			&lt;div&gt;
				&lt;a href="#"&gt;谷歌&lt;/a&gt;
				&lt;br /&gt;
				&lt;a href="#"&gt;Bing&lt;/a&gt;
			&lt;/div&gt;
			&lt;h1&gt;
				&lt;a href="#"&gt;学习, 与父容器同高&lt;/a&gt;
			&lt;/h1&gt;
			&lt;div&gt;
				&lt;a href="#"&gt;MSDN&lt;/a&gt;
			&lt;/div&gt;
		&lt;/div&gt;
	&lt;/div&gt;
	&lt;je:Accordion ID="aF" runat="server" ScriptPackageID="package" Selector="'#dF'" FillSpace="True"&gt;
	&lt;/je:Accordion&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;FillSpace="True"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;div id="dG" style="width: 200px;"&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;搜索, 事件&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#"&gt;谷歌&lt;/a&gt;
			&lt;br /&gt;
			&lt;a href="#"&gt;Bing&lt;/a&gt;
		&lt;/div&gt;
		&lt;h1&gt;
			&lt;a href="#"&gt;学习, 事件&lt;/a&gt;
		&lt;/h1&gt;
		&lt;div&gt;
			&lt;a href="#"&gt;MSDN&lt;/a&gt;
		&lt;/div&gt;
	&lt;/div&gt;
	&lt;je:Accordion ID="aG" runat="server" ScriptPackageID="package" Selector="'#dG'" Change="function(){writeLine('#pG', '改变');}"
		Changestart="function(){writeLine('#pG', '改变开始');}" Create="function(){writeLine('#pG', '创建');}"&gt;
	&lt;/je:Accordion&gt;
	&lt;p id="pG" class="panel" style="width: 80%;"&gt;
	&lt;/p&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Change="..." Changestart="..." Create=="..."&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:ScriptPackage ID="package" runat="server" /&gt;
	&lt;/form&gt;
&lt;/body&gt;
&lt;/html&gt;
</code></pre>

<h3>main.css</h3>
<pre><code>body
{
	font-family: "微软雅黑";
	font-size: 9pt;
}
hr
{
	border: solid 1px #eeeeee;
	margin-bottom: 50px;
}
li
{
	padding: 5px;
}
.panel
{
	border: solid 1px #cccccc;
	padding: 10px;
	background-color: #eeeeee;
}
.box
{
	border: solid 1px #999999;
	padding: 2px 5px 2px 5px;
	color: InfoText;
	background-color: InfoBackground;
}
.code
{
	float: right;
	font-style: italic;
	font-size: x-small;
	color: Blue;
}
.ui-selecting
{
	color: MenuText;
	background-color: InactiveCaption;
}
.ui-selected
{
	color: MenuText;
	background-color: ActiveCaption;
}
</code></pre>

<blockquote><i>这里仅列出部分代码, 可能需要您自己创建窗口, 页面等.</i>
</font>