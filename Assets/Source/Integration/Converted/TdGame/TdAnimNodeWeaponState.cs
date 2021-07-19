namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeWeaponState : TdAnimNodeState/*
		native
		hidecategories(Object,Object,Object)*/{
	[Category] [editoronly, transient] public array<TdPawn.EWeaponAnimState> EnumStates;
	
	public override /*event */void OnInit()
	{
		/*local */int ArrayItem = default;
	
		EnumStates.Remove(0, EnumStates.Length);
		using var v = StateMapping.GetEnumerator();while(v.MoveNext() && (ArrayItem = (int)v.Current) == ArrayItem)
		{
			EnumStates.AddItem(((TdPawn.EWeaponAnimState)(byte)(ArrayItem)));		
		}	
		base.OnInit();
	}
	
	public override /*event */void OverrideStateMapping()
	{
		/*local */int ArrayItem = default;
	
		StateMapping.Remove(0, StateMapping.Length);
		using var v = EnumStates.GetEnumerator();while(v.MoveNext() && (ArrayItem = (int)v.Current) == ArrayItem)
		{
			StateMapping.AddItem(ArrayItem);		
		}	
	}
	
	public TdAnimNodeWeaponState()
	{
		// Object Offset:0x005087B1
		EnumStringName = "EWeaponAnimState";
	}
}
}