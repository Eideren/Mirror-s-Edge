namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBubbleStack : Object{
	public partial struct /*native */BoolItem
	{
		public bool flag;
		public name Identifier;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0052EA27
	//		flag = false;
	//		Identifier = (name)"None";
	//	}
	};
	
	public /*private */TdAIController myDebugController;
	public /*private */name myDebugFilter;
	public /*private */int myMaxDepth;
	public /*private */bool myStartValue;
	public /*private */array<TdBubbleStack.BoolItem> BoolStack;
	
	public virtual /*function */void Initialize(bool StartValue, /*optional */int? _MaxDepth = default, /*optional */TdAIController _DebugController = default, /*optional */name? _DebugFilter = default)
	{
		// stub
	}
	
	public virtual /*function */void Reset()
	{
		// stub
	}
	
	public virtual /*function */bool GetBool()
	{
		// stub
		return default;
	}
	
	public virtual /*function */name GetIdentifier()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void PushBool(bool flag, name Identifier, /*optional */bool? _bDebug = default)
	{
		// stub
	}
	
	public virtual /*function */void PopBool(name Identifier, /*optional */bool? _bDebug = default)
	{
		// stub
	}
	
	public virtual /*private final function */int FindIdentifier(name Identifier)
	{
		// stub
		return default;
	}
	
}
}