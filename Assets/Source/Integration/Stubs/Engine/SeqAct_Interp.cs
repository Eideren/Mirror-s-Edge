namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_Interp : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public partial struct /*native export */SavedTransform
	{
		public Object.Vector Location;
		public Object.Rotator Rotation;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003C4B74
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Rotation = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//	}
	};
	
	[noimport, editoronly, native, Const, transient] public/*private*/ /*map<0,0>*/map<object, object> SavedActorTransforms;
	[Category] public float PlayRate;
	public float Position;
	[Category] public float ForceStartPosition;
	public bool bIsPlaying;
	public bool bPaused;
	[transient] public bool bIsBeingEdited;
	[Category] public bool bLooping;
	[Category] public bool bRewindOnPlay;
	[Category] public bool bNoResetOnRewind;
	[Category] public bool bRewindIfAlreadyPlaying;
	public bool bReversePlayback;
	[Category] public bool bInterpForPathBuilding;
	[Category] public bool bForceStartPos;
	[Category] public bool bClientSideOnly;
	[Category] public bool bSkipUpdateIfNotVisible;
	[Category] public bool bIsSkippable;
	[Category] public array<CoverLink> LinkedCover;
	[export] public InterpData InterpData;
	public array<InterpGroupInst> GroupInst;
	[Const] public Core.ClassT<MatineeActor> ReplicatedActorClass;
	[Const] public MatineeActor ReplicatedActor;
	
	// Export USeqAct_Interp::execSetPosition(FFrame&, void* const)
	public virtual /*native final function */void SetPosition(float NewPosition, /*optional */bool? _bJump = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USeqAct_Interp::execStop(FFrame&, void* const)
	public virtual /*native final function */void Stop()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USeqAct_Interp::execAddPlayerToDirectorTracks(FFrame&, void* const)
	public virtual /*native final function */void AddPlayerToDirectorTracks(PlayerController PC)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*function */void Reset()
	{
		// stub
	}
	
	public SeqAct_Interp()
	{
		// Object Offset:0x003C51A3
		PlayRate = 1.0f;
		ReplicatedActorClass = ClassT<MatineeActor>()/*Ref Class'MatineeActor'*/;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Play",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Reverse",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Stop",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Pause",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Change Dir",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Completed",
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
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<InterpData>()/*Ref Class'InterpData'*/,
				LinkedVariables = default,
				LinkDesc = "Data",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Matinee";
	}
}
}