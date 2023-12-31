namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIObject : UIScreenObject/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public const int FIRST_DEFAULT_DATABINDING_INDEX = 100;
	public const int TOOLTIP_BINDING_INDEX = 100;
	public const int CONTEXTMENU_BINDING_INDEX = 101;
	
	[noimport] public UIRoot.WIDGET_ID WidgetID;
	[Category("Presentation")] [editconst] public name WidgetTag;
	[duplicatetransient, Const] public/*private*/ UIObject Owner;
	[duplicatetransient, Const] public/*private*/ UIScene OwnerScene;
	public UIRoot.UIStyleReference PrimaryStyle;
	[Category("Focus")] public UIRoot.UINavigationData NavigationTargets;
	[Category("Focus")] public int TabIndex;
	[Category("Presentation")] [editconst] public UIRoot.UIDockingSet DockTargets;
	[Category("Presentation")] [Const, editconst, transient] public/*private*/ StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ RenderBounds;
	[Category("Presentation")] [Const, editconst, transient] public/*private*/ StaticArray<Object.Vector2D, Object.Vector2D, Object.Vector2D, Object.Vector2D>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ RenderBoundsVertices;
	[Category("Presentation")] public UIRoot.UIRotation Rotation;
	[Category("Presentation")] public Object.Vector RenderOffset;
	public/*private*/ int PrivateFlags;
	[Category("Data")] public/*private*/ UIRoot.UIDataStoreBinding ToolTip;
	[Category("Data")] [editconst] public/*private*/ UIRoot.UIDataStoreBinding ContextMenuData;
	public UIObject AnimationParent;
	[transient] public Object.Vector AnimationPosition;
	[transient] public array<UIAnimation.UIAnimSeqRef> AnimStack;
	[transient] public array<UIStyleResolver> StyleSubscribers;
	public/*private*/ bool bEnableActiveCursorUpdates;
	[Const] public bool bSupportsPrimaryStyle;
	[Category("Debug")] public bool bDebugShowBounds;
	[Category("Debug")] public Object.Color DebugBoundsColor;
	public /*delegate*/UIObject.OnCreate __OnCreate__Delegate;
	public /*delegate*/UIObject.OnValueChanged __OnValueChanged__Delegate;
	public /*delegate*/UIObject.OnRefreshSubscriberValue __OnRefreshSubscriberValue__Delegate;
	public /*delegate*/UIObject.OnPressed __OnPressed__Delegate;
	public /*delegate*/UIObject.OnPressRepeat __OnPressRepeat__Delegate;
	public /*delegate*/UIObject.OnPressRelease __OnPressRelease__Delegate;
	public /*delegate*/UIObject.OnClicked __OnClicked__Delegate;
	public /*delegate*/UIObject.OnDoubleClick __OnDoubleClick__Delegate;
	public /*delegate*/UIObject.OnQueryToolTip __OnQueryToolTip__Delegate;
	public /*delegate*/UIObject.OnOpenContextMenu __OnOpenContextMenu__Delegate;
	public /*delegate*/UIObject.OnCloseContextMenu __OnCloseContextMenu__Delegate;
	public /*delegate*/UIObject.OnContextMenuItemSelected __OnContextMenuItemSelected__Delegate;
	public /*delegate*/UIObject.OnUIAnimEnd __OnUIAnimEnd__Delegate;
	
	public delegate void OnCreate(UIObject CreatedWidget, UIScreenObject CreatorContainer);
	
	public delegate void OnValueChanged(UIObject Sender, int PlayerIndex);
	
	public delegate bool OnRefreshSubscriberValue(UIObject Sender, int BindingIndex);
	
	public delegate void OnPressed(UIScreenObject EventObject, int PlayerIndex);
	
	public delegate void OnPressRepeat(UIScreenObject EventObject, int PlayerIndex);
	
	public delegate void OnPressRelease(UIScreenObject EventObject, int PlayerIndex);
	
	public delegate bool OnClicked(UIScreenObject EventObject, int PlayerIndex);
	
	public delegate void OnDoubleClick(UIScreenObject EventObject, int PlayerIndex);
	
	public delegate bool OnQueryToolTip(UIObject Sender, ref UIToolTip CustomToolTip);
	
	public delegate bool OnOpenContextMenu(UIObject Sender, int PlayerIndex, ref UIContextMenu CustomContextMenu);
	
	public delegate bool OnCloseContextMenu(UIContextMenu ContextMenu, int PlayerIndex);
	
	public delegate void OnContextMenuItemSelected(UIContextMenu ContextMenu, int PlayerIndex, int ItemIndex);
	
	// Export UUIObject::execSetDefaultDataBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDefaultDataBinding(String MarkupText, int BindingIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execGetDefaultDataBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDefaultDataBinding(int BindingIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execResolveDefaultDataBinding(FFrame&, void* const)
	public virtual /*native final function */bool ResolveDefaultDataBinding(int BindingIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execGetDefaultDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetDefaultDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execClearDefaultDataBinding(FFrame&, void* const)
	public virtual /*native final function */void ClearDefaultDataBinding(int BindingIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execGenerateSceneDataStoreMarkup(FFrame&, void* const)
	public virtual /*native function */String GenerateSceneDataStoreMarkup(/*optional */String? _Group = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execGetToolTipValue(FFrame&, void* const)
	public virtual /*native final function */String GetToolTipValue()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execHasTransform(FFrame&, void* const)
	public virtual /*native final function */bool HasTransform(/*optional */bool? _bIncludeParentTransforms = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execSetAnchorPosition(FFrame&, void* const)
	public virtual /*native final function */void SetAnchorPosition(Object.Vector NewAnchorPosition, /*optional */UIRoot.EPositionEvalType? _InputType = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execRotateWidget(FFrame&, void* const)
	public virtual /*native final function */void RotateWidget(Object.Rotator NewRotationAmount, /*optional */bool? _bAccumulateRotation = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execUpdateRotationMatrix(FFrame&, void* const)
	public virtual /*native final function */void UpdateRotationMatrix()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execGetAnchorPosition(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetAnchorPosition(/*optional */bool? _bRelativeToWidget = default, /*optional */bool? _bPixelSpace = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execGenerateTransformMatrix(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GenerateTransformMatrix(/*optional */bool? _bIncludeParentTransforms = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execGetRotationMatrix(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetRotationMatrix(/*optional */bool? _bIncludeParentRotations = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execNotifyValueChanged(FFrame&, void* const)
	public virtual /*native function */void NotifyValueChanged(/*optional */int? _PlayerIndex = default, /*optional */int? _NotifyFlags = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execIsContainedBy(FFrame&, void* const)
	public virtual /*native final function */bool IsContainedBy(UIObject TestWidget)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execSetDockTarget(FFrame&, void* const)
	public virtual /*native function */bool SetDockTarget(UIRoot.EUIWidgetFace SourceFace, UIScreenObject Target, UIRoot.EUIWidgetFace TargetFace)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execSetDockPadding(FFrame&, void* const)
	public virtual /*native function */bool SetDockPadding(UIRoot.EUIWidgetFace SourceFace, float PaddingValue, /*optional */UIRoot.EUIDockPaddingEvalType? _PaddingInputType = default, /*optional */bool? _bModifyPaddingScaleType = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execSetDockParameters(FFrame&, void* const)
	public virtual /*native final function */bool SetDockParameters(UIRoot.EUIWidgetFace SourceFace, UIScreenObject Target, UIRoot.EUIWidgetFace TargetFace, float PaddingValue, /*optional */UIRoot.EUIDockPaddingEvalType? _PaddingInputType = default, /*optional */bool? _bModifyPaddingScaleType = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execIsDockedTo(FFrame&, void* const)
	public virtual /*native final function */bool IsDockedTo(/*const */UIScreenObject TargetWidget, /*optional */UIRoot.EUIWidgetFace? _SourceFace = default, /*optional */UIRoot.EUIWidgetFace? _TargetFace = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execSetNavigationTarget(FFrame&, void* const)
	public virtual /*native final function */bool SetNavigationTarget(UIRoot.EUIWidgetFace Face, UIObject NewNavTarget)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execSetForcedNavigationTarget(FFrame&, void* const)
	public virtual /*native final function */bool SetForcedNavigationTarget(UIRoot.EUIWidgetFace Face, UIObject NavTarget, /*optional */bool? _bIsNullOverride = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execCanAcceptFocus(FFrame&, void* const)
	public override /*native function */bool CanAcceptFocus(/*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execIsPrivateBehaviorSet(FFrame&, void* const)
	public virtual /*native final function */bool IsPrivateBehaviorSet(int Behavior)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execSetPrivateBehavior(FFrame&, void* const)
	public virtual /*native final function */void SetPrivateBehavior(int Behavior, bool Value, /*optional */bool? _bRecurse = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execSetActiveCursorUpdate(FFrame&, void* const)
	public virtual /*native function */void SetActiveCursorUpdate(bool bShouldReceiveCursorUpdates)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execNeedsActiveCursorUpdates(FFrame&, void* const)
	public virtual /*native final function */bool NeedsActiveCursorUpdates()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execGetPositionExtents(FFrame&, void* const)
	public virtual /*native final function */void GetPositionExtents(ref float MinX, ref float MaxX, ref float MinY, ref float MaxY, /*optional */bool? _bIncludeRotation = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execGetPositionExtent(FFrame&, void* const)
	public virtual /*native final function */float GetPositionExtent(UIRoot.EUIWidgetFace Face, /*optional */bool? _bIncludeRotation = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execAddStyleSubscriber(FFrame&, void* const)
	public virtual /*native final function */void AddStyleSubscriber(/*const */ref UIStyleResolver Subscriber)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execRemoveStyleSubscriber(FFrame&, void* const)
	public virtual /*native final function */void RemoveStyleSubscriber(/*const */ref UIStyleResolver Subscriber)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execFindStyleSubscriberIndex(FFrame&, void* const)
	public virtual /*native final function */int FindStyleSubscriberIndex(/*const */ref UIStyleResolver Subscriber)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execFindStyleSubscriberIndexById(FFrame&, void* const)
	public virtual /*native final function */int FindStyleSubscriberIndexById(name StyleSubscriberId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execSetWidgetStyleByName(FFrame&, void* const)
	public virtual /*native final function */bool SetWidgetStyleByName(name StyleResolverTagToSet, name StyleFriendlyName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIObject::execTickAnim(FFrame&, void* const)
	public virtual /*native function */void TickAnim(float DeltaTime)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*final function */UIScene GetScene()
	{
		// stub
		return default;
	}
	
	public virtual /*final function */UIObject GetOwner()
	{
		// stub
		return default;
	}
	
	public override /*function */UIScreenObject GetParent()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void LogRenderBounds(int Indent)
	{
		// stub
	}
	
	public virtual /*function */void OnSetDatastoreBinding(UIAction_SetDatastoreBinding Action)
	{
		// stub
	}
	
	// Export UUIObject::execAnimSetOpacity(FFrame&, void* const)
	public virtual /*native function */void AnimSetOpacity(float NewOpacity)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execAnimSetVisibility(FFrame&, void* const)
	public virtual /*native function */void AnimSetVisibility(bool bIsVisible)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execAnimSetColor(FFrame&, void* const)
	public virtual /*native function */void AnimSetColor(Object.LinearColor NewColor)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execAnimSetPosition(FFrame&, void* const)
	public virtual /*native function */void AnimSetPosition(Object.Vector NewPosition)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execAnimSetRelPosition(FFrame&, void* const)
	public virtual /*native function */void AnimSetRelPosition(Object.Vector NewPosition, Object.Vector InitialPosition)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execAnimSetRotation(FFrame&, void* const)
	public virtual /*native function */void AnimSetRotation(Object.Rotator NewRotation)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execAnimSetScale(FFrame&, void* const)
	public virtual /*native function */void AnimSetScale(float NewScale)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execAnimSetLeft(FFrame&, void* const)
	public virtual /*native function */void AnimSetLeft(float NewLeft)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execAnimSetTop(FFrame&, void* const)
	public virtual /*native function */void AnimSetTop(float NewTop)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execAnimSetRight(FFrame&, void* const)
	public virtual /*native function */void AnimSetRight(float NewRight)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIObject::execAnimSetBottom(FFrame&, void* const)
	public virtual /*native function */void AnimSetBottom(float NewBottom)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*event */void PlayUIAnimation(name AnimName, /*optional */UIAnimationSeq _AnimSeqTemplate = default, /*optional */float? _PlaybackRate = default, /*optional */bool? _bLoop = default, /*optional */float? _InitialPosition = default)
	{
		// stub
	}
	
	public virtual /*event */void StopUIAnimation(name AnimName, /*optional */UIAnimationSeq _AnimSeq = default, /*optional */bool? _bFinalize = default)
	{
		// stub
	}
	
	public virtual /*event */void ClearUIAnimation(name AnimName, /*optional */UIAnimationSeq _AnimSeq = default)
	{
		// stub
	}
	
	public virtual /*event */void UIAnimEnd(int SeqIndex)
	{
		// stub
	}
	
	public delegate void OnUIAnimEnd(UIObject AnimTarget, int AnimIndex, UIAnimationSeq AnimSeq);
	
	public UIObject()
	{
		var Default__UIObject_WidgetInitializedEvent = new UIEvent_Initialized
		{
			// Object Offset:0x005D29A6
			OutputLinks = new array<SequenceOp.SeqOpOutputLink>
			{
				new SequenceOp.SeqOpOutputLink
				{
					Links = default,
					LinkDesc = "Output",
					bHasImpulse = false,
					bDisabled = false,
					bDisabledPIE = false,
					LinkedOp = default,
					ActivateDelay = 0.0f,
					DrawY = 0,
					bHidden = false,
				},
			},
			ObjClassVersion = 4,
		}/* Reference: UIEvent_Initialized'Default__UIObject.WidgetInitializedEvent' */;
		var Default__UIObject_WidgetEventComponent = new UIComp_Event
		{
			// Object Offset:0x002DC098
			DefaultEvents = new array<UIRoot.DefaultEventSpecification>
			{
				new UIRoot.DefaultEventSpecification
				{
					EventTemplate = LoadAsset<UIEvent_Initialized>("Default__UIObject.WidgetInitializedEvent")/*Ref UIEvent_Initialized'Default__UIObject.WidgetInitializedEvent'*/,
					EventState = default,
				},
			},
		}/* Reference: UIComp_Event'Default__UIObject.WidgetEventComponent' */;
		// Object Offset:0x002D7AA6
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultComboStyle",
			RequiredStyleClass = default,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
		TabIndex = -1;
		DockTargets = new UIRoot.UIDockingSet
		{
			OwnerWidget = default,
			TargetWidget = new StaticArray<UIObject, UIObject, UIObject, UIObject>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = default,
				[1] = default,
				[2] = default,
				[3] = default,
			},
			DockPadding = new UIRoot.UIScreenValue_DockPadding
			{
				PaddingValue = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[0] = 0.0f,
					[1] = 0.0f,
					[2] = 0.0f,
					[3] = 0.0f,
				},
				PaddingScaleType = new StaticArray<UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[0] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
					[1] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
					[2] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
					[3] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
				},
			},
			bLockWidthWhenDocked = false,
			bLockHeightWhenDocked = false,
			TargetFace = new StaticArray<UIRoot.EUIWidgetFace, UIRoot.EUIWidgetFace, UIRoot.EUIWidgetFace, UIRoot.EUIWidgetFace>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = default,
				[1] = default,
				[2] = default,
				[3] = default,
			},
			bResolved = new StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = 0,
				[1] = 0,
				[2] = 0,
				[3] = 0,
			},
			bLinking = new StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = 0,
				[1] = 0,
				[2] = 0,
				[3] = 0,
			},
		};
		Rotation = new UIRoot.UIRotation
		{
			Rotation = new Rotator
			{
				Pitch=0,
				Yaw=0,
				Roll=0
			},
			TransformMatrix = new Matrix
			{
				XPlane={X=0.0f,
				Y=1.0f,
				Z=0.0f,
				W=0.0f},
				YPlane={X=0.0f,
				Y=0.0f,
				Z=1.0f,
				W=0.0f},
				ZPlane={X=0.0f,
				Y=0.0f,
				Z=0.0f,
				W=1.0f},
				WPlane={X=1.0f,
				Y=0.0f,
				Z=0.0f,
				W=0.0f}
			},
			AnchorPosition = new UIRoot.UIAnchorPosition
			{
				ZDepth = 0.0f,
				Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
				{
					[0] = 0.0f,
					[1] = 0.0f,
				},
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
				{
					[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
					[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
				},
			},
			AnchorType = UIRoot.ERotationAnchor.RA_Center,
		};
		ToolTip = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property,
			MarkupString = "",
			BindingIndex = 100,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		ContextMenuData = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Collection,
			MarkupString = "",
			BindingIndex = 101,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		bSupportsPrimaryStyle = true;
		DebugBoundsColor = new Color
		{
			R=255,
			G=128,
			B=255,
			A=255
		};
		EventProvider = Default__UIObject_WidgetEventComponent/*Ref UIComp_Event'Default__UIObject.WidgetEventComponent'*/;
	}
}
}