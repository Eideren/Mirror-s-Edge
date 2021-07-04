namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_Latent : SequenceAction/*
		abstract
		native
		hidecategories(Object)*/{
	public array<Actor> LatentActors;
	public bool bAborted;
	
	// Export USeqAct_Latent::execAbortFor(FFrame&, void* const)
	public virtual /*native function */void AbortFor(Actor latentActor)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*event */bool Update(float DeltaTime)
	{
		// stub
		return default;
	}
	
	public SeqAct_Latent()
	{
		// Object Offset:0x003B5B42
		bLatentExecution = true;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Finished",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Aborted",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjName = "Undefined Latent";
		ObjColor = new Color
		{
			R=128,
			G=128,
			B=0,
			A=255
		};
	}
}
}