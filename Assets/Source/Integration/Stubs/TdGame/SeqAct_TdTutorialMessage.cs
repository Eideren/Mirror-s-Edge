namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdTutorialMessage : SequenceAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ String TutorialMessage;
	public/*()*/ bool bReplaceCurrentMessage;
	public/*()*/ bool bRequireAccept;
	public/*()*/ bool bPauseGame;
	public/*()*/ bool bTriggerSlomo;
	public/*()*/ bool bCustomButtonFallThrough;
	public /*transient */bool bFinished;
	public/*()*/ float Duration;
	public/*()*/ TdProfileSettings.EDigitalButtonActions CustomButtonKey;
	public/*()*/ String CustomButtonCallOut;
	public /*transient */TdUIScene_TutorialHUDMessage Scene;
	public /*transient */TdGameUISceneClient SceneClient;
	
	public virtual /*function */LocalPlayer GetFirstLocalPlayer()
	{
		// stub
		return default;
	}
	
	public override /*function */void Reset()
	{
		// stub
	}
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public virtual /*event */void BeginShowTutorialMessage()
	{
		// stub
	}
	
	public virtual /*function */void OnPrevScene_Deactivated(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void ShowTutorialMessage()
	{
		// stub
	}
	
	public virtual /*function */void OnTutorialMessageOpened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnSceneDeactivated(UIScene DeactivatedScene)
	{
		// stub
	}
	
	public override /*event */bool IsValidLevelSequenceObject()
	{
		// stub
		return default;
	}
	
	public SeqAct_TdTutorialMessage()
	{
		// Object Offset:0x004A4B6F
		bRequireAccept = true;
		Duration = 3.0f;
		bCallHandler = false;
		bLatentExecution = true;
		bAutoActivateOutputLinks = false;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
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
		VariableLinks = default;
		ObjName = "Tutorial Message";
		ObjCategory = "TdTutorial";
	}
}
}