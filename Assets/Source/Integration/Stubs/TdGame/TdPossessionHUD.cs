namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPossessionHUD : TdMPHUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Texture2D BagIconTexture;
	public Texture2D ProjectedBagTexture;
	public Texture2D ProjectedArrow;
	[Category("HUDIcons")] public Object.Vector2D BagHolderIcon;
	[Category("HUDIcons")] public Object.Vector2D BagHolderName;
	[Const] public float BagFadeDistance;
	[transient] public/*private*/ Core.ClassT<TdLocalMessage> TdBagMessageClass;
	
	public override /*simulated function */void PreBeginPlay()
	{
		// stub
	}
	
	public override /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
		// stub
	}
	
	public virtual /*function */void DrawProjectedBag(TdBagPRI MyPRI, TdPossessionGRI MyGRI)
	{
		// stub
	}
	
	public override /*function */void DrawLivingHUD()
	{
		// stub
	}
	
	public virtual /*function */void DisplayBagHolder(TdPlayerReplicationInfo MyPRI, TdPossessionGRI MyGRI)
	{
		// stub
	}
	
	public override /*function */void DrawScore()
	{
		// stub
	}
	
	public TdPossessionHUD()
	{
		// Object Offset:0x00632D5C
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
		BagFadeDistance = 140.0f;
		ScorePos = new Vector2D
		{
			X=640.0f,
			Y=35.0f
		};
	}
}
}