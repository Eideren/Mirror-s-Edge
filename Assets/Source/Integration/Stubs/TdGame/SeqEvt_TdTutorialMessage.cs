namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdTutorialMessage : SequenceEvent/*
		hidecategories(Object)*/{
	public enum ETutorialMessage 
	{
		ETutoralMsg_HitMeReminder,
		ETutoralMsg_HitMeBlockReminder,
		ETutoralMsg_DisarmReminder,
		ETutoralMsg_GoodWorkOneMore,
		ETutoralMsg_HitSuccess,
		ETutoralMsg_HitFailed,
		ETutoralMsg_JumpKickSuccess,
		ETutoralMsg_JumpKickFailed,
		ETutoralMsg_SlideKickFailed,
		ETutoralMsg_PlayerLayOnGround,
		ETutoralMsg_MAX
	};
	
	[Category] public SeqEvt_TdTutorialMessage.ETutorialMessage Message;
	
	public SeqEvt_TdTutorialMessage()
	{
		// Object Offset:0x004A87F4
		MaxTriggerCount = 0;
		bPlayerOnly = false;
		ObjName = "Tutorial message event";
		ObjCategory = "Tutorial";
	}
}
}