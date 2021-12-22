namespace MEdge.Source
{
	using System;
	using System.Runtime.InteropServices;
	using Core;
	using Engine;
	using TdGame;
	using UnityEngine;
	using static Core.Object;
	using Object = Core.Object;
	using _E_struct_FVector = Core.Object.Vector;
	using _E_struct_FRotator = Core.Object.Rotator;

	
	public static class DecFn
	{
		static System.Random _randomSource = new System.Random();
		
		public static double fabs( double f ) => System.Math.Abs( f );
		public static double pow( double x, double p ) => System.Math.Pow( x, p );
		public static double sqrt( double f ) => System.Math.Sqrt( f );
		public static float fsqrt( float f ) => System.MathF.Sqrt( f );
		public static double floor( double f ) => System.Math.Floor( f );
		public static double asin( double f ) => System.Math.Asin( f );
		public static double sin( double f ) => System.Math.Sin( f );
		public static double cos( double f ) => System.Math.Cos( f );
		public static int rand() => _randomSource.Next();
		public static double atan2( double y, double x ) => System.Math.Atan2( y, x );
		
		
		public static short LOWORD( int i ) => (short)(i & 0b1111_1111_1111_1111);
		public static unsafe byte LOBYTE( int i ) => *(byte*)&i;
		public static unsafe sbyte SLOBYTE( int i ) => *(sbyte*)&i;
		public static unsafe sbyte SLOBYTE( uint i ) => *(sbyte*)&i;
		public static unsafe int LODWORD( float i ) => *(int*)&i;
		public static unsafe float COERCE_FLOAT( int i ) => *(float*)&i;



		public static unsafe void LODWORD( this ref float i, int v )
		{
			#error
		}



		public static unsafe uint* GMem_ptr
		{
			get
			{
				#error
			}
		}



		public static T E_TryCastTo<T>( object o ) where T : class => o is T a ? a : null;
		public static Object.Rotator E_AMinusC_IntoAndRetB(
			Object.Rotator thisS,
			out Object.Rotator outputPtr,
			Object.Rotator diffWith)
		{
			//_E_struct_FRotator *result; // eax
			//unsigned int v4; // esi
			//unsigned int v5; // ecx

			//result = outputPtr;
			outputPtr.Pitch = thisS.Pitch - diffWith.Pitch;
			outputPtr.Yaw = thisS.Yaw - diffWith.Yaw;;
			outputPtr.Roll = thisS.Roll - diffWith.Roll;
			return outputPtr;
		}



		public static unsafe void setPhysics( this TdPawn thiss, byte NewPhysics, int NewFloor, int NewFloorVX, int NewFloorVY, int NewFloorVZ )
		{
			Debug.Assert(NewFloor == 0);
			thiss.setPhysics(NewPhysics, null, new Vector(*(float*)&NewFloorVX, *(float*)&NewFloorVY, *(float*)&NewFloorVZ));
		}



		public static unsafe _E_struct_FVector * E_GetDefaultCollExtent(TdPawn thiss, _E_struct_FVector *a2)
		{
			CylinderComponent v3; // eax
			float v4; // xmm0_4
			_E_struct_FVector *result; // eax
			float v6; // [esp+4h] [ebp-Ch]
			float v7; // [esp+8h] [ebp-8h]

			if ( GWorld.HasBegunPlay() )
				v3 = thiss.DefaultAs<TdPawn>().CylinderComponent;
			else
				v3 = thiss.CylinderComponent;
			if ( v3 )
			{
				v6 = v3.CollisionRadius;
				v7 = v6;
				v4 = v3.CollisionHeight;
			}
			else
			{
				v4 = 0.0f;
				v6 = 0.0f;
				v7 = 0.0f;
			}
			result = a2;
			a2->X = v6;
			a2->Y = v7;
			a2->Z = v4;
			return result;
		}
		
		
		public static unsafe _E_struct_FRotator * E_DirToRotator(_E_struct_FVector *thiss, _E_struct_FRotator *out_a)
		{
			double v2; // st5
			double v4; // st4
			float v6; // [esp+0h] [ebp-4h]
			float a2a; // [esp+8h] [ebp+4h]

			v6 = (float)(atan2(thiss->Y, thiss->X) * 65535.0d * 0.1591549430918953d);
			v2 = thiss->Y;
			v4 = thiss->X;
			out_a->Yaw = (int)v6;
			a2a = (float)(0.1591549430918953d * (65535.0d * atan2(thiss->Z, sqrt(v4 * v4 + v2 * v2))));
			out_a->Pitch = (int)a2a;
			out_a->Roll = 0;
			return out_a;
		}
		
		public static unsafe _E_struct_FRotator * E_ClipAmountOfTurns(_E_struct_FRotator *thiss, _E_struct_FRotator *a5)
		{
			_E_struct_FRotator *result; // eax
			int v3; // edx
			int v4; // ecx
			int v5; // ecx
			int v6; // ecx
			int v7; // ecx

			result = a5;
			a5->Pitch = thiss->Pitch;
			v3 = thiss->Yaw;
			v4 = thiss->Roll;
			a5->Yaw = v3;
			a5->Roll = v4;
			v5 = (System.UInt16)a5->Pitch;
			if ( v5 > 0x7FFF )
				v5 -= 0x10000;
			a5->Pitch = v5;
			v6 = (System.UInt16)a5->Roll;
			if ( v6 > 0x7FFF )
				v6 -= 0x10000;
			a5->Roll = v6;
			v7 = (System.UInt16)a5->Yaw;
			if ( v7 > 0x7FFF )
				v7 -= 0x10000;
			a5->Yaw = v7;
			return result;
		}
		
		public static int E_WrapRot(System.UInt16 a1)
		{
			int result; // eax

			result = a1;
			if ( a1 > 0x7FFFu )
				result = a1 - 0x10000;
			return result;
		}
		
		
		
		public static unsafe _E_struct_FVector * GetCylinderExtent(this Actor thiss, _E_struct_FVector *a2)
		{
			CylinderComponent v3; // ecx
			_E_struct_FVector *result; // eax
			float v5; // xmm0_4
			float v6; // xmm0_4
			float v7; // [esp+8h] [ebp-8h] BYREF
			float v8; // [esp+Ch] [ebp-4h] BYREF

			v3 = (thiss.CollisionComponent) as CylinderComponent;
			if ( v3 )
			{
				result = a2;
				v5 = v3.CollisionRadius;
				a2->Z = v3.CollisionHeight;
				a2->X = v5;
				a2->Y = v5;
			}
			else
			{
				(*(void (__thiscall **)(_E_struct_AActor *, float *, float *))(this->VfTableObject.Dummy + 300))(this, &v7, &v8);// GetBoundingCylinder
				result = a2;
				v6 = v7;
				a2->X = v7;
				a2->Y = v6;
				a2->Z = v8;
			}
			return result;
		}
		
		
		
		public static unsafe void E_FLedgeHitInfo_FillWith(TdPawn.LedgeHitInfo *a1, CheckResult *a2, _E_struct_FVector *a3, _E_struct_FVector a4, _E_struct_FVector a9)
		{
			float v5; // ecx
			int v6; // ecx
			PrimitiveComponent v7; // ecx
			int v8; // ecx
			int v9; // ecx

			a1->LedgeNormal = a4;
			a1->LedgeLocation.X = a3->X;
			a1->LedgeLocation.Y = a3->Y;
			v5 = a3->Z;
			SetFromBitfield(ref a1->FeetExcluded, 2, a1->FeetExcluded.AsBitfield(2) & ~3);
			a1->MoveNormal.X = a9.X;
			a1->LedgeLocation.Z = v5;
			a1->MoveNormal.Y = a9.Y;
			a1->MoveNormal.Z = a9.Z;
			a1->MoveActor = default;
			if( a2->Actor )
			{
				v6 = a1->FeetExcluded.AsBitfield(2) ^ ( (byte)a1->FeetExcluded.AsBitfield(2) ^ (byte)( a1->FeetExcluded.AsBitfield(2) | ( a2->Actor.bExludeHandMoves.AsBitfield(32) >> 1 ) )) & 1;
				SetFromBitfield(ref a1->FeetExcluded, 2, v6);
				SetFromBitfield(ref a1->FeetExcluded, 2, v6 ^ ( (byte)v6 ^ (byte)( v6 | ( 2 * a2->Actor.bExludeHandMoves.AsBitfield(32) ) )) & 2);
				a1->MoveActor = a2->Actor;
			}

			v7 = a2->Component;
			if( v7 )
			{
				if( v7.Owner )
				{
					v8 = a1->FeetExcluded.AsBitfield(2) ^ ( (byte)a1->FeetExcluded.AsBitfield(2) ^ (byte)( a1->FeetExcluded.AsBitfield(2) | ( v7.Owner.bExludeHandMoves.AsBitfield(32) >> 1 ) )) & 1;
					SetFromBitfield(ref a1->FeetExcluded, 2, v8);
					SetFromBitfield(ref a1->FeetExcluded, 2, v8 ^ ( (byte)v8 ^ (byte)( v8 | ( 2 * a2->Component.Owner.bExludeHandMoves.AsBitfield(32) ) )) & 2);
					a1->MoveActor = a2->Component.Owner;
				}
			}

			if( a2->Component )
			{
				v9 = a1->FeetExcluded.AsBitfield(2) ^ ( (byte)a1->FeetExcluded.AsBitfield(2) ^ (byte)( a1->FeetExcluded.AsBitfield(2) | ( a2->Component.bUseViewOwnerDepthPriorityGroup.AsBitfield(21) >> 9 ) )) & 1;
				SetFromBitfield(ref a1->FeetExcluded, 2, v9);
				SetFromBitfield(ref a1->FeetExcluded, 2, v9 ^ ( (byte)v9 ^ (byte)( v9 | ( a2->Component.bUseViewOwnerDepthPriorityGroup.AsBitfield(21) >> 7 ) )) & 2);
			}
		}





		public static unsafe Vector* Vector( this Rotator rotator, Vector* output )
		{
			* output = rotator.Vector();
			return output;
		}



		public static IUWorld GWorld => ;



		public static unsafe void SetFromBitfield(ref bool b, int span, uint bitfield)
		{
			fixed( bool* v = &b )
			{
				for( int i = 0; i < span; i++ )
				{
					v[i] = ( bitfield & ( 1 << i ) ) != 0;
				}
			}
		}
		
		public static unsafe uint AsBitfield(ref this bool b, int span)
		{
			fixed( bool* v = & b )
			{
				int output = 0;
				for( int i = 0; i < span; i++ )
				{
					if( v[ i ] )
						output |= 1 << i;
				}

				return output;
			}
		}
		
		
		
		public static unsafe int E_GetHeadingAngle(_E_struct_FVector *a1)
		{
			float v1; // xmm1_4
			float v2; // xmm0_4
			double v3; // st7
			float v5; // [esp+4h] [ebp+4h]
			float v6; // [esp+4h] [ebp+4h]

			v1 = -1.0f;
			v2 = a1->X;
			if ( a1->Y <= 0.0f )
			{
				if ( v2 < -1.0f || ((v1 = 1.0f) is object && v2 >= 1.0f) )
					v5 = v1;
				else
					v5 = a1->X;
				v3 = -Acos(v5);
			}
			else if ( v2 < -1.0 || ((v1 = 1.0f) is object && v2 >= 1.0f) )
			{
				v3 = Acos(v1);
			}
			else
			{
				v3 = Acos(v2);
			}
			v6 = (float)v3;
			return (int)(float)((float)(v6 * 32768.0) * 0.31830987);
		}



		public static unsafe void CallUFunction<T>(System.Func<T> func, Object target, int idk, T* parameters, int idk2) where T : unmanaged
		{
			*parameters = func();
		}
		
		public static void CallUFunction(System.Action func, object target, int idk, int parameters, int idk2)
		{
			func();
		}
		
		public static unsafe void CallUFunction<T>( TdPawn.SetMove_del func, object target, int idk, T* parameters, int idk2 ) where T : unmanaged
		{
			if( typeof(T) != typeof(Object.Vector) && typeof(T) != typeof(byte) )
				throw new NotImplementedException("Haven't yet looked at how those other parameters are passed in");

			for( int i = 1; i < 12; i++ )
			{
				if( ( (byte*) parameters )[ i ] != default )
				{
					throw new NotImplementedException("Haven't yet looked at how those other parameters are passed in");
				}
			}
			
			func( (TdPawn.EMovement)(*((byte*)&(parameters))), false, false );
		}
		
		public static unsafe void CallUFunction( Action<bool?> func, object target, int idk, int* parameters, int idk2 )
		{
			func.Invoke(*parameters != 0);
		}



		public static unsafe Matrix* FRotationMatrix( Matrix* allocPtr, Rotator* rRef )
		{
			* allocPtr = Core.Object.FRotationMatrix( * rRef );
			return allocPtr;
		}



		public static _QWORD __PAIR64__( int a, int b ) => new _QWORD( a, b );
		
		

		[StructLayout( LayoutKind.Sequential, Size = 8)]
		public struct _QWORD
		{
			int a, b;
			public _QWORD( int a, int b )
			{
				this.a = a;
				this.b = b;
			}



			public static implicit operator long( _QWORD qw )
			{
				unsafe
				{
					return * ( (long*) & qw );
				}
			}
			public static implicit operator _QWORD( long qw )
			{
				unsafe
				{
					return * ( (_QWORD*) & qw );
				}
			}
		}



		public struct CheckResult// : public FIteratorActorList
        {
	        #error
	        public unsafe CheckResult * Next
	        {
		        get
		        {
			        return default;
		        }
		        set
		        {
			        
		        }
	        }

	        public Actor Actor
	        {
		        get
		        {
			        return default;
		        }
		        set
		        {
			        
		        }
	        }
	        // Variables.
	        public Object.Vector Location; // Location of the hit in coordinate system of the returner.
	        public Object.Vector Normal; // Normal vector in coordinate system of the returner. Zero=none.
	        public float Time; // Time until hit, if line check.
	        public int Item; // Primitive data item which was hit, INDEX_NONE=none.
	        public MaterialInterface Material
	        {
		        get
		        {
			        return default;
		        }
		        set
		        {
			        
		        }
	        }	// Material of the item which was hit.
	        public PhysicalMaterial	PhysMaterial
	        {
		        get
		        {
			        return default;
		        }
		        set
		        {
			        
		        }
	        } // Physical material that was hit
	        public PrimitiveComponent	Component
	        {
		        get
		        {
			        return default;
		        }
		        set
		        {
			        
		        }
	        }	// PrimitiveComponent that the check hit.
	        public name BoneName
	        {
		        get
		        {
			        return default;
		        }
		        set
		        {
			        
		        }
	        }	// Name of bone we hit (for skeletal meshes).
	        public Level Level
	        {
		        get
		        {
			        return default;
		        }
		        set
		        {
			        
		        }
	        }		// Level that was hit in case of BSPLineCheck


	        public int LevelIndex; // Index of the level that was hit in the case of BSP checks.

	        /** This line check started penetrating the primitive. */
	        public bool						bStartPenetrating;

	        // Functions.
	        /*FCheckResult()
		        : Location	(0,0,0)
		        , Normal	(0,0,0)
		        , Time		(0.0f)
		        , Item		(INDEX_NONE)
		        , Material	(NULL)
		        , PhysMaterial( NULL)
		        , Component	(NULL)
		        , BoneName	(NAME_None)
		        , Level		(NULL)
		        , LevelIndex	(INDEX_NONE)
		        , bStartPenetrating	(FALSE)
	        {}


	        FCheckResult( FLOAT InTime, FCheckResult* InNext=NULL )
		        :	FIteratorActorList( InNext, NULL )
		        ,	Location	(0,0,0)
		        ,	Normal		(0,0,0)
		        ,	Time		(InTime)
		        ,	Item		(INDEX_NONE)
		        ,	Material	(NULL)
		        ,   PhysMaterial( NULL)
		        ,	Component	(NULL)
		        ,	BoneName	(NAME_None)
		        ,	Level		(NULL)
		        ,	LevelIndex	(INDEX_NONE)
		        ,	bStartPenetrating	(FALSE)
	        {}


	        FCheckResult*& GetNext() const
	        { 
		        return *(FCheckResult**)&Next; 
	        }


	        static QSORT_RETURN CDECL CompareHits( const FCheckResult* A, const FCheckResult* B )
	        { 
		        return A->Time<B->Time ? -1 : A->Time>B->Time ? 1 : 0; 
	        }*/
        }
	}
}