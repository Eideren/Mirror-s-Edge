namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeSlot : AnimNodeBlendBase/*
		native
		hidecategories(Object,Object,Object)*/{
	public /*const */bool bIsPlayingCustomAnim;
	public /*const */float PendingBlendOutTime;
	public /*const */int CustomChildIndex;
	public /*const */int TargetChildIndex;
	public array<float> TargetWeight;
	public /*const */float BlendTimeToGo;
	public /*const transient */AnimNodeSynch SynchNode;
	
	// Export UAnimNodeSlot::execPlayCustomAnim(FFrame&, void* const)
	public virtual /*native final function */float PlayCustomAnim(name AnimName, float Rate, /*optional */float? _BlendInTime = default, /*optional */float? _BlendOutTime = default, /*optional */bool? _bLooping = default, /*optional */bool? _bOverride = default)
	{
		 // #warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UAnimNodeSlot::execPlayCustomAnimByDuration(FFrame&, void* const)
	public virtual /*native final function */void PlayCustomAnimByDuration(name AnimName, float Duration, /*optional */float? _BlendInTime = default, /*optional */float? _BlendOutTime = default, /*optional */bool? _bLooping = default, /*optional */bool? _bOverride = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UAnimNodeSlot::execGetPlayedAnimation(FFrame&, void* const)
	public virtual /*native final function */name GetPlayedAnimation()
	{
		 // #warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UAnimNodeSlot::execStopCustomAnim(FFrame&, void* const)
	public virtual /*native final function */void StopCustomAnim(float BlendOutTime)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UAnimNodeSlot::execSetCustomAnim(FFrame&, void* const)
	public virtual /*native final function */void SetCustomAnim(name AnimName)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UAnimNodeSlot::execSetActorAnimEndNotification(FFrame&, void* const)
	public virtual /*native final function */void SetActorAnimEndNotification(bool bNewStatus)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UAnimNodeSlot::execGetCustomAnimNodeSeq(FFrame&, void* const)
	public virtual /*native final function */AnimNodeSequence GetCustomAnimNodeSeq()
	{
		 // #warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UAnimNodeSlot::execSetRootBoneAxisOption(FFrame&, void* const)
	public virtual /*native final function */void SetRootBoneAxisOption(/*optional */AnimNodeSequence.ERootBoneAxis? _AxisX = default, /*optional */AnimNodeSequence.ERootBoneAxis? _AxisY = default, /*optional */AnimNodeSequence.ERootBoneAxis? _AxisZ = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UAnimNodeSlot::execAddToSynchGroup(FFrame&, void* const)
	public virtual /*native final function */void AddToSynchGroup(name GroupName)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	public AnimNodeSlot()
	{
		// Object Offset:0x0029ED13
		TargetWeight = new array<float>
		{
			1.0f,
		};
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Source",
				Anim = default,
				Weight = 1.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = 0,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Channel 01",
				Anim = default,
				Weight = 0.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = 0,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
		};
		NodeName = (name)"SlotName";
	}
}
}