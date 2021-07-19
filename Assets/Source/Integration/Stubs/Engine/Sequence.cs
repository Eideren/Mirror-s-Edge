namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Sequence : SequenceOp/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */ActivateOp
	{
		public SequenceOp ActivatorOp;
		public SequenceOp Op;
		public int InputIdx;
		public float RemainingDelay;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003DF355
	//		ActivatorOp = default;
	//		Op = default;
	//		InputIdx = 0;
	//		RemainingDelay = 0.0f;
	//	}
	};
	
	[Const] public Object.Pointer LogFile;
	[Const, export] public array</*export */SequenceObject> SequenceObjects;
	[Const] public array<SequenceOp> ActiveSequenceOps;
	[Const, transient] public array<Sequence> NestedSequences;
	[Const] public array<SequenceEvent> UnregisteredEvents;
	[Const] public array<Sequence.ActivateOp> DelayedActivatedOps;
	[Category] public/*private*/ bool bEnabled;
	public int DefaultViewX;
	public int DefaultViewY;
	public float DefaultViewZoom;
	
	// Export USequence::execFindSeqObjectsByClass(FFrame&, void* const)
	public virtual /*native final function */void FindSeqObjectsByClass(Core.ClassT<SequenceObject> DesiredClass, bool bRecursive, ref array<SequenceObject> OutputObjects)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*function */void Reset()
	{
		// stub
	}
	
	// Export USequence::execSetEnabled(FFrame&, void* const)
	public virtual /*native final function */void SetEnabled(bool bInEnabled)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public Sequence()
	{
		// Object Offset:0x003DF667
		bEnabled = true;
		DefaultViewZoom = 1.0f;
		InputLinks = default;
		OutputLinks = default;
		ObjName = "Sequence";
	}
}
}