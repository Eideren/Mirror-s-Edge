namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MorphNodeBase : Object/*
		abstract
		native
		hidecategories(Object)*/{
	public/*()*/ name NodeName;
	public bool bDrawSlider;
	public /*export editinline */SkeletalMeshComponent SkelComponent;
	public int NodePosX;
	public int NodePosY;
	public int DrawWidth;
	public int DrawHeight;
	public int OutDrawY;
	
}
}