namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdConsole : Console/* within GameViewportClient*//*
		transient
		native
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public new GameViewportClient Outer => base.Outer as GameViewportClient;
	
	public array<String> KeyStrings;
	public int ActiveKeywordIndex;
	public String SavedArgument;
	public String SavedCommand;
	public bool bCtrlIsPressed;
	
	// Export UTdConsole::execInitKeyStrings(FFrame&, void* const)
	public virtual /*native function */void InitKeyStrings()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTdConsole::execFindKeyWord(FFrame&, void* const)
	public virtual /*native function */bool FindKeyWord(String Str, ref String KeyWord, ref int Index)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public override /*function */void Initialized()
	{
		// stub
	}
	
	public virtual /*function */String GetStringToComplete(String TypedStrTmp)
	{
		// stub
		return default;
	}
	
	
	protected /*event */bool TdConsole_Typing_InputKey(int ControllerId, name Key, Object.EInputEvent Event, /*optional */float? _AmountDepressed = default, /*optional */bool? _bGamepad = default)// state function
	{
		// stub
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Typing()/*state Typing*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Typing": return Typing();
			default: return base.FindState(stateName);
		}
	}
	public TdConsole()
	{
		// Object Offset:0x00536ED9
		KeyStrings = new array<String>
		{
			"ShowAnims",
			"ShowAnimTimeLine",
			"start ",
			"suicide",
			"slomo ",
			"killall ",
			"ShowExtentLineCheck",
			"DebugMove ",
			"DebugActiveMove",
			"SetActiveActor",
			"ShowAnimsActiveActor",
			"NeverUseStreamingVolumes",
		};
	}
}
}