// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIKeyBindingList : TdUIWidgetList/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public partial struct /*native */BindKeyData
	{
		public name KeyName;
		public String Command;
		public PlayerInput PInput;
		public name PreviousBinding;
		public bool bBindIsPrimary;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0068A30B
	//		KeyName = (name)"None";
	//		Command = "";
	//		PInput = default;
	//		PreviousBinding = (name)"None";
	//		bBindIsPrimary = false;
	//	}
	};
	
	[transient] public TdUIKeyBindingList.BindKeyData CurrKeyBindData;
	[transient] public int NumButtons;
	[transient] public bool bCurrentlyBindingKey;
	[transient] public UIObject CurrentlyBindingObject;
	[transient] public TdUIScene_MessageBox BindKeyMessageBox;
	[transient] public array<String> CurrentBindings;
	[transient] public array<String> StoredBindings;
	[transient] public array<String> LocalizedFriendlyNames;
	
	// Export UTdUIKeyBindingList::execRefreshBindingLabels(FFrame&, void* const)
	public virtual /*native function */void RefreshBindingLabels()
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UTdUIKeyBindingList::execGetBindKeyFromCommand(FFrame&, void* const)
	public virtual /*native function */String GetBindKeyFromCommand(PlayerInput PInput, String Command, ref int StartIdx)
	{
		 NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*event */PlayerInput GetPlayerInput()
	{
	
		return default;
	}
	
	public virtual /*function */void ReloadDefaults()
	{
	
	}
	
	public virtual /*function */bool OnButton_InputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public override /*function */void ClickedScrollZone(UIScrollbar Sender, float PositionPerc, int PlayerIndex)
	{
	
	}
	
	public override /*function */bool ScrollVertical(UIScrollbar Sender, float PositionChange, /*optional */bool? _bPositionMaxed = default)
	{
	
		return default;
	}
	
	public override /*function */void SelectNextItem(/*optional */bool? _bWrap = default)
	{
	
	}
	
	public override /*function */void SelectPreviousItem(/*optional */bool? _bWrap = default)
	{
	
	}
	
	public virtual /*function */bool BindingsHaveChanged()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsAlreadyBound(name KeyName)
	{
	
		return default;
	}
	
	public virtual /*function */void SpawnBindStompWarningMessage()
	{
	
	}
	
	public virtual /*function */void OnMessageBox_BindOverwriteConfirm(TdUIScene_MessageBox MessageBox, int SelectedItem, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void AttemptKeyBind()
	{
	
	}
	
	public virtual /*function */void BindKey()
	{
	
	}
	
	public virtual /*function */void CancelKeyBind()
	{
	
	}
	
	public virtual /*function */void UnbindKey(name BindName)
	{
	
	}
	
	#warning override on a delegate removed
	public /*override*/ /*function */bool OnClicked(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnBindKeyMessageBox_HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public virtual /*function */void FinishKeyBinding(bool bPromptForBindStomp)
	{
	
	}
	
	public virtual /*function */void FinishBinding()
	{
	
	}
	
	public virtual /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIKeyBindingList()
	{
		var Default__TdUIKeyBindingList_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIKeyBindingList.WidgetEventComponent' */;
		// Object Offset:0x0068BE6D
		NumButtons = 2;
		EventProvider = Default__TdUIKeyBindingList_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIKeyBindingList.WidgetEventComponent'*/;
	}
}
}