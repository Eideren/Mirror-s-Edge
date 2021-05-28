namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqCond_SwitchBase : SequenceCondition/*
		abstract
		native
		hidecategories(Object)*/{
	public virtual /*event */void VerifyDefaultCaseValue()
	{
	
	}
	
	public virtual /*event */bool IsFallThruEnabled(int ValueIndex)
	{
	
		return default;
	}
	
	public virtual /*event */void InsertValueEntry(int InsertIndex)
	{
	
	}
	
	public virtual /*event */void RemoveValueEntry(int RemoveIndex)
	{
	
	}
	
	public SeqCond_SwitchBase()
	{
		// Object Offset:0x003D9121
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Default",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjCategory = "Switch";
	}
}
}