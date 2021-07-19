namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpeedTree : Object/*
		native*/{
	[duplicatetransient, native, Const] public Object.Pointer SRH;
	[Category] public int RandomSeed;
	[Category] public float Sink;
	[Category("Lighting")] public float LeafStaticShadowOpacity;
	[Category("Material")] public MaterialInterface BranchMaterial;
	[Category("Material")] public MaterialInterface FrondMaterial;
	[Category("Material")] public MaterialInterface LeafMaterial;
	[Category("Material")] public MaterialInterface BillboardMaterial;
	[Category("Wind")] public float MaxBendAngle;
	[Category("Wind")] public float BranchExponent;
	[Category("Wind")] public float LeafExponent;
	[Category("Wind")] public float Response;
	[Category("Wind")] public float ResponseLimiter;
	[Category("Wind")] public float Gusting_MinStrength;
	[Category("Wind")] public float Gusting_MaxStrength;
	[Category("Wind")] public float Gusting_Frequency;
	[Category("Wind")] public float Gusting_MinDuration;
	[Category("Wind")] public float Gusting_MaxDuration;
	[Category("Wind")] public float BranchHorizontal_LowWindAngle;
	[Category("Wind")] public float BranchHorizontal_LowWindSpeed;
	[Category("Wind")] public float BranchHorizontal_HighWindAngle;
	[Category("Wind")] public float BranchHorizontal_HighWindSpeed;
	[Category("Wind")] public float BranchVertical_LowWindAngle;
	[Category("Wind")] public float BranchVertical_LowWindSpeed;
	[Category("Wind")] public float BranchVertical_HighWindAngle;
	[Category("Wind")] public float BranchVertical_HighWindSpeed;
	[Category("Wind")] public float LeafRocking_LowWindAngle;
	[Category("Wind")] public float LeafRocking_LowWindSpeed;
	[Category("Wind")] public float LeafRocking_HighWindAngle;
	[Category("Wind")] public float LeafRocking_HighWindSpeed;
	[Category("Wind")] public float LeafRustling_LowWindAngle;
	[Category("Wind")] public float LeafRustling_LowWindSpeed;
	[Category("Wind")] public float LeafRustling_HighWindAngle;
	[Category("Wind")] public float LeafRustling_HighWindSpeed;
	
	public SpeedTree()
	{
		// Object Offset:0x003EBF0E
		RandomSeed = 1;
		LeafStaticShadowOpacity = 0.50f;
		MaxBendAngle = 35.0f;
		BranchExponent = 1.0f;
		LeafExponent = 1.0f;
		Response = 0.10f;
		ResponseLimiter = 0.010f;
		Gusting_MinStrength = 0.250f;
		Gusting_MaxStrength = 1.250f;
		Gusting_Frequency = 0.40f;
		Gusting_MinDuration = 2.0f;
		Gusting_MaxDuration = 15.0f;
		BranchHorizontal_LowWindAngle = 3.0f;
		BranchHorizontal_LowWindSpeed = 1.50f;
		BranchHorizontal_HighWindAngle = 3.0f;
		BranchHorizontal_HighWindSpeed = 1.50f;
		BranchVertical_LowWindAngle = 4.0f;
		BranchVertical_LowWindSpeed = 2.0f;
		BranchVertical_HighWindAngle = 4.0f;
		BranchVertical_HighWindSpeed = 2.0f;
		LeafRocking_LowWindAngle = 5.0f;
		LeafRocking_LowWindSpeed = 1.0f;
		LeafRocking_HighWindAngle = 5.0f;
		LeafRocking_HighWindSpeed = 3.0f;
		LeafRustling_LowWindAngle = 7.0f;
		LeafRustling_LowWindSpeed = 0.10f;
		LeafRustling_HighWindAngle = 5.0f;
		LeafRustling_HighWindSpeed = 15.0f;
	}
}
}