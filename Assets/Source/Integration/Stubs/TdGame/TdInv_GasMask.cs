namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInv_GasMask : TdEquipment/*
		notplaceable
		hidecategories(Navigation)*/{
	public TdInv_GasMask()
	{
		var Default__TdInv_GasMask_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdInv_GasMask.Sprite' */;
		// Object Offset:0x0057CAD2
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdInv_GasMask_Sprite/*Ref SpriteComponent'Default__TdInv_GasMask.Sprite'*/,
		};
	}
}
}