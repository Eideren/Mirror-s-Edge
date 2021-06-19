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
	public /*transient */TdUIScene_VideoSettingsPC.ScreenResSetting OldResolution;
	public /*transient */TdUIScene_VideoSettingsPC.ScreenResSetting NewResolution;
	public int OldVSyncVal;
	public int OldTexDetailVal;
	public int OldGfxQualVal;
	public int OldAAVal;
	public int OldPhysXVal;
	public /*private transient */bool bSupportsCSAA;
	
	// Export UTdUIScene_VideoSettingsPC::execGetSupportedAAModes(FFrame&, void* const)
	public virtual /*native function */bool GetSupportedAAModes(ref array<String> AAModes)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIScene_VideoSettingsPC::execGetPhysXSupported(FFrame&, void* const)
	public virtual /*native function */bool GetPhysXSupported()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void DisableVideoSettings()
	{
	
	}
	
	public override /*function */void OnReset()
	{
	
	}
	
	public virtual /*function */void SetupCurrentSettings()
	{
	
	}
	
	public override /*function */void OnAccept()
	{
	
	}
	
	public virtual /*function */void OnAcceptForce()
	{
	
	}
	
	public virtual /*function */bool CheckPhysXChanged()
	{
	
		return default;
	}
	
	public virtual /*function */void PhysXChanged(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void PhysXChangedNotSupported(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void DisplayPhysXChangedMsgBox(TdUIScene_MessageBox MsgBox, String Message, String Title)
	{
	
	}
	
	public virtual /*function */void PhysXChangedMsgBox_PreSelection(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void PhysXChangedMsgBox_Selection(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void ApplyVideoSettings()
	{
	
	}
	
	// Export UTdUIScene_VideoSettingsPC::execGetAntiAliasingString(FFrame&, void* const)
	public virtual /*private native final function */String GetAntiAliasingString(int MaxMultiSamples)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*private final function */int GetAAValue(String AAStr)
	{
	
		return default;
	}
	
	// Export UTdUIScene_VideoSettingsPC::execApplyDetectedSettings(FFrame&, void* const)
	public virtual /*native final function */void ApplyDetectedSettings()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*function */void ResetSettingsToDefault()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
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