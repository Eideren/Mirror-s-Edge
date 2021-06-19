namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdStashpoint : Actor/*
		abstract
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public /*transient */TdStashpoint Next;
	public /*protected transient */TdStashpointListener Listener;
	public /*const */int TerritoryOfTeam;
	public float TimeOfStashingInitiated;
	public /*const */bool bNotifyKismet;
	public /*config */float StashDuration;
	public/*(Stashpoint)*/ int StashPointID;
	public int InitiatedTriggerCount;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		Next;
	//}
	
	public virtual /*function */void OnStartMatchInProgress()
	{
	
	}
	
	public virtual /*final function */float GetDuration()
	{
	
		return default;
	}
	
	public virtual /*final function */bool IsTeamTerritory(TeamInfo Info)
	{
	
		return default;
	}
	
	public virtual /*final function */void ClearStashInterceptTimer()
	{
	
	}
	
	public virtual /*final function */void ClearStashCompleteTimer()
	{
	
	}
	
	public virtual /*final function */void SetListener(TdStashpointListener InListener)
	{
	
	}
	
	public virtual /*private final function */void SendKismetEvent(Core.ClassT<SequenceEvent> EventType)
	{
	
	}
	
	public virtual /*private final function */void NotifyInitiated()
	{
	
	}
	
	public virtual /*private final function */void NotifyIntercepted()
	{
	
	}
	
	public virtual /*private final function */void NotifyCompleted()
	{
	
	}
	
	public virtual /*private final function */void NotifyProgressed()
	{
	
	}
	
	public delegate void InitiateStashing_del();
	public virtual InitiateStashing_del InitiateStashing { get => bfield_InitiateStashing ?? TdStashpoint_InitiateStashing; set => bfield_InitiateStashing = value; } InitiateStashing_del bfield_InitiateStashing;
	public virtual InitiateStashing_del global_InitiateStashing => TdStashpoint_InitiateStashing;
	public /*function */void TdStashpoint_InitiateStashing()
	{
	
	}
	
	public delegate void InterceptStashing_del();
	public virtual InterceptStashing_del InterceptStashing { get => bfield_InterceptStashing ?? TdStashpoint_InterceptStashing; set => bfield_InterceptStashing = value; } InterceptStashing_del bfield_InterceptStashing;
	public virtual InterceptStashing_del global_InterceptStashing => TdStashpoint_InterceptStashing;
	public /*function */void TdStashpoint_InterceptStashing()
	{
	
	}
	
	public delegate void CompleteStashing_del();
	public virtual CompleteStashing_del CompleteStashing { get => bfield_CompleteStashing ?? TdStashpoint_CompleteStashing; set => bfield_CompleteStashing = value; } CompleteStashing_del bfield_CompleteStashing;
	public virtual CompleteStashing_del global_CompleteStashing => TdStashpoint_CompleteStashing;
	public /*function */void TdStashpoint_CompleteStashing()
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		InitiateStashing = null;
		InterceptStashing = null;
		CompleteStashing = null;
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Idle()/*auto state Idle*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Stashing()/*state Stashing*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Idle": return Idle();
			case "Stashing": return Stashing();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return Idle();
	}
	public TdStashpoint()
	{
		var Default__TdStashpoint_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdStashpoint.CollisionCylinder' */;
		// Object Offset:0x00537E37
		TerritoryOfTeam = -1;
		bNotifyKismet = true;
		bNoDelete = true;
		bAlwaysRelevant = true;
		bCollideActors = true;
		bCollideWorld = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdStashpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdStashpoint.CollisionCylinder'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetPriority = 3.0f;
		CollisionComponent = Default__TdStashpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdStashpoint.CollisionCylinder'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvt_TdStashingInitiated>(),
			ClassT<SeqEvt_TdStashingIntercepted>(),
			ClassT<SeqEvt_TdStashingCompleted>(),
		};
	}
}
}