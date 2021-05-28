namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FaceFXAnimSet : Object/*
		native
		hidecategories(Object)*/{
	public/*()*/ /*editoronly const */FaceFXAsset DefaultFaceFXAsset;
	public /*native const */Object.Pointer InternalFaceFXAnimSet;
	public /*native const */array<byte> RawFaceFXAnimSetBytes;
	public /*native const */array<byte> RawFaceFXMiniSessionBytes;
	public array<SoundCue> ReferencedSoundCues;
	public int NumLoadErrors;
	
}
}