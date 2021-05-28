namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdPlayerSwitchedWeapon : SequenceEvent/*
		hidecategories(Object)*/{
	public/*()*/ Volume ConditionalVolume;
	public/*()*/ Core.ClassT<TdWeapon> ConditionalWeaponClass;
	
	public SeqEvt_TdPlayerSwitchedWeapon()
	{
		// Object Offset:0x004A8112
		ObjName = "Player Switched Weapon";
		ObjCategory = "Takedown";
	}
}
}