namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNotify_ViewShake : AnimNotify_Scripted/*
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ float ShakeRadius;
	public/*()*/ float Duration;
	public/*()*/ Object.Vector RotAmplitude;
	public/*()*/ Object.Vector RotFrequency;
	public/*()*/ Object.Vector LocAmplitude;
	public/*()*/ Object.Vector LocFrequency;
	public/*()*/ float FOVAmplitude;
	public/*()*/ float FOVFrequency;
	public/*()*/ bool bUseBoneLocation;
	public/*()*/ name BoneName;
	
	public override /*event */void Notify(Actor Owner, AnimNodeSequence AnimSeqInstigator)
	{
		/*local */PlayerController PC = default;
		/*local */float Pct = default, DistToOrigin = default;
		/*local */Object.Vector ViewShakeOrigin = default, CamLoc = default;
		/*local */Object.Rotator CamRot = default;
	
		if((bUseBoneLocation && AnimSeqInstigator != default) && AnimSeqInstigator.SkelComponent != default)
		{
			ViewShakeOrigin = AnimSeqInstigator.SkelComponent.GetBoneLocation(BoneName, default(int?));		
		}
		else
		{
			ViewShakeOrigin = Owner.Location;
		}
		if(Owner != default)
		{
			
			// foreach Owner.WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
			using var e118 = Owner.WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
			while(e118.MoveNext() && (PC = (PlayerController)e118.Current) == PC)
			{
				PC.GetPlayerViewPoint(ref/*probably?*/ CamLoc, ref/*probably?*/ CamRot);
				DistToOrigin = VSize(ViewShakeOrigin - CamLoc);
				if(DistToOrigin < ShakeRadius)
				{
					Pct = 1.0f - (DistToOrigin / ShakeRadius);
					PC.CameraShake(Duration * Pct, RotAmplitude * Pct, RotFrequency * Pct, LocAmplitude * Pct, LocFrequency * Pct, FOVAmplitude * Pct, FOVFrequency * Pct);
				}			
			}		
		}
	}
	
	public AnimNotify_ViewShake()
	{
		// Object Offset:0x002A0615
		ShakeRadius = 4096.0f;
		Duration = 1.0f;
		RotAmplitude = new Vector
		{
			X=100.0f,
			Y=100.0f,
			Z=200.0f
		};
		RotFrequency = new Vector
		{
			X=10.0f,
			Y=10.0f,
			Z=25.0f
		};
		LocAmplitude = new Vector
		{
			X=0.0f,
			Y=3.0f,
			Z=6.0f
		};
		LocFrequency = new Vector
		{
			X=1.0f,
			Y=10.0f,
			Z=20.0f
		};
		FOVAmplitude = 2.0f;
		FOVFrequency = 5.0f;
	}
}
}