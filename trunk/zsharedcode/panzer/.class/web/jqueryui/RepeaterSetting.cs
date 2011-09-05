﻿/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/RepeaterSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using zoyobar.shared.panzer.Properties;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " RepeaterSetting "
	/// <summary>
	/// 自定义 Repeater 设置.
	/// </summary>
	public sealed class RepeaterSetting
		: PlusinSetting
	{

		#region " option "
		/// <summary>
		/// 获取或设置编辑行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string EditItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.edititem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.edititem, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置空模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string Empty
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.empty, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.empty, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置默认包含的字段, 默认为 "[]".
		/// </summary>
		public string Field
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.field, "[]" ); }
			set { this.settingHelper.SetOptionValue(OptionType.field, value, "[]"); }
		}

		/// <summary>
		/// 获取或设置尾模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string Footer
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.footer, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.footer, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置头模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string Header
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.header, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.header, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置新建后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string InsertedItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.inserteditem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.inserteditem, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string Item
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.item, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.item, value, string.Empty ); }
		}

		/*
		/// <summary>
		/// 获取或设置是否可以多行编辑, 默认为 false.
		/// </summary>
		public bool MultipleEdit
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.multipleEdit, false ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.multipleEdit, value, false ); }
		}
		*/

		/// <summary>
		/// 获取或设置是否可以选择多行, 默认为 true.
		/// </summary>
		public bool MultipleSelect
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.multipleselect, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.multipleselect, value, true ); }
		}

		/// <summary>
		/// 获取或设置新建行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string NewItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.newitem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.newitem, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置页码, 默认为 1.
		/// </summary>
		public int PageIndex
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.pageindex, 1 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.pageindex, value.ToString ( ), "1" ); }
		}

		/// <summary>
		/// 获取或设置页的大小, 默认为 10.
		/// </summary>
		public int PageSize
		{
			get { return this.settingHelper.GetOptionValueToInteger ( OptionType.pagesize, 10 ); }
			set { this.settingHelper.SetOptionValue ( OptionType.pagesize, value.ToString ( ), "10" ); }
		}

		/// <summary>
		/// 获取或设置删除后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string RemovedItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.removeditem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.removeditem, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置行的属性名称, 默认为 "rows".
		/// </summary>
		public string RowsName
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.rowsname, "rows" ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.rowsname, value, "rows" ); }
		}

		/// <summary>
		/// 获取或设置是否为单程处理, 默认为 true.
		/// </summary>
		public bool SingleThread
		{
			get { return this.settingHelper.GetOptionValueToBoolean ( OptionType.singlethread, true ); }
			set { this.settingHelper.SetOptionValueToBoolean ( OptionType.singlethread, value, true ); }
		}

		/// <summary>
		/// 获取或设置更新后的行模板, 其中包含了 html 代码, 注意使用 &#39; 表示单引号.
		/// </summary>
		public string UpdatedItem
		{
			get { return this.settingHelper.GetOptionValueToString ( OptionType.updateditem, string.Empty ); }
			set { this.settingHelper.SetOptionValueToString ( OptionType.updateditem, value, string.Empty ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置修改行之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreUpdate
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.preupdate ); }
			set { this.settingHelper.SetOptionValue ( OptionType.preupdate, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置修改行时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Update
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.update ); }
			set { this.settingHelper.SetOptionValue ( OptionType.update, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置修改行后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Updated
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.updated ); }
			set { this.settingHelper.SetOptionValue ( OptionType.updated, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置删除行之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreRemove
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.preremove ); }
			set { this.settingHelper.SetOptionValue ( OptionType.preremove, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置删除行时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Remove
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.remove ); }
			set { this.settingHelper.SetOptionValue ( OptionType.remove, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置删除行后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Removed
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.removed ); }
			set { this.settingHelper.SetOptionValue ( OptionType.removed, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置填充之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreFill
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.prefill ); }
			set { this.settingHelper.SetOptionValue ( OptionType.prefill, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置填充时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Fill
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.fill ); }
			set { this.settingHelper.SetOptionValue ( OptionType.fill, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置填充后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Filled
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.filled ); }
			set { this.settingHelper.SetOptionValue ( OptionType.filled, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置新建行之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreInsert
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.preinsert ); }
			set { this.settingHelper.SetOptionValue ( OptionType.preinsert, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置新建行时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Insert
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.insert ); }
			set { this.settingHelper.SetOptionValue ( OptionType.insert, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置新建行后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Inserted
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.inserted ); }
			set { this.settingHelper.SetOptionValue ( OptionType.inserted, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置是否可以导航发生改变后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Navigable
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.navigable ); }
			set { this.settingHelper.SetOptionValue ( OptionType.navigable, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置发生阻塞时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Blocked
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.blocked ); }
			set { this.settingHelper.SetOptionValue ( OptionType.blocked, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置执行操作之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreExecute
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.preexecute ); }
			set { this.settingHelper.SetOptionValue ( OptionType.preexecute, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置执行操作之后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Executed
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.executed ); }
			set { this.settingHelper.SetOptionValue ( OptionType.executed, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置执行自定义操作之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreCustom
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.precustom ); }
			set { this.settingHelper.SetOptionValue ( OptionType.precustom, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置执行自定义操作的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Custom
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.custom ); }
			set { this.settingHelper.SetOptionValue ( OptionType.custom, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置执行自定义操作之后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string Customed
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.customed ); }
			set { this.settingHelper.SetOptionValue ( OptionType.customed, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置执行分步操作之前的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string PreSubStep
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.presubstep ); }
			set { this.settingHelper.SetOptionValue ( OptionType.presubstep, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置执行分步操作时的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string SubStepping
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.substepping ); }
			set { this.settingHelper.SetOptionValue ( OptionType.substepping, value, string.Empty ); }
		}

		/// <summary>
		/// 获取或设置执行分步操作之后的事件, 类似于: "function(tag, e) { }".
		/// </summary>
		public string SubStepped
		{
			get { return this.settingHelper.GetOptionValue ( OptionType.substepped ); }
			set { this.settingHelper.SetOptionValue ( OptionType.substepped, value, string.Empty ); }
		}
		#endregion

		#region " ajax "
		/// <summary>
		/// 获取或设置删除行时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Remove.
		/// </summary>
		public AjaxSetting RemoveAsync
		{
			get { return this.ajaxs[0]; }
			set
			{

				if ( null == value )
					return;

				value.EventType = EventType.remove;
				value.Data = "e.row";
				value.Success = "function(data){e.callback.call($(tag), tag, e.index, (null == -:data.row ? e.row : -:data.row), -:data.__success, e.substep);}";
				value.Error = "function(){e.callback.call($(tag), tag, e.index, e.row, false, e.substep);}";
				this.ajaxs[0] = value;
			}
		}

		/// <summary>
		/// 获取或设置修改行时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Update.
		/// </summary>
		public AjaxSetting UpdateAsync
		{
			get { return this.ajaxs[1]; }
			set
			{

				if ( null == value )
					return;

				value.EventType = EventType.update;
				value.Data = "e.row";
				value.Success = "function(data){e.callback.call($(tag), tag, e.index, (null == -:data.row ? e.row : -:data.row), -:data.__success);}";
				value.Error = "function(){e.callback.call($(tag), tag, e.index, e.row, false);}";
				this.ajaxs[1] = value;
			}
		}

		/// <summary>
		/// 获取或设置填充时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Fill.
		/// </summary>
		public AjaxSetting FillAsync
		{
			get { return this.ajaxs[2]; }
			set
			{

				if ( null == value )
					return;

				value.EventType = EventType.fill;
				value.Parameters = new Parameter[]
				{
					new Parameter("pageindex", ParameterType.Expression, "this.__repeater('option', 'pageindex')"),
					new Parameter("pagesize", ParameterType.Expression, "this.__repeater('option', 'pagesize')"),
				};

				value.Success = "function(data){e.callback.call($(tag), tag, -:data, -:data.__success);}";
				value.Error = "function(){e.callback.call($(tag), tag, {}, false);}";
				this.ajaxs[2] = value;
			}
		}

		/// <summary>
		/// 获取或设置填充时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Insert.
		/// </summary>
		public AjaxSetting InsertAsync
		{
			get { return this.ajaxs[3]; }
			set
			{

				if ( null == value )
					return;

				value.EventType = EventType.insert;
				value.Data = "e.row";
				value.Success = "function(data){e.callback.call($(tag), tag, (null == -:data.row ? e.row : -:data.row), -:data.__success);}";
				value.Error = "function(){e.callback.call($(tag), tag, e.row, false);}";
				this.ajaxs[3] = value;
			}
		}

		/// <summary>
		/// 获取或设置自定义操作时的 Ajax 操作的相关设置, 如果设置有效将覆盖 Custom.
		/// </summary>
		public AjaxSetting CustomAsync
		{
			get { return this.ajaxs[4]; }
			set
			{

				if ( null == value )
					return;

				value.EventType = EventType.custom;
				value.Data = "e.row, {command: e.command}";
				value.Success = "function(data){e.callback.call($(tag), tag, e.index, e.command, (null == -:data.row ? e.row : -:data.row), -:data.__success, e.substep);}";
				value.Error = "function(){e.callback.call($(tag), tag, e.index, e.command, e.row, false, e.substep);}";
				this.ajaxs[4] = value;
			}
		}
		#endregion

		/// <summary>
		/// 创建一个自定义 Repeater 设置.
		/// </summary>
		public RepeaterSetting ( )
			: base ( PlusinType.repeater, 5 )
		{
			this.RemoveAsync = this.ajaxs[0];
			this.UpdateAsync = this.ajaxs[1];
			this.FillAsync = this.ajaxs[2];
			this.InsertAsync = this.ajaxs[3];
			this.CustomAsync = this.ajaxs[4];
		}

		/// <summary>
		/// 获取自定义 Repeater 的安装脚本.
		/// </summary>
		/// <returns>自定义 Repeater 的安装脚本.</returns>
		public override string GetPlusinCode ( )
		//{ return ""; }
		{ return Resources.repeater_min; }

	}
	#endregion

}