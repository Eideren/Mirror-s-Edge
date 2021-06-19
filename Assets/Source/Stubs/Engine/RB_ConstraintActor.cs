namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_ConstraintActor : Actor/*
		abstract
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ Actor ConstraintActor1;
	public/*()*/ Actor ConstraintActor2;
	public/*()*/ /*noclear export editinline */RB_ConstraintSetup ConstraintSetup;
	public/*()*/ /*noclear export editinline */RB_ConstraintInstance ConstraintInstance;
	public/*()*/ /*const */bool bDisableCollision;
	public/*()*/ bool bUpdateActor1RefFrame;
	public/*()*/ bool bUpdateActor2RefFrame;
	public/*(Pulley)*/ Actor PulleyPivotActor1;
	public/*(Pulley)*/ Actor PulleyPivotActor2;
	
	// Export URB_ConstraintActor::execSetDisableCollision(FFrame&, void* const)
	public virtual /*native final function */void SetDisableCollision(bool NewDisableCollision)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export URB_ConstraintActor::execInitConstraint(FFrame&, void* const)
	public virtual /*native final function */void InitConstraint(Actor Actor1, Actor Actor2, /*optional */name? _Actor1Bone = default, /*optional */name? _Actor2Bone = default, /*optional */float? _BreakThreshold = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export URB_ConstraintActor::execTermConstraint(FFrame&, void* const)
	public virtual /*native final function */void TermConstraint()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*simulated function */void OnDestroy(SeqAct_Destroy Action)
	{
	
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