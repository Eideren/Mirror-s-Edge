namespace MEdge.Source
{
	public static class DecFn
	{
		public static double fabs( double f ) => System.Math.Abs( f );
		public static short LOWORD( int i ) => (short)(i & 0b1111_1111_1111_1111);
		public static double pow( double x, double p ) => System.Math.Pow( x, p );
		public static double sqrt( double f ) => System.Math.Sqrt( f );
		public static float fsqrt( float f ) => System.MathF.Sqrt( f );
		public static double floor( double f ) => System.Math.Floor( f );
		public static double asin( double f ) => System.Math.Asin( f );
		public static double atan2( double y, double x ) => System.Math.Atan2( y, x );
		public static T E_TryCastTo<T>( object o ) where T : class => o is T a ? a : null;
	}
}