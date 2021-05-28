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
	
	}
	
	public virtual /*function */void SetupCover()
	{
	
	}
	
	public virtual /*function */Object.Vector GetFireLocation(TdAIAnimationController.ECoverDirectionState Dir)
	{
	
		return default;
	}
	
	public virtual /*function */Object.Rotator GetFireRotation(TdAIAnimationController.ECoverDirectionState Dir)
	{
	
		return default;
	}
	
	public virtual /*function */void Claim()
	{
	
	}
	
	public virtual /*function */bool HasClaimedCover()
	{
	
		return default;
	}
	
	public virtual /*function */void Drop()
	{
	
	}
	
	public virtual /*function */void MarkInvalid()
	{
	
	}
	
	public virtual /*function */void MarkAsTemporaryInvalid(float InvalidTime)
	{
	
	}
	
	// Export UTdCover::execAttemptReclaimCover(FFrame&, void* const)
	public virtual /*native final function */bool AttemptReclaimCover(CoverLink ActiveCoverLink, int ActiveSlotId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdCover::execGetCoverQuality(FFrame&, void* const)
	public virtual /*native final function */TdCover.ECoverQuality GetCoverQuality(CoverLink ActiveCoverLink, int ActiveSlotId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool IsValid(Object.Vector EnemyPosition, bool bFireCover)
	{
	
		return default;
	}
	
	// Export UTdCover::execIsCoverValid(FFrame&, void* const)
	public virtual /*native final function */bool IsCoverValid(Object.Vector EnemyPosition, CoverLink ActiveCoverLink, int ActiveSlotId, bool bFireCover)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdCover::execIsWithinRestraints(FFrame&, void* const)
	public virtual /*native final function */bool IsWithinRestraints(CoverLink TestLink)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdCover::execGetMinimumEnemyCoverDistance(FFrame&, void* const)
	public virtual /*native final function */float GetMinimumEnemyCoverDistance()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdCover::execHasValidCoverDirection(FFrame&, void* const)
	public virtual /*private native final function */bool HasValidCoverDirection(CoverLink ActiveCoverLink, int ActiveSlotId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool SelectCoverDirection(ref TdAIAnimationController.ECoverDirectionState iCoverDirection)
	{
	
		return default;
	}
	
	// Export UTdCover::execSelectCoverDirectionInternal(FFrame&, void* const)
	public virtual /*private native final function */TdAIAnimationController.ECoverDirectionState SelectCoverDirectionInternal(CoverLink ActiveCoverLink, int ActiveSlotId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdCover::execFindClosestUsableCover(FFrame&, void* const)
	public virtual /*private native final function */void FindClosestUsableCover(ref CoverLink out_Link, ref int out_SlotId)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */CoverSlotMarker GetSlotMarker()
	{
	
		return default;
	}
	
	public virtual /*function */bool FindNewCover()
	{
	
		return default;
	}
	
	public virtual /*function */bool PickClosestCover()
	{
	
		return default;
	}
	
	public virtual /*function */void PickRandomCover()
	{
	
	}
	
	public virtual /*function */void CoverDrawDebug()
	{
	
	}
	
	public virtual /*function */void AddToIgnoreList(CoverLink L, int S, float Time)
	{
	
	}
	
	// Export UTdCover::execShouldIgnore(FFrame&, void* const)
	public virtual /*native function */bool ShouldIgnore(CoverLink L, int S)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void VerifyHasValidCoverDirectionFailed(CoverLink ActiveCoverLink, bool bHasCoverType)
	{
	
	}
	
	public virtual /*event */void SelectCoverDirectionFailed(CoverLink ActiveCoverLink)
	{
	
	}
	
	public virtual /*function */bool HaveOppositeCoverDir(TdAIAnimationController.ECoverDirectionState Dir)
	{
	
		return default;
	}
	
}
}