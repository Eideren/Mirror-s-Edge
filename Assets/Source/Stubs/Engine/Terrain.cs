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
		public/*()*/ String Name;
		public/*()*/ TerrainLayerSetup Setup;
		public int AlphaMapIndex;
		public/*()*/ bool Highlighted;
		public/*()*/ bool WireframeHighlighted;
		public/*()*/ bool Hidden;
		public/*()*/ Object.Color HighlightColor;
		public/*()*/ Object.Color WireframeColor;
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
		public /*export editinline */PrimitiveComponent Component;
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
		public/*()*/ /*editinline */PrimitiveComponentFactory Factory;
		public/*()*/ float MinScale;
		public/*()*/ float MaxScale;
		public/*()*/ float Density;
		public/*()*/ float SlopeRotationBlend;
		public/*()*/ int RandSeed;
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
		public/*()*/ String Name;
		public/*()*/ array<Terrain.TerrainDecoration> Decorations;
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
		public /*duplicatetransient native const */array<Object.Pointer> CachedMaterials;
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
	
	public /*private native const */array<Terrain.TerrainHeight> Heights;
	public /*private native const */array<Terrain.TerrainInfoData> InfoData;
	public/*()*/ /*const */array<Terrain.TerrainLayer> Layers;
	public/*()*/ int NormalMapLayer;
	public/*()*/ /*const */array<Terrain.TerrainDecoLayer> DecoLayers;
	public /*native const */array<Terrain.AlphaMap> AlphaMaps;
	public /*nontransactional const export editinline */array</*export editinline */TerrainComponent> TerrainComponents;
	public /*const */int NumSectionsX;
	public /*const */int NumSectionsY;
	public /*const */int SectionSize;
	public /*private native const */array<Terrain.TerrainWeightedMaterial> WeightedMaterials;
	public /*private native const */array<TerrainWeightMapTexture> WeightedTextureMaps;
	public /*native const */array<byte> CachedDisplacements;
	public /*native const */float MaxCollisionDisplacement;
	public/*()*/ int MaxTesselationLevel;
	public/*()*/ int MinTessellationLevel;
	public/*()*/ float TesselationDistanceScale;
	public /*deprecated */int TessellationCheckCount;
	public/*()*/ float TessellationCheckDistance;
	public /*deprecated */float TessellationCheckBorder;
	public/*(Collision)*/ int CollisionTesselationLevel;
	public /*native const */StaticArray<Terrain.CachedTerrainMaterialArray, Terrain.CachedTerrainMaterialArray>/*[2]*/ CachedTerrainMaterials;
	public /*const */int NumVerticesX;
	public /*const */int NumVerticesY;
	public/*()*/ int NumPatchesX;
	public/*()*/ int NumPatchesY;
	public/*()*/ int MaxComponentSize;
	public/*(Lighting)*/ int StaticLightingResolution;
	public/*(Lighting)*/ bool bIsOverridingLightResolution;
	public/*(Lighting)*/ bool bBilinearFilterLightmapGeneration;
	public/*(Lighting)*/ bool bCastShadow;
	public/*(Lighting)*/ /*const */bool bForceDirectLightMap;
	public/*(Lighting)*/ /*const */bool bCastDynamicShadow;
	public/*(Collision)*/ /*const */bool bBlockRigidBody;
	public/*(Collision)*/ /*const */bool bAllowRigidBodyUnderneath;
	public/*(Lighting)*/ /*const */bool bAcceptsDynamicLights;
	public/*()*/ bool bMorphingEnabled;
	public/*()*/ bool bMorphingGradientsEnabled;
	public bool bLocked;
	public bool bHeightmapLocked;
	public bool bShowingCollision;
	public/*()*/ bool bShowWireframe;
	public/*(Lighting)*/ /*const */LightComponent.LightingChannelContainer LightingChannels;
	public /*native const */Object.Pointer ReleaseResourcesFence;
	public/*()*/ /*transient */int EditorTessellationLevel;
	public /*transient */array<Terrain.SelectedTerrainVertex> SelectedVertices;
	public/*()*/ Object.Color WireframeColor;
	
	// Export UTerrain::execCalcLayerBounds(FFrame&, void* const)
	public virtual /*native final function */void CalcLayerBounds()
	{
		 // #warning NATIVE FUNCTION !
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