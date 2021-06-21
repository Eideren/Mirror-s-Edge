namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIDroppableItem : Object/*
		abstract
		native*/{
	public virtual /*function */bool CanDrop(TdBotPawn Dropper)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void Drop(TdBotPawn Dropper)
	{
		// stub
	}
	
}
}