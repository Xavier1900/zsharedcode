﻿/*
 * wiki:
 * http://code.google.com/p/zsharedcode/wiki/JQueryUIProgressbar
 * 如果您无法运行此文件, 可能由于缺少相关类文件, 请下载解决方案后重试, 具体请参考: http://code.google.com/p/zsharedcode/wiki/HowToDownloadAndUse
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/Progressbar.cs
 * 引用代码:
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/JQueryElement.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/JQuery.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/ScriptHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/NavigateOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptBuildOption.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.enum/web/ScriptType.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DraggableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/DroppableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SortableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/SelectableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ResizableSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/EventEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/ParameterEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/OptionEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/AjaxSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/WidgetSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/RepeaterSettingEdit.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/ui/jqueryui/JQueryCoder.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DraggableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/DroppableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SortableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/SelectableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ResizableSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Option.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/WidgetSetting.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Event.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/Parameter.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/ExpressionHelper.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/JQueryUI.cs
 * http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/code/StringConvert.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 但您仍然需要遵守, 下载并将 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 包含在你的产品中.
 * */

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.WebControls;

using zoyobar.shared.panzer.code;
using zoyobar.shared.panzer.web.jqueryui;

namespace zoyobar.shared.panzer.ui.jqueryui
{

	/// <summary>
	/// jQuery UI 进度条插件.
	/// </summary>
	[ToolboxData ( "<{0}:Progressbar runat=server></{0}:Progressbar>" )]
	[DesignerAttribute ( typeof ( ProgressbarDesigner ) )]
	public class Progressbar
		: BaseWidget, IPostBackEventHandler
	{
		private readonly AjaxSettingEdit changeAjax = new AjaxSettingEdit ( );
		private readonly AjaxSettingEdit completeAjax = new AjaxSettingEdit ( );

		/// <summary>
		/// 创建一个 jQuery UI 按钮.
		/// </summary>
		public Progressbar ( )
			: base ( WidgetType.progressbar )
		{ this.elementType = ElementType.Div; }

		#region " Option "
		/// <summary>
		/// 获取或设置进度条是否可用, 可以设置为 true 或者 false.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( false )]
		[Description ( "指示进度条是否可用, 可以设置为 true 或者 false" )]
		[NotifyParentProperty ( true )]
		public bool Disabled
		{
			get { return this.getBoolean ( this.editHelper.GetOuterOptionEditValue ( OptionType.disabled ), false ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.disabled, value.ToString ( ).ToLower ( ) ); }
		}

		/// <summary>
		/// 获取或设置进度条当前的值, 比如: 37.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( 0 )]
		[Description ( "指示进度条当前的值, 比如: 37" )]
		[NotifyParentProperty ( true )]
		public int Value
		{
			get { return this.getInteger ( this.editHelper.GetOuterOptionEditValue ( OptionType.value ), 0 ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.value, value <= 0 ? string.Empty : value.ToString ( ) ); }
		}
		#endregion

		#region " Event "
		/// <summary>
		/// 获取或设置进度条被创建时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条被创建时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Create
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.create ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.create, value ); }
		}

		/// <summary>
		/// 获取或设置进度条当前值改变时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条当前值改变时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Change
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.change ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.change, value ); }
		}

		/// <summary>
		/// 获取或设置进度条完成时的事件, 类似于: function(event, ui) { }.
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示进度条完成时的事件, 类似于: function(event, ui) { }" )]
		[NotifyParentProperty ( true )]
		public string Complete
		{
			get { return this.editHelper.GetOuterOptionEditValue ( OptionType.complete ); }
			set { this.editHelper.SetOuterOptionEditValue ( OptionType.complete, value ); }
		}
		#endregion

		#region " Ajax "
		/// <summary>
		/// 获取 Change 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Change 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AjaxSettingEdit ChangeAsync
		{
			get { return this.changeAjax; }
		}
		/// <summary>
		/// 获取 Complete 操作相关的 Ajax 设置.
		/// </summary>
		[Category ( "Ajax" )]
		[Description ( "Complete 操作相关的 Ajax 设置" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public AjaxSettingEdit CompleteAsync
		{
			get { return this.completeAjax; }
		}
		#endregion

		#region " Server "
		/// <summary>
		/// 在服务器端执行的值改变事件.
		/// </summary>
		[Description ( "指示值改变的服务器端事件, 如果设置客户端事件将无效" )]
		public event ProgressbarChangeEventHandler ChangeSync;
		/// <summary>
		/// 在服务器端执行的完成事件.
		/// </summary>
		[Description ( "指示完成的服务器端事件, 如果设置客户端事件将无效" )]
		public event ProgressbarCompleteEventHandler CompleteSync;
		#endregion

		protected override void Render ( HtmlTextWriter writer )
		{

			if ( !this.DesignMode )
			{
				this.widgetSetting.Type = this.type;

				this.widgetSetting.ProgressbarSetting.SetEditHelper ( this.editHelper );

				this.widgetSetting.AjaxSettings.Clear ( );

				if ( this.changeAjax.Url != string.Empty )
				{
					this.changeAjax.WidgetEventType = EventType.change;
					this.widgetSetting.AjaxSettings.Add ( this.changeAjax );
				}

				if ( this.completeAjax.Url != string.Empty )
				{
					this.completeAjax.WidgetEventType = EventType.complete;
					this.widgetSetting.AjaxSettings.Add ( this.completeAjax );
				}


				if ( null != this.ChangeSync )
					this.Change = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "change;[%':$(this).progressbar(!sq!option!sq!, !sq!value!sq!)%]" ) + "}";

				if ( null != this.CompleteSync )
					this.Complete = "function(event, ui){" + this.Page.ClientScript.GetPostBackEventReference ( this, "complete;[%':$(this).progressbar(!sq!option!sq!, !sq!value!sq!)%]" ) + "}";

			}
			else if ( string.IsNullOrEmpty ( this.selector ) )
				switch ( this.type )
				{
					case WidgetType.progressbar:
						string style = string.Empty;

						if ( this.Width != Unit.Empty )
							style += string.Format ( "width:{0};", this.Width );

						if ( this.Height != Unit.Empty )
							style += string.Format ( "height:{0};", this.Height );

						writer.Write (
							"<{6} id=\"{0}\" class=\"{3}ui-progressbar ui-widget ui-widget-content ui-corner-all{2}\" style=\"{4}\" title=\"{5}\"><div style=\"width: {1}%;\" class=\"ui-progressbar-value ui-widget-header ui-corner-left\"></div></{6}>",
							this.ClientID,
							this.Value,
							this.Disabled ? " ui-progressbase-disabled ui-state-disabled" : string.Empty,
							string.IsNullOrEmpty ( this.CssClass ) ? string.Empty : this.CssClass + " ",
							style,
							this.ToolTip,
							this.elementType.ToString ( ).ToLower ( )
							);
						return;
				}

			base.Render ( writer );
		}

		public void RaisePostBackEvent ( string eventArgument )
		{

			if ( string.IsNullOrEmpty ( eventArgument ) )
				return;

			string[] parts = eventArgument.Split ( ';' );

			switch ( parts[0] )
			{
				case "change":

					if ( null != this.ChangeSync )
						try
						{ this.ChangeSync ( this, new ProgressbarEventArgs ( StringConvert.ToObject<int> ( parts[1] ) ) ); }
						catch { }

					break;

				case "complete":

					if ( null != this.CompleteSync )
						try
						{ this.CompleteSync ( this, new ProgressbarEventArgs ( StringConvert.ToObject<int> ( parts[1] ) ) ); }
						catch { }

					break;
			}

		}

	}

	#region " ProgressbarDesigner "
	/// <summary>
	/// 进度条设计器.
	/// </summary>
	public class ProgressbarDesigner : JQueryElementDesigner
	{

		/// <summary>
		/// 获取行为列表.
		/// </summary>
		public override DesignerActionListCollection ActionLists
		{
			get { return new DesignerActionListCollection ( ); }
		}

	}
	#endregion

	/// <summary>
	/// 进度条值改变事件.
	/// </summary>
	/// <param name="sender">事件的发起者.</param>
	/// <param name="e">事件的参数.</param>
	public delegate void ProgressbarChangeEventHandler ( object sender, ProgressbarEventArgs e );

	/// <summary>
	/// 进度条完成事件.
	/// </summary>
	/// <param name="sender">事件的发起者.</param>
	/// <param name="e">事件的参数.</param>
	public delegate void ProgressbarCompleteEventHandler ( object sender, ProgressbarEventArgs e );

	/// <summary>
	/// 进度条事件参数.
	/// </summary>
	public sealed class ProgressbarEventArgs
	{
		/// <summary>
		/// 值.
		/// </summary>
		public readonly int Value;

		/// <summary>
		/// 创建一个进度条事件参数.
		/// </summary>
		/// <param name="value">值.</param>
		public ProgressbarEventArgs ( int value )
		{

			if ( value < 0 )
				value = 0;

			this.Value = value;
		}

	}

}
