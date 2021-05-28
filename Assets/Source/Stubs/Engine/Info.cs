namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Info : Actor/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public partial struct /*native export transient */KeyValuePair
	{
		public/*()*/ /*init */string Key;
		public/*()*/ /*init */string Value;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0025DC5C
	//		Key = "";
	//		Value = "";
	//	}
	};
	
	public partial struct /*native export transient */PlayerResponseLine
	{
		public/*()*/ /*init */int PlayerNum;
		public/*()*/ /*init */int PlayerId;
		public/*()*/ /*init */string PlayerName;
		public/*()*/ /*init */int Ping;
		public/*()*/ /*init */int Score;
		public/*()*/ /*init */int StatsID;
		public/*()*/ /*init */array<Info.KeyValuePair> PlayerInfo;
	
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
		public/*()*/ /*init */int ServerID;
		public/*()*/ /*init */string IP;
		public/*()*/ /*init */int Port;
		public/*()*/ /*init */int QueryPort;
		public/*()*/ /*init */string ServerName;
		public/*()*/ /*init */string MapName;
		public/*()*/ /*init */string GameType;
		public/*()*/ /*init */int CurrentPlayers;
		public/*()*/ /*init */int MaxPlayers;
		public/*()*/ /*init */int Ping;
		public/*()*/ /*init */array<Info.KeyValuePair> ServerInfo;
		public/*()*/ /*init */array<Info.PlayerResponseLine> PlayerInfo;
	
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
		// Object Offset:0x0025E330
		bHidden = true;
		bSkipActorPropertyReplication = true;
		bOnlyDirtyReplication = true;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x0025E453
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__Info.Sprite' */,
		};
		NetUpdateFrequency = 10.0f;
	}
}
}