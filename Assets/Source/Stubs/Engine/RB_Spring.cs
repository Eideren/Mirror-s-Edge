namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_Spring : ActorComponent/*
		native*/{
	public /*const export editinline */PrimitiveComponent Component1;
	public /*const */name BoneName1;
	public /*const export editinline */PrimitiveComponent Component2;
	public /*const */name BoneName2;
	public /*native const */int SceneIndex;
	public /*native const */bool bInHardware;
	public/*()*/ bool bEnableForceMassRatio;
	public /*native const */Object.Pointer SpringData;
	public /*native const */float TimeSinceActivation;
	public /*const */float MinBodyMass;
	public/*()*/ float SpringSaturateDist;
	public/*()*/ float SpringMaxForce;
	public/*()*/ float MaxForceMassRatio;
	public/*()*/ Object.InterpCurveFloat SpringMaxForceTimeScale;
	public/*()*/ float DampSaturateVel;
	public/*()*/ float DampMaxForce;
	
	// Export URB_Spring::execSetComponents(FFrame&, void* const)
	public virtual /*native function */void SetComponents(PrimitiveComponent InComponent1, name InBoneName1, Object.Vector Position1, PrimitiveComponent InComponent2, name InBoneName2, Object.Vector Position2)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_Spring::execClear(FFrame&, void* const)
	public virtual /*native function */void Clear()
	{
		 // #warning NATIVE FUNCTION !
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