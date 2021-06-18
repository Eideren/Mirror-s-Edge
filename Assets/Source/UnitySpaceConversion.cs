namespace MEdge.Core
{
	using V3 = UnityEngine.Vector3;
	using Qu = UnityEngine.Quaternion;
	
	public partial class Object
	{
		public partial struct Vector
		{
			public static explicit operator V3( Vector v ) => new V3( v.X, v.Z, v.Y );
			public static explicit operator Vector( V3 v ) => new Vector( v.x, v.z, v.y );
		}



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