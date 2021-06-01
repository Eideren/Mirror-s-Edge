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
	
	}
	
	public virtual /*function */void InitAITestScripts()
	{
	
	}
	
	public virtual /*exec function */void SuppressAI()
	{
	
	}
	
	public virtual /*exec function */void Difficulty(int Level)
	{
	
	}
	
	public virtual /*exec function */void Ammo()
	{
	
	}
	
	public virtual /*exec function */void ToggleDifficultyLevel()
	{
	
	}
	
	public virtual /*exec function */void SeeMe()
	{
	
	}
	
	public virtual /*exec function */void Test()
	{
	
	}
	
	public virtual /*exec function */void Run()
	{
	
	}
	
	public virtual /*exec function */void DebugCover(bool bSelectClosestCover)
	{
	
	}
	
	public virtual /*exec function */void ChangeCover(bool bSelectClosestCover)
	{
	
	}
	
	public virtual /*exec function */void CoverGoToState(String iState)
	{
	
	}
	
	public virtual /*exec function */void ToggleSlomo()
	{
	
	}
	
	public virtual /*exec function */void PlayAnim(name AnimationName)
	{
	
	}
	
	public virtual /*exec function */void hack1()
	{
	
	}
	
	public virtual /*exec function */void hack2()
	{
	
	}
	
	public virtual /*exec function */void Invisible()
	{
	
	}
	
	public virtual /*exec function */void ToggleAIWalking()
	{
	
	}
	
	public virtual /*exec function */void ToggleAIFocus()
	{
	
	}
	
	public virtual /*exec function */void ToggleAICrouching()
	{
	
	}
	
	public virtual /*exec function */void TestCovers()
	{
	
	}
	
	public virtual /*exec function */void Idle()
	{
	
	}
	
	public virtual /*exec function */void AIGotoState(name NewState, /*optional */bool? _onlyFirst = default)
	{
	
	}
	
	public virtual /*exec function */void AIGod()
	{
	
	}
	
	public virtual /*exec function */void SetGod()
	{
	
	}
	
	public virtual /*exec function */void RemoveGod()
	{
	
	}
	
	public override /*exec function */void God()
	{
	
	}
	
	public virtual /*exec function */void Jesus()
	{
	
	}
	
	public virtual /*exec function */void Stefan()
	{
	
	}
	
	public virtual /*exec function */void QA()
	{
	
	}
	
	public virtual /*exec function */void DebugTrace(/*optional */int? _Type = default)
	{
	
	}
	
	public virtual /*exec function */void DropMe()
	{
	
	}
	
	public virtual /*exec function */void ShowClosest()
	{
	
	}
	
	public virtual /*exec function */void ShowThisOne()
	{
	
	}
	
	public virtual /*exec function */void ShowAll()
	{
	
	}
	
	public virtual /*exec function */void pp()
	{
	
	}
	
	public virtual /*exec function */void dc()
	{
	
	}
	
	public virtual /*exec function */void PS()
	{
	
	}
	
	public virtual /*exec function */void pe()
	{
	
	}
	
	public virtual /*exec function */void AiRootRotation()
	{
	
	}
	
	public virtual /*exec function */void GoHere()
	{
	
	}
	
	public virtual /*exec function */void GoAngle(int Angle, float Distance)
	{
	
	}
	
	public virtual /*exec function */void WalkHere()
	{
	
	}
	
	public virtual /*exec function */void GoHereAll()
	{
	
	}
	
	public virtual /*exec function */void MoveStraightHere()
	{
	
	}
	
	public virtual /*exec function */void RunStraightHere()
	{
	
	}
	
	public virtual /*exec function */void RunHere()
	{
	
	}
	
	public virtual /*exec function */void HeadFocus(bool flag)
	{
	
	}
	
	public virtual /*exec function */void SetHeadFocusOnPlayer()
	{
	
	}
	
	public virtual /*exec function */void MoveAIHere()
	{
	
	}
	
	public virtual /*exec function */void sp()
	{
	
	}
	
	public virtual /*exec function */void mp()
	{
	
	}
	
	public virtual /*exec function */void DebugStop()
	{
	
	}
	
	public virtual /*exec function */void UpdatePath()
	{
	
	}
	
	public virtual /*exec function */void ClearScreenLog()
	{
	
	}
	
	public virtual /*exec function */void ScreenLogFilter(name F)
	{
	
	}
	
	public virtual /*exec function */void AILogFilter(name F)
	{
	
	}
	
	public virtual /*exec function */void TestReachable()
	{
	
	}
	
	public virtual /*exec function */void Roll()
	{
	
	}
	
	public virtual /*exec function */void SpawnAt(Object.Vector pos)
	{
	
	}
	
	public virtual /*exec function */void Training()
	{
	
	}
	
	public virtual /*exec function */void Atrium()
	{
	
	}
	
	public virtual /*exec function */void subway()
	{
	
	}
	
	public virtual /*exec function */void Platform()
	{
	
	}
	
	public virtual /*exec function */void Helicopter()
	{
	
	}
	
	public virtual /*exec function */void rb()
	{
	
	}
	
	public virtual /*exec function */void Boss(int stage)
	{
	
	}
	
	public virtual /*exec function */void ShowAIDebug()
	{
	
	}
	
	public virtual /*exec function */void TdToggleSlomo()
	{
	
	}
	
	public virtual /*exec function */void FootPlacement(bool bEnable)
	{
	
	}
	
	public virtual /*exec function */void AlignFootPosition(bool bEnable)
	{
	
	}
	
	public virtual /*exec function */void AlignFootRotation(bool bEnable)
	{
	
	}
	
	public virtual /*exec function */void InterpolateFootPosition(bool bEnable)
	{
	
	}
	
	public virtual /*exec function */void FootPositionInterpolationSpeed(float Speed)
	{
	
	}
	
	public virtual /*exec function */void InterpolateFootRotation(bool bEnable)
	{
	
	}
	
	public virtual /*exec function */void GiveStarRating(int NumStars)
	{
	
	}
	
	public virtual /*exec function */void IsLevelUnlocked(int Index)
	{
	
	}
	
	public virtual /*exec function */void IsBagFound(int Index)
	{
	
	}
	
	public virtual /*exec function */void SetGameProgress(String Map, String Checkpoint)
	{
	
	}
	
	public virtual /*exec function */void UnlockTT(int Index)
	{
	
	}
	
	public virtual /*exec function */void LockTT(int Index)
	{
	
	}
	
	public virtual /*exec function */void IsAllTTStretchesUnlocked()
	{
	
	}
	
	public virtual /*exec function */void LockAllTT()
	{
	
	}
	
	public virtual /*exec function */void IsTTUnlocked(int Index)
	{
	
	}
	
	public virtual /*exec function */void UnLockAllTT()
	{
	
	}
	
	public virtual /*exec function */void ActivateSaturation()
	{
	
	}
	
	public virtual /*exec function */void DeActivateSaturation()
	{
	
	}
	
	public virtual /*exec function */void FindAllBags()
	{
	
	}
	
	public virtual /*exec function */void FindBag(int Bag)
	{
	
	}
	
	public virtual /*exec function */void UncontrolledFalling(int On)
	{
	
	}
	
	public virtual /*exec function */void UncontrolledFallingClamp(float Clamp)
	{
	
	}
	
	public virtual /*exec function */void Flashbang(/*optional */int? _dmg = default)
	{
	
	}
	
	public virtual /*exec function */void Taser(/*optional */int? _dmg = default)
	{
	
	}
	
	public virtual /*exec function */void Bullet(/*optional */int? _dmg = default)
	{
	
	}
	
	public virtual /*exec function */void DebugMixGroups()
	{
	
	}
	
	public virtual /*exec function */void DebugVelocitySounds()
	{
	
	}
	
	public virtual /*exec function */void DebugReverbVolumes()
	{
	
	}
	
	public virtual /*exec function */void DumpAudioAllocations()
	{
	
	}
	
	public virtual /*exec function */void UnlockAllLevels()
	{
	
	}
	
	public virtual /*exec function */void LockAllLevels()
	{
	
	}
	
	public virtual /*exec function */void LockLevel(int Index)
	{
	
	}
	
	public virtual /*exec function */void UnlockLevel(int Index)
	{
	
	}
	
	public virtual /*exec function */void CompleteLR(float Time)
	{
	
	}
	
	public virtual /*exec function */void CompleteLevel(int Level)
	{
	
	}
	
	public virtual /*exec function */void ShowScenes()
	{
	
	}
	
	public virtual /*exec function */void CP()
	{
	
	}
	
	public virtual /*exec function */void WriteTTTime(int Stretch, float Time, int NumIntermediateTimes)
	{
	
	}
	
	public virtual /*exec function */void ReadTTTime(int Stretch)
	{
	
	}
	
	public virtual /*exec function */void DefaultProfile()
	{
	
	}
	
	public virtual /*exec function */void SaveProfile()
	{
	
	}
	
	public virtual /*exec function */void KillAllButOne()
	{
	
	}
	
	public virtual /*exec function */void KillAllAI()
	{
	
	}
	
	public virtual /*exec function */void KillClosest()
	{
	
	}
	
	public virtual /*private final function */TdAIController GetClosestAI()
	{
	
		return default;
	}
	
	public virtual /*exec function */void DebugHalt()
	{
	
	}
	
	public virtual /*exec function */void DebugLineOfSight()
	{
	
	}
	
	public virtual /*exec function */void PrintLog(String iString)
	{
	
	}
	
	public virtual /*exec function */void AICrouch()
	{
	
	}
	
	public virtual /*exec function */void SetMeleeType(String mt)
	{
	
	}
	
	public virtual /*exec function */void CoverCPOL()
	{
	
	}
	
	public virtual /*exec function */void CoverDetour()
	{
	
	}
	
	public virtual /*exec function */void CoverPath()
	{
	
	}
	
	public virtual /*exec function */void ResetAI()
	{
	
	}
	
	public virtual /*exec function */void RenameNodes()
	{
	
	}
	
	public virtual /*exec function */void HeliMove(String navpointName)
	{
	
	}
	
	public virtual /*exec function */void SetHeliSpeed(int I)
	{
	
	}
	
	public virtual /*exec function */void Eyelids()
	{
	
	}
	
	public virtual /*exec function */void DebugFalling()
	{
	
	}
	
	public virtual /*exec function */void SetAimState(TdAIAnimationController.EAimState iAimState)
	{
	
	}
	
	public virtual /*exec function */void AiHoldFire(bool bHoldFire)
	{
	
	}
	
	public virtual /*exec function */void InvertMouseCheat()
	{
	
	}
	
	public virtual /*exec function */void ChaseAI()
	{
	
	}
	
	public TdCheatManager()
	{
		// Object Offset:0x0053352A
		SlomoSpeed = 1.0f;
	}
}
}