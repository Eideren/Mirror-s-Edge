namespace MEdge.Core
{
	using V3 = UnityEngine.Vector3;
	using Qu = UnityEngine.Quaternion;
	
	public static class V3Extension
	{
		/// <summary> This vector be rotated and scaled to fit in the proper metric system, I.E.: divided by 100 since 1 unity unit = 100 unreal unit</summary>
		public static V3 ToUnityPos(this Object.Vector v) => new V3( v.Y, v.Z, v.X ) * 0.01f;
		/// <summary> This vector should only be rotated to unreal space, not scaled to fit in the proper metric system </summary>
		public static V3 ToUnityDir(this Object.Vector v) => new V3( v.Y, v.Z, v.X );
		/// <summary> This vector be rotated and scaled to fit in the proper metric system, I.E.: multiplied by 100 since 1 unity unit = 100 unreal unit</summary>
		public static Object.Vector ToUnrealPos(this V3 v) => new Object.Vector( v.y, v.z, v.x ) * 100f;
		/// <summary> This vector should only be rotated to unreal space, not scaled to fit in the proper metric system </summary>
		public static Object.Vector ToUnrealDir(this V3 v) => new Object.Vector( v.y, v.z, v.x );
	}



	public partial class Object
	{
		public partial struct Rotator
		{
			public static explicit operator Qu( Rotator v )
			{
				return Qu.Euler( new V3( -v.Pitch, v.Yaw, -v.Roll/*maybe swap Z/Y?*/ ) / ushort.MaxValue * 360f );
			}



			public static explicit operator Rotator( Qu v )
			{
				var unitRot = (v.eulerAngles / 360f) * ushort.MaxValue;
				return new Rotator( -(int)unitRot.x, (int)unitRot.y /*maybe swap Z/Y?*/, -(int)unitRot.z );
			}
		}
	}
}