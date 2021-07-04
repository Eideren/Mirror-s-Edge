// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Interaction : UIRoot/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*delegate*/Interaction.OnReceivedNativeInputKey __OnReceivedNativeInputKey__Delegate;
	public /*delegate*/Interaction.OnReceivedNativeInputAxis __OnReceivedNativeInputAxis__Delegate;
	public /*delegate*/Interaction.OnReceivedNativeInputChar __OnReceivedNativeInputChar__Delegate;
	public /*delegate*/Interaction.OnInitialize __OnInitialize__Delegate;
	
	public delegate bool OnReceivedNativeInputKey(int ControllerId, name Key, Object.EInputEvent EventType, /*optional */float? _AmountDepressed = default, /*optional */bool? _bGamepad = default);
	
	#warning default implementation of above delegate
	public bool OnReceivedNativeInputKey_Default(int ControllerId, name Key, Object.EInputEvent EventType, /*optional */float? _AmountDepressed = default, /*optional */bool? _bGamepad = default)
	{
		var AmountDepressed = _AmountDepressed ?? 1.0f;
		var bGamepad = _bGamepad ?? default;
		return default;
	}



	public delegate bool OnReceivedNativeInputAxis( int ControllerId, name Key, float Delta, float DeltaTime, /*optional */bool? _bGamepad = default );
	public bool OnReceivedNativeInputAxis_Default(int ControllerId, name Key, float Delta, float DeltaTime, /*optional */bool? _bGamepad = default)
	{
		var bGamepad = _bGamepad ?? default;
		return default;
	}
	
	public delegate bool OnReceivedNativeInputChar(int ControllerId, String Unicode);
	
	public virtual /*event */void Tick(float DeltaTime)
	{
	
	}
	
	// Export UInteraction::execInit(FFrame&, void* const)
	public virtual /*native final function */void Init()
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	public delegate void OnInitialize();
	
	public virtual /*function */void Initialized()
	{
	
	}
	
	public virtual /*function */void NotifyGameSessionEnded()
	{
	
	}
	
	public virtual /*function */void NotifyPlayerAdded(int PlayerIndex, LocalPlayer AddedPlayer)
	{
	
	}
	
	public virtual /*function */void NotifyPlayerRemoved(int PlayerIndex, LocalPlayer RemovedPlayer)
	{
	
	}
	
	public Interaction()
	{
		// Object Offset:0x002C8DA1
		__OnInitialize__Delegate = () => Initialized();
	}
}
}