namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimSet : AnimSet/*
		native
		hidecategories(Object)*/{
	public/*(AnimSet)*/ bool bIsCommonAnimSet;
	public/*(AnimSet)*/ bool bIsWeaponSpecificAnimSet;
	
	public TdAnimSet()
	{
		// Object Offset:0x00508D39
		bAnimRotationOnly = false;
	}
}
}