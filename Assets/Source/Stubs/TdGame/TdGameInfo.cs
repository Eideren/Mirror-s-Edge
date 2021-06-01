namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGameInfo : GameInfo/*
		abstract
		native
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public partial struct /*native */DefaultInvItem
	{
		public name PawnClassName;
		public String InventoryClassName;
		public int Ammo;
		public int Clips;
		public Inventory.EInventorySlot Slot;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0054713C
	//		PawnClassName = (name)"None";
	//		InventoryClassName = "";
	//		Ammo = -2;
	//		Clips = -2;
	//		Slot = Inventory.EInventorySlot.EISlot_None;
	//	}
	};
	
	public bool ShowBulletTraces;
	public /*const */bool bAllowViewTargetSwitching;
	public /*const */bool bAllowDifficultyChange;
	public bool bOnlineMode;
	public float BulletTraceLifeTime;
	public/*()*/ array<TdGameInfo.DefaultInvItem> DefaultInventory;
	public array<PlayerStart> StartPoints;
	public array<TdSpectatorPoint> SpectatorPoints;
	public UIDataStore_TdGameData TdGameData;
	public array<TdLookAtPoint> ActiveLookAtPoints;
	public TdAIVoiceOverManager VoiceOverManager;
	public RequestedTextureResources ActiveRequestedTextureResources;
	
	public override /*event */void InitGame(String Options, ref String ErrorMessage)
	{
	
	}
	
	public override /*function */void PreBeginPlay()
	{
	
	}
	
	public virtual /*event */void PostSublevelStreaming(String Options)
	{
	
	}
	
	public virtual /*function */void InitializeDataStore()
	{
	
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdGameInfo_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdGameInfo_Reset;
	public /*function */void TdGameInfo_Reset()
	{
	
	}
	
	public virtual /*function */void RegisterLookAtPoint(TdLookAtPoint Point, /*optional */bool? _bForceLookAtNow = default)
	{
	
	}
	
	public virtual /*function */void UnRegisterLookAtPoint(TdLookAtPoint Point)
	{
	
	}
	
	public delegate TdLookAtPoint GetLookAtPoint_del(TdPawn Player);
	public virtual GetLookAtPoint_del GetLookAtPoint { get => bfield_GetLookAtPoint ?? TdGameInfo_GetLookAtPoint; set => bfield_GetLookAtPoint = value; } GetLookAtPoint_del bfield_GetLookAtPoint;
	public virtual GetLookAtPoint_del global_GetLookAtPoint => TdGameInfo_GetLookAtPoint;
	public /*function */TdLookAtPoint TdGameInfo_GetLookAtPoint(TdPawn Player)
	{
	
		return default;
	}
	
	public virtual /*function */void AccuireSpectatorPoints()
	{
	
	}
	
	public virtual /*function */TdSpectatorPoint GetFirstSpectatorPoint()
	{
	
		return default;
	}
	
	public virtual /*function */TdSpectatorPoint GetLastSpectatorPoint()
	{
	
		return default;
	}
	
	public virtual /*function */TdSpectatorPoint GetNextSpectatorPoint(TdSpectatorPoint CurrPoint)
	{
	
		return default;
	}
	
	public virtual /*function */TdSpectatorPoint GetPrevSpectatorPoint(TdSpectatorPoint CurrPoint)
	{
	
		return default;
	}
	
	public virtual /*function */void AcquirePlayerStartPoints()
	{
	
	}
	
	public delegate NavigationPoint FindClosestStartSpot_del(Object.Vector ObjectLocation);
	public virtual FindClosestStartSpot_del FindClosestStartSpot { get => bfield_FindClosestStartSpot ?? TdGameInfo_FindClosestStartSpot; set => bfield_FindClosestStartSpot = value; } FindClosestStartSpot_del bfield_FindClosestStartSpot;
	public virtual FindClosestStartSpot_del global_FindClosestStartSpot => TdGameInfo_FindClosestStartSpot;
	public /*function */NavigationPoint TdGameInfo_FindClosestStartSpot(Object.Vector ObjectLocation)
	{
	
		return default;
	}
	
	public override /*event */void AddDefaultInventory(Pawn P)
	{
	
	}
	
	public virtual /*event */NavigationPoint GetPlayerStart(Controller PlayerController)
	{
	
		return default;
	}
	
	// Export UTdGameInfo::execSaveTextureResourceInfo(FFrame&, void* const)
	public virtual /*native final function */bool SaveTextureResourceInfo(RequestedTextureResources RequestedTextureResources)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void OnLevelLoaded(RequestedTextureResources RequestedTextureResources)
	{
	
	}
	
	public virtual /*function */void OnSaveTextureResourceInfo()
	{
	
	}
	
	public virtual /*function */void OnQuitGame()
	{
	
	}
	
	public override /*function */void Killed(Controller Killer, Controller KilledPlayer, Pawn KilledPawn, Core.ClassT<DamageType> DamageType)
	{
	
	}
	
	public virtual /*function */bool UseStreamingVolumes(bool bInFreeCam)
	{
	
		return default;
	}
	
	public virtual /*exec function */void AimingLines()
	{
	
	}
	
	public virtual /*function */void OnlineConnectionLost()
	{
	
	}
	
	public virtual /*function */void SetObjective(name CheckpointName)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		GetLookAtPoint = null;
		FindClosestStartSpot = null;
	
	}
	public TdGameInfo()
	{
		// Object Offset:0x00548B98
		bAllowDifficultyChange = true;
		BulletTraceLifeTime = -1.0f;
		bEnableLOI = true;
		DefaultPawnClass = ClassT<TdPlayerPawn>()/*Ref Class'TdPlayerPawn'*/;
		PlayerControllerClass = ClassT<TdPlayerController>()/*Ref Class'TdPlayerController'*/;
		PlayerReplicationInfoClass = ClassT<TdPlayerReplicationInfo>()/*Ref Class'TdPlayerReplicationInfo'*/;
		GameReplicationInfoClass = ClassT<TdGameReplicationInfo>()/*Ref Class'TdGameReplicationInfo'*/;
	}
}
}