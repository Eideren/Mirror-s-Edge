namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCover : Object/*
		native*/{
	public enum ECoverQuality 
	{
		ECQ_Invalid,
		ECQ_Poor,
		ECQ_Good,
		ECQ_Perfect,
		ECQ_MAX
	};
	
	public partial struct /*native */IgnoreStruct
	{
		public CoverLink Link;
		public int Slot;
		public float IgnoreTime;
		public float StartTimeStamp;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00539341
	//		Link = default;
	//		Slot = 0;
	//		IgnoreTime = 0.0f;
	//		StartTimeStamp = 0.0f;
	//	}
	};
	
	public TdAIController Owner;
	public int SlotIdx;
	public CoverLink Link;
	public int PreviousSlotIdx;
	public CoverLink PreviousCoverLink;
	public array<TdCover.IgnoreStruct> IgnoreList;
	public Object.Vector Direction;
	public Object.Rotator Rotation;
	public Object.Vector Location;
	public Object.Vector CoverLeftLocation;
	public Object.Vector CoverRightLocation;
	public Object.Vector CoverLeftDirection;
	public Object.Vector CoverRightDirection;
	public Object.Vector FireLeftLocation;
	public Object.Vector FireRightLocation;
	public CoverLink.ECoverType CoverType;
	public bool bLeanLeft;
	public bool bLeanRight;
	public bool bCanPopUp;
	public bool bClaimed;
	public bool bAlwaysValid;
	public float LastCoverTime;
	
	public virtual /*function */void Initialize(TdAIController Drone)
	{
		// stub
	}
	
	public virtual /*function */void SetupCover()
	{
		// stub
	}
	
	public virtual /*function */Object.Vector GetFireLocation(TdAIAnimationController.ECoverDirectionState Dir)
	{
		// stub
		return default;
	}
	
	public virtual /*function */Object.Rotator GetFireRotation(TdAIAnimationController.ECoverDirectionState Dir)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void Claim()
	{
		// stub
	}
	
	public virtual /*function */bool HasClaimedCover()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void Drop()
	{
		// stub
	}
	
	public virtual /*function */void MarkInvalid()
	{
		// stub
	}
	
	public virtual /*function */void MarkAsTemporaryInvalid(float InvalidTime)
	{
		// stub
	}
	
	// Export UTdCover::execAttemptReclaimCover(FFrame&, void* const)
	public virtual /*native final function */bool AttemptReclaimCover(CoverLink ActiveCoverLink, int ActiveSlotId)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTdCover::execGetCoverQuality(FFrame&, void* const)
	public virtual /*native final function */TdCover.ECoverQuality GetCoverQuality(CoverLink ActiveCoverLink, int ActiveSlotId)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*function */bool IsValid(Object.Vector EnemyPosition, bool bFireCover)
	{
		// stub
		return default;
	}
	
	// Export UTdCover::execIsCoverValid(FFrame&, void* const)
	public virtual /*native final function */bool IsCoverValid(Object.Vector EnemyPosition, CoverLink ActiveCoverLink, int ActiveSlotId, bool bFireCover)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTdCover::execIsWithinRestraints(FFrame&, void* const)
	public virtual /*native final function */bool IsWithinRestraints(CoverLink TestLink)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTdCover::execGetMinimumEnemyCoverDistance(FFrame&, void* const)
	public virtual /*native final function */float GetMinimumEnemyCoverDistance()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTdCover::execHasValidCoverDirection(FFrame&, void* const)
	public virtual /*private native final function */bool HasValidCoverDirection(CoverLink ActiveCoverLink, int ActiveSlotId)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*function */bool SelectCoverDirection(ref TdAIAnimationController.ECoverDirectionState iCoverDirection)
	{
		// stub
		return default;
	}
	
	// Export UTdCover::execSelectCoverDirectionInternal(FFrame&, void* const)
	public virtual /*private native final function */TdAIAnimationController.ECoverDirectionState SelectCoverDirectionInternal(CoverLink ActiveCoverLink, int ActiveSlotId)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTdCover::execFindClosestUsableCover(FFrame&, void* const)
	public virtual /*private native final function */void FindClosestUsableCover(ref CoverLink out_Link, ref int out_SlotId)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*function */CoverSlotMarker GetSlotMarker()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool FindNewCover()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool PickClosestCover()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void PickRandomCover()
	{
		// stub
	}
	
	public virtual /*function */void CoverDrawDebug()
	{
		// stub
	}
	
	public virtual /*function */void AddToIgnoreList(CoverLink L, int S, float Time)
	{
		// stub
	}
	
	// Export UTdCover::execShouldIgnore(FFrame&, void* const)
	public virtual /*native function */bool ShouldIgnore(CoverLink L, int S)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*event */void VerifyHasValidCoverDirectionFailed(CoverLink ActiveCoverLink, bool bHasCoverType)
	{
		// stub
	}
	
	public virtual /*event */void SelectCoverDirectionFailed(CoverLink ActiveCoverLink)
	{
		// stub
	}
	
	public virtual /*function */bool HaveOppositeCoverDir(TdAIAnimationController.ECoverDirectionState Dir)
	{
		// stub
		return default;
	}
	
}
}