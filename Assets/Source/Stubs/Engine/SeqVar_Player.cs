namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_Player : SeqVar_Object/*
		native
		hidecategories(Object)*/{
	public /*transient */array<Object> Players;
	public/*()*/ bool bAllPlayers;
	public/*()*/ int PlayerIdx;
	
	public override /*function */Object GetObjectValue()
	{
	
		return default;
	}
	
	public SeqVar_Player()
	{
		// Object Offset:0x003E0F85
		bAllPlayers = true;
		SupportedClasses = new array< Class >
		{
			ClassT<Controller>(),
			ClassT<Pawn>(),
		};
		ObjName = "Player";
	}
}
}