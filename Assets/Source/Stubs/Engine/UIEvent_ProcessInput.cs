namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIEvent_ProcessInput : UIEvent/*
		transient
		native
		hidecategories(Object)*/{
	public /*native transient */Object.MultiMap_Mirror ActionMap;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public UIEvent_ProcessInput()
	{
		// Object Offset:0x004332E4
		Description = "Executes actions in response to an input event, such as a keypress or mouse movement";
		bShouldRegisterEvent = false;
		bPropagateEvent = false;
		ObjName = "Handle Input";
	}
}
}