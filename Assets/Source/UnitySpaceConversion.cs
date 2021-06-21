namespace MEdge.Core
{
	using V3 = UnityEngine.Vector3;
	using Qu = UnityEngine.Quaternion;
	
	public static class V3Extension
	{
		/// <summary> This vector be rotated and scaled to fit in the proper metric system, I.E.: divided by 100 since 1 unity unit = 100 unreal unit</summary>
		public static V3 ToUnityPos(this Object.Vector v) => new V3( v.X, v.Z, v.Y ) * 0.01f;
		/// <summary> This vector should only be rotated to unreal space, not scaled to fit in the proper metric system </summary>
		public static V3 ToUnityDir(this Object.Vector v) => new V3( v.X, v.Z, v.Y );
		/// <summary> This vector be rotated and scaled to fit in the proper metric system, I.E.: multiplied by 100 since 1 unity unit = 100 unreal unit</summary>
		public static Object.Vector ToUnrealPos(this V3 v) => new Object.Vector( v.x, v.z, v.y ) * 100f;
		/// <summary> This vector should only be rotated to unreal space, not scaled to fit in the proper metric system </summary>
		public static Object.Vector ToUnrealDir(this V3 v) => new Object.Vector( v.x, v.z, v.y );
	}



	public partial class Object
	{
		public partial struct Rotator
		{
			public static explicit operator Qu( Rotator v )
			{
				return Qu.Euler( new V3( v.Pitch, v.Yaw, v.Roll/*maybe swap Z/Y?*/ ) / short.MaxValue * 360f );
			}



			public static explicit operator Rotator( Qu v )
			{
				var unitRot = (v.eulerAngles / 360f) * short.MaxValue;
				return new Rotator{ Pitch = (int)unitRot.x, Roll = (int)unitRot.z /*maybe swap Z/Y?*/, Yaw = (int)unitRot.y };
			}
		}
	}



	public class UnitySpaceConversion
	{
		
	}
}