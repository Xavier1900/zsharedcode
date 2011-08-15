﻿/*
 * 作者: M.S.cxc
 * 原始代码: http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/.class/web/jqueryui/AjaxSetting.cs
 * 版本: .net 4.0, 其它版本可能有所不同
 * 
 * 使用许可: 此文件是开源共享免费的, 您需要遵守 panzer 许可证 http://zsharedcode.googlecode.com/svn/trunk/zsharedcode/panzer/panzer.license.txt 中的内容, 并将许可证下载包含到您的项目和产品中.
 * */

using System.ComponentModel;
using System.Collections.Generic;
using System.Web.UI;

namespace zoyobar.shared.panzer.web.jqueryui
{

	#region " AjaxSetting "
	/// <summary>
	/// jQuery UI Ajax 设置.
	/// </summary>
	public sealed class AjaxSetting
	{
		#region " property "
		private readonly List<Parameter> parameters = new List<Parameter> ( );
		private readonly SettingHelper settingHelper = new SettingHelper ( );

		private string contentType;
		private DataType dataType;
		private EventType eventType;
		private string form;
		private bool isSingleQuote;
		private string methodName;
		private RequestType type;
		private string url;

		/// <summary>
		/// 获取 Option, Event 辅助类.
		/// </summary>
		[Browsable ( false )]
		public SettingHelper SettingHelper
		{
			get { return this.settingHelper; }
		}

		/// <summary>
		/// 获取或设置请求内容的类型.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示请求内容的类型" )]
		[NotifyParentProperty ( true )]
		public string ContentType
		{
			get { return this.contentType; }
			set { this.contentType = ( null == value ? string.Empty : value ); }
		}

		/// <summary>
		/// 获取或设置获取的数据类型.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( DataType.json )]
		[Description ( "指示获取的数据类型" )]
		[NotifyParentProperty ( true )]
		public DataType DataType
		{
			get { return this.dataType; }
			set { this.dataType = value; }
		}

		/// <summary>
		/// 获取或设置相关的触发事件.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( EventType.none )]
		[Description ( "指示相关的触发事件" )]
		[NotifyParentProperty ( true )]
		public EventType EventType
		{
			get { return this.eventType; }
			set { this.eventType = value; }
		}

		/// <summary>
		/// 获取或设置用作传递参数的表单.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示用作传递参数的表单, 可以是一个选择器或元素" )]
		[NotifyParentProperty ( true )]
		public string Form
		{
			get { return this.form; }
			set { this.form = ( null == value ? string.Empty : value ); }
		}

		/// <summary>
		/// 获取或设置是否为字符串使用单引号.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( true )]
		[Description ( "指示是否为字符串使用单引号" )]
		[NotifyParentProperty ( true )]
		public bool IsSingleQuote
		{
			get { return this.isSingleQuote; }
			set { this.isSingleQuote = value; }
		}

		/// <summary>
		/// 获取或设置 WebService 的方法名称, 设置将可能修改 Type, ContentType 以及 DataType 属性.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示 WebService 的方法名称, 设置将可能修改 Type, ContentType 以及 DataType 属性" )]
		[NotifyParentProperty ( true )]
		public string MethodName
		{
			get { return this.methodName; }
			set
			{

				if ( !string.IsNullOrEmpty ( value ) )
				{
					this.type = RequestType.POST;
					this.dataType = DataType.json;

					if ( string.IsNullOrEmpty ( this.contentType ) )
						this.contentType = "application/json;charset=utf-8";

					this.methodName = value;
				}
				else
					this.methodName = string.Empty;

			}
		}

		/// <summary>
		/// 获取或设置 Ajax 所使用的参数.
		/// </summary>
		public Parameter[] Parameters
		{
			get { return this.parameters.ToArray ( ); }
			set
			{

				if ( null == value )
					return;

				this.parameters.Clear ( );

				foreach ( Parameter parameter in value )
					if ( null != parameter )
						this.parameters.Add ( parameter );

			}
		}

