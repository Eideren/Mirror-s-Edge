namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_Handle : ActorComponent/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public /*export editinline */PrimitiveComponent GrabbedComponent;
	public name GrabbedBoneName;
	public /*native const transient */int SceneIndex;
	public /*native const transient */bool bInHardware;
	public /*native const transient */bool bRotationConstrained;
	public bool bInterpolating;
	public /*native const transient */Object.Pointer HandleData;
	public /*native const transient */Object.Pointer KinActorData;
	public/*()*/ float LinearDamping;
	public/*()*/ float LinearStiffness;
	public/*()*/ float AngularDamping;
	public/*()*/ float AngularStiffness;
	public Object.Vector Destination;
	public Object.Vector StepSize;
	public Object.Vector Location;
	
	// Export URB_Handle::execGrabComponent(FFrame&, void* const)
	public virtual /*native function */void GrabComponent(PrimitiveComponent Component, name InBoneName, Object.Vector GrabLocation, bool bConstrainRotation)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_Handle::execReleaseComponent(FFrame&, void* const)
	public virtual /*native function */void ReleaseComponent()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_Handle::execSetLocation(FFrame&, void* const)
	public virtual /*native function */void SetLocation(Object.Vector NewLocation)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_Handle::execSetSmoothLocation(FFrame&, void* const)
	public virtual /*native function */void SetSmoothLocation(Object.Vector NewLocation, float MoveTime)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_Handle::execUpdateSmoothLocation(FFrame&, void* const)
	public virtual /*native function */void UpdateSmoothLocation(/*const */ref Object.Vector NewLocation)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_Handle::execSetOrientation(FFrame&, void* const)
	public virtual /*native function */void SetOrientation(Object.Quat NewOrientation)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export URB_Handle::execGetOrientation(FFrame&, void* const)
	public virtual /*native function */Object.Quat GetOrientation()
	{
		#warning NATIVE FUNCTION !
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