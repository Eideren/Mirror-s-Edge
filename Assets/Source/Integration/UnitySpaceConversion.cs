namespace MEdge.Core
{
	using System;
	using UnityV = UnityEngine.Vector3;
	using UnityQ = UnityEngine.Quaternion;
	using UnrealV = Object.Vector;
	using UnrealQ = Object.Quat;
	using Math = System.Math;
	using static Source.DecFn;
	
	public static class V3Extension
	{
		static Object.Matrix UnrealToUnity = new Object.Matrix
		{
			PlaneX = new(0f, 0f, 1f, 0f), 
			PlaneY = new(1f, 0f, 0f, 0f), 
			PlaneZ = new(0f, 1f, 0f, 0f), 
			PlaneW = new(0f, 0f, 0f, 1f)
		}, UnityToUnreal = UnrealToUnity.Inverse();
		
		
		
		public static UnrealV Inplace(this UnityV v, float mult) => new UnrealV( v.x, v.y, v.z ) * mult;
		public static UnrealQ Inplace(this UnityQ v) => new UnrealQ( v.x, v.y, v.z, v.w );
		
		
		/// <summary> This vector be rotated and scaled to fit in the proper metric system, I.E.: divided by 100 since 1 unity unit = 100 unreal unit</summary>
		public static UnityV ToUnityPos(this UnrealV v) => v.ToUnityDir() / 100f;
		/// <summary> This vector be rotated and scaled to fit in the proper metric system, I.E.: multiplied by 100 since 1 unity unit = 100 unreal unit</summary>
		public static UnrealV ToUnrealPos(this UnityV v) => v.ToUnrealDir() * 100f;



		/// <summary> This vector should only be rotated to unreal space, not scaled to fit in the proper metric system </summary>
		public static UnityV ToUnityDir(this UnrealV v)
		{
			v = UnrealToUnity.TransformNormal( v );
			return new UnityV( v.X, v.Y, v.Z );
		}



		/// <summary> This vector should only be rotated to unreal space, not scaled to fit in the proper metric system </summary>
		public static UnrealV ToUnrealDir(this UnityV v) => UnityToUnreal.TransformNormal( v.Inplace(1f) );



		public static UnrealV ToUnrealAnim(this UnityV v) => new UnrealV( -v.x, -v.y, v.z ) * 100f;
		public static UnityV ToUnityAnim(this UnrealV v) => new UnityV( -v.X, -v.Y, v.Z ) / 100f;
		
		public static UnrealQ ToUnrealAnim( this UnityQ q )
		{
			var m = Object.FQuatRotationTranslationMatrix( q.Inplace(), default );
			m.XPlane.Z *= -1f;
			m.YPlane.Z *= -1f;
			m.ZPlane.X *= -1f;
			m.ZPlane.Y *= -1f;
			return new UnrealQ(m);
		}
		
		public static unsafe UnityQ ToUnityAnim( this UnrealQ v )
		{
			var m = Object.FQuatRotationTranslationMatrix( v, default );
			m.XPlane.Z *= -1f;
			m.YPlane.Z *= -1f;
			m.ZPlane.X *= -1f;
			m.ZPlane.Y *= -1f;
			var q = new UnrealQ(m);
			return *(UnityQ*)&q;
		}



		public static UnityQ ToUnityQuat( this Object.Rotator v )
		{
			const double convScaling = 1d / (ushort.MaxValue) * (Math.PI * 2d);
			Object.Rotator.RotationYawPitchRoll( -v.Pitch * convScaling, v.Yaw * convScaling, -v.Roll * convScaling, out UnityQ q );
			return q;
		}
			
		public static Object.Rotator ToUnrealRot( this UnityQ v )
		{
			const double convScaling = 1d / (Math.PI * 2d) * (ushort.MaxValue);
			Object.Rotator.RotationYawPitchRoll( ref v, out var pitch, out var yaw, out var roll );
			return new Object.Rotator( -(int)Math.Round(pitch * convScaling), (int)Math.Round(yaw * convScaling), -(int)Math.Round(roll * convScaling) );
		}
		
		
		
		
		public static UnityQ ToUnity( this UnrealQ v )
		{
			var quatAsMat = Object.FQuatRotationTranslationMatrix( v, default );
			var transformed = new Object.Matrix
			{
				XPlane = new()
				{
					X = -quatAsMat.XPlane.Y,
					Y = -quatAsMat.XPlane.Z,
					Z = -quatAsMat.XPlane.X,
				},
				YPlane = new()
				{
					X = -quatAsMat.YPlane.Y,
					Y = -quatAsMat.YPlane.Z,
					Z = -quatAsMat.YPlane.X,
				},
				ZPlane = new()
				{
					X = +quatAsMat.ZPlane.Y,
					Y = +quatAsMat.ZPlane.Z,
					Z = +quatAsMat.ZPlane.X,
				},
				WPlane = new()
				{
					W = 1f,
				},
			};
			var q = new UnrealQ( transformed );
			return new UnityQ
			{
				x = q.X,
				y = q.Y,
				z = q.Z,
				w = q.W,
			};
		}
		
		/// <summary>
		/// This hasn't been properly tested
		/// </summary>
		public static UnrealQ ToUnreal( this UnityQ v )
		{
			return v.ToUnrealAnim();
			/*return new UnrealQ
			{
				X = v.z,
				Y = v.x,
				Z = v.y,
				W = v.w,
			};*/
		}
		
		
		


		// Arbitrary, not compared against source
		public static bool IsNearlyZero( this UnityV v ) => v.sqrMagnitude <= 0.0001f;
		public static bool IsNearlyZero( this Object.Vector2D v ) => v.X * v.X + v.Y * v.Y <= 0.0001f;
	}



	public partial class Object
	{
		public partial struct Quat
		{
			public Quat(float X, float Y, float Z, float W)
			{
				this.X = X;
				this.Y = Y;
				this.Z = Z;
				this.W = W;
			}
			
			public unsafe Quat( in Matrix M )
			{
				//const MeReal *const t = (MeReal *) tm;
				float	s;

				// Check diagonal (trace)
				float tr = M.M[0,0] + M.M[1,1] + M.M[2,2];

				if (tr > 0.0f) 
				{
					float InvS = appInvSqrt(tr + 1f);
					this.W = 0.5f * (1f / InvS);
					s = 0.5f * InvS;

					this.X = (M.M[1,2] - M.M[2,1]) * s;
					this.Y = (M.M[2,0] - M.M[0,2]) * s;
					this.Z = (M.M[0,1] - M.M[1,0]) * s;
				} 
				else 
				{
					// diagonal is negative
					int i = 0;

					if (M.M[1,1] > M.M[0,0])
						i = 1;

					if (M.M[2,2] > M.M[i,i])
						i = 2;

					int* nxt = stackalloc int[]{ 1, 2, 0 };
					int j = nxt[i];
					int k = nxt[j];

					s = M.M[i,i] - M.M[j,j] - M.M[k,k] + 1.0f;

					float InvS = appInvSqrt(s);

					float* qt = stackalloc float[4];
					qt[i] = 0.5f * (1f / InvS);

					s = 0.5f * InvS;

					qt[3] = (M.M[j,k] - M.M[k,j]) * s;
					qt[j] = (M.M[i,j] + M.M[j,i]) * s;
					qt[k] = (M.M[i,k] + M.M[k,i]) * s;

					this.X = qt[0];
					this.Y = qt[1];
					this.Z = qt[2];
					this.W = qt[3];
				}
			}
			
			public Quat( Vector Axis, float Angle )
			{
				float half_a = 0.5f * Angle;
				float s = appSin(half_a);
				float c = appCos(half_a);

				X = s * Axis.X;
				Y = s * Axis.Y;
				Z = s * Axis.Z;
				W = c;
			}



			public unsafe float this[ int index ]
			{
				get
				{
					if( index > 3 || index < 0 )
						throw new Exception();
					var cpy = this;
					return ( (float*) &cpy )[ index ];
				}
				set
				{
					if( index > 3 || index < 0 )
						throw new Exception();
					var cpy = this;
					( (float*) & cpy )[ index ] = value;
					this = cpy;
				}
			}



			public static Quat Identity => new Quat( 0f, 0f, 0f, 1f );



			public unsafe Quat( Matrix* M )
			{
				//const MeReal *const t = (MeReal *) tm;
				float	s;

				// Check diagonal (trace)
				float tr = M->M[0, 0] + M->M[1, 1] + M->M[2, 2];

				if (tr > 0.0f) 
				{
					float InvS = appInvSqrt(tr + 1f);
					this.W = 0.5f * (1f / InvS);
					s = 0.5f * InvS;

					this.X = (M->M[1, 2] - M->M[2, 1]) * s;
					this.Y = (M->M[2, 0] - M->M[0, 2]) * s;
					this.Z = (M->M[0, 1] - M->M[1, 0]) * s;
				} 
				else 
				{
					// diagonal is negative
					int i = 0;

					if (M->M[1, 1] > M->M[0, 0])
						i = 1;

					if (M->M[2, 2] > M->M[i, i])
						i = 2;

					int* nxt = stackalloc int[3]{ 1, 2, 0 };
					int j = nxt[i];
					int k = nxt[j];

					s = M->M[i, i] - M->M[j, j] - M->M[k, k] + 1.0f;

					float InvS = appInvSqrt(s);

					float* qt = stackalloc float[4];
					qt[i] = 0.5f * (1f / InvS);

					s = 0.5f * InvS;

					qt[3] = (M->M[j, k] - M->M[k, j]) * s;
					qt[j] = (M->M[i, j] + M->M[j, i]) * s;
					qt[k] = (M->M[i, k] + M->M[k, i]) * s;

					this.X = qt[0];
					this.Y = qt[1];
					this.Z = qt[2];
					this.W = qt[3];
				}
			}
			
			public void ToAxisAndAngle(ref Vector Axis, ref float Angle)
			{
				Angle = 2f * appAcos(W);

				float S = appSqrt(1f-(W*W));
				if (S < 0.0001f) 
				{ 
					Axis.X = 1f;
					Axis.Y = 0f;
					Axis.Z = 0f;
				} 
				else 
				{
					Axis.X = X / S;
					Axis.Y = Y / S;
					Axis.Z = Z / S;
				}
			}



			public static Quat operator *( Quat A, Quat Q )
			{
				float T0 = (A.Z - A.Y) * (Q.Y - Q.Z);
				float T1 = (A.W + A.X) * (Q.W + Q.X);
				float T2 = (A.W - A.X) * (Q.Y + Q.Z);
				float T3 = (A.Y + A.Z) * (Q.W - Q.X);
				float T4 = (A.Z - A.X) * (Q.X - Q.Y);
				float T5 = (A.Z + A.X) * (Q.X + Q.Y);
				float T6 = (A.W + A.Y) * (Q.W - Q.Z);
				float T7 = (A.W - A.Y) * (Q.W + Q.Z);
				float T8 = T5 + T6 + T7;
				float T9 = 0.5f * (T4 + T8);
				
				A.X = T1 + T9 - T8;
				A.Y = T2 + T9 - T7;
				A.Z = T3 + T9 - T6;
				A.W = T0 + T9 - T5;
				return A;
			}
        
			public static Quat operator -( in Quat Q )
			{
				return new( -Q.X, -Q.Y, -Q.Z, Q.W );
			}
			
			public static Quat operator *( in Quat Q, float Scale )
			{
				return new ( Scale*Q.X, Scale*Q.Y, Scale*Q.Z, Scale*Q.W);			
			}
	
			public static float operator |( in Quat A, in Quat Q )
			{
				return A.X*Q.X + A.Y*Q.Y + A.Z*Q.Z + A.W*Q.W;
			}

			// Binary operators.
			public static Quat operator+( in Quat A, in Quat Q )
			{		
				return new( A.X + Q.X, A.Y + Q.Y, A.Z + Q.Z, A.W + Q.W );
			}

			public static Quat operator-( in Quat A, in Quat Q )
			{		
				return new( A.X - Q.X, A.Y - Q.Y, A.Z - Q.Z, A.W - Q.W );
			}
				
			public void Normalize()
			{
				float SquareSum = X*X + Y*Y + Z*Z + W*W;
				// Make sure we have a non null SquareSum. It shouldn't happen with a quaternion, but better be safe.
				check(SquareSum > SMALL_NUMBER);
				float Scale = appInvSqrt(SquareSum);
				X *= Scale;
				Y *= Scale;
				Z *= Scale;
				W *= Scale;
			}



			public static bool operator !=( Quat a, Quat b ) => ( a == b ) == false;



			public static bool operator ==( Quat a, Quat b )
			{
				return a.X == b.X &&
				       a.Y == b.Y &&
				       a.Z == b.Z &&
				       a.W == b.W;
			}
		}



		public partial struct Vector
		{
			public Rotator Rotation()
			{
				const uint MAXWORD = 0xffffU;
				Rotator R;

				// Find yaw.
				R.Yaw = appRound(appAtan2(Y,X) * (float)MAXWORD / (2f*PI));

				// Find pitch.
				R.Pitch = appRound(appAtan2(Z,appSqrt(X*X+Y*Y)) * (float)MAXWORD / (2f*PI));

				// Find roll.
				R.Roll = 0;

				return R;
			}



			public void Deconstruct( out float X, out float Y, out float Z )
			{
				X = this.X;
				Y = this.Y;
				Z = this.Z;
			}
			
			
			public static implicit operator Vector( (float x, float y, float z) tuple )
			{
				return new Vector( tuple.x, tuple.y, tuple.z );
			}
		}



		[System.Serializable]
		public partial struct Rotator
		{
			public bool IsZero() => this.Pitch == 0 && this.Yaw == 0 && this.Roll == 0;



			public static bool operator ==(Rotator a, Rotator b)
			{
				return a.Pitch == b.Pitch && a.Yaw == b.Yaw && a.Roll == b.Roll;
			}
			
			public static bool operator !=(Rotator a, Rotator b) => ( a == b ) == false;



			public static unsafe explicit operator Quat( Rotator r )
			{
				Quat q = default;
				return *r.Quaternion( &q );
			}



			public static void RotationYawPitchRoll(ref UnityEngine.Quaternion rotation, out double pitch, out double yaw, out double roll)
			{
				var xx = (double)rotation.x * rotation.x;
				var yy = (double)rotation.y * rotation.y;
				var zz = (double)rotation.z * rotation.z;
				var xy = (double)rotation.x * rotation.y;
				var zw = (double)rotation.z * rotation.w;
				var zx = (double)rotation.z * rotation.x;
				var yw = (double)rotation.y * rotation.w;
				var yz = (double)rotation.y * rotation.z;
				var xw = (double)rotation.x * rotation.w;

				var r = 2d * ( xw - yz );
				// This really shouldn't be here but asin tends to create nans with specific rotation, like for rotator{ Pitch=16383, Yaw=0, Roll=0 }
				r = r > 1d ? 1d : r < - 1d ? - 1d : r;
				pitch = Math.Asin(r);
				if (Math.Cos(pitch) > 0f)
				{
					roll = Math.Atan2(2d * (xy + zw), 1d - (2d * (zz + xx)));
					yaw = Math.Atan2(2d * (zx + yw), 1d - (2d * (yy + xx)));
				}
				else
				{
					roll = Math.Atan2(-2d * (xy - zw), 1d - (2d * (yy + zz)));
					yaw = 0f;
				}
			}
			public static void RotationYawPitchRoll(double pitch, double yaw, double roll, out UnityEngine.Quaternion result)
			{
				var halfRoll = roll * 0.5d;
				var halfPitch = pitch * 0.5d;
				var halfYaw = yaw * 0.5d;
	            
				var sinRoll = Math.Sin(halfRoll);
				var cosRoll = Math.Cos(halfRoll);
				var sinPitch = Math.Sin(halfPitch);
				var cosPitch = Math.Cos(halfPitch);
				var sinYaw = Math.Sin(halfYaw);
				var cosYaw = Math.Cos(halfYaw);

				var cosYawPitch = cosYaw * cosPitch;
				var sinYawPitch = sinYaw * sinPitch;

				result.x = (float)((cosYaw * sinPitch * cosRoll) + (sinYaw * cosPitch * sinRoll));
				result.y = (float)((sinYaw * cosPitch * cosRoll) - (cosYaw * sinPitch * sinRoll));
				result.z = (float)((cosYawPitch * sinRoll) - (sinYawPitch * cosRoll));
				result.w = (float)((cosYawPitch * cosRoll) + (sinYawPitch * sinRoll));
			}



			public Vector Vector() => GetAxis( FRotationMatrix( this ), 0 );
			
			public unsafe Quat * Quaternion(Quat *out_data)
			{
				Matrix *v2; // eax
				Matrix v4; // [esp+10h] [ebp-40h] BYREF

				v2 = FRotationMatrix(&v4, this);
				*out_data = new Quat(v2);
				return out_data;
			}
			
			public unsafe Quat Quaternion()
			{
				Matrix *v2; // eax
				Matrix v4; // [esp+10h] [ebp-40h] BYREF

				v2 = FRotationMatrix(&v4, this);
				return new Quat(v2);
			}
			

			public Rotator Denormalize()
			{
				Rotator Rot = this;
				Rot.Pitch	= Rot.Pitch & 0xFFFF;
				Rot.Yaw		= Rot.Yaw & 0xFFFF;
				Rot.Roll	= Rot.Roll & 0xFFFF;
				return Rot;
			}
		}
	}
}