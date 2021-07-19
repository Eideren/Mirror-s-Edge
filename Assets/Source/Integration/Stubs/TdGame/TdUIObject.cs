namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIObject : UIObject/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public bool requiresTick;
	[Category("Widget")] [transient] public bool bShowBounds;
	public array<TdUIObject> TickStack;
	
	// Export UTdUIObject::execGetTdPlayerController(FFrame&, void* const)
	public virtual /*native function */TdPlayerController GetTdPlayerController(/*optional */int? _Index = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIObject::execGetTdPawn(FFrame&, void* const)
	public virtual /*native function */TdPawn GetTdPawn()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIObject::execGetPRI(FFrame&, void* const)
	public virtual /*native function */TdPlayerReplicationInfo GetPRI()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIObject::execGetWorldInfo(FFrame&, void* const)
	public virtual /*native function */WorldInfo GetWorldInfo()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*event */void Initialized()
	{
		// stub
	}
	
	public virtual /*event */void AddChildToTickStack(TdUIObject ChildToAdd)
	{
		// stub
	}
	
	public virtual /*event */void RemoveChildFromTickStack(TdUIObject ChildToRemove)
	{
		// stub
	}
	
	public override /*event */void AddedChild(UIScreenObject WidgetOwner, UIObject NewChild)
	{
		// stub
	}
	
	public override /*event */void RemovedChild(UIScreenObject WidgetOwner, UIObject OldChild, /*optional */array<UIObject>? _ExclusionSet = default)
	{
		// stub
	}
	
	public TdUIObject()
	{
		var Default__TdUIObject_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIObject.WidgetEventComponent' */;
		// Object Offset:0x005764AB
		EventProvider = Default__TdUIObject_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIObject.WidgetEventComponent'*/;
	}
}
}