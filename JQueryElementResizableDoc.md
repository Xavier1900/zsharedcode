﻿#summary JQueryElement 缩放效果
#labels Phase-Implementation
<font face='microsoft yahei'>
<font size='1'><a href='http://www.microsofttranslator.com/bv.aspx?from=&to=en&a=http://code.google.com/p/zsharedcode/wiki/JQueryElementResizableDoc'>Translate this page</a></font>

<h3>简介</h3>
<blockquote>使用 JQueryElement 的 Resizable 控件即可实现 jQuery UI 中的缩放效果, 在最终的用户页面中, 可以使用鼠标缩放某些元素.</blockquote>

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

<h3>实现一个简单的缩放</h3>
<blockquote>在页面中添加如下代码:<br>
<pre><code>&lt;je:Resizable ID="rA" runat="server" CssClass="panel" Html="&lt;strong&gt;可缩放 A&lt;/strong&gt;"	Width="200px" ScriptPackageID="package"&gt;
&lt;/je:Resizable&gt;
</code></pre>
这里实现了一个可以缩放的元素, 其内部的 html 代码为 <code>&lt;strong&gt;可缩放 A&lt;/strong&gt;</code>, 其对应的 js 脚本将生成到刚才添加的 ScriptPackage 控件中.</blockquote>

<h3>通过选择器实现缩放</h3>
<blockquote>Resizable 可以使页面上其它的元素实现缩放效果, 通过 Selector 属性, 将其设置为一个选择器, 比如: <code>'#divB'</code>, 表示选择页面中 id 为 divB 的元素, 注意使用了单引号, 那么 divB 将具有可缩放效果.<br>
<pre><code>&lt;div id="divB" class="panel" style="width: 200px;"&gt;
	&lt;div class="box"&gt;
		可缩放 B, 内容框也跟随缩放
	&lt;/div&gt;
&lt;/div&gt;
&lt;je:Resizable ID="rB" runat="server" Selector="'#divB'" AlsoResize="#divB .box" ScriptPackageID="package"&gt;
&lt;/je:Resizable&gt;
</code></pre></blockquote>

<h3>效果说明</h3>
<blockquote>通过设置 Resizable 的属性实现的部分效果如下, 具体请参考 resizable.aspx:<br>
</blockquote><ul><li>设置缩放元素内的元素一同缩放<br>
</li><li>播放缩放的动画效果<br>
</li><li>缩放时具有拖影<br>
</li><li>设置缩放的宽高比例<br>
</li><li>在为多个元素设置缩放效果时, 取消其中部分元素的缩放效果<br>
</li><li>缩放范围限制在某个容器中<br>
</li><li>限制鼠标按下一段时间或移动一段距离后产生缩放效果<br>
</li><li>按照点阵缩放<br>
</li><li>设置缩放元素的四条边和四个角哪些可以进行缩放<br>
</li><li>设置缩放元素的最大和最小尺寸</li></ul>

<h3>事件说明</h3>
<blockquote>Resizable 控件具有如下事件, 具体请参考 resizable.aspx:<br>
</blockquote><ul><li>创建时<br>
</li><li>缩放中<br>
</li><li>缩放开始时<br>
</li><li>缩放结束时</li></ul>

<h3>resizable.aspx</h3>
<pre><code>&lt;%@ Page Language="C#" %&gt;

&lt;%@ Register Assembly="zoyobar.shared.panzer.JQueryElement" Namespace="zoyobar.shared.panzer.ui.jqueryui"
	TagPrefix="je" %&gt;
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;
&lt;head runat="server"&gt;
	&lt;title&gt;JQuery UI 的缩放效果&lt;/title&gt;
	&lt;script type="text/javascript" src="../js/jquery-1.5.1.min.js"&gt;&lt;/script&gt;
	&lt;script type="text/javascript" src="../js/jquery-ui-1.8.11.custom.min.js"&gt;&lt;/script&gt;
	&lt;link type="text/css" rel="Stylesheet" href="../css/smoothness/jquery-ui-1.8.15.custom.css" /&gt;
	&lt;link type="text/css" rel="Stylesheet" href="../css/main.css" /&gt;
	&lt;script type="text/javascript"&gt;
		function writeLine(selector, html) {
			$(selector).html($(selector).html() + html + '&lt;br /&gt;');
		}
	&lt;/script&gt;
