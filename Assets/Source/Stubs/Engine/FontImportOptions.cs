namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FontImportOptions : Object/*
		transient
		native
		hidecategories(Object)*/{
	public enum EFontImportCharacterSet 
	{
		FontICS_Default,
		FontICS_Ansi,
		FontICS_Symbol,
		FontICS_MAX
	};
	
	public partial struct /*native */FontImportOptionsData
	{
		public/*()*/ string FontName;
		public/*()*/ float Height;
		public/*()*/ bool bEnableAntialiasing;
		public/*()*/ bool bEnableBold;
		public/*()*/ bool bEnableItalic;
		public/*()*/ bool bEnableUnderline;
		public/*()*/ FontImportOptions.EFontImportCharacterSet CharacterSet;
		public/*()*/ string Chars;
		public/*()*/ string UnicodeRange;
		public/*()*/ string CharsFilePath;
		public/*()*/ string CharsFileWildcard;
		public/*()*/ bool bCreatePrintableOnly;
		public/*()*/ Object.LinearColor ForegroundColor;
		public/*()*/ bool bEnableDropShadow;
		public/*()*/ int TexturePageWidth;
		public/*()*/ int TexturePageMaxHeight;
		public/*()*/ int XPadding;
		public/*()*/ int YPadding;
		public/*()*/ int ExtendBoxTop;
		public/*()*/ int ExtendBoxBottom;
		public/*()*/ int ExtendBoxRight;
		public/*()*/ int ExtendBoxLeft;
		public/*()*/ bool bEnableLegacyMode;
		public/*()*/ int Kerning;
		public/*()*/ bool bImportKerningPairs;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B700B
	//		FontName = "Arial";
	//		Height = 16.0f;
	//		bEnableAntialiasing = true;
	//		bEnableBold = false;
	//		bEnableItalic = false;
	//		bEnableUnderline = false;
	//		CharacterSet = FontImportOptions.EFontImportCharacterSet.FontICS_Default;
	//		Chars = "";
	//		UnicodeRange = "";
	//		CharsFilePath = "";
	//		CharsFileWildcard = "";
	//		bCreatePrintableOnly = false;
	//		ForegroundColor = new LinearColor
	//		{
	//			R=1.0f,
	//			G=1.0f,
	//			B=1.0f,
	//			A=1.0f
	//		};
	//		bEnableDropShadow = false;
	//		TexturePageWidth = 256;
	//		TexturePageMaxHeight = 256;
	//		XPadding = 1;
	//		YPadding = 1;
	//		ExtendBoxTop = 0;
	//		ExtendBoxBottom = 0;
	//		ExtendBoxRight = 0;
	//		ExtendBoxLeft = 0;
	//		bEnableLegacyMode = false;
	//		Kerning = 0;
	//		bImportKerningPairs = false;
	//	}
	};
	
	public/*()*/ FontImportOptions.FontImportOptionsData Data;
	
	public FontImportOptions()
	{
		// Object Offset:0x0031F999
		Data = new FontImportOptions.FontImportOptionsData
		{
			FontName = "Arial",
			Height = 16.0f,
			bEnableAntialiasing = true,
			bEnableBold = false,
			bEnableItalic = false,
			bEnableUnderline = false,
			CharacterSet = FontImportOptions.EFontImportCharacterSet.FontICS_Default,
			Chars = "",
			UnicodeRange = "",
			CharsFilePath = "",
			CharsFileWildcard = "",
			bCreatePrintableOnly = false,
			ForegroundColor = new LinearColor
			{
				R=1.0f,
				G=1.0f,
				B=1.0f,
				A=1.0f
			},
			bEnableDropShadow = false,
			TexturePageWidth = 256,
			TexturePageMaxHeight = 256,
			XPadding = 1,
			YPadding = 1,
			ExtendBoxTop = 0,
			ExtendBoxBottom = 0,
			ExtendBoxRight = 0,
			ExtendBoxLeft = 0,
			bEnableLegacyMode = false,
			Kerning = 0,
			bImportKerningPairs = false,
		};
	}
}
}