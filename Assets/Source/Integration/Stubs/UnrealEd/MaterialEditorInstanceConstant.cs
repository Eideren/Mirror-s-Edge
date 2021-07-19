namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialEditorInstanceConstant : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */EditorParameterValue
	{
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		public Object.Guid ExpressionId;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00025252
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//	}
	};
	
	public partial struct /*native */EditorVectorParameterValue// extends EditorParameterValue
	{
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		public Object.Guid ExpressionId;
	
		[Category] public Object.LinearColor ParameterValue;
			// Object Offset:0x00025252
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00025476
	//		ParameterValue = new LinearColor
	//		{
	//			R=0.0f,
	//			G=0.0f,
	//			B=0.0f,
	//			A=1.0f
	//		};
	//	}
	};
	
	public partial struct /*native */EditorScalarParameterValue// extends EditorParameterValue
	{
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		public Object.Guid ExpressionId;
	
		[Category] public float ParameterValue;
			// Object Offset:0x00025252
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native */EditorTextureParameterValue// extends EditorParameterValue
	{
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		public Object.Guid ExpressionId;
	
		[Category] public Texture ParameterValue;
			// Object Offset:0x00025252
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native */EditorFontParameterValue// extends EditorParameterValue
	{
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		public Object.Guid ExpressionId;
	
		[Category] public Font FontValue;
		[Category] public int FontPage;
			// Object Offset:0x00025252
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native */EditorStaticSwitchParameterValue// extends EditorParameterValue
	{
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		public Object.Guid ExpressionId;
	
		[Category] public bool ParameterValue;
			// Object Offset:0x00025252
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native */ComponentMaskParameter
	{
		[Category] public bool R;
		[Category] public bool G;
		[Category] public bool B;
		[Category] public bool A;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00025752
	//		R = false;
	//		G = false;
	//		B = false;
	//		A = false;
	//	}
	};
	
	public partial struct /*native */EditorStaticComponentMaskParameterValue// extends EditorParameterValue
	{
		[Category] public bool bOverride;
		[Category] public name ParameterName;
		public Object.Guid ExpressionId;
	
		[Category] public MaterialEditorInstanceConstant.ComponentMaskParameter ParameterValue;
			// Object Offset:0x00025252
	//		bOverride = false;
	//		ParameterName = (name)"None";
	//		ExpressionId = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	[Category] public PhysicalMaterial PhysMaterial;
	[Category] public bool BakerColorOverride;
	[Category] public bool BakerBleedBounceAmountOverride;
	[Category] public bool BakerBleedEmissiveAmountOverride;
	[Category] public bool BakerAlphaOverride;
	[Category] public bool BakerAlphaTextureOverride;
	[Category] public Object.Color BakerColor;
	[Category] public float BakerBleedBounceAmount;
	[Category] public float BakerBleedEmissiveAmount;
	[Category] public float BakerAlpha;
	[Category] public Texture BakerAlphaTexture;
	[Category] public MaterialInterface Parent;
	[Category] public array<MaterialEditorInstanceConstant.EditorVectorParameterValue> VectorParameterValues;
	[Category] public array<MaterialEditorInstanceConstant.EditorScalarParameterValue> ScalarParameterValues;
	[Category] public array<MaterialEditorInstanceConstant.EditorTextureParameterValue> TextureParameterValues;
	[Category] public array<MaterialEditorInstanceConstant.EditorFontParameterValue> FontParameterValues;
	[Category] public array<MaterialEditorInstanceConstant.EditorStaticSwitchParameterValue> StaticSwitchParameterValues;
	[Category] public array<MaterialEditorInstanceConstant.EditorStaticComponentMaskParameterValue> StaticComponentMaskParameterValues;
	public MaterialInstanceConstant SourceInstance;
	[duplicatetransient, Const, transient] public array<Object.Guid> VisibleExpressions;
	
}
}