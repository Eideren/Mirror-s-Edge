namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SendMessage : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIEditBox PlayerNameEditBox;
	public /*transient */String TargetPlayerName;
	public /*transient */OnlineSubsystem.UniqueNetId TargetPlayerNetId;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Cancel(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_AddFriend(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void SetTargetPlayer(OnlineSubsystem.UniqueNetId InPlayerNetId, String InPlayerName)
	{
	
	}
	
	public virtual /*function */void AddFriend()
	{
	
	}
	
	public virtual /*function */void OnAddFriendByNameComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*function */void OnFinishedAddFriend()
	{
	
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_SendMessage()
	{
		// Object Offset:0x006A6193
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_SendMessage.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_SendMessage.SceneEventComponent'*/;
	}
}
}