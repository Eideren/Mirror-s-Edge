namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitHUD : TdMPHUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public StaticArray<Texture2D, Texture2D, Texture2D>/*[3]*/ BagIconTexture;
	public Texture2D HelicopterTexture;
	public Texture2D ProjectedBagTexture;
	public Texture2D ProjectedArrow;
	public/*(HUDIcons)*/ Object.Vector2D BagHolderIcon;
	public/*(HUDIcons)*/ Object.Vector2D BagHolderName;
	public/*(HUDIcons)*/ Object.Vector2D BagSearchCountDown;
	public/*(HUDIcons)*/ Object.Vector2D BagDistanceOffset;
	public/*(HUDIcons)*/ Object.Vector2D StashDistanceOffset;
	public/*(HUDIcons)*/ Object.Vector2D StashTimerOffset;
	public /*const */float BagFadeDistance;
	public /*const */float StashpointFadeDistance;
	public /*private transient */Core.ClassT<TdLocalMessage> TdMessageClass;
	
	public override /*simulated event */void PreBeginPlay()
	{
		// stub
	}
	
	public override /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
		// stub
	}
	
	public virtual /*function */void DrawProjectedStashpoint(TdPursuitGRI MyGRI)
	{
		// stub
	}
	
	public virtual /*function */void DrawProjectedBag(TdPursuitPRI MyPRI, TdPursuitGRI MyGRI)
	{
		// stub
	}
	
	public override /*function */void DrawLivingHUD()
	{
		// stub
	}
	
	public virtual /*function */void DisplayBagHolder(TdPursuitPRI MyPRI, TdPursuitGRI MyGRI)
	{
		// stub
	}
	
	public TdPursuitHUD()
	{
		// Object Offset:0x00652173
		BagHolderIcon = new Vector2D
		{
			X=-1245.0f,
			Y=58.0f
		};
		BagHolderName = new Vector2D
		{
			X=-4.0f,
			Y=10.0f
		};
		BagSearchCountDown = new Vector2D
		{
			X=20.0f,
			Y=10.0f
		};
		BagDistanceOffset = new Vector2D
		{
			X=1.0f,
			Y=23.0f
		};
		StashDistanceOffset = new Vector2D
		{
			X=1.0f,
			Y=23.0f
		};
		StashTimerOffset = new Vector2D
		{
			X=1.0f,
			Y=-22.0f
		};
		BagFadeDistance = 140.0f;
		StashpointFadeDistance = 100.0f;
	}
}
}