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
		#warning NATIVE FUNCTION !
	}
	
	// Export UUISkin::execGetCursorResource(FFrame&, void* const)
	public virtual /*native final function */UITexture GetCursorResource(name CursorName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISkin::execAddUISoundCue(FFrame&, void* const)
	public virtual /*native final function */bool AddUISoundCue(name SoundCueName, SoundCue SoundToPlay)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISkin::execRemoveUISoundCue(FFrame&, void* const)
	public virtual /*native final function */bool RemoveUISoundCue(name SoundCueName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISkin::execGetUISoundCue(FFrame&, void* const)
	public virtual /*native final function */bool GetUISoundCue(name SoundCueName, ref SoundCue out_UISoundCue)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISkin::execGetSkinSoundCues(FFrame&, void* const)
	public virtual /*native final function */void GetSkinSoundCues(ref array<UISkin.UISoundCue> out_SoundCues)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUISkin::execIsInheritedGroupName(FFrame&, void* const)
	public virtual /*native final function */bool IsInheritedGroupName(String StyleGroupName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISkin::execAddStyleGroupName(FFrame&, void* const)
	public virtual /*native final function */bool AddStyleGroupName(String StyleGroupName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISkin::execRemoveStyleGroupName(FFrame&, void* const)
	public virtual /*native final function */bool RemoveStyleGroupName(String StyleGroupName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISkin::execRenameStyleGroup(FFrame&, void* const)
	public virtual /*native final function */bool RenameStyleGroup(String OldStyleGroupName, String NewStyleGroupName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISkin::execGetStyleGroupAtIndex(FFrame&, void* const)
	public virtual /*native final function */String GetStyleGroupAtIndex(int Index)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISkin::execFindStyleGroupIndex(FFrame&, void* const)
	public virtual /*native final function */int FindStyleGroupIndex(String StyleGroupName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISkin::execGetStyleGroups(FFrame&, void* const)
	public virtual /*native final function */void GetStyleGroups(ref array<String> StyleGroupArray, /*optional */bool? _bIncludeInheritedGroups = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public UISkin()
	{
		// Object Offset:0x00424FB0
		Tag = (name)"Styles";
	}
}
}