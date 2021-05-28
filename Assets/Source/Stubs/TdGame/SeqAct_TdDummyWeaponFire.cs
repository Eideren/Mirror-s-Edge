namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdDummyWeaponFire : SeqAct_Latent/*
		hidecategories(Object)*/{
	public TdDummyPawn DummyPawn;
	public/*()*/ int ShotsToFire;
	public/*()*/ Core.ClassT<TdWeapon> WeaponClass;
	public/*()*/ byte FireMode;
	public/*()*/ Actor Origin;
	public/*()*/ Actor Target;
	public/*()*/ Object.Rotator MaxSpread;
	public int ShotsFired;
	
	public override /*event */void Activated()
	{
	
	}
	
	public virtual /*function */void NotifyDummyFire()
	{
	
	}
	
	public override /*event */bool Update(float DeltaTime)
	{
	
		return default;
	}
	
	public SeqAct_TdDummyWeaponFire()
	{
		// Object Offset:0x00498935
		ShotsToFire = 1;
		bCallHandler = false;
		bAutoActivateOutputLinks = false;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Start Firing",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Stop Firing",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Out",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Finished",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Stopped",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Origin",
				LinkVar = (name)"None",
				PropertyName = (name)"Origin",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Target",
				LinkVar = (name)"None",
				PropertyName = (name)"Target",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Dummy Weapon Fire";
		ObjCategory = "Cinematic";
	}
}
}