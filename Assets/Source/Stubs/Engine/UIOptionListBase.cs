namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIOptionListBase : UIObject, 
		UIDataStorePublisher/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public const string UIKEY_MoveCursorLeft = "UIKEY_MoveCursorLeft";
	public const string UIKEY_MoveCursorRight = "UIKEY_MoveCursorRight";
	
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStorePublisher;
	public /*private */UIRoot.UIStyleReference DecrementStyle;
	public /*private */UIRoot.UIStyleReference IncrementStyle;
	public /*private const */UIOptionListButton DecrementButton;
	public /*private const */UIOptionListButton IncrementButton;
	public /*const */Core.ClassT<UIOptionListButton> OptionListButtonClass;
	public/*(Presentation)*/ UIRoot.UIScreenValue_Extent ButtonSpacing;
	public/*(Image)*/ /*const export editinline */UIComp_DrawImage BackgroundImageComponent;
	public/*(Data)*/ /*noclear const export editinline */UIComp_DrawString StringRenderComponent;
	public/*(Sound)*/ name IncrementCue;
	public/*(Sound)*/ name DecrementCue;
	public/*()*/ bool bWrapOptions;
	public/*(Data)*/ UIRoot.UIDataStoreBinding DataSource;
	public /*delegate*/UIOptionListBase.CreateCustomDecrementButton __CreateCustomDecrementButton__Delegate;
	public /*delegate*/UIOptionListBase.CreateCustomIncrementButton __CreateCustomIncrementButton__Delegate;
	
	public delegate UIOptionListButton CreateCustomDecrementButton(UIOptionListBase ButtonOwner);
	
	public delegate UIOptionListButton CreateCustomIncrementButton(UIOptionListBase ButtonOwner);
	
	// Export UUIOptionListBase::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIOptionListBase::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIOptionListBase::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIOptionListBase::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIOptionListBase::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIOptionListBase::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIOptionListBase::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIOptionListBase::execHasPrevValue(FFrame&, void* const)
	public virtual /*native function */bool HasPrevValue()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIOptionListBase::execHasNextValue(FFrame&, void* const)
	public virtual /*native function */bool HasNextValue()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIOptionListBase::execOnMoveSelectionLeft(FFrame&, void* const)
	public virtual /*native function */void OnMoveSelectionLeft(int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIOptionListBase::execOnMoveSelectionRight(FFrame&, void* const)
	public virtual /*native function */void OnMoveSelectionRight(int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*function */void Created(UIObject CreatedWidget, UIScreenObject CreatorContainer)
	{
		// stub
	}
	
	public override /*event */void Initialized()
	{
		// stub
	}
	
	public virtual /*function */void InitializeInternalControls()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonClicked(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public UIOptionListBase()
	{
		var Default__UIOptionListBase_DecrementButtonTemplate_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIOptionListBase.DecrementButtonTemplate.BackgroundImageTemplate' */;
		var Default__UIOptionListBase_DecrementButtonTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIOptionListBase.DecrementButtonTemplate.WidgetEventComponent' */;
		var Default__UIOptionListBase_DecrementButtonTemplate = new UIOptionListButton
		{
			// Object Offset:0x004472D8
			BackgroundImageComponent = Default__UIOptionListBase_DecrementButtonTemplate_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIOptionListBase.DecrementButtonTemplate.BackgroundImageTemplate'*/,
			WidgetTag = (name)"DecrementButton",
			TabIndex = 0,
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = 32.0f,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = Default__UIOptionListBase_DecrementButtonTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIOptionListBase.DecrementButtonTemplate.WidgetEventComponent'*/,
		}/* Reference: UIOptionListButton'Default__UIOptionListBase.DecrementButtonTemplate' */;
		var Default__UIOptionListBase_IncrementButtonTemplate_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIOptionListBase.IncrementButtonTemplate.BackgroundImageTemplate' */;
		var Default__UIOptionListBase_IncrementButtonTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIOptionListBase.IncrementButtonTemplate.WidgetEventComponent' */;
		var Default__UIOptionListBase_IncrementButtonTemplate = new UIOptionListButton
		{
			// Object Offset:0x004473BC
			BackgroundImageComponent = Default__UIOptionListBase_IncrementButtonTemplate_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIOptionListBase.IncrementButtonTemplate.BackgroundImageTemplate'*/,
			WidgetTag = (name)"IncrementButton",
			TabIndex = 1,
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = 224.0f,
				ScaleType = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
			},
			EventProvider = Default__UIOptionListBase_IncrementButtonTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIOptionListBase.IncrementButtonTemplate.WidgetEventComponent'*/,
		}/* Reference: UIOptionListButton'Default__UIOptionListBase.IncrementButtonTemplate' */;
		var Default__UIOptionListBase_BackgroundImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x004471A8
			StyleResolverTag = (name)"Background Image Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ButtonBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIOptionListBase.BackgroundImageTemplate' */;
		var Default__UIOptionListBase_LabelStringRenderer = new UIComp_DrawString
		{
			// Object Offset:0x00447228
			StyleResolverTag = (name)"Caption Style",
			StringStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultLabelButtonStyle",
			},
		}/* Reference: UIComp_DrawString'Default__UIOptionListBase.LabelStringRenderer' */;
		var Default__UIOptionListBase_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIOptionListBase.WidgetEventComponent' */;
		// Object Offset:0x00446AB1
		DecrementStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultIncrementButtonStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
		IncrementStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultDecrementButtonStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
		DecrementButton = Default__UIOptionListBase_DecrementButtonTemplate/*Ref UIOptionListButton'Default__UIOptionListBase.DecrementButtonTemplate'*/;
		IncrementButton = Default__UIOptionListBase_IncrementButtonTemplate/*Ref UIOptionListButton'Default__UIOptionListBase.IncrementButtonTemplate'*/;
		OptionListButtonClass = ClassT<UIOptionListButton>()/*Ref Class'UIOptionListButton'*/;
		BackgroundImageComponent = Default__UIOptionListBase_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIOptionListBase.BackgroundImageTemplate'*/;
		StringRenderComponent = Default__UIOptionListBase_LabelStringRenderer/*Ref UIComp_DrawString'Default__UIOptionListBase.LabelStringRenderer'*/;
		IncrementCue = (name)"SliderIncrement";
		DecrementCue = (name)"SliderDecrement";
		DataSource = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Collection,
			MarkupString = "",
			BindingIndex = -1,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		PrivateFlags = 1024;
		bSupportsPrimaryStyle = false;
		__OnCreate__Delegate = (CreatedWidget, CreatorContainer) => Created(CreatedWidget, CreatorContainer);
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[2] = 256.0f,
				[3] = 32.0f,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[2] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
				[3] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
		};
		Children = new array<UIObject>
		{
			Default__UIOptionListBase_DecrementButtonTemplate/*Ref UIOptionListButton'Default__UIOptionListBase.DecrementButtonTemplate'*/,
			Default__UIOptionListBase_IncrementButtonTemplate/*Ref UIOptionListButton'Default__UIOptionListBase.IncrementButtonTemplate'*/,
		};
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Active>(),
			ClassT<UIState_Pressed>(),
		};
		EventProvider = Default__UIOptionListBase_WidgetEventComponent/*Ref UIComp_Event'Default__UIOptionListBase.WidgetEventComponent'*/;
	}
}
}