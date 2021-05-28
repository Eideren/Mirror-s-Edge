namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_CylindricalForceActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*export editinline */DrawCylinderComponent RenderComponent;
	public/*()*/ /*interp */float RadialStrength;
	public/*()*/ /*interp */float RotationalStrength;
	public/*()*/ /*interp */float LiftStrength;
	public/*()*/ /*interp */float LiftFalloffHeight;
	public/*()*/ /*interp */float EscapeVelocity;
	public/*()*/ /*interp */float ForceRadius;
	public/*()*/ /*interp */float ForceTopRadius;
	public/*()*/ /*interp */float ForceHeight;
	public/*()*/ /*interp */float HeightOffset;
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
	
	public RB_CylindricalForceActor()
	{
		// Object Offset:0x003AD3E1
		RenderComponent = new DrawCylinderComponent
		{
			// Object Offset:0x004689FB
			CylinderRadius = 200.0f,
			CylinderTopRadius = 200.0f,
			CylinderHeight = 200.0f,
		}/* Reference: DrawCylinderComponent'Default__RB_CylindricalForceActor.DrawCylinder0' */;
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
			//Components[0]=
			new DrawCylinderComponent
			{
				// Object Offset:0x004689FB
				CylinderRadius = 200.0f,
				CylinderTopRadius = 200.0f,
				CylinderHeight = 200.0f,
			}/* Reference: DrawCylinderComponent'Default__RB_CylindricalForceActor.DrawCylinder0' */,
			//Components[1]=
			new SpriteComponent
			{
				// Object Offset:0x004D022E
				Sprite = LoadAsset<Texture2D>("EngineResources.S_RadForce")/*Ref Texture2D'EngineResources.S_RadForce'*/,
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__RB_CylindricalForceActor.Sprite' */,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 0.10f;
	}
}
}