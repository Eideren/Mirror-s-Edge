namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction : SequenceAction/*
		abstract
		native
		hidecategories(Object)*/{
	public /*noimport transient */int GamepadID;
	public/*()*/ bool bAutoTargetOwner;
	
	// Export UUIAction::execGetOwner(FFrame&, void* const)
	public virtual /*native final function */UIScreenObject GetOwner()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIAction::execGetOwnerScene(FFrame&, void* const)
	public virtual /*native final function */UIScene GetOwnerScene()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */bool IsValidLevelSequenceObject()
	{
	
		return default;
	}
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject TargetObject = default)
	{
	
		return default;
	}
	
	public UIAction()
	{
		// Object Offset:0x004005C3
		GamepadID = -1;
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Target",
				LinkVar = (name)"None",
				PropertyName = (name)"Targets",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "Player Index",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "Gamepad Id",
				LinkVar = (name)"None",
				PropertyName = (name)"GamepadID",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjClassVersion = 4;
		ObjCategory = "UI";
	}
}
}