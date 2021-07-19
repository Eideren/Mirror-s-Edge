namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIEvent : SequenceEvent/*
		abstract
		native
		hidecategories(Object)*/{
	[noimport] public UIScreenObject EventOwner;
	public Object EventActivator;
	[Const, localized] public String Description;
	public bool bShouldRegisterEvent;
	public bool bPropagateEvent;
	public /*delegate*/UIEvent.AllowEventActivation __AllowEventActivation__Delegate;
	
	public delegate bool AllowEventActivation(int ControllerIndex, UIScreenObject InEventOwner, Object InEventActivator, bool bActivateImmediately, /*const */ref array<int> IndicesToActivate);
	
	// Export UUIEvent::execGetOwner(FFrame&, void* const)
	public virtual /*native final function */UIScreenObject GetOwner()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIEvent::execGetOwnerScene(FFrame&, void* const)
	public virtual /*native final function */UIScene GetOwnerScene()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIEvent::execCanBeActivated(FFrame&, void* const)
	public virtual /*native final function */bool CanBeActivated(int ControllerIndex, UIScreenObject InEventOwner, /*optional */Object _InEventActivator/* = default*/, /*optional */bool? _bActivateImmediately/* = default*/, /*const optional */ref array<int> IndicesToActivate/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIEvent::execConditionalActivateUIEvent(FFrame&, void* const)
	public virtual /*native final function */bool ConditionalActivateUIEvent(int ControllerIndex, UIScreenObject InEventOwner, /*optional */Object _InEventActivator/* = default*/, /*optional */bool? _bActivateImmediately/* = default*/, /*const optional */ref array<int> IndicesToActivate/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIEvent::execActivateUIEvent(FFrame&, void* const)
	public virtual /*native final function */bool ActivateUIEvent(int ControllerIndex, UIScreenObject InEventOwner, /*optional */Object _InEventActivator/* = default*/, /*optional */bool? _bActivateImmediately/* = default*/, /*const optional */ref array<int> IndicesToActivate/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*event */bool IsValidLevelSequenceObject()
	{
		// stub
		return default;
	}
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool ShouldAlwaysInstance()
	{
		// stub
		return default;
	}
	
	public UIEvent()
	{
		// Object Offset:0x002DBA0D
		bShouldRegisterEvent = true;
		bPropagateEvent = true;
		MaxTriggerCount = 0;
		bClientSideOnly = true;
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Activator",
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
				PropertyName = (name)"None",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjClassVersion = 2;
		ObjCategory = "UI";
	}
}
}