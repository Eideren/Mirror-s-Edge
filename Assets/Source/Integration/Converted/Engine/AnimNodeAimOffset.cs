// NO OVERWRITE

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
		[Category] public Object.Quat Quaternion;
		[Category] public Object.Vector Translation;
	
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
		[Category] public name BoneName;
		[Category] public AnimNodeAimOffset.AimTransform LU;
		[Category] public AnimNodeAimOffset.AimTransform LC;
		[Category] public AnimNodeAimOffset.AimTransform LD;
		[Category] public AnimNodeAimOffset.AimTransform CU;
		[Category] public AnimNodeAimOffset.AimTransform CC;
		[Category] public AnimNodeAimOffset.AimTransform CD;
		[Category] public AnimNodeAimOffset.AimTransform RU;
		[Category] public AnimNodeAimOffset.AimTransform RC;
		[Category] public AnimNodeAimOffset.AimTransform RD;
	
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
		[Category] [Const, editconst] public name ProfileName;
		[Category] public Object.Vector2D HorizontalRange;
		[Category] public Object.Vector2D VerticalRange;
		public array<AnimNodeAimOffset.AimComponent> AimComponents;
		[Category] public name AnimName_LU;
		[Category] public name AnimName_LC;
		[Category] public name AnimName_LD;
		[Category] public name AnimName_CU;
		[Category] public name AnimName_CC;
		[Category] public name AnimName_CD;
		[Category] public name AnimName_RU;
		[Category] public name AnimName_RC;
		[Category] public name AnimName_RD;
	
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
	
	[Category] public Object.Vector2D Aim;
	[Category] public Object.Vector2D AngleOffset;
	[Category] public bool bForceAimDir;
	[Category] public bool bBakeFromAnimations;
	[Category] public int PassThroughAtOrAboveLOD;
	[Category] public AnimNodeAimOffset.EAnimAimDir ForcedAimDir;
	[transient] public array<byte> RequiredBones;
	[transient] public array<int> BoneToAimCpnt;
	[transient] public AnimNodeAimOffset TemplateNode;
	[Category] [editconst] public array</*editconst */AnimNodeAimOffset.AimOffsetProfile> Profiles;
	[Category] [Const, editconst] public int CurrentProfileIndex;
	
	//// Export UAnimNodeAimOffset::execSetActiveProfileByName(FFrame&, void* const)
	//public virtual /*native function */void SetActiveProfileByName(name ProfileName)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UAnimNodeAimOffset::execSetActiveProfileByIndex(FFrame&, void* const)
	//public virtual /*native function */void SetActiveProfileByIndex(int ProfileIndex)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
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
		bSkipTickWhenZeroWeight = true;
	}
}
}