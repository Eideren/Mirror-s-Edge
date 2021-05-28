namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdCreateLobby : UIAction/*
		native
		hidecategories(Object)*/{
	public string LobbyLevel;
	public string LobbyGameMode;
	
	public UIAction_TdCreateLobby()
	{
		// Object Offset:0x006D1DCA
		LobbyLevel = "TdLobby";
		LobbyGameMode = "TdGame.TdLobbyGameInfo";
		bAutoTargetOwner = true;
		ObjName = "Create Lobby";
		ObjCategory = "Takedown";
	}
}
}