namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_RunnerVisionEffect : InterpActor/*
		notplaceable
		hidecategories(Navigation)*/{
	public virtual /*simulated function */void Initialize()
	{
	
	}
	
	public TdAI_RunnerVisionEffect()
	{
		// Object Offset:0x004E0606
		StaticMeshComponent = new StaticMeshComponent
		{
			// Object Offset:0x02EA6B5B
			StaticMesh = LoadAsset<StaticMesh>("FX_AIEffects.Mesh.S_FX_AI_LOI_Cylinder_01")/*Ref StaticMesh'FX_AIEffects.Mesh.S_FX_AI_LOI_Cylinder_01'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdAI_RunnerVisionEffect.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdAI_RunnerVisionEffect.MyLightEnvironment'*/,
			bUseAsOccluder = false,
			CastShadow = false,
			bAcceptsLights = false,
		}/* Reference: StaticMeshComponent'Default__TdAI_RunnerVisionEffect.StaticMeshComponent0' */;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdAI_RunnerVisionEffect.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdAI_RunnerVisionEffect.MyLightEnvironment'*/;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdAI_RunnerVisionEffect.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdAI_RunnerVisionEffect.MyLightEnvironment'*/,
			new StaticMeshComponent
			{
				// Object Offset:0x02EA6B5B
				StaticMesh = LoadAsset<StaticMesh>("FX_AIEffects.Mesh.S_FX_AI_LOI_Cylinder_01")/*Ref StaticMesh'FX_AIEffects.Mesh.S_FX_AI_LOI_Cylinder_01'*/,
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdAI_RunnerVisionEffect.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdAI_RunnerVisionEffect.MyLightEnvironment'*/,
				bUseAsOccluder = false,
				CastShadow = false,
				bAcceptsLights = false,
			}/* Reference: StaticMeshComponent'Default__TdAI_RunnerVisionEffect.StaticMeshComponent0' */,
		};
		CollisionComponent = new StaticMeshComponent
		{
			// Object Offset:0x02EA6B5B
			StaticMesh = LoadAsset<StaticMesh>("FX_AIEffects.Mesh.S_FX_AI_LOI_Cylinder_01")/*Ref StaticMesh'FX_AIEffects.Mesh.S_FX_AI_LOI_Cylinder_01'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdAI_RunnerVisionEffect.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdAI_RunnerVisionEffect.MyLightEnvironment'*/,
			bUseAsOccluder = false,
			CastShadow = false,
			bAcceptsLights = false,
		}/* Reference: StaticMeshComponent'Default__TdAI_RunnerVisionEffect.StaticMeshComponent0' */;
	}
}
}