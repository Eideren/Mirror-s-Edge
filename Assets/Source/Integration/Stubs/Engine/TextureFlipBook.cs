namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TextureFlipBook : Texture2D/*
		native
		hidecategories(Object,Object)*/{
	public enum TextureFlipBookMethod 
	{
		TFBM_UL_ROW,
		TFBM_UL_COL,
		TFBM_UR_ROW,
		TFBM_UR_COL,
		TFBM_LL_ROW,
		TFBM_LL_COL,
		TFBM_LR_ROW,
		TFBM_LR_COL,
		TFBM_RANDOM,
		TFBM_MAX
	};
	
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FTickableObject;
	[Const, transient] public float TimeIntoMovie;
	[Const, transient] public float TimeSinceLastFrame;
	[Const, transient] public float HorizontalScale;
	[Const, transient] public float VerticalScale;
	[Const] public bool bPaused;
	[Const] public bool bStopped;
	[Category("FlipBook")] public bool bLooping;
	[Category("FlipBook")] public bool bAutoPlay;
	[Category("FlipBook")] public int HorizontalImages;
	[Category("FlipBook")] public int VerticalImages;
	[Category("FlipBook")] public TextureFlipBook.TextureFlipBookMethod FBMethod;
	[Category("FlipBook")] public float FrameRate;
	public/*private*/ float FrameTime;
	[Const, transient] public int CurrentRow;
	[Const, transient] public int CurrentColumn;
	[Const, transient] public float RenderOffsetU;
	[Const, transient] public float RenderOffsetV;
	[native, Const] public Object.Pointer ReleaseResourcesFence;
	
	// Export UTextureFlipBook::execPlay(FFrame&, void* const)
	public virtual /*native function */void Play()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTextureFlipBook::execPause(FFrame&, void* const)
	public virtual /*native function */void Pause()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTextureFlipBook::execStop(FFrame&, void* const)
	public virtual /*native function */void Stop()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTextureFlipBook::execSetCurrentFrame(FFrame&, void* const)
	public virtual /*native function */void SetCurrentFrame(int Row, int Col)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public TextureFlipBook()
	{
		// Object Offset:0x003FE45B
		bLooping = true;
		bAutoPlay = true;
		HorizontalImages = 1;
		VerticalImages = 1;
		FrameRate = 4.0f;
		FrameTime = 0.250f;
		AddressX = Texture.TextureAddress.TA_Clamp;
		AddressY = Texture.TextureAddress.TA_Clamp;
	}
}
}