namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CustomPropertyItemBindings : Object/*
		native
		config(Editor)*/{
	public partial struct /*native */PropertyItemCustomProxy
	{
		public/*()*/ /*config */String PropertyPathName;
		public/*()*/ /*config */String PropertyItemClassName;
		public/*()*/ /*config */bool bReplaceArrayHeaders;
		public/*()*/ /*config */bool bIgnoreArrayElements;
		public /*transient */Class PropertyItemClass;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F0C0
	//		PropertyPathName = "";
	//		PropertyItemClassName = "";
	//		bReplaceArrayHeaders = false;
	//		bIgnoreArrayElements = false;
	//		PropertyItemClass = default;
	//	}
	};
	
	public partial struct /*native */PropertyTypeCustomProxy
	{
		public/*()*/ /*config */name PropertyName;
		public/*()*/ /*config */String PropertyObjectClassPathName;
		public/*()*/ /*config */String PropertyItemClassName;
		public/*()*/ /*config */bool bReplaceArrayHeaders;
		public/*()*/ /*config */bool bIgnoreArrayElements;
		public /*transient */Class PropertyItemClass;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F294
	//		PropertyName = (name)"None";
	//		PropertyObjectClassPathName = "";
	//		PropertyItemClassName = "";
	//		bReplaceArrayHeaders = false;
	//		bIgnoreArrayElements = false;
	//		PropertyItemClass = default;
	//	}
	};
	
	public partial struct /*native */PropertyItemCustomClass
	{
		public/*()*/ /*config */String PropertyPathName;
		public/*()*/ /*config */String PropertyItemClassName;
		public/*()*/ /*config */bool bReplaceArrayHeaders;
		public/*()*/ /*config */bool bIgnoreArrayElements;
		public /*native transient */Object.Pointer WxPropertyItemClass;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F458
	//		PropertyPathName = "";
	//		PropertyItemClassName = "";
	//		bReplaceArrayHeaders = false;
	//		bIgnoreArrayElements = false;
	//	}
	};
	
	public partial struct /*native */PropertyTypeCustomClass
	{
		public/*()*/ /*config */name PropertyName;
		public/*()*/ /*config */String PropertyObjectClassPathName;
		public/*()*/ /*config */String PropertyItemClassName;
		public/*()*/ /*config */bool bReplaceArrayHeaders;
		public/*()*/ /*config */bool bIgnoreArrayElements;
		public /*native transient */Object.Pointer WxPropertyItemClass;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001F60C
	//		PropertyName = (name)"None";
	//		PropertyObjectClassPathName = "";
	//		PropertyItemClassName = "";
	//		bReplaceArrayHeaders = false;
	//		bIgnoreArrayElements = false;
	//	}
	};
	
	public/*()*/ /*config */array</*config */CustomPropertyItemBindings.PropertyItemCustomClass> CustomPropertyClasses;
	public/*()*/ /*config */array</*config */CustomPropertyItemBindings.PropertyTypeCustomClass> CustomPropertyTypeClasses;
	public/*()*/ /*config */array</*config */CustomPropertyItemBindings.PropertyItemCustomProxy> CustomPropertyDrawProxies;
	public/*()*/ /*config */array</*config */CustomPropertyItemBindings.PropertyItemCustomProxy> CustomPropertyInputProxies;
	public/*()*/ /*config */array</*config */CustomPropertyItemBindings.PropertyTypeCustomProxy> CustomPropertyTypeDrawProxies;
	public/*()*/ /*config */array</*config */CustomPropertyItemBindings.PropertyTypeCustomProxy> CustomPropertyTypeInputProxies;
	
	public CustomPropertyItemBindings()
	{
		// Object Offset:0x0001F7F4
		CustomPropertyClasses = new array</*config */CustomPropertyItemBindings.PropertyItemCustomClass>
		{
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UIStyleOverride.DrawColor",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UIStyleOverride.Opacity",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UIStyleOverride.Padding",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = true,
				bIgnoreArrayElements = true,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UITextStyleOverride.DrawFont",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UITextStyleOverride.TextAttributes",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UITextStyleOverride.TextAlignment",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = true,
				bIgnoreArrayElements = true,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UITextStyleOverride.ClipMode",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UITextStyleOverride.ClipAlignment",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UITextStyleOverride.AutoScaling",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UITextStyleOverride.DrawScale",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = true,
				bIgnoreArrayElements = true,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UITextStyleOverride.SpacingAdjust",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = true,
				bIgnoreArrayElements = true,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UIImageStyleOverride.Coordinates",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "Engine.UIRoot:UIImageStyleOverride.Formatting",
				PropertyItemClassName = "WxCustomPropertyItem_ConditionalItem",
				bReplaceArrayHeaders = true,
				bIgnoreArrayElements = true,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "UnrealEd.MaterialEditorInstanceConstant:VectorParameterValues",
				PropertyItemClassName = "WxPropertyWindow_MaterialInstanceConstantParameters",
				bReplaceArrayHeaders = true,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "UnrealEd.MaterialEditorInstanceConstant:StaticSwitchParameterValues",
				PropertyItemClassName = "WxPropertyWindow_MaterialInstanceConstantParameters",
				bReplaceArrayHeaders = true,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "UnrealEd.MaterialEditorInstanceConstant:StaticComponentMaskParameterValues",
				PropertyItemClassName = "WxPropertyWindow_MaterialInstanceConstantParameters",
				bReplaceArrayHeaders = true,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "UnrealEd.MaterialEditorInstanceConstant:ScalarParameterValues",
				PropertyItemClassName = "WxPropertyWindow_MaterialInstanceConstantParameters",
				bReplaceArrayHeaders = true,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "UnrealEd.MaterialEditorInstanceConstant:TextureParameterValues",
				PropertyItemClassName = "WxPropertyWindow_MaterialInstanceConstantParameters",
				bReplaceArrayHeaders = true,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "UnrealEd.MaterialEditorInstanceConstant:EditorVectorParameterValue.ParameterValue",
				PropertyItemClassName = "WxCustomPropertyItem_MaterialInstanceConstantParameter",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "UnrealEd.MaterialEditorInstanceConstant:EditorStaticSwitchParameterValue.ParameterValue",
				PropertyItemClassName = "WxCustomPropertyItem_MaterialInstanceConstantParameter",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "UnrealEd.MaterialEditorInstanceConstant:EditorStaticComponentMaskParameterValue.ParameterValue",
				PropertyItemClassName = "WxCustomPropertyItem_MaterialInstanceConstantParameter",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "UnrealEd.MaterialEditorInstanceConstant:EditorScalarParameterValue.ParameterValue",
				PropertyItemClassName = "WxCustomPropertyItem_MaterialInstanceConstantParameter",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
			new CustomPropertyItemBindings.PropertyItemCustomClass
			{
				PropertyPathName = "UnrealEd.MaterialEditorInstanceConstant:EditorTextureParameterValue.ParameterValue",
				PropertyItemClassName = "WxCustomPropertyItem_MaterialInstanceConstantParameter",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
			},
		};
		CustomPropertyDrawProxies = new array</*config */CustomPropertyItemBindings.PropertyItemCustomProxy>
		{
			new CustomPropertyItemBindings.PropertyItemCustomProxy
			{
				PropertyPathName = "Engine.UIScreenObject:PlayerInputMask",
				PropertyItemClassName = "UnrealEd.PlayerInputMask_CustomDrawProxy",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
				PropertyItemClass = default,
			},
		};
		CustomPropertyInputProxies = new array</*config */CustomPropertyItemBindings.PropertyItemCustomProxy>
		{
			new CustomPropertyItemBindings.PropertyItemCustomProxy
			{
				PropertyPathName = "Engine.UIScreenObject:PlayerInputMask",
				PropertyItemClassName = "UnrealEd.PlayerInputMask_CustomInputProxy",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
				PropertyItemClass = default,
			},
			new CustomPropertyItemBindings.PropertyItemCustomProxy
			{
				PropertyPathName = "Engine.UIScreenObject:InactiveStates.InactiveStates",
				PropertyItemClassName = "UnrealEd.UIState_CustomInputProxy",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
				PropertyItemClass = default,
			},
			new CustomPropertyItemBindings.PropertyItemCustomProxy
			{
				PropertyPathName = "Engine.UIScreenObject:InitialState",
				PropertyItemClassName = "UnrealEd.UIStateClass_CustomInputProxy",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
				PropertyItemClass = default,
			},
		};
		CustomPropertyTypeDrawProxies = new array</*config */CustomPropertyItemBindings.PropertyTypeCustomProxy>
		{
			new CustomPropertyItemBindings.PropertyTypeCustomProxy
			{
				PropertyName = (name)"ObjectProperty",
				PropertyObjectClassPathName = "Engine.UITexture",
				PropertyItemClassName = "UnrealEd.UITexture_CustomDrawProxy",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
				PropertyItemClass = default,
			},
		};
		CustomPropertyTypeInputProxies = new array</*config */CustomPropertyItemBindings.PropertyTypeCustomProxy>
		{
			new CustomPropertyItemBindings.PropertyTypeCustomProxy
			{
				PropertyName = (name)"ObjectProperty",
				PropertyObjectClassPathName = "Engine.UITexture",
				PropertyItemClassName = "UnrealEd.UITexture_CustomInputProxy",
				bReplaceArrayHeaders = false,
				bIgnoreArrayElements = false,
				PropertyItemClass = default,
			},
		};
	}
}
}