namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdExplosiveTargetArea : TdGrenadeTargetArea/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ Actor TargetActor;
	public/*()*/ Object.Vector OffsetFromTargetActorsPivot;
	public Object.Color ExplosiveLinkColor;
	
	public TdExplosiveTargetArea()
	{
		// Object Offset:0x005451A0
		ExplosiveLinkColor = new Color
		{
			R=255,
			G=0,
			B=255,
			A=0
		};
		GrenadeType = TdGrenadeTargetArea.EGrenadeType.ETargetExplosive;
		Radius = 400.0f;
		AreaColor = new Color
		{
			R=255,
			G=0,
			B=255,
			A=0
		};
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdExplosiveTargetArea.Sprite")/*Ref SpriteComponent'Default__TdExplosiveTargetArea.Sprite'*/,
			LoadAsset<TdGrenadeTargetAreaRenderingComponent>("Default__TdExplosiveTargetArea.Renderer")/*Ref TdGrenadeTargetAreaRenderingComponent'Default__TdExplosiveTargetArea.Renderer'*/,
		};
	}
}
}