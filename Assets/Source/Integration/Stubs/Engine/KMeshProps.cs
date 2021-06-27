namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class KMeshProps : Object/*
		native
		noexport*/{
	public partial struct KSphereElem
	{
		public/*()*/ /*editconst */Object.Matrix TM;
		public/*()*/ /*editconst */float Radius;
		public/*()*/ bool bNoRBCollision;
		public/*()*/ bool bPerPolyShape;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B0696
	//		TM = new Matrix
	//		{
	//			XPlane={X=0.0f,
	//			Y=1.0f,
	//			Z=0.0f,
	//			W=0.0f},
	//			YPlane={X=0.0f,
	//			Y=0.0f,
	//			Z=1.0f,
	//			W=0.0f},
	//			ZPlane={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=1.0f},
	//			WPlane={X=1.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f}
	//		};
	//		Radius = 1.0f;
	//		bNoRBCollision = false;
	//		bPerPolyShape = false;
	//	}
	};
	
	public partial struct KBoxElem
	{
		public/*()*/ /*editconst */Object.Matrix TM;
		public/*()*/ /*editconst */float X;
		public/*()*/ /*editconst */float Y;
		public/*()*/ /*editconst */float Z;
		public/*()*/ bool bNoRBCollision;
		public/*()*/ bool bPerPolyShape;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B088E
	//		TM = new Matrix
	//		{
	//			XPlane={X=0.0f,
	//			Y=1.0f,
	//			Z=0.0f,
	//			W=0.0f},
	//			YPlane={X=0.0f,
	//			Y=0.0f,
	//			Z=1.0f,
	//			W=0.0f},
	//			ZPlane={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=1.0f},
	//			WPlane={X=1.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f}
	//		};
	//		X = 1.0f;
	//		Y = 1.0f;
	//		Z = 1.0f;
	//		bNoRBCollision = false;
	//		bPerPolyShape = false;
	//	}
	};
	
	public partial struct KSphylElem
	{
		public/*()*/ /*editconst */Object.Matrix TM;
		public/*()*/ /*editconst */float Radius;
		public/*()*/ /*editconst */float Length;
		public/*()*/ bool bNoRBCollision;
		public/*()*/ bool bPerPolyShape;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B0A92
	//		TM = new Matrix
	//		{
	//			XPlane={X=0.0f,
	//			Y=1.0f,
	//			Z=0.0f,
	//			W=0.0f},
	//			YPlane={X=0.0f,
	//			Y=0.0f,
	//			Z=1.0f,
	//			W=0.0f},
	//			ZPlane={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=1.0f},
	//			WPlane={X=1.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f}
	//		};
	//		Radius = 1.0f;
	//		Length = 1.0f;
	//		bNoRBCollision = false;
	//		bPerPolyShape = false;
	//	}
	};
	
	public partial struct KConvexElem
	{
		public array<Object.Vector> VertexData;
		public array<Object.Plane> PermutedVertexData;
		public array<int> FaceTriData;
		public array<Object.Vector> EdgeDirections;
		public array<Object.Vector> FaceNormalDirections;
		public array<Object.Plane> FacePlaneData;
		public Object.Box ElemBox;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B0E06
	//		VertexData = default;
	//		PermutedVertexData = default;
	//		FaceTriData = default;
	//		EdgeDirections = default;
	//		FaceNormalDirections = default;
	//		FacePlaneData = default;
	//		ElemBox = new Box
	//		{
	//			Min={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f},
	//			Max={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f},
	//			IsValid=0
	//		};
	//	}
	};
	
	public partial struct KAggregateGeom
	{
		public/*()*/ /*editfixedsize */array<KMeshProps.KSphereElem> SphereElems;
		public/*()*/ /*editfixedsize */array<KMeshProps.KBoxElem> BoxElems;
		public/*()*/ /*editfixedsize */array<KMeshProps.KSphylElem> SphylElems;
		public/*()*/ /*editfixedsize */array<KMeshProps.KConvexElem> ConvexElems;
		public /*noimport nontransactional native */Object.Pointer RenderInfo;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B10CF
	//		SphereElems = default;
	//		BoxElems = default;
	//		SphylElems = default;
	//		ConvexElems = default;
	//	}
	};
	
	public/*()*/ Object.Vector COMNudge;
	public/*()*/ KMeshProps.KAggregateGeom AggGeom;
	
}
}