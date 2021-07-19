namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ThumbnailManager : Object/*
		native
		config(Editor)*/{
	public enum EThumbnailPrimType 
	{
		TPT_None,
		TPT_Sphere,
		TPT_Cube,
		TPT_Plane,
		TPT_Cylinder,
		TPT_MAX
	};
	
	public enum EThumbnailBackgroundType 
	{
		TBT_None,
		TBT_DefaultBackground,
		TBT_SolidBackground,
		TBT_MAX
	};
	
	public partial struct /*native */ThumbnailRenderingInfo
	{
		public String ClassNeedingThumbnailName;
		public Class ClassNeedingThumbnail;
		public String RendererClassName;
		public ThumbnailRenderer Renderer;
		public String LabelRendererClassName;
		public ThumbnailLabelRenderer LabelRenderer;
		public Object.Color BorderColor;
		public String IconName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x000290E9
	//		ClassNeedingThumbnailName = "";
	//		ClassNeedingThumbnail = default;
	//		RendererClassName = "";
	//		Renderer = default;
	//		LabelRendererClassName = "";
	//		LabelRenderer = default;
	//		BorderColor = new Color
	//		{
	//			R=0,
	//			G=0,
	//			B=0,
	//			A=0
	//		};
	//		IconName = "";
	//	}
	};
	
	[Const, config] public array</*config */ThumbnailManager.ThumbnailRenderingInfo> RenderableThumbnailTypes;
	[Const, config] public array</*config */ThumbnailManager.ThumbnailRenderingInfo> ArchetypeRenderableThumbnailTypes;
	[Const] public bool bIsInitialized;
	[Const] public bool bMapNeedsUpdate;
	public bool bPSysRealTime;
	[native, Const, transient] public/*private*/ Object.Pointer RenderInfoMap;
	[native, Const, transient] public/*private*/ Object.Pointer ArchetypeRenderInfoMap;
	[Const] public ThumbnailManager.ThumbnailRenderingInfo NotSupported;
	[Const, export, editinline] public StaticMeshComponent BackgroundComponent;
	[Const, export, editinline] public StaticMeshComponent SMPreviewComponent;
	[Const, export, editinline] public SkeletalMeshComponent SKPreviewComponent;
	[Const] public StaticMesh TexPropCube;
	[Const] public StaticMesh TexPropSphere;
	[Const] public StaticMesh TexPropCylinder;
	[Const] public StaticMesh TexPropPlane;
	[Const] public Material ThumbnailBackground;
	[Const] public Material ThumbnailBackgroundSolid;
	[Const] public MaterialInstanceConstant ThumbnailBackgroundSolidMatInst;
	
	public ThumbnailManager()
	{
		// Object Offset:0x0002955D
		RenderableThumbnailTypes = new array</*config */ThumbnailManager.ThumbnailRenderingInfo>
		{
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.Prefab",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.PrefabThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=192,
					B=128,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_Prefab",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.PhysicsAsset",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.PhysicsAssetLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=192,
					B=128,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_PhysAsset",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.PhysicalMaterial",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=0,
					G=0,
					B=255,
					A=255
				},
				IconName = "EngineMaterials.UnrealEdIcon_PhysMat",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.AnimTree",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.AnimTreeLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=128,
					B=192,
					A=255
				},
				IconName = "EngineMaterials.UnrealEdIcon_AnimTree",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.SoundNodeWave",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.SoundLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=0,
					G=0,
					B=255,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_Sound",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.SoundCue",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.SoundLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=0,
					G=175,
					B=255,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_SoundCue",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.SpeechRecognition",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=0,
					G=0,
					B=255,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_SoundCue",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.Font",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.FontThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=0,
					G=0,
					B=255,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_Font",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.Sequence",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=255,
					B=255,
					A=255
				},
				IconName = "EngineMaterials.UnrealEdIcon_Sequence",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.AnimSet",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.AnimSetLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=192,
					G=128,
					B=255,
					A=255
				},
				IconName = "EngineMaterials.UnrealEdIcon_AnimSet",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.TerrainMaterial",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=192,
					G=255,
					B=192,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_TerrainMaterial",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.TerrainLayerSetup",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=128,
					G=192,
					B=255,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_TerrainLayerSetup",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.Texture2D",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.TextureThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=0,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.ShadowMap2D",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.TextureThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=0,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.ShadowMapTexture2D",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.TextureThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=0,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.TextureRenderTarget",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.TextureThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=0,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.TextureRenderTargetCube",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.TextureThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=0,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.TextureFlipBook",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.TextureThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=0,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.TextureMovie",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.TextureThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=0,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.LightMapTexture2D",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.TextureThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=0,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.TextureCube",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.TextureCubeThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=0,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.Material",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.MaterialInstanceThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.MaterialInstanceLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=0,
					G=255,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.MaterialInterface",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.MaterialInstanceThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.MaterialInstanceLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=0,
					G=128,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.ParticleSystem",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.ParticleSystemThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=255,
					B=0,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.FracturedStaticMesh",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.StaticMeshThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.FracturedStaticMeshLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=96,
					G=200,
					B=255,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.StaticMesh",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.StaticMeshThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.StaticMeshLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=0,
					G=255,
					B=255,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.SkeletalMesh",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.SkeletalMeshThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.SkeletalMeshLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=0,
					B=255,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.MorphTargetSet",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=192,
					G=128,
					B=0,
					A=255
				},
				IconName = "EngineMaterials.UnrealEdIcon_MorphTargetSet",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.MorphWeightSequence",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=128,
					G=192,
					B=0,
					A=255
				},
				IconName = "EngineMaterials.UnrealEdIcon_MorphWeightSequence",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.PostProcessChain",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.PostProcessLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=192,
					G=128,
					B=255,
					A=255
				},
				IconName = "EngineMaterials.UnrealEdIcon_PostProcessChain",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.UIScene",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.UISceneThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=30,
					G=170,
					B=200,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_Archetype",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.CurveEdPresetCurve",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=30,
					G=170,
					B=200,
					A=255
				},
				IconName = "EngineMaterials.UnrealEdIcon_CurveEdPresetCurve",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.FaceFXAsset",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=192,
					B=0,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_FaceFXAsset",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.FaceFXAnimSet",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=128,
					G=128,
					B=255,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_FaceFXAsset",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.UISkin",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=15,
					G=125,
					B=150,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_Archetype",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.CameraAnim",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=15,
					G=125,
					B=150,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_Archetype",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.SpeedTree",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=64,
					G=255,
					B=64,
					A=255
				},
				IconName = "EditorResources.SpeedTreeLogoBig",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.LensFlare",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.LensFlareThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=200,
					B=64,
					A=255
				},
				IconName = "",
			},
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Engine.PhysXParticleSystem",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.IconThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=200,
					G=192,
					B=128,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_PhysAsset",
			},
		};
		ArchetypeRenderableThumbnailTypes = new array</*config */ThumbnailManager.ThumbnailRenderingInfo>
		{
			new ThumbnailManager.ThumbnailRenderingInfo
			{
				ClassNeedingThumbnailName = "Core.Object",
				ClassNeedingThumbnail = default,
				RendererClassName = "UnrealEd.ArchetypeThumbnailRenderer",
				Renderer = default,
				LabelRendererClassName = "UnrealEd.GenericThumbnailLabelRenderer",
				LabelRenderer = default,
				BorderColor = new Color
				{
					R=255,
					G=192,
					B=128,
					A=255
				},
				IconName = "EngineResources.UnrealEdIcon_Archetype",
			},
		};
		bMapNeedsUpdate = true;
		bPSysRealTime = true;
		TexPropCube = LoadAsset<StaticMesh>("EditorMeshes.TexPropCube")/*Ref StaticMesh'EditorMeshes.TexPropCube'*/;
		TexPropSphere = LoadAsset<StaticMesh>("EditorMeshes.TexPropSphere")/*Ref StaticMesh'EditorMeshes.TexPropSphere'*/;
		TexPropCylinder = LoadAsset<StaticMesh>("EditorMeshes.TexPropCylinder")/*Ref StaticMesh'EditorMeshes.TexPropCylinder'*/;
		TexPropPlane = LoadAsset<StaticMesh>("EditorMeshes.TexPropPlane")/*Ref StaticMesh'EditorMeshes.TexPropPlane'*/;
		ThumbnailBackground = LoadAsset<Material>("EditorMaterials.ThumbnailBack")/*Ref Material'EditorMaterials.ThumbnailBack'*/;
		ThumbnailBackgroundSolid = LoadAsset<Material>("EditorMaterials.ThumbnailSolid")/*Ref Material'EditorMaterials.ThumbnailSolid'*/;
		ThumbnailBackgroundSolidMatInst = LoadAsset<MaterialInstanceConstant>("EditorMaterials.ThumbnailSolid_MATInst")/*Ref MaterialInstanceConstant'EditorMaterials.ThumbnailSolid_MATInst'*/;
	}
}
}