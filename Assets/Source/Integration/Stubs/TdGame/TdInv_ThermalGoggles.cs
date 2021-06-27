namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInv_ThermalGoggles : TdEquipment/*
		notplaceable
		hidecategories(Navigation)*/{
	public TdInv_ThermalGoggles()
	{
		var Default__TdInv_ThermalGoggles_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdInv_ThermalGoggles.Sprite' */;
		// Object Offset:0x0057CF2D
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdInv_ThermalGoggles_Sprite/*Ref SpriteComponent'Default__TdInv_ThermalGoggles.Sprite'*/,
		};
	}
}
}