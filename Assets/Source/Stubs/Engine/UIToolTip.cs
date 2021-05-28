namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIToolTip : UILabel/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*const transient */bool bPendingPositionUpdate;
	public /*const transient */bool bResolveToolTipPosition;
	public/*()*/ bool bFollowCursor;
	public/*()*/ bool bAutoHideOnInput;
	public /*const transient */float SecondsActive;
	public /*delegate*/UIToolTip.ActivateToolTip __ActivateToolTip__Delegate;
	public /*delegate*/UIToolTip.DeactivateToolTip __DeactivateToolTip__Delegate;
	public /*delegate*/UIToolTip.CanShowToolTip __CanShowToolTip__Delegate;
	
	public delegate UIToolTip ActivateToolTip(UIToolTip Sender);
	
	public delegate bool DeactivateToolTip();
	
	public delegate bool CanShowToolTip(UIToolTip Sender);
	
	// Export UUIToolTip::execBeginTracking(FFrame&, void* const)
	public virtual /*native final function */UIToolTip BeginTracking()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIToolTip::execEndTracking(FFrame&, void* const)
	public virtual /*native final function */bool EndTracking()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIToolTip::execUpdateToolTipPosition(FFrame&, void* const)
	public virtual /*native final function */void UpdateToolTipPosition()
	{
		#warning NATIVE FUNCTION !
	}
	
	public UIToolTip()
	{
		// Object Offset:0x0045929B
		bPendingPositionUpdate = true;
		bAutoHideOnInput = true;
		StringRenderComponent = new UIComp_DrawString
		{
			// Object Offset:0x005D20A2
			StyleResolverTag = (name)"ToolTip String Style",
			AutoSizeParameters = new StaticArray<UIRoot.AutoSizeData, UIRoot.AutoSizeData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
			{ 
				[0] = new UIRoot.AutoSizeData
				{
					Extent = new UIRoot.UIScreenValue_AutoSizeRegion
					{
						Value = new StaticArray<float, float>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/()
						{
							[1] = 0.30f,
							#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
						},
						EvalType = new StaticArray<UIRoot.EUIExtentEvalType, UIRoot.EUIExtentEvalType>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/()
						{
							[1] = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_PercentScene,
							#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
						},
					},
					bAutoSizeEnabled = true,
				},
				[1] = new UIRoot.AutoSizeData
				{
					bAutoSizeEnabled = true,
				},
	 		},
			TextStyleCustomization = new UIRoot.UITextStyleOverride
			{
				ClipMode = UIRoot.ETextClipMode.CLIP_Normal,
				bOverrideClipMode = true,
			},
			StringStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultToolTipStringStyle",
			},
		}/* Reference: UIComp_DrawString'Default__UIToolTip.LabelStringRenderer' */;
		LabelBackground = new UIComp_DrawImage
		{
			// Object Offset:0x005D1EF2
			StyleResolverTag = (name)"ToolTip Background Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultToolTipBackgroundStyle",
			},
		}/* Reference: UIComp_DrawImage'Default__UIToolTip.TooltipBackgroundRenderer' */;
		PrivateFlags = 986;
		EventProvider = default;
	}
}
}