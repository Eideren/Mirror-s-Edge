namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_TakeDamage : SequenceEvent/*
		hidecategories(Object)*/{
	[Category] public float MinDamageAmount;
	[Category] public float DamageThreshold;
	[Category] public array< Core.ClassT<DamageType> > DamageTypes;
	[Category] public array< Core.ClassT<DamageType> > IgnoreDamageTypes;
	public float CurrentDamage;
	
	public virtual /*final function */bool IsValidDamageType(Core.ClassT<DamageType> inDamageType)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */void HandleDamage(Actor InOriginator, Actor InInstigator, Core.ClassT<DamageType> inDamageType, int inAmount)
	{
		// stub
	}
	
	public override /*function */void Reset()
	{
		// stub
	}
	
	public SeqEvent_TakeDamage()
	{
		// Object Offset:0x003DDF1A
		DamageThreshold = 100.0f;
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Instigator",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = true,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Float>()/*Ref Class'SeqVar_Float'*/,
				LinkedVariables = default,
				LinkDesc = "Damage Taken",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = true,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjClassVersion = 3;
		ObjName = "Take Damage";
		ObjCategory = "Actor";
	}
}
}