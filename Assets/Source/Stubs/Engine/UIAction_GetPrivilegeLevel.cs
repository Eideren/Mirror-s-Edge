namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_GetPrivilegeLevel : UIAction/*
		native
		hidecategories(Object)*/{
	public enum EFeaturePrivilegeMode 
	{
		FPM_Online,
		FPM_Chat,
		FPM_DownloadUserContent,
		FPM_PurchaseContent,
		FPM_MAX
	};
	
	public/*()*/ int PlayerId;
	public/*()*/ UIAction_GetPrivilegeLevel.EFeaturePrivilegeMode PrivMode;
	
	public virtual /*event */OnlineSubsystem.EFeaturePrivilegeLevel GetPrivilegeLevel(int ControllerId)
	{
		// stub
		return default;
	}
	
	public UIAction_GetPrivilegeLevel()
	{
		// Object Offset:0x0040C9A1
		bAutoActivateOutputLinks = false;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Disabled",
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
				LinkDesc = "Enabled for Friends Only",
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
				LinkDesc = "Enabled",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjName = "Get Privilege Level";
		ObjCategory = "Online";
	}
}
}