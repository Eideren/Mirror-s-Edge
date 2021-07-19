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
	
	[transient] public/*private*/ UILabel TitleLabel;
	[transient] public/*private*/ UILabel MessageLabel;
	[transient] public/*private*/ UISafeRegionPanel SafeRegionPanel;
	[transient] public/*private*/ UIScrollFrame ScrollFrame;
	[transient] public/*private*/ UIPanel ScenePanel;
	[transient] public array<String> PotentialOptions;
	[transient] public array<TdUIScene_MessageBox.PotentialOptionKeys> PotentialOptionKeyMappings;
	[transient] public int DefaultOptionIdx;
	[transient] public float MinimumDisplayTime;
	[transient] public float DisplayTimeElapsed;
	[transient] public bool bCloseHasBeenInvoked;
	[transient] public bool bModalIsClosing;
	[transient] public bool bIsModal;
	[transient] public/*private*/ bool bHandleDeviceRemoved;
	[transient] public/*private*/ int SelectedOptionIndex;
	[transient] public/*private*/ int SelectedOptionPlayerIndex;
	[transient] public UIScene.ESceneTransitionAnim SceneTransitionAnimOveride;
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
		// stub
	}
	
	public virtual /*function */void SetPotentialOptionKeyMappings(array<TdUIScene_MessageBox.PotentialOptionKeys> InPotentialOptionKeyMappings)
	{
		// stub
	}
	
	public virtual /*function */void SetTitle(String NewTitle)
	{
		// stub
	}
	
	public virtual /*function */void SetMessage(String NewMessage)
	{
		// stub
	}
	
	public virtual /*function */void SetScale(float ScaleX, float ScaleY)
	{
		// stub
	}
	
	public virtual /*function */void ReSize()
	{
		// stub
	}
	
	public virtual /*function */void Close(/*optional */bool? _bOverrideTimeDelay = default, /*optional */bool? _bSimulateCancel = default, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public virtual /*function */void DisplayAcceptBox(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection _InSelectionDelegate = default)
	{
		// stub
	}
	
	public virtual /*function */void DisplayCancelBox(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection _InSelectionDelegate = default)
	{
		// stub
	}
	
	public virtual /*function */void DisplayAcceptCancelBox(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection _InSelectionDelegate = default, /*optional */bool? _RenderParents = default)
	{
		// stub
	}
	
	public virtual /*function */bool IsDeviceRemoved()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void DisplayAcceptCancelRetryBoxOnline(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection _InSelectionDelegate = default, /*optional */bool? _RenderParents = default)
	{
		// stub
	}
	
	public virtual /*function */void DisplayAcceptCancelRetryBox(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection _InSelectionDelegate = default, /*optional */bool? _RenderParents = default)
	{
		// stub
	}
	
	public virtual /*function */void DisplayModalBox(String Message, /*optional */String? _Title = default, /*optional */float? _InMinDisplayTime = default)
	{
		// stub
	}
	
	public override /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
		// stub
	}
	
	public virtual /*function */void Display(String Message, /*optional */String? _Title = default, /*optional *//*delegate*/TdUIScene_MessageBox.OnSelection _InSelectionDelegate = default, /*optional */bool? _RenderParents = default, /*optional */int? _InDefaultOptionIdx = default)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public override /*event */bool PlayInputKeyNotification(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OptionSelected(int OptionIdx, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene(/*optional *//*delegate*/UIScene.OnSceneDeactivated _SceneClosedDelegate = default)
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void OnOptionSelected(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */bool OnOptionButton_Clicked(UIScreenObject EventObject, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */int FindCancelButtonIndex(/*optional */String? _CancelButtonMarkupString = default)
	{
		// stub
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