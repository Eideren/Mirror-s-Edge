namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeAimOffset : AnimNodeBlendBase/*
		native
		hidecategories(Object,Object,Object)*/{
	public enum EAnimAimDir 
	{
		ANIMAIM_LEFTUP,
		ANIMAIM_CENTERUP,
		ANIMAIM_RIGHTUP,
		ANIMAIM_LEFTCENTER,
		ANIMAIM_CENTERCENTER,
		ANIMAIM_RIGHTCENTER,
		ANIMAIM_LEFTDOWN,
		ANIMAIM_CENTERDOWN,
		ANIMAIM_RIGHTDOWN,
		ANIMAIM_MAX
	};
	
	public partial struct /*native */AimTransform
	{
		public/*()*/ Object.Quat Quaternion;
		public/*()*/ Object.Vector Translation;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0029675F
	//		Quaternion = new Quat
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f
	//		};
	//		Translation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public partial struct /*native */AimComponent
	{
		public/*()*/ name BoneName;
		public/*()*/ AnimNodeAimOffset.AimTransform LU;
		public/*()*/ AnimNodeAimOffset.AimTransform LC;
		public/*()*/ AnimNodeAimOffset.AimTransform LD;
		public/*()*/ AnimNodeAimOffset.AimTransform CU;
		public/*()*/ AnimNodeAimOffset.AimTransform CC;
		public/*()*/ AnimNodeAimOffset.AimTransform CD;
		public/*()*/ AnimNodeAimOffset.AimTransform RU;
		public/*()*/ AnimNodeAimOffset.AimTransform RC;
		public/*()*/ AnimNodeAimOffset.AimTransform RD;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002969CF
	//		BoneName = (name)"None";
	//		LU = new AnimNodeAimOffset.AimTransform
	//		{
	//			Quaternion = new Quat
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
	//		};
	//		LC = new AnimNodeAimOffset.AimTransform
	//		{
	//			Quaternion = new Quat
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
	//		};
	//		LD = new AnimNodeAimOffset.AimTransform
	//		{
	//			Quaternion = new Quat
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
	//		};
	//		CU = new AnimNodeAimOffset.AimTransform
	//		{
	//			Quaternion = new Quat
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
	//		};
	//		CC = new AnimNodeAimOffset.AimTransform
	//		{
	//			Quaternion = new Quat
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
	//		};
	//		CD = new AnimNodeAimOffset.AimTransform
	//		{
	//			Quaternion = new Quat
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
	//		};
	//		RU = new AnimNodeAimOffset.AimTransform
	//		{
	//			Quaternion = new Quat
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
	//		};
	//		RC = new AnimNodeAimOffset.AimTransform
	//		{
	//			Quaternion = new Quat
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
	//		};
	//		RD = new AnimNodeAimOffset.AimTransform
	//		{
	//			Quaternion = new Quat
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
	//		};
	//	}
	};
	
	public partial struct /*native */AimOffsetProfile
	{
		public/*()*/ /*const editconst */name ProfileName;
		public/*()*/ Object.Vector2D HorizontalRange;
		public/*()*/ Object.Vector2D VerticalRange;
		public array<AnimNodeAimOffset.AimComponent> AimComponents;
		public/*()*/ name AnimName_LU;
		public/*()*/ name AnimName_LC;
		public/*()*/ name AnimName_LD;
		public/*()*/ name AnimName_CU;
		public/*()*/ name AnimName_CC;
		public/*()*/ name AnimName_CD;
		public/*()*/ name AnimName_RU;
		public/*()*/ name AnimName_RC;
		public/*()*/ name AnimName_RD;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002973AB
	//		ProfileName = (name)"Default";
	//		HorizontalRange = new Vector2D
	//		{
	//			X=-1.0f,
	//			Y=1.0f
	//		};
	//		VerticalRange = new Vector2D
	//		{
	//			X=-1.0f,
	//			Y=1.0f
	//		};
	//		AimComponents = default;
	//		AnimName_LU = (name)"None";
	//		AnimName_LC = (name)"None";
	//		AnimName_LD = (name)"None";
	//		AnimName_CU = (name)"None";
	//		AnimName_CC = (name)"None";
	//		AnimName_CD = (name)"None";
	//		AnimName_RU = (name)"None";
	//		AnimName_RC = (name)"None";
	//		AnimName_RD = (name)"None";
	//	}
	};
	
	public/*()*/ Object.Vector2D Aim;
	public/*()*/ Object.Vector2D AngleOffset;
	public/*()*/ bool bForceAimDir;
	public/*()*/ bool bBakeFromAnimations;
	public/*()*/ int PassThroughAtOrAboveLOD;
	public/*()*/ AnimNodeAimOffset.EAnimAimDir ForcedAimDir;
	public /*transient */array<byte> RequiredBones;
	public /*transient */array<int> BoneToAimCpnt;
	public /*transient */AnimNodeAimOffset TemplateNode;
	public/*()*/ /*editconst */array</*editconst */AnimNodeAimOffset.AimOffsetProfile> Profiles;
	public/*()*/ /*const editconst */int CurrentProfileIndex;
	
	// Export UAnimNodeAimOffset::execSetActiveProfileByName(FFrame&, void* const)
	public virtual /*native function */void SetActiveProfileByName(name ProfileName)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UAnimNodeAimOffset::execSetActiveProfileByIndex(FFrame&, void* const)
	public virtual /*native function */void SetActiveProfileByIndex(int ProfileIndex)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	public AnimNodeAimOffset()
	{
		// Object Offset:0x0029766B
		PassThroughAtOrAboveLOD = 1000;
		ForcedAimDir = AnimNodeAimOffset.EAnimAimDir.ANIMAIM_CENTERCENTER;
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Input",
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
		};
		bFixNumChildren = true;
		bSkipTickWhenZeroWeight = true;
	}
}
}