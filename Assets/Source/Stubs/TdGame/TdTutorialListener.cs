namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface TdTutorialListener : Interface/*
		abstract*/{
	public /*function */void RegisterAiController(TdAIController AIController);
	
	public /*function */void OnPlayerSetMove(TdPawn.EMovement NewMove, TdPlayerPawn Pawn);
	
	public /*function */void OnTutorialEvent(int TutorialEvent, TdPawn Pawn);
	
	public /*function */bool CanAttack();
	
	public /*function */bool ValidAttack(Core.ClassT<DamageType> AttackType);
	
	public /*function */void OnAttackEvent(Core.ClassT<DamageType> AttackType, TdPawn Pawn);
	
	public /*function */void OnAiKismetEvent(int EventIdentifier);
	
	public /*function */int GetActiveMovementChallenge();
	
}
}