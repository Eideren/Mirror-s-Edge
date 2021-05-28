namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeIsReloadingSwitch : TdAnimNodeSwitch/*
		native
		hidecategories(Object,Object,Object)*/{
	public override /*event */void OnInitialize()
	{
	
	}
	
	public override /*event */bool EditorGetState()
	{
		return false;
	}
	
	public override /*event */void StateSwitched()
	{
		/*local */TdBotPawn AiPawn = default;
	
		AiPawn = ((SkelComponent.Owner) as TdBotPawn);
		if(AiPawn == default)
		{
			return;
		}
		if(GetState())
		{
			AiPawn.myController.HeadFocus.PushEnabled(false, "AnimNodeIsReloadingSwitch");		
		}
		else
		{
			AiPawn.myController.HeadFocus.PopEnabled("AnimNodeIsReloadingSwitch");
		}
	}
	
}
}