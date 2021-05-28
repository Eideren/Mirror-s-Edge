namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeBlendBySpeed : AnimNodeBlendList/*
		native
		hidecategories(Object,Object,Object)*/{
	public float Speed;
	public int LastChannel;
	public/*()*/ float BlendUpTime;
	public/*()*/ float BlendDownTime;
	public/*()*/ float BlendDownPerc;
	public/*()*/ array<float> Constraints;
	public/*()*/ bool bUseAcceleration;
	
	public AnimNodeBlendBySpeed()
	{
		// Object Offset:0x00299D4F
		BlendUpTime = 0.10f;
		BlendDownTime = 0.10f;
		BlendDownPerc = 0.20f;
		Constraints = new array<float>
		{
			0.0f,
			180.0f,
			350.0f,
			900.0f,
		};
	}
}
}