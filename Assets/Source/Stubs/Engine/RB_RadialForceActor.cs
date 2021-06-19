namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_RadialForceActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public enum ERadialForceType 
	{
		RFT_Force,
		RFT_Impulse,
		RFT_MAX
	};
	
	public /*export editinline */DrawSphereComponent RenderComponent;
	public/*()*/ /*interp */float ForceStrength;
	public/*()*/ /*interp */float ForceRadius;
	public/*()*/ /*interp */float SwirlStrength;
	public/*()*/ /*interp */float SpinTorque;
	public/*()*/ /*export */PrimitiveComponent.ERadialImpulseFalloff ForceFalloff;
	public/*()*/ RB_RadialForceActor.ERadialForceType RadialForceMode;
	public/*()*/ bool bForceActive;
	public/*()*/ bool bForceApplyToCloth;
	public/*()*/ bool bForceApplyToFluid;
	public/*()*/ bool bForceApplyToRigidBodies;
	public/*()*/ bool bForceApplyToProjectiles;
	public/*()*/ int ForceFieldChannel;
	public/*()*/ /*const */PrimitiveComponent.RBCollisionChannelContainer CollideWithChannels;
	
	//replication
	//{
	//	 if(bNetDirty)
	//		bForceActive;
	//}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle inAction)
	{
	
	}
	
	public RB_RadialForceActor()
	{
		var Default__RB_RadialForceActor_DrawSphere0 = new DrawSphereComponent
		{
			// Object Offset:0x00468CBF
			SphereColor = new Color
			{
				R=64,
				G=70,
				B=255,
				A=255
			},
			SphereRadius = 200.0f,
		}/* Reference: DrawSphereComponent'Default__RB_RadialForceActor.DrawSphere0' */;
		var Default__RB_RadialForceActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D03DA
			Sprite = LoadAsset<Texture2D>("EngineResources.S_RadForce")/*Ref Texture2D'EngineResources.S_RadForce'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__RB_RadialForceActor.Sprite' */;
		// Object Offset:0x003AEE49
		RenderComponent = Default__RB_RadialForceActor_DrawSphere0/*Ref DrawSphereComponent'Default__RB_RadialForceActor.DrawSphere0'*/;
		ForceStrength = 10.0f;
		ForceRadius = 200.0f;
		bForceApplyToCloth = true;
		bForceApplyToFluid = true;
		bForceApplyToRigidBodies = true;
		ForceFieldChannel = 1;
		CollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
		{
			Default = true,
			Nothing = false,
			Pawn = true,
			Vehicle = true,
			Water = true,
			GameplayPhysics = true,
			EffectPhysics = true,
			Untitled1 = true,
			Untitled2 = true,
			Untitled3 = true,
			Untitled4 = true,
			Cloth = true,
			FluidDrain = true,
		};
		bNoDelete = true;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_RadialForceActor_DrawSphere0/*Ref DrawSphereComponent'Default__RB_RadialForceActor.DrawSphere0'*/,
			Default__RB_RadialForceActor_Sprite/*Ref SpriteComponent'Default__RB_RadialForceActor.Sprite'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 0.10f;
	}
}
}