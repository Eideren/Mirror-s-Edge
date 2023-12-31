namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_BossHeliController : TdAI_HeliController/*
		notplaceable
		hidecategories(Navigation)*/{
	public float NodeInvalidatedTime;
	public bool bNodeInvalidated;
	public float PlayerNearDistance;
	public float TimeToInvalidateNode;
	public float PlayerNearTimeToInvalidate;
	
	public override Tick_del eventTick { get => bfield_Tick ?? TdAI_BossHeliController_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAI_BossHeliController_Tick;
	public /*event */void TdAI_BossHeliController_Tick(float DeltaTime)
	{
		// stub
	}
	
	public override /*function */float GetPrio(TdAttackPathNode Node, Object.Vector PlayerPosition)
	{
		// stub
		return default;
	}
	
	public override /*function */TdAttackPathNode FindBestAttackPoint(ref float PrioValue)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void InvalidateNode()
	{
		// stub
	}
	
	public virtual /*function */void CheckForPlayer()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		eventTick = null;
	
	}
	
	protected /*function */void TdAI_BossHeliController_SearchAndDestroy_ContinuedState()// state function
	{
		// stub
	}
	
	protected /*function */void TdAI_BossHeliController_SearchAndDestroy_PausedState()// state function
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
			case "SearchAndDestroy": return SearchAndDestroy();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return SearchAndDestroy();
	}
	public TdAI_BossHeliController()
	{
		var Default__TdAI_BossHeliController_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_BossHeliController.Sprite' */;
		// Object Offset:0x004D3E3C
		NodeInvalidatedTime = -1000.0f;
		PlayerNearDistance = 3000.0f;
		TimeToInvalidateNode = 60.0f;
		PlayerNearTimeToInvalidate = 10.0f;
		bMuted = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_BossHeliController_Sprite/*Ref SpriteComponent'Default__TdAI_BossHeliController.Sprite'*/,
		};
	}
}
}