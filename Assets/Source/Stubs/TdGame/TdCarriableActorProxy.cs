namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface TdCarriableActorProxy : Interface/*
		abstract*/{
	public /*function */void Initialize(TdCarriableMediator InMediator);
	
	public /*function */void Finalize();
	
	public /*function */Actor GetCarriableActor();
	
	public /*function */void EquipInvetoryPlaceHolderFor(Pawn P);
	
	public /*function */void SetUnreachableTimer(float TimeToRespawn);
	
	public /*function */void ClearUnreachableTimer();
	
	public /*function */void WakeRigidBody();
	
	public /*function */void SetCarried(Pawn Carrier, name Bone, Object.Rotator Rotation, Object.Vector Offset);
	
	public /*function */void SetDropped(Pawn CarrierPawn, Object.Vector StartLocation, Object.Rotator StartRotation, Object.Vector WithForce);
	
}
}