// NO OVERWRITE

namespace MEdge.Core{
using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Object/*
		abstract
		native
		noexport*/{
	public const int MaxInt = 0x7fffffff;
	public const double Pi = 3.1415926535897932;
	public const double RadToDeg = 57.295779513082321600;
	public const double DegToRad = 0.017453292519943296;
	public const double UnrRotToRad = 0.00009587379924285;
	public const double RadToUnrRot = 10430.3783504704527;
	public const int INDEX_NONE = -1;
	
	public enum EAxis 
	{
		AXIS_NONE,
		AXIS_X,
		AXIS_Y,
		AXIS_BLANK,
		AXIS_Z,
		AXIS_MAX
	};
	
	public enum EInputEvent 
	{
		IE_Pressed,
		IE_Released,
		IE_Repeat,
		IE_DoubleClick,
		IE_Axis,
		IE_MAX
	};
	
	public enum EInterpCurveMode 
	{
		CIM_Linear,
		CIM_CurveAuto,
		CIM_Constant,
		CIM_CurveUser,
		CIM_CurveBreak,
		CIM_MAX
	};
	
	public enum EInterpMethodType 
	{
		IMT_UseFixedTangentEval,
		IMT_UseBrokenTangentEval,
		IMT_MAX
	};
	
	public enum ETickingGroup 
	{
		TG_PreAsyncWork,
		TG_DuringAsyncWork,
		TG_PostAsyncWork,
		TG_PostUpdateWork,
		TG_MAX
	};
	
	public partial struct Pointer
	{
		public /*native const */int Dummy;
	};
	
	public partial struct QWord
	{
		public /*native const */int A;
		public /*native const */int B;
	};
	
	public partial struct Double
	{
		public /*native const */int A;
		public /*native const */int B;
	};
	
	public partial struct ThreadSafeCounter
	{
		public /*native const */int Value;
	};
	
	public partial struct BitArray_Mirror
	{
		public /*native const */Object.Pointer Data;
		public /*native const */int NumBits;
		public /*native const */int MaxBits;
		public /*native const */StaticArray<int, int, int, int>/*[4]*/ ReservedData;
	};
	
	public partial struct SparseArray_Mirror
	{
		public /*native const */array<int> Elements;
		public /*native const */array<int> FreeElements;
		public /*native const */Object.BitArray_Mirror AllocationFlags;
	};
	
	public partial struct Set_Mirror
	{
		public /*native const */Object.SparseArray_Mirror Elements;
		public /*native const */Object.Pointer Hash;
		public /*native const */int HashSize;
	};
	
	public partial struct Map_Mirror
	{
		public /*native const */Object.Set_Mirror Pairs;
	};
	
	public partial struct MultiMap_Mirror
	{
		public /*native const */Object.Set_Mirror Pairs;
	};
	
	public partial struct LookupMap_Mirror// extends MultiMap_Mirror
	{
		public /*native const */Object.Set_Mirror Pairs;
	
		public /*native const */array<int> UniqueElements;
	};
	
	public partial struct UntypedBulkData_Mirror
	{
		public /*native const */Object.Pointer VfTable;
		public /*native const */int BulkDataFlags;
		public /*native const */int ElementCount;
		public /*native const */int BulkDataOffsetInFile;
		public /*native const */int BulkDataSizeOnDisk;
		public /*native const */int SavedBulkDataFlags;
		public /*native const */int SavedElementCount;
		public /*native const */int SavedBulkDataOffsetInFile;
		public /*native const */int SavedBulkDataSizeOnDisk;
		public /*native const */Object.Pointer BulkData;
		public /*native const */int LockStatus;
		public /*native const */Object.Pointer AttachedAr;
	};
	
	public partial struct TextureMipBulkData_Mirror// extends UntypedBulkData_Mirror
	{
		public /*native const */Object.Pointer VfTable;
		public /*native const */int BulkDataFlags;
		public /*native const */int ElementCount;
		public /*native const */int BulkDataOffsetInFile;
		public /*native const */int BulkDataSizeOnDisk;
		public /*native const */int SavedBulkDataFlags;
		public /*native const */int SavedElementCount;
		public /*native const */int SavedBulkDataOffsetInFile;
		public /*native const */int SavedBulkDataSizeOnDisk;
		public /*native const */Object.Pointer BulkData;
		public /*native const */int LockStatus;
		public /*native const */Object.Pointer AttachedAr;
	
		public /*native const */int bShouldFreeOnEmtpy;
	};
	
	public partial struct RenderCommandFence_Mirror
	{
		public /*native const transient */int NumPendingFences;
	};
	
	public partial struct IndirectArray_Mirror
	{
		public /*native const */Object.Pointer Data;
		public /*native const */int ArrayNum;
		public /*native const */int ArrayMax;
	};
	
	public partial struct /*atomic immutable */Guid
	{
		public int A;
		public int B;
		public int C;
		public int D;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001D60F
	//		A = 0;
	//		B = 0;
	//		C = 0;
	//		D = 0;
	//	}
	};
	
	public partial struct /*atomic immutable */Vector
	{
		public/*()*/ float X;
		public/*()*/ float Y;
		public/*()*/ float Z;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001D73B
	//		X = 0.0f;
	//		Y = 0.0f;
	//		Z = 0.0f;
	//	}
	};
	
	public partial struct /*atomic immutable */Vector4
	{
		public/*()*/ float X;
		public/*()*/ float Y;
		public/*()*/ float Z;
		public/*()*/ float W;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001D877
	//		X = 0.0f;
	//		Y = 0.0f;
	//		Z = 0.0f;
	//		W = 0.0f;
	//	}
	};
	
	public partial struct /*atomic immutable */Vector2D
	{
		public/*()*/ float X;
		public/*()*/ float Y;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001D977
	//		X = 0.0f;
	//		Y = 0.0f;
	//	}
	};
	
	public partial struct /*atomic immutable */TwoVectors
	{
		public/*()*/ Object.Vector v1;
		public/*()*/ Object.Vector v2;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001DA47
	//		v1 = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		v2 = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public partial struct /*atomic immutable */Plane// extends Vector
	{
		public/*()*/ float X;
		public/*()*/ float Y;
		public/*()*/ float Z;
	
		public/*()*/ float W;
			// Object Offset:0x0001D73B
	//		X = 0.0f;
	//		Y = 0.0f;
	//		Z = 0.0f;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*atomic immutable */Rotator
	{
		public/*()*/ int Pitch;
		public/*()*/ int Yaw;
		public/*()*/ int Roll;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001DBBF
	//		Pitch = 0;
	//		Yaw = 0;
	//		Roll = 0;
	//	}
	};
	
	public partial struct /*atomic immutable */Quat
	{
		public/*()*/ float X;
		public/*()*/ float Y;
		public/*()*/ float Z;
		public/*()*/ float W;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001DCFB
	//		X = 0.0f;
	//		Y = 0.0f;
	//		Z = 0.0f;
	//		W = 0.0f;
	//	}
	};
	
	public partial struct /*atomic immutable */IntPoint
	{
		public/*()*/ int X;
		public/*()*/ int Y;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001DDFB
	//		X = 0;
	//		Y = 0;
	//	}
	};
	
	public partial struct SHVector
	{
		public/*()*/ StaticArray<float, float, float, float, float, float, float, float, float>/*[9]*/ V;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001DE97
	//		V = new StaticArray<float, float, float, float, float, float, float, float, float>/*[9]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	//			[2] = 0.0f,
	//			[3] = 0.0f,
	//			[4] = 0.0f,
	//			[5] = 0.0f,
	//			[6] = 0.0f,
	//			[7] = 0.0f,
	//			[8] = 0.0f,
	// 		};
	//	}
	};
	
	public partial struct SHVectorRGB
	{
		public/*()*/ Object.SHVector R;
		public/*()*/ Object.SHVector G;
		public/*()*/ Object.SHVector B;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001E05B
	//		R = new Object.SHVector
	//		{
	//			V = new StaticArray<float, float, float, float, float, float, float, float, float>/*[9]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//				[2] = 0.0f,
	//				[3] = 0.0f,
	//				[4] = 0.0f,
	//				[5] = 0.0f,
	//				[6] = 0.0f,
	//				[7] = 0.0f,
	//				[8] = 0.0f,
	//			},
	//		};
	//		G = new Object.SHVector
	//		{
	//			V = new StaticArray<float, float, float, float, float, float, float, float, float>/*[9]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//				[2] = 0.0f,
	//				[3] = 0.0f,
	//				[4] = 0.0f,
	//				[5] = 0.0f,
	//				[6] = 0.0f,
	//				[7] = 0.0f,
	//				[8] = 0.0f,
	//			},
	//		};
	//		B = new Object.SHVector
	//		{
	//			V = new StaticArray<float, float, float, float, float, float, float, float, float>/*[9]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//				[2] = 0.0f,
	//				[3] = 0.0f,
	//				[4] = 0.0f,
	//				[5] = 0.0f,
	//				[6] = 0.0f,
	//				[7] = 0.0f,
	//				[8] = 0.0f,
	//			},
	//		};
	//	}
	};
	
	public partial struct TPOV
	{
		public/*()*/ Object.Vector Location;
		public/*()*/ Object.Rotator Rotation;
		public/*()*/ float FOV;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001E48B
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Rotation = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		FOV = 90.0f;
	//	}
	};
	
	public partial struct /*atomic immutable */Color
	{
		public/*()*/ byte B;
		public/*()*/ byte G;
		public/*()*/ byte R;
		public/*()*/ byte A;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001E687
	//		B = 0;
	//		G = 0;
	//		R = 0;
	//		A = 0;
	//	}
	};
	
	public partial struct /*atomic immutable */LinearColor
	{
		public/*()*/ float R;
		public/*()*/ float G;
		public/*()*/ float B;
		public/*()*/ float A;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001E7D3
	//		R = 0.0f;
	//		G = 0.0f;
	//		B = 0.0f;
	//		A = 1.0f;
	//	}
	};
	
	public partial struct /*atomic immutable */Box
	{
		public/*()*/ Object.Vector Min;
		public/*()*/ Object.Vector Max;
		public byte IsValid;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001E90B
	//		Min = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Max = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		IsValid = 0;
	//	}
	};
	
	public partial struct BoxSphereBounds
	{
		public Object.Vector Origin;
		public Object.Vector BoxExtent;
		public float SphereRadius;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001EA40
	//		Origin = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		BoxExtent = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		SphereRadius = 0.0f;
	//	}
	};
	
	public partial struct /*atomic immutable */Matrix
	{
		public/*()*/ Object.Plane XPlane;
		public/*()*/ Object.Plane YPlane;
		public/*()*/ Object.Plane ZPlane;
		public/*()*/ Object.Plane WPlane;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001EBAC
	//		XPlane = new Plane
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f
	//		};
	//		YPlane = new Plane
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f
	//		};
	//		ZPlane = new Plane
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f
	//		};
	//		WPlane = new Plane
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f
	//		};
	//	}
	};
	
	public partial struct Cylinder
	{
		public float Radius;
		public float Height;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001ECFC
	//		Radius = 0.0f;
	//		Height = 0.0f;
	//	}
	};
	
	public partial struct InterpCurvePointFloat
	{
		public/*()*/ float InVal;
		public/*()*/ float OutVal;
		public/*()*/ float ArriveTangent;
		public/*()*/ float LeaveTangent;
		public/*()*/ Object.EInterpCurveMode InterpMode;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001EEC4
	//		InVal = 0.0f;
	//		OutVal = 0.0f;
	//		ArriveTangent = 0.0f;
	//		LeaveTangent = 0.0f;
	//		InterpMode = Object.EInterpCurveMode.CIM_Linear;
	//	}
	};
	
	public partial struct InterpCurveFloat
	{
		public/*()*/ array<Object.InterpCurvePointFloat> Points;
		public Object.EInterpMethodType InterpMethod;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F01C
	//		Points = default;
	//		InterpMethod = Object.EInterpMethodType.IMT_UseFixedTangentEval;
	//	}
	};
	
	public partial struct InterpCurvePointVector2D
	{
		public/*()*/ float InVal;
		public/*()*/ Object.Vector2D OutVal;
		public/*()*/ Object.Vector2D ArriveTangent;
		public/*()*/ Object.Vector2D LeaveTangent;
		public/*()*/ Object.EInterpCurveMode InterpMode;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F17C
	//		InVal = 0.0f;
	//		OutVal = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		ArriveTangent = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		LeaveTangent = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		InterpMode = Object.EInterpCurveMode.CIM_Linear;
	//	}
	};
	
	public partial struct InterpCurveVector2D
	{
		public/*()*/ array<Object.InterpCurvePointVector2D> Points;
		public Object.EInterpMethodType InterpMethod;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F2F8
	//		Points = default;
	//		InterpMethod = Object.EInterpMethodType.IMT_UseFixedTangentEval;
	//	}
	};
	
	public partial struct InterpCurvePointVector
	{
		public/*()*/ float InVal;
		public/*()*/ Object.Vector OutVal;
		public/*()*/ Object.Vector ArriveTangent;
		public/*()*/ Object.Vector LeaveTangent;
		public/*()*/ Object.EInterpCurveMode InterpMode;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F458
	//		InVal = 0.0f;
	//		OutVal = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		ArriveTangent = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		LeaveTangent = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		InterpMode = Object.EInterpCurveMode.CIM_Linear;
	//	}
	};
	
	public partial struct InterpCurveVector
	{
		public/*()*/ array<Object.InterpCurvePointVector> Points;
		public Object.EInterpMethodType InterpMethod;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F5E0
	//		Points = default;
	//		InterpMethod = Object.EInterpMethodType.IMT_UseFixedTangentEval;
	//	}
	};
	
	public partial struct InterpCurvePointTwoVectors
	{
		public/*()*/ float InVal;
		public/*()*/ Object.TwoVectors OutVal;
		public/*()*/ Object.TwoVectors ArriveTangent;
		public/*()*/ Object.TwoVectors LeaveTangent;
		public/*()*/ Object.EInterpCurveMode InterpMode;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F740
	//		InVal = 0.0f;
	//		OutVal = new TwoVectors
	//		{
	//			v1={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f},
	//			v2={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f}
	//		};
	//		ArriveTangent = new TwoVectors
	//		{
	//			v1={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f},
	//			v2={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f}
	//		};
	//		LeaveTangent = new TwoVectors
	//		{
	//			v1={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f},
	//			v2={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f}
	//		};
	//		InterpMode = Object.EInterpCurveMode.CIM_Linear;
	//	}
	};
	
	public partial struct InterpCurveTwoVectors
	{
		public/*()*/ array<Object.InterpCurvePointTwoVectors> Points;
		public Object.EInterpMethodType InterpMethod;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F8EC
	//		Points = default;
	//		InterpMethod = Object.EInterpMethodType.IMT_UseFixedTangentEval;
	//	}
	};
	
	public partial struct InterpCurvePointQuat
	{
		public/*()*/ float InVal;
		public/*()*/ Object.Quat OutVal;
		public/*()*/ Object.Quat ArriveTangent;
		public/*()*/ Object.Quat LeaveTangent;
		public/*()*/ Object.EInterpCurveMode InterpMode;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001FA4C
	//		InVal = 0.0f;
	//		OutVal = new Quat
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f
	//		};
	//		ArriveTangent = new Quat
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f
	//		};
	//		LeaveTangent = new Quat
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f
	//		};
	//		InterpMode = Object.EInterpCurveMode.CIM_Linear;
	//	}
	};
	
	public partial struct InterpCurveQuat
	{
		public/*()*/ array<Object.InterpCurvePointQuat> Points;
		public Object.EInterpMethodType InterpMethod;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001FBE0
	//		Points = default;
	//		InterpMethod = Object.EInterpMethodType.IMT_UseFixedTangentEval;
	//	}
	};
	
	public partial struct RawDistribution
	{
		public byte Type;
		public byte Op;
		public byte LookupTableNumElements;
		public byte LookupTableChunkSize;
		public array<float> LookupTable;
		public float LookupTableTimeScale;
		public float LookupTableStartTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001FDC8
	//		Type = 0;
	//		Op = 0;
	//		LookupTableNumElements = 0;
	//		LookupTableChunkSize = 0;
	//		LookupTable = default;
	//		LookupTableTimeScale = 0.0f;
	//		LookupTableStartTime = 0.0f;
	//	}
	};
	
	public partial struct RenderCommandFence
	{
		public /*private native const */int NumPendingFences;
	};
	#if false // DISABLED TO BIND EVERYTHING PROPERLY
	public /*private native const noexport */Object.Pointer VfTableObject;
	public /*private native const noexport */int ObjectInternalInteger;
	public /*private native const */Object.QWord ObjectFlags;
	public /*private native const */Object.Pointer HashNext;
	public /*private native const */Object.Pointer HashOuterNext;
	public /*private native const */Object.Pointer StateFrame;
	public /*private native const noexport */Object Linker;
	public /*private native const noexport */Object.Pointer LinkerIndex;
	public /*private native const noexport */int NetIndex;
	public /*native const */Object Outer;
	public/*()*/ /*native const editconst */name Name;
	public /*native const */Class Class;
	public/*()*/ /*native const editconst */Object ObjectArchetype;
	
	// Export UObject::execNot_PreBool(FFrame&, void* const)
	public /*native(129) final preoperator */static bool Not_PreBool(bool A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execEqualEqual_BoolBool(FFrame&, void* const)
	public /*native(242) final operator(24) */static bool EqualEqual_BoolBool(bool A, bool B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNotEqual_BoolBool(FFrame&, void* const)
	public /*native(243) final operator(26) */static bool NotEqual_BoolBool(bool A, bool B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAndAnd_BoolBool(FFrame&, void* const)
	public /*native(130) final operator(30) */static bool AndAnd_BoolBool(bool A, /*skip */bool B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execXorXor_BoolBool(FFrame&, void* const)
	public /*native(131) final operator(30) */static bool XorXor_BoolBool(bool A, bool B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execOrOr_BoolBool(FFrame&, void* const)
	public /*native(132) final operator(32) */static bool OrOr_BoolBool(bool A, /*skip */bool B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiplyEqual_ByteByte(FFrame&, void* const)
	public /*native(133) final operator(34) */static byte MultiplyEqual_ByteByte(ref byte A, byte B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiplyEqual_ByteFloat(FFrame&, void* const)
	public /*native(198) final operator(34) */static byte MultiplyEqual_ByteFloat(ref byte A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDivideEqual_ByteByte(FFrame&, void* const)
	public /*native(134) final operator(34) */static byte DivideEqual_ByteByte(ref byte A, byte B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAddEqual_ByteByte(FFrame&, void* const)
	public /*native(135) final operator(34) */static byte AddEqual_ByteByte(ref byte A, byte B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtractEqual_ByteByte(FFrame&, void* const)
	public /*native(136) final operator(34) */static byte SubtractEqual_ByteByte(ref byte A, byte B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAddAdd_PreByte(FFrame&, void* const)
	public /*native(137) final preoperator */static byte AddAdd_PreByte(ref byte A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtractSubtract_PreByte(FFrame&, void* const)
	public /*native(138) final preoperator */static byte SubtractSubtract_PreByte(ref byte A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAddAdd_Byte(FFrame&, void* const)
	public /*native(139) final postoperator */static byte AddAdd_Byte(ref byte A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtractSubtract_Byte(FFrame&, void* const)
	public /*native(140) final postoperator */static byte SubtractSubtract_Byte(ref byte A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execComplement_PreInt(FFrame&, void* const)
	public /*native(141) final preoperator */static int Complement_PreInt(int A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtract_PreInt(FFrame&, void* const)
	public /*native(143) final preoperator */static int Subtract_PreInt(int A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiply_IntInt(FFrame&, void* const)
	public /*native(144) final operator(16) */static int Multiply_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDivide_IntInt(FFrame&, void* const)
	public /*native(145) final operator(16) */static int Divide_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAdd_IntInt(FFrame&, void* const)
	public /*native(146) final operator(20) */static int Add_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtract_IntInt(FFrame&, void* const)
	public /*native(147) final operator(20) */static int Subtract_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLessLess_IntInt(FFrame&, void* const)
	public /*native(148) final operator(22) */static int LessLess_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGreaterGreater_IntInt(FFrame&, void* const)
	public /*native(149) final operator(22) */static int GreaterGreater_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGreaterGreaterGreater_IntInt(FFrame&, void* const)
	public /*native(196) final operator(22) */static int GreaterGreaterGreater_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLess_IntInt(FFrame&, void* const)
	public /*native(150) final operator(24) */static bool Less_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGreater_IntInt(FFrame&, void* const)
	public /*native(151) final operator(24) */static bool Greater_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLessEqual_IntInt(FFrame&, void* const)
	public /*native(152) final operator(24) */static bool LessEqual_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGreaterEqual_IntInt(FFrame&, void* const)
	public /*native(153) final operator(24) */static bool GreaterEqual_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execEqualEqual_IntInt(FFrame&, void* const)
	public /*native(154) final operator(24) */static bool EqualEqual_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNotEqual_IntInt(FFrame&, void* const)
	public /*native(155) final operator(26) */static bool NotEqual_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAnd_IntInt(FFrame&, void* const)
	public /*native(156) final operator(28) */static int And_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execXor_IntInt(FFrame&, void* const)
	public /*native(157) final operator(28) */static int Xor_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execOr_IntInt(FFrame&, void* const)
	public /*native(158) final operator(28) */static int Or_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiplyEqual_IntFloat(FFrame&, void* const)
	public /*native(159) final operator(34) */static int MultiplyEqual_IntFloat(ref int A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDivideEqual_IntFloat(FFrame&, void* const)
	public /*native(160) final operator(34) */static int DivideEqual_IntFloat(ref int A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAddEqual_IntInt(FFrame&, void* const)
	public /*native(161) final operator(34) */static int AddEqual_IntInt(ref int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtractEqual_IntInt(FFrame&, void* const)
	public /*native(162) final operator(34) */static int SubtractEqual_IntInt(ref int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAddAdd_PreInt(FFrame&, void* const)
	public /*native(163) final preoperator */static int AddAdd_PreInt(ref int A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtractSubtract_PreInt(FFrame&, void* const)
	public /*native(164) final preoperator */static int SubtractSubtract_PreInt(ref int A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAddAdd_Int(FFrame&, void* const)
	public /*native(165) final postoperator */static int AddAdd_Int(ref int A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtractSubtract_Int(FFrame&, void* const)
	public /*native(166) final postoperator */static int SubtractSubtract_Int(ref int A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execRand(FFrame&, void* const)
	public /*native(167) final function */static int Rand(int Max)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMin(FFrame&, void* const)
	public /*native(249) final function */static int Min(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMax(FFrame&, void* const)
	public /*native(250) final function */static int Max(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execClamp(FFrame&, void* const)
	public /*native(251) final function */static int Clamp(int V, int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execToHex(FFrame&, void* const)
	public /*native final function */static String ToHex(int A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtract_PreFloat(FFrame&, void* const)
	public /*native(169) final preoperator */static float Subtract_PreFloat(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiplyMultiply_FloatFloat(FFrame&, void* const)
	public /*native(170) final operator(12) */static float MultiplyMultiply_FloatFloat(float Base, float Exp)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiply_FloatFloat(FFrame&, void* const)
	public /*native(171) final operator(16) */static float Multiply_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDivide_FloatFloat(FFrame&, void* const)
	public /*native(172) final operator(16) */static float Divide_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execPercent_FloatFloat(FFrame&, void* const)
	public /*native(173) final operator(18) */static float Percent_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAdd_FloatFloat(FFrame&, void* const)
	public /*native(174) final operator(20) */static float Add_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtract_FloatFloat(FFrame&, void* const)
	public /*native(175) final operator(20) */static float Subtract_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLess_FloatFloat(FFrame&, void* const)
	public /*native(176) final operator(24) */static bool Less_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGreater_FloatFloat(FFrame&, void* const)
	public /*native(177) final operator(24) */static bool Greater_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLessEqual_FloatFloat(FFrame&, void* const)
	public /*native(178) final operator(24) */static bool LessEqual_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGreaterEqual_FloatFloat(FFrame&, void* const)
	public /*native(179) final operator(24) */static bool GreaterEqual_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execEqualEqual_FloatFloat(FFrame&, void* const)
	public /*native(180) final operator(24) */static bool EqualEqual_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execComplementEqual_FloatFloat(FFrame&, void* const)
	public /*native(210) final operator(24) */static bool ComplementEqual_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNotEqual_FloatFloat(FFrame&, void* const)
	public /*native(181) final operator(26) */static bool NotEqual_FloatFloat(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiplyEqual_FloatFloat(FFrame&, void* const)
	public /*native(182) final operator(34) */static float MultiplyEqual_FloatFloat(ref float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDivideEqual_FloatFloat(FFrame&, void* const)
	public /*native(183) final operator(34) */static float DivideEqual_FloatFloat(ref float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAddEqual_FloatFloat(FFrame&, void* const)
	public /*native(184) final operator(34) */static float AddEqual_FloatFloat(ref float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtractEqual_FloatFloat(FFrame&, void* const)
	public /*native(185) final operator(34) */static float SubtractEqual_FloatFloat(ref float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public /*final operator(18) */static int Percent_IntInt(int A, int B)
	{
	
		return default;
	}
	
	// Export UObject::execAbs(FFrame&, void* const)
	public /*native(186) final function */static float Abs(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSin(FFrame&, void* const)
	public /*native(187) final function */static float Sin(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAsin(FFrame&, void* const)
	public /*native final function */static float Asin(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execCos(FFrame&, void* const)
	public /*native(188) final function */static float Cos(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAcos(FFrame&, void* const)
	public /*native final function */static float Acos(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execTan(FFrame&, void* const)
	public /*native(189) final function */static float Tan(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAtan(FFrame&, void* const)
	public /*native(190) final function */static float Atan(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execExp(FFrame&, void* const)
	public /*native(191) final function */static float Exp(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLoge(FFrame&, void* const)
	public /*native(192) final function */static float Loge(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSqrt(FFrame&, void* const)
	public /*native(193) final function */static float Sqrt(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSquare(FFrame&, void* const)
	public /*native(194) final function */static float Square(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execFRand(FFrame&, void* const)
	public /*native(195) final function */static float FRand()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execFMin(FFrame&, void* const)
	public /*native(244) final function */static float FMin(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execFMax(FFrame&, void* const)
	public /*native(245) final function */static float FMax(float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execFClamp(FFrame&, void* const)
	public /*native(246) final function */static float FClamp(float V, float A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLerp(FFrame&, void* const)
	public /*native(247) final function */static float Lerp(float A, float B, float Alpha)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execRound(FFrame&, void* const)
	public /*native(199) final function */static int Round(float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execFCubicInterp(FFrame&, void* const)
	public /*native final function */static float FCubicInterp(float P0, float T0, float P1, float T1, float A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public /*final function */static float FInterpEaseIn(float A, float B, float Alpha, float Exp)
	{
	
		return default;
	}
	
	public /*final function */static float FInterpEaseOut(float A, float B, float Alpha, float Exp)
	{
	
		return default;
	}
	
	// Export UObject::execFInterpEaseInOut(FFrame&, void* const)
	public /*native final function */static float FInterpEaseInOut(float A, float B, float Alpha, float Exp)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public /*final simulated function */static float RandRange(float InMin, float InMax)
	{
	
		return default;
	}
	
	public /*final simulated function */static float FPctByRange(float Value, float InMin, float InMax)
	{
	
		return default;
	}
	
	// Export UObject::execFInterpTo(FFrame&, void* const)
	public /*native final function */static float FInterpTo(float Current, float Target, float DeltaTime, float InterpSpeed)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtract_PreVector(FFrame&, void* const)
	public /*native(211) final preoperator */static Object.Vector Subtract_PreVector(Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiply_VectorFloat(FFrame&, void* const)
	public /*native(212) final operator(16) */static Object.Vector Multiply_VectorFloat(Object.Vector A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiply_FloatVector(FFrame&, void* const)
	public /*native(213) final operator(16) */static Object.Vector Multiply_FloatVector(float A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiply_VectorVector(FFrame&, void* const)
	public /*native(296) final operator(16) */static Object.Vector Multiply_VectorVector(Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDivide_VectorFloat(FFrame&, void* const)
	public /*native(214) final operator(16) */static Object.Vector Divide_VectorFloat(Object.Vector A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAdd_VectorVector(FFrame&, void* const)
	public /*native(215) final operator(20) */static Object.Vector Add_VectorVector(Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtract_VectorVector(FFrame&, void* const)
	public /*native(216) final operator(20) */static Object.Vector Subtract_VectorVector(Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLessLess_VectorRotator(FFrame&, void* const)
	public /*native(275) final operator(22) */static Object.Vector LessLess_VectorRotator(Object.Vector A, Object.Rotator B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGreaterGreater_VectorRotator(FFrame&, void* const)
	public /*native(276) final operator(22) */static Object.Vector GreaterGreater_VectorRotator(Object.Vector A, Object.Rotator B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execEqualEqual_VectorVector(FFrame&, void* const)
	public /*native(217) final operator(24) */static bool EqualEqual_VectorVector(Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNotEqual_VectorVector(FFrame&, void* const)
	public /*native(218) final operator(26) */static bool NotEqual_VectorVector(Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDot_VectorVector(FFrame&, void* const)
	public /*native(219) final operator(16) */static float Dot_VectorVector(Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execCross_VectorVector(FFrame&, void* const)
	public /*native(220) final operator(16) */static Object.Vector Cross_VectorVector(Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiplyEqual_VectorFloat(FFrame&, void* const)
	public /*native(221) final operator(34) */static Object.Vector MultiplyEqual_VectorFloat(ref Object.Vector A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiplyEqual_VectorVector(FFrame&, void* const)
	public /*native(297) final operator(34) */static Object.Vector MultiplyEqual_VectorVector(ref Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDivideEqual_VectorFloat(FFrame&, void* const)
	public /*native(222) final operator(34) */static Object.Vector DivideEqual_VectorFloat(ref Object.Vector A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAddEqual_VectorVector(FFrame&, void* const)
	public /*native(223) final operator(34) */static Object.Vector AddEqual_VectorVector(ref Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtractEqual_VectorVector(FFrame&, void* const)
	public /*native(224) final operator(34) */static Object.Vector SubtractEqual_VectorVector(ref Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execVSize(FFrame&, void* const)
	public /*native(225) final function */static float VSize(Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execVSize2D(FFrame&, void* const)
	public /*native final function */static float VSize2D(Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execVSizeSq(FFrame&, void* const)
	public /*native final function */static float VSizeSq(Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execVSizeSq2D(FFrame&, void* const)
	public /*native final function */static float VSizeSq2D(Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNormal(FFrame&, void* const)
	public /*native(226) final function */static Object.Vector Normal(Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execVLerp(FFrame&, void* const)
	public /*native final function */static Object.Vector VLerp(Object.Vector A, Object.Vector B, float Alpha)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execVSmerp(FFrame&, void* const)
	public /*native final function */static Object.Vector VSmerp(Object.Vector A, Object.Vector B, float Alpha)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execVRand(FFrame&, void* const)
	public /*native(252) final function */static Object.Vector VRand()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMirrorVectorByNormal(FFrame&, void* const)
	public /*native(300) final function */static Object.Vector MirrorVectorByNormal(Object.Vector InVect, Object.Vector InNormal)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execProjectOnTo(FFrame&, void* const)
	public /*native(1500) final function */static Object.Vector ProjectOnTo(Object.Vector X, Object.Vector Y)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execIsZero(FFrame&, void* const)
	public /*native(1501) final function */static bool IsZero(Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execVInterpTo(FFrame&, void* const)
	public /*native final function */static Object.Vector VInterpTo(Object.Vector Current, Object.Vector Target, float DeltaTime, float InterpSpeed)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execClampLength(FFrame&, void* const)
	public /*native final function */static Object.Vector ClampLength(Object.Vector V, float MaxLength)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execEqualEqual_RotatorRotator(FFrame&, void* const)
	public /*native(142) final operator(24) */static bool EqualEqual_RotatorRotator(Object.Rotator A, Object.Rotator B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNotEqual_RotatorRotator(FFrame&, void* const)
	public /*native(203) final operator(26) */static bool NotEqual_RotatorRotator(Object.Rotator A, Object.Rotator B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiply_RotatorFloat(FFrame&, void* const)
	public /*native(287) final operator(16) */static Object.Rotator Multiply_RotatorFloat(Object.Rotator A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiply_FloatRotator(FFrame&, void* const)
	public /*native(288) final operator(16) */static Object.Rotator Multiply_FloatRotator(float A, Object.Rotator B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDivide_RotatorFloat(FFrame&, void* const)
	public /*native(289) final operator(16) */static Object.Rotator Divide_RotatorFloat(Object.Rotator A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiplyEqual_RotatorFloat(FFrame&, void* const)
	public /*native(290) final operator(34) */static Object.Rotator MultiplyEqual_RotatorFloat(ref Object.Rotator A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDivideEqual_RotatorFloat(FFrame&, void* const)
	public /*native(291) final operator(34) */static Object.Rotator DivideEqual_RotatorFloat(ref Object.Rotator A, float B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAdd_RotatorRotator(FFrame&, void* const)
	public /*native(316) final operator(20) */static Object.Rotator Add_RotatorRotator(Object.Rotator A, Object.Rotator B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtract_RotatorRotator(FFrame&, void* const)
	public /*native(317) final operator(20) */static Object.Rotator Subtract_RotatorRotator(Object.Rotator A, Object.Rotator B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAddEqual_RotatorRotator(FFrame&, void* const)
	public /*native(318) final operator(34) */static Object.Rotator AddEqual_RotatorRotator(ref Object.Rotator A, Object.Rotator B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtractEqual_RotatorRotator(FFrame&, void* const)
	public /*native(319) final operator(34) */static Object.Rotator SubtractEqual_RotatorRotator(ref Object.Rotator A, Object.Rotator B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execClockwiseFrom_IntInt(FFrame&, void* const)
	public /*native final operator(24) */static bool ClockwiseFrom_IntInt(int A, int B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGetAxes(FFrame&, void* const)
	public /*native(229) final function */static void GetAxes(Object.Rotator A, ref Object.Vector X, ref Object.Vector Y, ref Object.Vector Z)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execGetUnAxes(FFrame&, void* const)
	public /*native(230) final function */static void GetUnAxes(Object.Rotator A, ref Object.Vector X, ref Object.Vector Y, ref Object.Vector Z)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execRotRand(FFrame&, void* const)
	public /*native(320) final function */static Object.Rotator RotRand(/*optional */bool? _bRoll = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execOrthoRotation(FFrame&, void* const)
	public /*native final function */static Object.Rotator OrthoRotation(Object.Vector X, Object.Vector Y, Object.Vector Z)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNormalize(FFrame&, void* const)
	public /*native final function */static Object.Rotator Normalize(Object.Rotator Rot)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execRLerp(FFrame&, void* const)
	public /*native final function */static Object.Rotator RLerp(Object.Rotator A, Object.Rotator B, float Alpha, /*optional */bool? _bShortestPath = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execRSmerp(FFrame&, void* const)
	public /*native final function */static Object.Rotator RSmerp(Object.Rotator A, Object.Rotator B, float Alpha, /*optional */bool? _bShortestPath = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execRInterpTo(FFrame&, void* const)
	public /*native final function */static Object.Rotator RInterpTo(Object.Rotator Current, Object.Rotator Target, float DeltaTime, float InterpSpeed)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNormalizeRotAxis(FFrame&, void* const)
	public /*native final function */static int NormalizeRotAxis(int Angle)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execRDiff(FFrame&, void* const)
	public /*native final function */static float RDiff(Object.Rotator A, Object.Rotator B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public /*final function */static float RSize(Object.Rotator R)
	{
	
		return default;
	}
	
	public /*final simulated function */static void ClampRotAxis(int ViewAxis, ref int out_DeltaViewAxis, int MaxLimit, int MinLimit)
	{
	
	}
	
	public /*final simulated function */static int ClampRotAxisFromBase(int Current, int Center, int MaxDelta)
	{
	
		return default;
	}
	
	public /*final simulated function */static int ClampRotAxisFromRange(int Current, int Min, int Max)
	{
	
		return default;
	}
	
	public /*final simulated function */static bool SClampRotAxis(float DeltaTime, int ViewAxis, ref int out_DeltaViewAxis, int MaxLimit, int MinLimit, float InterpolationSpeed)
	{
	
		return default;
	}
	
	// Export UObject::execConcat_StrStr(FFrame&, void* const)
	public /*native(112) final operator(40) */static String Concat_StrStr(/*coerce */String A, /*coerce */String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAt_StrStr(FFrame&, void* const)
	public /*native(168) final operator(40) */static String At_StrStr(/*coerce */String A, /*coerce */String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLess_StrStr(FFrame&, void* const)
	public /*native(115) final operator(24) */static bool Less_StrStr(String A, String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGreater_StrStr(FFrame&, void* const)
	public /*native(116) final operator(24) */static bool Greater_StrStr(String A, String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLessEqual_StrStr(FFrame&, void* const)
	public /*native(120) final operator(24) */static bool LessEqual_StrStr(String A, String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGreaterEqual_StrStr(FFrame&, void* const)
	public /*native(121) final operator(24) */static bool GreaterEqual_StrStr(String A, String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execEqualEqual_StrStr(FFrame&, void* const)
	public /*native(122) final operator(24) */static bool EqualEqual_StrStr(String A, String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNotEqual_StrStr(FFrame&, void* const)
	public /*native(123) final operator(26) */static bool NotEqual_StrStr(String A, String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execComplementEqual_StrStr(FFrame&, void* const)
	public /*native(124) final operator(24) */static bool ComplementEqual_StrStr(String A, String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execConcatEqual_StrStr(FFrame&, void* const)
	public /*native(322) final operator(44) */static String ConcatEqual_StrStr(ref String A, /*coerce */String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAtEqual_StrStr(FFrame&, void* const)
	public /*native(323) final operator(44) */static String AtEqual_StrStr(ref String A, /*coerce */String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtractEqual_StrStr(FFrame&, void* const)
	public /*native(324) final operator(45) */static String SubtractEqual_StrStr(ref String A, /*coerce */String B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLen(FFrame&, void* const)
	public /*native(125) final function */static int Len(/*coerce */String S)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execInStr(FFrame&, void* const)
	public /*native(126) final function */static int InStr(/*coerce */String S, /*coerce */String T, /*optional */bool? _bSearchFromRight = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMid(FFrame&, void* const)
	public /*native(127) final function */static String Mid(/*coerce */String S, int I, /*optional */int? _J = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLeft(FFrame&, void* const)
	public /*native(128) final function */static String Left(/*coerce */String S, int I)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execRight(FFrame&, void* const)
	public /*native(234) final function */static String Right(/*coerce */String S, int I)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execCaps(FFrame&, void* const)
	public /*native(235) final function */static String Caps(/*coerce */String S)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execLocs(FFrame&, void* const)
	public /*native(238) final function */static String Locs(/*coerce */String S)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execChr(FFrame&, void* const)
	public /*native(236) final function */static String Chr(int I)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAsc(FFrame&, void* const)
	public /*native(237) final function */static int Asc(String S)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execRepl(FFrame&, void* const)
	public /*native(201) final function */static String Repl(/*coerce */String Src, /*coerce */String Match, /*coerce */String With, /*optional */bool? _bCaseSensitive = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public /*final function */static String Split(/*coerce */String Text, /*coerce */String SplitStr, /*optional */bool? _bOmitSplitStr = default)
	{
	
		return default;
	}
	
	public /*final function */static String GetRightMost(/*coerce */String Text)
	{
	
		return default;
	}
	
	public /*final function */static void JoinArray(array<String> StringArray, ref String out_Result, /*optional */String? _delim = default, /*optional */bool? _bIgnoreBlanks = default)
	{
	
	}
	
	// Export UObject::execParseStringIntoArray(FFrame&, void* const)
	public /*native final function */static void ParseStringIntoArray(String BaseString, ref array<String> Pieces, String delim, bool bCullEmpty)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execPathName(FFrame&, void* const)
	public /*native final function */static String PathName(Object CheckObject)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execEqualEqual_ObjectObject(FFrame&, void* const)
	public /*native(114) final operator(24) */static bool EqualEqual_ObjectObject(Object A, Object B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNotEqual_ObjectObject(FFrame&, void* const)
	public /*native(119) final operator(26) */static bool NotEqual_ObjectObject(Object A, Object B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execEqualEqual_InterfaceInterface(FFrame&, void* const)
	public /*native final operator(24) */static bool EqualEqual_InterfaceInterface(Interface A, Interface B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNotEqual_InterfaceInterface(FFrame&, void* const)
	public /*native final operator(26) */static bool NotEqual_InterfaceInterface(Interface A, Interface B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execClassIsChildOf(FFrame&, void* const)
	public /*native(258) final function */static bool ClassIsChildOf(Class TestClass, Class ParentClass)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execIsA(FFrame&, void* const)
	public virtual /*native(197) final function */bool IsA(name ClassName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execEqualEqual_NameName(FFrame&, void* const)
	public /*native(254) final operator(24) */static bool EqualEqual_NameName(name A, name B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execNotEqual_NameName(FFrame&, void* const)
	public /*native(255) final operator(26) */static bool NotEqual_NameName(name A, name B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMultiply_MatrixMatrix(FFrame&, void* const)
	public /*native final operator(34) */static Object.Matrix Multiply_MatrixMatrix(Object.Matrix A, Object.Matrix B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execTransformVector(FFrame&, void* const)
	public /*native final function */static Object.Vector TransformVector(Object.Matrix TM, Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execInverseTransformVector(FFrame&, void* const)
	public /*native final function */static Object.Vector InverseTransformVector(Object.Matrix TM, Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execTransformNormal(FFrame&, void* const)
	public /*native final function */static Object.Vector TransformNormal(Object.Matrix TM, Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execInverseTransformNormal(FFrame&, void* const)
	public /*native final function */static Object.Vector InverseTransformNormal(Object.Matrix TM, Object.Vector A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMakeRotationTranslationMatrix(FFrame&, void* const)
	public /*native final function */static Object.Matrix MakeRotationTranslationMatrix(Object.Vector Translation, Object.Rotator Rotation)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMatrixGetRotator(FFrame&, void* const)
	public /*native final function */static Object.Rotator MatrixGetRotator(Object.Matrix TM)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execMatrixGetOrigin(FFrame&, void* const)
	public /*native final function */static Object.Vector MatrixGetOrigin(Object.Matrix TM)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execQuatProduct(FFrame&, void* const)
	public /*native final function */static Object.Quat QuatProduct(Object.Quat A, Object.Quat B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execQuatDot(FFrame&, void* const)
	public /*native final function */static float QuatDot(Object.Quat A, Object.Quat B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execQuatInvert(FFrame&, void* const)
	public /*native final function */static Object.Quat QuatInvert(Object.Quat A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execQuatRotateVector(FFrame&, void* const)
	public /*native final function */static Object.Vector QuatRotateVector(Object.Quat A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execQuatFindBetween(FFrame&, void* const)
	public /*native final function */static Object.Quat QuatFindBetween(Object.Vector A, Object.Vector B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execQuatFromAxisAndAngle(FFrame&, void* const)
	public /*native final function */static Object.Quat QuatFromAxisAndAngle(Object.Vector Axis, float Angle)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execQuatFromRotator(FFrame&, void* const)
	public /*native final function */static Object.Quat QuatFromRotator(Object.Rotator A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execQuatToRotator(FFrame&, void* const)
	public /*native final function */static Object.Rotator QuatToRotator(Object.Quat A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execQuatSlerp(FFrame&, void* const)
	public /*native final function */static Object.Quat QuatSlerp(Object.Quat A, Object.Quat B, float Alpha, /*optional */bool? _bShortestPath = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execAdd_QuatQuat(FFrame&, void* const)
	public /*native(270) final operator(16) */static Object.Quat Add_QuatQuat(Object.Quat A, Object.Quat B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSubtract_QuatQuat(FFrame&, void* const)
	public /*native(271) final operator(16) */static Object.Quat Subtract_QuatQuat(Object.Quat A, Object.Quat B)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public /*final simulated function */static float GetRangeValueByPct(Object.Vector2D Range, float Pct)
	{
	
		return default;
	}
	
	public /*final simulated function */static float GetRangePctByValue(Object.Vector2D Range, float Value)
	{
	
		return default;
	}
	
	public /*final function */static Object.Vector2D vect2d(float InX, float InY)
	{
	
		return default;
	}
	
	public /*final operator(20) */static Object.Color Subtract_ColorColor(Object.Color A, Object.Color B)
	{
	
		return default;
	}
	
	public /*final operator(16) */static Object.Color Multiply_FloatColor(float A, Object.Color B)
	{
	
		return default;
	}
	
	public /*final operator(16) */static Object.Color Multiply_ColorFloat(Object.Color A, float B)
	{
	
		return default;
	}
	
	public /*final operator(20) */static Object.Color Add_ColorColor(Object.Color A, Object.Color B)
	{
	
		return default;
	}
	
	public /*final function */static Object.Color MakeColor(byte R, byte G, byte B, /*optional */byte? _A = default)
	{
	
		return default;
	}
	
	public /*final function */static Object.LinearColor MakeLinearColor(float R, float G, float B, float A)
	{
	
		return default;
	}
	
	public /*final function */static Object.LinearColor ColorToLinearColor(Object.Color OldColor)
	{
	
		return default;
	}
	
	public /*final operator(16) */static Object.LinearColor Multiply_LinearColorFloat(Object.LinearColor LC, float Mult)
	{
	
		return default;
	}
	
	public /*final operator(20) */static Object.LinearColor Subtract_LinearColorLinearColor(Object.LinearColor A, Object.LinearColor B)
	{
	
		return default;
	}
	
	// Export UObject::execLogInternal(FFrame&, void* const)
	public /*private native(231) final function */static void LogInternal(/*coerce */String S, /*optional */name? _Tag = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execWarnInternal(FFrame&, void* const)
	public /*private native(232) final function */static void WarnInternal(/*coerce */String S)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execLocalize(FFrame&, void* const)
	public /*native function */static String Localize(String SectionName, String KeyName, String PackageName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execScriptTrace(FFrame&, void* const)
	public /*native final function */static void ScriptTrace()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execScriptTraceString(FFrame&, void* const)
	public /*native final function */static String ScriptTraceString()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGetFuncName(FFrame&, void* const)
	public /*native final function */static name GetFuncName()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSetUTracing(FFrame&, void* const)
	public /*native final function */static void SetUTracing(bool bShouldUTrace)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execIsUTracing(FFrame&, void* const)
	public /*native final function */static bool IsUTracing()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGotoState(FFrame&, void* const)
	public virtual /*native(113) final function */void GotoState(/*optional */name? _NewState = default, /*optional */name? _Label = default, /*optional */bool? _bForceEvents = default, /*optional */bool? _bKeepStack = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execIsInState(FFrame&, void* const)
	public virtual /*native(281) final function */bool IsInState(name TestState, /*optional */bool? _bTestStateStack = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGetStateStack(FFrame&, void* const)
	public virtual /*native final function */String GetStateStack()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGetStateStackSize(FFrame&, void* const)
	public virtual /*native final function */int GetStateStackSize()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execIsChildState(FFrame&, void* const)
	public virtual /*native final function */bool IsChildState(name TestState, name TestParentState)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGetStateName(FFrame&, void* const)
	public virtual /*native(284) final function */name GetStateName()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execPushState(FFrame&, void* const)
	public virtual /*native final function */void PushState(name NewState, /*optional */name? _NewLabel = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execPopState(FFrame&, void* const)
	public virtual /*native final function */void PopState(/*optional */bool? _bPopAll = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execDumpStateStack(FFrame&, void* const)
	public virtual /*native final function */void DumpStateStack()
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void BeginState_del(name PreviousStateName);
	public virtual BeginState_del BeginState { get => bfield_BeginState ?? Object_BeginState; set => bfield_BeginState = value; } BeginState_del bfield_BeginState;
	public virtual BeginState_del global_BeginState => Object_BeginState;
	public /*event */void Object_BeginState(name PreviousStateName)
	{
	
	}
	
	public delegate void EndState_del(name NextStateName);
	public virtual EndState_del EndState { get => bfield_EndState ?? Object_EndState; set => bfield_EndState = value; } EndState_del bfield_EndState;
	public virtual EndState_del global_EndState => Object_EndState;
	public /*event */void Object_EndState(name NextStateName)
	{
	
	}
	
	public delegate void PushedState_del();
	public virtual PushedState_del PushedState { get => bfield_PushedState ?? Object_PushedState; set => bfield_PushedState = value; } PushedState_del bfield_PushedState;
	public virtual PushedState_del global_PushedState => Object_PushedState;
	public /*event */void Object_PushedState()
	{
	
	}
	
	public delegate void PoppedState_del();
	public virtual PoppedState_del PoppedState { get => bfield_PoppedState ?? Object_PoppedState; set => bfield_PoppedState = value; } PoppedState_del bfield_PoppedState;
	public virtual PoppedState_del global_PoppedState => Object_PoppedState;
	public /*event */void Object_PoppedState()
	{
	
	}
	
	public delegate void PausedState_del();
	public virtual PausedState_del PausedState { get => bfield_PausedState ?? Object_PausedState; set => bfield_PausedState = value; } PausedState_del bfield_PausedState;
	public virtual PausedState_del global_PausedState => Object_PausedState;
	public /*event */void Object_PausedState()
	{
	
	}
	
	public delegate void ContinuedState_del();
	public virtual ContinuedState_del ContinuedState { get => bfield_ContinuedState ?? Object_ContinuedState; set => bfield_ContinuedState = value; } ContinuedState_del bfield_ContinuedState;
	public virtual ContinuedState_del global_ContinuedState => Object_ContinuedState;
	public /*event */void Object_ContinuedState()
	{
	
	}
	
	// Export UObject::execEnable(FFrame&, void* const)
	public virtual /*native(117) final function */void Enable(name ProbeFunc)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execDisable(FFrame&, void* const)
	public virtual /*native(118) final function */void Disable(name ProbeFunc)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execGetEnum(FFrame&, void* const)
	public /*native final function */static name GetEnum(Object E, /*coerce */int I)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execDynamicLoadObject(FFrame&, void* const)
	public /*native final function */static Object DynamicLoadObject(String ObjectName, Class ObjectClass, /*optional */bool? _MayFail = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execFindObject(FFrame&, void* const)
	public /*native final function */static Object FindObject(String ObjectName, Class ObjectClass)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execSaveConfig(FFrame&, void* const)
	public virtual /*native(536) final function */void SaveConfig()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execStaticSaveConfig(FFrame&, void* const)
	public /*native final function */static void StaticSaveConfig()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UObject::execGetPerObjectConfigSections(FFrame&, void* const)
	public /*native final function */static bool GetPerObjectConfigSections(Class SearchClass, ref array<String> out_SectionNames, /*optional */Object? _ObjectOuter = default, /*optional */int? _MaxResults = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execPointDistToLine(FFrame&, void* const)
	public virtual /*native final function */float PointDistToLine(Object.Vector Point, Object.Vector Line, Object.Vector Origin, /*optional */ref Object.Vector OutClosestPoint/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final simulated function */float PointDistToPlane(Object.Vector Point, Object.Rotator Orientation, Object.Vector Origin, /*optional */ref Object.Vector out_ClosestPoint/* = default*/)
	{
	
		return default;
	}
	
	public /*final function */static bool PointInBox(Object.Vector Point, Object.Vector Location, Object.Vector Extent)
	{
	
		return default;
	}
	
	// Export UObject::execGetDotDistance(FFrame&, void* const)
	public /*native final function */static bool GetDotDistance(ref Object.Vector2D OutDotDist, Object.Vector Direction, Object.Vector AxisX, Object.Vector AxisY, Object.Vector AxisZ)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGetAngularDistance(FFrame&, void* const)
	public /*native final function */static bool GetAngularDistance(ref Object.Vector2D OutAngularDist, Object.Vector Direction, Object.Vector AxisX, Object.Vector AxisY, Object.Vector AxisZ)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UObject::execGetAngularFromDotDist(FFrame&, void* const)
	public /*native final function */static void GetAngularFromDotDist(ref Object.Vector2D OutAngDist, Object.Vector2D DotDist)
	{
		#warning NATIVE FUNCTION !
	}
	
	public /*final simulated function */static void GetAngularDegreesFromRadians(ref Object.Vector2D OutFOV)
	{
	
	}
	
	public /*final simulated function */static float GetHeadingAngle(Object.Vector Dir)
	{
	
		return default;
	}
	
	public /*final simulated function */static float FindDeltaAngle(float A1, float A2)
	{
	
		return default;
	}
	
	public /*final simulated function */static float UnwindHeading(float A)
	{
	
		return default;
	}
	
	public virtual /*final simulated function */byte FloatToByte(float inputFloat, /*optional */bool? _bSigned = default)
	{
	
		return default;
	}
	
	public virtual /*final simulated function */float ByteToFloat(byte inputByte, /*optional */bool? _bSigned = default)
	{
	
		return default;
	}
	
	// Export UObject::execIsPendingKill(FFrame&, void* const)
	public virtual /*native final function */bool IsPendingKill()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final function */name GetPackageName()
	{
	
		return default;
	}
	
	// Export UObject::execTransformVectorByRotation(FFrame&, void* const)
	public virtual /*native final function */Object.Vector TransformVectorByRotation(Object.Rotator SourceRotation, Object.Vector SourceVector, /*optional */bool? _bInverse = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		BeginState = null;
		EndState = null;
		PushedState = null;
		PoppedState = null;
		PausedState = null;
		ContinuedState = null;
	
	}
#endif
}
}