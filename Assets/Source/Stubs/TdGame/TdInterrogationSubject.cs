namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInterrogationSubject : Actor/*
		notplaceable
		hidecategories(Navigation)*/{
	public /*private */float StartTime;
	public /*private */float Duration;
	public /*private */float Lifetime;
	public /*private */TdPursuitPRI VictimPRI;
	public /*private */Pawn VictimPawn;
	public /*private */TdPursuitPRI InstigatorPRI;
	public /*private */Pawn InstigatorPawn;
	
	public override /*event */void PreBeginPlay()
	{
	
	}
	
	public virtual /*private final function */void InitiateInterrogation(Actor InstigatingActor)
	{
	
	}
	
	public virtual /*function */void SetVictimPRI(TdPursuitPRI NewVictimPRI)
	{
	
	}
	
	public virtual /*function */void SetVictimPawn(TdPawn NewVictimPawn)
	{
	
	}
	
	public virtual /*function */void TimeDestroy()
	{
	
	}
	
	public delegate void InterceptInterrogation_del();
	public virtual InterceptInterrogation_del InterceptInterrogation { get => bfield_InterceptInterrogation ?? TdInterrogationSubject_InterceptInterrogation; set => bfield_InterceptInterrogation = value; } InterceptInterrogation_del bfield_InterceptInterrogation;
	public virtual InterceptInterrogation_del global_InterceptInterrogation => TdInterrogationSubject_InterceptInterrogation;
	public /*function */void TdInterrogationSubject_InterceptInterrogation()
	{
	
	}
	
	public delegate void CompleteInterrogation_del();
	public virtual CompleteInterrogation_del CompleteInterrogation { get => bfield_CompleteInterrogation ?? (()=>{}); set => bfield_CompleteInterrogation = value; } CompleteInterrogation_del bfield_CompleteInterrogation;
	public virtual CompleteInterrogation_del global_CompleteInterrogation => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		InterceptInterrogation = null;
	
	}
	
	protected /*singular event */void TdInterrogationSubject_Idle_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Idle()/*auto state Idle*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*singular event */void TdInterrogationSubject_Interrogating_UnTouch(Actor Other)// state function
	{
	
	}
	
	protected /*private final function */void TdInterrogationSubject_Interrogating_CompleteInterrogation()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Interrogating()/*state Interrogating*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Idle": return Idle();
			case "Interrogating": return Interrogating();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return Idle();
	}
	public TdInterrogationSubject()
	{
		var Default__TdInterrogationSubject_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB4B9A
			CollisionHeight = 60.0f,
			CollisionRadius = 60.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__TdInterrogationSubject.CollisionCylinder' */;
		// Object Offset:0x0057C880
		Duration = 6.0f;
		Lifetime = 25.0f;
		bIgnoreRigidBodyPawns = true;
		bCollideActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdInterrogationSubject_CollisionCylinder/*Ref CylinderComponent'Default__TdInterrogationSubject.CollisionCylinder'*/,
		};
		TickGroup = Object.ETickingGroup.TG_PostAsyncWork;
		CollisionComponent = Default__TdInterrogationSubject_CollisionCylinder/*Ref CylinderComponent'Default__TdInterrogationSubject.CollisionCylinder'*/;
	}
}
}