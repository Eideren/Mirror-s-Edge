namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdMessageBox : UIAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ string TitleMarkup;
	public/*()*/ string MessageMarkup;
	public/*()*/ bool bSimpleBox;
	public bool bDone;
	public bool bReturnedTrue;
	
	public virtual /*event */void OnActivated()
	{
	
	}
	
	public virtual /*private final function */void OnMessageBoxOpened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OnMessageBox_OptionSelected(TdUIScene_MessageBox MessageBox, int SelectedOption, int PIndex)
	{
	
	}
	
	public virtual /*function */void OnMessageBox_Accept()
	{
	
	}
	
	public virtual /*function */void OnMessageBox_Cancel()
	{
	
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