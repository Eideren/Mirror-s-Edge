namespace MEdge.TdGame{
	using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
	using UnityEngine;



	public partial class TdAnimNodeBlendList
	{
		// Export UTdAnimNodeBlendList::execSetActiveMove(FFrame&, void* const)
        public virtual /*native function */bool SetActiveMove(int ChildIndex, /*optional */bool? _ForceActive = default)
        {
	        if( _ForceActive != default )
		        Debug.LogWarning( $"{nameof(_ForceActive)} not implemented" );
        	
	        for( int i = 0; i < TargetWeight.Length; i++ )
	        {
		        TargetWeight[ i ] = 0f;
	        }

	        TargetWeight[ ChildIndex ] = 1f;
	        EditorSliderIndex = ChildIndex;
	        BlendTimeToGo = BlendOutWeight[ ActiveChildIndex ] > BlendWeight[ ChildIndex ] ? BlendOutWeight[ ActiveChildIndex ] : BlendWeight[ ChildIndex ];
	        ActiveChildIndex = ChildIndex;
	        if(bPlayActiveChild)
		        PlayAnim();
	        
            return default;
        }
	}
}