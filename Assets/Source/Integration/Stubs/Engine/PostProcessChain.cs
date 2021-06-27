namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PostProcessChain : Object/*
		native*/{
	public array<PostProcessEffect> Effects;
	
	public virtual /*final function */PostProcessEffect FindPostProcessEffect(name EffectName)
	{
		// stub
		return default;
	}
	
}
}