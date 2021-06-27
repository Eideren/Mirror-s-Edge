namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface UIEventContainer : Interface/*
		abstract
		native*/{
	// Export UUIEventContainer::execGetUIEvents(FFrame&, void* const)
	public /*native final function */void GetUIEvents(ref array<UIEvent> out_Events, /*optional */Core.ClassT<UIEvent>? _LimitClass = default);
	
	// Export UUIEventContainer::execAddSequenceObject(FFrame&, void* const)
	public /*native final function */bool AddSequenceObject(SequenceObject NewObj, /*optional */bool? _bRecurse = default);
	
	// Export UUIEventContainer::execRemoveSequenceObject(FFrame&, void* const)
	public /*native final function */void RemoveSequenceObject(SequenceObject ObjectToRemove);
	
	// Export UUIEventContainer::execRemoveSequenceObjects(FFrame&, void* const)
	public /*native final function */void RemoveSequenceObjects(array<SequenceObject> ObjectsToRemove);
	
}
}