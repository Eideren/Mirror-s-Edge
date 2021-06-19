namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ColorScaleVolume : Volume/*
		placeable
		hidecategories(Navigation,Object,Movement,Display,Collision,Brush,Attachment,Volume)*/{
	public/*()*/ Object.Vector ColorScale;
	public/*()*/ float InterpTime;
	
	public override Touch_del Touch { get => bfield_Touch ?? ColorScaleVolume_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => ColorScaleVolume_Touch;
	public /*event */void ColorScaleVolume_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
	
	}
	
	public override UnTouch_del UnTouch { get => bfield_UnTouch ?? ColorScaleVolume_UnTouch; set => bfield_UnTouch = value; } UnTouch_del bfield_UnTouch;
	public override UnTouch_del global_UnTouch => ColorScaleVolume_UnTouch;
	public /*event */void ColorScaleVolume_UnTouch(Actor Other)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
		UnTouch = null;
	
	}
	public ColorScaleVolume()
	{
		var Default__ColorScaleVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__ColorScaleVolume.BrushComponent0' */;
		// Object Offset:0x002BCFD3
		ColorScale = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		InterpTime = 1.0f;
		BrushComponent = Default__ColorScaleVolume_BrushComponent0/*Ref BrushComponent'Default__ColorScaleVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__ColorScaleVolume_BrushComponent0/*Ref BrushComponent'Default__ColorScaleVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__ColorScaleVolume_BrushComponent0/*Ref BrushComponent'Default__ColorScaleVolume.BrushComponent0'*/;
	}
}
}