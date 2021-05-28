namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AIController : Controller/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public bool bHunting;
	public bool bAdjustFromWalls;
	public bool bReverseScriptedRoute;
	public float Skill;
	public Actor ScriptedMoveTarget;
	public Route ScriptedRoute;
	public int ScriptedRouteIndex;
	public Actor ScriptedFocus;
	
	public override /*event */void PreBeginPlay()
	{
	
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? AIController_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => AIController_Reset;
	public /*function */void AIController_Reset()
	{
	
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public virtual /*function */void SetOrders(name NewOrders, Controller OrderGiver)
	{
	
	}
	
	public virtual /*function */Actor GetOrderObject()
	{
	
		return default;
	}
	
	public virtual /*function */name GetOrders()
	{
	
		return default;
	}
	
	public virtual /*function */bool PriorityObjective()
	{
	
		return default;
	}
	
	public virtual /*event */void SetTeam(int inTeamIdx)
	{
	
	}
	
	public override /*simulated event */void GetPlayerViewPoint(ref Object.Vector out_Location, ref Object.Rotator out_Rotation)
	{
	
	}
	
	public virtual /*function */void OnAIMoveToActor(SeqAct_AIMoveToActor Action)
	{
	
	}
	
	public virtual /*function */void NotifyWeaponFired(Weapon W, byte FireMode)
	{
	
	}
	
	public virtual /*function */void NotifyWeaponFinishedFiring(Weapon W, byte FireMode)
	{
	
	}
	
	public virtual /*function */bool ShouldRefire()
	{
	
		return default;
	}
	
	public virtual /*function */bool ShouldAutoReload()
	{
	
		return default;
	}
	
	public virtual /*function */bool CanFireWeapon(Weapon Wpn, byte FireModeNum)
	{
	
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
	
	}
	
	protected /*event */void AIController_ScriptedMove_PoppedState()// state function
	{
	
	}
	
	protected /*event */void AIController_ScriptedMove_PushedState()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) ScriptedMove()/*state ScriptedMove*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*event */void AIController_ScriptedRouteMove_PoppedState()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) ScriptedRouteMove()/*state ScriptedRouteMove*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "ScriptedMove": return ScriptedMove();
			case "ScriptedRouteMove": return ScriptedRouteMove();
			default: return base.FindState(stateName);
		}
	}
	public AIController()
	{
		// Object Offset:0x0028CCB2
		bAdjustFromWalls = true;
		bCanDoSpecial = true;
		MinHitWall = -0.50f;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__AIController.Sprite")/*Ref SpriteComponent'Default__AIController.Sprite'*/,
		};
	}
}
}