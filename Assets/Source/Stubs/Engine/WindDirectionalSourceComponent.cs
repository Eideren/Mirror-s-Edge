namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class WindDirectionalSourceComponent : ActorComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public /*private noimport native const transient */Object.Pointer SceneProxy;
	public/*()*/ float Strength;
	public/*()*/ float Phase;
	public/*()*/ float Frequency;
	public/*()*/ float Speed;
	
	public WindDirectionalSourceComponent()
	{
		// Object Offset:0x004606CC
		Strength = 1.0f;
		Frequency = 1.0f;
		Speed = 1024.0f;
	}
}
}