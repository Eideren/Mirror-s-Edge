namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialInstanceConstant : MaterialInstance/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */FontParameterValue
	{
		[Category] public name ParameterName;
		[Category] public Font FontValue;
		[Category] public int FontPage;
		public Object.Guid ExpressionGUID;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0035A7D1
	//		ParameterName = (name)"None";
	//		FontValue = default;
	//		FontPage = 0;
	//		ExpressionGUID = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//	}
	};
	
	public partial struct /*native */ScalarParameterValue
	{
		[Category] public name ParameterName;
		[Category] public float ParameterValue;
		public Object.Guid ExpressionGUID;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0035A919
	//		ParameterName = (name)"None";
	//		ParameterValue = 0.0f;
	//		ExpressionGUID = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//	}
	};
	
	public partial struct /*native */TextureParameterValue
	{
		[Category] public name ParameterName;
		[Category] public Texture ParameterValue;
		public Object.Guid ExpressionGUID;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0035AA49
	//		ParameterName = (name)"None";
	//		ParameterValue = default;
	//		ExpressionGUID = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//	}
	};
	
	public partial struct /*native */VectorParameterValue
	{
		[Category] public name ParameterName;
		[Category] public Object.LinearColor ParameterValue;
		public Object.Guid ExpressionGUID;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0035AB79
	//		ParameterName = (name)"None";
	//		ParameterValue = new LinearColor
	//		{
	//			R=0.0f,
	//			G=0.0f,
	//			B=0.0f,
	//			A=1.0f
	//		};
	//		ExpressionGUID = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//	}
	};
	
	[Category] [Const] public array<MaterialInstanceConstant.FontParameterValue> FontParameterValues;
	[Category] [Const] public array<MaterialInstanceConstant.ScalarParameterValue> ScalarParameterValues;
	[Category] [Const] public array<MaterialInstanceConstant.TextureParameterValue> TextureParameterValues;
	[Category] [Const] public array<MaterialInstanceConstant.VectorParameterValue> VectorParameterValues;
	
	// Export UMaterialInstanceConstant::execSetParent(FFrame&, void* const)
	public override /*native function */void SetParent(MaterialInterface NewParent)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceConstant::execSetScalarParameterValue(FFrame&, void* const)
	public override /*native function */void SetScalarParameterValue(name ParameterName, float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceConstant::execSetTextureParameterValue(FFrame&, void* const)
	public override /*native function */void SetTextureParameterValue(name ParameterName, Texture Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceConstant::execSetVectorParameterValue(FFrame&, void* const)
	public override /*native function */void SetVectorParameterValue(name ParameterName, Object.LinearColor Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceConstant::execSetFontParameterValue(FFrame&, void* const)
	public override /*native function */void SetFontParameterValue(name ParameterName, Font FontValue, int FontPage)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceConstant::execClearParameterValues(FFrame&, void* const)
	public override /*native function */void ClearParameterValues()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}