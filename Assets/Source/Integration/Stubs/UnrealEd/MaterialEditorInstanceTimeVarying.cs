namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialEditorInstanceTimeVarying : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */EditorParameterValueOverTime
	{
		public Object.Guid ExpressionId;
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public/*()*/ bool bLoop;
		public/*()*/ bool bAutoActivate;
		public/*()*/ float CycleTime;
		public/*()*/ bool bNormalizeTime;
		public/*()*/ float OffsetTime;
		public/*()*/ bool bOffsetFromEnd;
	
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public/*()*/ bool bLoop;
		public/*()*/ bool bAutoActivate;
		public/*()*/ float CycleTime;
		public/*()*/ bool bNormalizeTime;
		public/*()*/ float OffsetTime;
		public/*()*/ bool bOffsetFromEnd;
	
		public/*()*/ Object.LinearColor ParameterValue;
		public/*()*/ Object.InterpCurveVector ParameterValueCurve;
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public/*()*/ bool bLoop;
		public/*()*/ bool bAutoActivate;
		public/*()*/ float CycleTime;
		public/*()*/ bool bNormalizeTime;
		public/*()*/ float OffsetTime;
		public/*()*/ bool bOffsetFromEnd;
	
		public/*()*/ float ParameterValue;
		public/*()*/ Object.InterpCurveFloat ParameterValueCurve;
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public/*()*/ bool bLoop;
		public/*()*/ bool bAutoActivate;
		public/*()*/ float CycleTime;
		public/*()*/ bool bNormalizeTime;
		public/*()*/ float OffsetTime;
		public/*()*/ bool bOffsetFromEnd;
	
		public/*()*/ Texture ParameterValue;
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public/*()*/ bool bLoop;
		public/*()*/ bool bAutoActivate;
		public/*()*/ float CycleTime;
		public/*()*/ bool bNormalizeTime;
		public/*()*/ float OffsetTime;
		public/*()*/ bool bOffsetFromEnd;
	
		public/*()*/ Font FontValue;
		public/*()*/ int FontPage;
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public/*()*/ bool bLoop;
		public/*()*/ bool bAutoActivate;
		public/*()*/ float CycleTime;
		public/*()*/ bool bNormalizeTime;
		public/*()*/ float OffsetTime;
		public/*()*/ bool bOffsetFromEnd;
	
		public/*()*/ bool ParameterValue;
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
		public/*()*/ bool R;
		public/*()*/ bool G;
		public/*()*/ bool B;
		public/*()*/ bool A;
	
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public/*()*/ bool bLoop;
		public/*()*/ bool bAutoActivate;
		public/*()*/ float CycleTime;
		public/*()*/ bool bNormalizeTime;
		public/*()*/ float OffsetTime;
		public/*()*/ bool bOffsetFromEnd;
	
		public/*()*/ MaterialEditorInstanceTimeVarying.ComponentMaskParameterOverTime ParameterValue;
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
	
	public/*()*/ PhysicalMaterial PhysMaterial;
	public/*()*/ MaterialInterface Parent;
	public/*()*/ bool BakerColorOverride;
	public/*()*/ bool BakerBleedBounceAmountOverride;
	public/*()*/ bool BakerBleedEmissiveAmountOverride;
	public/*()*/ bool BakerAlphaOverride;
	public/*()*/ bool BakerAlphaTextureOverride;
	public/*()*/ bool bAutoActivateAll;
	public/*()*/ Object.Color BakerColor;
	public/*()*/ float BakerBleedBounceAmount;
	public/*()*/ float BakerBleedEmissiveAmount;
	public/*()*/ float BakerAlpha;
	public/*()*/ Texture BakerAlphaTexture;
	public/*()*/ array<MaterialEditorInstanceTimeVarying.EditorVectorParameterValueOverTime> VectorParameterValues;
	public/*()*/ array<MaterialEditorInstanceTimeVarying.EditorScalarParameterValueOverTime> ScalarParameterValues;
	public/*()*/ array<MaterialEditorInstanceTimeVarying.EditorTextureParameterValueOverTime> TextureParameterValues;
	public/*()*/ array<MaterialEditorInstanceTimeVarying.EditorFontParameterValueOverTime> FontParameterValues;
	public/*()*/ array<MaterialEditorInstanceTimeVarying.EditorStaticSwitchParameterValueOverTime> StaticSwitchParameterValues;
	public/*()*/ array<MaterialEditorInstanceTimeVarying.EditorStaticComponentMaskParameterValueOverTime> StaticComponentMaskParameterValues;
	public MaterialInstanceTimeVarying SourceInstance;
	public /*duplicatetransient const transient */array<Object.Guid> VisibleExpressions;
	
	public MaterialEditorInstanceTimeVarying()
	{
		// Object Offset:0x00026995
		BakerBleedBounceAmount = 1.0f;
		BakerAlpha = 1.0f;
	}
}
}