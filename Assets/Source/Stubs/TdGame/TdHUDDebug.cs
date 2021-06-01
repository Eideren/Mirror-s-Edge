namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDDebug : Object/* within TdHUD*//*
		native
		config(Game)
		perobjectconfig*/{
	public new TdHUD Outer => base.Outer as TdHUD;
	
	public /*private native const noexport */Object.Pointer VfTable_FSelfRegisteringExec;
	public /*config */bool bShowInvisibleMode;
	public /*config */bool bShowGodMode;
	public/*(DebugTools)*/ bool bDebugAnimTimeline;
	public/*(DebugTools)*/ bool bDebugAnimWeights;
	public/*(DebugTools)*/ bool bDebugSkeletalMeshInfo;
	public/*(DebugTools)*/ bool bDrawGraph;
	public/*(DebugTools)*/ bool bDrawMemoryBudget;
	public/*(DebugTools)*/ bool bDrawLookAtPoints;
	public/*(DebugTools)*/ bool bDrawAIStates;
	public/*(DebugTools)*/ bool bDrawSafeRegion;
	public/*(DebugTools)*/ bool bDrawDebugAnims;
	public/*(DebugTools)*/ bool bFixedSlomo;
	public/*(DebugTools)*/ bool bDebugSceneStack;
	public/*(DebugTools)*/ bool bShowCheckpoints;
	public/*(DebugTools)*/ bool bShowCheckpointsPath;
	public float TimedMessageTimestamp;
	public float TimedMessageTime;
	public String TimedMessage;
	public/*(DebugTools)*/ String DebugKismetOutput;
	public/*(DebugTools)*/ TdPawn ActiveActor;
	public int BufferSize;
	public array<String> ScreenBuffer;
	public name AnimationStartingPoint;
	public /*transient */TdCheatManager CheatManager;
	public /*transient */array<TdCheckpoint> Checkpoints;
	
	public virtual /*function */void DrawDebugHUD()
	{
	
	}
	
	public virtual /*function */void TimedScreenMessage(String Message, float Time)
	{
	
	}
	
	public virtual /*exec function */void ShowLookAtPoints()
	{
	
	}
	
	public virtual /*exec function */void SetActiveActor(int Index)
	{
	
	}
	
	public virtual /*exec function */void CycleActiveActor()
	{
	
	}
	
	public virtual /*exec function */void SetAiTutorialPawnActive()
	{
	
	}
	
	public virtual /*exec function */void ShowAnims(/*optional */name? _StartingPoint = default)
	{
	
	}
	
	public virtual /*exec function */void SetShowAnimTimeLine(bool flag)
	{
	
	}
	
	public virtual /*exec function */void ShowAnimTimeLine()
	{
	
	}
	
	public virtual /*exec function */void SetShowDebug(bool flag, /*optional */name? _DebugType = default)
	{
	
	}
	
	public virtual /*exec function */void DebugNetAnim()
	{
	
	}
	
	public virtual /*exec function */void ShowSkeletalMeshInfo()
	{
	
	}
	
	public virtual /*exec function */void DebugAnims()
	{
	
	}
	
	public virtual /*exec function */void FixedSlomo(float Speed)
	{
	
	}
	
	public virtual /*exec function */void FlushAnimTimeLine()
	{
	
	}
	
	public virtual /*exec function */void FlushAnimWeightBoxes()
	{
	
	}
	
	public virtual /*exec function */void PlayAnimation(name AnimationName, /*optional */TdPawn.CustomNodeType? _AnimationType = default, /*optional */bool? _RootMotion = default, /*optional */bool? _RootRotation = default, /*optional */float? _BlendTime = default, /*optional */int? _Index = default)
	{
	
	}
	
	public virtual /*exec function */void ShowGraph()
	{
	
	}
	
	public virtual /*exec function */void ShowAIStates()
	{
	
	}
	
	public virtual /*function */void DrawPath(Pawn Target, /*optional */float? _Time = default)
	{
	
	}
	
	public virtual /*function */void DrawVisibilityValues()
	{
	
	}
	
	public virtual /*exec function */void ShowPathInfo(int Index)
	{
	
	}
	
	public virtual /*exec function */void ShowMemoryBudget()
	{
	
	}
	
	public virtual /*exec function */void DumpMemoryAllocations()
	{
	
	}
	
	public virtual /*exec function */void PPToggle(int Index)
	{
	
	}
	
	public virtual /*exec function */void DebugCheckpoints()
	{
	
	}
	
	public virtual /*exec function */void DebugCheckpointsOrder()
	{
	
	}
	
	// Export UTdHUDDebug::execPopulateCheckpointList(FFrame&, void* const)
	public virtual /*native function */void PopulateCheckpointList()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*exec function */void DebugCheckpointsPath()
	{
	
	}
	
	public TdHUDDebug()
	{
		// Object Offset:0x0056EC54
		BufferSize = 30;
	}
}
}