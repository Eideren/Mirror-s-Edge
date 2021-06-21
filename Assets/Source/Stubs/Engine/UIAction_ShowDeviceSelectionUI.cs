namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_ShowDeviceSelectionUI : UIAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ int SizeNeeded;
	public/*()*/ bool bForceShowUI;
	public bool bIsDone;
	public bool bResult;
	public/*()*/ int DeviceID;
	public/*()*/ String DeviceName;
	
	// Export UUIAction_ShowDeviceSelectionUI::execWriteToVariables(FFrame&, void* const)
	public virtual /*native function */void WriteToVariables()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*event */void SelectDevice()
	{
		// stub
	}
	
	public virtual /*function */void OnDeviceSelectionComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public UIAction_ShowDeviceSelectionUI()
	{
		// Object Offset:0x004169A8
		bLatentExecution = true;
		bAutoActivateOutputLinks = false;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Failure",
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
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "Device Name",
				LinkVar = (name)"None",
				PropertyName = (name)"DeviceName",
				bWriteable = true,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "DeviceID",
				LinkVar = (name)"None",
				PropertyName = (name)"DeviceID",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "Gamepad Id",
				LinkVar = (name)"None",
				PropertyName = (name)"GamepadID",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Select Media Device";
		ObjCategory = "Online";
	}
}
}