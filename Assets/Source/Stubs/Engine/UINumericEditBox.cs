namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UINumericEditBox : UIEditBox/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public/*(Style)*/ UIRoot.UIStyleReference IncrementStyle;
	public/*(Style)*/ UIRoot.UIStyleReference DecrementStyle;
	public /*private */UINumericEditBoxButton IncrementButton;
	public /*private */UINumericEditBoxButton DecrementButton;
	public/*(Text)*/ UIRoot.UIRangeData NumericValue;
	public/*(Text)*/ int DecimalPlaces;
	public/*(Buttons)*/ UIRoot.UIScreenValue_Bounds IncButton_Position;
	public/*(Buttons)*/ UIRoot.UIScreenValue_Bounds DecButton_Position;
	
	// Export UUINumericEditBox::execIncrementValue(FFrame&, void* const)
	public virtual /*native final function */void IncrementValue(UIScreenObject Sender, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUINumericEditBox::execDecrementValue(FFrame&, void* const)
	public virtual /*native final function */void DecrementValue(UIScreenObject Sender, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void Initialized()
	{
	
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	// Export UUINumericEditBox::execSetNumericValue(FFrame&, void* const)
	public virtual /*native final function */bool SetNumericValue(float NewValue, /*optional */bool bForceRefreshString = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUINumericEditBox::execGetNumericValue(FFrame&, void* const)
	public virtual /*native final function */float GetNumericValue()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public UINumericEditBox()
	{
		// Object Offset:0x00445167
		IncrementStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"ButtonBackground",
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
		DecrementStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"ButtonBackground",
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
		NumericValue = new UIRoot.UIRangeData
		{
			CurrentValue = 0.0f,
			MinValue = 0.0f,
			MaxValue = 100.0f,
			NudgeValue = 1.0f,
			bIntRange = false,
		};
		DecimalPlaces = 4;
		IncButton_Position = new UIRoot.UIScreenValue_Bounds
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
		DecButton_Position = new UIRoot.UIScreenValue_Bounds
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
		DataSource = new UIRoot.UIDataStoreBinding
		{
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_RangeProperty,
			MarkupString = "Numeric Editbox Text",
		};
		StringRenderComponent = LoadAsset<UIComp_DrawStringEditbox>("Default__UINumericEditBox.EditboxStringRenderer")/*Ref UIComp_DrawStringEditbox'Default__UINumericEditBox.EditboxStringRenderer'*/;
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UINumericEditBox.EditboxBackgroundTemplate")/*Ref UIComp_DrawImage'Default__UINumericEditBox.EditboxBackgroundTemplate'*/;
		CharacterSet = UIEditBox.EEditBoxCharacterSet.CHARSET_NumericOnly;
		PrivateFlags = 1024;
		EventProvider = LoadAsset<UIComp_Event>("Default__UINumericEditBox.WidgetEventComponent")/*Ref UIComp_Event'Default__UINumericEditBox.WidgetEventComponent'*/;
	}
}
}