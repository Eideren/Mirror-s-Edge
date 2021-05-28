namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_LoadIndicator : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */bool bIsLoadingLevel;
	public /*transient */bool bIsDiscAccess;
	public /*transient */TdPlayerController PlayerController;
	public /*transient */TdUILoadIndicator IndicatorWidget;
	public /*const localized */string WriteMessage;
	public /*const localized */string LongWriteMessage;
	public /*const localized */string ReadMessage;
	public /*const localized */string LongReadMessage;
	public /*const localized */string UploadMessage;
	public /*const localized */string DownloadMessage;
	public /*const localized */string CreatingSaveDataMessage;
	public /*const localized */string LoadingSaveDataMessage;
	public /*const localized */string CheckingSaveDataMessage;
	public /*const localized */string LoadingLevelMessage;
	public /*transient */MaterialInterface SaveMaterial;
	public /*transient */MaterialInterface SaveMaterialBlack;
	public /*transient */MaterialInterface LoadMaterial;
	public /*transient */MaterialInterface LoadMaterialBlack;
	
	public virtual /*function */void Setup(string Message, bool bSaving, /*optional */bool bBlack = default)
	{
	
	}
	
	public TdUIScene_LoadIndicator()
	{
		// Object Offset:0x0055C818
		WriteMessage = "SAVING...";
		LongWriteMessage = "SAVING, PLEASE DON'T TURN THE SYSTEM OFF";
		ReadMessage = "LOADING...";
		LongReadMessage = "LOADING, PLEASE DON'T TURN THE SYSTEM OFF";
		UploadMessage = "UPLOADING";
		DownloadMessage = "DOWNLOADING";
		CreatingSaveDataMessage = "SAVING NEW SAVE DATA, PLEASE DON'T TURN THE SYSTEM OFF";
		LoadingSaveDataMessage = "LOADING SAVE DATA, PLEASE DON'T TURN THE SYSTEM OFF";
		CheckingSaveDataMessage = "CHECKING SAVE DATA, PLEASE DON'T TURN THE SYSTEM OFF";
		LoadingLevelMessage = "LOADING LEVEL";
		SaveMaterial = LoadAsset<Material>("TdUIResources.Materials.AnimationSaving")/*Ref Material'TdUIResources.Materials.AnimationSaving'*/;
		SaveMaterialBlack = LoadAsset<Material>("TdUIResources.Materials.AnimationSavingBlack")/*Ref Material'TdUIResources.Materials.AnimationSavingBlack'*/;
		LoadMaterial = LoadAsset<Material>("TdUIResources.Materials.AnimationLoading")/*Ref Material'TdUIResources.Materials.AnimationLoading'*/;
		LoadMaterialBlack = LoadAsset<Material>("TdUIResources.Materials.AnimationLoadingBlack")/*Ref Material'TdUIResources.Materials.AnimationLoadingBlack'*/;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_LoadIndicator.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_LoadIndicator.SceneEventComponent'*/;
	}
}
}