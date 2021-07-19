namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FaceFXAnimSet : Object/*
		native
		hidecategories(Object)*/{
	[Category] [editoronly, Const] public FaceFXAsset DefaultFaceFXAsset;
	[native, Const] public Object.Pointer InternalFaceFXAnimSet;
	[native, Const] public array<byte> RawFaceFXAnimSetBytes;
	[native, Const] public array<byte> RawFaceFXMiniSessionBytes;
	public array<SoundCue> ReferencedSoundCues;
	public int NumLoadErrors;
	
}
}