namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdKeyBindingHandler : Object/*
		native*/{
	public partial struct /*native transient */KeyBindWidgetButtonData
	{
		public /*init */UILabelButton KeyBindButton;
		public /*init */UIDataProvider KeyProvider;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0056C182
	//		KeyBindButton = default;
	//		KeyProvider = default;
	//	}
	};
	
	public partial struct /*native transient */KeyBindWidgetData
	{
		public /*init */UILabel ActionNameLabel;
		public /*init */array<TdKeyBindingHandler.KeyBindWidgetButtonData> KeyBindButtons;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0056C282
	//		ActionNameLabel = default;
	//		KeyBindButtons = default;
	//	}
	};
	
	public partial struct /*native */KeyBindData
	{
		public name KeyName;
		public String Command;
		public name PreviousBinding;
		public bool bBindIsPrimary;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0057EBE7
	//		KeyName = (name)"None";
	//		Command = "";
	//		PreviousBinding = (name)"None";
	//		bBindIsPrimary = false;
	//	}
	};
	
	public partial struct /*native */CurrentBindKeyStruct
	{
		public array<String> BoundButtonKeys;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0057ECF3
	//		BoundButtonKeys = default;
	//	}
	};
	
	public /*transient */array<TdKeyBindingHandler.KeyBindWidgetData> KeyBindWidgets;
	public /*transient */TdKeyBindingHandler.KeyBindData CurrKeyBindData;
	public /*transient */array<TdKeyBindingHandler.CurrentBindKeyStruct> CurrentBindings;
	public bool bSettingsWasChanged;
	public /*transient */bool bCurrentlyBindingKey;
	public /*transient */bool bPromptForBindStomp;
	public /*transient */UILabelButton CurrentBindingObject;
	public TdUIScene OwnerScene;
	public /*transient */TdUIScene_MessageBox BindKeyMessageBox;
	public /*transient */array<Input.KeyBind> CurrentBindingsMap;
	public /*delegate*/TdKeyBindingHandler.OnSettingsChangedDelegate __OnSettingsChangedDelegate__Delegate;
	public /*delegate*/TdKeyBindingHandler.IsAllowedBindingKey __IsAllowedBindingKey__Delegate;
	
	// Export UTdKeyBindingHandler::execRefreshBindingButtons(FFrame&, void* const)
	public virtual /*native function */void RefreshBindingButtons()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTdKeyBindingHandler::execGetBindKeyFromCommand(FFrame&, void* const)
	public virtual /*native function */String GetBindKeyFromCommand(String Command, ref int StartIdx)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public delegate void OnSettingsChangedDelegate();
	
	public delegate bool IsAllowedBindingKey(name Key);
	
	public virtual /*function */void Initialize(TdUIScene inOwnerScene, array<TdKeyBindingHandler.KeyBindWidgetData> InKeyBindWidgets, /*optional *//*delegate*/TdKeyBindingHandler.OnSettingsChangedDelegate? _OnChangedDelegate = default)
	{
		// stub
	}
	
	public virtual /*function */bool GetKeyBindIndicesFromObject(UIObject Sender, ref int WidgetsIndexResult, ref int ButtonsIndexResult)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ResetToDefaults()
	{
		// stub
	}
	
	public virtual /*function */bool OnBindButton_InputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnKeyBindButton_Clicked_MsgBoxInit(UIScene OpenedScene, bool bInitialAcivation)
	{
		// stub
	}
	
	public virtual /*function */bool OnBindKeyMessageBox_HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool BindingsHaveChanged()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsAlreadyBound(name KeyName)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SpawnBindStompWarningMessage()
	{
		// stub
	}
	
	public virtual /*function */void OnSpawnBindStompWarningMessage_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnMessageBox_BindOverwriteConfirm(TdUIScene_MessageBox MessageBox, int SelectedItem, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void CancelKeyBind()
	{
		// stub
	}
	
	public virtual /*function */void AttemptKeyBind()
	{
		// stub
	}
	
	public virtual /*function */void BindKey()
	{
		// stub
	}
	
	public virtual /*function */void UnbindKey(name BindName)
	{
		// stub
	}
	
	public virtual /*function */void FinishKeyBinding(bool bInPromptForBindStomp)
	{
		// stub
	}
	
	public virtual /*function */void OnFinisKeyBinding_MsgBoxClosed()
	{
		// stub
	}
	
	public virtual /*function */void FinishBinding()
	{
		// stub
	}
	
	public virtual /*function */bool AllActionsHaveBind()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
}
}