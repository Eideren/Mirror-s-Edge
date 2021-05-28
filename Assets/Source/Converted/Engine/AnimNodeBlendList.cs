namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeBlendList : AnimNodeBlendBase/*
		native
		hidecategories(Object,Object,Object)*/{
	public array<float> TargetWeight;
	public float BlendTimeToGo;
	public int ActiveChildIndex;
	public/*()*/ bool bPlayActiveChild;
	
	// Export UAnimNodeBlendList::execSetActiveChild(FFrame&, void* const)
	public virtual /*native function */void SetActiveChild(int ChildIndex, float BlendTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	public AnimNodeBlendList()
	{
		// Object Offset:0x00297F57
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Child1",
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
	}
}
}