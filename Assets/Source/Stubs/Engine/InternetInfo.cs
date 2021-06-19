namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InternetInfo : Info/*
		transient
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public virtual /*function */String GetBeaconAddress(int I)
	{
	
		return default;
	}
	
	public virtual /*function */String GetBeaconText(int I)
	{
	
		return default;
	}
	
	public InternetInfo()
	{
		var Default__InternetInfo_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__InternetInfo.Sprite' */;
		// Object Offset:0x0033E0EF
		Components = new array</*export editinline */ActorComponent>
		{
			Default__InternetInfo_Sprite/*Ref SpriteComponent'Default__InternetInfo.Sprite'*/,
		};
	}
}
}