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
	
	public override Tick_del Tick { get => bfield_Tick ?? TdAI_BossHeliController_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAI_BossHeliController_Tick;
	public /*event */void TdAI_BossHeliController_Tick(float DeltaTime)
	{
	
	}
	
	public override /*function */float GetPrio(TdAttackPathNode Node, Object.Vector PlayerPosition)
	{
	
		return default;
	}
	
	public override /*function */TdAttackPathNode FindBestAttackPoint(ref float PrioValue)
	{
	
		return default;
	}
	
	public virtual /*function */void InvalidateNode()
	{
	
	}
	
	public virtual /*function */void CheckForPlayer()
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
	
	}
	
	protected /*function */void TdAI_BossHeliController_SearchAndDestroy_ContinuedState()// state function
	{
	
	}
	
	protected /*function */void TdAI_BossHeliController_SearchAndDestroy_PausedState()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) SearchAndDestroy()/*auto state SearchAndDestroy*/
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
		// Object Offset:0x004D3E3C
		NodeInvalidatedTime = -1000.0f;
		PlayerNearDistance = 3000.0f;
		TimeToInvalidateNode = 60.0f;
		PlayerNearTimeToInvalidate = 10.0f;
		bMuted = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdAI_BossHeliController.Sprite")/*Ref SpriteComponent'Default__TdAI_BossHeliController.Sprite'*/,
		};
	}
}
}