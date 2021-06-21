namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdMainMenuStickCaptionAnimation : UIAction/*
		native
		hidecategories(Object)*/{
	public TdUIScene_MainMenu MainMenuScene;
	public bool bIsDone;
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public virtual /*function */void CaptionDoneCallback()
	{
		// stub
	}
	
	public UIAction_TdMainMenuStickCaptionAnimation()
	{
		// Object Offset:0x006D52B5
		bAutoTargetOwner = true;
		bCallHandler = false;
		bLatentExecution = true;
		bAutoActivateOutputLinks = false;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Done",
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
				LinkDesc = "Failed",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjName = "MainMenu Stick Caption Animation";
		ObjCategory = "Takedown";
	}
}
}