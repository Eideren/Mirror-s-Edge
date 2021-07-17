namespace MEdge.TdGame{
	using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
	using UnityEngine;



	public partial class TdAnimNodeBlendList
	{
		// Export UTdAnimNodeBlendList::execSetActiveMove(FFrame&, void* const)
        public virtual /*native function */bool SetActiveMove(int ChildIndex, /*optional */bool? _ForceActive = default)
        {
	        float activeChildBlendOutWeight; // xmm0_4
	        float newChildBlendWeight; // xmm1_4
	        int activeChildIndex; // eax
	        float maxBlendWeight; // [esp+Ch] [ebp+8h]
	        
	        if ( _ForceActive != true && this.ActiveChildIndex == ChildIndex || this.TargetWeight.Count == 0 )
		        return false;
	        activeChildBlendOutWeight = 0.2f;            // default value if no active
	        if ( ChildIndex >= this.BlendWeight.Count )
		        newChildBlendWeight = 0.2f;
	        else
		        newChildBlendWeight = this.BlendWeight[ChildIndex];
	        activeChildIndex = this.ActiveChildIndex;
	        if ( activeChildIndex < this.BlendOutWeight.Count )
		        activeChildBlendOutWeight = this.BlendOutWeight[activeChildIndex];
	        if ( newChildBlendWeight < activeChildBlendOutWeight )
		        maxBlendWeight = activeChildBlendOutWeight;
	        else
		        maxBlendWeight = newChildBlendWeight;
	        this.SetActiveChild( ChildIndex, maxBlendWeight );
	        return true;
        }
	}
}