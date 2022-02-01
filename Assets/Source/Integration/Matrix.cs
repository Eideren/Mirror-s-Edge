namespace MEdge.Core
{
    using System.Runtime.InteropServices;
    using static MEdge.Source.DecFn;



    public partial class Object
    {
        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct Matrix
        {
            [FieldOffset(0)] public fixed float Vals[ 16 ];
            
            [FieldOffset(0)] public MatrixM M;
            [FieldOffset(0)] public Plane PlaneX;
            [FieldOffset(4)] public Plane PlaneY;
            [FieldOffset(8)] public Plane PlaneZ;
            [FieldOffset(12)] public Plane PlaneW;
            
            [FieldOffset(0)] public Plane XPlane;
            [FieldOffset(4)] public Plane YPlane;
            [FieldOffset(8)] public Plane ZPlane;
            [FieldOffset(12)] public Plane WPlane;




            [StructLayout(LayoutKind.Explicit)]
            public struct MatrixM
            {
                [FieldOffset(0)] public fixed float Vals[ 16 ];
                public ref float this[ int x, int y ] => ref Vals[ x * 4 + y ];
            }
            public ref float this[ int x, int y ] => ref Vals[ x * 4 + y ];



            public static readonly Matrix Identity = new Matrix {PlaneX = new(1f, 0f, 0f, 0f), PlaneY = new(0f, 1f, 0f, 0f), PlaneZ = new(0f,0f,1f,0f), PlaneW = new(0f,0f,0f,1f)};
            public void SetAxis( int i, in Vector Axis )
            {
                checkSlow(i >= 0 && i <= 2);
                M[i,0] = Axis.X;
                M[i,1] = Axis.Y;
                M[i,2] = Axis.Z;
            }
            
            public Vector GetAxis(int i)
            {
                checkSlow(i >= 0 && i <= 2);
                return new Vector(M[i,0], M[i,1], M[i,2]);
            }
            
            public Rotator Rotator()
            {
                Vector		XAxis	= GetAxis( 0 );
                Vector		YAxis	= GetAxis( 1 );
                Vector		ZAxis	= GetAxis( 2 );

                Rotator	Rotator	= new Rotator( 
                    appRound(appAtan2( XAxis.Z, appSqrt(Square(XAxis.X)+Square(XAxis.Y)) ) * 32768f / PI), 
                    appRound(appAtan2( XAxis.Y, XAxis.X ) * 32768f / PI), 
                    0 
                );
	
                Vector		SYAxis	= FRotationMatrix( Rotator ).GetAxis(1);
                Rotator.Roll		= appRound(appAtan2( ZAxis | SYAxis, YAxis | SYAxis ) * 32768f / PI);
                return Rotator;
            }
            
            public Vector GetOrigin()
            {
                return FVector(M[3,0],M[3,1],M[3,2]);
            }
            public Matrix Transpose()
            {
                Matrix	Result = default;

                Result.M[0,0] = M[0,0];
                Result.M[0,1] = M[1,0];
                Result.M[0,2] = M[2,0];
                Result.M[0,3] = M[3,0];

                Result.M[1,0] = M[0,1];
                Result.M[1,1] = M[1,1];
                Result.M[1,2] = M[2,1];
                Result.M[1,3] = M[3,1];

                Result.M[2,0] = M[0,2];
                Result.M[2,1] = M[1,2];
                Result.M[2,2] = M[2,2];
                Result.M[2,3] = M[3,2];

                Result.M[3,0] = M[0,3];
                Result.M[3,1] = M[1,3];
                Result.M[3,2] = M[2,3];
                Result.M[3,3] = M[3,3];

                return Result;
            }
            
            public float Determinant()
            {
            	return	M[0,0] * (
            				M[1,1] * (M[2,2] * M[3,3] - M[2,3] * M[3,2]) -
            				M[2,1] * (M[1,2] * M[3,3] - M[1,3] * M[3,2]) +
            				M[3,1] * (M[1,2] * M[2,3] - M[1,3] * M[2,2])
            				) -
            			M[1,0] * (
            				M[0,1] * (M[2,2] * M[3,3] - M[2,3] * M[3,2]) -
            				M[2,1] * (M[0,2] * M[3,3] - M[0,3] * M[3,2]) +
            				M[3,1] * (M[0,2] * M[2,3] - M[0,3] * M[2,2])
            				) +
            			M[2,0] * (
            				M[0,1] * (M[1,2] * M[3,3] - M[1,3] * M[3,2]) -
            				M[1,1] * (M[0,2] * M[3,3] - M[0,3] * M[3,2]) +
            				M[3,1] * (M[0,2] * M[1,3] - M[0,3] * M[1,2])
            				) -
            			M[3,0] * (
            				M[0,1] * (M[1,2] * M[2,3] - M[1,3] * M[2,2]) -
            				M[1,1] * (M[0,2] * M[2,3] - M[0,3] * M[2,2]) +
            				M[2,1] * (M[0,2] * M[1,3] - M[0,3] * M[1,2])
            				);
            }
            
            public static Matrix operator*(in Matrix thiss, in Matrix Other)
            {
                var m2 = thiss;
                var m3 = Other;
                return new Matrix().Mult(&m2, &m3);
                /*FMatrix Result;
                VectorMatrixMultiply( &Result, thiss, &Other );
                return Result;*/
            }
            
            public void RemoveScaling(float Tolerance=SMALL_NUMBER)
            {
                // For each row, find magnitude, and if its non-zero re-scale so its unit length.
                for(int i=0; i<3; i++)
                {
                    float SquareSum = (M[i,0] * M[i,0]) + (M[i,1] * M[i,1]) + (M[i,2] * M[i,2]);
                    if(SquareSum > Tolerance)
                    {
                        float Scale = appInvSqrt(SquareSum);
                        M[i,0] *= Scale; 
                        M[i,1] *= Scale; 
                        M[i,2] *= Scale; 
                    }
                }
            }
            
            // Inverse.
            public Matrix Inverse()
            {
                Matrix Result = default;
                Matrix thiss = this;
                VectorMatrixInverse( &Result, &thiss );
                return Result;
            }
        }



        
	
        [StructLayout(LayoutKind.Explicit)]
        public partial struct /*atomic immutable */Plane// extends Vector
        {
            [FieldOffset(0)] public/*()*/ float X;
            [FieldOffset(4)] public/*()*/ float Y;
            [FieldOffset(8)] public/*()*/ float Z;
            [FieldOffset(12)] public/*()*/ float W;
            
            [FieldOffset(0)] public Vector Vector;
            // Object Offset:0x0001D73B
            //		X = 0.0f;
            //		Y = 0.0f;
            //		Z = 0.0f;
            //
            //	structdefaultproperties
            //	{
            //	}
            public Plane( float X, float Y, float Z, float W )
            {
	            Vector = default;
	            this.X = X;
		        this.Y = Y;
	            this.Z = Z;
		        this.W = W;
            }
        };
    }
}