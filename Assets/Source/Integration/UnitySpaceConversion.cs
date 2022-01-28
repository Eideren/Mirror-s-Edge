namespace MEdge.Core
{
	using V3 = UnityEngine.Vector3;
	using UnityQuat = UnityEngine.Quaternion;
	using Math = System.Math;
	using static Source.DecFn;
	
	public static class V3Extension
	{
		/// <summary> This vector be rotated and scaled to fit in the proper metric system, I.E.: divided by 100 since 1 unity unit = 100 unreal unit</summary>
		public static V3 ToUnityPos(this Object.Vector v) => new V3( v.Y, v.Z, v.X ) * 0.01f;
		/// <summary> This vector should only be rotated to unreal space, not scaled to fit in the proper metric system </summary>
		public static V3 ToUnityDir(this Object.Vector v) => new V3( v.Y, v.Z, v.X );
		/// <summary> This vector be rotated and scaled to fit in the proper metric system, I.E.: multiplied by 100 since 1 unity unit = 100 unreal unit</summary>
		public static Object.Vector ToUnrealPos(this V3 v) => new Object.Vector( v.z, v.x, v.y ) * 100f;
		/// <summary> This vector should only be rotated to unreal space, not scaled to fit in the proper metric system </summary>
		public static Object.Vector ToUnrealDir(this V3 v) => new Object.Vector( v.z, v.x, v.y );


		// Arbitrary, not compared against source
		public static bool IsNearlyZero( this V3 v ) => v.sqrMagnitude <= 0.0001f;
		public static bool IsNearlyZero( this Object.Vector2D v ) => v.X * v.X + v.Y * v.Y <= 0.0001f;
	}



	public partial class Object
	{
		public partial struct Quat
		{
			public static explicit operator UnityQuat( Quat v )
			{
				return new UnityQuat
				{
					x = v.Y,
					y = v.Z,
					z = v.X,
					w = v.W,
				};
			}
			
			public static explicit operator Quat( UnityQuat v )
			{
				return new Quat
				{
					X = v.z,
					Y = v.x,
					Z = v.y,
					W = v.w,
				};
			}
			
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
			
		}



		public partial struct Vector
		{
			public bool IsZero() => this == default;
			public bool IsNearlyZero(float Tolerance=KINDA_SMALL_NUMBER)
			{
				return Abs(X)<Tolerance
				       &&	Abs(Y)<Tolerance
				       &&	Abs(Z)<Tolerance;
			}
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



			public static explicit operator UnityQuat( Rotator v )
			{
				const double convScaling = 1d / (ushort.MaxValue) * (Math.PI * 2d);
				RotationYawPitchRoll( -v.Pitch * convScaling, v.Yaw * convScaling, -v.Roll * convScaling, out UnityQuat q );
				return q;
			}
			
			public static explicit operator Rotator( UnityQuat v )
			{
				const double convScaling = 1d / (Math.PI * 2d) * (ushort.MaxValue);
				RotationYawPitchRoll( ref v, out var pitch, out var yaw, out var roll );
				return new Rotator( -(int)Math.Round(pitch * convScaling), (int)Math.Round(yaw * convScaling), -(int)Math.Round(roll * convScaling) );
			}



			public static unsafe explicit operator Quat( Rotator r )
			{
				Quat q = default;
				return *r.Quaternion( &q );
			}



			static void RotationYawPitchRoll(ref UnityEngine.Quaternion rotation, out double pitch, out double yaw, out double roll)
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
			static void RotationYawPitchRoll(double pitch, double yaw, double roll, out UnityEngine.Quaternion result)
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

				var c = this;
				v2 = FRotationMatrix(&v4, &c);
				*out_data = new Quat(v2);
				return out_data;
			}
			
			public unsafe Quat Quaternion()
			{
				Matrix *v2; // eax
				Matrix v4; // [esp+10h] [ebp-40h] BYREF

				var c = this;
				v2 = FRotationMatrix(&v4, &c);
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