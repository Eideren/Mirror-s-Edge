namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Mutator : Info/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public Mutator NextMutator;
	public/*()*/ array<string> GroupNames;
	public bool bUserAdded;
	
	public override /*event */void PreBeginPlay()
	{
	
	}
	
	public virtual /*function */bool MutatorIsAllowed()
	{
	
		return default;
	}
	
	public override /*event */void Destroyed()
	{
	
	}
	
	public virtual /*function */void Mutate(string MutateString, PlayerController Sender)
	{
	
	}
	
	public virtual /*function */void ModifyLogin(ref string Portal, ref string Options)
	{
	
	}
	
	public virtual /*function */void ModifyPlayer(Pawn Other)
	{
	
	}
	
	public virtual /*function */void AddMutator(Mutator M)
	{
	
	}
	
	public virtual /*function */bool AlwaysKeep(Actor Other)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsRelevant(Actor Other)
	{
	
		return default;
	}
	
	public virtual /*function */bool CheckRelevance(Actor Other)
	{
	
		return default;
	}
	
	public virtual /*function */bool CheckReplacement(Actor Other)
	{
	
		return default;
	}
	
	public virtual /*function */void GetServerDetails(ref Info.ServerResponseLine ServerState)
	{
	
	}
	
	public virtual /*function */void GetServerPlayers(ref Info.ServerResponseLine ServerState)
	{
	
	}
	
	public virtual /*function */string ParseChatPercVar(Controller Who, string Cmd)
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyLogout(Controller Exiting)
	{
	
	}
	
	public virtual /*function */void NotifyLogin(Controller NewPlayer)
	{
	
	}
	
	public virtual /*function */void DriverEnteredVehicle(Vehicle V, Pawn P)
	{
	
	}
	
	public virtual /*function */bool CanLeaveVehicle(Vehicle V, Pawn P)
	{
	
		return default;
	}
	
	public virtual /*function */void DriverLeftVehicle(Vehicle V, Pawn P)
	{
	
	}
	
	public virtual /*function */void InitMutator(string Options, ref string ErrorMessage)
	{
	
	}
	
	public virtual /*function */void GetSeamlessTravelActorList(bool bToEntry, ref array<Actor> ActorList)
	{
	
	}
	
	public Mutator()
	{
		// Object Offset:0x0035EA97
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__Mutator.Sprite")/*Ref SpriteComponent'Default__Mutator.Sprite'*/,
		};
	}
}
}