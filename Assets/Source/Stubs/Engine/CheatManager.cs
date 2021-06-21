namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CheatManager : Object/* within PlayerController*//*
		native*/{
	public new PlayerController Outer => base.Outer as PlayerController;
	
	public virtual /*exec function */void ListDynamicActors()
	{
		// stub
	}
	
	public virtual /*exec function */void FreezeFrame(float delay)
	{
		// stub
	}
	
	public virtual /*exec function */void WriteToLog(String Param)
	{
		// stub
	}
	
	public virtual /*exec function */void KillViewedActor()
	{
		// stub
	}
	
	public virtual /*exec function */void Teleport()
	{
		// stub
	}
	
	public virtual /*exec function */void BugItGo(/*coerce */float X, /*coerce */float Y, /*coerce */float Z, /*coerce */int Pitch, /*coerce */int Yaw, /*coerce */int Roll)
	{
		// stub
	}
	
	public virtual /*function */void BugItGoString(String TheLocation, String TheRotation)
	{
		// stub
	}
	
	public virtual /*function */void BugItWorker(Object.Vector TheLocation, Object.Rotator TheRotation)
	{
		// stub
	}
	
	public virtual /*exec function */void BugIt(/*optional */String? _ScreenShotDescription = default)
	{
		// stub
	}
	
	// Export UCheatManager::execGetFVectorFromString(FFrame&, void* const)
	public virtual /*private native final function */Object.Vector GetFVectorFromString(String InStr)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UCheatManager::execGetFRotatorFromString(FFrame&, void* const)
	public virtual /*private native final function */Object.Rotator GetFRotatorFromString(String InStr)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*exec function */void ChangeSize(float F)
	{
		// stub
	}
	
	public virtual /*exec function */void EndPath()
	{
		// stub
	}
	
	public virtual /*exec function */void Amphibious()
	{
		// stub
	}
	
	public virtual /*exec function */void Fly()
	{
		// stub
	}
	
	public virtual /*exec function */void Walk()
	{
		// stub
	}
	
	public virtual /*exec function */void Ghost()
	{
		// stub
	}
	
	public virtual /*exec function */void AllAmmo()
	{
		// stub
	}
	
	public virtual /*exec function */void God()
	{
		// stub
	}
	
	public virtual /*exec function */void AffectedByHitEffects()
	{
		// stub
	}
	
	public virtual /*exec function */void SloMo(float T)
	{
		// stub
	}
	
	public virtual /*exec function */void SetJumpZ(float F)
	{
		// stub
	}
	
	public virtual /*exec function */void SetGravity(float F)
	{
		// stub
	}
	
	public virtual /*exec function */void SetSpeed(float F)
	{
		// stub
	}
	
	public virtual /*exec function */void KillAll(Core.ClassT<Actor> aClass)
	{
		// stub
	}
	
	public virtual /*function */void KillAllPawns(Core.ClassT<Pawn> aClass)
	{
		// stub
	}
	
	public virtual /*exec function */void KillPawns()
	{
		// stub
	}
	
	public virtual /*exec function */void Avatar(name ClassName)
	{
		// stub
	}
	
	public virtual /*exec function */void Summon(String ClassName)
	{
		// stub
	}
	
	public virtual /*exec function */Weapon GiveWeapon(String WeaponClassStr)
	{
		// stub
		return default;
	}
	
	public virtual /*exec function */void PlayersOnly()
	{
		// stub
	}
	
	public virtual /*exec function */void RememberSpot()
	{
		// stub
	}
	
	public virtual /*exec function */void ViewSelf(/*optional */bool? _bQuiet = default)
	{
		// stub
	}
	
	public virtual /*exec function */void ViewPlayer(String S)
	{
		// stub
	}
	
	public virtual /*exec function */void ViewActor(name actorName)
	{
		// stub
	}
	
	public virtual /*exec function */void ViewFlag()
	{
		// stub
	}
	
	public virtual /*exec function */void ViewBot()
	{
		// stub
	}
	
	public virtual /*exec function */void ViewClass(Core.ClassT<Actor> aClass)
	{
		// stub
	}
	
	public virtual /*exec function */void Loaded()
	{
		// stub
	}
	
	public virtual /*exec function */void AllWeapons()
	{
		// stub
	}
	
	public virtual /*function */void SetLevelStreamingStatus(name PackageName, bool bShouldBeLoaded, bool bShouldBeVisible)
	{
		// stub
	}
	
	public virtual /*exec function */void StreamLevelIn(name PackageName)
	{
		// stub
	}
	
	public virtual /*exec function */void OnlyLoadLevel(name PackageName)
	{
		// stub
	}
	
	public virtual /*exec function */void StreamLevelOut(name PackageName)
	{
		// stub
	}
	
	public virtual /*exec function */void ToggleDebugCamera()
	{
		// stub
	}
	
	public virtual /*exec function */void TestLevel()
	{
		// stub
	}
	
}
}