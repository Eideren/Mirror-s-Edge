namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdTutorialChallenge : UIDataProvider_TdResource/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public /*config */int ChallengeId;
	public /*const config localized */String FriendlyName;
	public /*const config localized */String Description;
	public /*config */String ImageMarkup;
	public /*config */array</*config */float> GradeTimeSeconds;
	
}
}