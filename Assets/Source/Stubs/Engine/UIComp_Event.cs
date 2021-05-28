namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_Event : UIComponent/* within UIScreenObject*//*
		native*/{
	public new UIScreenObject Outer => base.Outer as UIScreenObject;
	
	public array<UIRoot.DefaultEventSpecification> DefaultEvents;
	public /*export editinline */UISequence EventContainer;
	public /*transient */UIEvent_ProcessInput InputProcessor;
	public array<name> DisabledEventAliases;
	
	// Export UUIComp_Event::execRegisterInputEvents(FFrame&, void* const)
	public virtual /*native final function */void RegisterInputEvents(UIState InputEventOwner, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_Event::execUnregisterInputEvents(FFrame&, void* const)
	public virtual /*native final function */void UnregisterInputEvents(UIState InputEventOwner, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
}
}