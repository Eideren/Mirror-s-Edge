namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTeamPlayerStart : TdPlayerStart/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	[Category] public bool CopSpawn;
	[Category] public bool RobberSpawn;
	public int TeamNumber;
	[export, editinline] public/*protected*/ SpriteComponent CopSprite;
	[export, editinline] public/*protected*/ SpriteComponent RunnerSprite;
	
	public override /*function */void PreBeginPlay()
	{
		// stub
	}
	
	public TdTeamPlayerStart()
	{
		var Default__TdTeamPlayerStart_CopSpawn = new SpriteComponent
		{
			// Object Offset:0x02E526A1
			Sprite = LoadAsset<Texture2D>("TdEditorResources.CopSpawnIcon")/*Ref Texture2D'TdEditorResources.CopSpawnIcon'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
			Scale = 0.330f,
		}/* Reference: SpriteComponent'Default__TdTeamPlayerStart.CopSpawn' */;
		var Default__TdTeamPlayerStart_RunnerSpawn = new SpriteComponent
		{
			// Object Offset:0x02E52745
			Sprite = LoadAsset<Texture2D>("TdEditorResources.RunnerSpawnIcon")/*Ref Texture2D'TdEditorResources.RunnerSpawnIcon'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
			Scale = 0.330f,
		}/* Reference: SpriteComponent'Default__TdTeamPlayerStart.RunnerSpawn' */;
		var Default__TdTeamPlayerStart_SpawnRadiusSphere = new DrawSphereComponent
		{
		}/* Reference: DrawSphereComponent'Default__TdTeamPlayerStart.SpawnRadiusSphere' */;
		var Default__TdTeamPlayerStart_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdTeamPlayerStart.Sprite' */;
		var Default__TdTeamPlayerStart_PlayerStartTextureResourcesObject = new RequestedTextureResources
		{
		}/* Reference: RequestedTextureResources'Default__TdTeamPlayerStart.PlayerStartTextureResourcesObject' */;
		var Default__TdTeamPlayerStart_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdTeamPlayerStart.CollisionCylinder' */;
		var Default__TdTeamPlayerStart_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdTeamPlayerStart.Sprite2' */;
		var Default__TdTeamPlayerStart_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdTeamPlayerStart.Arrow' */;
		var Default__TdTeamPlayerStart_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdTeamPlayerStart.PathRenderer' */;
		// Object Offset:0x006749E4
		CopSpawn = true;
		RobberSpawn = true;
		TeamNumber = 2;
		CopSprite = Default__TdTeamPlayerStart_CopSpawn/*Ref SpriteComponent'Default__TdTeamPlayerStart.CopSpawn'*/;
		RunnerSprite = Default__TdTeamPlayerStart_RunnerSpawn/*Ref SpriteComponent'Default__TdTeamPlayerStart.RunnerSpawn'*/;
		SphereRenderComponent = Default__TdTeamPlayerStart_SpawnRadiusSphere/*Ref DrawSphereComponent'Default__TdTeamPlayerStart.SpawnRadiusSphere'*/;
		GenericSprite = Default__TdTeamPlayerStart_Sprite/*Ref SpriteComponent'Default__TdTeamPlayerStart.Sprite'*/;
		PlayerStartTextureResources = Default__TdTeamPlayerStart_PlayerStartTextureResourcesObject/*Ref RequestedTextureResources'Default__TdTeamPlayerStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = Default__TdTeamPlayerStart_CollisionCylinder/*Ref CylinderComponent'Default__TdTeamPlayerStart.CollisionCylinder'*/;
		GoodSprite = Default__TdTeamPlayerStart_Sprite/*Ref SpriteComponent'Default__TdTeamPlayerStart.Sprite'*/;
		BadSprite = Default__TdTeamPlayerStart_Sprite2/*Ref SpriteComponent'Default__TdTeamPlayerStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdTeamPlayerStart_Sprite/*Ref SpriteComponent'Default__TdTeamPlayerStart.Sprite'*/,
			Default__TdTeamPlayerStart_Sprite2/*Ref SpriteComponent'Default__TdTeamPlayerStart.Sprite2'*/,
			Default__TdTeamPlayerStart_Arrow/*Ref ArrowComponent'Default__TdTeamPlayerStart.Arrow'*/,
			Default__TdTeamPlayerStart_CollisionCylinder/*Ref CylinderComponent'Default__TdTeamPlayerStart.CollisionCylinder'*/,
			Default__TdTeamPlayerStart_PathRenderer/*Ref PathRenderingComponent'Default__TdTeamPlayerStart.PathRenderer'*/,
			Default__TdTeamPlayerStart_SpawnRadiusSphere/*Ref DrawSphereComponent'Default__TdTeamPlayerStart.SpawnRadiusSphere'*/,
			Default__TdTeamPlayerStart_CopSpawn/*Ref SpriteComponent'Default__TdTeamPlayerStart.CopSpawn'*/,
			Default__TdTeamPlayerStart_RunnerSpawn/*Ref SpriteComponent'Default__TdTeamPlayerStart.RunnerSpawn'*/,
		};
		CollisionComponent = Default__TdTeamPlayerStart_CollisionCylinder/*Ref CylinderComponent'Default__TdTeamPlayerStart.CollisionCylinder'*/;
	}
}
}