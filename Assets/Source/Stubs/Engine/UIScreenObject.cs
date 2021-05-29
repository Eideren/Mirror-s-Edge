namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIScreenObject : UIRoot/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public/*(Presentation)*/ UIRoot.UIScreenValue_Bounds Position;
	public/*(Presentation)*/ float ZDepth;
	public/*(Presentation)*/ /*private */bool bHidden;
	public /*transient */bool bInitialized;
	public/*(Focus)*/ /*private const */bool bNeverFocus;
	public /*const */bool bSupports3DPrimitives;
	public /*protected noimport */array<UIObject> Children;
	public /*const */array< Core.ClassT<UIState> > DefaultStates;
	public Core.ClassT<UIState> InitialState;
	public/*(States)*/ /*const export editinline */array</*export editinline */UIState> InactiveStates;
	public /*const transient */array<UIState> StateStack;
	public /*const transient */array<UIRoot.PlayerInteractionData> FocusControls;
	public/*(Focus)*/ /*transient */array<UIRoot.UIFocusPropagationData> FocusPropagation;
	public/*(Splitscreen)*/ byte PlayerInputMask;
	public/*(Presentation)*/ float Opacity;
	public /*export editinline */UIComp_Event EventProvider;
	public/*(Sound)*/ name FocusedCue;
	public/*(Sound)*/ name MouseEnterCue;
	public/*(Sound)*/ name NavigateUpCue;
	public/*(Sound)*/ name NavigateDownCue;
	public/*(Sound)*/ name NavigateLeftCue;
	public/*(Sound)*/ name NavigateRightCue;
	public /*delegate*/UIScreenObject.NotifyActiveSkinChanged __NotifyActiveSkinChanged__Delegate;
	public /*delegate*/UIScreenObject.OnRawInputKey __OnRawInputKey__Delegate;
	public /*delegate*/UIScreenObject.OnRawInputAxis __OnRawInputAxis__Delegate;
	public /*delegate*/UIScreenObject.OnProcessInputKey __OnProcessInputKey__Delegate;
	public /*delegate*/UIScreenObject.OnProcessInputAxis __OnProcessInputAxis__Delegate;
	public /*delegate*/UIScreenObject.NotifyPositionChanged __NotifyPositionChanged__Delegate;
	public /*delegate*/UIScreenObject.NotifyResolutionChanged __NotifyResolutionChanged__Delegate;
	public /*transient *//*delegate*/UIScreenObject.NotifyActiveStateChanged __NotifyActiveStateChanged__Delegate;
	public /*delegate*/UIScreenObject.NotifyVisibilityChanged __NotifyVisibilityChanged__Delegate;
	public /*delegate*/UIScreenObject.OnPreRenderCallBack __OnPreRenderCallBack__Delegate;
	
	public delegate void NotifyActiveSkinChanged();
	
	public delegate bool OnRawInputKey(/*const */ref UIRoot.InputEventParameters EventParms);
	
	public delegate bool OnRawInputAxis(/*const */ref UIRoot.InputEventParameters EventParms);
	
	public delegate bool OnProcessInputKey(/*const */ref UIRoot.SubscribedInputEventParameters EventParms);
	
	public delegate bool OnProcessInputAxis(/*const */ref UIRoot.SubscribedInputEventParameters EventParms);
	
	public delegate void NotifyPositionChanged(UIScreenObject Sender);
	
	public delegate void NotifyResolutionChanged(/*const */ref Object.Vector2D OldViewportsize, /*const */ref Object.Vector2D NewViewportSize);
	
	public delegate void NotifyActiveStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default);
	
	public delegate void NotifyVisibilityChanged(UIScreenObject SourceWidget, bool bIsVisible);
	
	public delegate void OnPreRenderCallBack();
	
	// Export UUIScreenObject::execIsInitialized(FFrame&, void* const)
	public virtual /*native final function */bool IsInitialized()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execCreatePlayerData(FFrame&, void* const)
	public virtual /*native final function */void CreatePlayerData(int PlayerIndex, LocalPlayer AddedPlayer)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execRemovePlayerData(FFrame&, void* const)
	public virtual /*native final function */void RemovePlayerData(int PlayerIndex, LocalPlayer RemovedPlayer)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execInitializePlayerTracking(FFrame&, void* const)
	public virtual /*native final function */void InitializePlayerTracking()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execGetPlayerOwner(FFrame&, void* const)
	public virtual /*native final function */LocalPlayer GetPlayerOwner(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execPlayUISound(FFrame&, void* const)
	public /*native final function */static bool PlayUISound(name SoundCueName, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execCreateWidget(FFrame&, void* const)
	public virtual /*native final function */UIObject CreateWidget(UIScreenObject Owner, Core.ClassT<UIObject> WidgetClass, /*optional */Object? _WidgetArchetype = default, /*optional */name? _WidgetName = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execInitialize(FFrame&, void* const)
	public virtual /*native final function */void Initialize(UIScene inOwnerScene, /*optional */UIObject? _inOwner = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execInsertChild(FFrame&, void* const)
	public virtual /*native function */int InsertChild(UIObject NewChild, /*optional */int? _InsertIndex = default, /*optional */bool? _bRenameExisting = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execRemoveChild(FFrame&, void* const)
	public virtual /*native final function */bool RemoveChild(UIObject ExistingChild, /*optional */array<UIObject>? _ExclusionSet = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execRemoveChildren(FFrame&, void* const)
	public virtual /*native final function */array<UIObject> RemoveChildren(array<UIObject> ChildrenToRemove)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execReplaceChild(FFrame&, void* const)
	public virtual /*native final function */bool ReplaceChild(UIObject ExistingChild, UIObject NewChild)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execFindChild(FFrame&, void* const)
	public virtual /*native final function */UIObject FindChild(name WidgetName, /*optional */bool? _bRecurse = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execFindChildUsingID(FFrame&, void* const)
	public virtual /*native final function */UIObject FindChildUsingID(UIRoot.WIDGET_ID WidgetID, /*optional */bool? _bRecurse = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execFindChildIndex(FFrame&, void* const)
	public virtual /*native final function */int FindChildIndex(name WidgetName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execContainsChild(FFrame&, void* const)
	public virtual /*native final function */bool ContainsChild(UIObject Child, /*optional */bool? _bRecurse = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execContainsChildOfClass(FFrame&, void* const)
	public virtual /*native final function */bool ContainsChildOfClass(Core.ClassT<UIObject> SearchClass, /*optional */bool? _bRecurse = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetChildren(FFrame&, void* const)
	public virtual /*native final function */array<UIObject> GetChildren(/*optional */bool? _bRecurse = default, /*optional */array<UIObject>? _ExclusionSet = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetObjectCount(FFrame&, void* const)
	public virtual /*native final function */int GetObjectCount()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execRequestSceneUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestSceneUpdate(bool bDockingStackChanged, bool bPositionsChanged, /*optional */bool? _bNavLinksOutdated = default, /*optional */bool? _bWidgetStylesChanged = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execRequestFormattingUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestFormattingUpdate()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execRequestPrimitiveReview(FFrame&, void* const)
	public virtual /*native final function */void RequestPrimitiveReview(bool bReinitializePrimitives, bool bReviewPrimitiveUsage)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execRebuildNavigationLinks(FFrame&, void* const)
	public virtual /*native function */void RebuildNavigationLinks()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execGetViewportOffset(FFrame&, void* const)
	public virtual /*native final function */bool GetViewportOffset(ref Object.Vector2D out_ViewportOffset)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetViewportScale(FFrame&, void* const)
	public virtual /*native final function */float GetViewportScale()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetViewportOrigin(FFrame&, void* const)
	public virtual /*native final function */bool GetViewportOrigin(ref Object.Vector2D out_ViewportOrigin)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetViewportSize(FFrame&, void* const)
	public virtual /*native final function */bool GetViewportSize(ref Object.Vector2D out_ViewportSize)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetViewportWidth(FFrame&, void* const)
	public virtual /*native final function */float GetViewportWidth()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetViewportHeight(FFrame&, void* const)
	public virtual /*native final function */float GetViewportHeight()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execActivateEventByClass(FFrame&, void* const)
	public virtual /*native final function */void ActivateEventByClass(int PlayerIndex, Core.ClassT<UIEvent> EventClassToActivate, /*optional */Object? _InEventActivator/* = default*/, /*optional */bool? _bActivateImmediately/* = default*/, /*optional */array<int>? _IndicesToActivate/* = default*/, /*optional */ref array<UIEvent> out_ActivatedEvents/* = default*/)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execFindEventsOfClass(FFrame&, void* const)
	public virtual /*native final function */void FindEventsOfClass(Core.ClassT<UIEvent> EventClassToFind, ref array<UIEvent> out_EventInstances, /*optional */UIState? _LimitScope = default, /*optional */bool? _bExactClass = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execSetEnabled(FFrame&, void* const)
	public virtual /*native function */bool SetEnabled(bool bEnabled, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetCurrentState(FFrame&, void* const)
	public virtual /*native final function */UIState GetCurrentState(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execHasActiveStateOfClass(FFrame&, void* const)
	public virtual /*native final function */bool HasActiveStateOfClass(Core.ClassT<UIState> StateClass, int PlayerIndex, /*optional */ref int StateIndex/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execActivateState(FFrame&, void* const)
	public virtual /*native final function */bool ActivateState(UIState StateToActivate, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execActivateStateByClass(FFrame&, void* const)
	public virtual /*native final function */bool ActivateStateByClass(Core.ClassT<UIState> StateToActivate, int PlayerIndex, /*optional */ref UIState StateThatWasAdded/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execDeactivateState(FFrame&, void* const)
	public virtual /*native final function */bool DeactivateState(UIState StateToRemove, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execDeactivateStateByClass(FFrame&, void* const)
	public virtual /*native final function */bool DeactivateStateByClass(Core.ClassT<UIState> StateToRemove, int PlayerIndex, /*optional */ref UIState StateThatWasRemoved/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execConditionalPropagateEnabledState(FFrame&, void* const)
	public virtual /*native final function */bool ConditionalPropagateEnabledState(int PlayerIndex, /*optional */bool? _bForce = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execIsHoldingCtrl(FFrame&, void* const)
	public virtual /*native final function */bool IsHoldingCtrl(int ControllerId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execIsHoldingAlt(FFrame&, void* const)
	public virtual /*native final function */bool IsHoldingAlt(int ControllerId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execIsHoldingShift(FFrame&, void* const)
	public virtual /*native final function */bool IsHoldingShift(int ControllerId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execFocusFirstControl(FFrame&, void* const)
	public virtual /*native function */bool FocusFirstControl(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execFocusLastControl(FFrame&, void* const)
	public virtual /*native function */bool FocusLastControl(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execNextControl(FFrame&, void* const)
	public virtual /*native function */bool NextControl(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execPrevControl(FFrame&, void* const)
	public virtual /*native function */bool PrevControl(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execNavigateFocus(FFrame&, void* const)
	public virtual /*native function */bool NavigateFocus(UIScreenObject Sender, UIRoot.EUIWidgetFace Direction, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execIsNeverFocused(FFrame&, void* const)
	public virtual /*native final function */bool IsNeverFocused()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execCanAcceptFocus(FFrame&, void* const)
	public virtual /*native function */bool CanAcceptFocus(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execCanPropagateFocusFor(FFrame&, void* const)
	public virtual /*native final function */bool CanPropagateFocusFor(UIObject TestChild)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execSetFocus(FFrame&, void* const)
	public virtual /*native function */bool SetFocus(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execSetFocusToChild(FFrame&, void* const)
	public virtual /*native function */bool SetFocusToChild(/*optional */UIObject? _ChildToFocus = default, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execKillFocus(FFrame&, void* const)
	public virtual /*native function */bool KillFocus(UIScreenObject Sender, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetFocusedControl(FFrame&, void* const)
	public virtual /*native final function */UIObject GetFocusedControl(/*optional */bool? _bRecurse = default, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetLastFocusedControl(FFrame&, void* const)
	public virtual /*native final function */UIObject GetLastFocusedControl(/*optional */bool? _bRecurse = default, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execOverrideLastFocusedControl(FFrame&, void* const)
	public virtual /*native final function */void OverrideLastFocusedControl(int PlayerIndex, UIObject ChildToFocus)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execIsEnabled(FFrame&, void* const)
	public virtual /*native final function */bool IsEnabled(/*optional */int? _PlayerIndex = default, /*optional */bool? _bCheckOwnerChain = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execIsFocused(FFrame&, void* const)
	public virtual /*native final function */bool IsFocused(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execIsActive(FFrame&, void* const)
	public virtual /*native final function */bool IsActive(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execIsPressed(FFrame&, void* const)
	public virtual /*native final function */bool IsPressed(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execAcceptsPlayerInput(FFrame&, void* const)
	public virtual /*native final function */bool AcceptsPlayerInput(int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetActivePlayerCount(FFrame&, void* const)
	public /*native final function */static int GetActivePlayerCount()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetSupportedPlayerCount(FFrame&, void* const)
	public virtual /*native final function */int GetSupportedPlayerCount()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetBestPlayerIndex(FFrame&, void* const)
	public virtual /*native final function */int GetBestPlayerIndex()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execSetPosition(FFrame&, void* const)
	public virtual /*native final function */void SetPosition(float NewValue, UIRoot.EUIWidgetFace Face, /*optional */UIRoot.EPositionEvalType? _InputType = default, /*optional */bool? _bZeroOrigin = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execGetPosition(FFrame&, void* const)
	public virtual /*native final function */float GetPosition(UIRoot.EUIWidgetFace Face, /*optional */UIRoot.EPositionEvalType? _OutputType = default, /*optional */bool? _bZeroOrigin = default, /*optional */bool? _bIgnoreDockPadding = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetBounds(FFrame&, void* const)
	public virtual /*native final function */float GetBounds(UIRoot.EUIOrientation Dimension, /*optional */UIRoot.EPositionEvalType? _OutputType = default, /*optional */bool? _bIgnoreDockPadding = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetPositionVector(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetPositionVector(/*optional */bool? _bIncludeParentPosition = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetDockedWidgets(FFrame&, void* const)
	public virtual /*native final function */void GetDockedWidgets(ref array<UIObject> out_DockedWidgets, /*optional */UIRoot.EUIWidgetFace? _SourceFace = default, /*optional */UIRoot.EUIWidgetFace? _TargetFace = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScreenObject::execProject(FFrame&, void* const)
	public virtual /*native final function */Object.Vector Project(/*const */ref Object.Vector CanvasPosition)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execDeProject(FFrame&, void* const)
	public virtual /*native final function */Object.Vector DeProject(/*const */ref Object.Vector PixelPosition)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Vector4 CanvasToScreen(/*const */ref Object.Vector CanvasPosition)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execScreenToPixel(FFrame&, void* const)
	public virtual /*native final function */Object.Vector2D ScreenToPixel(/*const */ref Object.Vector4 ScreenPosition)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execPixelToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Vector4 PixelToScreen(/*const */ref Object.Vector2D PixelPosition)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execScreenToCanvas(FFrame&, void* const)
	public virtual /*native final function */Object.Vector ScreenToCanvas(/*const */ref Object.Vector4 ScreenPosition)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execPixelToCanvas(FFrame&, void* const)
	public virtual /*native final function */Object.Vector PixelToCanvas(/*const */ref Object.Vector2D PixelPosition)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetCanvasToScreen()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetInverseCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetInverseCanvasToScreen()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetAspectRatioAutoScaleFactor(FFrame&, void* const)
	public virtual /*native final function */float GetAspectRatioAutoScaleFactor(/*optional */Font? _BaseFont = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScreenObject::execGetWidgetPathName(FFrame&, void* const)
	public virtual /*native final function */string GetWidgetPathName()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void Initialized()
	{
	
	}
	
	public virtual /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*event */void AddedChild(UIScreenObject WidgetOwner, UIObject NewChild)
	{
	
	}
	
	public virtual /*event */void RemovedChild(UIScreenObject WidgetOwner, UIObject OldChild, /*optional */array<UIObject>? _ExclusionSet = default)
	{
	
	}
	
	public virtual /*event */void RemovedFromParent(UIScreenObject WidgetOwner)
	{
	
	}
	
	public virtual /*event */bool IsLoggedIn(/*optional */int? _ControllerId = default, /*optional */bool? _bRequireOnlineLogin = default)
	{
	
		return default;
	}
	
	public virtual /*private final function */void PrivateSetVisibility(bool bVisible)
	{
	
	}
	
	public virtual /*event */void SetVisibility(bool bIsVisible)
	{
	
	}
	
	public virtual /*final function */bool IsVisible()
	{
	
		return default;
	}
	
	public virtual /*final function */bool IsHidden()
	{
	
		return default;
	}
	
	public virtual /*final event */void EnablePlayerInput(byte PlayerIndex, /*optional */bool? _bRecurse = default)
	{
	
	}
	
	public virtual /*final event */void DisablePlayerInput(byte PlayerIndex, /*optional */bool? _bRecurse = default)
	{
	
	}
	
	public virtual /*event */void SetInputMask(byte NewInputMask, /*optional */bool? _bRecurse = default)
	{
	
	}
	
	public virtual /*event */void GetSupportedUIActionKeyNames(ref array<name> out_KeyNames)
	{
	
	}
	
	public virtual /*function */UIScreenObject GetParent()
	{
	
		return default;
	}
	
	public virtual /*function */void OnChangeVisibility(UIAction_ChangeVisibility Action)
	{
	
	}
	
	public virtual /*final function */bool EnableWidget(int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*final function */bool DisableWidget(int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnConsoleCommand(UIAction_ConsoleCommand Action)
	{
	
	}
	
	public virtual /*function */int GetBestControllerId()
	{
	
		return default;
	}
	
	public virtual /*function */OnlineSubsystem.ELoginStatus GetLoginStatus(/*optional */int? _ControllerId = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool HasLinkConnection()
	{
	
		return default;
	}
	
	public virtual /*function */bool CanPlayOnline(/*optional */int? _ControllerId = default)
	{
	
		return default;
	}
	
	public virtual /*function */OnlineSubsystem.ENATType GetNATType()
	{
	
		return default;
	}
	
	public virtual /*function */void OnShowFriendsUI(UIAction_ShowFriendsUI Action)
	{
	
	}
	
	public virtual /*function */void OnShowPlayersUI(UIAction_ShowPlayersUI Action)
	{
	
	}
	
	public virtual /*function */void OnShowAchievementsUI(UIAction_ShowAchievementsUI Action)
	{
	
	}
	
	public virtual /*function */void OnShowFriendInviteUI(UIAction_ShowFriendInviteUI Action)
	{
	
	}
	
	public virtual /*function */void OnShowMessagesUI(UIAction_ShowMessagesUI Action)
	{
	
	}
	
	public virtual /*function */void OnShowFeedbackUI(UIAction_ShowFeedbackUI Action)
	{
	
	}
	
	public virtual /*function */void OnShowGamerCardUI(UIAction_ShowGamerCardUI Action)
	{
	
	}
	
	public virtual /*function */void OnShowContentMarketplaceUI(UIAction_ShowContentMarketplaceUI Action)
	{
	
	}
	
	public virtual /*function */void OnShowMembershipMarketplaceUI(UIAction_ShowMembershipMarketplaceUI Action)
	{
	
	}
	
	public virtual /*function */void OnSetControllerId(UIAction_SetControllerId Action)
	{
	
	}
	
	public virtual /*function */void LogCurrentState(int Indent)
	{
	
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