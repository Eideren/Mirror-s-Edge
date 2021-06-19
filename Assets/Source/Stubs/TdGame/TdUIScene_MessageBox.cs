namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_MessageBox : TdUIScene_Overlay/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public const int MESSAGEBOX_MAX_POSSIBLE_OPTIONS = 4;
	public const string CANCEL_BUTTON_MARKUP_STRING = "<Strings:TdGameUI.TdButtonCallouts.Cancel>";
	
	public partial struct /*native */PotentialOptionKeys
	{
		public array<name> Keys;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0055F81F
	//		Keys = default;
	//	}
	};
	
	public /*private transient */UILabel TitleLabel;
	public /*private transient */UILabel MessageLabel;
	public /*private transient */UISafeRegionPanel SafeRegionPanel;
	public /*private transient */UIScrollFrame ScrollFrame;
	public /*private transient */UIPanel ScenePanel;
	public /*transient */array<String> PotentialOptions;
	public /*transient */array<TdUIScene_MessageBox.PotentialOptionKeys> PotentialOptionKeyMappings;
	public /*transient */int DefaultOptionIdx;
	public /*transient */float MinimumDisplayTime;
	public /*transient */float DisplayTimeElapsed;
	public /*transient */bool bCloseHasBeenInvoked;
	public /*transient */bool bModalIsClosing;
	public /*transient */bool bIsModal;
	public /*private transient */bool bHandleDeviceRemoved;
	public /*private transient */int SelectedOptionIndex;
	public /*private transient */int SelectedOptionPlayerIndex;
	public /*transient */UIScene.ESceneTransitionAnim SceneTransitionAnimOveride;
	public /*delegate*/TdUIScene_MessageBox.OnSelection __OnSelection__Delegate;
	public /*delegate*/TdUIScene_MessageBox.OnClosed __OnClosed__Delegate;
	public /*delegate*/TdUIScene_MessageBox.OnMBInputKey __OnMBInputKey__Delegate;
	public /*delegate*/TdUIScene_MessageBox.OnPreSelecting __OnPreSelecting__Delegate;
	public /*delegate*/TdUIScene_MessageBox.OnNotifyOptionSelected __OnNotifyOptionSelected__Delegate;
	
	public delegate void OnSelection(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex);
	
	public delegate void OnClosed();
	
	public delegate bool OnMBInputKey(/*const */ref UIRoot.InputEventParameters EventParms);
	
	public delegate void OnPreSelecting();
	
	public delegate void OnNotifyOptionSelected(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex);
	
	public virtual /*function */void SetPotentialOptions(array<String> InPotentialOptions, /*optional */array<TdUIScene_MessageBox.PotentialOptionKeys>? _InPotentialOptionKeyMappings = default)
	{
	
	}
	
	public virtual /*function */void SetPotentialOptionKeyMappings(array<TdUIScene_MessageBox.PotentialOptionKeys> InPotentialOptionKeyMappings)
	{
	
	}
	
	public virtual /*function */void SetTitle(String NewTitle)
	{
	
	}
	
	public virtual /*function */void SetMessage(String NewMessage)
	{
	
	}
	
	public virtual /*function */void SetScale(float ScaleX, float ScaleY)
	{
	
	}
	
	public virtual /*function */void ReSize()
	{
	
	}
	
	public virtual /*function */void Close(/*optional */bool? _bOverrideTimeDelay = default, /*optional */bool? _bSimulateCancel = default, /*optional */int? _PlayerIndex = default)
	{
	
	}
	
	public virtual /*function */void DisplayAcceptBox(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection? _InSelectionDelegate = default)
	{
	
	}
	
	public virtual /*function */void DisplayCancelBox(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection? _InSelectionDelegate = default)
	{
	
	}
	
	public virtual /*function */void DisplayAcceptCancelBox(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection? _InSelectionDelegate = default, /*optional */bool? _RenderParents = default)
	{
	
	}
	
	public virtual /*function */bool IsDeviceRemoved()
	{
	
		return default;
	}
	
	public virtual /*function */void DisplayAcceptCancelRetryBoxOnline(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection? _InSelectionDelegate = default, /*optional */bool? _RenderParents = default)
	{
	
	}
	
	public virtual /*function */void DisplayAcceptCancelRetryBox(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection? _InSelectionDelegate = default, /*optional */bool? _RenderParents = default)
	{
	
	}
	
	public virtual /*function */void DisplayModalBox(String Message, /*optional */String? _Title = default, /*optional */float? _InMinDisplayTime = default)
	{
	
	}
	
	public override /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
	
	}
	
	public virtual /*function */void Display(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection? _InSelectionDelegate = default, /*optional */bool? _RenderParents = default, /*optional */int? _InDefaultOptionIdx = default)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public override /*event */bool PlayInputKeyNotification(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public virtual /*function */void OptionSelected(int OptionIdx, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnCloseScene(/*optional *//*delegate*/UIScene.OnSceneDeactivated? _SceneClosedDelegate = default)
	{
	
	}
	
	public virtual /*function */void OnSceneClosed(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */void OnOptionSelected(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */bool OnOptionButton_Clicked(UIScreenObject EventObject, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */int FindCancelButtonIndex(/*optional */String? _CancelButtonMarkupString = default)
	{
	
		return default;
	}
	
	public TdUIScene_MessageBox()
	{
		var Default__TdUIScene_MessageBox_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_MessageBox.SceneEventComponent' */;
		// Object Offset:0x00561B49
		PotentialOptions = new array<String>
		{
			"<Strings:TdGameUI.TdButtonCallouts.OK>",
		};
		PotentialOptionKeyMappings = new array<TdUIScene_MessageBox.PotentialOptionKeys>
		{
			new TdUIScene_MessageBox.PotentialOptionKeys
			{
				Keys = new array<name>
				{
					(name)"XboxTypeS_B",
					(name)"Escape",
				},
			},
			new TdUIScene_MessageBox.PotentialOptionKeys
			{
				Keys = new array<name>
				{
					(name)"XboxTypeS_A",
					(name)"Enter",
				},
			},
			new TdUIScene_MessageBox.PotentialOptionKeys
			{
				Keys = new array<name>
				{
					(name)"XboxTypeS_X",
				},
			},
			new TdUIScene_MessageBox.PotentialOptionKeys
			{
				Keys = new array<name>
				{
					(name)"XboxTypeS_Y",
				},
			},
		};
		DefaultOptionIdx = -1;
		bPauseGameWhileActive = false;
		EventProvider = Default__TdUIScene_MessageBox_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_MessageBox.SceneEventComponent'*/;
	}
}
}