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
	[transient] public MaterialInstanceConstant FadeInEffectMaterialInstance;
	[transient] public/*private*/ TdDebugMenu DebugMenu;
	
	public override /*event */bool Init(ref String OutError)
	{
		// stub
		return default;
	}
	
	public virtual /*function */String GetHintMessage(int GameType)
	{
		// stub
		return default;
	}
	
	public override /*function */void DrawTransition(Canvas Canvas)
	{
		// stub
	}
	
	public override /*event */void PostRender(Canvas Canvas)
	{
		// stub
	}
	
	public virtual /*function */void DrawLoading(Canvas Canvas)
	{
		// stub
	}
	
	public override /*event */bool GetSubtitleRegion(ref Object.Vector2D MinPos, ref Object.Vector2D MaxPos)
	{
		// stub
		return default;
	}
	
	public TdGameViewportClient()
	{
		// Object Offset:0x0054D57B
		UIControllerClass = ClassT<TdUIInteraction>()/*Ref Class'TdUIInteraction'*/;
	}
}
}