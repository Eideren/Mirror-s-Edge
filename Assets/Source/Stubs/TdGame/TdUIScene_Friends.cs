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
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */void UpdateButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_AddFriend(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_RemoveFriend(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */bool GetCurrentFriendNick(ref String FriendNick)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */bool GetCurrentFriendNetId(ref OnlineSubsystem.UniqueNetId FriendNetId)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void AddFriend()
	{
		// stub
	}
	
	public virtual /*private final function */void RemoveFriend()
	{
		// stub
	}
	
	public virtual /*private final function */void RemoveFriend_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnRemoveFriend_MsgBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnRemoveFriend_Confirm()
	{
		// stub
	}
	
	public virtual /*private final function */void RefreshList()
	{
		// stub
	}
	
	public virtual /*private final function */bool OnFriendsList_Updated(UIObject Sender, int BindingIndex)
	{
		// stub
		return default;
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