namespace MEdge.Core
{
	using V3 = UnityEngine.Vector3;
	using UnityQuat = UnityEngine.Quaternion;
	using Math = System.Math;
	
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
				unsafe
				{
					return * (UnityQuat*)&v;
				}
			}
			
			public static explicit operator Quat( UnityQuat v )
			{
				unsafe
				{
					return * (Quat*)&v;
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
		}
	}
}