namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGameViewportClient : GameViewportClient/* within Engine*//*
		transient
		native
		config(Game)*/{
	public new Engine Outer => base.Outer as Engine;
	
	public TdUIInteraction ViewportUI;
	public Texture2D TransitionImage;
	public MaterialEffect FadeInEffect;
	public /*transient */MaterialInstanceConstant FadeInEffectMaterialInstance;
	public /*private transient */TdDebugMenu DebugMenu;
	
	public override /*event */bool Init(ref string OutError)
	{
	
		return default;
	}
	
	public virtual /*function */string GetHintMessage(int GameType)
	{
	
		return default;
	}
	
	public override /*function */void DrawTransition(Canvas Canvas)
	{
	
	}
	
	public override /*event */void PostRender(Canvas Canvas)
	{
	
	}
	
	public virtual /*function */void DrawLoading(Canvas Canvas)
	{
	
	}
	
	public override /*event */bool GetSubtitleRegion(ref Object.Vector2D MinPos, ref Object.Vector2D MaxPos)
	{
	
		return default;
	}
	
	public TdGameViewportClient()
	{
		// Object Offset:0x0054D57B
		UIControllerClass = ClassT<TdUIInteraction>()/*Ref Class'TdUIInteraction'*/;
	}
}
}