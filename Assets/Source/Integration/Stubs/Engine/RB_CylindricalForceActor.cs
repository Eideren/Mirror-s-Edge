namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_CylindricalForceActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	[Category] [export, editinline] public DrawCylinderComponent RenderComponent;
	[Category] [interp] public float RadialStrength;
	[Category] [interp] public float RotationalStrength;
	[Category] [interp] public float LiftStrength;
	[Category] [interp] public float LiftFalloffHeight;
	[Category] [interp] public float EscapeVelocity;
	[Category] [interp] public float ForceRadius;
	[Category] [interp] public float ForceTopRadius;
	[Category] [interp] public float ForceHeight;
	[Category] [interp] public float HeightOffset;
	[Category] public bool bForceActive;
	[Category] public bool bForceApplyToCloth;
	[Category] public bool bForceApplyToFluid;
	[Category] public bool bForceApplyToRigidBodies;
	[Category] public bool bForceApplyToProjectiles;
	[Category] public int ForceFieldChannel;
	[Category] [Const] public PrimitiveComponent.RBCollisionChannelContainer CollideWithChannels;
	
	//replication
	//{
	//	 if(bNetDirty)
	//		bForceActive;
	//}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle inAction)
	{
		// stub
	}
	
	public RB_CylindricalForceActor()
	{
		var Default__RB_CylindricalForceActor_DrawCylinder0 = new DrawCylinderComponent
		{
			// Object Offset:0x004689FB
			CylinderRadius = 200.0f,
			CylinderTopRadius = 200.0f,
			CylinderHeight = 200.0f,
		}/* Reference: DrawCylinderComponent'Default__RB_CylindricalForceActor.DrawCylinder0' */;
		var Default__RB_CylindricalForceActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D022E
			Sprite = LoadAsset<Texture2D>("EngineResources.S_RadForce")/*Ref Texture2D'EngineResources.S_RadForce'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__RB_CylindricalForceActor.Sprite' */;
		// Object Offset:0x003AD3E1
		RenderComponent = Default__RB_CylindricalForceActor_DrawCylinder0/*Ref DrawCylinderComponent'Default__RB_CylindricalForceActor.DrawCylinder0'*/;
		EscapeVelocity = 10000.0f;
		ForceRadius = 200.0f;
		ForceTopRadius = 200.0f;
		ForceHeight = 200.0f;
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
			Untitled4 = false,
			Cloth = true,
			FluidDrain = true,
		};
		bNoDelete = true;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_CylindricalForceActor_DrawCylinder0/*Ref DrawCylinderComponent'Default__RB_CylindricalForceActor.DrawCylinder0'*/,
			Default__RB_CylindricalForceActor_Sprite/*Ref SpriteComponent'Default__RB_CylindricalForceActor.Sprite'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 0.10f;
	}
}
}