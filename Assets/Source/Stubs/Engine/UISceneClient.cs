namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UISceneClient : UIRoot/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*private native const noexport */Object.Pointer VfTable_FExec;
	public /*private native const noexport */Object.Pointer VfTable_FCallbackEventDevice;
	public /*native const transient */Object.Pointer RenderViewport;
	public /*transient */UISkin ActiveSkin;
	public /*const transient */Object.IntPoint MousePosition;
	public /*const transient */UIObject ActiveControl;
	public /*const transient */DataStoreClient DataStoreManager;
	public /*transient */MaterialInstanceConstant OpacityParameter;
	public /*const transient */name OpacityParameterName;
	public /*const transient */Object.Matrix CanvasToScreen;
	public /*const transient */Object.Matrix InvCanvasToScreen;
	public /*transient */PostProcessChain UIScenePostProcess;
	public /*transient */bool bEnablePostProcess;
	
	// Export UUISceneClient::execChangeActiveSkin(FFrame&, void* const)
	public virtual /*native final function */bool ChangeActiveSkin(UISkin NewActiveSkin)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISceneClient::execIsUIActive(FFrame&, void* const)
	public virtual /*native final function */bool IsUIActive(/*optional */int? _Flags = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISceneClient::execIsSceneInitialized(FFrame&, void* const)
	public virtual /*native final function */bool IsSceneInitialized(UIScene Scene)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISceneClient::execInitializeScene(FFrame&, void* const)
	public virtual /*native final function */bool InitializeScene(UIScene Scene, /*optional */LocalPlayer? _SceneOwner/* = default*/, /*optional */ref UIScene InitializedScene/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISceneClient::execOpenScene(FFrame&, void* const)
	public virtual /*native final function */bool OpenScene(UIScene Scene, /*optional */LocalPlayer? _SceneOwner/* = default*/, /*optional */ref UIScene OpenedScene/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISceneClient::execCloseScene(FFrame&, void* const)
	public virtual /*native function */bool CloseScene(UIScene Scene)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISceneClient::execSetMousePosition(FFrame&, void* const)
	public virtual /*native final function */void SetMousePosition(int NewMouseX, int NewMouseY)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUISceneClient::execChangeMouseCursor(FFrame&, void* const)
	public virtual /*native final function */bool ChangeMouseCursor(name CursorName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISceneClient::execUpdateCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */void UpdateCanvasToScreen()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUISceneClient::execGetCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetCanvasToScreen(/*const optional */UIObject? _Widget = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISceneClient::execGetInverseCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetInverseCanvasToScreen(/*const optional */UIObject? _Widget = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */UIScene GetActiveScene()
	{
	
		return default;
	}
	
	public UISceneClient()
	{
		// Object Offset:0x00335AD2
		OpacityParameterName = (name)"UI_Opacity";
		bEnablePostProcess = true;
	}
}
}