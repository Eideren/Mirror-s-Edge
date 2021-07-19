namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Terrain : Info/*
		native
		placeable
		hidecategories(Navigation)*/{
	public partial struct TerrainHeight
	{
	};
	
	public partial struct TerrainInfoData
	{
	};
	
	public partial struct TerrainWeightedMaterial
	{
	};
	
	public partial struct TerrainLayer
	{
		[Category] public String Name;
		[Category] public TerrainLayerSetup Setup;
		public int AlphaMapIndex;
		[Category] public bool Highlighted;
		[Category] public bool WireframeHighlighted;
		[Category] public bool Hidden;
		[Category] public Object.Color HighlightColor;
		[Category] public Object.Color WireframeColor;
		public int MinX;
		public int MinY;
		public int MaxX;
		public int MaxY;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FAAF8
	//		Name = "";
	//		Setup = default;
	//		AlphaMapIndex = -1;
	//		Highlighted = false;
	//		WireframeHighlighted = false;
	//		Hidden = false;
	//		HighlightColor = new Color
	//		{
	//			R=255,
	//			G=255,
	//			B=255,
	//			A=0
	//		};
	//		WireframeColor = new Color
	//		{
	//			R=0,
	//			G=0,
	//			B=0,
	//			A=0
	//		};
	//		MinX = 0;
	//		MinY = 0;
	//		MaxX = 0;
	//		MaxY = 0;
	//	}
	};
	
	public partial struct AlphaMap
	{
	};
	
	public partial struct TerrainDecorationInstance
	{
		[export, editinline] public PrimitiveComponent Component;
		public float X;
		public float Y;
		public float Scale;
		public int Yaw;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FADA8
	//		Component = default;
	//		X = 0.0f;
	//		Y = 0.0f;
	//		Scale = 0.0f;
	//		Yaw = 0;
	//	}
	};
	
	public partial struct TerrainDecoration
	{
		[Category] [editinline] public PrimitiveComponentFactory Factory;
		[Category] public float MinScale;
		[Category] public float MaxScale;
		[Category] public float Density;
		[Category] public float SlopeRotationBlend;
		[Category] public int RandSeed;
		public array<Terrain.TerrainDecorationInstance> Instances;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FAFD8
	//		Factory = default;
	//		MinScale = 1.0f;
	//		MaxScale = 1.0f;
	//		Density = 0.010f;
	//		SlopeRotationBlend = 0.0f;
	//		RandSeed = 0;
	//		Instances = default;
	//	}
	};
	
	public partial struct TerrainDecoLayer
	{
		[Category] public String Name;
		[Category] public array<Terrain.TerrainDecoration> Decorations;
		public int AlphaMapIndex;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FB18C
	//		Name = "";
	//		Decorations = default;
	//		AlphaMapIndex = -1;
	//	}
	};
	
	public partial struct TerrainMaterialResource
	{
	};
	
	public partial struct /*native */CachedTerrainMaterialArray
	{
		[duplicatetransient, native, Const] public array<Object.Pointer> CachedMaterials;
	};
	
	public partial struct SelectedTerrainVertex
	{
		public int X;
		public int Y;
		public int Weight;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FBBB8
	//		X = 0;
	//		Y = 0;
	//		Weight = 0;
	//	}
	};
	
	[native, Const] public/*private*/ array<Terrain.TerrainHeight> Heights;
	[native, Const] public/*private*/ array<Terrain.TerrainInfoData> InfoData;
	[Category] [Const] public array<Terrain.TerrainLayer> Layers;
	[Category] public int NormalMapLayer;
	[Category] [Const] public array<Terrain.TerrainDecoLayer> DecoLayers;
	[native, Const] public array<Terrain.AlphaMap> AlphaMaps;
	[nontransactional, Const, export, editinline] public array</*export editinline */TerrainComponent> TerrainComponents;
	[Const] public int NumSectionsX;
	[Const] public int NumSectionsY;
	[Const] public int SectionSize;
	[native, Const] public/*private*/ array<Terrain.TerrainWeightedMaterial> WeightedMaterials;
	[native, Const] public/*private*/ array<TerrainWeightMapTexture> WeightedTextureMaps;
	[native, Const] public array<byte> CachedDisplacements;
	[native, Const] public float MaxCollisionDisplacement;
	[Category] public int MaxTesselationLevel;
	[Category] public int MinTessellationLevel;
	[Category] public float TesselationDistanceScale;
	[deprecated] public int TessellationCheckCount;
	[Category] public float TessellationCheckDistance;
	[deprecated] public float TessellationCheckBorder;
	[Category("Collision")] public int CollisionTesselationLevel;
	[native, Const] public StaticArray<Terrain.CachedTerrainMaterialArray, Terrain.CachedTerrainMaterialArray>/*[2]*/ CachedTerrainMaterials;
	[Const] public int NumVerticesX;
	[Const] public int NumVerticesY;
	[Category] public int NumPatchesX;
	[Category] public int NumPatchesY;
	[Category] public int MaxComponentSize;
	[Category("Lighting")] public int StaticLightingResolution;
	[Category("Lighting")] public bool bIsOverridingLightResolution;
	[Category("Lighting")] public bool bBilinearFilterLightmapGeneration;
	[Category("Lighting")] public bool bCastShadow;
	[Category("Lighting")] [Const] public bool bForceDirectLightMap;
	[Category("Lighting")] [Const] public bool bCastDynamicShadow;
	[Category("Collision")] [Const] public bool bBlockRigidBody;
	[Category("Collision")] [Const] public bool bAllowRigidBodyUnderneath;
	[Category("Lighting")] [Const] public bool bAcceptsDynamicLights;
	[Category] public bool bMorphingEnabled;
	[Category] public bool bMorphingGradientsEnabled;
	public bool bLocked;
	public bool bHeightmapLocked;
	public bool bShowingCollision;
	[Category] public bool bShowWireframe;
	[Category("Lighting")] [Const] public LightComponent.LightingChannelContainer LightingChannels;
	[native, Const] public Object.Pointer ReleaseResourcesFence;
	[Category] [transient] public int EditorTessellationLevel;
	[transient] public array<Terrain.SelectedTerrainVertex> SelectedVertices;
	[Category] public Object.Color WireframeColor;
	
	// Export UTerrain::execCalcLayerBounds(FFrame&, void* const)
	public virtual /*native final function */void CalcLayerBounds()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
		// stub
	}
	
	public Terrain()
	{
		var Default__Terrain_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D06F2
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Terrain")/*Ref Texture2D'EngineResources.S_Terrain'*/,
		}/* Reference: SpriteComponent'Default__Terrain.Sprite' */;
		// Object Offset:0x003FBD53
		NormalMapLayer = -1;
		MaxTesselationLevel = 4;
		MinTessellationLevel = 1;
		TesselationDistanceScale = 1.0f;
		TessellationCheckDistance = -1.0f;
		CollisionTesselationLevel = 1;
		NumPatchesX = 1;
		NumPatchesY = 1;
		MaxComponentSize = 16;
		StaticLightingResolution = 4;
		bBilinearFilterLightmapGeneration = true;
		bCastShadow = true;
		bForceDirectLightMap = true;
		bCastDynamicShadow = true;
		bBlockRigidBody = true;
		bAcceptsDynamicLights = true;
		LightingChannels = new LightComponent.LightingChannelContainer
		{
			bInitialized = true,
			BSP = false,
			Static = true,
			Dynamic = false,
			CompositeDynamic = false,
			Skybox = false,
			Unnamed_1 = false,
			Unnamed_2 = false,
			Unnamed_3 = false,
			Unnamed_4 = false,
			Unnamed_5 = false,
			Unnamed_6 = false,
			Cinematic_1 = false,
			Cinematic_2 = false,
			Cinematic_3 = false,
			Cinematic_4 = false,
			Cinematic_5 = false,
			Cinematic_6 = false,
			Gameplay_1 = false,
			Gameplay_2 = false,
			Gameplay_3 = false,
			Gameplay_4 = false,
		};
		WireframeColor = new Color
		{
			R=0,
			G=255,
			B=255,
			A=0
		};
		bStatic = true;
		bHidden = false;
		bNoDelete = true;
		bWorldGeometry = true;
		bCollideActors = true;
		bBlockActors = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Terrain_Sprite/*Ref SpriteComponent'Default__Terrain.Sprite'*/,
		};
		DrawScale3D = new Vector
		{
			X=256.0f,
			Y=256.0f,
			Z=256.0f
		};
	}
}
}