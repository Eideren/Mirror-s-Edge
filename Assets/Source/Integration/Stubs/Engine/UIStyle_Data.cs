namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIStyle_Data : UIRoot/*
		abstract
		native
		hidecategories(Object,UIRoot)*/{
	[editoronly, Const] public String UIEditorControlClass;
	public Object.LinearColor StyleColor;
	public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ StylePadding;
	public bool bEnabled;
	[transient] public bool bDirty;
	
	public UIStyle_Data()
	{
		// Object Offset:0x004529AB
		StyleColor = new LinearColor
		{
			R=1.0f,
			G=1.0f,
			B=1.0f,
			A=1.0f
		};
	}
}
}