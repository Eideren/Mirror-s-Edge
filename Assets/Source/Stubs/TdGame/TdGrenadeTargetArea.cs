namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGrenadeTargetArea : TdGrenadeArea/*
		native
		placeable
		hidecategories(Navigation)*/{
	public enum EThrowType 
	{
		EGThrow_Normal,
		EGThrow_Low,
		EGThrow_MAX
	};
	
	public enum EGrenadeType 
	{
		ESmokeGrenade,
		EFlashBang,
		ETargetExplosive,
		EGrenadeType_MAX
	};
	
	public/*()*/ TdGrenadeTargetArea.EGrenadeType GrenadeType;
	public/*()*/ TdGrenadeTargetArea.EThrowType TypeOfThrow;
	public/*()*/ array<NavigationPoint> GrenadeNodes;
	public/*()*/ array<TdGrenadeArea> TriggerAreas;
	public/*()*/ bool bForceAIThrow;
	public/*()*/ bool bUsePlayerAsTarget;
	public/*()*/ bool bOnlyUseOnce;
	public/*()*/ float ThrowSpeedTweak;
	public/*()*/ float YawAngleTweak;
	public/*()*/ float TimeToExplode;
	public Object.Color NodeLinkColor;
	public Object.Color TriggerLinkColor;
	
	// Export UTdGrenadeTargetArea::execIsPawnInArea(FFrame&, void* const)
	public virtual /*native function */bool IsPawnInArea(Pawn inPawn)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public virtual /*event */void ThrowGrenade()
	{
		// stub
	}
	
	public TdGrenadeTargetArea()
	{
		var Default__TdGrenadeTargetArea_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdGrenadeTargetArea.Sprite' */;
		var Default__TdGrenadeTargetArea_Renderer = new TdGrenadeTargetAreaRenderingComponent
		{
		}/* Reference: TdGrenadeTargetAreaRenderingComponent'Default__TdGrenadeTargetArea.Renderer' */;
		// Object Offset:0x00544F65
		ThrowSpeedTweak = -100.0f;
		TimeToExplode = -1.0f;
		NodeLinkColor = new Color
		{
			R=255,
			G=255,
			B=0,
			A=0
		};
		TriggerLinkColor = new Color
		{
			R=0,
			G=0,
			B=255,
			A=0
		};
		AreaColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=0
		};
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdGrenadeTargetArea_Sprite/*Ref SpriteComponent'Default__TdGrenadeTargetArea.Sprite'*/,
			Default__TdGrenadeTargetArea_Renderer/*Ref TdGrenadeTargetAreaRenderingComponent'Default__TdGrenadeTargetArea.Renderer'*/,
		};
	}
}
}