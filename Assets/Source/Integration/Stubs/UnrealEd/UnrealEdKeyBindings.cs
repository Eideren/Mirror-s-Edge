namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UnrealEdKeyBindings : Object/*
		native
		config(EditorKeyBindings)*/{
	public partial struct /*native */EditorKeyBinding
	{
		public bool bCtrlDown;
		public bool bAltDown;
		public bool bShiftDown;
		public name Key;
		public name CommandName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002F51B
	//		bCtrlDown = false;
	//		bAltDown = false;
	//		bShiftDown = false;
	//		Key = (name)"None";
	//		CommandName = (name)"None";
	//	}
	};
	
	public /*config */array</*config */UnrealEdKeyBindings.EditorKeyBinding> KeyBindings;
	
}
}