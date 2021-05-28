namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DirectionalLight : Light/*
		native
		placeable
		hidecategories(Navigation)*/{
	public DirectionalLight()
	{
		// Object Offset:0x0030DBEE
		LightComponent = new DirectionalLightComponent
		{
			// Object Offset:0x0030DD59
			UseDirectLightMap = true,
		}/* Reference: DirectionalLightComponent'Default__DirectionalLight.DirectionalLightComponent0' */;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x0030DD25
				Sprite = LoadAsset<Texture2D>("EngineResources.LightIcons.Light_Directional_Stationary_UserSelected")/*Ref Texture2D'EngineResources.LightIcons.Light_Directional_Stationary_UserSelected'*/,
			}/* Reference: SpriteComponent'Default__DirectionalLight.Sprite' */,
			//Components[1]=
			new DirectionalLightComponent
			{
				// Object Offset:0x0030DD59
				UseDirectLightMap = true,
			}/* Reference: DirectionalLightComponent'Default__DirectionalLight.DirectionalLightComponent0' */,
			//Components[2]=
			new ArrowComponent
			{
				// Object Offset:0x0030DD95
				ArrowColor = new Color
				{
					R=150,
					G=200,
					B=255,
					A=255
				},
			}/* Reference: ArrowComponent'Default__DirectionalLight.ArrowComponent0' */,
		};
		Rotation = new Rotator
		{
			Pitch=-16384,
			Yaw=0,
			Roll=0
		};
		DesiredRotation = new Rotator
		{
			Pitch=-16384,
			Yaw=0,
			Roll=0
		};
	}
}
}