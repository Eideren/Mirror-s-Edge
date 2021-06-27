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
	
	public/*()*/ PhysicalMaterial PhysMaterial;
	public Core.ClassT<PhysicalMaterial> PhysicalMaterial;
	public Material.ColorMaterialInput DiffuseColor;
	public Material.ScalarMaterialInput DiffusePower;
	public Material.ColorMaterialInput SpecularColor;
	public Material.ScalarMaterialInput SpecularPower;
	public Material.VectorMaterialInput Normal;
	public Material.ColorMaterialInput EmissiveColor;
	public Material.ScalarMaterialInput Opacity;
	public Material.ScalarMaterialInput OpacityMask;
	public/*()*/ float OpacityMaskClipValue;
	public Material.Vector2MaterialInput Distortion;
	public/*()*/ Material.EBlendMode BlendMode;
	public/*()*/ Material.EMaterialLightingModel LightingModel;
	public Material.ColorMaterialInput CustomLighting;
	public Material.ScalarMaterialInput TwoSidedLightingMask;
	public Material.ColorMaterialInput TwoSidedLightingColor;
	public/*()*/ bool TwoSided;
	public/*()*/ bool bDisableDepthTest;
	public/*(Usage)*/ /*const */bool bUsedAsLightFunction;
	public/*(Usage)*/ /*const */bool bUsedWithFogVolumes;
	public/*(Usage)*/ /*const */bool bUsedAsSpecialEngineMaterial;
	public/*(Usage)*/ /*const */bool bUsedWithSkeletalMesh;
	public /*const */bool bUsedWithParticleSystem;
	public/*(Usage)*/ /*const */bool bUsedWithParticleSprites;
	public/*(Usage)*/ /*const */bool bUsedWithBeamTrails;
	public/*(Usage)*/ /*const */bool bUsedWithParticleSubUV;
	public/*(Usage)*/ /*const */bool bUsedWithFoliage;
	public/*(Usage)*/ /*const */bool bUsedWithSpeedTree;
	public/*(Usage)*/ /*const */bool bUsedWithStaticLighting;
	public/*(Usage)*/ /*const */bool bUsedWithLensFlare;
	public/*(Usage)*/ /*const */bool bUsedWithGammaCorrection;
	public/*(Usage)*/ /*const */bool bUsedWithInstancedMeshParticles;
	public/*()*/ bool Wireframe;
	public/*(Usage)*/ bool bIsFallbackMaterial;
	public /*private */bool bUsesDistortion;
	public /*private */bool bUsesSceneColor;
	public /*private */bool bIsMasked;
	public /*private duplicatetransient transient */bool bIsPreviewMaterial;
	public /*private transient */bool bDeferredProcessing;
	public/*()*/ Material FallbackMaterial;
	public /*duplicatetransient native const */StaticArray<Object.Pointer, Object.Pointer>/*[2]*/ MaterialResources;
	public /*duplicatetransient native const */StaticArray<Object.Pointer, Object.Pointer>/*[2]*/ DefaultMaterialInstances;
	public int EditorX;
	public int EditorY;
	public int EditorPitch;
	public int EditorYaw;
	public array<MaterialExpression> Expressions;
	public /*editoronly */array<MaterialExpressionComment> EditorComments;
	public /*editoronly */array<MaterialExpressionCompound> EditorCompounds;
	public /*native *//*map<0,0>*/map<object, object> EditorParameters;
	public /*private const */array<Texture> ReferencedTextures;
	
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