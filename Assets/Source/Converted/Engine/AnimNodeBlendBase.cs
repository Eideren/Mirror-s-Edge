namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeBlendBase : AnimNode/*
		abstract
		native
		hidecategories(Object,Object)*/{
	public partial struct /*native */AnimBlendChild
	{
		public/*()*/ name Name;
		public /*export editinline */AnimNode Anim;
		public float Weight;
		public /*const */float TotalWeight;
		public /*const transient */int bHasRootMotion;
		public /*const transient */AnimNode.BoneAtom RootMotion;
		public bool bMirrorSkeleton;
		public int DrawY;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002962D3
	//		Name = (name)"None";
	//		Anim = default;
	//		Weight = 0.0f;
	//		TotalWeight = 0.0f;
	//		bHasRootMotion = 0;
	//		RootMotion = new AnimNode.BoneAtom
	//		{
	//			Rotation = new Quat
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f,
	//				W=0.0f
	//			},
	//			Translation = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			Scale = 0.0f,
	//		};
	//		bMirrorSkeleton = false;
	//		DrawY = 0;
	//	}
	};
	
	public /*editfixedsize export editinline */array</*export editinline */AnimNodeBlendBase.AnimBlendChild> Children;
	public bool bFixNumChildren;
	
	// Export UAnimNodeBlendBase::execPlayAnim(FFrame&, void* const)
	public override /*native function */void PlayAnim(/*optional */bool bLoop = default, /*optional */float Rate = default, /*optional */float StartTime = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UAnimNodeBlendBase::execStopAnim(FFrame&, void* const)
	public override /*native function */void StopAnim()
	{
		#warning NATIVE FUNCTION !
	}
	
}
}