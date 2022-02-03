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
        public virtual unsafe /*native function */void InitMoveObjects()
        {
            this.Mesh3p.Animations = this.Mesh3p.AnimTreeTemplate;
            this.Mesh1p.Animations = this.Mesh1p.AnimTreeTemplate;
            LogWarning( $"Need to implement clone for {nameof(this.Mesh3p.AnimTreeTemplate)} instead of straight assign" );
            
            /*ref array<TdMove> v2; // edi
            bool v3; // zf
            TdMove[] v4; // esi
            void *v5; // ecx
            */
            int i; // esi
            ClassT<TdMove>[]  currentMoveClass; // eax
            /*_DWORD *v8; // eax
            _DWORD *v9; // eax
            */
            
            ref array<TdMove> v2 = ref this.Moves;
            /*v3 = this.Moves.Max == 0;
            this.Moves.Count = 0;
            if ( !v3 )
            {
                v4 = v2.Data;
                v3 = v2.Data == null;
                this.Moves.Max = 0;
                if ( !v3 )
                {
                    v5 = dword_2018708;
                    if ( !dword_2018708 )
                    {
                        GCreateMalloc_Prob();
                        v5 = dword_2018708;
                    }
                    v2.Data = (_E_struct_UTdMove *__ptr32 *__ptr32)(*(int (__thiscall **)(void *, _E_struct_UTdMove *__ptr32 *__ptr32, _DWORD, int))(*(_DWORD *)v5 + 8))(v5, v4, 0, 8);
                }
            }*/

            v2.Reset();
            while( v2.Length != this.MoveClasses.Count )
                v2.Add( null );
            //FArray::Add(v2, this.MoveClasses.Count, 4, 8);
            i = 0;
            if ( this.MoveClasses.Count > 0 )
            {
                while ( true )
                {
                    currentMoveClass = this.MoveClasses.Data;
                    if ( currentMoveClass[i] == null )
                    {
                        v2.Data[i] = null;
                    }
                    else if ( i == 4 )
                    {
                        /*v9 = E_newInstanceOfClass_Probably(currentMoveClass[40], this, 0, 0, 0, 0, 0, off_20186F4, 0, 0);
                        v2.Data[4] = E_TryCastToTdMove((int)v9);*/
                        v2.Data[4] = currentMoveClass[40].New( this );
                        v2.Data[4].PawnOwner = this;
                    }
                    else if( i == 40 || i == 5 )
                    {
                        v2.Data[i] = v2.Data[4];
                    }
                    else
                    {
                        /*v8 = E_newInstanceOfClass_Probably(currentMoveClass[i], this, 0, 0, 0, 0, 0, off_20186F4, 0, 0);
                        v2.Data[i] = (_E_struct_UTdMove *__ptr32)E_TryCastToTdMove((int)v8);*/
                        v2.Data[i] = currentMoveClass[i].New(this);
                        v2.Data[i].PawnOwner = this;
                    }
                    if ( ++i >= this.MoveClasses.Count )
                        return;
                }
            }
        }
	}
}