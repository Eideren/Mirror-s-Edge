namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Mutator : Info/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public Mutator NextMutator;
	[Category] public array<String> GroupNames;
	public bool bUserAdded;
	
	public override /*event */void PreBeginPlay()
	{
		// stub
	}
	
	public virtual /*function */bool MutatorIsAllowed()
	{
		// stub
		return default;
	}
	
	public override /*event */void Destroyed()
	{
		// stub
	}
	
	public virtual /*function */void Mutate(String MutateString, PlayerController Sender)
	{
		// stub
	}
	
	public virtual /*function */void ModifyLogin(ref String Portal, ref String Options)
	{
		// stub
	}
	
	public virtual /*function */void ModifyPlayer(Pawn Other)
	{
		// stub
	}
	
	public virtual /*function */void AddMutator(Mutator M)
	{
		// stub
	}
	
	public virtual /*function */bool AlwaysKeep(Actor Other)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsRelevant(Actor Other)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CheckRelevance(Actor Other)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CheckReplacement(Actor Other)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void GetServerDetails(ref Info.ServerResponseLine ServerState)
	{
		// stub
	}
	
	public virtual /*function */void GetServerPlayers(ref Info.ServerResponseLine ServerState)
	{
		// stub
	}
	
	public virtual /*function */String ParseChatPercVar(Controller Who, String Cmd)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void NotifyLogout(Controller Exiting)
	{
		// stub
	}
	
	public virtual /*function */void NotifyLogin(Controller NewPlayer)
	{
		// stub
	}
	
	public virtual /*function */void DriverEnteredVehicle(Vehicle V, Pawn P)
	{
		// stub
	}
	
	public virtual /*function */bool CanLeaveVehicle(Vehicle V, Pawn P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void DriverLeftVehicle(Vehicle V, Pawn P)
	{
		// stub
	}
	
	public virtual /*function */void InitMutator(String Options, ref String ErrorMessage)
	{
		// stub
	}
	
	public virtual /*function */void GetSeamlessTravelActorList(bool bToEntry, ref array<Actor> ActorList)
	{
		// stub
	}
	
	public Mutator()
	{
		var Default__Mutator_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__Mutator.Sprite' */;
		// Object Offset:0x0035EA97
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Mutator_Sprite/*Ref SpriteComponent'Default__Mutator.Sprite'*/,
		};
	}
}
}