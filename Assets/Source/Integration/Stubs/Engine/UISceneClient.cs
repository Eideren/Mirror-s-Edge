namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UISceneClient : UIRoot/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FExec;
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FCallbackEventDevice;
	[native, Const, transient] public Object.Pointer RenderViewport;
	[transient] public UISkin ActiveSkin;
	[Const, transient] public Object.IntPoint MousePosition;
	[Const, transient] public UIObject ActiveControl;
	[Const, transient] public DataStoreClient DataStoreManager;
	[transient] public MaterialInstanceConstant OpacityParameter;
	[Const, transient] public name OpacityParameterName;
	[Const, transient] public Object.Matrix CanvasToScreen;
	[Const, transient] public Object.Matrix InvCanvasToScreen;
	[transient] public PostProcessChain UIScenePostProcess;
	[transient] public bool bEnablePostProcess;
	
	// Export UUISceneClient::execChangeActiveSkin(FFrame&, void* const)
	public virtual /*native final function */bool ChangeActiveSkin(UISkin NewActiveSkin)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISceneClient::execIsUIActive(FFrame&, void* const)
	public virtual /*native final function */bool IsUIActive(/*optional */int? _Flags = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISceneClient::execIsSceneInitialized(FFrame&, void* const)
	public virtual /*native final function */bool IsSceneInitialized(UIScene Scene)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISceneClient::execInitializeScene(FFrame&, void* const)
	public virtual /*native final function */bool InitializeScene(UIScene Scene, /*optional */LocalPlayer _SceneOwner/* = default*/, /*optional */ref UIScene InitializedScene/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISceneClient::execOpenScene(FFrame&, void* const)
	public virtual /*native final function */bool OpenScene(UIScene Scene, /*optional */LocalPlayer _SceneOwner/* = default*/, /*optional */ref UIScene OpenedScene/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISceneClient::execCloseScene(FFrame&, void* const)
	public virtual /*native function */bool CloseScene(UIScene Scene)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISceneClient::execSetMousePosition(FFrame&, void* const)
	public virtual /*native final function */void SetMousePosition(int NewMouseX, int NewMouseY)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUISceneClient::execChangeMouseCursor(FFrame&, void* const)
	public virtual /*native final function */bool ChangeMouseCursor(name CursorName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISceneClient::execUpdateCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */void UpdateCanvasToScreen()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUISceneClient::execGetCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetCanvasToScreen(/*const optional */UIObject _Widget = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISceneClient::execGetInverseCanvasToScreen(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetInverseCanvasToScreen(/*const optional */UIObject _Widget = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */UIScene GetActiveScene()
	{
		// stub
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