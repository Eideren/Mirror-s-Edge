namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_BigOverlayImage : TdUIScene_Overlay/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIImage BigImage;
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void SetOverlayImage(Surface Image)
	{
	
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_BigOverlayImage()
	{
		var Default__TdUIScene_BigOverlayImage_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_BigOverlayImage.SceneEventComponent' */;
		// Object Offset:0x0068E7F1
		EventProvider = Default__TdUIScene_BigOverlayImage_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_BigOverlayImage.SceneEventComponent'*/;
	}
}
}