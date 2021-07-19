namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ParentalEmail : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIEditBox ParentalEmailEditbox;
	public /*delegate*/TdUIScene_ParentalEmail.ConfirmParentalEmail __ConfirmParentalEmail__Delegate;
	public /*delegate*/TdUIScene_ParentalEmail.UserAbort __UserAbort__Delegate;
	
	public delegate void ConfirmParentalEmail(String Email);
	
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
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_EditEditbox(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed_UserAbort(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void TryContinue()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed_TryContinue(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void OnEditEditbox()
	{
		// stub
	}
	
	public virtual /*function */void OnKeyboardInput_Complete(bool bWasSuccessful)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_ParentalEmail()
	{
		var Default__TdUIScene_ParentalEmail_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_ParentalEmail.SceneEventComponent' */;
		// Object Offset:0x006A52E5
		EventProvider = Default__TdUIScene_ParentalEmail_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_ParentalEmail.SceneEventComponent'*/;
	}
}
}