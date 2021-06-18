namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpeedTreeActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */SpeedTreeComponent SpeedTreeComponent;
	
	public SpeedTreeActor()
	{
		var Default__SpeedTreeActor_SpeedTreeComponent0 = new SpeedTreeComponent
		{
			// Object Offset:0x004CF3CE
			bAllowApproximateOcclusion = true,
			bForceDirectLightMap = true,
			bCastDynamicShadow = false,
		}/* Reference: SpeedTreeComponent'Default__SpeedTreeActor.SpeedTreeComponent0' */;
		// Object Offset:0x003ECB28
		SpeedTreeComponent = Default__SpeedTreeActor_SpeedTreeComponent0;
		bStatic = true;
		bNoDelete = true;
		bWorldGeometry = true;
		bMovable = false;
		bCollideActors = true;
		bBlockActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SpeedTreeActor_SpeedTreeComponent0,
		};
		CollisionComponent = Default__SpeedTreeActor_SpeedTreeComponent0;
	}
}
}