namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CheatManager : Object/* within PlayerController*//*
		native*/{
	public new PlayerController Outer => base.Outer as PlayerController;
	
	public virtual /*exec function */void ListDynamicActors()
	{
	
	}
	
	public virtual /*exec function */void FreezeFrame(float delay)
	{
	
	}
	
	public virtual /*exec function */void WriteToLog(String Param)
	{
	
	}
	
	public virtual /*exec function */void KillViewedActor()
	{
	
	}
	
	public virtual /*exec function */void Teleport()
	{
	
	}
	
	public virtual /*exec function */void BugItGo(/*coerce */float X, /*coerce */float Y, /*coerce */float Z, /*coerce */int Pitch, /*coerce */int Yaw, /*coerce */int Roll)
	{
	
	}
	
	public virtual /*function */void BugItGoString(String TheLocation, String TheRotation)
	{
	
	}
	
	public virtual /*function */void BugItWorker(Object.Vector TheLocation, Object.Rotator TheRotation)
	{
	
	}
	
	public virtual /*exec function */void BugIt(/*optional */String? _ScreenShotDescription = default)
	{
	
	}
	
	// Export UCheatManager::execGetFVectorFromString(FFrame&, void* const)
	public virtual /*private native final function */Object.Vector GetFVectorFromString(String InStr)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCheatManager::execGetFRotatorFromString(FFrame&, void* const)
	public virtual /*private native final function */Object.Rotator GetFRotatorFromString(String InStr)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*exec function */void ChangeSize(float F)
	{
	
	}
	
	public virtual /*exec function */void EndPath()
	{
	
	}
	
	public virtual /*exec function */void Amphibious()
	{
	
	}
	
	public virtual /*exec function */void Fly()
	{
	
	}
	
	public virtual /*exec function */void Walk()
	{
	
	}
	
	public virtual /*exec function */void Ghost()
	{
	
	}
	
	public virtual /*exec function */void AllAmmo()
	{
	
	}
	
	public virtual /*exec function */void God()
	{
	
	}
	
	public virtual /*exec function */void AffectedByHitEffects()
	{
	
	}
	
	public virtual /*exec function */void SloMo(float T)
	{
	
	}
	
	public virtual /*exec function */void SetJumpZ(float F)
	{
	
	}
	
	public virtual /*exec function */void SetGravity(float F)
	{
	
	}
	
	public virtual /*exec function */void SetSpeed(float F)
	{
	
	}
	
	public virtual /*exec function */void KillAll(Core.ClassT<Actor> aClass)
	{
	
	}
	
	public virtual /*function */void KillAllPawns(Core.ClassT<Pawn> aClass)
	{
	
	}
	
	public virtual /*exec function */void KillPawns()
	{
	
	}
	
	public virtual /*exec function */void Avatar(name ClassName)
	{
	
	}
	
	public virtual /*exec function */void Summon(String ClassName)
	{
	
	}
	
	public virtual /*exec function */Weapon GiveWeapon(String WeaponClassStr)
	{
	
		return default;
	}
	
	public virtual /*exec function */void PlayersOnly()
	{
	
	}
	
	public virtual /*exec function */void RememberSpot()
	{
	
	}
	
	public virtual /*exec function */void ViewSelf(/*optional */bool? _bQuiet = default)
	{
	
	}
	
	public virtual /*exec function */void ViewPlayer(String S)
	{
	
	}
	
	public virtual /*exec function */void ViewActor(name actorName)
	{
	
	}
	
	public virtual /*exec function */void ViewFlag()
	{
	
	}
	
	public virtual /*exec function */void ViewBot()
	{
	
	}
	
	public virtual /*exec function */void ViewClass(Core.ClassT<Actor> aClass)
	{
	
	}
	
	public virtual /*exec function */void Loaded()
	{
	
	}
	
	public virtual /*exec function */void AllWeapons()
	{
	
	}
	
	public virtual /*function */void SetLevelStreamingStatus(name PackageName, bool bShouldBeLoaded, bool bShouldBeVisible)
	{
	
	}
	
	public virtual /*exec function */void StreamLevelIn(name PackageName)
	{
	
	}
	
	public virtual /*exec function */void OnlyLoadLevel(name PackageName)
	{
	
	}
	
	public virtual /*exec function */void StreamLevelOut(name PackageName)
	{
	
	}
	
	public virtual /*exec function */void ToggleDebugCamera()
	{
	
	}
	
	public virtual /*exec function */void TestLevel()
	{
	
	}
	
}
}