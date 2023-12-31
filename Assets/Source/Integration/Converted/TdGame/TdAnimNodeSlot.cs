// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeSlot : AnimNodeSlot/*
		native
		hidecategories(Object,Object,Object)*/{
	//// Export UTdAnimNodeSlot::execSetBlendOutTime(FFrame&, void* const)
	//public virtual /*native function */void SetBlendOutTime(float BlendTime)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UTdAnimNodeSlot::execSetCauseActorCeaseRelevant(FFrame&, void* const)
	//public virtual /*native function */void SetCauseActorCeaseRelevant(bool bNewStatus)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UTdAnimNodeSlot::execSetRootBoneRotationAxisOption(FFrame&, void* const)
	//public virtual /*native final function */void SetRootBoneRotationAxisOption(/*optional */AnimNodeSequence.ERootRotationOption? _AxisX = default, /*optional */AnimNodeSequence.ERootRotationOption? _AxisY = default, /*optional */AnimNodeSequence.ERootRotationOption? _AxisZ = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	public virtual /*final function */void AccelerateBlend(float BlendAmount)
	{
		/*local */int I = default;
		/*local */float BlendDelta = default;
	
		I = 0;
		J0x07:{}
		if(I < Children.Length)
		{
			BlendDelta = TargetWeight[I] - Children[I].Weight;
			Children[I].Weight += (BlendDelta * BlendAmount);
			++ I;
			goto J0x07;
		}
	}
	
}
}