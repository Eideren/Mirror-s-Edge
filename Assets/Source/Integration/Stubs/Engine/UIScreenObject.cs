namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIScreenObject : UIRoot/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	[Category("Presentation")] public UIRoot.UIScreenValue_Bounds Position;
	[Category("Presentation")] public float ZDepth;
	[Category("Presentation")] public/*private*/ bool bHidden;
	[transient] public bool bInitialized;
	[Category("Focus")] [Const] public/*private*/ bool bNeverFocus;
	[Const] public bool bSupports3DPrimitives;
	[noimport] public/*protected*/ array<UIObject> Children;
	[Const] public array< Core.ClassT<UIState> > DefaultStates;
	public Core.ClassT<UIState> InitialState;
	[Category("States")] [Const, export, editinline] public array</*export editinline */UIState> InactiveStates;
	[Const, transient] public array<UIState> StateStack;
	[Const, transient] public array<UIRoot.PlayerInteractionData> FocusControls;
	[Category("Focus")] [transient] public array<UIRoot.UIFocusPropagationData> FocusPropagation;
	[Category("Splitscreen")] public byte PlayerInputMask;
	[Category("Presentation")] public float Opacity;
	[export, editinline] public UIComp_Event EventProvider;
	[Category("Sound")] public name FocusedCue;
	[Category("Sound")] public name MouseEnterCue;
	[Category("Sound")] public name NavigateUpCue;
	[Category("Sound")] public name NavigateDownCue;
	[Category("Sound")] public name NavigateLeftCue;
	[Category("Sound")] public name NavigateRightCue;
	public /*delegate*/UIScreenObject.NotifyActiveSkinChanged __NotifyActiveSkinChanged__Delegate;
	public /*delegate*/UIScreenObject.OnRawInputKey __OnRawInputKey__Delegate;
	public /*delegate*/UIScreenObject.OnRawInputAxis __OnRawInputAxis__Delegate;
	public /*delegate*/UIScreenObject.OnProcessInputKey __OnProcessInputKey__Delegate;
	public /*delegate*/UIScreenObject.OnProcessInputAxis __OnProcessInputAxis__Delegate;
	public /*delegate*/UIScreenObject.NotifyPositionChanged __NotifyPositionChanged__Delegate;
	public /*delegate*/UIScreenObject.NotifyResolutionChanged __NotifyResolutionChanged__Delegate;
	[transient] public /*delegate*/UIScreenObject.NotifyActiveStateChanged __NotifyActiveStateChanged__Delegate;
	public /*delegate*/UIScreenObject.NotifyVisibilityChanged __NotifyVisibilityChanged__Delegate;
	public /*delegate*/UIScreenObject.OnPreRenderCallBack __OnPreRenderCallBack__Delegate;
	
	public delegate void NotifyActiveSkinChanged();
	
	public delegate bool OnRawInputKey(/*const */ref UIRoot.InputEventParameters EventParms);
	
	public delegate bool OnRawInputAxis(/*const */ref UIRoot.InputEventParameters EventParms);
	
	public delegate bool OnProcessInputKey(/*const */ref UIRoot.SubscribedInputEventParameters EventParms);
	
	public delegate bool OnProcessInputAxis(/*const */ref UIRoot.SubscribedInputEventParameters EventParms);
	
	public delegate void NotifyPositionChanged(UIScreenObject Sender);
	
	public delegate void NotifyResolutionChanged(/*const */ref Object.Vector2D OldViewportsize, /*const */ref Object.Vector2D NewViewportSize);
	
	public delegate void NotifyActiveStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState _PreviouslyActiveState = default);
	
	public delegate void NotifyVisibilityChanged(UIScreenObject SourceWidget, bool bIsVisible);
	
	public delegate void OnPreRenderCallBack();
	
	// Export UUIScreenObject::execIsInitialized(FFrame&, void* const)
	public virtual /*native final function */bool IsInitialized()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execCreatePlayerData(FFrame&, void* const)
	public virtual /*native final function */void CreatePlayerData(int PlayerIndex, LocalPlayer AddedPlayer)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execRemovePlayerData(FFrame&, void* const)
	public virtual /*native final function */void RemovePlayerData(int PlayerIndex, LocalPlayer RemovedPlayer)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execInitializePlayerTracking(FFrame&, void* const)
	public virtual /*native final function */void InitializePlayerTracking()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execGetPlayerOwner(FFrame&, void* const)
	public virtual /*native final function */LocalPlayer GetPlayerOwner(/*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execPlayUISound(FFrame&, void* const)
	public /*native final function */static bool PlayUISound(name SoundCueName, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execCreateWidget(FFrame&, void* const)
	public virtual /*native final function */UIObject CreateWidget(UIScreenObject Owner, Core.ClassT<UIObject> WidgetClass, /*optional */Object _WidgetArchetype = default, /*optional */name? _WidgetName = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execInitialize(FFrame&, void* const)
	public virtual /*native final function */void Initialize(UIScene inOwnerScene, /*optional */UIObject _inOwner = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execInsertChild(FFrame&, void* const)
	public virtual /*native function */int InsertChild(UIObject NewChild, /*optional */int? _InsertIndex = default, /*optional */bool? _bRenameExisting = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execRemoveChild(FFrame&, void* const)
	public virtual /*native final function */bool RemoveChild(UIObject ExistingChild, /*optional */array<UIObject>? _ExclusionSet = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execRemoveChildren(FFrame&, void* const)
	public virtual /*native final function */array<UIObject> RemoveChildren(array<UIObject> ChildrenToRemove)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execReplaceChild(FFrame&, void* const)
	public virtual /*native final function */bool ReplaceChild(UIObject ExistingChild, UIObject NewChild)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execFindChild(FFrame&, void* const)
	public virtual /*native final function */UIObject FindChild(name WidgetName, /*optional */bool? _bRecurse = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execFindChildUsingID(FFrame&, void* const)
	public virtual /*native final function */UIObject FindChildUsingID(UIRoot.WIDGET_ID WidgetID, /*optional */bool? _bRecurse = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execFindChildIndex(FFrame&, void* const)
	public virtual /*native final function */int FindChildIndex(name WidgetName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execContainsChild(FFrame&, void* const)
	public virtual /*native final function */bool ContainsChild(UIObject Child, /*optional */bool? _bRecurse = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execContainsChildOfClass(FFrame&, void* const)
	public virtual /*native final function */bool ContainsChildOfClass(Core.ClassT<UIObject> SearchClass, /*optional */bool? _bRecurse = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetChildren(FFrame&, void* const)
	public virtual /*native final function */array<UIObject> GetChildren(/*optional */bool? _bRecurse = default, /*optional */array<UIObject>? _ExclusionSet = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetObjectCount(FFrame&, void* const)
	public virtual /*native final function */int GetObjectCount()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execRequestSceneUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestSceneUpdate(bool bDockingStackChanged, bool bPositionsChanged, /*optional */bool? _bNavLinksOutdated = default, /*optional */bool? _bWidgetStylesChanged = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execRequestFormattingUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestFormattingUpdate()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execRequestPrimitiveReview(FFrame&, void* const)
	public virtual /*native final function */void RequestPrimitiveReview(bool bReinitializePrimitives, bool bReviewPrimitiveUsage)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execRebuildNavigationLinks(FFrame&, void* const)
	public virtual /*native function */void RebuildNavigationLinks()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execGetViewportOffset(FFrame&, void* const)
	public virtual /*native final function */bool GetViewportOffset(ref Object.Vector2D out_ViewportOffset)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetViewportScale(FFrame&, void* const)
	public virtual /*native final function */float GetViewportScale()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetViewportOrigin(FFrame&, void* const)
	public virtual /*native final function */bool GetViewportOrigin(ref Object.Vector2D out_ViewportOrigin)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetViewportSize(FFrame&, void* const)
	public virtual /*native final function */bool GetViewportSize(ref Object.Vector2D out_ViewportSize)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetViewportWidth(FFrame&, void* const)
	public virtual /*native final function */float GetViewportWidth()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetViewportHeight(FFrame&, void* const)
	public virtual /*native final function */float GetViewportHeight()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execActivateEventByClass(FFrame&, void* const)
	public virtual /*native final function */void ActivateEventByClass(int PlayerIndex, Core.ClassT<UIEvent> EventClassToActivate, /*optional */Object _InEventActivator/* = default*/, /*optional */bool? _bActivateImmediately/* = default*/, /*optional */array<int>? _IndicesToActivate/* = default*/, /*optional */ref array<UIEvent> out_ActivatedEvents/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execFindEventsOfClass(FFrame&, void* const)
	public virtual /*native final function */void FindEventsOfClass(Core.ClassT<UIEvent> EventClassToFind, ref array<UIEvent> out_EventInstances, /*optional */UIState _LimitScope = default, /*optional */bool? _bExactClass = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execSetEnabled(FFrame&, void* const)
	public virtual /*native function */bool SetEnabled(bool bEnabled, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetCurrentState(FFrame&, void* const)
	public virtual /*native final function */UIState GetCurrentState(/*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execHasActiveStateOfClass(FFrame&, void* const)
	public virtual /*native final function */bool HasActiveStateOfClass(Core.ClassT<UIState> StateClass, int PlayerIndex, /*optional */ref int StateIndex/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execActivateState(FFrame&, void* const)
	public virtual /*native final function */bool ActivateState(UIState StateToActivate, int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execActivateStateByClass(FFrame&, void* const)
	public virtual /*native final function */bool ActivateStateByClass(Core.ClassT<UIState> StateToActivate, int PlayerIndex, /*optional */ref UIState StateThatWasAdded/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execDeactivateState(FFrame&, void* const)
	public virtual /*native final function */bool DeactivateState(UIState StateToRemove, int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execDeactivateStateByClass(FFrame&, void* const)
	public virtual /*native final function */bool DeactivateStateByClass(Core.ClassT<UIState> StateToRemove, int PlayerIndex, /*optional */ref UIState StateThatWasRemoved/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execConditionalPropagateEnabledState(FFrame&, void* const)
	public virtual /*native final function */bool ConditionalPropagateEnabledState(int PlayerIndex, /*optional */bool? _bForce = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execIsHoldingCtrl(FFrame&, void* const)
	public virtual /*native final function */bool IsHoldingCtrl(int ControllerId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execIsHoldingAlt(FFrame&, void* const)
	public virtual /*native final function */bool IsHoldingAlt(int ControllerId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execIsHoldingShift(FFrame&, void* const)
	public virtual /*native final function */bool IsHoldingShift(int ControllerId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execFocusFirstControl(FFrame&, void* const)
	public virtual /*native function */bool FocusFirstControl(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execFocusLastControl(FFrame&, void* const)
	public virtual /*native function */bool FocusLastControl(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execNextControl(FFrame&, void* const)
	public virtual /*native function */bool NextControl(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execPrevControl(FFrame&, void* const)
	public virtual /*native function */bool PrevControl(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execNavigateFocus(FFrame&, void* const)
	public virtual /*native function */bool NavigateFocus(UIScreenObject Sender, UIRoot.EUIWidgetFace Direction, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execIsNeverFocused(FFrame&, void* const)
	public virtual /*native final function */bool IsNeverFocused()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execCanAcceptFocus(FFrame&, void* const)
	public virtual /*native function */bool CanAcceptFocus(/*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execCanPropagateFocusFor(FFrame&, void* const)
	public virtual /*native final function */bool CanPropagateFocusFor(UIObject TestChild)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execSetFocus(FFrame&, void* const)
	public virtual /*native function */bool SetFocus(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execSetFocusToChild(FFrame&, void* const)
	public virtual /*native function */bool SetFocusToChild(/*optional */UIObject _ChildToFocus = default, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execKillFocus(FFrame&, void* const)
	public virtual /*native function */bool KillFocus(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetFocusedControl(FFrame&, void* const)
	public virtual /*native final function */UIObject GetFocusedControl(/*optional */bool? _bRecurse = default, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetLastFocusedControl(FFrame&, void* const)
	public virtual /*native final function */UIObject GetLastFocusedControl(/*optional */bool? _bRecurse = default, /*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execOverrideLastFocusedControl(FFrame&, void* const)
	public virtual /*native final function */void OverrideLastFocusedControl(int PlayerIndex, UIObject ChildToFocus)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execIsEnabled(FFrame&, void* const)
	public virtual /*native final function */bool IsEnabled(/*optional */int? _PlayerIndex = default, /*optional */bool? _bCheckOwnerChain = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execIsFocused(FFrame&, void* const)
	public virtual /*native final function */bool IsFocused(/*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execIsActive(FFrame&, void* const)
	public virtual /*native final function */bool IsActive(/*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execIsPressed(FFrame&, void* const)
	public virtual /*native final function */bool IsPressed(/*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execAcceptsPlayerInput(FFrame&, void* const)
	public virtual /*native final function */bool AcceptsPlayerInput(int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetActivePlayerCount(FFrame&, void* const)
	public /*native final function */static int GetActivePlayerCount()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetSupportedPlayerCount(FFrame&, void* const)
	public virtual /*native final function */int GetSupportedPlayerCount()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetBestPlayerIndex(FFrame&, void* const)
	public virtual /*native final function */int GetBestPlayerIndex()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execSetPosition(FFrame&, void* const)
	public virtual /*native final function */void SetPosition(float NewValue, UIRoot.EUIWidgetFace Face, /*optional */UIRoot.EPositionEvalType? _InputType = default, /*optional */bool? _bZeroOrigin = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execGetPosition(FFrame&, void* const)
	public virtual /*native final function */float GetPosition(UIRoot.EUIWidgetFace Face, /*optional */UIRoot.EPositionEvalType? _OutputType = default, /*optional */bool? _bZeroOrigin = default, /*optional */bool? _bIgnoreDockPadding = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetBounds(FFrame&, void* const)
	public virtual /*native final function */float GetBounds(UIRoot.EUIOrientation Dimension, /*optional */UIRoot.EPositionEvalType? _OutputType = default, /*optional */bool? _bIgnoreDockPadding = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetPositionVector(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetPositionVector(/*optional */bool? _bIncludeParentPosition = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetDockedWidgets(FFrame&, void* const)
	public virtual /*native final function */void GetDockedWidgets(ref array<UIObject> out_DockedWidgets, /*optional */UIRoot.EUIWidgetFace? _SourceFace = default, /*optional */UIRoot.EUIWidgetFace? _TargetFace = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScreenObject::execProject(FFrame&, void* const)
	public virtual /*native final function */Object.Vector Project(/*const */ref Object.Vector CanvasPosition)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execDeProject(FFrame&, void* const)
	public virtual /*native final function */Object.Vector DeProject(/*const */ref Object.Vector PixelPosition)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Vector4 CanvasToScreen(/*const */ref Object.Vector CanvasPosition)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execScreenToPixel(FFrame&, void* const)
	public virtual /*native final function */Object.Vector2D ScreenToPixel(/*const */ref Object.Vector4 ScreenPosition)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execPixelToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Vector4 PixelToScreen(/*const */ref Object.Vector2D PixelPosition)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execScreenToCanvas(FFrame&, void* const)
	public virtual /*native final function */Object.Vector ScreenToCanvas(/*const */ref Object.Vector4 ScreenPosition)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execPixelToCanvas(FFrame&, void* const)
	public virtual /*native final function */Object.Vector PixelToCanvas(/*const */ref Object.Vector2D PixelPosition)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetCanvasToScreen()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetInverseCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetInverseCanvasToScreen()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetAspectRatioAutoScaleFactor(FFrame&, void* const)
	public virtual /*native final function */float GetAspectRatioAutoScaleFactor(/*optional */Font _BaseFont = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScreenObject::execGetWidgetPathName(FFrame&, void* const)
	public virtual /*native final function */String GetWidgetPathName()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*event */void Initialized()
	{
		// stub
	}
	
	public virtual /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*event */void AddedChild(UIScreenObject WidgetOwner, UIObject NewChild)
	{
		// stub
	}
	
	public virtual /*event */void RemovedChild(UIScreenObject WidgetOwner, UIObject OldChild, /*optional */array<UIObject>? _ExclusionSet = default)
	{
		// stub
	}
	
	public virtual /*event */void RemovedFromParent(UIScreenObject WidgetOwner)
	{
		// stub
	}
	
	public virtual /*event */bool IsLoggedIn(/*optional */int? _ControllerId = default, /*optional */bool? _bRequireOnlineLogin = default)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void PrivateSetVisibility(bool bVisible)
	{
		// stub
	}
	
	public virtual /*event */void SetVisibility(bool bIsVisible)
	{
		// stub
	}
	
	public virtual /*final function */bool IsVisible()
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool IsHidden()
	{
		// stub
		return default;
	}
	
	public virtual /*final event */void EnablePlayerInput(byte PlayerIndex, /*optional */bool? _bRecurse = default)
	{
		// stub
	}
	
	public virtual /*final event */void DisablePlayerInput(byte PlayerIndex, /*optional */bool? _bRecurse = default)
	{
		// stub
	}
	
	public virtual /*event */void SetInputMask(byte NewInputMask, /*optional */bool? _bRecurse = default)
	{
		// stub
	}
	
	public virtual /*event */void GetSupportedUIActionKeyNames(ref array<name> out_KeyNames)
	{
		// stub
	}
	
	public virtual /*function */UIScreenObject GetParent()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnChangeVisibility(UIAction_ChangeVisibility Action)
	{
		// stub
	}
	
	public virtual /*final function */bool EnableWidget(int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool DisableWidget(int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnConsoleCommand(UIAction_ConsoleCommand Action)
	{
		// stub
	}
	
	public virtual /*function */int GetBestControllerId()
	{
		// stub
		return default;
	}
	
	public virtual /*function */OnlineSubsystem.ELoginStatus GetLoginStatus(/*optional */int? _ControllerId = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool HasLinkConnection()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CanPlayOnline(/*optional */int? _ControllerId = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */OnlineSubsystem.ENATType GetNATType()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnShowFriendsUI(UIAction_ShowFriendsUI Action)
	{
		// stub
	}
	
	public virtual /*function */void OnShowPlayersUI(UIAction_ShowPlayersUI Action)
	{
		// stub
	}
	
	public virtual /*function */void OnShowAchievementsUI(UIAction_ShowAchievementsUI Action)
	{
		// stub
	}
	
	public virtual /*function */void OnShowFriendInviteUI(UIAction_ShowFriendInviteUI Action)
	{
		// stub
	}
	
	public virtual /*function */void OnShowMessagesUI(UIAction_ShowMessagesUI Action)
	{
		// stub
	}
	
	public virtual /*function */void OnShowFeedbackUI(UIAction_ShowFeedbackUI Action)
	{
		// stub
	}
	
	public virtual /*function */void OnShowGamerCardUI(UIAction_ShowGamerCardUI Action)
	{
		// stub
	}
	
	public virtual /*function */void OnShowContentMarketplaceUI(UIAction_ShowContentMarketplaceUI Action)
	{
		// stub
	}
	
	public virtual /*function */void OnShowMembershipMarketplaceUI(UIAction_ShowMembershipMarketplaceUI Action)
	{
		// stub
	}
	
	public virtual /*function */void OnSetControllerId(UIAction_SetControllerId Action)
	{
		// stub
	}
	
	public virtual /*function */void LogCurrentState(int Indent)
	{
		// stub
	}
	
	public UIScreenObject()
	{
		// Object Offset:0x002D2763
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = 0.0f,
				[1] = 0.0f,
				[2] = 1.0f,
				[3] = 1.0f,
			},
			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
				[1] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
				[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
				[3] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
			},
			bInvalidated = new StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = 1,
				[1] = 1,
				[2] = 1,
				[3] = 1,
			},
			AspectRatioMode = UIRoot.EUIAspectRatioConstraint.UIASPECTRATIO_AdjustNone,
		};
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
		};
		InitialState = ClassT<UIState_Enabled>()/*Ref Class'UIState_Enabled'*/;
		PlayerInputMask = 255;
		Opacity = 1.0f;
		FocusedCue = (name)"Focused";
		NavigateUpCue = (name)"NavigateUp";
		NavigateDownCue = (name)"NavigateDown";
		NavigateLeftCue = (name)"NavigateLeft";
		NavigateRightCue = (name)"NavigateRight";
	}
}
}