namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialEditorInstanceTimeVarying : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */EditorParameterValueOverTime
	{
		public Object.Guid ExpressionId;
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00025E09
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		bLoop = false;
	//		bAutoActivate = false;
	//		CycleTime = 1.0f;
	//		bNormalizeTime = false;
	//		OffsetTime = 0.0f;
	//		bOffsetFromEnd = false;
	//	}
	};
	
	public partial struct /*native */EditorVectorParameterValueOverTime// extends EditorParameterValueOverTime
	{
		public Object.Guid ExpressionId;
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
		[Category] public Object.LinearColor ParameterValue;
		[Category] public Object.InterpCurveVector ParameterValueCurve;
			// Object Offset:0x00025E09
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		bLoop = false;
	//		bAutoActivate = false;
	//		CycleTime = 1.0f;
	//		bNormalizeTime = false;
	//		OffsetTime = 0.0f;
	//		bOffsetFromEnd = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00026105
	//		ParameterValue = new LinearColor
	//		{
	//			R=0.0f,
	//			G=0.0f,
	//			B=0.0f,
	//			A=1.0f
	//		};
	//		CycleTime = 0.0f;
	//	}
	};
	
	public partial struct /*native */EditorScalarParameterValueOverTime// extends EditorParameterValueOverTime
	{
		public Object.Guid ExpressionId;
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
		[Category] public float ParameterValue;
		[Category] public Object.InterpCurveFloat ParameterValueCurve;
			// Object Offset:0x00025E09
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		bLoop = false;
	//		bAutoActivate = false;
	//		CycleTime = 1.0f;
	//		bNormalizeTime = false;
	//		OffsetTime = 0.0f;
	//		bOffsetFromEnd = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x000261E5
	//		CycleTime = 0.0f;
	//	}
	};
	
	public partial struct /*native */EditorTextureParameterValueOverTime// extends EditorParameterValueOverTime
	{
		public Object.Guid ExpressionId;
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
		[Category] public Texture ParameterValue;
			// Object Offset:0x00025E09
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		bLoop = false;
	//		bAutoActivate = false;
	//		CycleTime = 1.0f;
	//		bNormalizeTime = false;
	//		OffsetTime = 0.0f;
	//		bOffsetFromEnd = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00026269
	//		CycleTime = 0.0f;
	//	}
	};
	
	public partial struct /*native */EditorFontParameterValueOverTime// extends EditorParameterValueOverTime
	{
		public Object.Guid ExpressionId;
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
		[Category] public Font FontValue;
		[Category] public int FontPage;
			// Object Offset:0x00025E09
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		bLoop = false;
	//		bAutoActivate = false;
	//		CycleTime = 1.0f;
	//		bNormalizeTime = false;
	//		OffsetTime = 0.0f;
	//		bOffsetFromEnd = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00026319
	//		CycleTime = 0.0f;
	//	}
	};
	
	public partial struct /*native */EditorStaticSwitchParameterValueOverTime// extends EditorParameterValueOverTime
	{
		public Object.Guid ExpressionId;
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
		[Category] public bool ParameterValue;
			// Object Offset:0x00025E09
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		bLoop = false;
	//		bAutoActivate = false;
	//		CycleTime = 1.0f;
	//		bNormalizeTime = false;
	//		OffsetTime = 0.0f;
	//		bOffsetFromEnd = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00026399
	//		CycleTime = 0.0f;
	//	}
	};
	
	public partial struct /*native */ComponentMaskParameterOverTime
	{
		[Category] public bool R;
		[Category] public bool G;
		[Category] public bool B;
		[Category] public bool A;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002649D
	//		R = false;
	//		G = false;
	//		B = false;
	//		A = false;
	//	}
	};
	
	public partial struct /*native */EditorStaticComponentMaskParameterValueOverTime// extends EditorParameterValueOverTime
	{
		public Object.Guid ExpressionId;
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
		[Category] public MaterialEditorInstanceTimeVarying.ComponentMaskParameterOverTime ParameterValue;
			// Object Offset:0x00025E09
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		bLoop = false;
	//		bAutoActivate = false;
	//		CycleTime = 1.0f;
	//		bNormalizeTime = false;
	//		OffsetTime = 0.0f;
	//		bOffsetFromEnd = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00026575
	//		CycleTime = 0.0f;
	//	}
	};
	
	[Category] public PhysicalMaterial PhysMaterial;
	[Category] public MaterialInterface Parent;
	[Category] public bool BakerColorOverride;
	[Category] public bool BakerBleedBounceAmountOverride;
	[Category] public bool BakerBleedEmissiveAmountOverride;
	[Category] public bool BakerAlphaOverride;
	[Category] public bool BakerAlphaTextureOverride;
	[Category] public bool bAutoActivateAll;
	[Category] public Object.Color BakerColor;
	[Category] public float BakerBleedBounceAmount;
	[Category] public float BakerBleedEmissiveAmount;
	[Category] public float BakerAlpha;
	[Category] public Texture BakerAlphaTexture;
	[Category] public array<MaterialEditorInstanceTimeVarying.EditorVectorParameterValueOverTime> VectorParameterValues;
	[Category] public array<MaterialEditorInstanceTimeVarying.EditorScalarParameterValueOverTime> ScalarParameterValues;
	[Category] public array<MaterialEditorInstanceTimeVarying.EditorTextureParameterValueOverTime> TextureParameterValues;
	[Category] public array<MaterialEditorInstanceTimeVarying.EditorFontParameterValueOverTime> FontParameterValues;
	[Category] public array<MaterialEditorInstanceTimeVarying.EditorStaticSwitchParameterValueOverTime> StaticSwitchParameterValues;
	[Category] public array<MaterialEditorInstanceTimeVarying.EditorStaticComponentMaskParameterValueOverTime> StaticComponentMaskParameterValues;
	public MaterialInstanceTimeVarying SourceInstance;
	[duplicatetransient, Const, transient] public array<Object.Guid> VisibleExpressions;
	
	public MaterialEditorInstanceTimeVarying()
	{
		// Object Offset:0x00026995
		BakerBleedBounceAmount = 1.0f;
		BakerAlpha = 1.0f;
	}
}
}