namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_DrawStringEditbox : UIComp_DrawString/* within UIEditBox*//*
		native
		config(UI)
		editinlinenew
		hidecategories(Object)*/{
	public partial struct /*native transient */UIStringSelectionRegion
	{
		public /*init */int SelectionStartCharIndex;
		public /*init */int SelectionEndCharIndex;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E11A4
	//		SelectionStartCharIndex = -1;
	//		SelectionEndCharIndex = -1;
	//	}
	};
	
	public new UIEditBox Outer => base.Outer as UIEditBox;
	
	public /*private transient */String UserText;
	public/*(Presentation)*/ UIRoot.UIStringCaretParameters StringCaret;
	public /*transient */UIComp_DrawStringEditbox.UIStringSelectionRegion SelectionRegion;
	public /*config */Object.LinearColor SelectionTextColor;
	public /*config */Object.LinearColor SelectionBackgroundColor;
	public /*private native const transient */Object.Pointer CaretNode;
	public /*private const transient */int FirstCharacterPosition;
	public /*const transient */bool bRecalculateFirstCharacter;
	public /*const transient */float CaretOffset;
	
	// Export UUIComp_DrawStringEditbox::execSetUserText(FFrame&, void* const)
	public virtual /*native final function */bool SetUserText(String NewValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawStringEditbox::execGetUserTextLength(FFrame&, void* const)
	public virtual /*native final function */int GetUserTextLength()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawStringEditbox::execSetSelectionRange(FFrame&, void* const)
	public virtual /*native final function */bool SetSelectionRange(int StartIndex, int EndIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawStringEditbox::execSetSelectionStart(FFrame&, void* const)
	public virtual /*native final function */bool SetSelectionStart(int StartIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawStringEditbox::execSetSelectionEnd(FFrame&, void* const)
	public virtual /*native final function */bool SetSelectionEnd(int EndIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawStringEditbox::execClearSelection(FFrame&, void* const)
	public virtual /*native final function */bool ClearSelection()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawStringEditbox::execGetSelectionRange(FFrame&, void* const)
	public virtual /*native final function */bool GetSelectionRange(ref int out_StartIndex, ref int out_EndIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawStringEditbox::execGetSelectedText(FFrame&, void* const)
	public virtual /*native final function */String GetSelectedText()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public UIComp_DrawStringEditbox()
	{
		// Object Offset:0x002E1853
		StringCaret = new UIRoot.UIStringCaretParameters
		{
			bDisplayCaret = false,
			CaretType = UIRoot.EUIDefaultPenColor.UIPEN_White,
			CaretWidth = 1.0f,
			CaretStyle = (name)"DefaultCaretStyle",
			CaretPosition = 0,
			CaretMaterial = default,
		};
		SelectionRegion = new UIComp_DrawStringEditbox.UIStringSelectionRegion
		{
			SelectionStartCharIndex = -1,
			SelectionEndCharIndex = -1,
		};
		SelectionTextColor = new LinearColor
		{
			R=1.0f,
			G=1.0f,
			B=1.0f,
			A=1.0f
		};
		SelectionBackgroundColor = new LinearColor
		{
			R=0.0f,
			G=0.0f,
			B=0.0f,
			A=1.0f
		};
		StringClass = ClassT<UIEditboxString>()/*Ref Class'UIEditboxString'*/;
		TextStyleCustomization = new UIRoot.UITextStyleOverride
		{
			ClipMode = UIRoot.ETextClipMode.CLIP_Normal,
			ClipAlignment = UIRoot.EUIAlignment.UIALIGN_Right,
			bOverrideClipMode = true,
			bOverrideClipAlignment = true,
		};
		StringStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultEditboxStyle",
		};
	}
}
}