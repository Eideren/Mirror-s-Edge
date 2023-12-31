namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_ConstraintActor : Actor/*
		abstract
		native
		placeable
		hidecategories(Navigation)*/{
	[Category] public Actor ConstraintActor1;
	[Category] public Actor ConstraintActor2;
	[Category] [noclear, export, editinline] public RB_ConstraintSetup ConstraintSetup;
	[Category] [noclear, export, editinline] public RB_ConstraintInstance ConstraintInstance;
	[Category] [Const] public bool bDisableCollision;
	[Category] public bool bUpdateActor1RefFrame;
	[Category] public bool bUpdateActor2RefFrame;
	[Category("Pulley")] public Actor PulleyPivotActor1;
	[Category("Pulley")] public Actor PulleyPivotActor2;
	
	// Export URB_ConstraintActor::execSetDisableCollision(FFrame&, void* const)
	public virtual /*native final function */void SetDisableCollision(bool NewDisableCollision)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintActor::execInitConstraint(FFrame&, void* const)
	public virtual /*native final function */void InitConstraint(Actor Actor1, Actor Actor2, /*optional */name? _Actor1Bone = default, /*optional */name? _Actor2Bone = default, /*optional */float? _BreakThreshold = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_ConstraintActor::execTermConstraint(FFrame&, void* const)
	public virtual /*native final function */void TermConstraint()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*simulated function */void OnDestroy(SeqAct_Destroy Action)
	{
		// stub
	}
	
	public RB_ConstraintActor()
	{
		var Default__RB_ConstraintActor_MyConstraintInstance = new RB_ConstraintInstance
		{
		}/* Reference: RB_ConstraintInstance'Default__RB_ConstraintActor.MyConstraintInstance' */;
		var Default__RB_ConstraintActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x003AC32E
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__RB_ConstraintActor.Sprite' */;
		var Default__RB_ConstraintActor_MyConDrawComponent = new RB_ConstraintDrawComponent
		{
		}/* Reference: RB_ConstraintDrawComponent'Default__RB_ConstraintActor.MyConDrawComponent' */;
		// Object Offset:0x003AC11B
		ConstraintInstance = Default__RB_ConstraintActor_MyConstraintInstance/*Ref RB_ConstraintInstance'Default__RB_ConstraintActor.MyConstraintInstance'*/;
		bUpdateActor1RefFrame = true;
		bUpdateActor2RefFrame = true;
		bHidden = true;
		bNoDelete = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_ConstraintActor_Sprite/*Ref SpriteComponent'Default__RB_ConstraintActor.Sprite'*/,
			Default__RB_ConstraintActor_MyConDrawComponent/*Ref RB_ConstraintDrawComponent'Default__RB_ConstraintActor.MyConDrawComponent'*/,
		};
		Physics = Actor.EPhysics.PHYS_RigidBody;
		TickGroup = Object.ETickingGroup.TG_PostAsyncWork;
		DrawScale = 0.50f;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvent_ConstraintBroken>(),
		};
	}
}
}