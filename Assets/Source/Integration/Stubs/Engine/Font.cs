namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Font : Object/*
		native
		hidecategories(Object)*/{
	public const int NULLCHARACTER = 127;
	
	public partial struct /*native atomic immutable */FontCharacter
	{
		[Category] public int StartU;
		[Category] public int StartV;
		[Category] public int USize;
		[Category] public int VSize;
		[Category] public byte TextureIndex;
		[Category] public int VerticalOffset;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B74CD
	//		StartU = 0;
	//		StartV = 0;
	//		USize = 0;
	//		VSize = 0;
	//		TextureIndex = 0;
	//		VerticalOffset = 0;
	//	}
	};
	
	public partial struct /*native export */FontKerningPair
	{
		public int Pair;
		public float Amount;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B7806
	//		Pair = 0;
	//		Amount = 0.0f;
	//	}
	};
	
	[Category] [editinline] public array</*editinline */Font.FontCharacter> Characters;
	public array<Texture2D> Textures;
	[native, Const] public/*private*/ /*map<0,0>*/map<object, object> CharRemap;
	public int IsRemapped;
	[Category] public int Kerning;
	[Category] public FontImportOptions.FontImportOptionsData ImportOptions;
	[transient] public int NumCharacters;
	[transient] public array<int> MaxCharHeight;
	[native] public array<Font.FontKerningPair> KerningPairs;
	[native] public array<int> KerningPairPageStarts;
	[transient] public bool bHasKerningPairs;
	
	// Export UFont::execGetResolutionPageIndex(FFrame&, void* const)
	public virtual /*native function */int GetResolutionPageIndex(float HeightTest)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UFont::execGetScalingFactor(FFrame&, void* const)
	public virtual /*native function */float GetScalingFactor(float HeightTest)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UFont::execGetAuthoredViewportHeight(FFrame&, void* const)
	public virtual /*native final function */float GetAuthoredViewportHeight(float ViewportHeight)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UFont::execGetMaxCharHeight(FFrame&, void* const)
	public virtual /*native function */float GetMaxCharHeight()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}