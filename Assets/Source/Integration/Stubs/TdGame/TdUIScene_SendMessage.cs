namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SendMessage : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIEditBox PlayerNameEditBox;
	[transient] public String TargetPlayerName;
	[transient] public OnlineSubsystem.UniqueNetId TargetPlayerNetId;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Cancel(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_AddFriend(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetTargetPlayer(OnlineSubsystem.UniqueNetId InPlayerNetId, String InPlayerName)
	{
		// stub
	}
	
	public virtual /*function */void AddFriend()
	{
		// stub
	}
	
	public virtual /*function */void OnAddFriendByNameComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*function */void OnFinishedAddFriend()
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_SendMessage()
	{
		var Default__TdUIScene_SendMessage_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_SendMessage.SceneEventComponent' */;
		// Object Offset:0x006A6193
		EventProvider = Default__TdUIScene_SendMessage_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_SendMessage.SceneEventComponent'*/;
	}
}
}