namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_PrismaticActor : RB_ConstraintActor/*
		placeable
		hidecategories(Navigation)*/{
	public RB_PrismaticActor()
	{
		var Default__RB_PrismaticActor_MyPrismaticSetup = new RB_PrismaticSetup
		{
		}/* Reference: RB_PrismaticSetup'Default__RB_PrismaticActor.MyPrismaticSetup' */;
		var Default__RB_PrismaticActor_MyConstraintInstance = new RB_ConstraintInstance
		{
		}/* Reference: RB_ConstraintInstance'Default__RB_PrismaticActor.MyConstraintInstance' */;
		var Default__RB_PrismaticActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D0372
			Sprite = LoadAsset<Texture2D>("EngineResources.S_KPrismatic")/*Ref Texture2D'EngineResources.S_KPrismatic'*/,
		}/* Reference: SpriteComponent'Default__RB_PrismaticActor.Sprite' */;
		var Default__RB_PrismaticActor_MyConDrawComponent = new RB_ConstraintDrawComponent
		{
		}/* Reference: RB_ConstraintDrawComponent'Default__RB_PrismaticActor.MyConDrawComponent' */;
		var Default__RB_PrismaticActor_ArrowComponent0 = new ArrowComponent
		{
			// Object Offset:0x00465D3B
			ArrowColor = new Color
			{
				R=255,
				G=64,
				B=64,
				A=255
			},
		}/* Reference: ArrowComponent'Default__RB_PrismaticActor.ArrowComponent0' */;
		// Object Offset:0x003AE819
		ConstraintSetup = Default__RB_PrismaticActor_MyPrismaticSetup/*Ref RB_PrismaticSetup'Default__RB_PrismaticActor.MyPrismaticSetup'*/;
		ConstraintInstance = Default__RB_PrismaticActor_MyConstraintInstance/*Ref RB_ConstraintInstance'Default__RB_PrismaticActor.MyConstraintInstance'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_PrismaticActor_Sprite/*Ref SpriteComponent'Default__RB_PrismaticActor.Sprite'*/,
			Default__RB_PrismaticActor_MyConDrawComponent/*Ref RB_ConstraintDrawComponent'Default__RB_PrismaticActor.MyConDrawComponent'*/,
			Default__RB_PrismaticActor_ArrowComponent0/*Ref ArrowComponent'Default__RB_PrismaticActor.ArrowComponent0'*/,
		};
	}
}
}