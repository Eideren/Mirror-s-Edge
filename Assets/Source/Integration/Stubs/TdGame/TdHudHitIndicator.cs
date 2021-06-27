namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudHitIndicator : TdHUDObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public partial struct /*native */DamageDataInfo
	{
		public float FadeTime;
		public float FadeValue;
		public MaterialInstanceConstant MatConstant;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x005767D6
	//		FadeTime = 0.0f;
	//		FadeValue = 0.0f;
	//		MatConstant = default;
	//	}
	};
	
	public int MaxNoOfIndicators;
	public array<TdHudHitIndicator.DamageDataInfo> DamageData;
	public/*(Widget)*/ Material BaseMaterial;
	public/*(Widget)*/ float FadeTime;
	public/*(Widget)*/ name PositionalParamName;
	public/*(Widget)*/ name FadeParamName;
	
	public override /*event */void Initialized()
	{
		// stub
	}
	
	public virtual /*function */void TrackDamage(Object.Vector HitDir, int Damage, Core.ClassT<DamageType> DamageType)
	{
		// stub
	}
	
	public virtual /*function */void FlashDamage(float FlashPosition)
	{
		// stub
	}
	
	public TdHudHitIndicator()
	{
		var Default__TdHudHitIndicator_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHudHitIndicator.WidgetEventComponent' */;
		// Object Offset:0x00577266
		MaxNoOfIndicators = 3;
		FadeTime = 0.50f;
		PositionalParamName = (name)"DamageDirectionRotation";
		FadeParamName = (name)"DamageDirectionAlpha";
		requiresTick = true;
		WidgetTag = (name)"HudHitIndicator";
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = 0.3750f,
				[1] = 0.250f,
				[2] = 0.1250f,
				[3] = 0.166660f,
			},
			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = UIRoot.EPositionEvalType.EVALPOS_PercentageScene,
				[1] = UIRoot.EPositionEvalType.EVALPOS_PercentageScene,
				[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageScene,
				[3] = UIRoot.EPositionEvalType.EVALPOS_PercentageScene,
			},
		};
		EventProvider = Default__TdHudHitIndicator_WidgetEventComponent/*Ref UIComp_Event'Default__TdHudHitIndicator.WidgetEventComponent'*/;
	}
}
}