namespace MEdge.TdGame
{
    using Core;
    using _E_struct_FRotator = Core.Object.Rotator;
    using _E_struct_Quat = Core.Object.Quat;
    using _E_struct_FVector = Core.Object.Vector;
    using _E_struct_FMatrix = Core.Object.Matrix;
    using _E_struct_FInterpCurveFloat = Core.Object.InterpCurveFloat;
    using _E_struct_FInterpCurvePointFloat = Core.Object.InterpCurvePointFloat;
    using static UnityEngine.Debug;
    
	public partial class TdPawn
	{
        // Export UTdPawn::execInitMoveObjects(FFrame&, void* const)
        public virtual /*native function */void InitMoveObjects()
        {
            NativeMarkers.MarkUnimplemented();
            // Not verified
            for( int i = 0; i < this.MoveClasses.Length; i++ )
            {
                var c = this.MoveClasses[ i ];
                if( c == null )
                    continue;
                this.Moves[ i ] = this.MoveClasses[ i ].New( this );
                this.Moves[ i ].PawnOwner = this;
            }

            this.Mesh3p.Animations = this.Mesh3p.AnimTreeTemplate;
            this.Mesh1p.Animations = this.Mesh1p.AnimTreeTemplate;
            LogWarning( $"Need to implement clone for {nameof(this.Mesh3p.AnimTreeTemplate)} instead of straight assign" );
        }
	}
}