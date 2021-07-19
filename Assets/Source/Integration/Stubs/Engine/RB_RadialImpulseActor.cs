namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_RadialImpulseActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	[export, editinline] public DrawSphereComponent RenderComponent;
	[Category] [Const, editconst, export, editinline] public RB_RadialImpulseComponent ImpulseComponent;
	[repnotify] public byte ImpulseCount;
	
	//replication
	//{
	//	 if(bNetDirty)
	//		ImpulseCount;
	//}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle inAction)
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public RB_RadialImpulseActor()
	{
		var Default__RB_RadialImpulseActor_DrawSphere0 = new DrawSphereComponent
		{
		}/* Reference: DrawSphereComponent'Default__RB_RadialImpulseActor.DrawSphere0' */;
		var Default__RB_RadialImpulseActor_ImpulseComponent0 = new RB_RadialImpulseComponent
		{
			// Object Offset:0x004CE596
			PreviewSphere = Default__RB_RadialImpulseActor_DrawSphere0/*Ref DrawSphereComponent'Default__RB_RadialImpulseActor.DrawSphere0'*/,
		}/* Reference: RB_RadialImpulseComponent'Default__RB_RadialImpulseActor.ImpulseComponent0' */;
		var Default__RB_RadialImpulseActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D0462
			Sprite = LoadAsset<Texture2D>("EngineResources.S_RadImpulse")/*Ref Texture2D'EngineResources.S_RadImpulse'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__RB_RadialImpulseActor.Sprite' */;
		// Object Offset:0x003AF606
		RenderComponent = Default__RB_RadialImpulseActor_DrawSphere0/*Ref DrawSphereComponent'Default__RB_RadialImpulseActor.DrawSphere0'*/;
		ImpulseComponent = Default__RB_RadialImpulseActor_ImpulseComponent0/*Ref RB_RadialImpulseComponent'Default__RB_RadialImpulseActor.ImpulseComponent0'*/;
		bNoDelete = true;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_RadialImpulseActor_DrawSphere0/*Ref DrawSphereComponent'Default__RB_RadialImpulseActor.DrawSphere0'*/,
			Default__RB_RadialImpulseActor_ImpulseComponent0/*Ref RB_RadialImpulseComponent'Default__RB_RadialImpulseActor.ImpulseComponent0'*/,
			Default__RB_RadialImpulseActor_Sprite/*Ref SpriteComponent'Default__RB_RadialImpulseActor.Sprite'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 0.10f;
	}
}
}