namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdWeaponFired : SequenceEvent/*
		hidecategories(Object)*/{
	[Category] public Volume ConditionalVolume;
	[Category] public Core.ClassT<TdWeapon> ConditionalWeaponClass;
	
	public SeqEvt_TdWeaponFired()
	{
		// Object Offset:0x004A895F
		ObjName = "Weapon Fired";
		ObjCategory = "Takedown";
	}
}
}