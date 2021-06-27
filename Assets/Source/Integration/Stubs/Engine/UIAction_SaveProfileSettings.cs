namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_SaveProfileSettings : UIAction/*
		native
		hidecategories(Object)*/{
	public bool bIsDone;
	public bool bWroteProfile;
	
	public virtual /*event */void RegisterDelegate()
	{
		// stub
	}
	
	public virtual /*event */void ClearDelegate()
	{
		// stub
	}
	
	public virtual /*function */void OnProfileWriteComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public UIAction_SaveProfileSettings()
	{
		// Object Offset:0x00412A5E
		bAutoTargetOwner = true;
		bLatentExecution = true;
		bAutoActivateOutputLinks = false;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Failure",
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
				LinkDesc = "Success",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjName = "Save Profile Settings";
		ObjCategory = "Online";
	}
}
}