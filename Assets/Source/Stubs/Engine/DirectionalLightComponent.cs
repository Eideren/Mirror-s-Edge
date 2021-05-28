namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DirectionalLightComponent : LightComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ float SoftShadowAngle;
	public/*()*/ int Photons;
	public/*()*/ float PhotonIntensity;
	public/*(AdvancedLighting)*/ float TraceDistance;
	
	public DirectionalLightComponent()
	{
		// Object Offset:0x0030DAEB
		SoftShadowAngle = 10.0f;
		Photons = 100000;
		PhotonIntensity = 1.0f;
		TraceDistance = 100000.0f;
		bCastCompositeShadow = true;
	}
}
}