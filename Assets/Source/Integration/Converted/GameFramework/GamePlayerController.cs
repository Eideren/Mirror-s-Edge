namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GamePlayerController : PlayerController/*
		abstract
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	// Export UGamePlayerController::execGetChapterStrings(FFrame&, void* const)
	public virtual /*native function */void GetChapterStrings(int eChapter, ref String ChapterName, ref String ActName)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*simulated function */void DisplayChapterTitle(int DisplayChapter, float TotalDisplayTime, float TotalFadeTime)
	{
		ClientDisplayChapterTitle(DisplayChapter, TotalDisplayTime, TotalFadeTime);
	}
	
	public virtual /*reliable client simulated function */void ClientDisplayChapterTitle(int DisplayChapter, float TotalDisplayTime, float TotalFadeTime)
	{
		/*local */String ChapterName = default, ActName = default;
	
		if(myHUD != default)
		{
			GetChapterStrings(DisplayChapter, ref/*probably?*/ ChapterName, ref/*probably?*/ ActName);
			((myHUD) as GameHUD).StartDrawingChapterTitle(ChapterName, ActName, TotalDisplayTime, TotalFadeTime);
		}
	}
	
	public GamePlayerController()
	{
	}
}
}