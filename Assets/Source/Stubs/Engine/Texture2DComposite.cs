namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Texture2DComposite : Texture/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */SourceTexture2DRegion
	{
		public int OffsetX;
		public int OffsetY;
		public int SizeX;
		public int SizeY;
		public Texture2D Texture2D;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FDC62
	//		OffsetX = 0;
	//		OffsetY = 0;
	//		SizeX = 0;
	//		SizeY = 0;
	//		Texture2D = default;
	//	}
	};
	
	public array<Texture2DComposite.SourceTexture2DRegion> SourceRegions;
	public int MaxTextureSize;
	
	// Export UTexture2DComposite::execSourceTexturesFullyStreamedIn(FFrame&, void* const)
	public virtual /*native final function */bool SourceTexturesFullyStreamedIn()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTexture2DComposite::execUpdateCompositeTexture(FFrame&, void* const)
	public virtual /*native final function */void UpdateCompositeTexture(int NumMipsToGenerate)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTexture2DComposite::execResetSourceRegions(FFrame&, void* const)
	public virtual /*native final function */void ResetSourceRegions()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public Texture2DComposite()
	{
		// Object Offset:0x003FDE96
		NeverStream = true;
	}
}
}