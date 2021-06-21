namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIStyle : UIRoot/* within UISkin*//*
		native
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public new UISkin Outer => base.Outer as UISkin;
	
	public UIRoot.STYLE_ID StyleID;
	public name StyleTag;
	public/*()*/ /*const localized */String StyleName;
	public /*const */String StyleGroupName;
	public /*const */Core.ClassT<UIStyle_Data> StyleDataClass;
	public /*native const transient *//*map<0,0>*/map<object, object> StateDataMap;
	
	// Export UUIStyle::execGetStyleForState(FFrame&, void* const)
	public virtual /*native final function */UIStyle_Data GetStyleForState(UIState StateObject)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIStyle::execGetStyleForStateByClass(FFrame&, void* const)
	public virtual /*native final function */UIStyle_Data GetStyleForStateByClass(Core.ClassT<UIState> StateClass)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*final event */UIStyle_Data GetDefaultStyle()
	{
		// stub
		return default;
	}
	
	public UIStyle()
	{
		// Object Offset:0x004527FE
		StyleName = "Default Style";
	}
}
}