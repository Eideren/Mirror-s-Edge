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
	public /*const localized */String WriteMessage;
	public /*const localized */String LongWriteMessage;
	public /*const localized */String ReadMessage;
	public /*const localized */String LongReadMessage;
	public /*const localized */String UploadMessage;
	public /*const localized */String DownloadMessage;
	public /*const localized */String CreatingSaveDataMessage;
	public /*const localized */String LoadingSaveDataMessage;
	public /*const localized */String CheckingSaveDataMessage;
	public /*const localized */String LoadingLevelMessage;
	public /*transient */MaterialInterface SaveMaterial;
	public /*transient */MaterialInterface SaveMaterialBlack;
	public /*transient */MaterialInterface LoadMaterial;
	public /*transient */MaterialInterface LoadMaterialBlack;
	
	public virtual /*function */void Setup(String Message, bool bSaving, /*optional */bool? _bBlack = default)
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