namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CoverLink : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public const double COVERLINK_ExposureDot = 0.4f;
	public const double COVERLINK_EdgeCheckDot = 0.25f;
	public const double COVERLINK_EdgeExposureDot = 0.85f;
	public const double COVERLINK_DangerDist = 1536f;
	
	public enum ECoverAction 
	{
		CA_Default,
		CA_BlindLeft,
		CA_BlindRight,
		CA_LeanLeft,
		CA_LeanRight,
		CA_StepLeft,
		CA_StepRight,
		CA_PopUp,
		CA_BlindUp,
		CA_PeekLeft,
		CA_PeekRight,
		CA_PeekUp,
		CA_MAX
	};
	
	public enum ECoverDirection 
	{
		CD_Default,
		CD_Left,
		CD_Right,
		CD_Up,
		CD_MAX
	};
	
	public enum ECoverType 
	{
		CT_None,
		CT_Standing,
		CT_MidLevel,
		CT_Low,
		CT_MAX
	};
	
	public partial struct /*native */CoverReference// extends NavReference
	{
		[Category] public NavigationPoint Nav;
		[Category] [Const, editconst] public Object.Guid Guid;
	
		[Category] public int SlotIdx;
		[Category] public int Direction;
			// Object Offset:0x0024C470
	//		Nav = default;
	//		Guid = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native */CoverInfo
	{
		[Category] [editconst] public CoverLink Link;
		[Category] [editconst] public int SlotIdx;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E4753
	//		Link = default;
	//		SlotIdx = 0;
	//	}
	};
	
	public partial struct /*native */TargetInfo
	{
		public Actor Target;
		public int SlotIdx;
		public int Direction;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E484B
	//		Target = default;
	//		SlotIdx = 0;
	//		Direction = 0;
	//	}
	};
	
	public partial struct /*native */CovPosInfo
	{
		public CoverLink Link;
		public int LtSlotIdx;
		public int RtSlotIdx;
		public float LtToRtPct;
		public Object.Vector Location;
		public Object.Vector Normal;
		public Object.Vector Tangent;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E4A1B
	//		Link = default;
	//		LtSlotIdx = -1;
	//		RtSlotIdx = -1;
	//		LtToRtPct = 0.0f;
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Normal = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Tangent = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public partial struct /*native */FireLinkItem
	{
		public CoverLink.ECoverType SrcType;
		public CoverLink.ECoverAction SrcAction;
		public CoverLink.ECoverType DestType;
		public CoverLink.ECoverAction DestAction;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E4D07
	//		SrcType = CoverLink.ECoverType.CT_None;
	//		SrcAction = CoverLink.ECoverAction.CA_Default;
	//		DestType = CoverLink.ECoverType.CT_None;
	//		DestAction = CoverLink.ECoverAction.CA_Default;
	//	}
	};
	
	public partial struct /*native */FireLink
	{
		[Category] [Const, editconst] public Actor.NavReference TargetMarker;
		public array<CoverLink.FireLinkItem> Items;
		public Object.Vector LastMarkerLocation;
		public bool bFallbackLink;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E4EAB
	//		TargetMarker = new Actor.NavReference
	//		{
	//			Nav = default,
	//			Guid = new Guid
	//			{
	//				A=0,
	//				B=0,
	//				C=0,
	//				D=0
	//			},
	//		};
	//		Items = default;
	//		LastMarkerLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		bFallbackLink = false;
	//	}
	};
	
	public partial struct /*native */ExposedLink
	{
		[Category] [Const, editconst] public Actor.NavReference TargetMarker;
		[Category] public float ExposedScale;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E5017
	//		TargetMarker = new Actor.NavReference
	//		{
	//			Nav = default,
	//			Guid = new Guid
	//			{
	//				A=0,
	//				B=0,
	//				C=0,
	//				D=0
	//			},
	//		};
	//		ExposedScale = 0.0f;
	//	}
	};
	
	public partial struct /*native */DangerLink
	{
		[Category] [Const, editconst] public Actor.NavReference DangerNav;
		[Category] public int DangerCost;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E513B
	//		DangerNav = new Actor.NavReference
	//		{
	//			Nav = default,
	//			Guid = new Guid
	//			{
	//				A=0,
	//				B=0,
	//				C=0,
	//				D=0
	//			},
	//		};
	//		DangerCost = 0;
	//	}
	};
	
	public partial struct /*native */CoverSlot
	{
		public Controller SlotOwner;
		[Category] public CoverLink.ECoverType ForceCoverType;
		[Category("Auto")] [editconst] public CoverLink.ECoverType CoverType;
		public Object.Vector LocationOffset;
		public Object.Vector FireLeftPos;
		public Object.Vector FireRightPos;
		public Object.Rotator RotationOffset;
		[duplicatetransient] public array<CoverLink.ECoverAction> Actions;
		[duplicatetransient] public array<CoverLink.FireLink> FireLinks;
		[duplicatetransient] public array<CoverLink.FireLink> ForcedFireLinks;
		[duplicatetransient] public array<CoverLink.CoverInfo> RejectedFireLinks;
		[duplicatetransient] public array<CoverLink.ExposedLink> ExposedFireLinks;
		[duplicatetransient] public array<CoverLink.DangerLink> DangerLinks;
		[duplicatetransient] public CoverLink.CoverReference MantleTarget;
		[duplicatetransient] public array<CoverLink.CoverReference> TurnTarget;
		[duplicatetransient] public array<CoverLink.CoverReference> SlipTarget;
		[Category("Auto")] [duplicatetransient, editconst] public array</*editconst */CoverLink.CoverReference> OverlapClaims;
		[Category("Auto")] public bool bLeanLeft;
		[Category("Auto")] public bool bLeanRight;
		[Category("Auto")] public bool bCanPopUp;
		[Category("Auto")] public float FireLeftOffset;
		[Category("Auto")] public float FireRightOffset;
		[editconst] public bool bCanMantle;
		[editconst] public bool bCanClimbUp;
		[editconst] public bool bCanCoverSlip_Left;
		[editconst] public bool bCanCoverSlip_Right;
		[editconst] public bool bCanSwatTurn_Left;
		[editconst] public bool bCanSwatTurn_Right;
		[Category] public bool bEnabled;
		[Category] public bool bAllowPopup;
		public bool bAllowMantle;
		public bool bAllowCoverSlip;
		public bool bAllowClimbUp;
		public bool bAllowSwatTurn;
		[transient] public bool bSelected;
		public float LeanTraceDist;
		[Category] [duplicatetransient, editconst] public CoverSlotMarker SlotMarker;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E5A57
	//		SlotOwner = default;
	//		ForceCoverType = CoverLink.ECoverType.CT_None;
	//		CoverType = CoverLink.ECoverType.CT_None;
	//		LocationOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		FireLeftPos = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		FireRightPos = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		RotationOffset = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		Actions = default;
	//		FireLinks = default;
	//		ForcedFireLinks = default;
	//		RejectedFireLinks = default;
	//		ExposedFireLinks = default;
	//		DangerLinks = default;
	//		MantleTarget = new CoverLink.CoverReference
	//		{
	//			SlotIdx = 0,
	//			Direction = 0,
	//			Nav = default,
	//			Guid = new Guid
	//			{
	//				A=0,
	//				B=0,
	//				C=0,
	//				D=0
	//			},
	//		};
	//		TurnTarget = default;
	//		SlipTarget = default;
	//		OverlapClaims = default;
	//		bLeanLeft = false;
	//		bLeanRight = false;
	//		bCanPopUp = false;
	//		FireLeftOffset = 0.0f;
	//		FireRightOffset = 0.0f;
	//		bCanMantle = true;
	//		bCanClimbUp = false;
	//		bCanCoverSlip_Left = true;
	//		bCanCoverSlip_Right = true;
	//		bCanSwatTurn_Left = true;
	//		bCanSwatTurn_Right = true;
	//		bEnabled = true;
	//		bAllowPopup = true;
	//		bAllowMantle = true;
	//		bAllowCoverSlip = false;
	//		bAllowClimbUp = false;
	//		bAllowSwatTurn = true;
	//		bSelected = false;
	//		LeanTraceDist = 200.0f;
	//		SlotMarker = default;
	//	}
	};
	
	public partial struct /*native */CoverRange
	{
		public int Low;
		public int High;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E5FCB
	//		Low = 0;
	//		High = 0;
	//	}
	};
	
	[Category] [editinline] public array</*editinline */CoverLink.CoverSlot> Slots;
	public array<Controller> Claims;
	[Category] public bool bDisabled;
	[Category] public bool bClaimAllSlots;
	public bool bAutoSort;
	[Category] public bool bAutoAdjust;
	[Category] public bool bForceCoverActions;
	public bool bCircular;
	public bool bLooped;
	public bool bPlayerOnly;
	public bool bDynamicCover;
	[transient] public bool bInvalidCover;
	[Category("Debug")] public bool bDebug_FireLinks;
	[Category("Debug")] public bool bDebug_ExposedLinks;
	[Category("Debug")] public bool bDebug_DangerLinks;
	public float MaxFireLinkDist;
	[Const] public Object.Vector CircularOrigin;
	[Const] public float CircularRadius;
	[Const] public float AlignDist;
	[Const] public float StandHeight;
	[Const] public float MidHeight;
	[Const] public float LowHeight;
	[Const] public CoverLink.CoverRange LowCover;
	[Const] public CoverLink.CoverRange MediumCover;
	[Const] public int SideOffsetTraceHeight;
	[transient] public float IvalidUntilThisTime;
	[Const] public float CornerDist;
	[Const] public float FireFromCornerDist;
	[Const] public Object.Vector StandingLeanOffset;
	[Const] public Object.Vector CrouchLeanOffset;
	[Const] public Object.Vector PopupOffset;
	[Const] public float SlipDist;
	[Const] public float TurnDist;
	public float DangerScale;
	[Const] public CoverLink NextCoverLink;
	
	// Export UCoverLink::execGetSlotLocation(FFrame&, void* const)
	public virtual /*native final simulated function */Object.Vector GetSlotLocation(int SlotIdx, /*optional */bool? _bForceUseOffset = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execGetSlotRotation(FFrame&, void* const)
	public virtual /*native final simulated function */Object.Rotator GetSlotRotation(int SlotIdx, /*optional */bool? _bForceUseOffset = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execGetSlotViewPoint(FFrame&, void* const)
	public virtual /*native final simulated function */Object.Vector GetSlotViewPoint(int SlotIdx, /*optional */CoverLink.ECoverType? _Type = default, /*optional */CoverLink.ECoverAction? _Action = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execGetSlotMarker(FFrame&, void* const)
	public virtual /*native final simulated function */CoverSlotMarker GetSlotMarker(int SlotIdx)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execGetSlotFireLocation(FFrame&, void* const)
	public virtual /*native final simulated function */Object.Vector GetSlotFireLocation(int SlotIdx, CoverLink.ECoverAction Action)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execIsExposedTo(FFrame&, void* const)
	public virtual /*native final simulated function */bool IsExposedTo(int SlotIdx, CoverLink.CoverInfo ChkSlot, ref float out_ExposedScale)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*final event */bool Claim(Controller NewClaim, int SlotIdx)
	{
		// stub
		return default;
	}
	
	public virtual /*final event */bool UnClaim(Controller OldClaim, int SlotIdx, bool bUnclaimAll)
	{
		// stub
		return default;
	}
	
	// Export UCoverLink::execIsValidClaim(FFrame&, void* const)
	public virtual /*native final function */bool IsValidClaim(Controller ChkClaim, int SlotIdx, /*optional */bool? _bSkipTeamCheck = default, /*optional */bool? _bSkipOverlapCheck = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*final simulated function */bool IsStationarySlot(int SlotIdx)
	{
		// stub
		return default;
	}
	
	// Export UCoverLink::execFindSlots(FFrame&, void* const)
	public virtual /*native final simulated function */bool FindSlots(Object.Vector CheckLocation, float MaxDistance, ref int LeftSlotIdx, ref int RightSlotIdx)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execIsEdgeSlot(FFrame&, void* const)
	public virtual /*native final simulated function */bool IsEdgeSlot(int SlotIdx, /*optional */bool? _bIgnoreLeans = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execIsLeftEdgeSlot(FFrame&, void* const)
	public virtual /*native final simulated function */bool IsLeftEdgeSlot(int SlotIdx, bool bIgnoreLeans)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execIsRightEdgeSlot(FFrame&, void* const)
	public virtual /*native final simulated function */bool IsRightEdgeSlot(int SlotIdx, bool bIgnoreLeans)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*final simulated function */bool AllowRightTransition(int SlotIdx)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated function */bool AllowLeftTransition(int SlotIdx)
	{
		// stub
		return default;
	}
	
	// Export UCoverLink::execGetFireLinkTo(FFrame&, void* const)
	public virtual /*native function */bool GetFireLinkTo(int SlotIdx, CoverLink.CoverInfo ChkCover, CoverLink.ECoverAction ChkAction, CoverLink.ECoverType ChkType, ref int out_FireLinkIdx, ref array<int> out_Items)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execHasFireLinkTo(FFrame&, void* const)
	public virtual /*native function */bool HasFireLinkTo(int SlotIdx, CoverLink.CoverInfo ChkCover, /*optional */bool? _bAllowFallbackLinks = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execGetSlotActions(FFrame&, void* const)
	public virtual /*native final function */void GetSlotActions(int SlotIdx, ref array<CoverLink.ECoverAction> Actions)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*simulated event */void SetDisabled(bool bNewDisabled)
	{
		// stub
	}
	
	public virtual /*simulated event */void SetSlotEnabled(int SlotIdx, bool bEnable)
	{
		// stub
	}
	
	public virtual /*function */void OnModifyCover(SeqAct_ModifyCover Action)
	{
		// stub
	}
	
	// Export UCoverLink::execAutoAdjustSlot(FFrame&, void* const)
	public virtual /*native final function */bool AutoAdjustSlot(int SlotIdx, bool bOnlyCheckLeans)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UCoverLink::execIsEnabled(FFrame&, void* const)
	public virtual /*native final function */bool IsEnabled()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*function */void OnToggle(SeqAct_Toggle inAction)
	{
		// stub
	}
	
	public virtual /*simulated function */bool GetSwatTurnTarget(int SlotIdx, int Direction, ref CoverLink.CoverReference out_Info)
	{
		// stub
		return default;
	}
	
	// Export UCoverLink::execAddCoverSlot(FFrame&, void* const)
	public virtual /*native final function */int AddCoverSlot(Object.Vector SlotLocation, Object.Rotator SlotRotation, /*optional */int? _SlotIdx = default, /*optional */bool? _bForceSlotUpdate = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*simulated function */String GetDebugString(int SlotIdx)
	{
		// stub
		return default;
	}
	
	public CoverLink()
	{
		var Default__CoverLink_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x0046641B
			CollisionHeight = 58.0f,
			CollisionRadius = 48.0f,
		}/* Reference: CylinderComponent'Default__CoverLink.CollisionCylinder' */;
		var Default__CoverLink_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CF76A
			Sprite = LoadAsset<Texture2D>("EngineResources.CoverNodeNone")/*Ref Texture2D'EngineResources.CoverNodeNone'*/,
		}/* Reference: SpriteComponent'Default__CoverLink.Sprite' */;
		var Default__CoverLink_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__CoverLink.Sprite2' */;
		var Default__CoverLink_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__CoverLink.Arrow' */;
		var Default__CoverLink_CoverMesh = new CoverMeshComponent
		{
			// Object Offset:0x0046637F
			bUseAsOccluder = false,
			bUsePrecomputedShadows = false,
		}/* Reference: CoverMeshComponent'Default__CoverLink.CoverMesh' */;
		// Object Offset:0x002E8A8E
		Slots = new array</*editinline */CoverLink.CoverSlot>
		{
			new CoverLink.CoverSlot
			{
				SlotOwner = default,
				ForceCoverType = CoverLink.ECoverType.CT_None,
				CoverType = CoverLink.ECoverType.CT_None,
				LocationOffset = new Vector
				{
					X=64.0f,
					Y=0.0f,
					Z=0.0f
				},
				FireLeftPos = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				FireRightPos = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				RotationOffset = new Rotator
				{
					Pitch=0,
					Yaw=0,
					Roll=0
				},
				Actions = default,
				FireLinks = default,
				ForcedFireLinks = default,
				RejectedFireLinks = default,
				ExposedFireLinks = default,
				DangerLinks = default,
				MantleTarget = new CoverLink.CoverReference
				{
					SlotIdx = 0,
					Direction = 0,
					Nav = default,
					Guid = new Guid
					{
						A=0,
						B=0,
						C=0,
						D=0
					},
				},
				TurnTarget = default,
				SlipTarget = default,
				OverlapClaims = default,
				bLeanLeft = false,
				bLeanRight = false,
				bCanPopUp = false,
				FireLeftOffset = 0.0f,
				FireRightOffset = 0.0f,
				bCanMantle = true,
				bCanClimbUp = false,
				bCanCoverSlip_Left = true,
				bCanCoverSlip_Right = true,
				bCanSwatTurn_Left = true,
				bCanSwatTurn_Right = true,
				bEnabled = true,
				bAllowPopup = true,
				bAllowMantle = true,
				bAllowCoverSlip = false,
				bAllowClimbUp = false,
				bAllowSwatTurn = true,
				bSelected = false,
				LeanTraceDist = 200.0f,
				SlotMarker = default,
			},
		};
		bAutoSort = true;
		bAutoAdjust = true;
		bDebug_FireLinks = true;
		MaxFireLinkDist = 2048.0f;
		AlignDist = 30.0f;
		StandHeight = 180.0f;
		MidHeight = 144.0f;
		LowHeight = 88.0f;
		LowCover = new CoverLink.CoverRange
		{
			Low = 50,
			High = 85,
		};
		MediumCover = new CoverLink.CoverRange
		{
			Low = 110,
			High = 150,
		};
		SideOffsetTraceHeight = 110;
		CornerDist = 120.0f;
		FireFromCornerDist = 50.0f;
		StandingLeanOffset = new Vector
		{
			X=0.0f,
			Y=88.0f,
			Z=69.0f
		};
		CrouchLeanOffset = new Vector
		{
			X=0.0f,
			Y=80.0f,
			Z=19.0f
		};
		PopupOffset = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=100.0f
		};
		SlipDist = 152.0f;
		TurnDist = 512.0f;
		DangerScale = 2.0f;
		bSpecialMove = true;
		CylinderComponent = Default__CoverLink_CollisionCylinder/*Ref CylinderComponent'Default__CoverLink.CollisionCylinder'*/;
		GoodSprite = Default__CoverLink_Sprite/*Ref SpriteComponent'Default__CoverLink.Sprite'*/;
		BadSprite = Default__CoverLink_Sprite2/*Ref SpriteComponent'Default__CoverLink.Sprite2'*/;
		Abbrev = "CL";
		Components = new array</*export editinline */ActorComponent>
		{
			Default__CoverLink_Sprite/*Ref SpriteComponent'Default__CoverLink.Sprite'*/,
			Default__CoverLink_Sprite2/*Ref SpriteComponent'Default__CoverLink.Sprite2'*/,
			Default__CoverLink_Arrow/*Ref ArrowComponent'Default__CoverLink.Arrow'*/,
			Default__CoverLink_CollisionCylinder/*Ref CylinderComponent'Default__CoverLink.CollisionCylinder'*/,
			Default__CoverLink_CoverMesh/*Ref CoverMeshComponent'Default__CoverLink.CoverMesh'*/,
		};
		CollisionComponent = Default__CoverLink_CollisionCylinder/*Ref CylinderComponent'Default__CoverLink.CollisionCylinder'*/;
	}
}
}