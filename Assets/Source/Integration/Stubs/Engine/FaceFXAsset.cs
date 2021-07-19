namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FaceFXAsset : Object/*
		native
		hidecategories(Object)*/{
	[editoronly, Const] public SkeletalMesh DefaultSkelMesh;
	[native, Const] public Object.Pointer FaceFXActor;
	[native, Const] public array<byte> RawFaceFXActorBytes;
	[native, Const] public array<byte> RawFaceFXSessionBytes;
	[Category] [editoronly] public array<MorphTargetSet> PreviewMorphSets;
	[transient] public array<FaceFXAnimSet> MountedFaceFXAnimSets;
	public array<SoundCue> ReferencedSoundCues;
	public int NumLoadErrors;
	
	// Export UFaceFXAsset::execMountFaceFXAnimSet(FFrame&, void* const)
	public virtual /*native final function */void MountFaceFXAnimSet(FaceFXAnimSet AnimSet)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UFaceFXAsset::execUnmountFaceFXAnimSet(FFrame&, void* const)
	public virtual /*native final function */void UnmountFaceFXAnimSet(FaceFXAnimSet AnimSet)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}