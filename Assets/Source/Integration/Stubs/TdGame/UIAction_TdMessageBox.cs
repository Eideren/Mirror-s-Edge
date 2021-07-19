namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdMessageBox : UIAction/*
		native
		hidecategories(Object)*/{
	[Category] public String TitleMarkup;
	[Category] public String MessageMarkup;
	[Category] public bool bSimpleBox;
	public bool bDone;
	public bool bReturnedTrue;
	
	public virtual /*event */void OnActivated()
	{
		// stub
	}
	
	public virtual /*private final function */void OnMessageBoxOpened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnMessageBox_OptionSelected(TdUIScene_MessageBox MessageBox, int SelectedOption, int PIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnMessageBox_Accept()
	{
		// stub
	}
	
	public virtual /*function */void OnMessageBox_Cancel()
	{
		// stub
	}
	
	public UIAction_TdMessageBox()
	{
		// Object Offset:0x006D5A50
		bAutoTargetOwner = true;
		bLatentExecution = true;
		bAutoActivateOutputLinks = false;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Ok",
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
				LinkDesc = "Cancel",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjName = "TdMessageBox";
		ObjCategory = "Takedown";
	}
}
}