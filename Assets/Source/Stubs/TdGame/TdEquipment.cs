namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdEquipment : Inventory/*
		notplaceable
		hidecategories(Navigation)*/{
	public /*private */bool bIsActive;
	
	public override /*simulated function */void RenderOverlays(HUD H)
	{
	
	}
	
	public virtual /*function */void Activate()
	{
	
	}
	
	public virtual /*function */bool IsActive()
	{
	
		return default;
	}
	
	public virtual /*function */void Deactivate()
	{
	
	}
	
	public TdEquipment()
	{
		var Default__TdEquipment_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdEquipment.Sprite' */;
		// Object Offset:0x0054468D
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdEquipment_Sprite/*Ref SpriteComponent'Default__TdEquipment.Sprite'*/,
		};
	}
}
}