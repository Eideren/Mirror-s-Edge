namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PhATSimOptions : Object/*
		native
		config(Editor)
		hidecategories(Object)*/{
	[Category("Anim")] [transient] public AnimSet PreviewAnimSet;
	[Category("Anim")] [transient] public float PhysicsBlend;
	[Category("Anim")] [transient] public bool bBlendOnPoke;
	[Category("Simulation")] [config] public bool bDrawContacts;
	[Category("Advanced")] [config] public bool bPromptOnBoneDelete;
	[Category("Advanced")] [config] public bool bShowConstraintsAsPoints;
	[Category("Advanced")] [config] public bool bShowNamesInHierarchy;
	[Category("Anim")] [config] public float PokePauseTime;
	[Category("Anim")] [config] public float PokeBlendTime;
	[Category("Anim")] [transient] public float AngularSpringScale;
	[Category("Anim")] [transient] public float AngularDampingScale;
	[Category("Simulation")] [config] public float SimSpeed;
	[Category("Simulation")] [config] public float FloorGap;
	[Category("Simulation")] [config] public float GravScale;
	[Category("MouseSpring")] [config] public float HandleLinearDamping;
	[Category("MouseSpring")] [config] public float HandleLinearStiffness;
	[Category("MouseSpring")] [config] public float HandleAngularDamping;
	[Category("MouseSpring")] [config] public float HandleAngularStiffness;
	[Category("Poking")] [config] public float PokeStrength;
	[Category("Lighting")] [config] public float SkyBrightness;
	[Category("Lighting")] [config] public float Brightness;
	[Category("Snap")] [config] public float AngularSnap;
	[Category("Snap")] [config] public float LinearSnap;
	
	public PhATSimOptions()
	{
		// Object Offset:0x0002769F
		PhysicsBlend = 1.0f;
		bPromptOnBoneDelete = true;
		bShowNamesInHierarchy = true;
		PokePauseTime = 0.50f;
		PokeBlendTime = 0.50f;
		AngularSpringScale = 1.0f;
		AngularDampingScale = 1.0f;
		SimSpeed = 1.0f;
		FloorGap = 25.0f;
		GravScale = 1.0f;
		PokeStrength = 100.0f;
		SkyBrightness = 0.250f;
		Brightness = 1.0f;
		AngularSnap = 15.0f;
		LinearSnap = 2.0f;
	}
}
}