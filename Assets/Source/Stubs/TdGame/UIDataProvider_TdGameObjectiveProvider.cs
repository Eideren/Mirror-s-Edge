namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdGameObjectiveProvider : UIDataProvider_TdResource/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */SubObjectiveStruct
	{
		public /*config */name SubObjectiveName;
		public bool bIsFinished;
		public /*const config localized */string FriendlyName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006B817F
	//		SubObjectiveName = (name)"None";
	//		bIsFinished = false;
	//		FriendlyName = "";
	//	}
	};
	
	public /*const config localized */string FriendlyName;
	public /*const config localized */string Description;
	public /*config */string ImagePath;
	public /*config */array</*config */UIDataProvider_TdGameObjectiveProvider.SubObjectiveStruct> SubObjectives;
	public /*private transient */int CurrentActiveSubObjectiveIndex;
	
	public UIDataProvider_TdGameObjectiveProvider()
	{
		// Object Offset:0x006D8331
		CurrentActiveSubObjectiveIndex = -1;
	}
}
}