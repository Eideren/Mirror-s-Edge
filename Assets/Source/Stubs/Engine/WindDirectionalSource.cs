namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class WindDirectionalSource : Info/*
		placeable
		hidecategories(Navigation,Movement,Collision)*/{
	public/*()*/ /*const editconst export editinline */WindDirectionalSourceComponent Component;
	
	public WindDirectionalSource()
	{
		// Object Offset:0x004607C7
		Component = LoadAsset<WindDirectionalSourceComponent>("Default__WindDirectionalSource.WindDirectionalSourceComponent0")/*Ref WindDirectionalSourceComponent'Default__WindDirectionalSource.WindDirectionalSourceComponent0'*/;
		bStatic = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__WindDirectionalSource.Sprite")/*Ref SpriteComponent'Default__WindDirectionalSource.Sprite'*/,
			LoadAsset<WindDirectionalSourceComponent>("Default__WindDirectionalSource.WindDirectionalSourceComponent0")/*Ref WindDirectionalSourceComponent'Default__WindDirectionalSource.WindDirectionalSourceComponent0'*/,
			//Components[2]=
			new ArrowComponent
			{
				// Object Offset:0x00465E2F
				ArrowColor = new Color
				{
					R=150,
					G=200,
					B=255,
					A=255
				},
			}/* Reference: ArrowComponent'Default__WindDirectionalSource.ArrowComponent0' */,
		};
	}
}
}