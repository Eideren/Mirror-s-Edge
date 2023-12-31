namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FoliageComponent : PrimitiveComponent/*
		native*/{
	public partial struct /*native */FoliageInstanceBase
	{
		public Object.Vector Location;
		public Object.Vector XAxis;
		public Object.Vector YAxis;
		public Object.Vector ZAxis;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0031ED1F
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		XAxis = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		YAxis = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		ZAxis = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public partial struct /*native */GatheredFoliageInstance// extends FoliageInstanceBase
	{
		public Object.Vector Location;
		public Object.Vector XAxis;
		public Object.Vector YAxis;
		public Object.Vector ZAxis;
	
		public StaticArray<Object.Color, Object.Color, Object.Color, Object.Color>/*[4]*/ StaticLighting;
			// Object Offset:0x0031ED1F
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		XAxis = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		YAxis = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		ZAxis = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	[Const] public array<FoliageComponent.GatheredFoliageInstance> Instances;
	[Const] public array<Object.Guid> StaticallyRelevantLights;
	[Const] public array<Object.Guid> StaticallyIrrelevantLights;
	[Const] public StaticArray<float, float, float>/*[3]*/ DirectionalStaticLightingScale;
	[Const] public StaticArray<float, float, float>/*[3]*/ SimpleStaticLightingScale;
	[Const] public StaticMesh InstanceStaticMesh;
	[Const] public MaterialInterface Material;
	public float MaxDrawRadius;
	public float MinTransitionRadius;
	public Object.Vector MinScale;
	public Object.Vector MaxScale;
	public float SwayScale;
	
	public FoliageComponent()
	{
		// Object Offset:0x0031F12B
		bForceDirectLightMap = true;
		bAcceptsLights = true;
		bUsePrecomputedShadows = true;
	}
}
}