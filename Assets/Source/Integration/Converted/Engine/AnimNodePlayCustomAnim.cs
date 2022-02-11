namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodePlayCustomAnim : AnimNodeBlend/*
		native
		hidecategories(Object,Object,Object)*/{
	public bool bIsPlayingCustomAnim;
	public float CustomPendingBlendOutTime;
	
	// Export UAnimNodePlayCustomAnim::execPlayCustomAnim(FFrame&, void* const)
	public virtual /*native final function */float PlayCustomAnim(name AnimName, float Rate, /*optional */float? _BlendInTime = default, /*optional */float? _BlendOutTime = default, /*optional */bool? _bLooping = default, /*optional */bool? _bOverride = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UAnimNodePlayCustomAnim::execPlayCustomAnimByDuration(FFrame&, void* const)
	public virtual /*native final function */void PlayCustomAnimByDuration(name AnimName, float Duration, /*optional */float? _BlendInTime = default, /*optional */float? _BlendOutTime = default, /*optional */bool? _bLooping = default, /*optional */bool? _bOverride = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*final function */void SetCustomAnim(name AnimName)
	{
		/*local */AnimNodeSequence SeqNode = default;
	
		SeqNode = ((Children[1].Anim) as AnimNodeSequence);
		if(SeqNode != default)
		{
			SeqNode.SetAnim(AnimName);
		}
	}
	
	public virtual /*final function */void SetActorAnimEndNotification(bool bNewStatus)
	{
		/*local */AnimNodeSequence SeqNode = default;
	
		SeqNode = ((Children[1].Anim) as AnimNodeSequence);
		if(SeqNode != default)
		{
			SeqNode.bCauseActorAnimEnd = bNewStatus;
		}
	}
	
	public virtual /*final function */AnimNodeSequence GetCustomAnimNodeSeq()
	{
		return ((Children[1].Anim) as AnimNodeSequence);
	}
	
	public virtual /*final function */void SetRootBoneAxisOption(/*optional */AnimNodeSequence.ERootBoneAxis? _AxisX = default, /*optional */AnimNodeSequence.ERootBoneAxis? _AxisY = default, /*optional */AnimNodeSequence.ERootBoneAxis? _AxisZ = default)
	{
		/*local */AnimNodeSequence AnimSeq = default;
	
		var AxisX = _AxisX ?? 0;
		var AxisY = _AxisY ?? 0;
		var AxisZ = _AxisZ ?? 0;
		AnimSeq = GetCustomAnimNodeSeq();
		if(AnimSeq != default)
		{
			AnimSeq.RootBoneOption[0] = AxisX;
			AnimSeq.RootBoneOption[1] = AxisY;
			AnimSeq.RootBoneOption[2] = AxisZ;		
		}
	}
	
	public AnimNodePlayCustomAnim()
	{
		// Object Offset:0x0029C59F
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Normal",
				Anim = default,
				Weight = 1.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = false,
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
				Name = (name)"Custom",
				Anim = default,
				Weight = 0.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = false,
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
		NodeName = (name)"CustomAnim";
	}
}
}