namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Friends : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIList FriendsList;
	public /*transient */UILabel NoFriendsLabel;
	public /*transient */UIDataStore_OnlinePlayerData PlayerData;
	public /*transient */bool bFriendsListEmpty;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */void UpdateButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_AddFriend(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_RemoveFriend(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*private final function */bool GetCurrentFriendNick(ref String FriendNick)
	{
	
		return default;
	}
	
	public virtual /*private final function */bool GetCurrentFriendNetId(ref OnlineSubsystem.UniqueNetId FriendNetId)
	{
	
		return default;
	}
	
	public virtual /*private final function */void AddFriend()
	{
	
	}
	
	public virtual /*private final function */void RemoveFriend()
	{
	
	}
	
	public virtual /*private final function */void RemoveFriend_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OnRemoveFriend_MsgBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnRemoveFriend_Confirm()
	{
	
	}
	
	public virtual /*private final function */void RefreshList()
	{
	
	}
	
	public virtual /*private final function */bool OnFriendsList_Updated(UIObject Sender, int BindingIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_Friends()
	{
		var Default__TdUIScene_Friends_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_Friends.SceneEventComponent' */;
		// Object Offset:0x006999F7
		EventProvider = Default__TdUIScene_Friends_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_Friends.SceneEventComponent'*/;
	}
}
}