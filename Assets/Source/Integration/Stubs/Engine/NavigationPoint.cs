namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class NavigationPoint : Actor/*
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public const int INFINITE_PATH_COST = 10000000;
	
	public partial struct /*native */NavigationOctreeObject
	{
		public Object.Box BoundingBox;
		public Object.Vector BoxCenter;
		[native, Const, transient] public Object.Pointer OctreeNode;
		[Const, noexport] public Object Owner;
		[Const, noexport] public byte OwnerType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002AE469
	//		BoundingBox = new Box
	//		{
	//			Min={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f},
	//			Max={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f},
	//			IsValid=0
	//		};
	//		BoxCenter = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Owner = default;
	//		OwnerType = 0;
	//	}
	};
	
	[transient] public bool bEndPoint;
	[transient] public bool bTransientEndPoint;
	[transient] public bool bHideEditorPaths;
	[transient] public bool bCanReach;
	[Category] public bool bBlocked;
	[Category] public bool bOneWayPath;
	public bool bNeverUseStrafing;
	public bool bAlwaysUseStrafing;
	[Const] public bool bForceNoStrafing;
	[Const] public bool bAutoBuilt;
	public bool bSpecialMove;
	public bool bNoAutoConnect;
	[Const] public bool bNotBased;
	[Const] public bool bPathsChanged;
	public bool bDestinationOnly;
	public bool bSourceOnly;
	public bool bSpecialForced;
	public bool bMustBeReachable;
	public bool bBlockable;
	public bool bFlyingPreferred;
	public bool bMayCausePain;
	[transient] public bool bAlreadyVisited;
	[Category] public bool bVehicleDestination;
	[Category] public bool bMakeSourceOnly;
	public bool bMustTouchToReach;
	public bool bCanWalkOnToReach;
	public bool bBuildLongPaths;
	[Category("VehicleUsage")] public bool bBlockedForVehicles;
	[Category("VehicleUsage")] public bool bPreferredVehiclePath;
	public bool bIsSkippable;
	public bool bNeedsVelocityToTrigger;
	public bool bIsSpecialMove;
	public bool bCanBePlayerNavigationPoint;
	[Const] public bool bHasCrossLevelPaths;
	[native, Const, transient] public NavigationPoint.NavigationOctreeObject NavOctreeObject;
	[Category] [duplicatetransient, Const, editconst] public array</*editconst editinline */ReachSpec> PathList;
	[duplicatetransient] public array<Actor.NavReference> EditorProscribedPaths;
	[duplicatetransient] public array<Actor.NavReference> EditorForcedPaths;
	[Category] [Const, editconst] public array</*editconst */Volume> VolumeList;
	public int visitedWeight;
	[Const] public int bestPathWeight;
	[Const] public/*private*/ NavigationPoint nextNavigationPoint;
	[Const] public NavigationPoint nextOrdered;
	[Const] public NavigationPoint prevOrdered;
	[Const] public NavigationPoint previousPath;
	public int Cost;
	[Category] public int ExtraCost;
	[transient] public int TransientCost;
	[transient] public int FearCost;
	[native, transient] public /*map<0,0>*/map<object, object> CostArray;
	public DroppedPickup InventoryCache;
	public float InventoryDist;
	[Const] public float LastDetourWeight;
	[export, editinline] public CylinderComponent CylinderComponent;
	public Objective NearestObjective;
	public float ObjectiveDistance;
	[Category] [Const, editconst] public Object.Cylinder MaxPathSize;
	[Category] [duplicatetransient, Const, editconst] public Object.Guid NavGuid;
	[Const, export, editinline] public SpriteComponent GoodSprite;
	[Const, export, editinline] public SpriteComponent BadSprite;
	[Category] [Const, editconst] public int NetworkID;
	[transient] public Pawn AnchoredPawn;
	[transient] public float LastAnchoredPawnTime;
	public String Abbrev;
	public float IgnoreAsTaserSpotTimeStamp;
	[Category("Visibility")] public array<NavigationPoint> CanSeeMePoints;
	[Category("Visibility")] public array<NavigationPoint> VisiblePoints;
	[Category("Visibility")] public int Visibility;
	[Category("Visibility")] public int Exposure;
	[transient] public/*protected*/ int UsageCount;
	[transient] public array<Controller> Users;
	
	// Export UNavigationPoint::execUsage(FFrame&, void* const)
	public virtual /*native final function */int Usage()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UNavigationPoint::execOccupy(FFrame&, void* const)
	public virtual /*native final function */void Occupy(Controller NewUser)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UNavigationPoint::execUnoccupy(FFrame&, void* const)
	public virtual /*native final function */void Unoccupy(Controller OldUser)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UNavigationPoint::execHasVisibilityTo(FFrame&, void* const)
	public virtual /*native function */bool HasVisibilityTo(Object.Vector Offset, NavigationPoint Other, Object.Vector otherOffset)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UNavigationPoint::execCanBeSeenFrom(FFrame&, void* const)
	public virtual /*native function */bool CanBeSeenFrom(Object.Vector Offset, NavigationPoint Other, Object.Vector otherOffset)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UNavigationPoint::execSeenFrom(FFrame&, void* const)
	public virtual /*native final function */bool SeenFrom(/*const */NavigationPoint Other)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UNavigationPoint::execCanSee(FFrame&, void* const)
	public virtual /*native final function */bool CanSee(/*const */NavigationPoint Other)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UNavigationPoint::execGetBoundingCylinder(FFrame&, void* const)
	public override /*native function */void GetBoundingCylinder(ref float CollisionRadius, ref float CollisionHeight)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UNavigationPoint::execGetReachSpecTo(FFrame&, void* const)
	public virtual /*native final function */ReachSpec GetReachSpecTo(NavigationPoint Nav)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UNavigationPoint::execCanTeleport(FFrame&, void* const)
	public virtual /*native function */bool CanTeleport(Actor A)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*event */int SpecialCost(Pawn Seeker, ReachSpec Path)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool Accept(Actor Incoming, Actor Source)
	{
		// stub
		return default;
	}
	
	public delegate float DetourWeight_del(Pawn Other, float PathWeight);
	public virtual DetourWeight_del DetourWeight { get => bfield_DetourWeight ?? NavigationPoint_DetourWeight; set => bfield_DetourWeight = value; } DetourWeight_del bfield_DetourWeight;
	public virtual DetourWeight_del global_DetourWeight => NavigationPoint_DetourWeight;
	public /*event */float NavigationPoint_DetourWeight(Pawn Other, float PathWeight)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SuggestMovePreparation(Pawn Other)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ProceedWithMove(Pawn Other)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsAvailableTo(Actor chkActor)
	{
		// stub
		return default;
	}
	
	public /*final function */static NavigationPoint GetNearestNavToActor(Actor chkActor, /*optional */Core.ClassT<NavigationPoint> _RequiredClass = default, /*optional */array<NavigationPoint>? _ExcludeList = default, /*optional */float? _MinDist = default)
	{
		// stub
		return default;
	}
	
	public /*final function */static NavigationPoint GetNearestNavToPoint(Actor chkActor, Object.Vector ChkPoint, /*optional */Core.ClassT<NavigationPoint> _RequiredClass = default, /*optional */array<NavigationPoint>? _ExcludeList = default)
	{
		// stub
		return default;
	}
	
	// Export UNavigationPoint::execGetAllNavInRadius(FFrame&, void* const)
	public /*native final function */static bool GetAllNavInRadius(Actor chkActor, Object.Vector ChkPoint, float Radius, ref array<NavigationPoint> out_NavList, /*optional */bool? _bSkipBlocked = default, /*optional */int? _inNetworkID = default, /*optional */Object.Cylinder? _MinSize = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */void OnToggle(SeqAct_Toggle inAction)
	{
		// stub
	}
	
	public virtual /*simulated function */bool OnMatchingNetworks(NavigationPoint Nav)
	{
		// stub
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		DetourWeight = null;
	
	}
	public NavigationPoint()
	{
		var Default__NavigationPoint_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x002AFFFD
			CollisionHeight = 50.0f,
			CollisionRadius = 50.0f,
		}/* Reference: CylinderComponent'Default__NavigationPoint.CollisionCylinder' */;
		var Default__NavigationPoint_Sprite = new SpriteComponent
		{
			// Object Offset:0x002AFE5D
			Sprite = LoadAsset<Texture2D>("EngineResources.S_NavP")/*Ref Texture2D'EngineResources.S_NavP'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__NavigationPoint.Sprite' */;
		var Default__NavigationPoint_Sprite2 = new SpriteComponent
		{
			// Object Offset:0x002AFEE5
			Sprite = LoadAsset<Texture2D>("EditorResources.Bad")/*Ref Texture2D'EditorResources.Bad'*/,
			HiddenGame = true,
			HiddenEditor = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
			Scale = 0.250f,
		}/* Reference: SpriteComponent'Default__NavigationPoint.Sprite2' */;
		var Default__NavigationPoint_Arrow = new ArrowComponent
		{
			// Object Offset:0x002AFFA5
			ArrowColor = new Color
			{
				R=150,
				G=200,
				B=255,
				A=255
			},
			ArrowSize = 0.50f,
		}/* Reference: ArrowComponent'Default__NavigationPoint.Arrow' */;
		var Default__NavigationPoint_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__NavigationPoint.PathRenderer' */;
		// Object Offset:0x002AFAF2
		bMayCausePain = true;
		bMustTouchToReach = true;
		bIsSkippable = true;
		CylinderComponent = Default__NavigationPoint_CollisionCylinder/*Ref CylinderComponent'Default__NavigationPoint.CollisionCylinder'*/;
		GoodSprite = Default__NavigationPoint_Sprite/*Ref SpriteComponent'Default__NavigationPoint.Sprite'*/;
		BadSprite = Default__NavigationPoint_Sprite2/*Ref SpriteComponent'Default__NavigationPoint.Sprite2'*/;
		NetworkID = -1;
		Abbrev = "NP?";
		bStatic = true;
		bNoDelete = true;
		bCollideWhenPlacing = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__NavigationPoint_Sprite/*Ref SpriteComponent'Default__NavigationPoint.Sprite'*/,
			Default__NavigationPoint_Sprite2/*Ref SpriteComponent'Default__NavigationPoint.Sprite2'*/,
			Default__NavigationPoint_Arrow/*Ref ArrowComponent'Default__NavigationPoint.Arrow'*/,
			Default__NavigationPoint_CollisionCylinder/*Ref CylinderComponent'Default__NavigationPoint.CollisionCylinder'*/,
			Default__NavigationPoint_PathRenderer/*Ref PathRenderingComponent'Default__NavigationPoint.PathRenderer'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
		CollisionComponent = Default__NavigationPoint_CollisionCylinder/*Ref CylinderComponent'Default__NavigationPoint.CollisionCylinder'*/;
	}
}
}