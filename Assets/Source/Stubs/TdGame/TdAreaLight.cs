namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAreaLight : PointLight/*
		native
		placeable
		hidecategories(Navigation)*/{
	public /*export editinline */DrawBoxComponent BoxComponent;
	public/*(Baker)*/ bool bIsWindowLight;
	public/*(Baker)*/ float WindowLightAngle;
	
	public TdAreaLight()
	{
		var Default__TdAreaLight_DrawBoxComponent0 = new DrawBoxComponent
		{
			// Object Offset:0x01B683E2
			BoxExtent = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: DrawBoxComponent'Default__TdAreaLight.DrawBoxComponent0' */;
		var Default__TdAreaLight_PointLightComponent0 = new PointLightComponent
		{
			// Object Offset:0x01D76313
			PreviewLightRadius = LoadAsset<DrawLightRadiusComponent>("Default__TdAreaLight.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__TdAreaLight.DrawLightRadius0'*/,
		}/* Reference: PointLightComponent'Default__TdAreaLight.PointLightComponent0' */;
		var Default__TdAreaLight_DrawLightRadius0 = new DrawLightRadiusComponent
		{
			// Object Offset:0x01B6857E
			Scale3D = new Vector
			{
				X=0.010f,
				Y=0.010f,
				Z=0.010f
			},
		}/* Reference: DrawLightRadiusComponent'Default__TdAreaLight.DrawLightRadius0' */;
		var Default__TdAreaLight_ArrowComponent0 = new ArrowComponent
		{
			// Object Offset:0x01AB4066
			ArrowColor = new Color
			{
				R=150,
				G=200,
				B=255,
				A=255
			},
			Rotation = new Rotator
			{
				Pitch=0,
				Yaw=-16384,
				Roll=0
			},
			Scale3D = new Vector
			{
				X=1.0f,
				Y=0.010f,
				Z=0.010f
			},
		}/* Reference: ArrowComponent'Default__TdAreaLight.ArrowComponent0' */;
		// Object Offset:0x00509407
		BoxComponent = Default__TdAreaLight_DrawBoxComponent0;
		WindowLightAngle = 0.20f;
		LightComponent = Default__TdAreaLight_PointLightComponent0;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdAreaLight.Sprite")/*Ref SpriteComponent'Default__TdAreaLight.Sprite'*/,
			Default__TdAreaLight_DrawLightRadius0,
			Default__TdAreaLight_PointLightComponent0,
			Default__TdAreaLight_DrawBoxComponent0,
			Default__TdAreaLight_ArrowComponent0,
		};
		Rotation = new Rotator
		{
			Pitch=0,
			Yaw=0,
			Roll=-16384
		};
		DrawScale3D = new Vector
		{
			X=100.0f,
			Y=1.0f,
			Z=100.0f
		};
		DesiredRotation = new Rotator
		{
			Pitch=0,
			Yaw=0,
			Roll=-16384
		};
	}
}
}