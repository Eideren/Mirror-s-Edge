using static MEdge.Source.DecFn;
namespace MEdge.Core
{
    public partial class Object
    {
        public partial struct Vector4
        {
            public Vector4( float x, float y, float z, float w )
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
                this.W = w;
            }



            public static implicit operator Vector( Vector4 v )
            {
                return new Vector( v.X, v.Y, v.Z );
            }
            
            public Vector4 SafeNormal(float Tolerance=SMALL_NUMBER)
            {
                float SquareSum = X*X + Y*Y + Z*Z;
                if( SquareSum > Tolerance )
                {
                    float Scale = appInvSqrt(SquareSum);
                    return new Vector4(X*Scale, Y*Scale, Z*Scale, 0.0f);
                }
                return new Vector4();
            }
        }



        public partial struct Plane
        {
            public Plane( in Vector InBase, in Vector InNormal )
            {
                this = default;
                Vector = ( InNormal );
                W = ( InBase | InNormal );
            }
            public float PlaneDot( in Vector P )
            {
                return X*P.X + Y*P.Y + Z*P.Z - W;
            }
        }



        public partial struct Vector
    {
        public Vector( float x, float y, float z )
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public Vector( float x )
        {
            this.X = x;
            this.Y = x;
            this.Z = x;
        }
        
        public static float operator|( Vector A, Vector V )
        {
            return A.X*V.X + A.Y*V.Y + A.Z*V.Z;
        }
        
        public static Vector operator^( Vector A, Vector V )
        {
            return A.Cross(V);
        }



        public static Vector operator *( Vector A, Vector B )
        {
            return new(A.X * B.X, A.Y * B.Y, A.Z * B.Z);
        }



        public static implicit operator Vector2D(Vector v) => new Vector2D() { X = v.X, Y = v.Y };

        public static Vector operator *(Vector a, float b)
        {
            return new Vector()
            {
                X = a.X * b,
                Y = a.Y * b,
                Z = a.Z * b,
            };
        }

        public static Vector operator /(Vector a, float b)
        {
            return new Vector()
            {
                X = a.X / b,
                Y = a.Y / b,
                Z = a.Z / b,
            };
        }

        public static Vector operator *(float b, Vector a)
        {
            return new Vector()
            {
                X = a.X * b,
                Y = a.Y * b,
                Z = a.Z * b,
            };
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector()
            {
                X = a.X + b.X,
                Y = a.Y + b.Y,
                Z = a.Z + b.Z,
            };
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector()
            {
                X = a.X - b.X,
                Y = a.Y - b.Y,
                Z = a.Z - b.Z,
            };
        }

        public static Vector operator -(Vector a)
        {
            return new Vector()
            {
                X = -a.X,
                Y = -a.Y,
                Z = -a.Z,
            };
        }
        
        public readonly float GetMax()
        {
            return Max(Max(X,Y),Z);
        }
        
        public readonly float Size()
        {
            return Sqrt( X*X + Y*Y + Z*Z );
        }
        
        public readonly float SizeSquared()
        {
            return X*X + Y*Y + Z*Z;
        }
        public readonly Vector SafeNormal(float Tolerance = SMALL_NUMBER)
        {
            float SquareSum = X*X + Y*Y + Z*Z;
            
            if( SquareSum == 1f )
            {
                return this;
            }		
            else if( SquareSum < Tolerance )
            {
                return default;
            }
            float Scale = InvSqrt(SquareSum);
            return new Vector(X*Scale, Y*Scale, Z*Scale);
        }
        
        public bool Normalize(float Tolerance=SMALL_NUMBER)
        {
            float SquareSum = X*X + Y*Y + Z*Z;
            if( SquareSum > Tolerance )
            {
                float Scale = appInvSqrt(SquareSum);
                X *= Scale; Y *= Scale; Z *= Scale;
                return TRUE;
            }
            return FALSE;
        }


        /// <summary> Also known as the '|' operator between two vectors in unreal c++ or 'x Dot y' in unreal script </summary>
        public readonly float Dot( Vector V ) => X*V.X + Y*V.Y + Z*V.Z;
        public readonly Vector Cross( Vector V ) => new Vector
        (
            Y * V.Z - Z * V.Y, 
            Z * V.X - X * V.Z, 
            X * V.Y - Y * V.X
        );



        public static bool operator ==(Vector a, Vector b) => a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        public static bool operator !=(Vector a, Vector b) => (a == b) == false;
        public override bool Equals( object obj ) => obj is Vector v && this == v;
        public override int GetHashCode()
        {
            var previousHash = unchecked( ( 1009 * 9176 ) + X.GetHashCode() );
            previousHash = unchecked( ( previousHash * 9176 ) + Y.GetHashCode() );
            return unchecked( ( previousHash * 9176 ) + Z.GetHashCode() );
        }



        public override string ToString() => $"({X}, {Y}, {Z})";
        
        public readonly bool IsZero() => this == default;
        public readonly bool IsNearlyZero(float Tolerance=KINDA_SMALL_NUMBER)
        {
            return Abs(X)<Tolerance
                   &&	Abs(Y)<Tolerance
                   &&	Abs(Z)<Tolerance;
        }
        public readonly void FindBestAxisVectors( ref Vector Axis1, ref Vector Axis2 )
        {
            float NX = Abs(X);
            float NY = Abs(Y);
            float NZ = Abs(Z);

            // Find best basis vectors.
            if( NZ>NX && NZ>NY )	Axis1 = FVector(1,0,0);
            else					Axis1 = FVector(0,0,1);

            Axis1 = (Axis1 - this * (Axis1 | this)).SafeNormal();
            Axis2 = Axis1 ^ this;
        }
    }
    }
}