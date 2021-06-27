namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_TOS : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public const int MAX_CHARS_IN_STRING_BLOB = 5000;
	public const int NUM_BLOBS = 10;
	
	public /*transient */UIScrollFrame ScrollFrame;
	public /*delegate*/TdUIScene_TOS.AcceptTOS __AcceptTOS__Delegate;
	public /*delegate*/TdUIScene_TOS.UserAbort __UserAbort__Delegate;
	
	public delegate void AcceptTOS(bool Accept);
	
	public delegate void UserAbort();
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Cancel(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Accept(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetTOSMessage(String Message)
	{
		// stub
	}
	
	public virtual /*function */void OnAcceptTOS()
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene_Accept(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void OnCancelTOS()
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene_Cancel(UIScene ClosedScene)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_TOS()
	{
		var Default__TdUIScene_TOS_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_TOS.SceneEventComponent' */;
		// Object Offset:0x006B459F
		EventProvider = Default__TdUIScene_TOS_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_TOS.SceneEventComponent'*/;
	}
}
}