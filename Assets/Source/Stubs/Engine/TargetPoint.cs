namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TargetPoint : Keypoint/*
		placeable
		hidecategories(Navigation)*/{
	public TargetPoint()
	{
		// Object Offset:0x003F745A
		bStatic = false;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x004D0656
				Sprite = LoadAsset<Texture2D>("EditorMaterials.TargetIcon")/*Ref Texture2D'EditorMaterials.TargetIcon'*/,
				Scale = 0.350f,
			}/* Reference: SpriteComponent'Default__TargetPoint.Sprite' */,
		};
	}
}
}