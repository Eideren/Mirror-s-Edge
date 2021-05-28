namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInv_ThermalGoggles : TdEquipment/*
		notplaceable
		hidecategories(Navigation)*/{
	public TdInv_ThermalGoggles()
	{
		// Object Offset:0x0057CF2D
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdInv_ThermalGoggles.Sprite")/*Ref SpriteComponent'Default__TdInv_ThermalGoggles.Sprite'*/,
		};
	}
}
}