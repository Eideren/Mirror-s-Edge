// NO OVERWRITE

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
		public/*()*/ StaticArray<float, float>/*[2]*/ TopLeft;
		public/*()*/ StaticArray<float, float>/*[2]*/ TopRight;
		public/*()*/ StaticArray<float, float>/*[2]*/ BottomLeft;
		public/*()*/ StaticArray<float, float>/*[2]*/ BottomRight;
		public/*()*/ float TopHeight;
		public/*()*/ float BottomHeight;
		public/*()*/ float CenterLeftWidth;
		public/*()*/ float CenterRightWidth;
	
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
	
	public/*(Image)*/ /*noclear const export editinline */StaticArray<UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage>/*[9]*/ BackgroundImageComponent;
	public/*(Image)*/ /*editinline */UIFrameBox.CornerSizes BackgroundCornerSizes;
	
	public virtual /*final function */void SetBackgroundImage(UIFrameBox.EFrameBoxImage ImageToSet, Surface NewImage)
	{
	
	}
	
	public UIFrameBox()
	{
		// Object Offset:0x00437EF6
		BackgroundImageComponent = new StaticArray<UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage, UIComp_DrawImage>/*[9]*/()
		{ 
			[0] = new UIComp_DrawImage
			{
				// Object Offset:0x005D181A
				StyleResolverTag = (name)"Top Left Style",
				ImageStyle = new UIRoot.UIStyleReference
				{
					DefaultStyleTag = (name)"PanelBackground",
				},
			}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateTopLeft' */,
			[1] = new UIComp_DrawImage
			{
				// Object Offset:0x005D179A
				StyleResolverTag = (name)"Top Style",
				ImageStyle = new UIRoot.UIStyleReference
				{
					DefaultStyleTag = (name)"PanelBackground",
				},
			}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateTop' */,
			[2] = new UIComp_DrawImage
			{
				// Object Offset:0x005D189A
				StyleResolverTag = (name)"Top Right Style",
				ImageStyle = new UIRoot.UIStyleReference
				{
					DefaultStyleTag = (name)"PanelBackground",
				},
			}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateTopRight' */,
			[3] = new UIComp_DrawImage
			{
				// Object Offset:0x005D169A
				StyleResolverTag = (name)"Center Left Style",
				ImageStyle = new UIRoot.UIStyleReference
				{
					DefaultStyleTag = (name)"PanelBackground",
				},
			}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateCenterLeft' */,
			[4] = new UIComp_DrawImage
			{
				// Object Offset:0x005D161A
				StyleResolverTag = (name)"Center Style",
				ImageStyle = new UIRoot.UIStyleReference
				{
					DefaultStyleTag = (name)"PanelBackground",
				},
			}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateCenter' */,
			[5] = new UIComp_DrawImage
			{
				// Object Offset:0x005D171A
				StyleResolverTag = (name)"Center Right Style",
				ImageStyle = new UIRoot.UIStyleReference
				{
					DefaultStyleTag = (name)"PanelBackground",
				},
			}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateCenterRight' */,
			[6] = new UIComp_DrawImage
			{
				// Object Offset:0x005D151A
				StyleResolverTag = (name)"Bottom Left Style",
				ImageStyle = new UIRoot.UIStyleReference
				{
					DefaultStyleTag = (name)"PanelBackground",
				},
			}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateBottomLeft' */,
			[7] = new UIComp_DrawImage
			{
				// Object Offset:0x005D149A
				StyleResolverTag = (name)"Bottom Style",
				ImageStyle = new UIRoot.UIStyleReference
				{
					DefaultStyleTag = (name)"PanelBackground",
				},
			}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateBottom' */,
			[8] = new UIComp_DrawImage
			{
				// Object Offset:0x005D159A
				StyleResolverTag = (name)"Bottom Right Style",
				ImageStyle = new UIRoot.UIStyleReference
				{
					DefaultStyleTag = (name)"PanelBackground",
				},
			}/* Reference: UIComp_DrawImage'Default__UIFrameBox.TemplateBottomRight' */,
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
		EventProvider = LoadAsset<UIComp_Event>("Default__UIFrameBox.WidgetEventComponent")/*Ref UIComp_Event'Default__UIFrameBox.WidgetEventComponent'*/;
	}
}
}