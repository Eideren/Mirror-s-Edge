namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_HeliController : AIController/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public enum HeliSpeed 
	{
		EHSpeed_Fastest_Default,
		EHSpeed_Fast,
		EHSpeed_Slow,
		EHSpeed_Slower,
		EHSpeed_Slowest,
		EHSpeed_MAX
	};
	
	public enum EHeliAttackSide 
	{
		ESide_Right,
		ESide_Left,
		ESide_UseLeftWhenHovering,
		ESide_UseRightWhenHovering,
		ESide_Both,
		ESide_None,
		ESide_MAX
	};
	
	public enum EAdjustPosition 
	{
		EAP_PositionOK,
		EAP_BetterPosFound,
		EAP_PositionNotOk,
		EAP_MAX
	};
	
	public partial struct /*native */VisitedNode
	{
		public TdAttackPathNode Node;
		public float TimeVisited;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004919C3
	//		Node = default;
	//		TimeVisited = 0.0f;
	//	}
	};
	
	public TdPlayerPawn Player;
	public TdVehicle_Helicopter HelicopterPawn;
	public TdAI_HeliController.EHeliAttackSide FireFromThisSide;
	public Actor TargetActor;
	public array<TdAI_HeliController.VisitedNode> VisitedNodes;
	public float MaxRememberTime;
	public float DistanceNodePlayerWeight;
	public float DistanceNodeHeliWeight;
	public float AngleToPlayerWeight;
	public float LastVisitWeight;
	public TdAttackPathNode BestAttackNode;
	public float CurrentPrioValue;
	public array<TdAttackPathNode> AttackNodes;
	public TdAIVoiceOverManager VoiceOverManager;
	[Const] public float BigFloat;
	public bool bMuted;
	public Object.Vector LastLoc;
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public override Tick_del eventTick { get => bfield_Tick ?? TdAI_HeliController_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAI_HeliController_Tick;
	public /*event */void TdAI_HeliController_Tick(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void DrawPosition()
	{
		// stub
	}
	
	public virtual /*function */void OnSetHeliTarget(SeqAct_SetHeliTarget seqAct)
	{
		// stub
	}
	
	public virtual /*function */void OnSetHeliSpeed(SeqAct_SetHeliSpeed seqAct)
	{
		// stub
	}
	
	public virtual /*function */void SetHeliSpeed(TdAI_HeliController.HeliSpeed Speed)
	{
		// stub
	}
	
	public virtual /*function */void Say(int VO)
	{
		// stub
	}
	
	public virtual /*function */void DrawDebugInfo(PlayerController PlayerC, Canvas aCanvas)
	{
		// stub
	}
	
	// Export UTdAI_HeliController::execDrawPath(FFrame&, void* const)
	public virtual /*native function */void DrawPath()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override Possess_del Possess { get => bfield_Possess ?? TdAI_HeliController_Possess; set => bfield_Possess = value; } Possess_del bfield_Possess;
	public override Possess_del global_Possess => TdAI_HeliController_Possess;
	public /*event */void TdAI_HeliController_Possess(Pawn aPawn, bool bVehicleTransition)
	{
		// stub
	}
	
	public virtual /*function */void UpdateVisitedNodes()
	{
		// stub
	}
	
	public virtual /*function */float GetTimeFactor(TdAttackPathNode Node)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnAIAbortMoveToActor(SeqAct_AIAbortMoveToActor inAction)
	{
		// stub
	}
	
	public virtual /*function */void CheckTargetPoint()
	{
		// stub
	}
	
	public virtual /*function */void DebugMoveTo(NavigationPoint navpoint)
	{
		// stub
	}
	
	public virtual /*event */void SkipPathNode()
	{
		// stub
	}
	
	public virtual /*function */TdAI_HeliController.EAdjustPosition CurrentPositionOk()
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdAttackPathNode FindBestAttackPoint(ref float PrioValue)
	{
		// stub
		return default;
	}
	
	public virtual /*function */float GetPrio(TdAttackPathNode Node, Object.Vector PlayerPosition)
	{
		// stub
		return default;
	}
	
	public virtual /*function */float VerticalAngleToPos(Object.Vector pos, Object.Vector Source)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void FindPlayerController()
	{
		// stub
	}
	
	public override SeePlayer_del SeePlayer { get => bfield_SeePlayer ?? TdAI_HeliController_SeePlayer; set => bfield_SeePlayer = value; } SeePlayer_del bfield_SeePlayer;
	public override SeePlayer_del global_SeePlayer => TdAI_HeliController_SeePlayer;
	public /*event */void TdAI_HeliController_SeePlayer(Pawn Seen)
	{
		// stub
	}
	
	public virtual /*event */void OnMute(bool bMute)
	{
		// stub
	}
	
	public virtual /*function */Object.Vector vec3(float X, float Y, float Z)
	{
		// stub
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		eventTick = null;
		Possess = null;
		SeePlayer = null;
	
	}
	
	protected /*event */void TdAI_HeliController_ScriptedMove_PoppedState()// state function
	{
		// stub
	}
	
	protected /*event */void TdAI_HeliController_ScriptedMove_PushedState()// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) ScriptedMove()/*state ScriptedMove*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAI_HeliController_SearchAndDestroy_ContinuedState()// state function
	{
		// stub
	}
	
	protected /*function */void TdAI_HeliController_SearchAndDestroy_PausedState()// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) SearchAndDestroy()/*auto state SearchAndDestroy*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "ScriptedMove": return ScriptedMove();
			case "SearchAndDestroy": return SearchAndDestroy();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return SearchAndDestroy();
	}
	public TdAI_HeliController()
	{
		var Default__TdAI_HeliController_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_HeliController.Sprite' */;
		// Object Offset:0x004D3235
		MaxRememberTime = 180.0f;
		DistanceNodePlayerWeight = 1.50f;
		DistanceNodeHeliWeight = 1.0f;
		AngleToPlayerWeight = 1000.0f;
		LastVisitWeight = 2000.0f;
		BigFloat = 10000000.0f;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_HeliController_Sprite/*Ref SpriteComponent'Default__TdAI_HeliController.Sprite'*/,
		};
	}
}
}