namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameHUD : HUD/*
		abstract
		transient
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public enum EGameHUDColor 
	{
		GHD_WHITE,
		GHD_BLACK,
		GHD_MAX
	};
	
	public float TotalTitleDrawTime;
	public float TotalTitleFadeTime;
	public float TitleDrawStartTime;
	public string ChapterTitleString;
	public string ActTitleString;
	
	public virtual /*function */void SetHUDDrawColor(GameHUD.EGameHUDColor eColor, /*optional */byte Alpha = default)
	{
	
	}
	
	public virtual /*simulated function */void StartDrawingChapterTitle(string ChapterName, string ActName, float TotalDrawTime, float TotalFadeTime)
	{
	
	}
	
	public virtual /*simulated function */void StopDrawingChapterTitle()
	{
	
	}
	
}
}