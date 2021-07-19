namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialInstanceTimeVarying : MaterialInstance/*
		native*/{
	public partial struct /*native */ParameterValueOverTime
	{
		public Object.Guid ExpressionGUID;
		[transient] public float StartTime;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0035B2A8
	//		ExpressionGUID = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		StartTime = -1.0f;
	//		ParameterName = (name)"None";
	//		bLoop = false;
	//		bAutoActivate = false;
	//		CycleTime = 1.0f;
	//		bNormalizeTime = false;
	//		OffsetTime = 0.0f;
	//		bOffsetFromEnd = false;
	//	}
	};
	
	public partial struct /*native */FontParameterValueOverTime// extends ParameterValueOverTime
	{
		public Object.Guid ExpressionGUID;
		[transient] public float StartTime;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
		[Category] public Font FontValue;
		[Category] public int FontPage;
			// Object Offset:0x0035B2A8
	//		ExpressionGUID = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		StartTime = -1.0f;
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
	//		// Object Offset:0x0035B510
	//		StartTime = 0.0f;
	//		CycleTime = 0.0f;
	//	}
	};
	
	public partial struct /*native */ScalarParameterValueOverTime// extends ParameterValueOverTime
	{
		public Object.Guid ExpressionGUID;
		[transient] public float StartTime;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
		[Category] public float ParameterValue;
		[Category] public Object.InterpCurveFloat ParameterValueCurve;
			// Object Offset:0x0035B2A8
	//		ExpressionGUID = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		StartTime = -1.0f;
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
	//		// Object Offset:0x0035B5DC
	//		StartTime = 0.0f;
	//		CycleTime = 0.0f;
	//	}
	};
	
	public partial struct /*native */TextureParameterValueOverTime// extends ParameterValueOverTime
	{
		public Object.Guid ExpressionGUID;
		[transient] public float StartTime;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
		[Category] public Texture ParameterValue;
			// Object Offset:0x0035B2A8
	//		ExpressionGUID = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		StartTime = -1.0f;
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
	//		// Object Offset:0x0035B67C
	//		StartTime = 0.0f;
	//		CycleTime = 0.0f;
	//	}
	};
	
	public partial struct /*native */VectorParameterValueOverTime// extends ParameterValueOverTime
	{
		public Object.Guid ExpressionGUID;
		[transient] public float StartTime;
		[Category] public name ParameterName;
		[Category] public bool bLoop;
		[Category] public bool bAutoActivate;
		[Category] public float CycleTime;
		[Category] public bool bNormalizeTime;
		[Category] public float OffsetTime;
		[Category] public bool bOffsetFromEnd;
	
		[Category] public Object.LinearColor ParameterValue;
		[Category] public Object.InterpCurveVector ParameterValueCurve;
			// Object Offset:0x0035B2A8
	//		ExpressionGUID = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		StartTime = -1.0f;
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
	//		// Object Offset:0x0035B74C
	//		ParameterValue = new LinearColor
	//		{
	//			R=0.0f,
	//			G=0.0f,
	//			B=0.0f,
	//			A=1.0f
	//		};
	//		StartTime = 0.0f;
	//		CycleTime = 0.0f;
	//	}
	};
	
	[Category] public bool bAutoActivateAll;
	[transient] public float Duration;
	[Category] [Const] public array<MaterialInstanceTimeVarying.FontParameterValueOverTime> FontParameterValues;
	[Category] [Const] public array<MaterialInstanceTimeVarying.ScalarParameterValueOverTime> ScalarParameterValues;
	[Category] [Const] public array<MaterialInstanceTimeVarying.TextureParameterValueOverTime> TextureParameterValues;
	[Category] [Const] public array<MaterialInstanceTimeVarying.VectorParameterValueOverTime> VectorParameterValues;
	
	// Export UMaterialInstanceTimeVarying::execSetParent(FFrame&, void* const)
	public override /*native function */void SetParent(MaterialInterface NewParent)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceTimeVarying::execSetScalarParameterValue(FFrame&, void* const)
	public override /*native function */void SetScalarParameterValue(name ParameterName, float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceTimeVarying::execSetScalarCurveParameterValue(FFrame&, void* const)
	public override /*native function */void SetScalarCurveParameterValue(name ParameterName, Object.InterpCurveFloat Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceTimeVarying::execSetScalarStartTime(FFrame&, void* const)
	public virtual /*native function */void SetScalarStartTime(name ParameterName, float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceTimeVarying::execSetDuration(FFrame&, void* const)
	public virtual /*native function */void SetDuration(float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceTimeVarying::execSetTextureParameterValue(FFrame&, void* const)
	public override /*native function */void SetTextureParameterValue(name ParameterName, Texture Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceTimeVarying::execSetVectorParameterValue(FFrame&, void* const)
	public override /*native function */void SetVectorParameterValue(name ParameterName, Object.LinearColor Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceTimeVarying::execSetVectorCurveParameterValue(FFrame&, void* const)
	public virtual /*native function */void SetVectorCurveParameterValue(name ParameterName, Object.InterpCurveVector Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceTimeVarying::execSetVectorStartTime(FFrame&, void* const)
	public virtual /*native function */void SetVectorStartTime(name ParameterName, float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceTimeVarying::execSetFontParameterValue(FFrame&, void* const)
	public override /*native function */void SetFontParameterValue(name ParameterName, Font FontValue, int FontPage)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstanceTimeVarying::execClearParameterValues(FFrame&, void* const)
	public override /*native function */void ClearParameterValues()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}