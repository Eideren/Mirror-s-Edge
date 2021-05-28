namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface TdUIScene_CreateAccountInterface : Interface/*
		abstract*/{
	public /*function */void CreateAccountDone(int Error, /*optional */string LocError = default);
	
	public /*function */void SetSceneDeactivatedDelegate(/*delegate*/UIScene.OnSceneDeactivated SceneDeactivated);
	
}
}