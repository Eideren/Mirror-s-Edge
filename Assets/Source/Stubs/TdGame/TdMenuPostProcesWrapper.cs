namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMenuPostProcesWrapper : Object{
	public partial struct TdEffectPanelStruct
	{
		public MaterialInstanceConstant MaterialIC;
		public UIImage PanelImage;
		public float AnimPosition;
		public bool bActive;
		public float MinWidth;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0058F488
	//		MaterialIC = default;
	//		PanelImage = default;
	//		AnimPosition = 0.0f;
	//		bActive = false;
	//		MinWidth = 0.0f;
	//	}
	};
	
	public /*private */Material PanelMaterial;
	public /*private */array<TdMenuPostProcesWrapper.TdEffectPanelStruct> PanelsData;
	public /*private */float PanelAnimDuration;
	public /*private */float UnfocusedPanelBGWidth;
	public /*private */Object.LinearColor SelectionColor;
	public /*delegate*/TdMenuPostProcesWrapper.OnPanelAnimFinished __OnPanelAnimFinished__Delegate;
	
	public delegate void OnPanelAnimFinished(int FinishedPanelIndex, bool bPanelActive);
	
	public virtual /*function */void Initialize(array<UIImage> PanelImages, /*optional *//*delegate*/TdMenuPostProcesWrapper.OnPanelAnimFinished? _PanelAnimFinished = default, /*optional */float? _UnfocusedMinWidth = default)
	{
		// stub
	}
	
	public virtual /*function */void Destroy()
	{
		// stub
	}
	
	public virtual /*function */void SetAnimDurations(float PanelAnimDur)
	{
		// stub
	}
	
	public virtual /*function */bool IsAnimating()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void Tick(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*private final function */void UpdatePanelAnimation(int PanelIndex)
	{
		// stub
	}
	
	public virtual /*private final function */int GetActivePanelIndex()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetSelectionFieldPos(int PanelIndex, float Top, float Bottom)
	{
		// stub
	}
	
	public virtual /*function */void DeativatePanel(int PanelIndex)
	{
		// stub
	}
	
	public virtual /*function */void SetActivePanel(int PanelIndexToActivate, /*optional */bool? _bSkipAnimation = default)
	{
		// stub
	}
	
	public virtual /*private final function */void SetPanelWidth(int PanelIndex, float NewWidth)
	{
		// stub
	}
	
	public virtual /*private final function */void SetSelectionField(int PanelIndex, float TopPos, float BottomPos)
	{
		// stub
	}
	
	public virtual /*private final function */void SetPanelSelFieldVis(int PanelIndex, bool bVisible)
	{
		// stub
	}
	
	public virtual /*private final function */void SetPanelMovementOffset(int PanelIndex, float Offset)
	{
		// stub
	}
	
	public virtual /*private final function */void SetPanelSideOffset(int PanelIndex, float LeftOffset, float RightOffset)
	{
		// stub
	}
	
	public virtual /*private final function */void SetPanelMovementAmount(int PanelIndex, float Amount)
	{
		// stub
	}
	
	public virtual /*private final function */void SetSelectionColor(Object.LinearColor SelColor)
	{
		// stub
	}
	
	public virtual /*private final function */void SetParamFloat(int PanelIndex, name ParamName, float Value)
	{
		// stub
	}
	
	public TdMenuPostProcesWrapper()
	{
		// Object Offset:0x00590B14
		PanelMaterial = LoadAsset<Material>("UI_Menus.M_MainMenuStick_01")/*Ref Material'UI_Menus.M_MainMenuStick_01'*/;
		PanelAnimDuration = 0.30f;
		UnfocusedPanelBGWidth = 0.020f;
		SelectionColor = new LinearColor
		{
			R=255.0f,
			G=255.0f,
			B=255.0f,
			A=1.0f
		};
	}
}
}