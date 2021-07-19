namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_PlayFaceFXAnim : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] public FaceFXAnimSet FaceFXAnimSetRef;
	[Category] public String FaceFXGroupName;
	[Category] public String FaceFXAnimName;
	
	public SeqAct_PlayFaceFXAnim()
	{
		// Object Offset:0x003C9FB4
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Play",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		ObjName = "Play FaceFX Anim";
		ObjCategory = "Sound";
	}
}
}