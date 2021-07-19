namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_VideoSettingsPC : TdUIScene_VideoSettings/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public partial struct /*native */ScreenResSetting
	{
		public int ResX;
		public int ResY;
		public bool bFullscreen;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0056871B
	//		ResX = 0;
	//		ResY = 0;
	//		bFullscreen = false;
	//	}
	};
	
	public UIDataStore_TdStringList StringList;
	[transient] public TdUIScene_VideoSettingsPC.ScreenResSetting OldResolution;
	[transient] public TdUIScene_VideoSettingsPC.ScreenResSetting NewResolution;
	public int OldVSyncVal;
	public int OldTexDetailVal;
	public int OldGfxQualVal;
	public int OldAAVal;
	public int OldPhysXVal;
	[transient] public/*private*/ bool bSupportsCSAA;
	
	// Export UTdUIScene_VideoSettingsPC::execGetSupportedAAModes(FFrame&, void* const)
	public virtual /*native function */bool GetSupportedAAModes(ref array<String> AAModes)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUIScene_VideoSettingsPC::execGetPhysXSupported(FFrame&, void* const)
	public virtual /*native function */bool GetPhysXSupported()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void DisableVideoSettings()
	{
		// stub
	}
	
	public override /*function */void OnReset()
	{
		// stub
	}
	
	public virtual /*function */void SetupCurrentSettings()
	{
		// stub
	}
	
	public override /*function */void OnAccept()
	{
		// stub
	}
	
	public virtual /*function */void OnAcceptForce()
	{
		// stub
	}
	
	public virtual /*function */bool CheckPhysXChanged()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void PhysXChanged(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void PhysXChangedNotSupported(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void DisplayPhysXChangedMsgBox(TdUIScene_MessageBox MsgBox, String Message, String Title)
	{
		// stub
	}
	
	public virtual /*function */void PhysXChangedMsgBox_PreSelection(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void PhysXChangedMsgBox_Selection(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void ApplyVideoSettings()
	{
		// stub
	}
	
	// Export UTdUIScene_VideoSettingsPC::execGetAntiAliasingString(FFrame&, void* const)
	public virtual /*private native final function */String GetAntiAliasingString(int MaxMultiSamples)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*private final function */int GetAAValue(String AAStr)
	{
		// stub
		return default;
	}
	
	// Export UTdUIScene_VideoSettingsPC::execApplyDetectedSettings(FFrame&, void* const)
	public virtual /*native final function */void ApplyDetectedSettings()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*function */void ResetSettingsToDefault()
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_VideoSettingsPC()
	{
		var Default__TdUIScene_VideoSettingsPC_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_VideoSettingsPC.SceneEventComponent' */;
		// Object Offset:0x0056A43B
		EventProvider = Default__TdUIScene_VideoSettingsPC_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_VideoSettingsPC.SceneEventComponent'*/;
	}
}
}