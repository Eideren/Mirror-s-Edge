// Unreal Engine 4 Source
// C:\UE4Source\UnrealEngine\
// Engine\Source\Runtime\Engine\Private\KismetMathLibrary
// Engine\Source\Runtime\Core\Public\Math

namespace MEdge.Core
{
    public partial class Object
    {
        public static float Abs(float f) => f < 0 ? -f : f;
        public static float Cos(float f) => (float)System.Math.Cos(f);
        public static float Sin(float f) => (float)System.Math.Sin(f);
        public static float Sqrt(float f) => (float)System.Math.Sqrt(f);
        public static float Square(float f);

        // Export UObject::execRand(FFrame&, void* const)
        /// <summary> Returns a number between and including 0 to <paramref name="max"/> excluding </summary>
        public /*native(167) final function */static int Rand(int Max);

	
        // Export UObject::execVRand(FFrame&, void* const)
        public /*native(252) final function */static Object.Vector VRand();

	
        // Export UObject::execFRand(FFrame&, void* const)
        public /*native(195) final function */static float FRand();

        public /*final simulated function */static float RandRange(float InMin, float InMax);
        
        public static float Exponentiation(float x, float y);
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
        public /*native final function */ static float FInterpTo(float Current, float Target, float DeltaTime, float InterpSpeed);


        public static float VSize2D(Vector2D v2D) => FMath::Sqrt(v2D.X * v2D.X + v2D.Y * v2D.Y); // verify this through disassembly
        public static float VSizeSq2D(Vector2D v2D); // verify this through disassembly
        


        public static float VSize(Vector v) => FMath::Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z); // verify this through disassembly
	
        // Export UObject::execVSizeSq(FFrame&, void* const)
        public /*native final function */static float VSizeSq(Object.Vector A);


        public static Vector Normal(Vector v)
        {
#error implement this
        }

        public static Rotator Normalize(Rotator rotator)
        {
#error implement this
        }

        /// <summary>
        /// Returns a Rotator axis within the [-32768,+32767] range in float 
        /// </summary>
        public static int NormalizeRotAxis(int angle)
        {
                #warning this implementation is just an interpretation, official implementation likely differ
                // +32767 is +179.x degrees
                // -32768 is -180.x degrees
                // so a full rotation is 32768*2, which once normalized should be equal to '0'
                // Therefore we can simplify this by reading the least significant bits as a 'short' 
                return unchecked((short) angle);
        }

        public static Vector vect(float x, float y, float z) => new Vector() { X = x, Y = y, Z = z };
        public static Rotator rot(int pitch, int roll, int yaw) => new Rotator() { Pitch = pitch, Roll = roll, Yaw = yaw };

        public static float Dot(Vector a, Vector b);
        public static Vector Cross(Vector a, Vector b);
        /// <summary>
        /// '<<'
        /// Sometimes it is easier to express an offset relative to a rotation,
        /// for example to specify the 1st person weapon position.
        /// All engine versions provide two special operators for conversion between world coordinates and a local coordinate system expressed by a rotator. Assume CamRot is a camera rotation describing a local coordinate system, for example a player view. Then V << CamRot converts a global offset into a camera-relative local offset, while V >> CamRot converts a camera-relative offset into a global offset.
        /// </summary>
        public static Vector ShiftL(Vector v, Rotator r);
        /// <summary>
        /// '>>'
        /// Sometimes it is easier to express an offset relative to a rotation,
        /// for example to specify the 1st person weapon position.
        /// All engine versions provide two special operators for conversion between world coordinates and a local coordinate system expressed by a rotator. Assume CamRot is a camera rotation describing a local coordinate system, for example a player view. Then V << CamRot converts a global offset into a camera-relative local offset, while V >> CamRot converts a camera-relative offset into a global offset.
        /// </summary>
        public static Vector ShiftR(Vector v, Rotator r);


        public static int ShiftL(int v, int r) => v << r;
        public static int ShiftR(int v, int r) => v >> r;

        public static Vector VInterpTo(Vector a, Vector b, float dt, float speed);
	
        // Export UObject::execLerp(FFrame&, void* const)
        public /*native(247) final function */static float Lerp(float A, float B, float Alpha);
        
        public static Rotator RLerp(Rotator A, Rotator B, float Alpha, bool bShortestPath = false);
        
        // Export UObject::execVLerp(FFrame&, void* const)
        public /*native final function */static Object.Vector VLerp(Object.Vector A, Object.Vector B, float Alpha);
        
        // Export UObject::execFCubicInterp(FFrame&, void* const)
        public /*native final function */static float FCubicInterp(float P0, float T0, float P1, float T1, float A);

        public /*final function */static float FInterpEaseIn(float A, float B, float Alpha, float Exp);

        public /*final function */static float FInterpEaseOut(float A, float B, float Alpha, float Exp);
	
        // Export UObject::execFInterpEaseInOut(FFrame&, void* const)
        public /*native final function */static float FInterpEaseInOut(float A, float B, float Alpha, float Exp);
        
        
        // Export UObject::execGetAxes(FFrame&, void* const)
        public  /*native(229) final function *//*static*/ void GetAxes(Object.Rotator A, ref Object.Vector X, ref Object.Vector Y, ref Object.Vector Z)
        {
            // Weird ass usage here, the function is marked as static but the source code uses it like an instanced function
#warning NATIVE FUNCTION !
            X = default;
            Y = default;
            Z = default;
        }
        
        // Export UObject::execPointDistToLine(FFrame&, void* const)
        public virtual /*native final function */float PointDistToLine(Object.Vector Point, Object.Vector Line, Object.Vector Origin, /*optional */ref Object.Vector OutClosestPoint/* = default*/)
        {
#warning NATIVE FUNCTION !
            OutClosestPoint = default;
            return default;
        }
        
        // Export UObject::execProjectOnTo(FFrame&, void* const)
        public  /*native(1500) final function */static Object.Vector ProjectOnTo(Object.Vector X, Object.Vector Y)
        {
#warning NATIVE FUNCTION !
            return default;
        }
        
        // Export UObject::execQuatToRotator(FFrame&, void* const)
        public /*native final function */static Object.Rotator QuatToRotator(Object.Quat A);

        /// <summary>
        /// Case-insensitve equality
        /// https://wiki.beyondunreal.com/Legacy:Operators
        /// </summary>
        public static bool ApproximatelyEqual(String a, String b) => String.Equals(a, b, System.StringComparison.OrdinalIgnoreCase);

        public /*final function */static Object.LinearColor MakeLinearColor(float R, float G, float B, float A);
        
        // Export UObject::execIsZero(FFrame&, void* const)
        public /*native(1501) final function */static bool IsZero(Object.Vector A);
    }
}