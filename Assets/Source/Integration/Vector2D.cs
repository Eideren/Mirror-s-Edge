namespace MEdge.Core
{
	public partial class Object
	{
		public partial struct /*atomic immutable */Vector2D
		{
			public float Size()
			{
				return Sqrt( X*X + Y*Y );
			}


			public float SizeSquared()
			{
				return X*X + Y*Y;
			}
		}
	}
}