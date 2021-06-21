namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Font : Object/*
		native
		hidecategories(Object)*/{
	public const int NULLCHARACTER = 127;
	
	public partial struct /*native atomic immutable */FontCharacter
	{
		public/*()*/ int StartU;
		public/*()*/ int StartV;
		public/*()*/ int USize;
		public/*()*/ int VSize;
		public/*()*/ byte TextureIndex;
		public/*()*/ int VerticalOffset;
	
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
	
	public/*()*/ /*editinline */array</*editinline */Font.FontCharacter> Characters;
	public array<Texture2D> Textures;
	public /*private native const *//*map<0,0>*/map<object, object> CharRemap;
	public int IsRemapped;
	public/*()*/ int Kerning;
	public/*()*/ FontImportOptions.FontImportOptionsData ImportOptions;
	public /*transient */int NumCharacters;
	public /*transient */array<int> MaxCharHeight;
	public /*native */array<Font.FontKerningPair> KerningPairs;
	public /*native */array<int> KerningPairPageStarts;
	public /*transient */bool bHasKerningPairs;
	
	// Export UFont::execGetResolutionPageIndex(FFrame&, void* const)
	public virtual /*native function */int GetResolutionPageIndex(float HeightTest)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFont::execGetScalingFactor(FFrame&, void* const)
	public virtual /*native function */float GetScalingFactor(float HeightTest)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFont::execGetAuthoredViewportHeight(FFrame&, void* const)
	public virtual /*native final function */float GetAuthoredViewportHeight(float ViewportHeight)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFont::execGetMaxCharHeight(FFrame&, void* const)
	public virtual /*native function */float GetMaxCharHeight()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
}
}