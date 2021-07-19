namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class WindDirectionalSource : Info/*
		placeable
		hidecategories(Navigation,Movement,Collision)*/{
	[Category] [Const, editconst, export, editinline] public WindDirectionalSourceComponent Component;
	
	public WindDirectionalSource()
	{
		var Default__WindDirectionalSource_WindDirectionalSourceComponent0 = new WindDirectionalSourceComponent
		{
		}/* Reference: WindDirectionalSourceComponent'Default__WindDirectionalSource.WindDirectionalSourceComponent0' */;
		var Default__WindDirectionalSource_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__WindDirectionalSource.Sprite' */;
		var Default__WindDirectionalSource_ArrowComponent0 = new ArrowComponent
		{
			// Object Offset:0x00465E2F
			ArrowColor = new Color
			{
				R=150,
				G=200,
				B=255,
				A=255
			},
		}/* Reference: ArrowComponent'Default__WindDirectionalSource.ArrowComponent0' */;
		// Object Offset:0x004607C7
		Component = Default__WindDirectionalSource_WindDirectionalSourceComponent0/*Ref WindDirectionalSourceComponent'Default__WindDirectionalSource.WindDirectionalSourceComponent0'*/;
		bStatic = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__WindDirectionalSource_Sprite/*Ref SpriteComponent'Default__WindDirectionalSource.Sprite'*/,
			Default__WindDirectionalSource_WindDirectionalSourceComponent0/*Ref WindDirectionalSourceComponent'Default__WindDirectionalSource.WindDirectionalSourceComponent0'*/,
			Default__WindDirectionalSource_ArrowComponent0/*Ref ArrowComponent'Default__WindDirectionalSource.ArrowComponent0'*/,
		};
	}
}
}