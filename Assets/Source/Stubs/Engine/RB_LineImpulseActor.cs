namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_LineImpulseActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ float ImpulseStrength;
	public/*()*/ float ImpulseRange;
	public/*()*/ bool bVelChange;
	public/*()*/ bool bStopAtFirstHit;
	public /*export editinline */ArrowComponent Arrow;
	public /*repnotify */byte ImpulseCount;
	
	//replication
	//{
	//	 if(bNetDirty)
	//		ImpulseCount;
	//}
	
	// Export URB_LineImpulseActor::execFireLineImpulse(FFrame&, void* const)
	public virtual /*native final function */void FireLineImpulse()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle inAction)
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public RB_LineImpulseActor()
	{
		var Default__RB_LineImpulseActor_ArrowComponent0 = new ArrowComponent
		{
			// Object Offset:0x00465D07
			ArrowSize = 4.166670f,
		}/* Reference: ArrowComponent'Default__RB_LineImpulseActor.ArrowComponent0' */;
		var Default__RB_LineImpulseActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D02EA
			Sprite = LoadAsset<Texture2D>("EngineResources.S_LineImpulse")/*Ref Texture2D'EngineResources.S_LineImpulse'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__RB_LineImpulseActor.Sprite' */;
		// Object Offset:0x003AE54B
		ImpulseStrength = 900.0f;
		ImpulseRange = 200.0f;
		Arrow = Default__RB_LineImpulseActor_ArrowComponent0/*Ref ArrowComponent'Default__RB_LineImpulseActor.ArrowComponent0'*/;
		bNoDelete = true;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_LineImpulseActor_ArrowComponent0/*Ref ArrowComponent'Default__RB_LineImpulseActor.ArrowComponent0'*/,
			Default__RB_LineImpulseActor_Sprite/*Ref SpriteComponent'Default__RB_LineImpulseActor.Sprite'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetUpdateFrequency = 0.10f;
	}
}
}