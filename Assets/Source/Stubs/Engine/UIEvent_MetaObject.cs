namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIEvent_MetaObject : UIEvent/*
		transient
		native
		hidecategories(Object)*/{
	public /*private native const noexport */Object.Pointer VfTable_FCallbackEventDevice;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public UIEvent_MetaObject()
	{
		// Object Offset:0x00431758
		ObjName = "State Input Events";
		bDeletable = false;
	}
}
}