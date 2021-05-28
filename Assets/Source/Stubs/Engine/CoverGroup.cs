namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CoverGroup : Info/*
		native
		placeable
		hidecategories(Navigation,Movement,Collision)*/{
	public enum ECoverGroupFillAction 
	{
		CGFA_Overwrite,
		CGFA_Add,
		CGFA_Remove,
		CGFA_Clear,
		CGFA_Cylinder,
		CGFA_MAX
	};
	
	public/*()*/ array<Actor.NavReference> CoverLinkRefs;
	public/*()*/ float AutoSelectRadius;
	public/*()*/ float AutoSelectHeight;
	
	// Export UCoverGroup::execEnableGroup(FFrame&, void* const)
	public virtual /*native function */void EnableGroup()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UCoverGroup::execDisableGroup(FFrame&, void* const)
	public virtual /*native function */void DisableGroup()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UCoverGroup::execToggleGroup(FFrame&, void* const)
	public virtual /*native function */void ToggleGroup()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UCoverGroup::execContains(FFrame&, void* const)
	public virtual /*native function */bool Contains(CoverLink Link)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
	}
	
	public CoverGroup()
	{
		// Object Offset:0x002E3929
		bStatic = true;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x004CF736
				Sprite = LoadAsset<Texture2D>("EditorMaterials.CovergroupIcon")/*Ref Texture2D'EditorMaterials.CovergroupIcon'*/,
			}/* Reference: SpriteComponent'Default__CoverGroup.Sprite' */,
			//Components[1]=
			new CoverGroupRenderingComponent
			{
				// Object Offset:0x0046632F
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: CoverGroupRenderingComponent'Default__CoverGroup.CoverGroupRenderer' */,
		};
	}
}
}