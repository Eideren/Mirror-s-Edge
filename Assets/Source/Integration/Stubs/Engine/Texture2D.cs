namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Texture2D : Texture/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */Texture2DMipMap
	{
		[native] public Object.TextureMipBulkData_Mirror Data;
		[native] public int SizeX;
		[native] public int SizeY;
	};
	
	public partial struct TextureLinkedListMirror
	{
		[native, Const] public Object.Pointer Element;
		[native, Const] public Object.Pointer Next;
		[native, Const] public Object.Pointer PrevLink;
	};
	
	[native, Const] public Object.IndirectArray_Mirror Mips;
	[Const] public int SizeX;
	[Const] public int SizeY;
	[Const] public int TurtleSizeX;
	[Const] public int TurtleSizeY;
	[Const] public Texture.EPixelFormat Format;
	[Category] public Texture.TextureAddress AddressX;
	[Category] public Texture.TextureAddress AddressY;
	[transient] public int CachedRequestedMips;
	[Const, transient] public bool bIsStreamable;
	[Const, transient] public bool bHasCancelationPending;
	[Const, transient] public bool bHasBeenLoadedFromPersistentArchive;
	[transient] public bool bForceMiplevelsToBeResident;
	[Category] [Const] public bool bGlobalForceMipLevelsToBeResident;
	[transient] public float TimeToForceMipLevelsToBeResident;
	public name TextureFileCacheName;
	[Const, transient] public int RequestedMips;
	[Const, transient] public int ResidentMips;
	[native, Const, transient] public Object.ThreadSafeCounter PendingMipChangeRequestStatus;
	[noimport, duplicatetransient, native, Const] public/*private*/ Texture2D.TextureLinkedListMirror StreamableTexturesLink;
	[Const] public int MipTailBaseIdx;
	[native, Const, transient] public/*private*/ Object.Pointer ResourceMem;
	[native, Const, transient] public/*private*/ int FirstResourceMemMip;
	
}
}