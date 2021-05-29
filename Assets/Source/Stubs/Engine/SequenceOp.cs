namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SequenceOp : SequenceObject/*
		abstract
		native
		hidecategories(Object)*/{
	public partial struct /*native */SeqOpInputLink
	{
		public string LinkDesc;
		public bool bHasImpulse;
		public bool bDisabled;
		public bool bDisabledPIE;
		public SequenceOp LinkedOp;
		public int DrawY;
		public bool bHidden;
		public float ActivateDelay;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002D90DB
	//		LinkDesc = "";
	//		bHasImpulse = false;
	//		bDisabled = false;
	//		bDisabledPIE = false;
	//		LinkedOp = default;
	//		DrawY = 0;
	//		bHidden = false;
	//		ActivateDelay = 0.0f;
	//	}
	};
	
	public partial struct /*native */SeqOpOutputInputLink
	{
		public SequenceOp LinkedOp;
		public int InputLinkIdx;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002D924F
	//		LinkedOp = default;
	//		InputLinkIdx = 0;
	//	}
	};
	
	public partial struct /*native */SeqOpOutputLink
	{
		public array<SequenceOp.SeqOpOutputInputLink> Links;
		public string LinkDesc;
		public bool bHasImpulse;
		public bool bDisabled;
		public bool bDisabledPIE;
		public SequenceOp LinkedOp;
		public float ActivateDelay;
		public int DrawY;
		public bool bHidden;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002D9483
	//		Links = default;
	//		LinkDesc = "";
	//		bHasImpulse = false;
	//		bDisabled = false;
	//		bDisabledPIE = false;
	//		LinkedOp = default;
	//		ActivateDelay = 0.0f;
	//		DrawY = 0;
	//		bHidden = false;
	//	}
	};
	
	public partial struct /*native */SeqVarLink
	{
		public Core.ClassT<SequenceVariable> ExpectedType;
		public array<SequenceVariable> LinkedVariables;
		public string LinkDesc;
		public name LinkVar;
		public name PropertyName;
		public bool bWriteable;
		public bool bHidden;
		public int MinVars;
		public int MaxVars;
		public int DrawX;
		public /*const transient */Property CachedProperty;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002D97DB
	//		ExpectedType = ClassT<SequenceVariable>()/*Ref Class'SequenceVariable'*/;
	//		LinkedVariables = default;
	//		LinkDesc = "";
	//		LinkVar = (name)"None";
	//		PropertyName = (name)"None";
	//		bWriteable = false;
	//		bHidden = false;
	//		MinVars = 1;
	//		MaxVars = 255;
	//		DrawX = 0;
	//		CachedProperty = default;
	//	}
	};
	
	public partial struct /*native */SeqEventLink
	{
		public Core.ClassT<SequenceEvent> ExpectedType;
		public array<SequenceEvent> LinkedEvents;
		public string LinkDesc;
		public int DrawX;
		public bool bHidden;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002D9A67
	//		ExpectedType = ClassT<SequenceEvent>()/*Ref Class'SequenceEvent'*/;
	//		LinkedEvents = default;
	//		LinkDesc = "";
	//		DrawX = 0;
	//		bHidden = false;
	//	}
	};
	
	public bool bActive;
	public /*const */bool bLatentExecution;
	public bool bAutoActivateOutputLinks;
	public array<SequenceOp.SeqOpInputLink> InputLinks;
	public array<SequenceOp.SeqOpOutputLink> OutputLinks;
	public array<SequenceOp.SeqVarLink> VariableLinks;
	public array<SequenceOp.SeqEventLink> EventLinks;
	public /*noimport transient */int PlayerIndex;
	public /*transient */int ActivateCount;
	public /*protected duplicatetransient const transient */int SearchTag;
	
	// Export USequenceOp::execHasLinkedOps(FFrame&, void* const)
	public virtual /*native final function */bool HasLinkedOps(/*optional */bool? _bConsiderInputLinks = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USequenceOp::execGetLinkedObjects(FFrame&, void* const)
	public virtual /*native final function */void GetLinkedObjects(ref array<SequenceObject> out_Objects, /*optional */Core.ClassT<SequenceObject>? _ObjectType = default, /*optional */bool? _bRecurse = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USequenceOp::execGetObjectVars(FFrame&, void* const)
	public virtual /*native final function */void GetObjectVars(ref array<Object> objVars, /*optional */string? _inDesc = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USequenceOp::execGetBoolVars(FFrame&, void* const)
	public virtual /*native final function */void GetBoolVars(ref array<byte> boolVars, /*optional */string? _inDesc = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USequenceOp::execLinkedVariables(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<SequenceVariable/* OutVariable*/> LinkedVariables(Core.ClassT<SequenceVariable> VarClass, /*optional */string? _inDesc = default)
	{
		#warning NATIVE FUNCTION !
		yield return default;
	}
	
	public virtual /*event */void Activated()
	{
	
	}
	
	public virtual /*event */void Deactivated()
	{
	
	}
	
	public virtual /*event */void VersionUpdated(int OldVersion, int NewVersion)
	{
	
	}
	
	// Export USequenceOp::execPopulateLinkedVariableValues(FFrame&, void* const)
	public virtual /*native final function */void PopulateLinkedVariableValues()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USequenceOp::execPublishLinkedVariableValues(FFrame&, void* const)
	public virtual /*native final function */void PublishLinkedVariableValues()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void Reset()
	{
	
	}
	
	public virtual /*function */Pawn GetPawn(Actor TheActor)
	{
	
		return default;
	}
	
	public virtual /*function */Controller GetController(Actor TheActor)
	{
	
		return default;
	}
	
	public SequenceOp()
	{
		// Object Offset:0x002DA3C5
		bAutoActivateOutputLinks = true;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "In",
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
		};
		PlayerIndex = -1;
	}
}
}