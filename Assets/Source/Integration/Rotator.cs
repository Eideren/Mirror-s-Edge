namespace MEdge.Core
{
    using static MEdge.Source.DecFn;
    
    public partial class Object
    {
        public partial struct Rotator
        {
            public Rotator(int pitch, int yaw, int roll)
            {
                Pitch = pitch;
                Yaw = yaw;
                Roll = roll;
            }



            // Returns a unit length vector facing the given rotator
            public static explicit operator Vector( Rotator v )
            {
                return GetAxis(FRotationMatrix(v), 0);
            }



            // Returns rotation matching the vector's direction
            public static explicit operator Rotator( Vector v )
            {
                Rotator R = default;

                // Find yaw.
                R.Yaw = appRound(appAtan2(v.Y,v.X) * (float)MAXWORD / (2f*PI));

                // Find pitch.
                R.Pitch = appRound(appAtan2(v.Z,appSqrt(v.X*v.X+v.Y*v.Y)) * (float)MAXWORD / (2f*PI));

                // Find roll.
                R.Roll = 0;

                return R;
            }
            

            public static Rotator operator +(Rotator a, Rotator b)
            {
                Rotator result;
                result.Pitch = a.Pitch + b.Pitch;
                result.Yaw = a.Yaw + b.Yaw;
                result.Roll = a.Roll + b.Roll;
                return result;
            }
            

            public static Rotator operator -(Rotator a, Rotator b)
            {
                Rotator result;
                result.Pitch = a.Pitch - b.Pitch;
                result.Yaw = a.Yaw - b.Yaw;
                result.Roll = a.Roll - b.Roll;
                return result;
            }
            

            public static Rotator operator *(Rotator a, float b)
            {
                Rotator result;
                result.Pitch = (int)(a.Pitch * b);
                result.Yaw = (int)(a.Yaw * b);
                result.Roll = (int)(a.Roll * b);
                return result;
            }
            

            public static Rotator operator /(Rotator a, float b)
            {
                Rotator result;
                var reciprocal = 1f / b;
                result.Pitch = (int)(a.Pitch * reciprocal);
                result.Yaw = (int)(a.Yaw * reciprocal);
                result.Roll = (int)(a.Roll * reciprocal);
                return result;
            }
            
            
            public void Normalize()
            {
                #warning not sure about this
                Pitch = NormalizeRotAxis(Pitch);
                Yaw = NormalizeRotAxis(Yaw);
                Roll = NormalizeRotAxis(Roll);
            }
        }
    }
}