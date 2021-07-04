namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UISkin : UIDataStore/*
		notransient
		native
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */UISoundCue
	{
		public name SoundName;
		public SoundCue SoundToPlay;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004244C5
	//		SoundName = (name)"None";
	//		SoundToPlay = default;
	//	}
	};
	
	public /*protected const export editinline */array</*export editinline */UIStyle> Styles;
	public /*protected const */array<String> StyleGroups;
	public /*protected const */array<UISkin.UISoundCue> SoundCues;
	public /*native const transient *//*map<0,0>*/map<object, object> StyleLookupTable;
	public /*native const transient *//*map<0,0>*/map<object, object> StyleNameMap;
	public /*native const transient */Object.LookupMap_Mirror StyleGroupMap;
	public /*duplicatetransient native const *//*map<0,0>*/map<object, object> CursorMap;
	public /*native const transient *//*map<0,0>*/map<object, object> SoundCueMap;
	
	// Export UUISkin::execGetAvailableStyles(FFrame&, void* const)
	public virtual /*native final function */void GetAvailableStyles(ref array<UIStyle> out_Styles, /*optional */bool? _bIncludeInheritedStyles = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUISkin::execGetCursorResource(FFrame&, void* const)
	public virtual /*native final function */UITexture GetCursorResource(name CursorName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISkin::execAddUISoundCue(FFrame&, void* const)
	public virtual /*native final function */bool AddUISoundCue(name SoundCueName, SoundCue SoundToPlay)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISkin::execRemoveUISoundCue(FFrame&, void* const)
	public virtual /*native final function */bool RemoveUISoundCue(name SoundCueName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISkin::execGetUISoundCue(FFrame&, void* const)
	public virtual /*native final function */bool GetUISoundCue(name SoundCueName, ref SoundCue out_UISoundCue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISkin::execGetSkinSoundCues(FFrame&, void* const)
	public virtual /*native final function */void GetSkinSoundCues(ref array<UISkin.UISoundCue> out_SoundCues)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUISkin::execIsInheritedGroupName(FFrame&, void* const)
	public virtual /*native final function */bool IsInheritedGroupName(String StyleGroupName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISkin::execAddStyleGroupName(FFrame&, void* const)
	public virtual /*native final function */bool AddStyleGroupName(String StyleGroupName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISkin::execRemoveStyleGroupName(FFrame&, void* const)
	public virtual /*native final function */bool RemoveStyleGroupName(String StyleGroupName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISkin::execRenameStyleGroup(FFrame&, void* const)
	public virtual /*native final function */bool RenameStyleGroup(String OldStyleGroupName, String NewStyleGroupName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISkin::execGetStyleGroupAtIndex(FFrame&, void* const)
	public virtual /*native final function */String GetStyleGroupAtIndex(int Index)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISkin::execFindStyleGroupIndex(FFrame&, void* const)
	public virtual /*native final function */int FindStyleGroupIndex(String StyleGroupName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISkin::execGetStyleGroups(FFrame&, void* const)
	public virtual /*native final function */void GetStyleGroups(ref array<String> StyleGroupArray, /*optional */bool? _bIncludeInheritedGroups = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public UISkin()
	{
		// Object Offset:0x00424FB0
		Tag = (name)"Styles";
	}
}
}