namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialInstanceConstant : MaterialInstance/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */FontParameterValue
	{
		public/*()*/ name ParameterName;
		public/*()*/ Font FontValue;
		public/*()*/ int FontPage;
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
		public/*()*/ name ParameterName;
		public/*()*/ float ParameterValue;
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
		public/*()*/ name ParameterName;
		public/*()*/ Texture ParameterValue;
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
		public/*()*/ name ParameterName;
		public/*()*/ Object.LinearColor ParameterValue;
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
	
	public/*()*/ /*const */array<MaterialInstanceConstant.FontParameterValue> FontParameterValues;
	public/*()*/ /*const */array<MaterialInstanceConstant.ScalarParameterValue> ScalarParameterValues;
	public/*()*/ /*const */array<MaterialInstanceConstant.TextureParameterValue> TextureParameterValues;
	public/*()*/ /*const */array<MaterialInstanceConstant.VectorParameterValue> VectorParameterValues;
	
	// Export UMaterialInstanceConstant::execSetParent(FFrame&, void* const)
	public override /*native function */void SetParent(MaterialInterface NewParent)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UMaterialInstanceConstant::execSetScalarParameterValue(FFrame&, void* const)
	public override /*native function */void SetScalarParameterValue(name ParameterName, float Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UMaterialInstanceConstant::execSetTextureParameterValue(FFrame&, void* const)
	public override /*native function */void SetTextureParameterValue(name ParameterName, Texture Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UMaterialInstanceConstant::execSetVectorParameterValue(FFrame&, void* const)
	public override /*native function */void SetVectorParameterValue(name ParameterName, Object.LinearColor Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UMaterialInstanceConstant::execSetFontParameterValue(FFrame&, void* const)
	public override /*native function */void SetFontParameterValue(name ParameterName, Font FontValue, int FontPage)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UMaterialInstanceConstant::execClearParameterValues(FFrame&, void* const)
	public override /*native function */void ClearParameterValues()
	{
		#warning NATIVE FUNCTION !
	}
	
}
}