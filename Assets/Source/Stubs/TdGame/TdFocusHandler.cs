namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdFocusHandler : Object/* within TdAIController*//*
		native*/{
	public enum FocusType 
	{
		FT_None,
		FT_Point,
		FT_Player,
		FT_Navigation,
		FT_Actor,
		FT_MAX
	};
	
	public new TdAIController Outer => base.Outer as TdAIController;
	
	public Object.Vector FocusPoint;
	public Actor FocusedActor;
	public TdAIController myOwner;
	public TdFocusHandler.FocusType CurrentFocus;
	
	public virtual /*function */void Initialize(TdAIController C)
	{
	
	}
	
	public virtual /*function */void SetFocus(TdFocusHandler.FocusType Focus)
	{
	
	}
	
	// Export UTdFocusHandler::execGetFocus(FFrame&, void* const)
	public virtual /*native function */bool GetFocus(ref Object.Vector out_Focus)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdFocusHandler::execGetFocusLocation(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetFocusLocation()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdFocusHandler::execHasFocus(FFrame&, void* const)
	public virtual /*native function */bool HasFocus()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void SetFocalPoint(Object.Vector NewFocus)
	{
	
	}
	
	public virtual /*function */void SetActorFocus(Actor NewFocus)
	{
	
	}
	
	public virtual /*function */string GetDescription()
	{
	
		return default;
	}
	
}
}