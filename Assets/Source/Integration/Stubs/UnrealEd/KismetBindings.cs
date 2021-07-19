namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class KismetBindings : Object/*
		native
		config(Editor)*/{
	public partial struct /*native */KismetKeyBind
	{
		[config] public name Key;
		[config] public bool bControl;
		[config] public bool bShift;
		[config] public name SeqObjClassName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00023C96
	//		Key = (name)"None";
	//		bControl = false;
	//		bShift = false;
	//		SeqObjClassName = (name)"None";
	//	}
	};
	
	public partial struct /*native */KismetCommentPreset
	{
		[config] public name PresetName;
		[config] public int BorderWidth;
		[config] public Object.Color BorderColor;
		[config] public bool bFilled;
		[config] public Object.Color FillColor;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00023E8A
	//		PresetName = (name)"None";
	//		BorderWidth = 0;
	//		BorderColor = new Color
	//		{
	//			R=0,
	//			G=0,
	//			B=0,
	//			A=0
	//		};
	//		bFilled = false;
	//		FillColor = new Color
	//		{
	//			R=0,
	//			G=0,
	//			B=0,
	//			A=0
	//		};
	//	}
	};
	
	[config] public array</*config */KismetBindings.KismetKeyBind> Bindings;
	[config] public array</*config */KismetBindings.KismetCommentPreset> CommentPresets;
	
	public KismetBindings()
	{
		// Object Offset:0x00023F62
		Bindings = new array</*config */KismetBindings.KismetKeyBind>
		{
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"O",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqVar_Object",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"S",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqAct_PlaySound",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"P",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqVar_Player",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"I",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqVar_Int",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"I",
				bControl = true,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqCond_CompareInt",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"F",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqVar_Float",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"F",
				bControl = true,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqCond_CompareFloat",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"B",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqVar_Bool",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"B",
				bControl = true,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqCond_CompareBool",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"N",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqVar_Named",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"E",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqVar_External",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"LeftBracket",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqEvent_SequenceActivated",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"RightBracket",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqAct_FinishSequence",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"T",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqAct_Toggle",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"D",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqAct_Delay",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"L",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqAct_Log",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"M",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqAct_Interp",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"S",
				bControl = true,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqEvent_LevelStartup",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"X",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqCond_Increment",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"Q",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.Sequence",
			},
			new KismetBindings.KismetKeyBind
			{
				Key = (name)"G",
				bControl = false,
				bShift = false,
				SeqObjClassName = (name)"Engine.SeqAct_Gate",
			},
		};
		CommentPresets = new array</*config */KismetBindings.KismetCommentPreset>
		{
			new KismetBindings.KismetCommentPreset
			{
				PresetName = (name)"Default",
				BorderWidth = 1,
				BorderColor = new Color
				{
					R=0,
					G=0,
					B=0,
					A=255
				},
				bFilled = true,
				FillColor = new Color
				{
					R=0,
					G=0,
					B=0,
					A=16
				},
			},
		};
	}
}
}