namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkeletalMeshSocket : Object/*
		native
		hidecategories(Object,Actor)*/{
	[Category] [Const, editconst] public name SocketName;
	[Category] [Const, editconst] public name BoneName;
	[Category] public Object.Vector RelativeLocation;
	[Category] public Object.Rotator RelativeRotation;
	[Category] public Object.Vector RelativeScale;
	[Category] [editoronly] public SkeletalMesh PreviewSkelMesh;
	[Category] [Const, editconst, export, editinline, transient] public SkeletalMeshComponent PreviewSkelComp;
	[Category] [editoronly] public StaticMesh PreviewStaticMesh;
	
	public SkeletalMeshSocket()
	{
		// Object Offset:0x003E833D
		RelativeScale = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
	}
}
}