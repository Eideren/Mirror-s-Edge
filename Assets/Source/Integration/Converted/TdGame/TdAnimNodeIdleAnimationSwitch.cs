namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeIdleAnimationSwitch : TdAnimNodeSwitch/*
		native
		hidecategories(Object,Object,Object)*/{
	public virtual /*final simulated event */bool CruddyCelesteTaserTest(Controller C)
	{
		return !C.IsInState("Taser", default(bool?)) && !C.IsInState("Immobile", default(bool?));
	}
	
	public override /*event */void OnInitialize()
	{
	
	}
	
	public override /*event */bool EditorGetState()
	{
		return false;
	}
	
}
}