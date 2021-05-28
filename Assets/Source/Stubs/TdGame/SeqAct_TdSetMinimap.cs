namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdSetMinimap : SequenceAction/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */MinimapMap
	{
		public/*()*/ Surface Image;
		public/*()*/ float imageHeight;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0049F954
	//		Image = default;
	//		imageHeight = 0.0f;
	//	}
	};
	
	public/*()*/ string minimapWidgetName;
	public/*()*/ array<SeqAct_TdSetMinimap.MinimapMap> maps;
	
	public SeqAct_TdSetMinimap()
	{
		// Object Offset:0x0049FA20
		ObjName = "Set Minimap Image";
		ObjCategory = "Takedown";
	}
}
}