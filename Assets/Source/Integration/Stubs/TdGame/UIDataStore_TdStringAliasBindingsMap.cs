namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdStringAliasBindingsMap : UIDataStore_StringAliasMap/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public const int SABM_FIND_FIRST_BIND = -2;
	
	public partial struct /*native */ControllerMap
	{
		public name KeyName;
		public String XBoxMapping;
		public String PS3Mapping;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006E02D6
	//		KeyName = (name)"None";
	//		XBoxMapping = "";
	//		PS3Mapping = "";
	//	}
	};
	
	public partial struct /*native */BindCacheElement
	{
		public name KeyName;
		public String MappingString;
		public int FieldIndex;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006E03EA
	//		KeyName = (name)"None";
	//		MappingString = "";
	//		FieldIndex = 0;
	//	}
	};
	
	[config] public int FakePlatform;
	[transient] public bool bControllerConnected;
	[native, Const, transient] public Object.Map_Mirror CommandToBindNames;
	[config] public array</*config */UIDataStore_TdStringAliasBindingsMap.ControllerMap> ControllerMapArray;
	
	// Export UUIDataStore_TdStringAliasBindingsMap::execGetStringWithFieldName(FFrame&, void* const)
	public override /*native function */int GetStringWithFieldName(String FieldName, ref String MappedString)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdStringAliasBindingsMap::execGetBoundStringWithFieldName(FFrame&, void* const)
	public virtual /*native function */int GetBoundStringWithFieldName(String FieldName, ref String MappedString, /*optional */ref int StartIndex/* = default*/, /*optional */ref String BindString/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdStringAliasBindingsMap::execFindMappingInBoundKeyCache(FFrame&, void* const)
	public virtual /*protected native final function */bool FindMappingInBoundKeyCache(String Command, ref String MappingStr, ref int FieldIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdStringAliasBindingsMap::execAddMappingToBoundKeyCache(FFrame&, void* const)
	public virtual /*protected native final function */void AddMappingToBoundKeyCache(String Command, String MappingStr, int FieldIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIDataStore_TdStringAliasBindingsMap::execClearBoundKeyCache(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundKeyCache()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*event */void Registered(LocalPlayer PlayerOwner)
	{
		// stub
	}
	
	public override /*event */void Unregistered(LocalPlayer PlayerOwner)
	{
		// stub
	}
	
	public virtual /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
		// stub
	}
	
	public UIDataStore_TdStringAliasBindingsMap()
	{
		// Object Offset:0x006E0B4B
		FakePlatform = -1;
		ControllerMapArray = new array</*config */UIDataStore_TdStringAliasBindingsMap.ControllerMap>
		{
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_A",
				XBoxMapping = "Xenon_A",
				PS3Mapping = "PS3_A",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_B",
				XBoxMapping = "Xenon_B",
				PS3Mapping = "PS3_B",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_X",
				XBoxMapping = "Xenon_X",
				PS3Mapping = "PS3_X",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_Y",
				XBoxMapping = "Xenon_Y",
				PS3Mapping = "PS3_Y",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_Start",
				XBoxMapping = "Xenon_Start",
				PS3Mapping = "PS3_Start",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_Back",
				XBoxMapping = "Xenon_Back",
				PS3Mapping = "PS3_Back",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_LeftShoulder",
				XBoxMapping = "Xenon_LeftBumper",
				PS3Mapping = "PS3_LeftBumper",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_RightShoulder",
				XBoxMapping = "Xenon_RightBumper",
				PS3Mapping = "PS3_RightBumper",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_LeftTrigger",
				XBoxMapping = "Xenon_LeftTrigger",
				PS3Mapping = "PS3_LeftTrigger",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_RightTrigger",
				XBoxMapping = "Xenon_RightTrigger",
				PS3Mapping = "PS3_RightTrigger",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_DPad_Up",
				XBoxMapping = "Xenon_DPadUp",
				PS3Mapping = "PS3_DPadUp",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_DPad_Down",
				XBoxMapping = "Xenon_DPadDown",
				PS3Mapping = "PS3_DPadDown",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_DPad_Left",
				XBoxMapping = "Xenon_DPadLeft",
				PS3Mapping = "PS3_DPadLeft",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_DPad_Right",
				XBoxMapping = "Xenon_DPadRight",
				PS3Mapping = "PS3_DPadRight",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_LeftThumbstick",
				XBoxMapping = "Xenon_LeftStickButton",
				PS3Mapping = "PS3_LeftStickButton",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XBoxTypeS_RightThumbstick",
				XBoxMapping = "Xenon_RightStickButton",
				PS3Mapping = "PS3_RightStickButton",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XboxTypeS_LeftX",
				XBoxMapping = "Xenon_LeftStick",
				PS3Mapping = "PS3_LeftStick",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XboxTypeS_LeftY",
				XBoxMapping = "Xenon_LeftStick",
				PS3Mapping = "PS3_LeftStick",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XboxTypeS_RightX",
				XBoxMapping = "Xenon_RightStick",
				PS3Mapping = "PS3_RightStick",
			},
			new UIDataStore_TdStringAliasBindingsMap.ControllerMap
			{
				KeyName = (name)"GMS_XboxTypeS_RightY",
				XBoxMapping = "Xenon_RightStick",
				PS3Mapping = "PS3_RightStick",
			},
		};
		MenuInputMapArray = new array</*config */UIDataStore_StringAliasMap.UIMenuInputMap>
		{
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"None",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_MoveForward",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_MoveBackward",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_StrafeLeft",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_StrafeRight",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_Strafe",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_TurnLeft",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_TurnRight",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_LookUp",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_LookDown",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_Look_Gamepad",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_Pause",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_Fire",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_Jump",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_Crouch",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_Use",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_InGameMenu",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_LookBehind",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_ReactionTime",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_SwitchWeapon",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_ZoomWeapon",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_LookAt",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_WalkMod",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_Look_MouseX",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"GBA_Look_MouseY",
				Set = (name)"None",
				MappedText = "",
			},
		};
		Tag = (name)"StringAliasBindings";
	}
}
}