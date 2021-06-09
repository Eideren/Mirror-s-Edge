namespace MEdge.Core
{
	using V3 = UnityEngine.Vector3;
	
	public partial class Object
	{
		public partial struct Vector
		{
			public static explicit operator V3( Vector v ) => new V3( v.X, v.Z, v.Y );
			public static explicit operator Vector( V3 v ) => new Vector( v.x, v.z, v.y );
		}
	}



	public class UnitySpaceConversion
	{
		
	}
}