		/// <summary>
		/// 获取或设置 Ajax 所使用的参数列表.
		/// </summary>
		[Browsable ( false )]
		[Category ( "基本" )]
		[Description ( "用作传递的参数" )]
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		[PersistenceMode ( PersistenceMode.InnerProperty )]
		[NotifyParentProperty ( true )]
		public List<Parameter> ParameterList
		{
			get { return this.parameters; }
		}

		/// <summary>
		/// 获取或设置客户端向 Web 服务器请求的类型.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( RequestType.GET )]
		[Description ( "指示请求的类型" )]
		[NotifyParentProperty ( true )]
		public RequestType Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// 获取或设置请求的地址.
		/// </summary>
		[Category ( "行为" )]
		[DefaultValue ( "" )]
		[Description ( "指示请求的地址" )]
		[NotifyParentProperty ( true )]
		[UrlProperty ( )]
		public string Url
		{
			get { return this.url; }
			set { this.url = ( null == value ? string.Empty : value ); }
		}
		#endregion

		#region " event "
		/// <summary>
		/// 获取或设置 ajax 完成时的事件, 类似于: "function() { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 完成时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Complete
		{
			get { return this.settingHelper.GetEventValue ( EventType.complete ); }
			set { this.settingHelper.SetEventValue ( EventType.complete, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 错误时的事件, 类似于: "function() { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 错误时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Error
		{
			get { return this.settingHelper.GetEventValue ( EventType.error ); }
			set { this.settingHelper.SetEventValue ( EventType.error, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 成功时的事件, 类似于: "function() { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 成功时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Success
		{
			get { return this.settingHelper.GetEventValue ( EventType.success ); }
			set { this.settingHelper.SetEventValue ( EventType.success, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 发送时的事件, 类似于: "function() { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 发送时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Send
		{
			get { return this.settingHelper.GetEventValue ( EventType.send ); }
			set { this.settingHelper.SetEventValue ( EventType.send, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 开始时的事件, 类似于: "function() { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 开始时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Start
		{
			get { return this.settingHelper.GetEventValue ( EventType.start ); }
			set { this.settingHelper.SetEventValue ( EventType.start, value ); }
		}

		/// <summary>
		/// 获取或设置 ajax 停止时的事件, 类似于: "function() { }".
		/// </summary>
		[Category ( "事件" )]
		[DefaultValue ( "" )]
		[Description ( "指示 ajax 停止时的事件, 类似于: function() { }" )]
		[NotifyParentProperty ( true )]
		public string Stop
		{
			get { return this.settingHelper.GetEventValue ( EventType.stop ); }
			set { this.settingHelper.SetEventValue ( EventType.stop, value ); }
		}
		#endregion

		/// <summary>
		/// 创建 jQuery UI Ajax 设置.
		/// </summary>
		public AjaxSetting ( )
			: this ( EventType.none, null, null, DataType.json, RequestType.GET, null, null, null, null, true )
		{ }
		/// <summary>
		/// 创建 jQuery UI Ajax 设置.
		/// </summary>
		/// <param name="eventType">相关的触发事件.</param>
		/// <param name="url">请求的地址, 比如: "''".</param>
		/// <param name="methodName">调用的 WebService 的方法名称.</param>
		/// <param name="dataType">获取的数据类型.</param>
		/// <param name="type">请求的类型.</param>
		/// <param name="contentType">请求的内容类型.</param>
		/// <param name="form">用作传递参数的表单.</param>
		/// <param name="parameters">用作传递的参数, 如果指定了 form 参数, 则忽略 parameters.</param>
		/// <param name="events">Ajax 相关事件.</param>
		/// <param name="isSingleQuote">是否为字符串使用单引号.</param>
		public AjaxSetting ( EventType eventType, string url, string methodName, DataType dataType, RequestType type, string contentType, string form, Parameter[] parameters, Event[] events, bool isSingleQuote )
		{
			this.Parameters = parameters;
			this.settingHelper.Events = events;

			this.eventType = eventType;
			this.Url = url;
			this.MethodName = methodName;

			this.dataType = dataType;
			this.type = type;

			this.ContentType = contentType;
			this.Form = form;

			this.isSingleQuote = isSingleQuote;
		}

	}
	#endregion

}
