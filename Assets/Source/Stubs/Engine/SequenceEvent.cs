namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SequenceEvent : SequenceOp/*
		abstract
		native
		hidecategories(Object)*/{
	public partial struct /*native */QueuedActivationInfo
	{
		public Actor InOriginator;
		public Actor InInstigator;
		public array<int> ActivateIndices;
		public bool bPushTop;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002DAA9F
	//		InOriginator = default;
	//		InInstigator = default;
	//		ActivateIndices = default;
	//		bPushTop = false;
	//	}
	};
	
	public Actor Originator;
	public /*transient */Actor Instigator;
	public /*transient */float ActivationTime;
	public /*transient */int TriggerCount;
	public/*()*/ int MaxTriggerCount;
	public/*()*/ float ReTriggerDelay;
	public/*()*/ bool bEnabled;
	public/*()*/ bool bPlayerOnly;
	public /*transient */bool bRegistered;
	public/*()*/ /*const */bool bClientSideOnly;
	public/*()*/ byte Priority;
	public int MaxWidth;
	public array<SequenceEvent.QueuedActivationInfo> QueuedActivations;
	
	public virtual /*event */void RegisterEvent()
	{
	
	}
	
	// Export USequenceEvent::execCheckActivate(FFrame&, void* const)
	public virtual /*native final function */bool CheckActivate(Actor InOriginator, Actor InInstigator, /*optional */bool bTest/* = default*/, /*const optional */ref array<int> ActivateIndices/* = default*/, /*optional */bool bPushTop = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */void Reset()
	{
	
	}
	
	public virtual /*event */void Toggled()
	{
	
	}
	
	public SequenceEvent()
	{
		// Object Offset:0x002DADB0
		MaxTriggerCount = 1;
		bEnabled = true;
		bPlayerOnly = true;
		InputLinks = default;
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
		};
		ObjColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=255
		};
	}
}
}