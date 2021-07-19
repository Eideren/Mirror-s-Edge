namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Info : Actor/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public partial struct /*native export transient */KeyValuePair
	{
		[Category] [init] public String Key;
		[Category] [init] public String Value;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0025DC5C
	//		Key = "";
	//		Value = "";
	//	}
	};
	
	public partial struct /*native export transient */PlayerResponseLine
	{
		[Category] [init] public int PlayerNum;
		[Category] [init] public int PlayerId;
		[Category] [init] public String PlayerName;
		[Category] [init] public int Ping;
		[Category] [init] public int Score;
		[Category] [init] public int StatsID;
		[Category] [init] public array<Info.KeyValuePair> PlayerInfo;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0025DE34
	//		PlayerNum = 0;
	//		PlayerId = 0;
	//		PlayerName = "";
	//		Ping = 0;
	//		Score = 0;
	//		StatsID = 0;
	//		PlayerInfo = default;
	//	}
	};
	
	public partial struct /*native export transient */ServerResponseLine
	{
		[Category] [init] public int ServerID;
		[Category] [init] public String IP;
		[Category] [init] public int Port;
		[Category] [init] public int QueryPort;
		[Category] [init] public String ServerName;
		[Category] [init] public String MapName;
		[Category] [init] public String GameType;
		[Category] [init] public int CurrentPlayers;
		[Category] [init] public int MaxPlayers;
		[Category] [init] public int Ping;
		[Category] [init] public array<Info.KeyValuePair> ServerInfo;
		[Category] [init] public array<Info.PlayerResponseLine> PlayerInfo;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0025E1A8
	//		ServerID = 0;
	//		IP = "";
	//		Port = 0;
	//		QueryPort = 0;
	//		ServerName = "";
	//		MapName = "";
	//		GameType = "";
	//		CurrentPlayers = 0;
	//		MaxPlayers = 0;
	//		Ping = 0;
	//		ServerInfo = default;
	//		PlayerInfo = default;
	//	}
	};
	
	public Info()
	{
		var Default__Info_Sprite = new SpriteComponent
		{
			// Object Offset:0x0025E453
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__Info.Sprite' */;
		// Object Offset:0x0025E330
		bHidden = true;
		bSkipActorPropertyReplication = true;
		bOnlyDirtyReplication = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Info_Sprite/*Ref SpriteComponent'Default__Info.Sprite'*/,
		};
		NetUpdateFrequency = 10.0f;
	}
}
}