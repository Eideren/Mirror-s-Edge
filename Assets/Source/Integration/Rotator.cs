namespace MEdge.Core
{
    public partial class Object
    {
        public partial struct Rotator
        {
            // Returns a unit length vector facing the given rotator
            public static explicit operator Vector( Rotator v )
            {
                // This has not been decompiled, could not find the source, just tested as matching when doing the same operation over in UDK
                Vector X = default, Y = default, Z = default;
                Decompiled.E_UObject_execGetAxes(v, ref X, ref Y, ref Z);
                return X;
            }



            // Returns rotation matching the vector's direction
            public static explicit operator Rotator( Vector v )
            {
                // This has not been decompiled, could not find the source, just tested as matching when doing the same operation over in UDK
                v = v.SafeNormal();
                Rotator R;
                R.Yaw = (int)(atan2(v.Y,v.X) * 65536f / 2f / PI);
                R.Pitch = (int)(atan2(v.Z,Sqrt(v.X*v.X+v.Y*v.Y)) * 65536f / 2f / PI);
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