namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Material : MaterialInterface/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public enum EBlendMode 
	{
		BLEND_Opaque,
		BLEND_Masked,
		BLEND_Translucent,
		BLEND_Additive,
		BLEND_Modulate,
		BLEND_MAX
	};
	
	public enum EMaterialLightingModel 
	{
		MLM_Phong,
		MLM_NonDirectional,
		MLM_Unlit,
		MLM_SHPRT,
		MLM_Custom,
		MLM_MAX
	};
	
	public partial struct MaterialInput
	{
		public MaterialExpression Expression;
		public int Mask;
		public int MaskR;
		public int MaskG;
		public int MaskB;
		public int MaskA;
		public int GCC64_Padding;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0030A157
	//		Expression = default;
	//		Mask = 0;
	//		MaskR = 0;
	//		MaskG = 0;
	//		MaskB = 0;
	//		MaskA = 0;
	//		GCC64_Padding = 0;
	//	}
	};
	
	public partial struct ColorMaterialInput// extends MaterialInput
	{
		public MaterialExpression Expression;
		public int Mask;
		public int MaskR;
		public int MaskG;
		public int MaskB;
		public int MaskA;
		public int GCC64_Padding;
	
		public bool UseConstant;
		public Object.Color Constant;
			// Object Offset:0x0030A157
	//		Expression = default;
	//		Mask = 0;
	//		MaskR = 0;
	//		MaskG = 0;
	//		MaskB = 0;
	//		MaskA = 0;
	//		GCC64_Padding = 0;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct ScalarMaterialInput// extends MaterialInput
	{
		public MaterialExpression Expression;
		public int Mask;
		public int MaskR;
		public int MaskG;
		public int MaskB;
		public int MaskA;
		public int GCC64_Padding;
	
		public bool UseConstant;
		public float Constant;
			// Object Offset:0x0030A157
	//		Expression = default;
	//		Mask = 0;
	//		MaskR = 0;
	//		MaskG = 0;
	//		MaskB = 0;
	//		MaskA = 0;
	//		GCC64_Padding = 0;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct VectorMaterialInput// extends MaterialInput
	{
		public MaterialExpression Expression;
		public int Mask;
		public int MaskR;
		public int MaskG;
		public int MaskB;
		public int MaskA;
		public int GCC64_Padding;
	
		public bool UseConstant;
		public Object.Vector Constant;
			// Object Offset:0x0030A157
	//		Expression = default;
	//		Mask = 0;
	//		MaskR = 0;
	//		MaskG = 0;
	//		MaskB = 0;
	//		MaskA = 0;
	//		GCC64_Padding = 0;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct Vector2MaterialInput// extends MaterialInput
	{
		public MaterialExpression Expression;
		public int Mask;
		public int MaskR;
		public int MaskG;
		public int MaskB;
		public int MaskA;
		public int GCC64_Padding;
	
		public bool UseConstant;
		public float ConstantX;
		public float ConstantY;
			// Object Offset:0x0030A157
	//		Expression = default;
	//		Mask = 0;
	//		MaskR = 0;
	//		MaskG = 0;
	//		MaskB = 0;
	//		MaskA = 0;
	//		GCC64_Padding = 0;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	[Category] public PhysicalMaterial PhysMaterial;
	public Core.ClassT<PhysicalMaterial> PhysicalMaterial;
	public Material.ColorMaterialInput DiffuseColor;
	public Material.ScalarMaterialInput DiffusePower;
	public Material.ColorMaterialInput SpecularColor;
	public Material.ScalarMaterialInput SpecularPower;
	public Material.VectorMaterialInput Normal;
	public Material.ColorMaterialInput EmissiveColor;
	public Material.ScalarMaterialInput Opacity;
	public Material.ScalarMaterialInput OpacityMask;
	[Category] public float OpacityMaskClipValue;
	public Material.Vector2MaterialInput Distortion;
	[Category] public Material.EBlendMode BlendMode;
	[Category] public Material.EMaterialLightingModel LightingModel;
	public Material.ColorMaterialInput CustomLighting;
	public Material.ScalarMaterialInput TwoSidedLightingMask;
	public Material.ColorMaterialInput TwoSidedLightingColor;
	[Category] public bool TwoSided;
	[Category] public bool bDisableDepthTest;
	[Category("Usage")] [Const] public bool bUsedAsLightFunction;
	[Category("Usage")] [Const] public bool bUsedWithFogVolumes;
	[Category("Usage")] [Const] public bool bUsedAsSpecialEngineMaterial;
	[Category("Usage")] [Const] public bool bUsedWithSkeletalMesh;
	[Const] public bool bUsedWithParticleSystem;
	[Category("Usage")] [Const] public bool bUsedWithParticleSprites;
	[Category("Usage")] [Const] public bool bUsedWithBeamTrails;
	[Category("Usage")] [Const] public bool bUsedWithParticleSubUV;
	[Category("Usage")] [Const] public bool bUsedWithFoliage;
	[Category("Usage")] [Const] public bool bUsedWithSpeedTree;
	[Category("Usage")] [Const] public bool bUsedWithStaticLighting;
	[Category("Usage")] [Const] public bool bUsedWithLensFlare;
	[Category("Usage")] [Const] public bool bUsedWithGammaCorrection;
	[Category("Usage")] [Const] public bool bUsedWithInstancedMeshParticles;
	[Category] public bool Wireframe;
	[Category("Usage")] public bool bIsFallbackMaterial;
	public/*private*/ bool bUsesDistortion;
	public/*private*/ bool bUsesSceneColor;
	public/*private*/ bool bIsMasked;
	[duplicatetransient, transient] public/*private*/ bool bIsPreviewMaterial;
	[transient] public/*private*/ bool bDeferredProcessing;
	[Category] public Material FallbackMaterial;
	[duplicatetransient, native, Const] public StaticArray<Object.Pointer, Object.Pointer>/*[2]*/ MaterialResources;
	[duplicatetransient, native, Const] public StaticArray<Object.Pointer, Object.Pointer>/*[2]*/ DefaultMaterialInstances;
	public int EditorX;
	public int EditorY;
	public int EditorPitch;
	public int EditorYaw;
	public array<MaterialExpression> Expressions;
	[editoronly] public array<MaterialExpressionComment> EditorComments;
	[editoronly] public array<MaterialExpressionCompound> EditorCompounds;
	[native] public /*map<0,0>*/map<object, object> EditorParameters;
	[Const] public/*private*/ array<Texture> ReferencedTextures;
	
	public virtual /*function */array<Texture> GetTextures()
	{
		// stub
		return default;
	}
	
	public Material()
	{
		// Object Offset:0x0030AF87
		DiffuseColor = new Material.ColorMaterialInput
		{
			UseConstant = false,
			Constant = new Color
			{
				R=128,
				G=128,
				B=128,
				A=0
			},
			Expression = default,
			Mask = 0,
			MaskR = 0,
			MaskG = 0,
			MaskB = 0,
			MaskA = 0,
			GCC64_Padding = 0,
		};
		DiffusePower = new Material.ScalarMaterialInput
		{
			UseConstant = false,
			Constant = 1.0f,
			Expression = default,
			Mask = 0,
			MaskR = 0,
			MaskG = 0,
			MaskB = 0,
			MaskA = 0,
			GCC64_Padding = 0,
		};
		SpecularColor = new Material.ColorMaterialInput
		{
			UseConstant = false,
			Constant = new Color
			{
				R=128,
				G=128,
				B=128,
				A=0
			},
			Expression = default,
			Mask = 0,
			MaskR = 0,
			MaskG = 0,
			MaskB = 0,
			MaskA = 0,
			GCC64_Padding = 0,
		};
		SpecularPower = new Material.ScalarMaterialInput
		{
			UseConstant = false,
			Constant = 15.0f,
			Expression = default,
			Mask = 0,
			MaskR = 0,
			MaskG = 0,
			MaskB = 0,
			MaskA = 0,
			GCC64_Padding = 0,
		};
		Opacity = new Material.ScalarMaterialInput
		{
			UseConstant = false,
			Constant = 1.0f,
			Expression = default,
			Mask = 0,
			MaskR = 0,
			MaskG = 0,
			MaskB = 0,
			MaskA = 0,
			GCC64_Padding = 0,
		};
		OpacityMask = new Material.ScalarMaterialInput
		{
			UseConstant = false,
			Constant = 1.0f,
			Expression = default,
			Mask = 0,
			MaskR = 0,
			MaskG = 0,
			MaskB = 0,
			MaskA = 0,
			GCC64_Padding = 0,
		};
		OpacityMaskClipValue = 0.33330f;
		TwoSidedLightingColor = new Material.ColorMaterialInput
		{
			UseConstant = false,
			Constant = new Color
			{
				R=255,
				G=255,
				B=255,
				A=0
			},
			Expression = default,
			Mask = 0,
			MaskR = 0,
			MaskG = 0,
			MaskB = 0,
			MaskA = 0,
			GCC64_Padding = 0,
		};
		bUsedWithStaticLighting = true;
	}
}
}