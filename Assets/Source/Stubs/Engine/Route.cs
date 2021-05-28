namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Route : Info/*
		native
		placeable
		hidecategories(Navigation,Movement,Collision)*/{
	public enum ERouteFillAction 
	{
		RFA_Overwrite,
		RFA_Add,
		RFA_Remove,
		RFA_Clear,
		RFA_MAX
	};
	
	public enum ERouteDirection 
	{
		ERD_Forward,
		ERD_Reverse,
		ERD_MAX
	};
	
	public enum ERouteType 
	{
		ERT_Linear,
		ERT_Loop,
		ERT_Circle,
		ERT_MAX
	};
	
	public/*()*/ Route.ERouteType RouteType;
	public/*()*/ array<Actor.NavReference> NavList;
	
	public Route()
	{
		// Object Offset:0x003B06E9
		bStatic = true;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x004D0572
				Sprite = LoadAsset<Texture2D>("EngineResources.S_Route")/*Ref Texture2D'EngineResources.S_Route'*/,
			}/* Reference: SpriteComponent'Default__Route.Sprite' */,
			//Components[1]=
			new SpriteComponent
			{
				// Object Offset:0x004D0572
				Sprite = LoadAsset<Texture2D>("EngineResources.S_Route")/*Ref Texture2D'EngineResources.S_Route'*/,
			}/* Reference: SpriteComponent'Default__Route.Sprite' */,
			//Components[2]=
			new RouteRenderingComponent
			{
				// Object Offset:0x004CE5F6
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: RouteRenderingComponent'Default__Route.RouteRenderer' */,
		};
	}
}
}