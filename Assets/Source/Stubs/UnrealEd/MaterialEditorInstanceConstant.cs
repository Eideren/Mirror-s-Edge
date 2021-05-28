namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialEditorInstanceConstant : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */EditorParameterValue
	{
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public Object.Guid ExpressionId;
	
		public/*()*/ Object.LinearColor ParameterValue;
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public Object.Guid ExpressionId;
	
		public/*()*/ float ParameterValue;
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public Object.Guid ExpressionId;
	
		public/*()*/ Texture ParameterValue;
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public Object.Guid ExpressionId;
	
		public/*()*/ Font FontValue;
		public/*()*/ int FontPage;
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public Object.Guid ExpressionId;
	
		public/*()*/ bool ParameterValue;
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
		public/*()*/ bool R;
		public/*()*/ bool G;
		public/*()*/ bool B;
		public/*()*/ bool A;
	
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
		public/*()*/ bool bOverride;
		public/*()*/ name ParameterName;
		public Object.Guid ExpressionId;
	
		public/*()*/ MaterialEditorInstanceConstant.ComponentMaskParameter ParameterValue;
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
	
	public/*()*/ PhysicalMaterial PhysMaterial;
	public/*()*/ bool BakerColorOverride;
	public/*()*/ bool BakerBleedBounceAmountOverride;
	public/*()*/ bool BakerBleedEmissiveAmountOverride;
	public/*()*/ bool BakerAlphaOverride;
	public/*()*/ bool BakerAlphaTextureOverride;
	public/*()*/ Object.Color BakerColor;
	public/*()*/ float BakerBleedBounceAmount;
	public/*()*/ float BakerBleedEmissiveAmount;
	public/*()*/ float BakerAlpha;
	public/*()*/ Texture BakerAlphaTexture;
	public/*()*/ MaterialInterface Parent;
	public/*()*/ array<MaterialEditorInstanceConstant.EditorVectorParameterValue> VectorParameterValues;
	public/*()*/ array<MaterialEditorInstanceConstant.EditorScalarParameterValue> ScalarParameterValues;
	public/*()*/ array<MaterialEditorInstanceConstant.EditorTextureParameterValue> TextureParameterValues;
	public/*()*/ array<MaterialEditorInstanceConstant.EditorFontParameterValue> FontParameterValues;
	public/*()*/ array<MaterialEditorInstanceConstant.EditorStaticSwitchParameterValue> StaticSwitchParameterValues;
	public/*()*/ array<MaterialEditorInstanceConstant.EditorStaticComponentMaskParameterValue> StaticComponentMaskParameterValues;
	public MaterialInstanceConstant SourceInstance;
	public /*duplicatetransient const transient */array<Object.Guid> VisibleExpressions;
	
}
}