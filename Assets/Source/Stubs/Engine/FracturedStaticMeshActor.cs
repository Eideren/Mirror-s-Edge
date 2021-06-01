namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FracturedStaticMeshActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */FracturedStaticMeshComponent FracturedStaticMeshComponent;
	public array<int> ChunkHealth;
	
	// Export UFracturedStaticMeshActor::execSpawnPart(FFrame&, void* const)
	public virtual /*native function */FracturedStaticMeshPart SpawnPart(int ChunkIndex, Object.Vector InitialVel, Object.Vector InitialAngVel)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UFracturedStaticMeshActor::execSpawnPartMulti(FFrame&, void* const)
	public virtual /*native function */FracturedStaticMeshPart SpawnPartMulti(array<int> ChunkIndices, Object.Vector InitialVel, Object.Vector InitialAngVel)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UFracturedStaticMeshActor::execRecreatePhysState(FFrame&, void* const)
	public virtual /*native function */void RecreatePhysState()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public virtual /*event */void ResetHealth()
	{
	
	}
	
	public virtual /*function */array<byte> BreakOffIsolatedIslands(array<byte> FragmentVis, array<int> IgnoreFrags, Object.Vector ChunkDir, array<FracturedStaticMeshPart> DisableCollWithPart)
	{
	
		return default;
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? FracturedStaticMeshActor_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => FracturedStaticMeshActor_TakeDamage;
	public /*event */void FracturedStaticMeshActor_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
	
	}
	
	public virtual /*event */void Explode()
	{
	
	}
	
	public virtual /*event */void BreakOffPartsInRadius(Object.Vector Origin, float Radius, float RBStrength)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
	
	}
	public FracturedStaticMeshActor()
	{
		// Object Offset:0x00322D6C
		FracturedStaticMeshComponent = new FracturedStaticMeshComponent
		{
			// Object Offset:0x00322FBF
			WireframeColor = new Color
			{
				R=0,
				G=128,
				B=255,
				A=255
			},
			bAllowApproximateOcclusion = true,
			bAcceptsDecals = false,
			bForceDirectLightMap = true,
			bCastDynamicShadow = false,
		}/* Reference: FracturedStaticMeshComponent'Default__FracturedStaticMeshActor.FracturedStaticMeshComponent0' */;
		bNoDelete = true;
		bWorldGeometry = true;
		bRouteBeginPlayEvenIfStatic = false;
		bGameRelevant = true;
		bMovable = false;
		bCollideActors = true;
		bBlockActors = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new FracturedStaticMeshComponent
			{
				// Object Offset:0x00322FBF
				WireframeColor = new Color
				{
					R=0,
					G=128,
					B=255,
					A=255
				},
				bAllowApproximateOcclusion = true,
				bAcceptsDecals = false,
				bForceDirectLightMap = true,
				bCastDynamicShadow = false,
			}/* Reference: FracturedStaticMeshComponent'Default__FracturedStaticMeshActor.FracturedStaticMeshComponent0' */,
		};
		CollisionComponent = new FracturedStaticMeshComponent
		{
			// Object Offset:0x00322FBF
			WireframeColor = new Color
			{
				R=0,
				G=128,
				B=255,
				A=255
			},
			bAllowApproximateOcclusion = true,
			bAcceptsDecals = false,
			bForceDirectLightMap = true,
			bCastDynamicShadow = false,
		}/* Reference: FracturedStaticMeshComponent'Default__FracturedStaticMeshActor.FracturedStaticMeshComponent0' */;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvent_Death>(),
		};
	}
}
}