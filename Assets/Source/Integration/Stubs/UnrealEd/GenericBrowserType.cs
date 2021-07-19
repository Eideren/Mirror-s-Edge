namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GenericBrowserType : Object/*
		abstract
		native
		hidecategories(Object,GenericBrowserType)*/{
	public partial struct /*native */GenericBrowserTypeInfo
	{
		[Const] public Class Class;
		[Const] public Object.Color BorderColor;
		[native, Const] public Object.QWord RequiredFlags;
		[native, Const] public Object.Pointer ContextMenu;
		public GenericBrowserType BrowserType;
		[native] public Object.Pointer IsSupportedCallback;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002195F
	//		Class = default;
	//		BorderColor = new Color
	//		{
	//			R=0,
	//			G=0,
	//			B=0,
	//			A=0
	//		};
	//		BrowserType = default;
	//	}
	};
	
	public String Description;
	[native] public array<GenericBrowserType.GenericBrowserTypeInfo> SupportInfo;
	public Object.Color BorderColor;
	
}
}