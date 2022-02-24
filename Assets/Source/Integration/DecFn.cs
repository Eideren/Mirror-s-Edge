namespace MEdge.Source
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;
	using Core;
	using Engine;
	using TdGame;
	using UnityEngine;
	using static Core.Object;
	using Object = Core.Object;
	using _E_struct_FVector = Core.Object.Vector;
	using _E_struct_FRotator = Core.Object.Rotator;
	using _E_struct_FMatrix = Core.Object.Matrix;
	using _E_struct_FQuat = Core.Object.Quat;
	using FLOAT = System.Single;
	using INT = System.Int32;
	using FVector = Core.Object.Vector;
	using FVector4 = Core.Object.Vector4;
	using FRotator = Core.Object.Rotator;

	
	public unsafe static class DecFn
	{
		public const float UCONST_ACTORMAXSTEPHEIGHT = 35.0f;
		public const float UCONST_MINFLOORZ = 0.7f;
		static System.Random _randomSource = new System.Random();
		public static float appAcos( FLOAT Value ) { return MathF.Acos( (Value<-1f) ? -1f : ((Value<1f) ? Value : 1f) ); }
		public static float appSin( FLOAT Value ) { return MathF.Sin( Value ); }
		public static float appAsin( FLOAT Value ) { return MathF.Asin( (Value<-1f) ? -1f : ((Value<1f) ? Value : 1f)  ); }
		
		public static float appSqrt( float f1 ) => (float)sqrt( f1 );
		public static float appAtan2( float f1, float f2 ) => (float)atan2( f1, f2 );
		public static int appRound( float f ) => Object.Round( f );
		public static double fabs( double f ) => System.Math.Abs( f );
		public static double pow( double x, double p ) => System.Math.Pow( x, p );
		public static double sqrt( double f ) => System.Math.Sqrt( f );
		public static float fsqrt( float f ) => System.MathF.Sqrt( f );
		public static double floor( double f ) => System.Math.Floor( f );
		public static int appFloor( float F ) => appTrunc(System.MathF.Floor(F));
		public static double asin( double f ) => System.Math.Asin( f );
		public static double sin( double f ) => System.Math.Sin( f );
		public static double cos( double f ) => System.Math.Cos( f );
		public static float appCos( float f ) => System.MathF.Cos( f );
		public static int rand() => _randomSource.Next();
		public static float appSRand() => (float)(_randomSource.NextDouble()*2d-1d); // Maybe ?
		public static float appFrand() => (float)_randomSource.NextDouble(); // Maybe ?
		public static double atan2( double y, double x ) => System.Math.Atan2( y, x );
		
		
		public static short LOWORD( int i ) => (short)(i & 0b1111_1111_1111_1111);
		public static short LOWORD( float f ) => LOWORD( *(int*)&f );
		public static byte LOBYTE( float i ) => *(byte*)&i;
		public static byte LOBYTE( int i ) => *(byte*)&i;
		public static byte LOBYTE( uint i ) => *(byte*)&i;
		public static byte HIBYTE( uint i ) => ((byte*) & i)[3];
		public static sbyte SLOBYTE( int i ) => *(sbyte*)&i;
		public static sbyte SLOBYTE( uint i ) => *(sbyte*)&i;
		public static uint LODWORD( float i ) => *(uint*)&i;
		public static int SLODWORD( float i ) => *(int*)&i;
		public static float COERCE_FLOAT( int i ) => *(float*)&i;
		public static byte BYTE2<T>( T x ) where T : unmanaged => BYTEn( x, 2 );
		public static byte BYTEn<T>( T x, int n ) where T : unmanaged => ( * ( (byte*) & ( x ) + n ) );

		public static bool AsBool( this int i ) => i != 0 ? true : false;
		public static bool AsBool( this uint i ) => i != 0 ? true : false;
		public static void Swap<T>( ref T A, ref T B )
		{
			T Temp = A;
			A = B;
			B = Temp;
		}
		public static void Exchange<T>( ref T A, ref T B )
		{
			Swap(ref A, ref B);
		}
		
		public static float CubicInterp( float P0, float T0, float P1, float T1, float A )
		{
			FLOAT A2 = A  * A;
			FLOAT A3 = A2 * A;

			return (((2*A3)-(3*A2)+1) * P0) + ((A3-(2*A2)+A) * T0) + ((A3-A2) * T1) + (((-2*A3)+(3*A2)) * P1);
		}
		public static int E_ClampInt(int srcVal, int min, int max)
		{
			int result; // eax

			result = srcVal;
			if ( srcVal < min )
				result = min;
			if ( result > max )
				result = max;
			return result;
		}
		
		public static void E_MatrixToRotator(_E_struct_FMatrix *a1, _E_struct_FRotator *a2)
		{
			float v3; // xmm0_4
			double v4; // st7
			_E_struct_FRotator *v5; // edi
			float v6; // xmm0_4
			float a1b; // [esp+4h] [ebp+4h]
			float a1a; // [esp+4h] [ebp+4h]
			float a1c; // [esp+4h] [ebp+4h]
			float a1d; // [esp+4h] [ebp+4h]
			float a1e; // [esp+4h] [ebp+4h]
			float a1f; // [esp+4h] [ebp+4h]

			v3 = a1->ZPlane.Y;
			if ( v3 >= 1.0 )
			{
				if ( fabs(a1->XPlane.Z) >= 0.00000001 || fabs(a1->XPlane.X) >= 0.00000001 )
				{
					a1f = (float)(atan2(a1->XPlane.Z, a1->XPlane.X) * 10430.378);
					a2->Yaw = (int)a1f;
					a2->Roll = 0x4000;
					a2->Pitch = 0;
				}
				else
				{
					a2->Yaw = 0;
					a2->Roll = 0x4000;
					a2->Pitch = 0;
				}
			}
			else if ( v3 <= -1.0 )
			{
				if ( fabs(a1->XPlane.Z) >= 0.00000001 || fabs(a1->XPlane.X) >= 0.00000001 )
				{
					a1e = (float)(atan2(a1->XPlane.Z, a1->XPlane.X) * -10430.378);
					a2->Yaw = (int)a1e;
					a2->Roll = -16384;
					a2->Pitch = 0;
				}
				else
				{
					a2->Yaw = 0;
					a2->Roll = -16384;
					a2->Pitch = 0;
				}
			}
			else
			{
				v4 = a1->XPlane.Y;
				if ( fabs(v4) >= 0.00000001 || fabs(a1->YPlane.Y) >= 0.00000001 )
				{
					a1b = (float)(atan2(v4, a1->YPlane.Y) * 10430.378);
					v5 = a2;
					a2->Yaw = (int)a1b;
				}
				else
				{
					v5 = a2;
					a2->Yaw = 0;
				}
				v6 = a1->ZPlane.Y;
				if ( v6 >= -1.0 )
				{
					if ( v6 >= 1.0 )
						a1a = 1.0f;
					else
						a1a = a1->ZPlane.Y;
				}
				else
				{
					a1a = -1.0f;
				}
				a1c = (float)(asin(a1a) * 10430.378);
				v5->Roll = (int)a1c;
				if ( fabs(a1->ZPlane.X) >= 0.00000001 || fabs(a1->ZPlane.Z) >= 0.00000001 )
				{
					a1d = (float)(10430.378 * atan2(-a1->ZPlane.X, a1->ZPlane.Z));
					v5->Pitch = (int)a1d;
				}
				else
				{
					v5->Pitch = 0;
				}
			}
		}
		
		public static _E_struct_FRotator * E_Quat2Rot(_E_struct_FRotator *thiss, _E_struct_FQuat *a2)
		{
			_E_struct_FMatrix *v2; // eax
			_E_struct_FVector a3; // [esp+0h] [ebp-4Ch] BYREF
			_E_struct_FMatrix v5; // [esp+Ch] [ebp-40h] BYREF

			a3.X = 0.0f;
			a3.Y = 0.0f;
			a3.Z = 0.0f;
			v5 = FQuatRotationTranslationMatrix(*a2, a3);
			v2 = & v5;
			* thiss = v2 -> Rotator();
			//*thiss = *FMatrix::Rotator(v2, (_E_struct_FRotator *)&a3);
			return thiss;
		}
		public static _E_struct_FVector * E_SomeKindOfLerp(_E_struct_FVector* output, ref _E_struct_FVector atZero, ref _E_struct_FVector atOne, ref float scaler, float scaler_scaler)
		{
			float v5; // xmm0_4
			float v6; // xmm3_4
			double v7; // st7
			float v8; // xmm4_4
			float v9; // xmm6_4
			float v10; // xmm7_4
			_E_struct_FVector *result; // eax
			float v12; // ecx
			float v13; // xmm1_4
			float v14; // edx
			float v15; // [esp+4h] [ebp-Ch]

			v5 = 0.0f;
			if ( scaler == 0.0 || atZero.X == atOne.X && atZero.Y == atOne.Y && atZero.Z == atOne.Z )
			{
				result = output;
				output->X = atZero.X;
				v14 = atZero.Z;
				output->Y = atZero.Y;
				output->Z = v14;
			}
			else
			{
				v6 = atZero.Y;
				v7 = atOne.X - atZero.X;
				v8 = atZero.Z;
				v9 = atOne.Y - v6;
				v10 = atOne.Z - v8;
				if ( v7 * v7 + v9 * v9 + v10 * v10 >= 0.0001 )
				{
					v13 = scaler * scaler_scaler;
					if ( v13 >= 0.0 )
					{
						v5 = scaler * scaler_scaler;
						if ( v13 > 1.0 )
							v5 = 1.0f;
					}
					result = output;
					v15 = (float)v7;
					output->X = atZero.X + (float)(v5 * v15);
					output->Y = v6 + (float)(v5 * v9);
					output->Z = v8 + (float)(v5 * v10);
				}
				else
				{
					result = output;
					output->X = atOne.X;
					v12 = atOne.Z;
					output->Y = atOne.Y;
					output->Z = v12;
				}
			}
			return result;
		}
		
		public static FLOAT GetMaximumAxisScale(in Matrix Matrix)
		{
			FLOAT MaxRowScaleSquared = Max(
				Matrix.GetAxis(0).SizeSquared(),
				Max(
					Matrix.GetAxis(1).SizeSquared(),
					Matrix.GetAxis(2).SizeSquared()
				)
			);
			return appSqrt(MaxRowScaleSquared);
		}
		
		public static Matrix BuildMatrixFromVectors(Object.EAxis Vec1Axis, in FVector Vec1, Object.EAxis Vec2Axis, in FVector Vec2)
		{
			check(Vec1 != Vec2);

			Matrix OutMatrix = Matrix.Identity;

			if(Vec1Axis == Object.EAxis.AXIS_X)
			{
				OutMatrix.SetAxis(0, Vec1);

				if(Vec2Axis == Object.EAxis.AXIS_Y)
				{
					OutMatrix.SetAxis(1, Vec2);
					OutMatrix.SetAxis(2, Vec1 ^ Vec2);
				}
				else // AXIS_Z
				{
					OutMatrix.SetAxis(2, Vec2);
					OutMatrix.SetAxis(1, Vec2 ^ Vec1 );
				}
			}
			else if(Vec1Axis == Object.EAxis.AXIS_Y)
			{
				OutMatrix.SetAxis(1, Vec1);

				if(Vec2Axis == Object.EAxis.AXIS_X)
				{
					OutMatrix.SetAxis(0, Vec2);
					OutMatrix.SetAxis(2, Vec2 ^ Vec1);
				}
				else // AXIS_Z
				{
					OutMatrix.SetAxis(2, Vec2);
					OutMatrix.SetAxis(0, Vec1 ^ Vec2 );
				}
			}
			else // AXIS_Z
			{
				OutMatrix.SetAxis(2, Vec1);

				if(Vec2Axis == Object.EAxis.AXIS_X)
				{
					OutMatrix.SetAxis(0, Vec2);
					OutMatrix.SetAxis(1, Vec1 ^ Vec2);
				}
				else // AXIS_Y
				{
					OutMatrix.SetAxis(1, Vec2);
					OutMatrix.SetAxis(0, Vec2 ^ Vec1 );
				}
			}

			FLOAT Det = OutMatrix.RotDeterminant();
			if( OutMatrix.Determinant() <= 0f )
			{
				debugf( TEXT("BuildMatrixFromVectors : Bad Determinant (%f)"), Det );
				debugf( TEXT("Vec1: %d (%f %f %f)"), Vec1Axis, Vec1.X, Vec1.Y, Vec1.Z );
				debugf( TEXT("Vec2: %d (%f %f %f)"), Vec2Axis, Vec2.X, Vec2.Y, Vec2.Z );
			}
			//check( OutMatrix.RotDeterminant() > 0.f );

			return OutMatrix;
		}
		
		
		public static Quat FQuatFindBetween(in FVector vec1, in FVector vec2)
		{
			FVector cross = vec1 ^ vec2;
			FLOAT crossMag = cross.Size();

			// If these vectors are basically parallel - just return identity quaternion (ie no rotation).
			if(crossMag < KINDA_SMALL_NUMBER)
			{
				return Quat.Identity;
			}

			if(crossMag < KINDA_SMALL_NUMBER)
			{
				FLOAT Dot = vec1 | vec2;
				if(Dot > -KINDA_SMALL_NUMBER)
				{
					return Quat.Identity; // no rotation
				}
				else
				{
					// rotation by 180 degrees around a vector orthogonal to vec1 & vec2
					FVector Vec = vec1.SizeSquared() > vec2.SizeSquared() ? vec1 : vec2;
					Vec.Normalize();

					FVector AxisA = default, AxisB = default;
					Vec.FindBestAxisVectors(ref AxisA, ref AxisB);

					return new Quat(AxisA.X, AxisA.Y, AxisA.Z, 0f); // (axis*sin(pi/2), cos(pi/2)) = (axis, 0)
				}
			}

			FLOAT angle = appAsin(crossMag);

			FLOAT dot = vec1 | vec2;
			if(dot < 0.0f)
			{
				angle = PI - angle;
			}

			FLOAT sinHalfAng = appSin(0.5f * angle);
			FLOAT cosHalfAng = appCos(0.5f * angle);
			FVector axis = cross / crossMag;

			return new Quat(
				sinHalfAng * axis.X,
				sinHalfAng * axis.Y,
				sinHalfAng * axis.Z,
				cosHalfAng );
		}
		
		public static void CopyRotationPart(ref Matrix DestMatrix, in Matrix SrcMatrix)
		{
			DestMatrix.M[0,0] = SrcMatrix.M[0,0];
			DestMatrix.M[0,1] = SrcMatrix.M[0,1];
			DestMatrix.M[0,2] = SrcMatrix.M[0,2];

			DestMatrix.M[1,0] = SrcMatrix.M[1,0];
			DestMatrix.M[1,1] = SrcMatrix.M[1,1];
			DestMatrix.M[1,2] = SrcMatrix.M[1,2];

			DestMatrix.M[2,0] = SrcMatrix.M[2,0];
			DestMatrix.M[2,1] = SrcMatrix.M[2,1];
			DestMatrix.M[2,2] = SrcMatrix.M[2,2];
		}
            
		
            
		public static Matrix FTranslationMatrix(in Vector Delta)
		{
			Matrix m = default;
			m.XPlane.X = 1f;
			m.YPlane.Y = 1f;
			m.ZPlane.Z = 1f;
                
			m.WPlane.X = Delta.X;
			m.WPlane.Y = Delta.Y;
			m.WPlane.Z = Delta.Z;
                
			m.WPlane.W = 1f;
			return m;
		}
		
		public static Matrix FScaleMatrix(in FVector Scale)
		{
			return 
			FMatrix(
				FPlane( Scale.X, 0.0f, 0.0f, 0.0f ),
				FPlane( 0.0f, Scale.Y, 0.0f, 0.0f ),
				FPlane( 0.0f, 0.0f, Scale.Z, 0.0f ),
				FPlane( 0.0f, 0.0f, 0.0f, 1.0f ) );
		}
		
		public static Matrix FScaleMatrix(float Scale)
		{
			return 
				FMatrix(
					FPlane( Scale, 0.0f, 0.0f, 0.0f ),
					FPlane( 0.0f, Scale, 0.0f, 0.0f ),
					FPlane( 0.0f, 0.0f, Scale, 0.0f ),
					FPlane( 0.0f, 0.0f, 0.0f, 1.0f ) );
		}
		
		public static Box GetBox(this BoxSphereBounds bsb)
		{
			return new Box(){ Min = bsb.Origin - bsb.BoxExtent, Max = bsb.Origin + bsb.BoxExtent, IsValid = 1 };
		}
		
		public static FVector GetExtent( this Box bsb )
		{
			return 0.5f*(bsb.Max - bsb.Min);
		}
		public static void GetCenterAndExtents( this Box bsb, out FVector center, out FVector Extents )
		{
			Extents = bsb.GetExtent();
			center = bsb.Min + Extents;
		}

		public static unsafe bool AsBool<T>( this T i ) where T : unmanaged, System.Enum
		{
			ulong l = default;
			*(T*) & l = i;
			return l != default;
		}



		public static int AsInt( this bool i ) => i ? 1 : 0;
		public static uint AsUInt( this bool i ) => i ? 1u : 0;



		public static bool AllGreaterThan( this Vector thiss, float a2 )
		{
			return a2 > fabs(thiss.X) && a2 > fabs(thiss.Y) && a2 > fabs(thiss.Z);
		}



		public static void LODWORD( this ref float i, int v )
		{
			i = * (float*) & v;
		}
		public static void LODWORD( this ref float i, bool v )
		{
			float cpy = 0f;
			( *(bool*) & cpy ) = v;
			i = cpy;
		}
		public static void LODWORD( this ref float i, uint v )
		{
			i = * (float*) & v;
		}
		public static void LOBYTE( this ref float i, int v )
		{
			var cpy = i;
			* (byte*) & cpy = (byte)v;
			i = cpy;
		}
		public static void LOBYTE( this ref int i, int v )
		{
			var cpy = i;
			* (byte*) & cpy = (byte)v;
			i = cpy;
		}
		
		public static INT appTrunc( FLOAT F )
		{
			return (INT)F;
			//	return (INT)truncf(F);
		}
		
		public static bool IsProbing( this Object obj, int ProbeName0, int ProbeName1 )
		{
			// AFAICT checks whether the given object has an implemented function of that name
			return true;
			/*return	(obj.ProbeName.GetIndex() <  NAME_PROBEMIN)
			        ||		(obj.ProbeName.GetIndex() >= NAME_PROBEMAX)
			        ||		(!StateFrame)
			        ||		(StateFrame->ProbeMask & ((QWORD)1 << (ProbeName.GetIndex() - NAME_PROBEMIN)));*/
		}



		public static Vector* GetBoneAxis( this SkeletalMeshComponent thiss, Vector* ou, name n, EAxis axis )
		{
			* ou = thiss.GetBoneAxis( n, axis );
			return ou;
		}
		public static Matrix* GetBoneMatrix( this SkeletalMeshComponent thiss, Matrix* ou, int index )
		{
			* ou = thiss.GetBoneMatrix( index );
			return ou;
		}



		public static void TwoWallAdjust(in FVector DesiredDir, ref FVector Delta, in FVector HitNormal, in FVector OldHitNormal, FLOAT HitTime)
		{
			if ((OldHitNormal | HitNormal) <= 0f) //90 or less corner, so use cross product for dir
			{
				FVector NewDir = (HitNormal ^ OldHitNormal);
				NewDir = NewDir.SafeNormal();
				Delta = (Delta | NewDir) * (1f - HitTime) * NewDir;
				if ((DesiredDir | Delta) < 0f)
					Delta = -1f * Delta;
			}
			else //adjust to new wall
			{
				Delta = (Delta - HitNormal * (Delta | HitNormal)) * (1f - HitTime);
				if ((Delta | DesiredDir) <= 0f)
					Delta = FVector(0f,0f,0f);
			}
		}



		public static Matrix Mult( this Matrix Result, Matrix* mA, Matrix* mB )
		{
			//typedef FLOAT Float4x4[4][4];
			//const Float4x4& A = *((const Float4x4*) Matrix1);
			//const Float4x4& B = *((const Float4x4*) Matrix2);
			ref var A = ref * mA;
			ref var B = ref * mB;
			Result[0, 0] = A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0] + A[0, 2] * B[2, 0] + A[0, 3] * B[3, 0];
			Result[0, 1] = A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1] + A[0, 2] * B[2, 1] + A[0, 3] * B[3, 1];
			Result[0, 2] = A[0, 0] * B[0, 2] + A[0, 1] * B[1, 2] + A[0, 2] * B[2, 2] + A[0, 3] * B[3, 2];
			Result[0, 3] = A[0, 0] * B[0, 3] + A[0, 1] * B[1, 3] + A[0, 2] * B[2, 3] + A[0, 3] * B[3, 3];

			Result[1, 0] = A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0] + A[1, 2] * B[2, 0] + A[1, 3] * B[3, 0];
			Result[1, 1] = A[1, 0] * B[0, 1] + A[1, 1] * B[1, 1] + A[1, 2] * B[2, 1] + A[1, 3] * B[3, 1];
			Result[1, 2] = A[1, 0] * B[0, 2] + A[1, 1] * B[1, 2] + A[1, 2] * B[2, 2] + A[1, 3] * B[3, 2];
			Result[1, 3] = A[1, 0] * B[0, 3] + A[1, 1] * B[1, 3] + A[1, 2] * B[2, 3] + A[1, 3] * B[3, 3];

			Result[2, 0] = A[2, 0] * B[0, 0] + A[2, 1] * B[1, 0] + A[2, 2] * B[2, 0] + A[2, 3] * B[3, 0];
			Result[2, 1] = A[2, 0] * B[0, 1] + A[2, 1] * B[1, 1] + A[2, 2] * B[2, 1] + A[2, 3] * B[3, 1];
			Result[2, 2] = A[2, 0] * B[0, 2] + A[2, 1] * B[1, 2] + A[2, 2] * B[2, 2] + A[2, 3] * B[3, 2];
			Result[2, 3] = A[2, 0] * B[0, 3] + A[2, 1] * B[1, 3] + A[2, 2] * B[2, 3] + A[2, 3] * B[3, 3];

			Result[3, 0] = A[3, 0] * B[0, 0] + A[3, 1] * B[1, 0] + A[3, 2] * B[2, 0] + A[3, 3] * B[3, 0];
			Result[3, 1] = A[3, 0] * B[0, 1] + A[3, 1] * B[1, 1] + A[3, 2] * B[2, 1] + A[3, 3] * B[3, 1];
			Result[3, 2] = A[3, 0] * B[0, 2] + A[3, 1] * B[1, 2] + A[3, 2] * B[2, 2] + A[3, 3] * B[3, 2];
			Result[3, 3] = A[3, 0] * B[0, 3] + A[3, 1] * B[1, 3] + A[3, 2] * B[2, 3] + A[3, 3] * B[3, 3];
			return Result;
			//memcpy( Result, &Temp, 16*sizeof(FLOAT) );
		}
		
		
		
		
		public static Matrix FRotationTranslationMatrix(in Rotator Rot, in FVector Origin)
		{
			Matrix M = default;
			FLOAT	SR	= GMath.SinTab(Rot.Roll);
			FLOAT	SP	= GMath.SinTab(Rot.Pitch);
			FLOAT	SY	= GMath.SinTab(Rot.Yaw);
			FLOAT	CR	= GMath.CosTab(Rot.Roll);
			FLOAT	CP	= GMath.CosTab(Rot.Pitch);
			FLOAT	CY	= GMath.CosTab(Rot.Yaw);

			M[0,0]	= CP * CY;
			M[0,1]	= CP * SY;
			M[0,2]	= SP;
			M[0,3]	= 0f;

			M[1,0]	= SR * SP * CY - CR * SY;
			M[1,1]	= SR * SP * SY + CR * CY;
			M[1,2]	= - SR * CP;
			M[1,3]	= 0f;

			M[2,0]	= -( CR * SP * CY + SR * SY );
			M[2,1]	= CY * SR - CR * SP * SY;
			M[2,2]	= CR * CP;
			M[2,3]	= 0f;

			M[3,0]	= Origin.X;
			M[3,1]	= Origin.Y;
			M[3,2]	= Origin.Z;
			M[3,3]	= 1f;
			return M;
		}



		public static Object.Plane FPlane( float x, float y, float z, float w ) => new Object.Plane {X = x, Y = y, Z = z, W = w};
		public static Matrix FMatrix( Object.Plane x, Object.Plane y, Object.Plane z, Object.Plane w ) => new Matrix {PlaneX = x, PlaneY = y, PlaneZ = z, PlaneW = w};


		public static Matrix FInverseRotationMatrix( in Rotator Rot )
		{
			return (
				FMatrix( // Yaw
					FPlane( + GMath.CosTab( - Rot.Yaw ), + GMath.SinTab( - Rot.Yaw ), 0.0f, 0.0f ),
					FPlane( - GMath.SinTab( - Rot.Yaw ), + GMath.CosTab( - Rot.Yaw ), 0.0f, 0.0f ),
					FPlane( 0.0f, 0.0f, 1.0f, 0.0f ),
					FPlane( 0.0f, 0.0f, 0.0f, 1.0f ) ) *
				FMatrix( // Pitch
					FPlane( + GMath.CosTab( - Rot.Pitch ), 0.0f, + GMath.SinTab( - Rot.Pitch ), 0.0f ),
					FPlane( 0.0f, 1.0f, 0.0f, 0.0f ),
					FPlane( - GMath.SinTab( - Rot.Pitch ), 0.0f, + GMath.CosTab( - Rot.Pitch ), 0.0f ),
					FPlane( 0.0f, 0.0f, 0.0f, 1.0f ) ) *
				FMatrix( // Roll
					FPlane( 1.0f, 0.0f, 0.0f, 0.0f ),
					FPlane( 0.0f, + GMath.CosTab( - Rot.Roll ), - GMath.SinTab( - Rot.Roll ), 0.0f ),
					FPlane( 0.0f, + GMath.SinTab( - Rot.Roll ), + GMath.CosTab( - Rot.Roll ), 0.0f ),
					FPlane( 0.0f, 0.0f, 0.0f, 1.0f ) )
			);
		}
	


		public static MEdge.Engine.MaterialInterface GetMaterial(this MEdge.Engine.MaterialInterface material, int/*EMaterialShaderPlatform*/ Platform)
		{
			NativeMarkers.MarkUnimplemented();
			return material;
			//pass the request to the fallback material if one exists and this is a sm2 platform
			/*if (material.FallbackMaterial && Platform == 1)
			{
				return material.FallbackMaterial.GetMaterial(Platform);
			}

			const MaterialResource * MaterialResource = GetMaterialResource(Platform);

			if(MaterialResource)
			{
				return this;
			}
			else
			{
				return GEngine ? GEngine->DefaultMaterial : NULL;
			}*/
		}



		public static int* GMem_ptr => null;



		public static float PointDistToLine( _E_struct_FVector* Point, _E_struct_FVector* Direction, _E_struct_FVector* Origin, _E_struct_FVector* OutClosestPoint )
		{
			Vector SafeDir = Direction->SafeNormal();
			*OutClosestPoint = *Origin + (SafeDir * (Dot((*Point-*Origin), SafeDir)));
			return (*OutClosestPoint-*Point).Size();
		}



		public static bool Encompasses( this Volume thiss, Vector vec )
		{
			NativeMarkers.MarkUnimplemented();
			return false;
			/*check(CollisionComponent);

			CheckResult Hit = new(1f);
			if (thiss.Brush != NULL)
			{
				//	debugf(TEXT("%s brush pointcheck %d at %f %f %f"),*GetName(),!Brush->PointCheck(Hit,this,	point, FVector(0.f,0.f,0.f), 0), point.X, point.Y,point.Z);
				return !thiss.Brush->PointCheck(Hit,this,	NULL, point, FVector(0.f,0.f,0.f));
			}
			else
			{
				return (Cast<UBrushComponent>(CollisionComponent) != NULL) ? FALSE : !CollisionComponent->PointCheck(Hit, point, FVector(0.f, 0.f, 0.f), 0);
			}*/
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
		
		
		public static Vector* RotateVector(this Quat quat, Vector* vOut, Vector v)
		{	
			// (q.W*q.W-qv.qv)v + 2(qv.v)qv + 2 q.W (qv x v)

			Vector qv = new Vector(quat.X, quat.Y, quat.Z);
			*vOut = 2f * quat.W * (qv ^ v);
			*vOut += ((quat.W * quat.W) - (qv | qv)) * v;
			*vOut += (2f * (qv | v)) * qv;

			return vOut;
		}
		
		public static Vector* GetBoneLocation(this SkeletalMeshComponent mesh, Vector* vOut, name BoneName, /*optional */int? _Space = default) // 0 == World, 1 == Local (Component)
		{
			* vOut = mesh.GetBoneLocation( BoneName, _Space );
			return vOut;
		}



		public static float appInvSqrt(float x)
		{
			return 1f / MathF.Sqrt( x );
		}



		public static PhysicsVolume E_TryFindPhysicsVolumeAtThisLocation_Maybe( _E_struct_FVector vecArg, Object type )
		{
			NativeMarkers.MarkUnimplemented();
			return null;
		}



		public static int GMem;
		public static int FMemMark_Maybe => GMem;
		/*public static DecFn.CheckResult* MultiLineCheck( this IUWorld world, ref int Mem, in Object.Vector End, in Object.Vector Start, in Object.Vector Extent, uint TraceFlags, Actor SourceActor, int dummy )
		{
			if( dummy != 0 )
				throw new NotImplementedException();
			
			return world.MultiLineCheck( ref Mem, End, Start, Extent, TraceFlags, SourceActor, 0 );
		}*/
		
		public static FVector4 TransformFVector(this Matrix thiss, in FVector V)
		{
			return TransformFVector4(thiss, new FVector4(V.X,V.Y,V.Z,1.0f));
		}



		public static void FMemMark_Pop_Maybe(ref int Mem, int Mark)
		{
			
		}



		public static void qmemcpy(ref CheckResult dest, CheckResult source, uint length)
		{
			if(length != 0x4Cu)
				throw new NotImplementedException();
			CheckResult.Overwrite(ref dest, source);
		}
		public static void qmemcpy<T>(ref T dest, T source, int length) where T : unmanaged
		{
			if(length != sizeof(T))
				throw new NotImplementedException();
			dest = source;
		}



		public static Object GetDefaultObject( this Class c, int bForce )
		{
			if(bForce != 0)
				throw new NotImplementedException();
			return c.DefaultAs<Object>();
		}



		/*public static void setPhysics( this TdPawn thiss, byte NewPhysics, int NewFloor, int NewFloorVX, int NewFloorVY, int NewFloorVZ )
		{
			Debug.Assert(NewFloor == 0);
			thiss.setPhysics(NewPhysics, null, new Vector(*(float*)&NewFloorVX, *(float*)&NewFloorVY, *(float*)&NewFloorVZ));
		}*/



		public static _E_struct_FVector * E_GetDefaultCollExtent(TdPawn thiss, _E_struct_FVector *a2)
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
		
		
		public static _E_struct_FRotator * E_DirToRotator(in _E_struct_FVector thiss, _E_struct_FRotator* out_a)
		{
			double v2; // st5
			double v4; // st4
			float v6; // [esp+0h] [ebp-4h]
			float a2a; // [esp+8h] [ebp+4h]

			v6 = (float)(atan2(thiss.Y, thiss.X) * 65535.0d * 0.1591549430918953d);
			v2 = thiss.Y;
			v4 = thiss.X;
			out_a->Yaw = (int)v6;
			a2a = (float)(0.1591549430918953d * (65535.0d * atan2(thiss.Z, sqrt(v4 * v4 + v2 * v2))));
			out_a->Pitch = (int)a2a;
			out_a->Roll = 0;
			return out_a;
		}
		
		public static _E_struct_FRotator * E_ClipAmountOfTurns(_E_struct_FRotator *thiss, _E_struct_FRotator *a5)
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
		
		
		
		public static _E_struct_FVector * GetCylinderExtent(this Actor thiss, _E_struct_FVector *a2)
		{
			* a2 = thiss.GetCylinderExtent();
			return a2;
		}
		
		
		
		public static void E_FLedgeHitInfo_FillWith(ref TdPawn.LedgeHitInfo a1, CheckResult *a2, _E_struct_FVector *a3, _E_struct_FVector a4, _E_struct_FVector a9)
		{
			float v5; // ecx
			uint v6; // ecx
			PrimitiveComponent v7; // ecx
			uint v8; // ecx
			uint v9; // ecx

			a1.LedgeNormal = a4;
			a1.LedgeLocation.X = a3->X;
			a1.LedgeLocation.Y = a3->Y;
			v5 = a3->Z;
			SetFromBitfield(ref a1.FeetExcluded, 2, a1.FeetExcluded.AsBitfield(2) & ~3u);
			a1.MoveNormal.X = a9.X;
			a1.LedgeLocation.Z = v5;
			a1.MoveNormal.Y = a9.Y;
			a1.MoveNormal.Z = a9.Z;
			a1.MoveActor = default;
			if( a2->Actor )
			{
				v6 =(uint)(a1.FeetExcluded.AsBitfield(2) ^ ( (byte)a1.FeetExcluded.AsBitfield(2) ^ (byte)( a1.FeetExcluded.AsBitfield(2) | ( a2->Actor.bExludeHandMoves.AsBitfield(32) >> 1 ) )) & 1u);
				SetFromBitfield(ref a1.FeetExcluded, 2, v6);
				SetFromBitfield(ref a1.FeetExcluded, 2, (uint)(v6 ^ ( (byte)v6 ^ (byte)( v6 | ( 2u * a2->Actor.bExludeHandMoves.AsBitfield(32) ) )) & 2u));
				a1.MoveActor = a2->Actor;
			}

			v7 = a2->Component;
			if( v7 )
			{
				if( v7.Owner )
				{
					v8 = (uint)(a1.FeetExcluded.AsBitfield(2) ^ ( (byte)a1.FeetExcluded.AsBitfield(2) ^ (byte)( a1.FeetExcluded.AsBitfield(2) | ( v7.Owner.bExludeHandMoves.AsBitfield(32) >> 1 ) )) & 1);
					SetFromBitfield(ref a1.FeetExcluded, 2, v8);
					SetFromBitfield(ref a1.FeetExcluded, 2, (uint)(v8 ^ ( (byte)v8 ^ (byte)( v8 | ( 2 * a2->Component.Owner.bExludeHandMoves.AsBitfield(32) ) )) & 2));
					a1.MoveActor = a2->Component.Owner;
				}
			}

			if( a2->Component )
			{
				v9 = (uint)(a1.FeetExcluded.AsBitfield(2) ^ ( (byte)a1.FeetExcluded.AsBitfield(2) ^ (byte)( a1.FeetExcluded.AsBitfield(2) | ( a2->Component.bUseViewOwnerDepthPriorityGroup.AsBitfield(21) >> 9 ) )) & 1u);
				SetFromBitfield(ref a1.FeetExcluded, 2, v9);
				SetFromBitfield(ref a1.FeetExcluded, 2, (uint)(v9 ^ ( (byte)v9 ^ (byte)( v9 | ( a2->Component.bUseViewOwnerDepthPriorityGroup.AsBitfield(21) >> 7 ) )) & 2));
			}
		}





		public static Vector* Vector( this Rotator rotator, Vector* output )
		{
			* output = rotator.Vector();
			return output;
		}



		public static IUWorld GWorld
		{
			get;
			private set;
		}

		public static void SetWorld( IUWorld w ) => GWorld = w;


		public static void SetFromBitfield(ref bool b, int span, uint bitfield)
		{
			fixed( bool* v = &b )
			{
				for( int i = 0; i < span; i++ )
				{
					v[i] = ( bitfield & ( 1 << i ) ) != 0;
				}
			}
		}
		
		public static uint AsBitfield(ref this bool b, int span)
		{
			fixed( bool* v = & b )
			{
				uint output = 0;
				for( int i = 0; i < span; i++ )
				{
					if( v[ i ] )
						output |= 1u << i;
				}

				return output;
			}
		}
		
		
		
		public static float Eval( this InterpCurveFloat icf, float InVal, ref float Default, int* PtIdx = null )
		{
			ref var Points = ref icf.Points;
			int NumPoints = Points.Num();

			// If no point in curve, return the Default value we passed in.
			if( NumPoints == 0 )
			{
				if( PtIdx != default )
				{
					*PtIdx = -1;
				}
				return Default;
			}

			// If only one point, or before the first point in the curve, return the first points value.
			if( NumPoints < 2 || (InVal <= Points[0].InVal) )
			{
				if( PtIdx != default )
				{
					*PtIdx = 0;
				}
				return Points[0].OutVal;
			}

			// If beyond the last point in the curve, return its value.
			if( InVal >= Points[NumPoints-1].InVal )
			{
				if( PtIdx != default )
				{
					*PtIdx = NumPoints - 1;
				}
				return Points[NumPoints-1].OutVal;
			}

			// Somewhere with curve range - linear search to find value.
			for( INT i=1; i<NumPoints; i++ )
			{	
				if( InVal < Points[i].InVal )
				{
					FLOAT Diff = Points[i].InVal - Points[i-1].InVal;

					if( Diff > 0f && Points[i-1].InterpMode != EInterpCurveMode.CIM_Constant )
					{
						FLOAT Alpha = (InVal - Points[i-1].InVal) / Diff;

						if( PtIdx != default )
						{
							*PtIdx = i - 1;
						}

						if( Points[i-1].InterpMode == EInterpCurveMode.CIM_Linear )
						{
							return Lerp( Points[i-1].OutVal, Points[i].OutVal, Alpha );
						}
						else
						{
							throw new NotImplementedException();
							/*if(icf.InterpMethod == EInterpMethodType.IMT_UseBrokenTangentEval)
							{
								return CubicInterp( Points[i-1].OutVal, Points[i-1].LeaveTangent, Points[i].OutVal, Points[i].ArriveTangent, Alpha );
							}
							else
							{
								return CubicInterp( Points[i-1].OutVal, Points[i-1].LeaveTangent * Diff, Points[i].OutVal, Points[i].ArriveTangent * Diff, Alpha );
							}*/
						}
					}
					else
					{
						if( PtIdx != default )
						{
							*PtIdx = i - 1;
						}

						return Points[i-1].OutVal;
					}
				}
			}

			// Shouldn't really reach here.
			if( PtIdx != default )
			{
				*PtIdx = NumPoints - 1;
			}

			return Points[NumPoints-1].OutVal;
		}
		
		
		
		public static int E_GetHeadingAngle(_E_struct_FVector *a1)
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



		public static void CallUFunction<T>(System.Func<T> func, Object target, int idk, T* parameters, int idk2) where T : unmanaged
		{
			*parameters = func();
		}
		
		public static void CallUFunction(System.Action func, object target, int idk, int parameters, int idk2)
		{
			func();
		}
		
		public static void CallUFunction( Action<bool?> func, object target, int idk, int* parameters, int idk2 )
		{
			func.Invoke(*parameters != 0);
		}



		public static _QWORD __PAIR64__( int a, int b ) => new _QWORD( a, b );
		public static _QWORD __PAIR64__( uint a, uint b ) => new _QWORD( (int)a, (int)b );
		public static Rotator FRotator( int i ) => new Rotator( i, i, i );
		public static Rotator FRotator( int i, int i2, int i3 ) => new Rotator( i, i2, i3 );
		public static Vector FVector( float f ) => new Vector( f, f, f );
		public static Vector FVector( float f, float f2, float f3 ) => new Vector( f, f2, f3 );

		public static float Size2D( this FVector v ) => MathF.Sqrt( v.X * v.X + v.Y * v.Y );

		public static Pawn GetAPawn( this Actor a ) => a as Pawn;
		
		
		// MAGIC NUMBERS
		public const FLOAT MAXSTEPSIDEZ = 0.08f;	// maximum z value for step side normal (if more, then treat as unclimbable)

// range of acceptable distances for pawn cylinder to float above floor when walking
		public const FLOAT MINFLOORDIST = 1.9f;
		public const FLOAT MAXFLOORDIST = 2.4f;
		public const FLOAT CYLINDERREPULSION = 2.2f;	// amount taken off trace dist for cylinders

		public const FLOAT LEDGECHECKTHRESHOLD = 4f;	// used in determining if pawn is going off ledge
		public const FLOAT MAXSTEPHEIGHTFUDGE = 2f;	
		public const FLOAT SLOWVELOCITYSQUARED = 100f;// velocity threshold (used for deciding to stop)
		public const FLOAT SHORTTRACETESTDIST = 100f;
		public const FLOAT LADDEROUTPUSH = 3f;
		public const FLOAT FASTWALKSPEED = 100f;		// ~4.5 MPH
		public const FLOAT SWIMBOBSPEED = -80f;
		public const FLOAT MINSTEPSIZESQUARED = 144f;



		
		public static unsafe bool MoveActor( this IUWorld w, Actor Actor, ref Object.Vector Delta, ref Object.Rotator NewRotation, uint MoveFlags, ref Source.DecFn.CheckResult Hit )
		{
			return w.MoveActor( Actor, Delta, NewRotation, MoveFlags, ref Hit );
		}
		
		public static Matrix FScaleRotationTranslationMatrix(in FVector Scale, in FRotator Rot, in FVector Origin)
		{
			FLOAT	SR	= GMath.SinTab(Rot.Roll);
			FLOAT	SP	= GMath.SinTab(Rot.Pitch);
			FLOAT	SY	= GMath.SinTab(Rot.Yaw);
			FLOAT	CR	= GMath.CosTab(Rot.Roll);
			FLOAT	CP	= GMath.CosTab(Rot.Pitch);
			FLOAT	CY	= GMath.CosTab(Rot.Yaw);
			Matrix M = default;

			M[0,0]	= (CP * CY) * Scale.X;
			M[0,1]	= (CP * SY) * Scale.X;
			M[0,2]	= (SP) * Scale.X;
			M[0,3]	= 0f;

			M[1,0]	= (SR * SP * CY - CR * SY) * Scale.Y;
			M[1,1]	= (SR * SP * SY + CR * CY) * Scale.Y;
			M[1,2]	= (- SR * CP) * Scale.Y;
			M[1,3]	= 0f;

			M[2,0]	= ( -( CR * SP * CY + SR * SY ) ) * Scale.Z;
			M[2,1]	= (CY * SR - CR * SP * SY) * Scale.Z;
			M[2,2]	= (CR * CP) * Scale.Z;
			M[2,3]	= 0f;

			M[3,0]	= Origin.X;
			M[3,1]	= Origin.Y;
			M[3,2]	= Origin.Z;
			M[3,3]	= 1f;
			return M;
		}



		/*public static void setPhysics( this Actor actor, byte NewPhysics, Actor NewFloor = null, FVector? NewFloorV = null )
		{
			actor.setPhysics( NewPhysics, NewFloor, NewFloorV ?? FVector( 0, 0, 1 ) );
		}*/



		[StructLayout( LayoutKind.Sequential, Size = 8)]
		public struct _QWORD
		{
			int b, a;
			public _QWORD( int a, int b )
			{
				this.b = b;
				this.a = a;
			}
		}



		public struct VectorRegister
		{
			public fixed FLOAT V[4];
		};



		public static VectorRegister VectorLoadAligned( in Object.Plane Ptr )
		{
			var cpy = Ptr;
			return *(VectorRegister*) & cpy;
		}



		public static VectorRegister MakeVectorRegister( FLOAT X, FLOAT Y, FLOAT Z, FLOAT W )
		{
			VectorRegister Vec = new VectorRegister();
			Vec.V[ 0 ] = X;
			Vec.V[ 1 ] = Y;
			Vec.V[ 2 ] = Z;
			Vec.V[ 3 ] = W;
			return Vec;
		}
		public static VectorRegister VectorLoadFloat3( Vector Ptr ) => MakeVectorRegister( Ptr.X, Ptr.Y, Ptr.Z, 0f );
		public static VectorRegister VectorSetFloat3( float X, float Y, float Z ) => MakeVectorRegister( X, Y, Z, 0f );
		public static VectorRegister VectorReplicate( in VectorRegister Vec, int ElementIndex ) => MakeVectorRegister( ( Vec ).V[ ElementIndex ], ( Vec ).V[ ElementIndex ], ( Vec ).V[ ElementIndex ], ( Vec ).V[ ElementIndex ] );
		public static VectorRegister VectorMultiply( in VectorRegister Vec1, in VectorRegister Vec2 )
		{
			VectorRegister Vec;
			Vec.V[0] = Vec1.V[0] * Vec2.V[0];
			Vec.V[1] = Vec1.V[1] * Vec2.V[1];
			Vec.V[2] = Vec1.V[2] * Vec2.V[2];
			Vec.V[3] = Vec1.V[3] * Vec2.V[3];
			return Vec;
		}
		
		public static VectorRegister VectorMultiplyAdd( in VectorRegister Vec1, in VectorRegister Vec2, in VectorRegister Vec3 )
		{
			VectorRegister Vec;
			Vec.V[0] = Vec1.V[0] * Vec2.V[0] + Vec3.V[0];
			Vec.V[1] = Vec1.V[1] * Vec2.V[1] + Vec3.V[1];
			Vec.V[2] = Vec1.V[2] * Vec2.V[2] + Vec3.V[2];
			Vec.V[3] = Vec1.V[3] * Vec2.V[3] + Vec3.V[3];
			return Vec;
		}
		
		public static VectorRegister VectorAdd( in VectorRegister Vec1, in VectorRegister Vec2 )
		{
			VectorRegister Vec;
			Vec.V[0] = Vec1.V[0] + Vec2.V[0];
			Vec.V[1] = Vec1.V[1] + Vec2.V[1];
			Vec.V[2] = Vec1.V[2] + Vec2.V[2];
			Vec.V[3] = Vec1.V[3] + Vec2.V[3];
			return Vec;
		}
		
		public static VectorRegister VectorMin( in VectorRegister Vec1, in VectorRegister Vec2 )
		{
			VectorRegister Vec;
			Vec.V[0] = Min(Vec1.V[0], Vec2.V[0]);
			Vec.V[1] = Min(Vec1.V[1], Vec2.V[1]);
			Vec.V[2] = Min(Vec1.V[2], Vec2.V[2]);
			Vec.V[3] = Min(Vec1.V[3], Vec2.V[3]);
			return Vec;
		}
		
		public static VectorRegister VectorMax( in VectorRegister Vec1, in VectorRegister Vec2 )
		{
			VectorRegister Vec;
			Vec.V[0] = Max(Vec1.V[0], Vec2.V[0]);
			Vec.V[1] = Max(Vec1.V[1], Vec2.V[1]);
			Vec.V[2] = Max(Vec1.V[2], Vec2.V[2]);
			Vec.V[3] = Max(Vec1.V[3], Vec2.V[3]);
			return Vec;
		}



		public static void VectorStoreFloat3( in VectorRegister Vec, ref Vector Ptr )
		{
			Ptr.X = Vec.V[ 0 ];
			Ptr.Y = Vec.V[ 1 ];
			Ptr.Z = Vec.V[ 2 ];
		}



		public struct CheckResult// : public FIteratorActorList
		{
			static internalCheckResult[] _buffer = new internalCheckResult[4];
			static int _allocated = 0;
			static List<IntPtr> _pinnedResults = new ();



			struct internalCheckResult // : public FIteratorActorList
			{
				public unsafe CheckResult* Next;
				public Actor Actor;
				public Object.Vector Location;
				public Object.Vector Normal;
				public float Time;
				public int Item;
				public MaterialInterface Material;
				public PhysicalMaterial PhysMaterial;
				public PrimitiveComponent Component;
				public name BoneName;
				public Level Level;
				public int LevelIndex;
				public bool bStartPenetrating;
			}
			
			int _indexInBuffer;



			public unsafe CheckResult* Next
			{
				get => GetInternalRep.Next;
				set
				{
					if(value != default)
						throw new Exception();
					GetInternalRep.Next = default;
				}
			}
			public ref Actor Actor => ref GetInternalRep.Actor;
			/// <summary>
			/// Basically the position to take to get out of this collision hit
			/// </summary>
			public ref Object.Vector Location => ref GetInternalRep.Location;
			public ref Object.Vector Normal => ref GetInternalRep.Normal;
			public ref float Time => ref GetInternalRep.Time;
			public ref int Item => ref GetInternalRep.Item;
			public ref MaterialInterface Material => ref GetInternalRep.Material;
			public ref PhysicalMaterial PhysMaterial => ref GetInternalRep.PhysMaterial;
			public ref PrimitiveComponent Component => ref GetInternalRep.Component;
			public ref name BoneName => ref GetInternalRep.BoneName;
			public ref Level Level => ref GetInternalRep.Level;
			public ref int LevelIndex => ref GetInternalRep.LevelIndex;
			public ref bool bStartPenetrating => ref GetInternalRep.bStartPenetrating;
			


			ref internalCheckResult GetInternalRep
			{
				get
				{
					if( _indexInBuffer == 0 )
					{
						_indexInBuffer = Alloc();
						Debug.Assert(_indexInBuffer != 0, "index should not be zero");
					}

					return ref _buffer[ _indexInBuffer ];
				}
			}


			/// <summary>
			/// Mark this instance as shared, any copy of this now points to the same data as this one's data 
			/// </summary>
			public void ForceFixAndAllocate()
			{
				var r = GetInternalRep;
			}
			

			public static void Overwrite( ref CheckResult dest, in CheckResult source )
			{
				dest.GetInternalRep = source.GetInternalRep;
			}




			static int Alloc()
			{
				_allocated += 1;
				if( _allocated >= _buffer.Length )
				{
					if(_allocated > 4096)
						UnityEngine.Debug.LogError("Clear() should be called every frame");
					var newAllocated = new internalCheckResult[ _allocated * _allocated ];
					Array.Copy(_buffer, newAllocated, _buffer.Length);
					_buffer = newAllocated;
				}

				return _allocated;
			}



			public static void Clear()
			{
				_allocated = 0; // start at one  
				Array.Clear(_buffer, 0, _buffer.Length);
				foreach( IntPtr ptr in _pinnedResults )
				{
					Marshal.FreeCoTaskMem(ptr);
				}
				_pinnedResults.Clear();
			}



			public void AssignNext( CheckResult data )
			{
				int len = Marshal.SizeOf(typeof(CheckResult));
				IntPtr mem = Marshal.AllocCoTaskMem(len);
				_pinnedResults.Add(mem);
				var newPtr = (CheckResult*) mem;
				* newPtr = data;
				GetInternalRep.Next = newPtr;
			}





			public unsafe CheckResult( FLOAT InTime ) : this( InTime, null )
	        {
	        }



	        public unsafe CheckResult( FLOAT InTime, CheckResult* InNext )
		        /*:	FIteratorActorList( InNext, NULL )
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
		        , bStartPenetrating( FALSE )*/
	        {
		        this = default;
		        Time = InTime;
		        Next = InNext;
	        }



	        public CheckResult* GetNext() => Next;
        }



		public struct FMemMark
		{
			public FMemMark( int mem )
			{
			}



			public void Pop()
			{
			}
		}



		[System.Flags]
		public enum ETraceFlags
		{
			// Bitflags.
			TRACE_Pawns					= 0x00001, // Check collision with pawns.
			TRACE_Movers				= 0x00002, // Check collision with movers.
			TRACE_Level					= 0x00004, // Check collision with BSP level geometry.
			TRACE_Volumes				= 0x00008, // Check collision with soft volume boundaries.
			TRACE_Others				= 0x00010, // Check collision with all other kinds of actors.
			TRACE_OnlyProjActor			= 0x00020, // Check collision with other actors only if they are projectile targets
			TRACE_Blocking				= 0x00040, // Check collision with other actors only if they block the check actor
			TRACE_LevelGeometry			= 0x00080, // Check collision with other actors which are static level geometry
			TRACE_ShadowCast			= 0x00100, // Check collision with shadow casting actors
			TRACE_StopAtAnyHit			= 0x00200, // Stop when find any collision (for visibility checks)
			TRACE_SingleResult			= 0x00400, // Stop when find guaranteed first nearest collision (for SingleLineCheck)
			TRACE_Material				= 0x00800, // Request that Hit.Material return the material the trace hit.
			TRACE_Visible				= 0x01000,
			TRACE_Terrain				= 0x02000, // Check collision with terrain
			TRACE_Tesselation			= 0x04000, // Check collision against highest tessellation level (not valid for box checks)  (no longer used)
			TRACE_PhysicsVolumes		= 0x08000, // Check collision with physics volumes
			TRACE_TerrainIgnoreHoles	= 0x10000, // Ignore terrain holes when checking collision
			TRACE_ComplexCollision		= 0x20000, // Ignore simple collision on static meshes and always do per poly
			TRACE_AllComponents			= 0x40000, // Don't discard collision results of actors that have already been tagged.  Currently adhered to only by ActorOverlapCheck.

			// Combinations.
			TRACE_Hash					= TRACE_Pawns	|	TRACE_Movers |	TRACE_Volumes	|	TRACE_Others			|	TRACE_Terrain	|	TRACE_LevelGeometry,
			TRACE_Actors				= TRACE_Pawns	|	TRACE_Movers |	TRACE_Others	|	TRACE_LevelGeometry		|	TRACE_Terrain,
			TRACE_World					= TRACE_Level	|	TRACE_Movers |	TRACE_Terrain	|	TRACE_LevelGeometry,
			TRACE_AllColliding			= TRACE_Level	|	TRACE_Actors |	TRACE_Volumes,
			TRACE_ProjTargets			= TRACE_AllColliding	| TRACE_OnlyProjActor,
			TRACE_AllBlocking			= TRACE_Blocking		| TRACE_AllColliding,
		};
		
		[System.Flags]
		public enum EMoveFlags
		{
			// Bitflags.
			MOVE_IgnoreBases		= 0x00001, // ignore collisions with things the Actor is based on
			MOVE_NoFail				= 0x00002, // ignore conditions that would normally cause MoveActor() to abort (such as encroachment)
			MOVE_TraceHitMaterial	= 0x00004, // figure out material was hit for any collisions
		};
	}
}