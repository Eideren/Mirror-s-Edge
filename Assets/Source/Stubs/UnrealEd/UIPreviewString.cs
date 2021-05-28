namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIPreviewString : UIString/* within UIScreenObject*//*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public new UIScreenObject Outer => base.Outer as UIScreenObject;
	
	public /*private */UIState CurrentMenuState;
	public /*private const */Object.Vector2D PreviewViewportSize;
	
}
}