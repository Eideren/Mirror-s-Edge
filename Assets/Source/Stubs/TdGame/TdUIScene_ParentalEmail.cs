namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ParentalEmail : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIEditBox ParentalEmailEditbox;
	public /*delegate*/TdUIScene_ParentalEmail.ConfirmParentalEmail __ConfirmParentalEmail__Delegate;
	public /*delegate*/TdUIScene_ParentalEmail.UserAbort __UserAbort__Delegate;
	
	public delegate void ConfirmParentalEmail(String Email);
	
	public delegate void UserAbort();
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Cancel(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_EditEditbox(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public virtual /*function */void OnSceneClosed_UserAbort(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */void TryContinue()
	{
	
	}
	
	public virtual /*function */void OnSceneClosed_TryContinue(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */void OnEditEditbox()
	{
	
	}
	
	public virtual /*function */void OnKeyboardInput_Complete(bool bWasSuccessful)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_ParentalEmail()
	{
		// Object Offset:0x006A52E5
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_ParentalEmail.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_ParentalEmail.SceneEventComponent'*/;
	}
}
}