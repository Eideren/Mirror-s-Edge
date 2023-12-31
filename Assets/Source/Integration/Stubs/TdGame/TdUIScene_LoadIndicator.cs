namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_LoadIndicator : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public bool bIsLoadingLevel;
	[transient] public bool bIsDiscAccess;
	[transient] public TdPlayerController PlayerController;
	[transient] public TdUILoadIndicator IndicatorWidget;
	[Const, localized] public String WriteMessage;
	[Const, localized] public String LongWriteMessage;
	[Const, localized] public String ReadMessage;
	[Const, localized] public String LongReadMessage;
	[Const, localized] public String UploadMessage;
	[Const, localized] public String DownloadMessage;
	[Const, localized] public String CreatingSaveDataMessage;
	[Const, localized] public String LoadingSaveDataMessage;
	[Const, localized] public String CheckingSaveDataMessage;
	[Const, localized] public String LoadingLevelMessage;
	[transient] public MaterialInterface SaveMaterial;
	[transient] public MaterialInterface SaveMaterialBlack;
	[transient] public MaterialInterface LoadMaterial;
	[transient] public MaterialInterface LoadMaterialBlack;
	
	public virtual /*function */void Setup(String Message, bool bSaving, /*optional */bool? _bBlack = default)
	{
		// stub
	}
	
	public TdUIScene_LoadIndicator()
	{
		var Default__TdUIScene_LoadIndicator_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_LoadIndicator.SceneEventComponent' */;
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
		EventProvider = Default__TdUIScene_LoadIndicator_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_LoadIndicator.SceneEventComponent'*/;
	}
}
}