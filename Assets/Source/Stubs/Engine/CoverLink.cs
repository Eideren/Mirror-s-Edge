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
		public/*()*/ NavigationPoint Nav;
		public/*()*/ /*const editconst */Object.Guid Guid;
	
		public/*()*/ int SlotIdx;
		public/*()*/ int Direction;
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
		public/*()*/ /*editconst */CoverLink Link;
		public/*()*/ /*editconst */int SlotIdx;
	
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
		public/*()*/ /*const editconst */Actor.NavReference TargetMarker;
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
		public/*()*/ /*const editconst */Actor.NavReference TargetMarker;
		public/*()*/ float ExposedScale;
	
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
		public/*()*/ /*const editconst */Actor.NavReference DangerNav;
		public/*()*/ int DangerCost;
	
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
		public/*()*/ CoverLink.ECoverType ForceCoverType;
		public/*(Auto)*/ /*editconst */CoverLink.ECoverType CoverType;
		public Object.Vector LocationOffset;
		public Object.Vector FireLeftPos;
		public Object.Vector FireRightPos;
		public Object.Rotator RotationOffset;
		public /*duplicatetransient */array<CoverLink.ECoverAction> Actions;
		public /*duplicatetransient */array<CoverLink.FireLink> FireLinks;
		public /*duplicatetransient */array<CoverLink.FireLink> ForcedFireLinks;
		public /*duplicatetransient */array<CoverLink.CoverInfo> RejectedFireLinks;
		public /*duplicatetransient */array<CoverLink.ExposedLink> ExposedFireLinks;
		public /*duplicatetransient */array<CoverLink.DangerLink> DangerLinks;
		public /*duplicatetransient */CoverLink.CoverReference MantleTarget;
		public /*duplicatetransient */array<CoverLink.CoverReference> TurnTarget;
		public /*duplicatetransient */array<CoverLink.CoverReference> SlipTarget;
		public/*(Auto)*/ /*duplicatetransient editconst */array</*editconst */CoverLink.CoverReference> OverlapClaims;
		public/*(Auto)*/ bool bLeanLeft;
		public/*(Auto)*/ bool bLeanRight;
		public/*(Auto)*/ bool bCanPopUp;
		public/*(Auto)*/ float FireLeftOffset;
		public/*(Auto)*/ float FireRightOffset;
		public /*editconst */bool bCanMantle;
		public /*editconst */bool bCanClimbUp;
		public /*editconst */bool bCanCoverSlip_Left;
		public /*editconst */bool bCanCoverSlip_Right;
		public /*editconst */bool bCanSwatTurn_Left;
		public /*editconst */bool bCanSwatTurn_Right;
		public/*()*/ bool bEnabled;
		public/*()*/ bool bAllowPopup;
		public bool bAllowMantle;
		public bool bAllowCoverSlip;
		public bool bAllowClimbUp;
		public bool bAllowSwatTurn;
		public /*transient */bool bSelected;
		public float LeanTraceDist;
		public/*()*/ /*duplicatetransient editconst */CoverSlotMarker SlotMarker;
	
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
	
	public/*()*/ /*editinline */array</*editinline */CoverLink.CoverSlot> Slots;
	public array<Controller> Claims;
	public/*()*/ bool bDisabled;
	public/*()*/ bool bClaimAllSlots;
	public bool bAutoSort;
	public/*()*/ bool bAutoAdjust;
	public/*()*/ bool bForceCoverActions;
	public bool bCircular;
	public bool bLooped;
	public bool bPlayerOnly;
	public bool bDynamicCover;
	public /*transient */bool bInvalidCover;
	public/*(Debug)*/ bool bDebug_FireLinks;
	public/*(Debug)*/ bool bDebug_ExposedLinks;
	public/*(Debug)*/ bool bDebug_DangerLinks;
	public float MaxFireLinkDist;
	public /*const */Object.Vector CircularOrigin;
	public /*const */float CircularRadius;
	public /*const */float AlignDist;
	public /*const */float StandHeight;
	public /*const */float MidHeight;
	public /*const */float LowHeight;
	public /*const */CoverLink.CoverRange LowCover;
	public /*const */CoverLink.CoverRange MediumCover;
	public /*const */int SideOffsetTraceHeight;
	public /*transient */float IvalidUntilThisTime;
	public /*const */float CornerDist;
	public /*const */float FireFromCornerDist;
	public /*const */Object.Vector StandingLeanOffset;
	public /*const */Object.Vector CrouchLeanOffset;
	public /*const */Object.Vector PopupOffset;
	public /*const */float SlipDist;
	public /*const */float TurnDist;
	public float DangerScale;
	public /*const */CoverLink NextCoverLink;
	
	// Export UCoverLink::execGetSlotLocation(FFrame&, void* const)
	public virtual /*native final simulated function */Object.Vector GetSlotLocation(int SlotIdx, /*optional */bool bForceUseOffset = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execGetSlotRotation(FFrame&, void* const)
	public virtual /*native final simulated function */Object.Rotator GetSlotRotation(int SlotIdx, /*optional */bool bForceUseOffset = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execGetSlotViewPoint(FFrame&, void* const)
	public virtual /*native final simulated function */Object.Vector GetSlotViewPoint(int SlotIdx, /*optional */CoverLink.ECoverType Type = default, /*optional */CoverLink.ECoverAction Action = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execGetSlotMarker(FFrame&, void* const)
	public virtual /*native final simulated function */CoverSlotMarker GetSlotMarker(int SlotIdx)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execGetSlotFireLocation(FFrame&, void* const)
	public virtual /*native final simulated function */Object.Vector GetSlotFireLocation(int SlotIdx, CoverLink.ECoverAction Action)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execIsExposedTo(FFrame&, void* const)
	public virtual /*native final simulated function */bool IsExposedTo(int SlotIdx, CoverLink.CoverInfo ChkSlot, ref float out_ExposedScale)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final event */bool Claim(Controller NewClaim, int SlotIdx)
	{
	
		return default;
	}
	
	public virtual /*final event */bool UnClaim(Controller OldClaim, int SlotIdx, bool bUnclaimAll)
	{
	
		return default;
	}
	
	// Export UCoverLink::execIsValidClaim(FFrame&, void* const)
	public virtual /*native final function */bool IsValidClaim(Controller ChkClaim, int SlotIdx, /*optional */bool bSkipTeamCheck = default, /*optional */bool bSkipOverlapCheck = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final simulated function */bool IsStationarySlot(int SlotIdx)
	{
	
		return default;
	}
	
	// Export UCoverLink::execFindSlots(FFrame&, void* const)
	public virtual /*native final simulated function */bool FindSlots(Object.Vector CheckLocation, float MaxDistance, ref int LeftSlotIdx, ref int RightSlotIdx)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execIsEdgeSlot(FFrame&, void* const)
	public virtual /*native final simulated function */bool IsEdgeSlot(int SlotIdx, /*optional */bool bIgnoreLeans = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execIsLeftEdgeSlot(FFrame&, void* const)
	public virtual /*native final simulated function */bool IsLeftEdgeSlot(int SlotIdx, bool bIgnoreLeans)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execIsRightEdgeSlot(FFrame&, void* const)
	public virtual /*native final simulated function */bool IsRightEdgeSlot(int SlotIdx, bool bIgnoreLeans)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final simulated function */bool AllowRightTransition(int SlotIdx)
	{
	
		return default;
	}
	
	public virtual /*final simulated function */bool AllowLeftTransition(int SlotIdx)
	{
	
		return default;
	}
	
	// Export UCoverLink::execGetFireLinkTo(FFrame&, void* const)
	public virtual /*native function */bool GetFireLinkTo(int SlotIdx, CoverLink.CoverInfo ChkCover, CoverLink.ECoverAction ChkAction, CoverLink.ECoverType ChkType, ref int out_FireLinkIdx, ref array<int> out_Items)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execHasFireLinkTo(FFrame&, void* const)
	public virtual /*native function */bool HasFireLinkTo(int SlotIdx, CoverLink.CoverInfo ChkCover, /*optional */bool bAllowFallbackLinks = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execGetSlotActions(FFrame&, void* const)
	public virtual /*native final function */void GetSlotActions(int SlotIdx, ref array<CoverLink.ECoverAction> Actions)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*simulated event */void SetDisabled(bool bNewDisabled)
	{
	
	}
	
	public virtual /*simulated event */void SetSlotEnabled(int SlotIdx, bool bEnable)
	{
	
	}
	
	public virtual /*function */void OnModifyCover(SeqAct_ModifyCover Action)
	{
	
	}
	
	// Export UCoverLink::execAutoAdjustSlot(FFrame&, void* const)
	public virtual /*native final function */bool AutoAdjustSlot(int SlotIdx, bool bOnlyCheckLeans)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverLink::execIsEnabled(FFrame&, void* const)
	public virtual /*native final function */bool IsEnabled()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */void OnToggle(SeqAct_Toggle inAction)
	{
	
	}
	
	public virtual /*simulated function */bool GetSwatTurnTarget(int SlotIdx, int Direction, ref CoverLink.CoverReference out_Info)
	{
	
		return default;
	}
	
	// Export UCoverLink::execAddCoverSlot(FFrame&, void* const)
	public virtual /*native final function */int AddCoverSlot(Object.Vector SlotLocation, Object.Rotator SlotRotation, /*optional */int SlotIdx = default, /*optional */bool bForceSlotUpdate = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*simulated function */string GetDebugString(int SlotIdx)
	{
	
		return default;
	}
	
	public CoverLink()
	{
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
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x0046641B
			CollisionHeight = 58.0f,
			CollisionRadius = 48.0f,
		}/* Reference: CylinderComponent'Default__CoverLink.CollisionCylinder' */;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x004CF76A
			Sprite = LoadAsset<Texture2D>("EngineResources.CoverNodeNone")/*Ref Texture2D'EngineResources.CoverNodeNone'*/,
		}/* Reference: SpriteComponent'Default__CoverLink.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__CoverLink.Sprite2")/*Ref SpriteComponent'Default__CoverLink.Sprite2'*/;
		Abbrev = "CL";
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x004CF76A
				Sprite = LoadAsset<Texture2D>("EngineResources.CoverNodeNone")/*Ref Texture2D'EngineResources.CoverNodeNone'*/,
			}/* Reference: SpriteComponent'Default__CoverLink.Sprite' */,
			LoadAsset<SpriteComponent>("Default__CoverLink.Sprite2")/*Ref SpriteComponent'Default__CoverLink.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__CoverLink.Arrow")/*Ref ArrowComponent'Default__CoverLink.Arrow'*/,
			//Components[3]=
			new CylinderComponent
			{
				// Object Offset:0x0046641B
				CollisionHeight = 58.0f,
				CollisionRadius = 48.0f,
			}/* Reference: CylinderComponent'Default__CoverLink.CollisionCylinder' */,
			//Components[4]=
			new CoverMeshComponent
			{
				// Object Offset:0x0046637F
				bUseAsOccluder = false,
				bUsePrecomputedShadows = false,
			}/* Reference: CoverMeshComponent'Default__CoverLink.CoverMesh' */,
		};
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x0046641B
			CollisionHeight = 58.0f,
			CollisionRadius = 48.0f,
		}/* Reference: CylinderComponent'Default__CoverLink.CollisionCylinder' */;
	}
}
}