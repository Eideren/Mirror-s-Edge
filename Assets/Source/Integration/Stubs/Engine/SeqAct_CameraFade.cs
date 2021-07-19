namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_CameraFade : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] public Object.Color FadeColor;
	[Category] public Object.Vector2D FadeAlpha;
	[Category] public float FadeTime;
	[Category] public bool bPersistFade;
	[transient] public float FadeTimeRemaining;
	[transient] public array<Camera> CachedCameras;
	
	public SeqAct_CameraFade()
	{
		// Object Offset:0x003B93EF
		FadeAlpha = new Vector2D
		{
			X=0.0f,
			Y=1.0f
		};
		FadeTime = 1.0f;
		bPersistFade = true;
		bLatentExecution = true;
		bAutoActivateOutputLinks = false;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Out",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Finished",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjName = "Fade";
		ObjCategory = "Camera";
	}
}
}