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
	
	public /*private native const noexport */Object.Pointer VfTable_FTickableObject;
	public /*const transient */float TimeIntoMovie;
	public /*const transient */float TimeSinceLastFrame;
	public /*const transient */float HorizontalScale;
	public /*const transient */float VerticalScale;
	public /*const */bool bPaused;
	public /*const */bool bStopped;
	public/*(FlipBook)*/ bool bLooping;
	public/*(FlipBook)*/ bool bAutoPlay;
	public/*(FlipBook)*/ int HorizontalImages;
	public/*(FlipBook)*/ int VerticalImages;
	public/*(FlipBook)*/ TextureFlipBook.TextureFlipBookMethod FBMethod;
	public/*(FlipBook)*/ float FrameRate;
	public /*private */float FrameTime;
	public /*const transient */int CurrentRow;
	public /*const transient */int CurrentColumn;
	public /*const transient */float RenderOffsetU;
	public /*const transient */float RenderOffsetV;
	public /*native const */Object.Pointer ReleaseResourcesFence;
	
	// Export UTextureFlipBook::execPlay(FFrame&, void* const)
	public virtual /*native function */void Play()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTextureFlipBook::execPause(FFrame&, void* const)
	public virtual /*native function */void Pause()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTextureFlipBook::execStop(FFrame&, void* const)
	public virtual /*native function */void Stop()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTextureFlipBook::execSetCurrentFrame(FFrame&, void* const)
	public virtual /*native function */void SetCurrentFrame(int Row, int Col)
	{
		 // #warning NATIVE FUNCTION !
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