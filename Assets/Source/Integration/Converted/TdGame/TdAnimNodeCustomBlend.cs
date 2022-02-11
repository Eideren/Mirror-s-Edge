namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeCustomBlend : TdAnimNodeBlendList/*
		native
		hidecategories(Object,Object,Object)*/{
	public float Duration;
	public float BlendOutTime;
	
	public virtual /*simulated function */void Activate(float Amount, float _Duration, float BlendIn, float BlendOut)
	{
		TargetWeight[0] = 1.0f - Amount;
		TargetWeight[1] = Amount;
		BlendTimeToGo = BlendIn;
		ActiveChildIndex = 1;
		BlendOutTime = BlendOut;
		Duration = _Duration;
	}
	
	public override /*event */void OnBecomeRelevant()
	{
		if(Duration <= 0.0f)
		{
			SetActiveChild(0, 0.0f);
		}
		base.OnBecomeRelevant();
	}
	
	public TdAnimNodeCustomBlend()
	{
		// Object Offset:0x005015FA
		BlendWeight = new array<float>
		{
			1.0f,
			0.0f,
		};
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Default",
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
		bFixNumChildren = true;
	}
}
}