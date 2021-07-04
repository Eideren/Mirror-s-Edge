namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeBlendList : AnimNodeBlendList/*
		native
		hidecategories(Object,Object,Object)*/{
	public/*()*/ array<float> BlendWeight;
	public/*()*/ array<float> BlendOutWeight;
	public/*()*/ bool bScaleBlendTimeBySpeed;
	public int EditorSliderIndex;
	public /*transient */TdPawn TdPawnOwner;
	
	// Export UTdAnimNodeBlendList::execSetActiveMove(FFrame&, void* const)
	public virtual /*native function */bool SetActiveMove(int ChildIndex, /*optional */bool? _ForceActive = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
}
}