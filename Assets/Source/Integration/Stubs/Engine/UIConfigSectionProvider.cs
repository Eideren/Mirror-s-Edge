namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIConfigSectionProvider : UIConfigProvider/* within UIConfigFileProvider*//*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public new UIConfigFileProvider Outer => base.Outer as UIConfigFileProvider;
	
	[transient] public String SectionName;
	
}
}