&lt;/head&gt;
&lt;body&gt;
	&lt;form id="formResizable" runat="server"&gt;
	&lt;je:Resizable ID="rA" runat="server" CssClass="panel" Html="&lt;strong&gt;可缩放 A&lt;/strong&gt;"
		Width="200px" ScriptPackageID="package"&gt;
	&lt;/je:Resizable&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;-&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;div id="divB" class="panel" style="width: 200px;"&gt;
		&lt;div class="box"&gt;
			可缩放 B, 内容框也跟随缩放
		&lt;/div&gt;
	&lt;/div&gt;
	&lt;je:Resizable ID="rB" runat="server" Selector="'#divB'" AlsoResize="#divB .box" ScriptPackageID="package"&gt;
	&lt;/je:Resizable&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;AlsoResize="#divB .box"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Resizable ID="rC" runat="server" CssClass="panel" Text="可缩放 C, 以正常速度播放缩放动画, 并具有拖影"
		Width="200px" ScriptPackageID="package" Animate="True" AnimateDuration="normal"
		Ghost="True"&gt;
	&lt;/je:Resizable&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Animate="True" AnimateDuration="normal" Ghost="True"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Resizable ID="rD" runat="server" CssClass="panel" Text="可缩放 D, 宽高比例 3:1" Width="300px"
		Height="100px" ScriptPackageID="package" AspectRatio="3"&gt;
	&lt;/je:Resizable&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;AspectRatio="3"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;div id="divE" class="panel" style="width: 80%; height: 50px;"&gt;
		&lt;div&gt;
			可缩放 E1
		&lt;/div&gt;
		&lt;br /&gt;
		&lt;div class="box"&gt;
			不可缩放 E2, 取消了样式为 box 的 div 元素的缩放
		&lt;/div&gt;
		&lt;je:Resizable ID="rE" runat="server" ScriptPackageID="package" Selector="'#divE &gt; div'"
			Cancel=".box"&gt;
		&lt;/je:Resizable&gt;
	&lt;/div&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Selector="'#divE &gt; div'" Cancel=".box"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;div class="panel" style="width: 80%; height: 50px;"&gt;
		&lt;je:Resizable ID="rF" runat="server" CssClass="box" Text="可缩放 F, 在 p 元素范围内" Width="200px"
			ScriptPackageID="package" Containment="parent"&gt;
		&lt;/je:Resizable&gt;
	&lt;/div&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Containment="parent"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Resizable ID="rG" runat="server" CssClass="panel" Text="可缩放 G, 鼠标按下 1 秒后产生缩放"
		Width="200px" ScriptPackageID="package" Delay="1000"&gt;
	&lt;/je:Resizable&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Delay="1000"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Resizable ID="rH" runat="server" CssClass="panel" Text="可缩放 H, 鼠标按下并移动 100px 后产生缩放"
		Width="200px" ScriptPackageID="package" Distance="100"&gt;
	&lt;/je:Resizable&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Distance="100"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Resizable ID="rI" runat="server" CssClass="panel" Text="可缩放 I, 按照 10*10 的点阵移动缩放"
		Width="200px" ScriptPackageID="package" Grid="[10, 10]"&gt;
	&lt;/je:Resizable&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Grid="[10, 10]"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Resizable ID="rJ" runat="server" CssClass="panel" Text="可缩放 J, 四条边和右下角均可以缩放"
		Width="200px" ScriptPackageID="package" Handles="e, s, se, w, n"&gt;
	&lt;/je:Resizable&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Handles="e, s, se, w, n"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Resizable ID="rK" runat="server" CssClass="panel" Text="可缩放 K, 最小尺寸 100 * 50, 最大尺寸 300 * 100"
		Width="300px" Height="100px" ScriptPackageID="package" MaxHeight="100" MaxWidth="300"
		MinHeight="50" MinWidth="100"&gt;
	&lt;/je:Resizable&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;MaxHeight="100" MaxWidth="300" MinHeight="50" MinWidth="100"&lt;/span&gt;
	&lt;br /&gt;
	&lt;hr /&gt;
	&lt;je:Resizable ID="rL" runat="server" CssClass="panel" Text="可缩放 L, 事件" Width="200px"
		ScriptPackageID="package" Create="function(){writeLine('#pL', '创建');}" Resize="function(){writeLine('#pL', '缩放中');}"
		Start="function(){writeLine('#pL', '缩放开始');}" Stop="function(){writeLine('#pL', '缩放结束');}"&gt;
	&lt;/je:Resizable&gt;
	&lt;p id="pL" class="panel" style="width: 80%;"&gt;
	&lt;/p&gt;
	&lt;br /&gt;
	&lt;span class="code"&gt;Create="..." Resize="..." Start="..." Stop="..."&lt;/span&gt;
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