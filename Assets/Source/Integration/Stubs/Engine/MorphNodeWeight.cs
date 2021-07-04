namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MorphNodeWeight : MorphNodeWeightBase/*
		native
		hidecategories(Object,Object,Object)*/{
	public float NodeWeight;
	
	// Export UMorphNodeWeight::execSetNodeWeight(FFrame&, void* const)
	public virtual /*native function */void SetNodeWeight(float NewWeight)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public MorphNodeWeight()
	{
		// Object Offset:0x0035D27C
		NodeConns = new array<MorphNodeWeightBase.MorphNodeConn>
		{
			new MorphNodeWeightBase.MorphNodeConn
			{
				ChildNodes = default,
				ConnName = (name)"In",
				DrawY = 0,
			},
		};
		bDrawSlider = true;
	}
}
}