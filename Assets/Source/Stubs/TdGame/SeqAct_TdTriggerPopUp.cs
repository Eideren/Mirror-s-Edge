namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdTriggerPopUp : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ TdSPHUD.EPopUpType PopUpType;
	public/*()*/ float Duration;
	
	public override /*event */void Activated()
	{
	
	}
	
	public SeqAct_TdTriggerPopUp()
	{
		// Object Offset:0x004A2AEC
		OutputLinks = default;
		VariableLinks = default;
		ObjName = "Pop Up";
		ObjCategory = "Takedown";
	}
}
}