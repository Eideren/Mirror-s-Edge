namespace MEdge.Source
{
	using Core;



	public static class DecFn
	{
		static System.Random _randomSource = new System.Random();
		
		public static double fabs( double f ) => System.Math.Abs( f );
		public static short LOWORD( int i ) => (short)(i & 0b1111_1111_1111_1111);
		public static double pow( double x, double p ) => System.Math.Pow( x, p );
		public static double sqrt( double f ) => System.Math.Sqrt( f );
		public static float fsqrt( float f ) => System.MathF.Sqrt( f );
		public static double floor( double f ) => System.Math.Floor( f );
		public static double asin( double f ) => System.Math.Asin( f );
		public static double sin( double f ) => System.Math.Sin( f );
		public static int rand() => _randomSource.Next();
		public static double atan2( double y, double x ) => System.Math.Atan2( y, x );
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
	}
}