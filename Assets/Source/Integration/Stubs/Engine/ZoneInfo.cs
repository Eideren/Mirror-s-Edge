namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ZoneInfo : Info/*
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	[Category] public float KillZ;
	[Category] public float SoftKill;
	[Category] public Core.ClassT<KillZDamageType> KillZDamageType;
	[Category] public bool bSoftKillZ;
	
	public ZoneInfo()
	{
		var Default__ZoneInfo_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__ZoneInfo.Sprite' */;
		// Object Offset:0x0046098A
		KillZ = -262143.0f;
		SoftKill = 2500.0f;
		KillZDamageType = ClassT<KillZDamageType>()/*Ref Class'KillZDamageType'*/;
		bStatic = true;
		bNoDelete = true;
		bGameRelevant = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__ZoneInfo_Sprite/*Ref SpriteComponent'Default__ZoneInfo.Sprite'*/,
		};
	}
}
}