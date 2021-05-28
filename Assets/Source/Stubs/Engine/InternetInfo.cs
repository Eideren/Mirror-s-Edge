namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InternetInfo : Info/*
		transient
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public virtual /*function */string GetBeaconAddress(int I)
	{
	
		return default;
	}
	
	public virtual /*function */string GetBeaconText(int I)
	{
	
		return default;
	}
	
	public InternetInfo()
	{
		// Object Offset:0x0033E0EF
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__InternetInfo.Sprite")/*Ref SpriteComponent'Default__InternetInfo.Sprite'*/,
		};
	}
}
}