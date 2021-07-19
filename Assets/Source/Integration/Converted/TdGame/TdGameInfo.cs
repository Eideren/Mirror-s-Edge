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
	[Const] public bool bAllowViewTargetSwitching;
	[Const] public bool bAllowDifficultyChange;
	public bool bOnlineMode;
	public float BulletTraceLifeTime;
	[Category] public array<TdGameInfo.DefaultInvItem> DefaultInventory;
	public array<PlayerStart> StartPoints;
	public array<TdSpectatorPoint> SpectatorPoints;
	public UIDataStore_TdGameData TdGameData;
	public array<TdLookAtPoint> ActiveLookAtPoints;
	public TdAIVoiceOverManager VoiceOverManager;
	public RequestedTextureResources ActiveRequestedTextureResources;
	
	public override /*event */void InitGame(String Options, ref String ErrorMessage)
	{
		base.InitGame(Options, ref/*probably?*/ ErrorMessage);
		bOnlineMode = StringToBool((ParseOption(Options, "OnlineMode")));
	}
	
	public override /*function */void PreBeginPlay()
	{
		base.PreBeginPlay();
		AcquirePlayerStartPoints();
		InitializeDataStore();
	}
	
	public virtual /*event */void PostSublevelStreaming(String Options)
	{
		/*local */Object.Vector HitLocation = default, HitNormal = default;
		/*local */Actor.TraceHitInfo HitInfo = default;
		/*local */TdPlayerController PC = default;
	
		
		// foreach LocalPlayerControllers(ClassT<TdPlayerController>(), ref/*probably?*/ PC)
		using var e0 = LocalPlayerControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (PC = (TdPlayerController)e0.Current) == PC)
		{
			if(Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, PC.myPawn.Location + vect(0.0f, 0.0f, -90.0f), PC.myPawn.Location, true, vect(2.0f, 2.0f, 2.0f), ref/*probably?*/ HitInfo, 1) != default)
			{
				PC.myPawn.SetLocation(HitLocation + vect(0.0f, 0.0f, 90.0f));
			}		
		}	
	}
	
	public virtual /*function */void InitializeDataStore()
	{
		/*local */DataStoreClient DataStoreManager = default;
	
		DataStoreManager = UIInteraction.GetDataStoreClient();
		if(DataStoreManager != default)
		{
			TdGameData = ((DataStoreManager.FindDataStore("TdGameData", default(LocalPlayer))) as UIDataStore_TdGameData);
		}
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdGameInfo_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdGameInfo_Reset;
	public /*function */void TdGameInfo_Reset()
	{
		ActiveLookAtPoints.Length = 0;
		/*Transformed 'base.' to specific call*/GameInfo_Reset();
	}
	
	public virtual /*function */void RegisterLookAtPoint(TdLookAtPoint Point, /*optional */bool? _bForceLookAtNow = default)
	{
		/*local */TdPlayerController PC = default;
	
		var bForceLookAtNow = _bForceLookAtNow ?? default;
		if(bForceLookAtNow)
		{
			
			// foreach LocalPlayerControllers(ClassT<TdPlayerController>(), ref/*probably?*/ PC)
			using var e10 = LocalPlayerControllers(ClassT<TdPlayerController>()).GetEnumerator();
			while(e10.MoveNext() && (PC = (TdPlayerController)e10.Current) == PC)
			{
				PC.CurrentForcedLookAtPoint = Point;			
			}				
		}
		else
		{
			ActiveLookAtPoints.AddItem(Point);
		}
	}
	
	public virtual /*function */void UnRegisterLookAtPoint(TdLookAtPoint Point)
	{
		/*local */TdPlayerController PC = default;
	
		ActiveLookAtPoints.RemoveItem(Point);
		
		// foreach LocalPlayerControllers(ClassT<TdPlayerController>(), ref/*probably?*/ PC)
		using var e13 = LocalPlayerControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e13.MoveNext() && (PC = (TdPlayerController)e13.Current) == PC)
		{
			if(PC.CurrentLookAtPoint == Point)
			{
				PC.CurrentLookAtPoint = default;
			}
			if(PC.CurrentForcedLookAtPoint == Point)
			{
				PC.CurrentForcedLookAtPoint = default;
			}		
		}	
	}
	
	public delegate TdLookAtPoint GetLookAtPoint_del(TdPawn Player);
	public virtual GetLookAtPoint_del GetLookAtPoint { get => bfield_GetLookAtPoint ?? TdGameInfo_GetLookAtPoint; set => bfield_GetLookAtPoint = value; } GetLookAtPoint_del bfield_GetLookAtPoint;
	public virtual GetLookAtPoint_del global_GetLookAtPoint => TdGameInfo_GetLookAtPoint;
	public /*function */TdLookAtPoint TdGameInfo_GetLookAtPoint(TdPawn Player)
	{
		/*local */TdLookAtPoint P = default, NearestPoint = default;
		/*local */float NearestDistance = default;
	
		if(!Player.Moves[((int)Player.MovementState)].CanUseLookAtHint())
		{
			return default;
		}
		NearestDistance = 100000.0f;
		using var v = ActiveLookAtPoints.GetEnumerator();while(v.MoveNext() && (P = (TdLookAtPoint)v.Current) == P)
		{
			if(VSize(P.Location - Player.Location) < NearestDistance)
			{
				NearestDistance = VSize(P.Location - Player.Location);
				NearestPoint = P;
			}		
		}	
		return NearestPoint;
	}
	
	public virtual /*function */void AccuireSpectatorPoints()
	{
		/*local */TdSpectatorPoint CurrentSpecPoint = default;
		/*local */int Idx = default;
	
		SpectatorPoints.Remove(0, SpectatorPoints.Length);
		SpectatorPoints.Length = 0;
		
		// foreach DynamicActors(ClassT<TdSpectatorPoint>(), ref/*probably?*/ CurrentSpecPoint)
		using var e21 = DynamicActors(ClassT<TdSpectatorPoint>()).GetEnumerator();
		while(e21.MoveNext() && (CurrentSpecPoint = (TdSpectatorPoint)e21.Current) == CurrentSpecPoint)
		{
			Idx = 0;
			J0x2C:{}
			if(Idx < SpectatorPoints.Length)
			{
				if(SpectatorPoints[Idx].OrderIndex > CurrentSpecPoint.OrderIndex)
				{
					SpectatorPoints.Insert(Idx, 1);
					SpectatorPoints[Idx] = CurrentSpecPoint;
					goto J0x8F;
				}
				++ Idx;
				goto J0x2C;
			}
			J0x8F:{}
			if(Idx == SpectatorPoints.Length)
			{
				SpectatorPoints.Insert(Idx, 1);
				SpectatorPoints[Idx] = CurrentSpecPoint;
			}		
		}	
	}
	
	public virtual /*function */TdSpectatorPoint GetFirstSpectatorPoint()
	{
		if(SpectatorPoints.Length > 0)
		{
			return SpectatorPoints[0];
		}
		return default;
	}
	
	public virtual /*function */TdSpectatorPoint GetLastSpectatorPoint()
	{
		if(SpectatorPoints.Length > 0)
		{
			return SpectatorPoints[SpectatorPoints.Length - 1];
		}
		return default;
	}
	
	public virtual /*function */TdSpectatorPoint GetNextSpectatorPoint(TdSpectatorPoint CurrPoint)
	{
		/*local */int Idx = default;
		/*local */TdSpectatorPoint NextPoint = default;
	
		NextPoint = CurrPoint;
		if(SpectatorPoints.Length > 1)
		{
			Idx = SpectatorPoints.Find(CurrPoint);
			if(Idx != -1)
			{
				NextPoint = SpectatorPoints[++ Idx % SpectatorPoints.Length];
			}
		}
		return NextPoint;
	}
	
	public virtual /*function */TdSpectatorPoint GetPrevSpectatorPoint(TdSpectatorPoint CurrPoint)
	{
		/*local */int Idx = default;
		/*local */TdSpectatorPoint PrevPoint = default;
	
		PrevPoint = CurrPoint;
		if(SpectatorPoints.Length > 1)
		{
			Idx = SpectatorPoints.Find(CurrPoint);
			if(Idx != -1)
			{
				PrevPoint = ((Idx == 0) ? SpectatorPoints[SpectatorPoints.Length - 1] : SpectatorPoints[Idx - 1]);
			}
		}
		return PrevPoint;
	}
	
	public virtual /*function */void AcquirePlayerStartPoints()
	{
		/*local */PlayerStart PlayerStartPoint = default;
	
		StartPoints.Remove(0, StartPoints.Length);
		
		// foreach WorldInfo.AllNavigationPoints(ClassT<PlayerStart>(), ref/*probably?*/ PlayerStartPoint)
		using var e13 = WorldInfo.AllNavigationPoints(ClassT<PlayerStart>()).GetEnumerator();
		while(e13.MoveNext() && (PlayerStartPoint = (PlayerStart)e13.Current) == PlayerStartPoint)
		{
			StartPoints.Insert(StartPoints.Length, 1);
			StartPoints[StartPoints.Length - 1] = PlayerStartPoint;		
		}	
	}
	
	public delegate NavigationPoint FindClosestStartSpot_del(Object.Vector ObjectLocation);
	public virtual FindClosestStartSpot_del FindClosestStartSpot { get => bfield_FindClosestStartSpot ?? TdGameInfo_FindClosestStartSpot; set => bfield_FindClosestStartSpot = value; } FindClosestStartSpot_del bfield_FindClosestStartSpot;
	public virtual FindClosestStartSpot_del global_FindClosestStartSpot => TdGameInfo_FindClosestStartSpot;
	public /*function */NavigationPoint TdGameInfo_FindClosestStartSpot(Object.Vector ObjectLocation)
	{
		/*local */int Index = default;
		/*local */PlayerStart PlayerStartPoint = default;
	
		if(StartPoints.Length == 0)
		{
			return default;
		}
		PlayerStartPoint = StartPoints[0];
		Index = 1;
		J0x22:{}
		if(Index < StartPoints.Length)
		{
			if(Abs(VSizeSq2D(PlayerStartPoint.Location - ObjectLocation)) > Abs(VSizeSq2D(StartPoints[Index].Location - ObjectLocation)))
			{
				PlayerStartPoint = StartPoints[Index];
			}
			++ Index;
			goto J0x22;
		}
		return PlayerStartPoint;
	}
	
	public override /*event */void AddDefaultInventory(Pawn P)
	{
		/*local */int Index = default;
		/*local */Core.ClassT<Inventory> InvClass = default;
		/*local */Inventory Inv = default;
		/*local */Inventory.EInventorySlot Slot = default;
		/*local */TdWeapon DefaultWeapon = default;
	
		if(!P.IsA("TdPlayerPawn"))
		{
			return;
		}
		Index = 0;
		J0x23:{}
		if(Index < DefaultInventory.Length)
		{
			if(P.IsA(DefaultInventory[Index].PawnClassName))
			{
				InvClass = ((DynamicLoadObject(DefaultInventory[Index].InventoryClassName, ClassT<Class>(), default(bool?))) as ClassT<Inventory>);
				Slot = ((Inventory.EInventorySlot)DefaultInventory[Index].Slot);
				if(InvClass != default)
				{
					Inv = P.FindInventoryType(InvClass, default(bool?));
					if(Inv == default)
					{
						Inv = P.CreateInventory(InvClass, default(bool?));
					}
					DefaultWeapon = ((Inv) as TdWeapon);
					if(DefaultWeapon != default)
					{
						if(DefaultInventory[Index].Clips > -2)
						{
							DefaultWeapon.ClipCount = DefaultInventory[Index].Clips;
						}
					}
					if(Inv != default)
					{
						if(((int)Slot) != ((int)Inventory.EInventorySlot.EISlot_None/*0*/))
						{
							Inv.AssignToSlot(((Inventory.EInventorySlot)Slot));
							goto J0x1AA;
						}
						Inv.AssignToSlot(((Inventory.EInventorySlot)Inv.DefaultInventorySlot));
					}
				}
			}
			J0x1AA:{}
			++ Index;
			goto J0x23;
		}
		base.AddDefaultInventory(P);
	}
	
	public virtual /*event */NavigationPoint GetPlayerStart(Controller PlayerController)
	{
		return FindPlayerStart(PlayerController, (byte)default(byte?), default(String?));
	}
	
	// Export UTdGameInfo::execSaveTextureResourceInfo(FFrame&, void* const)
	public virtual /*native final function */bool SaveTextureResourceInfo(RequestedTextureResources RequestedTextureResources)
	{
		NativeMarkers.MarkUnimplemented();
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
		ConsoleCommand("Quit", default(bool?));
	}
	
	public override /*function */void Killed(Controller Killer, Controller KilledPlayer, Pawn KilledPawn, Core.ClassT<DamageType> DamageType)
	{
		/*local */TdPlayerController TdKillerPC = default;
		/*local */bool bMelee = default;
	
		bMelee = ((DamageType) as ClassT<TdDmgType_Melee>) != default;
		TdKillerPC = ((Killer) as TdPlayerController);
		if((TdKillerPC != default) && bMelee)
		{
			if(DamageType == ClassT<TdDmgType_MeleeDisarm>())
			{
				TdKillerPC.AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_SPMeleeDisarmKills/*3*/);			
			}
			else
			{
				TdKillerPC.AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_MeleeKills/*1*/);
			}
		}
		base.Killed(Killer, KilledPlayer, KilledPawn, DamageType);
	}
	
	public virtual /*function */bool UseStreamingVolumes(bool bInFreeCam)
	{
		return true;
	}
	
	public virtual /*exec function */void AimingLines()
	{
		/*local */TdAIController MyAIController = default;
	
		
		// foreach AllActors(ClassT<TdAIController>(), ref/*probably?*/ MyAIController)
		using var e0 = AllActors(ClassT<TdAIController>()).GetEnumerator();
		while(e0.MoveNext() && (MyAIController = (TdAIController)e0.Current) == MyAIController)
		{
			MyAIController.ShowAimingLines();		
		}	
	}
	
	public virtual /*function */void OnlineConnectionLost()
	{
	
	}
	
	public virtual /*function */void SetObjective(name CheckpointName)
	{
		/*local */DataStoreClient DataStoreClient = default;
		/*local */UIDataStore_TdGameObjectivesData ObjectiveData = default;
	
		DataStoreClient = UIInteraction.GetDataStoreClient();
		if(DataStoreClient != default)
		{
			ObjectiveData = ((DataStoreClient.FindDataStore("TdGameObjectivesData", default(LocalPlayer))) as UIDataStore_TdGameObjectivesData);
			if(ObjectiveData != default)
			{
				ObjectiveData.ResolveAndSetCheckpointObjective("Objectives", CheckpointName, default(bool?));
			}
		}
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