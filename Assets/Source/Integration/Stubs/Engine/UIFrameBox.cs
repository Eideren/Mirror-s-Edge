namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIFrameBox : UIContainer/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public enum EFrameBoxImage 
	{
		FBI_TopLeft,
		FBI_Top,
		FBI_TopRight,
		FBI_CenterLeft,
		FBI_Center,
		FBI_CenterRight,
		FBI_BottomLeft,
		FBI_Bottom,
		FBI_BottomRight,
		FBI_MAX
	};
	
	public partial struct /*native */CornerSizes
	{
		[Category] public StaticArray<float, float>/*[2]*/ TopLeft;
		[Category] public StaticArray<float, float>/*[2]*/ TopRight;
		[Category] public StaticArray<float, float>/*[2]*/ BottomLeft;
		[Category] public StaticArray<float, float>/*[2]*/ BottomRight;
		[Category] public float TopHeight;
		[Category] public float BottomHeight;
		[Category] public float CenterLeftWidth;
		[Category] public float CenterRightWidth;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00437C40
	//		TopLeft = new StaticArray<float, float>/*[2]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		TopRight = new StaticArray<float, float>/*[2]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		BottomLeft = new StaticArray<float, float>/*[2]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		BottomRight = new StaticArray<float, float>/*[2]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		TopHeight = 0.0f;
	//		BottomHeight = 0.0f;
	//		CenterLeftWidth = 0.0f;
	//		CenterRightWidth = 0.0f;
	//	}
	};
	
	[Category("Image")] [noclear, Const, export, editinline] public StaticArray<UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage>/*[9]*/ BackgroundImageComponent;
	[Category("Image")] [editinline] public UIFrameBox.CornerSizes BackgroundCornerSizes;
	
	public virtual /*final function */void SetBackgroundImage(UIFrameBox.EFrameBoxImage ImageToSet, Surface NewImage)
	{
		// stub
	}
	
	public UIFrameBox()
	{
		var Default__UIFrameBox_TemplateTopLeft = new UIComp_DrawImage
		{
			// Object Offset:0x005D181A
			StyleResolverTag = (name)"Top Left Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"PanelBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateTopLeft' */;
		var Default__UIFrameBox_TemplateTop = new UIComp_DrawImage
		{
			// Object Offset:0x005D179A
			StyleResolverTag = (name)"Top Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"PanelBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateTop' */;
		var Default__UIFrameBox_TemplateTopRight = new UIComp_DrawImage
		{
			// Object Offset:0x005D189A
			StyleResolverTag = (name)"Top Right Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"PanelBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateTopRight' */;
		var Default__UIFrameBox_TemplateCenterLeft = new UIComp_DrawImage
		{
			// Object Offset:0x005D169A
			StyleResolverTag = (name)"Center Left Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"PanelBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateCenterLeft' */;
		var Default__UIFrameBox_TemplateCenter = new UIComp_DrawImage
		{
			// Object Offset:0x005D161A
			StyleResolverTag = (name)"Center Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"PanelBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateCenter' */;
		var Default__UIFrameBox_TemplateCenterRight = new UIComp_DrawImage
		{
			// Object Offset:0x005D171A
			StyleResolverTag = (name)"Center Right Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"PanelBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateCenterRight' */;
		var Default__UIFrameBox_TemplateBottomLeft = new UIComp_DrawImage
		{
			// Object Offset:0x005D151A
			StyleResolverTag = (name)"Bottom Left Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"PanelBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateBottomLeft' */;
		var Default__UIFrameBox_TemplateBottom = new UIComp_DrawImage
		{
			// Object Offset:0x005D149A
			StyleResolverTag = (name)"Bottom Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"PanelBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateBottom' */;
		var Default__UIFrameBox_TemplateBottomRight = new UIComp_DrawImage
		{
			// Object Offset:0x005D159A
			StyleResolverTag = (name)"Bottom Right Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"PanelBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateBottomRight' */;
		var Default__UIFrameBox_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIFrameBox.WidgetEventComponent' */;
		// Object Offset:0x00437EF6
		BackgroundImageComponent = new StaticArray<UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage>/*[9]*/()
		{ 
			[0] = Default__UIFrameBox_TemplateTopLeft/*Ref UIComp_DrawImage'Default__UIFrameBox.TemplateTopLeft'*/,
			[1] = Default__UIFrameBox_TemplateTop/*Ref UIComp_DrawImage'Default__UIFrameBox.TemplateTop'*/,
			[2] = Default__UIFrameBox_TemplateTopRight/*Ref UIComp_DrawImage'Default__UIFrameBox.TemplateTopRight'*/,
			[3] = Default__UIFrameBox_TemplateCenterLeft/*Ref UIComp_DrawImage'Default__UIFrameBox.TemplateCenterLeft'*/,
			[4] = Default__UIFrameBox_TemplateCenter/*Ref UIComp_DrawImage'Default__UIFrameBox.TemplateCenter'*/,
			[5] = Default__UIFrameBox_TemplateCenterRight/*Ref UIComp_DrawImage'Default__UIFrameBox.TemplateCenterRight'*/,
			[6] = Default__UIFrameBox_TemplateBottomLeft/*Ref UIComp_DrawImage'Default__UIFrameBox.TemplateBottomLeft'*/,
			[7] = Default__UIFrameBox_TemplateBottom/*Ref UIComp_DrawImage'Default__UIFrameBox.TemplateBottom'*/,
			[8] = Default__UIFrameBox_TemplateBottomRight/*Ref UIComp_DrawImage'Default__UIFrameBox.TemplateBottomRight'*/,
	 	};
		BackgroundCornerSizes = new UIFrameBox.CornerSizes
		{
			TopLeft = new StaticArray<float, float>/*[2]*/()
			{
				[0] = 16.0f,
				[1] = 16.0f,
			},
			TopRight = new StaticArray<float, float>/*[2]*/()
			{
				[0] = 16.0f,
				[1] = 16.0f,
			},
			BottomLeft = new StaticArray<float, float>/*[2]*/()
			{
				[0] = 16.0f,
				[1] = 16.0f,
			},
			BottomRight = new StaticArray<float, float>/*[2]*/()
			{
				[0] = 16.0f,
				[1] = 16.0f,
			},
			TopHeight = 16.0f,
			BottomHeight = 16.0f,
			CenterLeftWidth = 16.0f,
			CenterRightWidth = 16.0f,
		};
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"PanelBackground",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
		};
		bSupportsPrimaryStyle = false;
		EventProvider = Default__UIFrameBox_WidgetEventComponent/*Ref UIComp_Event'Default__UIFrameBox.WidgetEventComponent'*/;
	}
}
}