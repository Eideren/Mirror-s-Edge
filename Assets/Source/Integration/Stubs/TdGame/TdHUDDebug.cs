namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDDebug : Object/* within TdHUD*//*
		native
		config(Game)
		perobjectconfig*/{
	public new TdHUD Outer => base.Outer as TdHUD;
	
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FSelfRegisteringExec;
	[config] public bool bShowInvisibleMode;
	[config] public bool bShowGodMode;
	[Category("DebugTools")] public bool bDebugAnimTimeline;
	[Category("DebugTools")] public bool bDebugAnimWeights;
	[Category("DebugTools")] public bool bDebugSkeletalMeshInfo;
	[Category("DebugTools")] public bool bDrawGraph;
	[Category("DebugTools")] public bool bDrawMemoryBudget;
	[Category("DebugTools")] public bool bDrawLookAtPoints;
	[Category("DebugTools")] public bool bDrawAIStates;
	[Category("DebugTools")] public bool bDrawSafeRegion;
	[Category("DebugTools")] public bool bDrawDebugAnims;
	[Category("DebugTools")] public bool bFixedSlomo;
	[Category("DebugTools")] public bool bDebugSceneStack;
	[Category("DebugTools")] public bool bShowCheckpoints;
	[Category("DebugTools")] public bool bShowCheckpointsPath;
	public float TimedMessageTimestamp;
	public float TimedMessageTime;
	public String TimedMessage;
	[Category("DebugTools")] public String DebugKismetOutput;
	[Category("DebugTools")] public TdPawn ActiveActor;
	public int BufferSize;
	public array<String> ScreenBuffer;
	public name AnimationStartingPoint;
	[transient] public TdCheatManager CheatManager;
	[transient] public array<TdCheckpoint> Checkpoints;
	
	public virtual /*function */void DrawDebugHUD()
	{
		// stub
	}
	
	public virtual /*function */void TimedScreenMessage(String Message, float Time)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowLookAtPoints()
	{
		// stub
	}
	
	public virtual /*exec function */void SetActiveActor(int Index)
	{
		// stub
	}
	
	public virtual /*exec function */void CycleActiveActor()
	{
		// stub
	}
	
	public virtual /*exec function */void SetAiTutorialPawnActive()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowAnims(/*optional */name? _StartingPoint = default)
	{
		// stub
	}
	
	public virtual /*exec function */void SetShowAnimTimeLine(bool flag)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowAnimTimeLine()
	{
		// stub
	}
	
	public virtual /*exec function */void SetShowDebug(bool flag, /*optional */name? _DebugType = default)
	{
		// stub
	}
	
	public virtual /*exec function */void DebugNetAnim()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowSkeletalMeshInfo()
	{
		// stub
	}
	
	public virtual /*exec function */void DebugAnims()
	{
		// stub
	}
	
	public virtual /*exec function */void FixedSlomo(float Speed)
	{
		// stub
	}
	
	public virtual /*exec function */void FlushAnimTimeLine()
	{
		// stub
	}
	
	public virtual /*exec function */void FlushAnimWeightBoxes()
	{
		// stub
	}
	
	public virtual /*exec function */void PlayAnimation(name AnimationName, /*optional */TdPawn.CustomNodeType? _AnimationType = default, /*optional */bool? _RootMotion = default, /*optional */bool? _RootRotation = default, /*optional */float? _BlendTime = default, /*optional */int? _Index = default)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowGraph()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowAIStates()
	{
		// stub
	}
	
	public virtual /*function */void DrawPath(Pawn Target, /*optional */float? _Time = default)
	{
		// stub
	}
	
	public virtual /*function */void DrawVisibilityValues()
	{
		// stub
	}
	
	public virtual /*exec function */void ShowPathInfo(int Index)
	{
		// stub
	}
	
	public virtual /*exec function */void ShowMemoryBudget()
	{
		// stub
	}
	
	public virtual /*exec function */void DumpMemoryAllocations()
	{
		// stub
	}
	
	public virtual /*exec function */void PPToggle(int Index)
	{
		// stub
	}
	
	public virtual /*exec function */void DebugCheckpoints()
	{
		// stub
	}
	
	public virtual /*exec function */void DebugCheckpointsOrder()
	{
		// stub
	}
	
	// Export UTdHUDDebug::execPopulateCheckpointList(FFrame&, void* const)
	public virtual /*native function */void PopulateCheckpointList()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*exec function */void DebugCheckpointsPath()
	{
		// stub
	}
	
	public TdHUDDebug()
	{
		// Object Offset:0x0056EC54
		BufferSize = 30;
	}
}
}