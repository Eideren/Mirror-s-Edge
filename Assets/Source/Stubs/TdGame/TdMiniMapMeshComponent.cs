namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMiniMapMeshComponent : StaticMeshComponent/*
		native
		editinlinenew
		hidecategories(Object)
		autoexpandcategories(Collision,Rendering,Lighting)*/{
	public enum EMeshIconType 
	{
		EMIT_Stashpoint,
		EMIT_Runner,
		EMIT_Cop,
		EMIT_Bag,
		EMIT_You,
		EMIT_MAX
	};
	
	public partial struct /*native */MiniMapObject
	{
		public Object.Vector Location;
		public Object.Rotator Rotation;
		public float Scale;
		public byte MeshIcon;
		public Material Material;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00590FCB
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Rotation = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		Scale = 10.0f;
	//		MeshIcon = 0;
	//		Material = default;
	//	}
	};
	
	public /*const */StaticArray<StaticMesh, StaticMesh, StaticMesh, StaticMesh, StaticMesh>/*[TdMiniMapMeshComponent.EMeshIconType.EMIT_MAX]*/ MeshObjects;
	public array<TdMiniMapMeshComponent.MiniMapObject> MiniMapObjects;
	public /*transient */StaticMesh MapMesh;
	public Material MiniMapBaseMaterial;
	public Material InactiveStashPointMaterial;
	public /*transient */Object.Vector WorldToMiniMapOrigo;
	public /*const */float DefaultScale;
	public /*const */Object.Vector DefaultTranslation;
	
	public TdMiniMapMeshComponent()
	{
		// Object Offset:0x005910AC
		DefaultScale = 0.0160f;
		DefaultTranslation = new Vector
		{
			X=130.0f,
			Y=170.0f,
			Z=0.0f
		};
		bAcceptsDecals = false;
		CastShadow = false;
		CollideActors = false;
		BlockActors = false;
		BlockZeroExtent = false;
		BlockNonZeroExtent = false;
		BlockRigidBody = false;
		AlwaysLoadOnServer = false;
	}
}
}