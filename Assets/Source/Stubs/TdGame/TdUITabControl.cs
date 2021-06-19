// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabControl : UITabControl/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public/*()*/ name DefaultTabWidgetTag;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*event */bool ActivatePage(UITabPage PageToActivate, int PlayerIndex, /*optional */bool? _bFocusPage = default)
	{
	
		return default;
	}
	
	public override /*function */bool ActivateBestTab(int PlayerIndex, /*optional */bool? _bFocusPage = default, /*optional */int? _StartIndex = default)
	{
	
		return default;
	}
	
	public virtual /*function */int FindPageIndexByTag(name TabTag)
	{
	
		return default;
	}
	
	public virtual /*function */bool ActivateTabByTag(name TabTag, /*optional */int? _PlayerIndex = default, /*optional */bool? _bFocusPage = default)
	{
	
		return default;
	}
	
	public virtual /*function */void RemoveTabByTag(name TabTag, /*optional */int? _PlayerIndex = default)
	{
	
	}
	
	public virtual /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUITabControl()
	{
		var Default__TdUITabControl_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUITabControl.WidgetEventComponent' */;
		// Object Offset:0x006B7A24
		EventProvider = Default__TdUITabControl_WidgetEventComponent/*Ref UIComp_Event'Default__TdUITabControl.WidgetEventComponent'*/;
		__OnRawInputKey__Delegate = HandleInputKey;
	}
}
}