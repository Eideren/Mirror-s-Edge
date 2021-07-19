namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_Handle : ActorComponent/*
		native
		collapsecategories
		hidecategories(Object)*/{
	[export, editinline] public PrimitiveComponent GrabbedComponent;
	public name GrabbedBoneName;
	[native, Const, transient] public int SceneIndex;
	[native, Const, transient] public bool bInHardware;
	[native, Const, transient] public bool bRotationConstrained;
	public bool bInterpolating;
	[native, Const, transient] public Object.Pointer HandleData;
	[native, Const, transient] public Object.Pointer KinActorData;
	[Category] public float LinearDamping;
	[Category] public float LinearStiffness;
	[Category] public float AngularDamping;
	[Category] public float AngularStiffness;
	public Object.Vector Destination;
	public Object.Vector StepSize;
	public Object.Vector Location;
	
	// Export URB_Handle::execGrabComponent(FFrame&, void* const)
	public virtual /*native function */void GrabComponent(PrimitiveComponent Component, name InBoneName, Object.Vector GrabLocation, bool bConstrainRotation)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_Handle::execReleaseComponent(FFrame&, void* const)
	public virtual /*native function */void ReleaseComponent()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_Handle::execSetLocation(FFrame&, void* const)
	public virtual /*native function */void SetLocation(Object.Vector NewLocation)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_Handle::execSetSmoothLocation(FFrame&, void* const)
	public virtual /*native function */void SetSmoothLocation(Object.Vector NewLocation, float MoveTime)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_Handle::execUpdateSmoothLocation(FFrame&, void* const)
	public virtual /*native function */void UpdateSmoothLocation(/*const */ref Object.Vector NewLocation)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_Handle::execSetOrientation(FFrame&, void* const)
	public virtual /*native function */void SetOrientation(Object.Quat NewOrientation)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export URB_Handle::execGetOrientation(FFrame&, void* const)
	public virtual /*native function */Object.Quat GetOrientation()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public RB_Handle()
	{
		// Object Offset:0x003ADFD1
		LinearDamping = 100.0f;
		LinearStiffness = 1300.0f;
		AngularDamping = 200.0f;
		AngularStiffness = 1000.0f;
		TickGroup = Object.ETickingGroup.TG_PreAsyncWork;
	}
}
}