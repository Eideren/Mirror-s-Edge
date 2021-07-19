namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_Spring : ActorComponent/*
		native*/{
	[Const, export, editinline] public PrimitiveComponent Component1;
	[Const] public name BoneName1;
	[Const, export, editinline] public PrimitiveComponent Component2;
	[Const] public name BoneName2;
	[native, Const] public int SceneIndex;
	[native, Const] public bool bInHardware;
	[Category] public bool bEnableForceMassRatio;
	[native, Const] public Object.Pointer SpringData;
	[native, Const] public float TimeSinceActivation;
	[Const] public float MinBodyMass;
	[Category] public float SpringSaturateDist;
	[Category] public float SpringMaxForce;
	[Category] public float MaxForceMassRatio;
	[Category] public Object.InterpCurveFloat SpringMaxForceTimeScale;
	[Category] public float DampSaturateVel;
	[Category] public float DampMaxForce;
	
	// Export URB_Spring::execSetComponents(FFrame&, void* const)
	public virtual /*native function */void SetComponents(PrimitiveComponent InComponent1, name InBoneName1, Object.Vector Position1, PrimitiveComponent InComponent2, name InBoneName2, Object.Vector Position2)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_Spring::execClear(FFrame&, void* const)
	public virtual /*native function */void Clear()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public RB_Spring()
	{
		// Object Offset:0x003AFD4F
		SpringMaxForceTimeScale = new Object.InterpCurveFloat
		{
			Points = new array<Object.InterpCurvePointFloat>
			{
				new Object.InterpCurvePointFloat
				{
					InVal = 0.0f,
					OutVal = 1.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
			},
			InterpMethod = Object.EInterpMethodType.IMT_UseFixedTangentEval,
		};
		TickGroup = Object.ETickingGroup.TG_PreAsyncWork;
	}
}
}