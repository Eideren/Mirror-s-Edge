// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeState : TdAnimNodeBlendList/*
		native
		hidecategories(Object,Object,Object)*/{
	public array<int> StateMapping;
	public String EnumStringName;
	public array<TdAnimNodeState> FriendNodes;
	public int SavedEnum;
	public int CurrentUsedEnum;
	public int PreviousUsedEnum;
	public bool bUseCustomBlend;
	
	// Export UTdAnimNodeState::execSetActiveMove(FFrame&, void* const)
	//public override /*native function */bool SetActiveMove(int ChildIndex, /*optional */bool? _ForceActive = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export UTdAnimNodeState::execUpdateChildNames(FFrame&, void* const)
	public virtual /*native function */void UpdateChildNames()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UTdAnimNodeState::execGetActiveState(FFrame&, void* const)
	//public virtual /*native function */int GetActiveState()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export UTdAnimNodeState::execGetBlendValue(FFrame&, void* const)
	//public virtual /*native function */float GetBlendValue(int PreviousState, int NewState)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	public override /*event */void OnInit()
	{
		UpdateChildNames();
	}
	
	public override /*event */void OnBecomeRelevant()
	{
		SetActiveChild(GetActiveState(), 0.0f);
		base.OnBecomeRelevant();
	}
	
	// Export UTdAnimNodeState::execGetState(FFrame&, void* const)
	public virtual /*native simulated function */int GetState()
	{
		// This works like an abstract function afaik, never actually called,
		// just defined for children to override its behavior
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*event */void OverrideStateMapping()
	{
	
	}
	
	public TdAnimNodeState()
	{
		// Object Offset:0x004FBC70
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Default",
				Anim = default,
				Weight = 0.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = false,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
		};
		bFixNumChildren = true;
	}
}
}