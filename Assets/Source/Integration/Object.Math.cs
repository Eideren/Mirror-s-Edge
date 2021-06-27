namespace MEdge.Core
{
	public partial class Object
    {
	    const float PI = (3.1415926535897932f);
	    const float SMALL_NUMBER = (1e-8f);
	    const float KINDA_SMALL_NUMBER = (1e-4f);
	    const float BIG_NUMBER = (3.4e+38f);
	    const float EULERS_NUMBER = (2.71828182845904523536f);
	    
        public static float Abs(float f) => f < 0 ? -f : f;
        public static float Cos(float f) => (float)System.Math.Cos(f);
        public static float Sin(float f) => (float)System.Math.Sin(f);
        public static float Sqrt(float f) => (float)System.Math.Sqrt(f);
        public static float Square( float f ) => f * f;
        
        protected static float atan2( double x, double y ) => (float)System.Math.Atan2( x, y );
        protected static double sqrt( double x ) => System.Math.Sqrt( x );
        protected static float fsqrt( float x ) => (float)System.Math.Sqrt( x );
        protected static float fabs( float f ) => Abs( f );
        protected static float pow( float x, float y ) => (float)System.Math.Pow( x, y );
        protected static float floor( float f ) => (float)System.Math.Floor( f );

        // Export UObject::execRand(FFrame&, void* const)
        /// <summary> Returns a number between and including 0 to <paramref name="max"/> excluding </summary>
        public /*native(167) final function */static int Rand( int Max ) => UnityEngine.Random.Range( 0, Max );

	
        // Export UObject::execVRand(FFrame&, void* const)
        public /*native(252) final function */static Object.Vector VRand()
        {
	        Vector Result;

	        float L;

	        do
	        {
		        // Check random vectors in the unit sphere so result is statistically uniform.
		        Result.X = FRand() * 2 - 1;
		        Result.Y = FRand() * 2 - 1;
		        Result.Z = FRand() * 2 - 1;

		        L = Result.SizeSquared();
	        } while(L > 1.0f || L < 0.001f);

	        return Result * (1.0f / Sqrt(L));
        }



        // Export UObject::execFRand(FFrame&, void* const)
        public /*native(195) final function */static float FRand() => UnityEngine.Random.Range( 0f, 1f );

        public /*final simulated function */static float RandRange(float InMin, float InMax) => UnityEngine.Random.Range( InMin, InMax );

        public static float Exponentiation( float x, float y ) => (float)System.Math.Pow( x, y );
        public static float Acos(float f) => (float)System.Math.Acos(f);
        public static float Tan(float f) => (float)System.Math.Tan(f);

        // Export UObject::execRound(FFrame&, void* const)
        public /*native(199) final function */static int Round( float A ) => (int)System.Math.Round( (double)A );



        public static int Min(int a, int b) => a < b ? a : b;
        public static int Max(int a, int b) => a > b ? a : b;
        public static float FMin(float a, float b) => a < b ? a : b;
        public static float FMax(float a, float b) => a > b ? a : b;
        public static int Clamp(int x, int min, int max) => x > max ? max : x < min ? min : x;
        public static float FClamp(float x, float min, float max) => x > max ? max : x < min ? min : x;

        /// <summary> Unreal Scripts support 'intX *= floatY' operation, this replaces that for c# </summary>
        public static int IntFloat_Mult(int x, float y)
        {
            // Not sure if it rounds 'y' to int and then mult, or cast 'x' to float, mult, then cast back the result to int
            // I'll go for the most sane version for now.
            return (int)(x * y);
        }
        
        
	
        // Export UObject::execFInterpTo(FFrame&, void* const)
        public /*native final function */ static float FInterpTo( float Current, float Target, float DeltaTime, float InterpSpeed )
        {
	        // If no interp speed, jump to target value
	        if( InterpSpeed == 0f )
	        {
		        return Target;
	        }

	        // Distance to reach
	        float Dist = Target - Current;

	        // If distance is too small, just set the desired location
	        if( Square(Dist) < SMALL_NUMBER )
	        {
		        return Target;
	        }

	        // Delta Move, Clamp so we do not over shoot.
	        float DeltaMove = Dist * FClamp(DeltaTime * InterpSpeed, 0f, 1f);

	        return Current + DeltaMove;
        }



        public static float VSize2D(Vector2D v2D) => v2D.Size();
        public static float VSizeSq2D(Vector2D v2D) => v2D.SizeSquared();



        public static float VSize( Vector v ) => v.Size();
	
        // Export UObject::execVSizeSq(FFrame&, void* const)
        public /*native final function */static float VSizeSq( Object.Vector A ) => A.SizeSquared();


        public static Vector Normal(Vector v) => v.SafeNormal();

        public static Rotator Normalize(Rotator rotator)
        {
	        rotator.Normalize();
	        return rotator;
        }
        
        public static float InvSqrt( float F )
        {
	        return 1.0f / sqrtf( F );
        }
        
        public static float sqrtf( float F ) => UnityEngine.Mathf.Sqrt( F );

        /// <summary>
        /// Returns a Rotator axis within the [-32768,+32767] range in float 
        /// </summary>
        public static int NormalizeRotAxis(int angle)
        {
                #warning this implementation is just an interpretation, official implementation likely differs
                // +32767 is +179.x degrees
                // -32768 is -180.x degrees
                // so a full rotation is 32768*2, which once normalized should be equal to '0'
                // Therefore we can simplify this by reading the least significant bits as a 'short' 
                return unchecked((short) angle);
        }

        public static Vector vect(float x, float y, float z) => new Vector() { X = x, Y = y, Z = z };
        public static Rotator rot(int pitch, int roll, int yaw) => new Rotator() { Pitch = pitch, Roll = roll, Yaw = yaw };

        public static float Dot( Vector a, Vector b ) => a.Dot( b );
        public static Vector Cross( Vector a, Vector b ) => a.Cross( b );



        /// <summary>
        /// '<<'
        /// Sometimes it is easier to express an offset relative to a rotation,
        /// for example to specify the 1st person weapon position.
        /// All engine versions provide two special operators for conversion between world coordinates and a local coordinate system expressed by a rotator. Assume CamRot is a camera rotation describing a local coordinate system, for example a player view. Then V << CamRot converts a global offset into a camera-relative local offset, while V >> CamRot converts a camera-relative offset into a global offset.
        /// </summary>
        public static Vector ShiftL( Vector A, Rotator B ) => Decompiled.UObject_execLessLess_VectorRotator( A, B );



        /// <summary>
        /// '>>'
        /// Sometimes it is easier to express an offset relative to a rotation,
        /// for example to specify the 1st person weapon position.
        /// All engine versions provide two special operators for conversion between world coordinates and a local coordinate system expressed by a rotator. Assume CamRot is a camera rotation describing a local coordinate system, for example a player view. Then V << CamRot converts a global offset into a camera-relative local offset, while V >> CamRot converts a camera-relative offset into a global offset.
        /// </summary>
        public static Vector ShiftR( Vector A, Rotator B ) => Decompiled.UObject_execGreaterGreater_VectorRotator( A, B );



        public static int ShiftL(int v, int r) => v << r;
        public static int ShiftR(int v, int r) => v >> r;



        // Export UObject::execVInterpTo(FFrame&, void* const)
        public static Vector VInterpTo( Vector Current, Vector Target, float DeltaTime, float InterpSpeed )
        {
	        // If no interp speed, jump to target value
	        if( InterpSpeed <= 0f )
	        {
		        return Target;
	        }

	        // Distance to reach
	        Vector Dist = Target - Current;

	        // If distance is too small, just set the desired location
	        if( Dist.SizeSquared() < KINDA_SMALL_NUMBER )
	        {
		        return Target;
	        }

	        // Delta Move, Clamp so we do not over shoot.
	        Vector	DeltaMove = Dist * FClamp(DeltaTime * InterpSpeed, 0f, 1f);

	        return Current + DeltaMove;
        }



        // Export UObject::execLerp(FFrame&, void* const)
        public /*native(247) final function */static float Lerp( float A, float B, float Alpha ) => ( B - A ) * Alpha + A; // Decompiled



        public static Rotator RLerp( Rotator A, Rotator B, float Alpha, bool bShortestPath = false ) => Decompiled.E_UObject_execRLerp( A, B, Alpha, bShortestPath );



        // Export UObject::execVLerp(FFrame&, void* const)
        public /*native final function */static Object.Vector VLerp(Object.Vector A, Object.Vector B, float V) => A + V*(B-A);
        
        // Export UObject::execFCubicInterp(FFrame&, void* const)
        public /*native final function */static float FCubicInterp( float P0, float T0, float P1, float T1, float A )
        {
	        float A2 = A  * A;
	        float A3 = A2 * A;

	        return (((2*A3)-(3*A2)+1) * P0) + ((A3-(2*A2)+A) * T0) + ((A3-A2) * T1) + (((-2*A3)+(3*A2)) * P1);
        }
        
        // Export UObject::execFInterpEaseInOut(FFrame&, void* const)
        public /*native final function */static float FInterpEaseInOut(float A, float B, float Alpha, float Exp)
        {
	        float ModifiedAlpha = ( Alpha < 0.5f ) ? 
		        0.5f * Pow(2f * Alpha, Exp) : 
		        1f - 0.5f * Pow(2f * (1f - Alpha), Exp);

	        return Lerp(A, B, ModifiedAlpha);
        }
        
        public static/* final function */float FInterpEaseIn(float A, float B, float Alpha, float Exp)
        {
	        return Lerp(A, B, Exponentiation(Alpha, Exp));
        }

        public static/* final function */float FInterpEaseOut(float A, float B, float Alpha, float Exp)
        {
	        return Lerp(A, B, Exponentiation(Alpha, (1f / Exp)));
        }



        static float Pow( float fBase, float fPow ) => Exponentiation( fBase, fPow );
        
        
        // Export UObject::execGetAxes(FFrame&, void* const)
        public /*static*/ /*native(229) final function *//*static*/ void GetAxes(Object.Rotator A, ref Object.Vector X, ref Object.Vector Y, ref Object.Vector Z)
        {
            // Weird ass usage here, the function is marked as static but the source code uses it like an instanced function
            Decompiled.E_UObject_execGetAxes(A, ref X, ref Y, ref Z);
        }

        
        
        // Export UObject::execGetUnAxes(FFrame&, void* const)
        public /*native(230) final function */static void GetUnAxes(Object.Rotator A, ref Object.Vector X, ref Object.Vector Y, ref Object.Vector Z)
        {
	        Decompiled.E_UObject_execGetUnAxes(A, ref X, ref Y, ref Z);
        }
        
        // Export UObject::execPointDistToLine(FFrame&, void* const)
        public virtual /*native final function */float PointDistToLine(Object.Vector Point, Object.Vector Direction, Object.Vector Origin, /*optional */ref Object.Vector OutClosestPoint/* = default*/)
        {
	        Vector SafeDir = Direction.SafeNormal();
	        OutClosestPoint = Origin + (SafeDir * (Dot((Point-Origin), SafeDir)));
	        return (OutClosestPoint-Point).Size();
        }
        
        // Export UObject::execProjectOnTo(FFrame&, void* const)
        public  /*native(1500) final function */static Object.Vector ProjectOnTo(Object.Vector X, Object.Vector Y)
        {
	        return (Y * (Dot(X, Y) / Dot(Y, Y))); 
        }
        
        // Export UObject::execQuatToRotator(FFrame&, void* const)
        public /*native final function */static Object.Rotator QuatToRotator( Object.Quat A ) => Decompiled.E_UObject_execQuatToRotator( A );

        /// <summary>
        /// Case-insensitve equality
        /// https://wiki.beyondunreal.com/Legacy:Operators
        /// </summary>
        public static bool ApproximatelyEqual(String a, String b) => string.Equals(a, b, System.StringComparison.OrdinalIgnoreCase);



        public /*final function */static Object.LinearColor MakeLinearColor( float R, float G, float B, float A )
        {
	        LinearColor LC;
	        LC.R = R;
	        LC.G = G;
	        LC.B = B;
	        LC.A = A;
	        return LC;
        }



        // Export UObject::execIsZero(FFrame&, void* const)
        public /*native(1501) final function */static bool IsZero( Object.Vector A ) => A.X == 0.0f && A.Y == 0.0f && A.Z == 0.0f;
    }
}