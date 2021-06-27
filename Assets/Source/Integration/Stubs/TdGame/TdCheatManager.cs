namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCheatManager : CheatManager/* within TdPlayerController*/{
	public new TdPlayerController Outer => base.Outer as TdPlayerController;
	
	public Object.Vector P1;
	public Object.Vector P2;
	public Object.Vector oldPos;
	public TdAIController DebugController;
	public Pawn aPawn;
	public Object.Vector OldHitLocation;
	public Object.Vector StoredPosition;
	public bool bStefan;
	public bool bQA;
	public bool bShowTestAnimHud;
	public TdAITestScripts AITests;
	public float SlomoSpeed;
	public Object.Vector enemyPos;
	public TdPawn ActiveActor;
	
	public virtual /*function */void SetDebugControllers()
	{
		// stub
	}
	
	public virtual /*function */void InitAITestScripts()
	{
		// stub
	}
	
	public virtual /*exec function */void SuppressAI()
	{
		// stub
	}
	
	public virtual /*exec function */void Difficulty(int Level)
	{
		// stub
	}
	
	public virtual /*exec function */void Ammo()
	{
		// stub
	}
	
	public virtual /*exec function */void ToggleDifficultyLevel()
	{
		// stub
	}
	
	public virtual /*exec function */void SeeMe()
	{
		// stub
	}
	
	public virtual /*exec function */void Test()
	{
		// stub
	}
	
	public virtual /*exec function */void Run()
	{
		// stub
	}
	
	public virtual /*exec function */void DebugCover(bool bSelectClosestCover)
	{
		// stub
	}
	
	public virtual /*exec function */void ChangeCover(bool bSelectClosestCover)
	{
		// stub
	}
	
	public virtual /*exec function */void CoverGoToState(String iState)
	{
		// stub
	}
	
	public virtual /*exec function */void ToggleSlomo()
	{
		// stub
	}
	
	public virtual /*exec function */void PlayAnim(name AnimationName)
	{
		// stub
	}
	
	public virtual /*exec function */void hack1()
	{
		// stub
	}
	
	public virtual /*exec function */void hack2()
	{
		// stub
	}
	
	public virtual /*exec function */void Invisible()
	{
		// stub
	}
	
	public virtual /*exec function */void ToggleAIWalking()
	{
		// stub
	}
	
	public virtual /*exec function */void ToggleAIFocus()
	{
		// stub
	}
	
	public virtual /*exec function */void ToggleAICrouching()
	{
		// stub
	}
	
	public virtual /*exec function */void TestCovers()
	{
		// stub
	}
	
	public virtual /*exec function */void Idle()
	{
		// stub
	}
	
	public virtual /*exec function */void AIGotoState(name NewState, /*optional */bool? _onlyFirst = default)
	{
		// stub
	}
	
	public virtual /*exec function */void AIGod()
	{
		// stub
	}
	
	public virtual /*exec function */void SetGod()
	{
		// stub
	}
	
	public virtual /*exec function */void RemoveGod()
	{
		// stub
	}
	
	public override /*exec function */void God()
	{
		// stub
	}
	
	public virtual /*exec function */void Jesus()
	{
		// stub
	}
	
	public virtual /*exec function */void Stefan()
	{
		// stub
	}
	
	public virtual /*exec function */void QA()
	{
		// stub
	}
	
	public virtual /*exec function */void DebugTrace(/*optional */int? _Type = default)
	{
		// stub
	}
	
	public virtual /*exec function */void DropMe()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowClosest()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowThisOne()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowAll()
	{
		// stub
	}
	
	public virtual /*exec function */void pp()
	{
		// stub
	}
	
	public virtual /*exec function */void dc()
	{
		// stub
	}
	
	public virtual /*exec function */void PS()
	{
		// stub
	}
	
	public virtual /*exec function */void pe()
	{
		// stub
	}
	
	public virtual /*exec function */void AiRootRotation()
	{
		// stub
	}
	
	public virtual /*exec function */void GoHere()
	{
		// stub
	}
	
	public virtual /*exec function */void GoAngle(int Angle, float Distance)
	{
		// stub
	}
	
	public virtual /*exec function */void WalkHere()
	{
		// stub
	}
	
	public virtual /*exec function */void GoHereAll()
	{
		// stub
	}
	
	public virtual /*exec function */void MoveStraightHere()
	{
		// stub
	}
	
	public virtual /*exec function */void RunStraightHere()
	{
		// stub
	}
	
	public virtual /*exec function */void RunHere()
	{
		// stub
	}
	
	public virtual /*exec function */void HeadFocus(bool flag)
	{
		// stub
	}
	
	public virtual /*exec function */void SetHeadFocusOnPlayer()
	{
		// stub
	}
	
	public virtual /*exec function */void MoveAIHere()
	{
		// stub
	}
	
	public virtual /*exec function */void sp()
	{
		// stub
	}
	
	public virtual /*exec function */void mp()
	{
		// stub
	}
	
	public virtual /*exec function */void DebugStop()
	{
		// stub
	}
	
	public virtual /*exec function */void UpdatePath()
	{
		// stub
	}
	
	public virtual /*exec function */void ClearScreenLog()
	{
		// stub
	}
	
	public virtual /*exec function */void ScreenLogFilter(name F)
	{
		// stub
	}
	
	public virtual /*exec function */void AILogFilter(name F)
	{
		// stub
	}
	
	public virtual /*exec function */void TestReachable()
	{
		// stub
	}
	
	public virtual /*exec function */void Roll()
	{
		// stub
	}
	
	public virtual /*exec function */void SpawnAt(Object.Vector pos)
	{
		// stub
	}
	
	public virtual /*exec function */void Training()
	{
		// stub
	}
	
	public virtual /*exec function */void Atrium()
	{
		// stub
	}
	
	public virtual /*exec function */void subway()
	{
		// stub
	}
	
	public virtual /*exec function */void Platform()
	{
		// stub
	}
	
	public virtual /*exec function */void Helicopter()
	{
		// stub
	}
	
	public virtual /*exec function */void rb()
	{
		// stub
	}
	
	public virtual /*exec function */void Boss(int stage)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowAIDebug()
	{
		// stub
	}
	
	public virtual /*exec function */void TdToggleSlomo()
	{
		// stub
	}
	
	public virtual /*exec function */void FootPlacement(bool bEnable)
	{
		// stub
	}
	
	public virtual /*exec function */void AlignFootPosition(bool bEnable)
	{
		// stub
	}
	
	public virtual /*exec function */void AlignFootRotation(bool bEnable)
	{
		// stub
	}
	
	public virtual /*exec function */void InterpolateFootPosition(bool bEnable)
	{
		// stub
	}
	
	public virtual /*exec function */void FootPositionInterpolationSpeed(float Speed)
	{
		// stub
	}
	
	public virtual /*exec function */void InterpolateFootRotation(bool bEnable)
	{
		// stub
	}
	
	public virtual /*exec function */void GiveStarRating(int NumStars)
	{
		// stub
	}
	
	public virtual /*exec function */void IsLevelUnlocked(int Index)
	{
		// stub
	}
	
	public virtual /*exec function */void IsBagFound(int Index)
	{
		// stub
	}
	
	public virtual /*exec function */void SetGameProgress(String Map, String Checkpoint)
	{
		// stub
	}
	
	public virtual /*exec function */void UnlockTT(int Index)
	{
		// stub
	}
	
	public virtual /*exec function */void LockTT(int Index)
	{
		// stub
	}
	
	public virtual /*exec function */void IsAllTTStretchesUnlocked()
	{
		// stub
	}
	
	public virtual /*exec function */void LockAllTT()
	{
		// stub
	}
	
	public virtual /*exec function */void IsTTUnlocked(int Index)
	{
		// stub
	}
	
	public virtual /*exec function */void UnLockAllTT()
	{
		// stub
	}
	
	public virtual /*exec function */void ActivateSaturation()
	{
		// stub
	}
	
	public virtual /*exec function */void DeActivateSaturation()
	{
		// stub
	}
	
	public virtual /*exec function */void FindAllBags()
	{
		// stub
	}
	
	public virtual /*exec function */void FindBag(int Bag)
	{
		// stub
	}
	
	public virtual /*exec function */void UncontrolledFalling(int On)
	{
		// stub
	}
	
	public virtual /*exec function */void UncontrolledFallingClamp(float Clamp)
	{
		// stub
	}
	
	public virtual /*exec function */void Flashbang(/*optional */int? _dmg = default)
	{
		// stub
	}
	
	public virtual /*exec function */void Taser(/*optional */int? _dmg = default)
	{
		// stub
	}
	
	public virtual /*exec function */void Bullet(/*optional */int? _dmg = default)
	{
		// stub
	}
	
	public virtual /*exec function */void DebugMixGroups()
	{
		// stub
	}
	
	public virtual /*exec function */void DebugVelocitySounds()
	{
		// stub
	}
	
	public virtual /*exec function */void DebugReverbVolumes()
	{
		// stub
	}
	
	public virtual /*exec function */void DumpAudioAllocations()
	{
		// stub
	}
	
	public virtual /*exec function */void UnlockAllLevels()
	{
		// stub
	}
	
	public virtual /*exec function */void LockAllLevels()
	{
		// stub
	}
	
	public virtual /*exec function */void LockLevel(int Index)
	{
		// stub
	}
	
	public virtual /*exec function */void UnlockLevel(int Index)
	{
		// stub
	}
	
	public virtual /*exec function */void CompleteLR(float Time)
	{
		// stub
	}
	
	public virtual /*exec function */void CompleteLevel(int Level)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowScenes()
	{
		// stub
	}
	
	public virtual /*exec function */void CP()
	{
		// stub
	}
	
	public virtual /*exec function */void WriteTTTime(int Stretch, float Time, int NumIntermediateTimes)
	{
		// stub
	}
	
	public virtual /*exec function */void ReadTTTime(int Stretch)
	{
		// stub
	}
	
	public virtual /*exec function */void DefaultProfile()
	{
		// stub
	}
	
	public virtual /*exec function */void SaveProfile()
	{
		// stub
	}
	
	public virtual /*exec function */void KillAllButOne()
	{
		// stub
	}
	
	public virtual /*exec function */void KillAllAI()
	{
		// stub
	}
	
	public virtual /*exec function */void KillClosest()
	{
		// stub
	}
	
	public virtual /*private final function */TdAIController GetClosestAI()
	{
		// stub
		return default;
	}
	
	public virtual /*exec function */void DebugHalt()
	{
		// stub
	}
	
	public virtual /*exec function */void DebugLineOfSight()
	{
		// stub
	}
	
	public virtual /*exec function */void PrintLog(String iString)
	{
		// stub
	}
	
	public virtual /*exec function */void AICrouch()
	{
		// stub
	}
	
	public virtual /*exec function */void SetMeleeType(String mt)
	{
		// stub
	}
	
	public virtual /*exec function */void CoverCPOL()
	{
		// stub
	}
	
	public virtual /*exec function */void CoverDetour()
	{
		// stub
	}
	
	public virtual /*exec function */void CoverPath()
	{
		// stub
	}
	
	public virtual /*exec function */void ResetAI()
	{
		// stub
	}
	
	public virtual /*exec function */void RenameNodes()
	{
		// stub
	}
	
	public virtual /*exec function */void HeliMove(String navpointName)
	{
		// stub
	}
	
	public virtual /*exec function */void SetHeliSpeed(int I)
	{
		// stub
	}
	
	public virtual /*exec function */void Eyelids()
	{
		// stub
	}
	
	public virtual /*exec function */void DebugFalling()
	{
		// stub
	}
	
	public virtual /*exec function */void SetAimState(TdAIAnimationController.EAimState iAimState)
	{
		// stub
	}
	
	public virtual /*exec function */void AiHoldFire(bool bHoldFire)
	{
		// stub
	}
	
	public virtual /*exec function */void InvertMouseCheat()
	{
		// stub
	}
	
	public virtual /*exec function */void ChaseAI()
	{
		// stub
	}
	
	public TdCheatManager()
	{
		// Object Offset:0x0053352A
		SlomoSpeed = 1.0f;
	}
}
}