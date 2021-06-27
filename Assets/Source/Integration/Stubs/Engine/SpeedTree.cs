namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpeedTree : Object/*
		native*/{
	public /*duplicatetransient native const */Object.Pointer SRH;
	public/*()*/ int RandomSeed;
	public/*()*/ float Sink;
	public/*(Lighting)*/ float LeafStaticShadowOpacity;
	public/*(Material)*/ MaterialInterface BranchMaterial;
	public/*(Material)*/ MaterialInterface FrondMaterial;
	public/*(Material)*/ MaterialInterface LeafMaterial;
	public/*(Material)*/ MaterialInterface BillboardMaterial;
	public/*(Wind)*/ float MaxBendAngle;
	public/*(Wind)*/ float BranchExponent;
	public/*(Wind)*/ float LeafExponent;
	public/*(Wind)*/ float Response;
	public/*(Wind)*/ float ResponseLimiter;
	public/*(Wind)*/ float Gusting_MinStrength;
	public/*(Wind)*/ float Gusting_MaxStrength;
	public/*(Wind)*/ float Gusting_Frequency;
	public/*(Wind)*/ float Gusting_MinDuration;
	public/*(Wind)*/ float Gusting_MaxDuration;
	public/*(Wind)*/ float BranchHorizontal_LowWindAngle;
	public/*(Wind)*/ float BranchHorizontal_LowWindSpeed;
	public/*(Wind)*/ float BranchHorizontal_HighWindAngle;
	public/*(Wind)*/ float BranchHorizontal_HighWindSpeed;
	public/*(Wind)*/ float BranchVertical_LowWindAngle;
	public/*(Wind)*/ float BranchVertical_LowWindSpeed;
	public/*(Wind)*/ float BranchVertical_HighWindAngle;
	public/*(Wind)*/ float BranchVertical_HighWindSpeed;
	public/*(Wind)*/ float LeafRocking_LowWindAngle;
	public/*(Wind)*/ float LeafRocking_LowWindSpeed;
	public/*(Wind)*/ float LeafRocking_HighWindAngle;
	public/*(Wind)*/ float LeafRocking_HighWindSpeed;
	public/*(Wind)*/ float LeafRustling_LowWindAngle;
	public/*(Wind)*/ float LeafRustling_LowWindSpeed;
	public/*(Wind)*/ float LeafRustling_HighWindAngle;
	public/*(Wind)*/ float LeafRustling_HighWindSpeed;
	
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