namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_RadialImpulseActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public /*export editinline */DrawSphereComponent RenderComponent;
	public/*()*/ /*const editconst export editinline */RB_RadialImpulseComponent ImpulseComponent;
	public /*repnotify */byte ImpulseCount;
	
	//replication
	//{
	//	 if(bNetDirty)
	//		ImpulseCount;
	//}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle inAction)
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	public RB_RadialImpulseActor()
	{
		var Default__RB_RadialImpulseActor_ImpulseComponent0 = new RB_RadialImpulseComponent
		{
			// Object Offset:0x004CE596
			PreviewSphere = LoadAsset<DrawSphereComponent>("Default__RB_RadialImpulseActor.DrawSphere0")/*Ref DrawSphereComponent'Default__RB_RadialImpulseActor.DrawSphere0'*/,
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
		RenderComponent = LoadAsset<DrawSphereComponent>("Default__RB_RadialImpulseActor.DrawSphere0")/*Ref DrawSphereComponent'Default__RB_RadialImpulseActor.DrawSphere0'*/;
		ImpulseComponent = Default__RB_RadialImpulseActor_ImpulseComponent0;
		bNoDelete = true;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DrawSphereComponent>("Default__RB_RadialImpulseActor.DrawSphere0")/*Ref DrawSphereComponent'Default__RB_RadialImpulseActor.DrawSphere0'*/,
			Default__RB_RadialImpulseActor_ImpulseComponent0,
			Default__RB_RadialImpulseActor_Sprite,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 0.10f;
	}
}
}