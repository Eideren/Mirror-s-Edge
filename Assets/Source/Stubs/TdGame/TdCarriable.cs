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
	
	}
	
	public virtual /*function */void RespawnActorProxy(Object.Vector InLocation)
	{
	
	}
	
	public virtual /*function */void OnTouched(TdPlayerPawn InCarrierPawn)
	{
	
	}
	
	public virtual /*function */void OnResurrected()
	{
	
	}
	
	public virtual /*function */bool IsCarried()
	{
	
		return default;
	}
	
	public virtual /*function */void OnTouchedGround()
	{
	
	}
	
	public virtual /*function */void HintUnreachable()
	{
	
	}
	
	public virtual /*function */Object.Vector GetLocation()
	{
	
		return default;
	}
	
	public virtual /*function */Pawn GetCarryingPawn()
	{
	
		return default;
	}
	
	public virtual /*function */Actor GetCarriedActor()
	{
	
		return default;
	}
	
	public virtual /*function */bool OnCarried(TdPlayerPawn InCarrierPawn)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnDropped(TdPlayerPawn InCarrierPawn, Object.Vector StartLocation, Object.Rotator StartRotation, Object.Vector WithForce)
	{
	
		return default;
	}
	
}
}