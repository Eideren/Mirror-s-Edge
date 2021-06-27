namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FaceFXAsset : Object/*
		native
		hidecategories(Object)*/{
	public /*editoronly const */SkeletalMesh DefaultSkelMesh;
	public /*native const */Object.Pointer FaceFXActor;
	public /*native const */array<byte> RawFaceFXActorBytes;
	public /*native const */array<byte> RawFaceFXSessionBytes;
	public/*()*/ /*editoronly */array<MorphTargetSet> PreviewMorphSets;
	public /*transient */array<FaceFXAnimSet> MountedFaceFXAnimSets;
	public array<SoundCue> ReferencedSoundCues;
	public int NumLoadErrors;
	
	// Export UFaceFXAsset::execMountFaceFXAnimSet(FFrame&, void* const)
	public virtual /*native final function */void MountFaceFXAnimSet(FaceFXAnimSet AnimSet)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UFaceFXAsset::execUnmountFaceFXAnimSet(FFrame&, void* const)
	public virtual /*native final function */void UnmountFaceFXAnimSet(FaceFXAnimSet AnimSet)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
}
}