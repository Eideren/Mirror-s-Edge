namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LensFlare : Object/*
		native
		hidecategories(Object)*/{
	public partial struct /*native transient */LensFlareElementCurvePair
	{
		[init] public String CurveName;
		[init] public Object CurveObject;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0034D2E0
	//		CurveName = "";
	//		CurveObject = default;
	//	}
	};
	
	public partial struct /*native */LensFlareElement
	{
		[Category] public name ElementName;
		[Category] public float RayDistance;
		[Category] public bool bIsEnabled;
		[Category] public bool bUseSourceDistance;
		[Category] public bool bNormalizeRadialDistance;
		[Category] public bool bModulateColorBySource;
		[Category] public Object.Vector Size;
		[Category("Material")] public array<MaterialInterface> LFMaterials;
		[Category("Material")] public DistributionFloat.RawDistributionFloat LFMaterialIndex;
		[Category("Scaling")] public DistributionFloat.RawDistributionFloat Scaling;
		[Category("Scaling")] public DistributionVector.RawDistributionVector AxisScaling;
		[Category("Rotation")] public DistributionFloat.RawDistributionFloat Rotation;
		[Category("Color")] public DistributionVector.RawDistributionVector Color;
		[Category("Color")] public DistributionFloat.RawDistributionFloat Alpha;
		[Category("Offset")] public DistributionVector.RawDistributionVector Offset;
		[Category("Scaling")] public DistributionVector.RawDistributionVector DistMap_Scale;
		[Category("Scaling")] public DistributionVector.RawDistributionVector DistMap_Color;
		[Category("Scaling")] public DistributionFloat.RawDistributionFloat DistMap_Alpha;
	
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
	
	[Category("Source")] [export, editinline] public LensFlare.LensFlareElement SourceElement;
	[Category("Source")] public StaticMesh SourceMesh;
	[Category("Source")] [Const] public Scene.ESceneDepthPriorityGroup SourceDPG;
	[Category("Reflections")] [Const] public Scene.ESceneDepthPriorityGroup ReflectionsDPG;
	[Category("Reflections")] [export, editinline] public array</*export editinline */LensFlare.LensFlareElement> Reflections;
	[Category("Visibility")] public float OuterCone;
	[Category("Visibility")] public float InnerCone;
	[Category("Visibility")] public float ConeFudgeFactor;
	[Category("Visibility")] public float Radius;
	[Category("Occlusion")] public DistributionFloat.RawDistributionFloat ScreenPercentageMap;
	[Category("Bounds")] public bool bUseFixedRelativeBoundingBox;
	[Category("Debug")] public bool bRenderDebugLines;
	public bool ThumbnailImageOutOfDate;
	[Category("Bounds")] public Object.Box FixedRelativeBoundingBox;
	[export] public InterpCurveEdSetup CurveEdSetup;
	[transient] public int ReflectionCount;
	public Object.Rotator ThumbnailAngle;
	public float ThumbnailDistance;
	public Texture2D ThumbnailImage;
	
	public LensFlare()
	{
		var Default__LensFlare_DistributionLFMaterialIndex = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__LensFlare.DistributionLFMaterialIndex' */;
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
		var Default__LensFlare_DistributionRotation = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__LensFlare.DistributionRotation' */;
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
		var Default__LensFlare_DistributionOffset = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__LensFlare.DistributionOffset' */;
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
				Distribution = Default__LensFlare_DistributionLFMaterialIndex/*Ref DistributionFloatConstant'Default__LensFlare.DistributionLFMaterialIndex'*/,
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
				Distribution = Default__LensFlare_DistributionScaling/*Ref DistributionFloatConstant'Default__LensFlare.DistributionScaling'*/,
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
				Distribution = Default__LensFlare_DistributionAxisScaling/*Ref DistributionVectorConstant'Default__LensFlare.DistributionAxisScaling'*/,
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
				Distribution = Default__LensFlare_DistributionRotation/*Ref DistributionFloatConstant'Default__LensFlare.DistributionRotation'*/,
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
				Distribution = Default__LensFlare_DistributionColor/*Ref DistributionVectorConstant'Default__LensFlare.DistributionColor'*/,
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