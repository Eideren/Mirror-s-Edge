namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCarriable : Object, 
		TdCarriableMediator{
	public partial struct TdCarriableAttachInfo
	{
		public name Bone;
		public Object.Vector Offset;
		public Object.Rotator Rotation;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0052F378
	//		Bone = (name)"None";
	//		Offset = new Vector
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
	
	public /*protected transient */TdCarriableActorProxy ActorProxy;
	public /*private transient */TdCarriableListener Listener;
	public /*private transient */TdPlayerPawn CarrierPawn;
	public /*private */TdCarriable.TdCarriableAttachInfo AttachInfo;
	public /*private */TdBagGRI MyGRI;
	public /*private */float UnreachableTimeout;
	
	public virtual /*function */void Initialize(TdCarriableListener InListener, TdBagGRI InGRI)
	{
		// stub
	}
	
	public virtual /*function */void RespawnActorProxy(Object.Vector InLocation)
	{
		// stub
	}
	
	public virtual /*function */void OnTouched(TdPlayerPawn InCarrierPawn)
	{
		// stub
	}
	
	public virtual /*function */void OnResurrected()
	{
		// stub
	}
	
	public virtual /*function */bool IsCarried()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnTouchedGround()
	{
		// stub
	}
	
	public virtual /*function */void HintUnreachable()
	{
		// stub
	}
	
	public virtual /*function */Object.Vector GetLocation()
	{
		// stub
		return default;
	}
	
	public virtual /*function */Pawn GetCarryingPawn()
	{
		// stub
		return default;
	}
	
	public virtual /*function */Actor GetCarriedActor()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnCarried(TdPlayerPawn InCarrierPawn)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnDropped(TdPlayerPawn InCarrierPawn, Object.Vector StartLocation, Object.Rotator StartRotation, Object.Vector WithForce)
	{
		// stub
		return default;
	}
	
}
}