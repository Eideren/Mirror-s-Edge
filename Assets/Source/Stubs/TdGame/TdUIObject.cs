namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIObject : UIObject/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public bool requiresTick;
	public/*(Widget)*/ /*transient */bool bShowBounds;
	public array<TdUIObject> TickStack;
	
	// Export UTdUIObject::execGetTdPlayerController(FFrame&, void* const)
	public virtual /*native function */TdPlayerController GetTdPlayerController(/*optional */int? _Index = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIObject::execGetTdPawn(FFrame&, void* const)
	public virtual /*native function */TdPawn GetTdPawn()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIObject::execGetPRI(FFrame&, void* const)
	public virtual /*native function */TdPlayerReplicationInfo GetPRI()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIObject::execGetWorldInfo(FFrame&, void* const)
	public virtual /*native function */WorldInfo GetWorldInfo()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */void Initialized()
	{
	
	}
	
	public virtual /*event */void AddChildToTickStack(TdUIObject ChildToAdd)
	{
	
	}
	
	public virtual /*event */void RemoveChildFromTickStack(TdUIObject ChildToRemove)
	{
	
	}
	
	public override /*event */void AddedChild(UIScreenObject WidgetOwner, UIObject NewChild)
	{
	
	}
	
	public override /*event */void RemovedChild(UIScreenObject WidgetOwner, UIObject OldChild, /*optional */array<UIObject>? _ExclusionSet = default)
	{
	
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