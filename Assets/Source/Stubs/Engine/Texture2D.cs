namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Texture2D : Texture/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */Texture2DMipMap
	{
		public /*native */Object.TextureMipBulkData_Mirror Data;
		public /*native */int SizeX;
		public /*native */int SizeY;
	};
	
	public partial struct TextureLinkedListMirror
	{
		public /*native const */Object.Pointer Element;
		public /*native const */Object.Pointer Next;
		public /*native const */Object.Pointer PrevLink;
	};
	
	public /*native const */Object.IndirectArray_Mirror Mips;
	public /*const */int SizeX;
	public /*const */int SizeY;
	public /*const */int TurtleSizeX;
	public /*const */int TurtleSizeY;
	public /*const */Texture.EPixelFormat Format;
	public/*()*/ Texture.TextureAddress AddressX;
	public/*()*/ Texture.TextureAddress AddressY;
	public /*transient */int CachedRequestedMips;
	public /*const transient */bool bIsStreamable;
	public /*const transient */bool bHasCancelationPending;
	public /*const transient */bool bHasBeenLoadedFromPersistentArchive;
	public /*transient */bool bForceMiplevelsToBeResident;
	public/*()*/ /*const */bool bGlobalForceMipLevelsToBeResident;
	public /*transient */float TimeToForceMipLevelsToBeResident;
	public name TextureFileCacheName;
	public /*const transient */int RequestedMips;
	public /*const transient */int ResidentMips;
	public /*native const transient */Object.ThreadSafeCounter PendingMipChangeRequestStatus;
	public /*private noimport duplicatetransient native const */Texture2D.TextureLinkedListMirror StreamableTexturesLink;
	public /*const */int MipTailBaseIdx;
	public /*private native const transient */Object.Pointer ResourceMem;
	public /*private native const transient */int FirstResourceMemMip;
	
}
}