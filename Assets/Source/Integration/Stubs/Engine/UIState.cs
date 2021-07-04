// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIState : UIRoot, 
		UIEventContainer/*
		abstract
		native
		editinlinenew
		hidecategories(Object,UIRoot)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIEventContainer;
	public /*noimport export editinline */UIStateSequence StateSequence;
	public array<UIRoot.InputKeyAction> StateInputActions;
	public array<UIRoot.InputKeyAction> DisabledInputActions;
	public/*()*/ name MouseCursorName;
	public /*transient */byte PlayerIndexMask;
	public /*const transient */byte StackPriority;
	
	public virtual /*event */bool IsWidgetClassSupported(Core.ClassT<UIScreenObject> WidgetClass)
	{
	
		return default;
	}
	
	// Export UUIState::execIsActiveForPlayer(FFrame&, void* const)
	public virtual /*native final function */bool IsActiveForPlayer(int PlayerIndex)
	{
		 NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*event */bool ActivateState(UIScreenObject Target, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*event */bool DeactivateState(UIScreenObject Target, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*event */void OnActivate(UIScreenObject Target, int PlayerIndex, bool bPushedState)
	{
	
	}
	
	public virtual /*event */void OnDeactivate(UIScreenObject Target, int PlayerIndex, bool bPoppedState)
	{
	
	}
	
	public virtual /*event */bool IsStateAllowed(UIScreenObject Target, UIState NewState, int PlayerIndex)
	{
	
		return default;
	}
	
	// Export UUIState::execGetUIEvents(FFrame&, void* const)
	public virtual /*native final function */void GetUIEvents(ref array<UIEvent> out_Events, /*optional */Core.ClassT<UIEvent> _LimitClass = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UUIState::execAddSequenceObject(FFrame&, void* const)
	public virtual /*native final function */bool AddSequenceObject(SequenceObject NewObj, /*optional */bool? _bRecurse = default)
	{
		 NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UUIState::execRemoveSequenceObject(FFrame&, void* const)
	public virtual /*native final function */void RemoveSequenceObject(SequenceObject ObjectToRemove)
	{
		 NativeMarkers.MarkUnimplemented();
	}



	public void RemoveSequenceObjects( array<SequenceObject> ObjectsToRemove )
	{
		// INTERFACE FUNCTION, WAS NOT PART OF THE DECOMPILATION PROCESS
	}



	// Export UUIState::execRemoveSequenceObjects(FFrame&, void* const)
	public virtual /*native final function */void RemoveSequenceObjects(/*const */ref array<SequenceObject> ObjectsToRemove)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	public UIState()
	{
		// Object Offset:0x004518E9
		MouseCursorName = (name)"Arrow";
	}
}
}