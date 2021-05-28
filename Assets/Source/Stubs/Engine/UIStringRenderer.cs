namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface UIStringRenderer : Interface/*
		abstract
		native*/{
	// Export UUIStringRenderer::execSetTextAlignment(FFrame&, void* const)
	public /*native final function */void SetTextAlignment(UIRoot.EUIAlignment Horizontal, UIRoot.EUIAlignment Vertical);
	
}
}