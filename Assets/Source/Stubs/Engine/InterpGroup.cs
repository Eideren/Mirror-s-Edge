namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpGroup : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct InterpEdSelKey
	{
		public InterpGroup Group;
		public int TrackIndex;
		public int KeyIndex;
		public float UnsnappedPosition;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00340FC6
	//		Group = default;
	//		TrackIndex = 0;
	//		KeyIndex = 0;
	//		UnsnappedPosition = 0.0f;
	//	}
	};
	
	public /*private native const noexport */Object.Pointer VfTable_FInterpEdInputInterface;
	public /*export */array</*export */InterpTrack> InterpTracks;
	public name GroupName;
	public/*()*/ Object.Color GroupColor;
	public/*()*/ array<AnimSet> GroupAnimSets;
	public bool bCollapsed;
	public /*transient */bool bVisible;
	public bool bIsFolder;
	public bool bIsParented;
	
	public InterpGroup()
	{
		// Object Offset:0x0034106E
		GroupName = (name)"InterpGroup";
		GroupColor = new Color
		{
			R=100,
			G=80,
			B=200,
			A=255
		};
		bVisible = true;
	}
}
}