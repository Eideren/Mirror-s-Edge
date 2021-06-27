namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMapInfo : MapInfo/*
		native
		editinlinenew*/{
	public/*()*/ /*const */StaticMesh MapMesh;
	public/*()*/ /*const */Object.Vector WorldToMiniMapOrigo;
	public/*()*/ /*const */Object.Vector MapSpecificWidgetTranslation;
	public/*()*/ /*const */float MapSpecificWidgetScale;
	
	public TdMapInfo()
	{
		// Object Offset:0x0058D62A
		MapSpecificWidgetTranslation = new Vector
		{
			X=160.0f,
			Y=140.0f,
			Z=0.0f
		};
		MapSpecificWidgetScale = 0.0130f;
	}
}
}