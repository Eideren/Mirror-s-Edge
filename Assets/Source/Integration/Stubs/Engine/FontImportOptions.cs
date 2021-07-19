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
		[Category] public String FontName;
		[Category] public float Height;
		[Category] public bool bEnableAntialiasing;
		[Category] public bool bEnableBold;
		[Category] public bool bEnableItalic;
		[Category] public bool bEnableUnderline;
		[Category] public FontImportOptions.EFontImportCharacterSet CharacterSet;
		[Category] public String Chars;
		[Category] public String UnicodeRange;
		[Category] public String CharsFilePath;
		[Category] public String CharsFileWildcard;
		[Category] public bool bCreatePrintableOnly;
		[Category] public Object.LinearColor ForegroundColor;
		[Category] public bool bEnableDropShadow;
		[Category] public int TexturePageWidth;
		[Category] public int TexturePageMaxHeight;
		[Category] public int XPadding;
		[Category] public int YPadding;
		[Category] public int ExtendBoxTop;
		[Category] public int ExtendBoxBottom;
		[Category] public int ExtendBoxRight;
		[Category] public int ExtendBoxLeft;
		[Category] public bool bEnableLegacyMode;
		[Category] public int Kerning;
		[Category] public bool bImportKerningPairs;
	
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
	
	[Category] public FontImportOptions.FontImportOptionsData Data;
	
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