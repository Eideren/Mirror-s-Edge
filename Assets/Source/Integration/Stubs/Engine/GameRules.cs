namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameRules : Info/*
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public GameRules NextGameRules;
	
	public virtual /*function */void AddGameRules(GameRules GR)
	{
		// stub
	}
	
	public virtual /*function */NavigationPoint FindPlayerStart(Controller Player, /*optional */byte? _InTeam = default, /*optional */String? _IncomingName = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */String GetRules()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool HandleRestartGame()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CheckEndGame(PlayerReplicationInfo Winner, String Reason)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OverridePickupQuery(Pawn Other, Core.ClassT<Inventory> ItemClass, Actor Pickup, ref byte bAllowPickup)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool PreventDeath(Pawn Killed, Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ScoreObjective(PlayerReplicationInfo Scorer, int Score)
	{
		// stub
	}
	
	public virtual /*function */void ScoreKill(Controller Killer, Controller Killed)
	{
		// stub
	}
	
	public virtual /*function */void NetDamage(int OriginalDamage, ref int Damage, Pawn injured, Controller InstigatedBy, Object.Vector HitLocation, ref Object.Vector Momentum, Core.ClassT<DamageType> DamageType)
	{
		// stub
	}
	
	public GameRules()
	{
		var Default__GameRules_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__GameRules.Sprite' */;
		// Object Offset:0x00334F8D
		Components = new array</*export editinline */ActorComponent>
		{
			Default__GameRules_Sprite/*Ref SpriteComponent'Default__GameRules.Sprite'*/,
		};
	}
}
}