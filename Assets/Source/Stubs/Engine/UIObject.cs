namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIObject : UIScreenObject/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public const int FIRST_DEFAULT_DATABINDING_INDEX = 100;
	public const int TOOLTIP_BINDING_INDEX = 100;
	public const int CONTEXTMENU_BINDING_INDEX = 101;
	
	public /*noimport */UIRoot.WIDGET_ID WidgetID;
	public/*(Presentation)*/ /*editconst */name WidgetTag;
	public /*private duplicatetransient const */UIObject Owner;
	public /*private duplicatetransient const */UIScene OwnerScene;
	public UIRoot.UIStyleReference PrimaryStyle;
	public/*(Focus)*/ UIRoot.UINavigationData NavigationTargets;
	public/*(Focus)*/ int TabIndex;
	public/*(Presentation)*/ /*editconst */UIRoot.UIDockingSet DockTargets;
	public/*(Presentation)*/ /*private const editconst transient */StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ RenderBounds;
	public/*(Presentation)*/ /*private const editconst transient */StaticArray<Object.Vector2D, Object.Vector2D, Object.Vector2D, Object.Vector2D>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ RenderBoundsVertices;
	public/*(Presentation)*/ UIRoot.UIRotation Rotation;
	public/*(Presentation)*/ Object.Vector RenderOffset;
	public /*private */int PrivateFlags;
	public/*(Data)*/ /*private */UIRoot.UIDataStoreBinding ToolTip;
	public/*(Data)*/ /*private editconst */UIRoot.UIDataStoreBinding ContextMenuData;
	public UIObject AnimationParent;
	public /*transient */Object.Vector AnimationPosition;
	public /*transient */array<UIAnimation.UIAnimSeqRef> AnimStack;
	public /*transient */array<UIStyleResolver> StyleSubscribers;
	public /*private */bool bEnableActiveCursorUpdates;
	public /*const */bool bSupportsPrimaryStyle;
	public/*(Debug)*/ bool bDebugShowBounds;
	public/*(Debug)*/ Object.Color DebugBoundsColor;
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
	public virtual /*native final function */void SetDefaultDataBinding(string MarkupText, int BindingIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execGetDefaultDataBinding(FFrame&, void* const)
	public virtual /*native final function */string GetDefaultDataBinding(int BindingIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execResolveDefaultDataBinding(FFrame&, void* const)
	public virtual /*native final function */bool ResolveDefaultDataBinding(int BindingIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execGetDefaultDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetDefaultDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execClearDefaultDataBinding(FFrame&, void* const)
	public virtual /*native final function */void ClearDefaultDataBinding(int BindingIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execGenerateSceneDataStoreMarkup(FFrame&, void* const)
	public virtual /*native function */string GenerateSceneDataStoreMarkup(/*optional */string Group = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execGetToolTipValue(FFrame&, void* const)
	public virtual /*native final function */string GetToolTipValue()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execHasTransform(FFrame&, void* const)
	public virtual /*native final function */bool HasTransform(/*optional */bool bIncludeParentTransforms = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execSetAnchorPosition(FFrame&, void* const)
	public virtual /*native final function */void SetAnchorPosition(Object.Vector NewAnchorPosition, /*optional */UIRoot.EPositionEvalType InputType = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execRotateWidget(FFrame&, void* const)
	public virtual /*native final function */void RotateWidget(Object.Rotator NewRotationAmount, /*optional */bool bAccumulateRotation = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execUpdateRotationMatrix(FFrame&, void* const)
	public virtual /*native final function */void UpdateRotationMatrix()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execGetAnchorPosition(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetAnchorPosition(/*optional */bool bRelativeToWidget = default, /*optional */bool bPixelSpace = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execGenerateTransformMatrix(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GenerateTransformMatrix(/*optional */bool bIncludeParentTransforms = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execGetRotationMatrix(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetRotationMatrix(/*optional */bool bIncludeParentRotations = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execNotifyValueChanged(FFrame&, void* const)
	public virtual /*native function */void NotifyValueChanged(/*optional */int PlayerIndex = default, /*optional */int NotifyFlags = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execIsContainedBy(FFrame&, void* const)
	public virtual /*native final function */bool IsContainedBy(UIObject TestWidget)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execSetDockTarget(FFrame&, void* const)
	public virtual /*native function */bool SetDockTarget(UIRoot.EUIWidgetFace SourceFace, UIScreenObject Target, UIRoot.EUIWidgetFace TargetFace)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execSetDockPadding(FFrame&, void* const)
	public virtual /*native function */bool SetDockPadding(UIRoot.EUIWidgetFace SourceFace, float PaddingValue, /*optional */UIRoot.EUIDockPaddingEvalType PaddingInputType = default, /*optional */bool bModifyPaddingScaleType = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execSetDockParameters(FFrame&, void* const)
	public virtual /*native final function */bool SetDockParameters(UIRoot.EUIWidgetFace SourceFace, UIScreenObject Target, UIRoot.EUIWidgetFace TargetFace, float PaddingValue, /*optional */UIRoot.EUIDockPaddingEvalType PaddingInputType = default, /*optional */bool bModifyPaddingScaleType = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execIsDockedTo(FFrame&, void* const)
	public virtual /*native final function */bool IsDockedTo(/*const */UIScreenObject TargetWidget, /*optional */UIRoot.EUIWidgetFace SourceFace = default, /*optional */UIRoot.EUIWidgetFace TargetFace = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execSetNavigationTarget(FFrame&, void* const)
	public virtual /*native final function */bool SetNavigationTarget(UIRoot.EUIWidgetFace Face, UIObject NewNavTarget)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execSetForcedNavigationTarget(FFrame&, void* const)
	public virtual /*native final function */bool SetForcedNavigationTarget(UIRoot.EUIWidgetFace Face, UIObject NavTarget, /*optional */bool bIsNullOverride = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execCanAcceptFocus(FFrame&, void* const)
	public override /*native function */bool CanAcceptFocus(/*optional */int PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execIsPrivateBehaviorSet(FFrame&, void* const)
	public virtual /*native final function */bool IsPrivateBehaviorSet(int Behavior)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execSetPrivateBehavior(FFrame&, void* const)
	public virtual /*native final function */void SetPrivateBehavior(int Behavior, bool Value, /*optional */bool bRecurse = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execSetActiveCursorUpdate(FFrame&, void* const)
	public virtual /*native function */void SetActiveCursorUpdate(bool bShouldReceiveCursorUpdates)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execNeedsActiveCursorUpdates(FFrame&, void* const)
	public virtual /*native final function */bool NeedsActiveCursorUpdates()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execGetPositionExtents(FFrame&, void* const)
	public virtual /*native final function */void GetPositionExtents(ref float MinX, ref float MaxX, ref float MinY, ref float MaxY, /*optional */bool bIncludeRotation = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execGetPositionExtent(FFrame&, void* const)
	public virtual /*native final function */float GetPositionExtent(UIRoot.EUIWidgetFace Face, /*optional */bool bIncludeRotation = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execAddStyleSubscriber(FFrame&, void* const)
	public virtual /*native final function */void AddStyleSubscriber(/*const */ref UIStyleResolver Subscriber)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execRemoveStyleSubscriber(FFrame&, void* const)
	public virtual /*native final function */void RemoveStyleSubscriber(/*const */ref UIStyleResolver Subscriber)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execFindStyleSubscriberIndex(FFrame&, void* const)
	public virtual /*native final function */int FindStyleSubscriberIndex(/*const */ref UIStyleResolver Subscriber)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execFindStyleSubscriberIndexById(FFrame&, void* const)
	public virtual /*native final function */int FindStyleSubscriberIndexById(name StyleSubscriberId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execSetWidgetStyleByName(FFrame&, void* const)
	public virtual /*native final function */bool SetWidgetStyleByName(name StyleResolverTagToSet, name StyleFriendlyName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIObject::execTickAnim(FFrame&, void* const)
	public virtual /*native function */void TickAnim(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*final function */UIScene GetScene()
	{
	
		return default;
	}
	
	public virtual /*final function */UIObject GetOwner()
	{
	
		return default;
	}
	
	public override /*function */UIScreenObject GetParent()
	{
	
		return default;
	}
	
	public virtual /*function */void LogRenderBounds(int Indent)
	{
	
	}
	
	public virtual /*function */void OnSetDatastoreBinding(UIAction_SetDatastoreBinding Action)
	{
	
	}
	
	// Export UUIObject::execAnimSetOpacity(FFrame&, void* const)
	public virtual /*native function */void AnimSetOpacity(float NewOpacity)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execAnimSetVisibility(FFrame&, void* const)
	public virtual /*native function */void AnimSetVisibility(bool bIsVisible)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execAnimSetColor(FFrame&, void* const)
	public virtual /*native function */void AnimSetColor(Object.LinearColor NewColor)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execAnimSetPosition(FFrame&, void* const)
	public virtual /*native function */void AnimSetPosition(Object.Vector NewPosition)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execAnimSetRelPosition(FFrame&, void* const)
	public virtual /*native function */void AnimSetRelPosition(Object.Vector NewPosition, Object.Vector InitialPosition)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execAnimSetRotation(FFrame&, void* const)
	public virtual /*native function */void AnimSetRotation(Object.Rotator NewRotation)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execAnimSetScale(FFrame&, void* const)
	public virtual /*native function */void AnimSetScale(float NewScale)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execAnimSetLeft(FFrame&, void* const)
	public virtual /*native function */void AnimSetLeft(float NewLeft)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execAnimSetTop(FFrame&, void* const)
	public virtual /*native function */void AnimSetTop(float NewTop)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execAnimSetRight(FFrame&, void* const)
	public virtual /*native function */void AnimSetRight(float NewRight)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIObject::execAnimSetBottom(FFrame&, void* const)
	public virtual /*native function */void AnimSetBottom(float NewBottom)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*event */void PlayUIAnimation(name AnimName, /*optional */UIAnimationSeq AnimSeqTemplate = default, /*optional */float PlaybackRate = default, /*optional */bool bLoop = default, /*optional */float InitialPosition = default)
	{
	
	}
	
	public virtual /*event */void StopUIAnimation(name AnimName, /*optional */UIAnimationSeq AnimSeq = default, /*optional */bool bFinalize = default)
	{
	
	}
	
	public virtual /*event */void ClearUIAnimation(name AnimName, /*optional */UIAnimationSeq AnimSeq = default)
	{
	
	}
	
	public virtual /*event */void UIAnimEnd(int SeqIndex)
	{
	
	}
	
	public delegate void OnUIAnimEnd(UIObject AnimTarget, int AnimIndex, UIAnimationSeq AnimSeq);
	
	public UIObject()
	{
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
		EventProvider = new UIComp_Event
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
	}
}
}