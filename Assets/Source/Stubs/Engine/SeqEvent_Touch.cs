namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_Touch : SequenceEvent/*
		native
		hidecategories(Object)*/{
	public/*(TouchTypes)*/ array< Core.ClassT<Actor> > ClassProximityTypes;
	public/*(TouchTypes)*/ array< Core.ClassT<Actor> > IgnoredClassProximityTypes;
	public/*()*/ bool bForceOverlapping;
	public/*()*/ bool bUseInstigator;
	public/*()*/ bool bAllowDeadPawns;
	public array<Actor> TouchedList;
	
	// Export USeqEvent_Touch::execCheckTouchActivate(FFrame&, void* const)
	public virtual /*native final function */bool CheckTouchActivate(Actor InOriginator, Actor InInstigator, /*optional */bool? _bTest = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USeqEvent_Touch::execCheckUnTouchActivate(FFrame&, void* const)
	public virtual /*native final function */bool CheckUnTouchActivate(Actor InOriginator, Actor InInstigator, /*optional */bool? _bTest = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */void Toggled()
	{
	
	}
	
	public virtual /*function */void NotifyTouchingPawnDied(Pawn P)
	{
	
	}
	
	public SeqEvent_Touch()
	{
		// Object Offset:0x003DE806
		ClassProximityTypes = new array< Core.ClassT<Actor> >
		{
			ClassT<Pawn>(),
		};
		bForceOverlapping = true;
		ReTriggerDelay = 0.10f;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Touched",
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
				LinkDesc = "UnTouched",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjName = "Touch";
		ObjCategory = "Physics";
	}
}
}