namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Light : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */LightComponent LightComponent;
	public/*(Baker)*/ Object.Color BakerColor;
	public/*(Baker)*/ float BakerBrightness;
	public/*(Baker)*/ bool bUseBakerColorAndBrightness;
	public /*repnotify */bool bEnabled;
	public/*(Baker)*/ float SampleFactor;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bEnabled;
	//}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		// stub
	}
	
	public Light()
	{
		var Default__Light_Sprite = new SpriteComponent
		{
			// Object Offset:0x0030D263
			Sprite = LoadAsset<Texture2D>("EngineResources.LightIcons.Light_Point_Stationary_Statics")/*Ref Texture2D'EngineResources.LightIcons.Light_Point_Stationary_Statics'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
			Scale = 0.250f,
		}/* Reference: SpriteComponent'Default__Light.Sprite' */;
		// Object Offset:0x0030D0F2
		SampleFactor = 1.0f;
		bStatic = true;
		bHidden = true;
		bNoDelete = true;
		bRouteBeginPlayEvenIfStatic = false;
		bMovable = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Light_Sprite/*Ref SpriteComponent'Default__Light.Sprite'*/,
		};
	}
}
}