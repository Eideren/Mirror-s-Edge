namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeBlendBySpeed : AnimNodeBlendBySpeed/*
		native
		hidecategories(Object,Object,Object)*/{
	public/*()*/ bool bDebugThis;
	public/*()*/ bool bUseAverageSpeed;
	
	public TdAnimNodeBlendBySpeed()
	{
		// Object Offset:0x004FF34A
		bUseAverageSpeed = true;
		Constraints = new array<float>
		{
			0.0f,
			40.0f,
			200.0f,
			650.0f,
		};
	}
}
}