namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIInputConfiguration : UIRoot/*
		native
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public /*const config */array</*config */UIRoot.UIInputAliasClassMap> WidgetInputAliases;
	public /*const config */array</*config */UIRoot.UIAxisEmulationDefinition> AxisEmulationDefinitions;
	
	// Export UUIInputConfiguration::execLoadInputAliasClasses(FFrame&, void* const)
	public virtual /*native final function */void LoadInputAliasClasses()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public UIInputConfiguration()
	{
		// Object Offset:0x00438773
		WidgetInputAliases = new array</*config */UIRoot.UIInputAliasClassMap>
		{
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.ConsoleEntry",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NextControl",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"TAB",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UIButton",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Enter",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"SpaceBar",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_A",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Consume",
								LinkedInputKeys = default,
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Pressed",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_LeftX",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_LeftY",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_RightX",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_RightY",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Consume",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Escape",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_B",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UICheckbox",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Enter",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"SpaceBar",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NextControl",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"TAB",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UIList",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"SubmitListSelection",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Enter",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"MouseScrollUp",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"MouseScrollDown",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"SelectFirstElement",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Home",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"SelectLastElement",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"End",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"PageUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"PageUp",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"PageDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"PageDown",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"SelectAllItems",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"A",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UIEditBox",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NextControl",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"TAB",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"SubmitText",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Enter",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"DeleteCharacter",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Delete",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveCursorLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveCursorRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveCursorToLineStart",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Home",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveCursorToLineEnd",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"End",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"BackSpace",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"BackSpace",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Char",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"A",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"B",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"C",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"D",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"E",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"F",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"G",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"H",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"I",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"J",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"K",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"L",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"M",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"N",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"O",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"P",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Q",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"R",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"S",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"T",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"U",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"V",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"W",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"X",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Y",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Z",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"ZERO",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"ONE",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"TWO",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"THREE",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"FOUR",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"FIVE",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"SIX",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"SEVEN",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"EIGHT",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NINE",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NumPadZero",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NumPadOne",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NumPadTwo",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NumPadThree",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NumPadFour",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NumPadFive",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NumPadSix",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NumPadSeven",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NumPadEight",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"NumPadNine",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Multiply",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Add",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Subtract",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Decimal",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Divide",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Semicolon",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Equals",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Comma",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Underscore",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Period",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Slash",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Tilde",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftBracket",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Backslash",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"RightBracket",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Quote",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Character",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Consume",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftShift",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"RightShift",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftControl",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"RightControl",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftAlt",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"RightAlt",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"PrevControl",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"TAB",
										ModifierKeyFlags = 28,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UILabelButton",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Enter",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"SpaceBar",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_A",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UIOptionListBase",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UIPanel",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UIScrollbar",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UIScrollbarButton",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UIScrollbarMarkerButton",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"DecrementSliderValue",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"IncrementSliderValue",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Pressed",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"DragSlider",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"MouseY",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UIScrollFrame",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"ScrollUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"MouseScrollUp",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"ScrollDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"MouseScrollDown",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"ScrollLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Scrollright",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"PageUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"PageUp",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"PageDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"PageDown",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.UISlider",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NextControl",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"TAB",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"PrevControl",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"TAB",
										ModifierKeyFlags = 28,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"DecrementSliderValue",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"IncrementSliderValue",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"DragSlider",
								LinkedInputKeys = default,
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Pressed",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"DragSlider",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"MouseX",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"MouseY",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "TdGame.TdUITabButton",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "TdGame.TdUITextSlider",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"DecrementSliderValue",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"IncrementSliderValue",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "TdGame.UITdOptionButton",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NextControl",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"TAB",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"PrevControl",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"TAB",
										ModifierKeyFlags = 28,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "Engine.ScriptConsoleEntry",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NextControl",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"TAB",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "TdGame.TdUIDrawPlayersPanel",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_A",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Enter",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Active",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"LeftMouseButton",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "TdGame.TdUILobbyPlayerWidget",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "TdGame.TdUIPlayerSlotBase",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"Clicked",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_A",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"SpaceBar",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Enter",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "TdGame.TdUITabControl",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NextPage",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"PreviousPage",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
			new UIRoot.UIInputAliasClassMap
			{
				WidgetClassName = "TdGame.UITdShelfOptionButton",
				WidgetClass = default,
				WidgetStates = new array<UIRoot.UIInputAliasStateMap>
				{
					new UIRoot.UIInputAliasStateMap
					{
						StateClassName = "Engine.UIState_Focused",
						State = default,
						StateInputAliases = new array<UIRoot.UIInputActionAlias>
						{
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusUp",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Up",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Up",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusDown",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Down",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Down",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Left",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Left",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"NavFocusRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_DPad_Right",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"Gamepad_LeftStick_Right",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionLeft",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_LeftShoulder",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_LeftTrigger",
										ModifierKeyFlags = 56,
									},
								},
							},
							new UIRoot.UIInputActionAlias
							{
								InputAliasName = (name)"MoveSelectionRight",
								LinkedInputKeys = new array<UIRoot.RawInputKeyEventData>
								{
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_RightShoulder",
										ModifierKeyFlags = 56,
									},
									new UIRoot.RawInputKeyEventData
									{
										InputKeyName = (name)"XboxTypeS_RightTrigger",
										ModifierKeyFlags = 56,
									},
								},
							},
						},
					},
				},
			},
		};
		AxisEmulationDefinitions = new array</*config */UIRoot.UIAxisEmulationDefinition>
		{
			new UIRoot.UIAxisEmulationDefinition
			{
				AxisInputKey = (name)"MouseX",
				AdjacentAxisInputKey = (name)"MouseY",
				bEmulateButtonPress = false,
				InputKeyToEmulate = new StaticArray<name, name>/*[2]*/()
				{
					[0] = (name)"None",
					[1] = (name)"None",
				},
			},
			new UIRoot.UIAxisEmulationDefinition
			{
				AxisInputKey = (name)"MouseY",
				AdjacentAxisInputKey = (name)"MouseX",
				bEmulateButtonPress = false,
				InputKeyToEmulate = new StaticArray<name, name>/*[2]*/()
				{
					[0] = (name)"None",
					[1] = (name)"None",
				},
			},
			new UIRoot.UIAxisEmulationDefinition
			{
				AxisInputKey = (name)"XboxTypeS_LeftX",
				AdjacentAxisInputKey = (name)"XboxTypeS_LeftY",
				bEmulateButtonPress = true,
				InputKeyToEmulate = new StaticArray<name, name>/*[2]*/()
				{
					[0] = (name)"Gamepad_LeftStick_Right",
					[1] = (name)"Gamepad_LeftStick_Left",
				},
			},
			new UIRoot.UIAxisEmulationDefinition
			{
				AxisInputKey = (name)"XboxTypeS_LeftY",
				AdjacentAxisInputKey = (name)"XboxTypeS_LeftX",
				bEmulateButtonPress = true,
				InputKeyToEmulate = new StaticArray<name, name>/*[2]*/()
				{
					[0] = (name)"Gamepad_LeftStick_Up",
					[1] = (name)"Gamepad_LeftStick_Down",
				},
			},
			new UIRoot.UIAxisEmulationDefinition
			{
				AxisInputKey = (name)"XboxTypeS_RightX",
				AdjacentAxisInputKey = (name)"XboxTypeS_RightY",
				bEmulateButtonPress = true,
				InputKeyToEmulate = new StaticArray<name, name>/*[2]*/()
				{
					[0] = (name)"Gamepad_RightStick_Right",
					[1] = (name)"Gamepad_RightStick_Left",
				},
			},
			new UIRoot.UIAxisEmulationDefinition
			{
				AxisInputKey = (name)"XboxTypeS_RightY",
				AdjacentAxisInputKey = (name)"XboxTypeS_RightX",
				bEmulateButtonPress = true,
				InputKeyToEmulate = new StaticArray<name, name>/*[2]*/()
				{
					[0] = (name)"Gamepad_RightStick_Down",
					[1] = (name)"Gamepad_RightStick_Up",
				},
			},
		};
	}
}
}