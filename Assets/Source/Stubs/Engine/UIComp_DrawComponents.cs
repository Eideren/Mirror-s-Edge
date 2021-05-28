namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_DrawComponents : UIComponent/* within UIObject*//*
		native*/{
	public enum EFadeType 
	{
		EFT_None,
		EFT_Fading,
		EFT_Pulsing,
		EFT_MAX
	};
	
	public new UIObject Outer => base.Outer as UIObject;
	
	public/*(Fading)*/ /*transient */UIComp_DrawComponents.EFadeType FadeType;
	public/*(Fading)*/ /*transient */float FadeAlpha;
	public/*(Fading)*/ /*transient */float FadeTarget;
	public/*(Fading)*/ /*transient */float FadeTime;
	public /*transient */float LastRenderTime;
	public /*transient */float FadeRate;
	public /*delegate*/UIComp_DrawComponents.OnFadeComplete __OnFadeComplete__Delegate;
	
	// Export UUIComp_DrawComponents::execFade(FFrame&, void* const)
	public virtual /*native final function */void Fade(float FromAlpha, float ToAlpha, float TargetFadeTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawComponents::execPulse(FFrame&, void* const)
	public virtual /*native final function */void Pulse(/*optional */float MaxAlpha = default, /*optional */float MinAlpha = default, /*optional */float PulseRate = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawComponents::execResetFade(FFrame&, void* const)
	public virtual /*native final function */void ResetFade()
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnFadeComplete(UIComp_DrawComponents Sender);
	
}
}