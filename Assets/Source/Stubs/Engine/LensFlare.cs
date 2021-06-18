namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LensFlare : Object/*
		native
		hidecategories(Object)*/{
	public partial struct /*native transient */LensFlareElementCurvePair
	{
		public /*init */String CurveName;
		public /*init */Object CurveObject;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0034D2E0
	//		CurveName = "";
	//		CurveObject = default;
	//	}
	};
	
	public partial struct /*native */LensFlareElement
	{
		public/*()*/ name ElementName;
		public/*()*/ float RayDistance;
		public/*()*/ bool bIsEnabled;
		public/*()*/ bool bUseSourceDistance;
		public/*()*/ bool bNormalizeRadialDistance;
		public/*()*/ bool bModulateColorBySource;
		public/*()*/ Object.Vector Size;
		public/*(Material)*/ array<MaterialInterface> LFMaterials;
		public/*(Material)*/ DistributionFloat.RawDistributionFloat LFMaterialIndex;
		public/*(Scaling)*/ DistributionFloat.RawDistributionFloat Scaling;
		public/*(Scaling)*/ DistributionVector.RawDistributionVector AxisScaling;
		public/*(Rotation)*/ DistributionFloat.RawDistributionFloat Rotation;
		public/*(Color)*/ DistributionVector.RawDistributionVector Color;
		public/*(Color)*/ DistributionFloat.RawDistributionFloat Alpha;
		public/*(Offset)*/ DistributionVector.RawDistributionVector Offset;
		public/*(Scaling)*/ DistributionVector.RawDistributionVector DistMap_Scale;
		public/*(Scaling)*/ DistributionVector.RawDistributionVector DistMap_Color;
		public/*(Scaling)*/ DistributionFloat.RawDistributionFloat DistMap_Alpha;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0034D6C8
	//		ElementName = (name)"None";
	//		RayDistance = 0.0f;
	//		bIsEnabled = false;
	//		bUseSourceDistance = false;
	//		bNormalizeRadialDistance = false;
	//		bModulateColorBySource = false;
	//		Size = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		LFMaterials = default;
	//		LFMaterialIndex = new DistributionFloat.RawDistributionFloat
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		Scaling = new DistributionFloat.RawDistributionFloat
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		AxisScaling = new DistributionVector.RawDistributionVector
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		Rotation = new DistributionFloat.RawDistributionFloat
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		Color = new DistributionVector.RawDistributionVector
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		Alpha = new DistributionFloat.RawDistributionFloat
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		Offset = new DistributionVector.RawDistributionVector
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		DistMap_Scale = new DistributionVector.RawDistributionVector
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		DistMap_Color = new DistributionVector.RawDistributionVector
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		DistMap_Alpha = new DistributionFloat.RawDistributionFloat
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//	}
	};
	
	public/*(Source)*/ /*export editinline */LensFlare.LensFlareElement SourceElement;
	public/*(Source)*/ StaticMesh SourceMesh;
	public/*(Source)*/ /*const */Scene.ESceneDepthPriorityGroup SourceDPG;
	public/*(Reflections)*/ /*const */Scene.ESceneDepthPriorityGroup ReflectionsDPG;
	public/*(Reflections)*/ /*export editinline */array</*export editinline */LensFlare.LensFlareElement> Reflections;
	public/*(Visibility)*/ float OuterCone;
	public/*(Visibility)*/ float InnerCone;
	public/*(Visibility)*/ float ConeFudgeFactor;
	public/*(Visibility)*/ float Radius;
	public/*(Occlusion)*/ DistributionFloat.RawDistributionFloat ScreenPercentageMap;
	public/*(Bounds)*/ bool bUseFixedRelativeBoundingBox;
	public/*(Debug)*/ bool bRenderDebugLines;
	public bool ThumbnailImageOutOfDate;
	public/*(Bounds)*/ Object.Box FixedRelativeBoundingBox;
	public /*export */InterpCurveEdSetup CurveEdSetup;
	public /*transient */int ReflectionCount;
	public Object.Rotator ThumbnailAngle;
	public float ThumbnailDistance;
	public Texture2D ThumbnailImage;
	
	public LensFlare()
	{
		var Default__LensFlare_DistributionScaling = new DistributionFloatConstant
		{
			// Object Offset:0x00466A1B
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__LensFlare.DistributionScaling' */;
		var Default__LensFlare_DistributionAxisScaling = new DistributionVectorConstant
		{
			// Object Offset:0x00467C43
			Constant = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=0.0f
			},
		}/* Reference: DistributionVectorConstant'Default__LensFlare.DistributionAxisScaling' */;
		var Default__LensFlare_DistributionColor = new DistributionVectorConstant
		{
			// Object Offset:0x00467C87
			Constant = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorConstant'Default__LensFlare.DistributionColor' */;
		var Default__LensFlare_DistributionAlpha = new DistributionFloatConstant
		{
			// Object Offset:0x00466983
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__LensFlare.DistributionAlpha' */;
		var Default__LensFlare_DistributionDistMap_Scale = new DistributionVectorConstant
		{
			// Object Offset:0x00467D0F
			Constant = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorConstant'Default__LensFlare.DistributionDistMap_Scale' */;
		var Default__LensFlare_DistributionDistMap_Color = new DistributionVectorConstant
		{
			// Object Offset:0x00467CCB
			Constant = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorConstant'Default__LensFlare.DistributionDistMap_Color' */;
		var Default__LensFlare_DistributionDistMap_Alpha = new DistributionFloatConstant
		{
			// Object Offset:0x004669B7
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__LensFlare.DistributionDistMap_Alpha' */;
		var Default__LensFlare_DistributionScreenPercentageMap = new DistributionFloatConstant
		{
			// Object Offset:0x00466A4F
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__LensFlare.DistributionScreenPercentageMap' */;
		// Object Offset:0x0034E538
		SourceElement = new LensFlare.LensFlareElement
		{
			ElementName = (name)"Source",
			RayDistance = 0.0f,
			bIsEnabled = true,
			bUseSourceDistance = false,
			bNormalizeRadialDistance = false,
			bModulateColorBySource = false,
			Size = new Vector
			{
				X=0.50f,
				Y=0.50f,
				Z=0.0f
			},
			LFMaterials = default,
			LFMaterialIndex = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatConstant>("Default__LensFlare.DistributionLFMaterialIndex")/*Ref DistributionFloatConstant'Default__LensFlare.DistributionLFMaterialIndex'*/,
				Type = 0,
				Op = 1,
				LookupTableNumElements = 1,
				LookupTableChunkSize = 1,
				LookupTable = new array<float>
				{
					0.0f,
					0.0f,
					0.0f,
					0.0f,
				},
				LookupTableTimeScale = 0.0f,
				LookupTableStartTime = 0.0f,
			},
			Scaling = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatConstant>("Default__LensFlare.DistributionScaling")/*Ref DistributionFloatConstant'Default__LensFlare.DistributionScaling'*/,
				Type = 0,
				Op = 1,
				LookupTableNumElements = 1,
				LookupTableChunkSize = 1,
				LookupTable = new array<float>
				{
					1.0f,
					1.0f,
					1.0f,
					1.0f,
				},
				LookupTableTimeScale = 0.0f,
				LookupTableStartTime = 0.0f,
			},
			AxisScaling = new DistributionVector.RawDistributionVector
			{
				Distribution = LoadAsset<DistributionVectorConstant>("Default__LensFlare.DistributionAxisScaling")/*Ref DistributionVectorConstant'Default__LensFlare.DistributionAxisScaling'*/,
				Type = 0,
				Op = 1,
				LookupTableNumElements = 1,
				LookupTableChunkSize = 3,
				LookupTable = new array<float>
				{
					0.0f,
					1.0f,
					1.0f,
					1.0f,
					0.0f,
					1.0f,
					1.0f,
					0.0f,
				},
				LookupTableTimeScale = 0.0f,
				LookupTableStartTime = 0.0f,
			},
			Rotation = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatConstant>("Default__LensFlare.DistributionRotation")/*Ref DistributionFloatConstant'Default__LensFlare.DistributionRotation'*/,
				Type = 0,
				Op = 1,
				LookupTableNumElements = 1,
				LookupTableChunkSize = 1,
				LookupTable = new array<float>
				{
					0.0f,
					0.0f,
					0.0f,
					0.0f,
				},
				LookupTableTimeScale = 0.0f,
				LookupTableStartTime = 0.0f,
			},
			Color = new DistributionVector.RawDistributionVector
			{
				Distribution = LoadAsset<DistributionVectorConstant>("Default__LensFlare.DistributionColor")/*Ref DistributionVectorConstant'Default__LensFlare.DistributionColor'*/,
				Type = 0,
				Op = 1,
				LookupTableNumElements = 1,
				LookupTableChunkSize = 3,
				LookupTable = new array<float>
				{
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
				},
				LookupTableTimeScale = 0.0f,
				LookupTableStartTime = 0.0f,
			},
			Alpha = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatConstant>("Default__LensFlare.DistributionAlpha")/*Ref DistributionFloatConstant'Default__LensFlare.DistributionAlpha'*/,
				Type = 0,
				Op = 1,
				LookupTableNumElements = 1,
				LookupTableChunkSize = 1,
				LookupTable = new array<float>
				{
					1.0f,
					1.0f,
					1.0f,
					1.0f,
				},
				LookupTableTimeScale = 0.0f,
				LookupTableStartTime = 0.0f,
			},
			Offset = new DistributionVector.RawDistributionVector
			{
				Distribution = LoadAsset<DistributionVectorConstant>("Default__LensFlare.DistributionOffset")/*Ref DistributionVectorConstant'Default__LensFlare.DistributionOffset'*/,
				Type = 0,
				Op = 1,
				LookupTableNumElements = 1,
				LookupTableChunkSize = 3,
				LookupTable = new array<float>
				{
					0.0f,
					0.0f,
					0.0f,
					0.0f,
					0.0f,
					0.0f,
					0.0f,
					0.0f,
				},
				LookupTableTimeScale = 0.0f,
				LookupTableStartTime = 0.0f,
			},
			DistMap_Scale = new DistributionVector.RawDistributionVector
			{
				Distribution = LoadAsset<DistributionVectorConstant>("Default__LensFlare.DistributionDistMap_Scale")/*Ref DistributionVectorConstant'Default__LensFlare.DistributionDistMap_Scale'*/,
				Type = 0,
				Op = 1,
				LookupTableNumElements = 1,
				LookupTableChunkSize = 3,
				LookupTable = new array<float>
				{
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
				},
				LookupTableTimeScale = 0.0f,
				LookupTableStartTime = 0.0f,
			},
			DistMap_Color = new DistributionVector.RawDistributionVector
			{
				Distribution = LoadAsset<DistributionVectorConstant>("Default__LensFlare.DistributionDistMap_Color")/*Ref DistributionVectorConstant'Default__LensFlare.DistributionDistMap_Color'*/,
				Type = 0,
				Op = 1,
				LookupTableNumElements = 1,
				LookupTableChunkSize = 3,
				LookupTable = new array<float>
				{
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
					1.0f,
				},
				LookupTableTimeScale = 0.0f,
				LookupTableStartTime = 0.0f,
			},
			DistMap_Alpha = new DistributionFloat.RawDistributionFloat
			{
				Distribution = LoadAsset<DistributionFloatConstant>("Default__LensFlare.DistributionDistMap_Alpha")/*Ref DistributionFloatConstant'Default__LensFlare.DistributionDistMap_Alpha'*/,
				Type = 0,
				Op = 1,
				LookupTableNumElements = 1,
				LookupTableChunkSize = 1,
				LookupTable = new array<float>
				{
					1.0f,
					1.0f,
					1.0f,
					1.0f,
				},
				LookupTableTimeScale = 0.0f,
				LookupTableStartTime = 0.0f,
			},
		};
		SourceDPG = Scene.ESceneDepthPriorityGroup.SDPG_World;
		ReflectionsDPG = Scene.ESceneDepthPriorityGroup.SDPG_Foreground;
		ConeFudgeFactor = 0.50f;
		ScreenPercentageMap = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__LensFlare.DistributionScreenPercentageMap")/*Ref DistributionFloatConstant'Default__LensFlare.DistributionScreenPercentageMap'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				1.0f,
				1.0f,
				1.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
	}
}
}