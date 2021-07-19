namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UITabButton : UILabelButton/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	[Category] [editconst, editinline] public/*protected*/ UITabPage TabPage;
	public /*delegate*/UITabButton.IsActivationAllowed __IsActivationAllowed__Delegate;
	
	public delegate bool IsActivationAllowed(UITabButton Sender, int PlayerIndex);
	
	public override /*event */void AddedChild(UIScreenObject WidgetOwner, UIObject NewChild)
	{
		// stub
	}
	
	public override /*event */void RemovedChild(UIScreenObject WidgetOwner, UIObject OldChild, /*optional */array<UIObject>? _ExclusionSet = default)
	{
		// stub
	}
	
	public override /*event */void RemovedFromParent(UIScreenObject WidgetOwner)
	{
		// stub
	}
	
	// Export UUITabButton::execCanActivateButton(FFrame&, void* const)
	public virtual /*native final function */bool CanActivateButton(int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUITabButton::execIsTargeted(FFrame&, void* const)
	public virtual /*native final function */bool IsTargeted(/*optional */int? _PlayerIndex/* = default*/, /*optional */ref int StateIndex/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */UITabPage GetTabPage()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState _PreviouslyActiveState = default)
	{
		// stub
	}
	
	public UITabButton()
	{
		var Default__UITabButton_LabelStringRenderer = new UIComp_DrawString
		{
			// Object Offset:0x005D1FD2
			StyleResolverTag = (name)"TabButtonCaptionStyle",
		}/* Reference: UIComp_DrawString'Default__UITabButton.LabelStringRenderer' */;
		var Default__UITabButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x005D1E22
			StyleResolverTag = (name)"TabButtonBackgroundStyle",
		}/* Reference: UIComp_DrawImage'Default__UITabButton.BackgroundImageTemplate' */;
		var Default__UITabButton_WidgetEventComponent = new UIComp_Event
		{
			// Object Offset:0x005D26C2
			DisabledEventAliases = new array<name>
			{
				(name)"NextControl",
				(name)"PrevControl",
				(name)"NavFocusUp",
				(name)"NavFocusDown",
				(name)"NavFocusLeft",
				(name)"NavFocusRight",
			},
		}/* Reference: UIComp_Event'Default__UITabButton.WidgetEventComponent' */;
		// Object Offset:0x00453F17
		StringRenderComponent = Default__UITabButton_LabelStringRenderer/*Ref UIComp_DrawString'Default__UITabButton.LabelStringRenderer'*/;
		BackgroundImageComponent = Default__UITabButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UITabButton.BackgroundImageTemplate'*/;
		PrivateFlags = 931;
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Active>(),
			ClassT<UIState_Pressed>(),
			ClassT<UIState_TargetedTab>(),
		};
		EventProvider = Default__UITabButton_WidgetEventComponent/*Ref UIComp_Event'Default__UITabButton.WidgetEventComponent'*/;
		__NotifyActiveStateChanged__Delegate = (Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState) => OnStateChanged(Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState);
	}
}
}