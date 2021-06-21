namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CylinderComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport*/{
	public/*()*/ /*const export */float CollisionHeight;
	public/*()*/ /*const export */float CollisionRadius;
	public/*()*/ /*const */Object.Color CylinderColor;
	public /*const */bool bDrawBoundingBox;
	public /*const */bool bDrawNonColliding;
	
	// Export UCylinderComponent::execSetCylinderSize(FFrame&, void* const)
	public virtual /*native final function */void SetCylinderSize(float NewRadius, float NewHeight)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	public CylinderComponent()
	{
		// Object Offset:0x00268CB8
		CollisionHeight = 22.0f;
		CollisionRadius = 22.0f;
		CylinderColor = new Color
		{
			R=223,
			G=149,
			B=157,
			A=255
		};
		bDrawBoundingBox = true;
		HiddenGame = true;
		bCastDynamicShadow = false;
		BlockZeroExtent = true;
		BlockNonZeroExtent = true;
	}
}
}