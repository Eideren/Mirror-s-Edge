namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UISequence : Sequence, 
		UIEventContainer/*
		native
		hidecategories(Object)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIEventContainer;
	public /*init private noimport const transient */array</*init */UIEvent> UIEvents;
	
	// Export UUISequence::execGetOwner(FFrame&, void* const)
	public virtual /*native final function */UIScreenObject GetOwner()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISequence::execGetUIEvents(FFrame&, void* const)
	public virtual /*native final function */void GetUIEvents(ref array<UIEvent> out_Events, /*optional */Core.ClassT<UIEvent>? _LimitClass = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUISequence::execAddSequenceObject(FFrame&, void* const)
	public virtual /*native final function */bool AddSequenceObject(SequenceObject NewObj, /*optional */bool? _bRecurse = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISequence::execRemoveSequenceObject(FFrame&, void* const)
	public virtual /*native final function */void RemoveSequenceObject(SequenceObject ObjectToRemove)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUISequence::execRemoveSequenceObjects(FFrame&, void* const)
	public virtual /*native final function */void RemoveSequenceObjects(/*const */ref array<SequenceObject> ObjectsToRemove)
	{
		#warning NATIVE FUNCTION !
	}
	
	public UISequence()
	{
		// Object Offset:0x0044FB3D
		ObjPosX = 904;
		ObjPosY = 64;
		ObjName = "Widget Events";
	}
}
}