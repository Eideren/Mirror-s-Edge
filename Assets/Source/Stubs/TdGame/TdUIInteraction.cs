namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIInteraction : UIInteraction/* within TdGameViewportClient*//*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public new TdGameViewportClient Outer => base.Outer as TdGameViewportClient;
	
	public int BlockUIInputSemaphore;
	
	public virtual /*event */void ClearUIInputBlocks()
	{
		// stub
	}
	
	// Export UTdUIInteraction::execShouldProcessUIInput(FFrame&, void* const)
	public virtual /*native final function */bool ShouldProcessUIInput()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*event */void BlockUIInput(bool bBlock)
	{
		// stub
	}
	
	public TdUIInteraction()
	{
		// Object Offset:0x00687E01
		SceneClientClass = ClassT<TdGameUISceneClient>()/*Ref Class'TdGameUISceneClient'*/;
	}
}
}