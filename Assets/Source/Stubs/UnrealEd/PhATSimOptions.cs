namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PhATSimOptions : Object/*
		native
		config(Editor)
		hidecategories(Object)*/{
	public/*(Anim)*/ /*transient */AnimSet PreviewAnimSet;
	public/*(Anim)*/ /*transient */float PhysicsBlend;
	public/*(Anim)*/ /*transient */bool bBlendOnPoke;
	public/*(Simulation)*/ /*config */bool bDrawContacts;
	public/*(Advanced)*/ /*config */bool bPromptOnBoneDelete;
	public/*(Advanced)*/ /*config */bool bShowConstraintsAsPoints;
	public/*(Advanced)*/ /*config */bool bShowNamesInHierarchy;
	public/*(Anim)*/ /*config */float PokePauseTime;
	public/*(Anim)*/ /*config */float PokeBlendTime;
	public/*(Anim)*/ /*transient */float AngularSpringScale;
	public/*(Anim)*/ /*transient */float AngularDampingScale;
	public/*(Simulation)*/ /*config */float SimSpeed;
	public/*(Simulation)*/ /*config */float FloorGap;
	public/*(Simulation)*/ /*config */float GravScale;
	public/*(MouseSpring)*/ /*config */float HandleLinearDamping;
	public/*(MouseSpring)*/ /*config */float HandleLinearStiffness;
	public/*(MouseSpring)*/ /*config */float HandleAngularDamping;
	public/*(MouseSpring)*/ /*config */float HandleAngularStiffness;
	public/*(Poking)*/ /*config */float PokeStrength;
	public/*(Lighting)*/ /*config */float SkyBrightness;
	public/*(Lighting)*/ /*config */float Brightness;
	public/*(Snap)*/ /*config */float AngularSnap;
	public/*(Snap)*/ /*config */float LinearSnap;
	
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