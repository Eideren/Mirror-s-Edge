namespace MEdge.Core
{
    using System.Runtime.InteropServices;
    using UnityEngine;
    using static MEdge.Source.DecFn;



    public partial class Object
    {
        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct Matrix
        {
            [FieldOffset(0)] public fixed float Vals[ 16 ];
            
            [FieldOffset(0)] public MatrixM M;
            
            [FieldOffset(0)] public Plane PlaneX;
            [FieldOffset(16)] public Plane PlaneY;
            [FieldOffset(32)] public Plane PlaneZ;
            [FieldOffset(48)] public Plane PlaneW;
            
            [FieldOffset(0)] public Plane XPlane;
            [FieldOffset(16)] public Plane YPlane;
            [FieldOffset(32)] public Plane ZPlane;
            [FieldOffset(48)] public Plane WPlane;



            [StructLayout(LayoutKind.Explicit)]
            public struct MatrixM
            {
                [FieldOffset(0)] public fixed float Vals[ 16 ];
                public float this[ int x, int y ]
                {
	                get => Vals[ x * 4 + y ];
	                set => Vals[ x * 4 + y ] = value;
                }
            }



            public float this[ int x, int y ]
            {
	            get => Vals[ x * 4 + y ];
	            set => Vals[ x * 4 + y ] = value;
            }
            
            public readonly Vector InverseTransformFVector(ref Vector V)
            {
	            return Inverse().TransformFVector(V);
            }



            public static readonly Matrix Identity = new Matrix
            {
	            PlaneX = new(1f, 0f, 0f, 0f), 
	            PlaneY = new(0f, 1f, 0f, 0f), 
	            PlaneZ = new(0f, 0f, 1f, 0f), 
	            PlaneW = new(0f, 0f, 0f, 1f)
            };
            
            
            
            public void SetAxis( int i, in Vector Axis )
            {
                checkSlow(i >= 0 && i <= 2);
                M[i,0] = Axis.X;
                M[i,1] = Axis.Y;
                M[i,2] = Axis.Z;
            }
            
            public readonly Vector GetAxis(int i)
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
            
            public void Mirror(EAxis MirrorAxis, EAxis FlipAxis)
            {
	            if(MirrorAxis == EAxis.AXIS_X)
	            {
		            M[0,0] *= -1f;
		            M[1,0] *= -1f;
		            M[2,0] *= -1f;

		            M[3,0] *= -1f;
	            }
	            else if(MirrorAxis == EAxis.AXIS_Y)
	            {
		            M[0,1] *= -1f;
		            M[1,1] *= -1f;
		            M[2,1] *= -1f;

		            M[3,1] *= -1f;
	            }
	            else if(MirrorAxis == EAxis.AXIS_Z)
	            {
		            M[0,2] *= -1f;
		            M[1,2] *= -1f;
		            M[2,2] *= -1f;

		            M[3,2] *= -1f;
	            }

	            if(FlipAxis == EAxis.AXIS_X)
	            {
		            M[0,0] *= -1f;
		            M[0,1] *= -1f;
		            M[0,2] *= -1f;
	            }
	            else if(FlipAxis == EAxis.AXIS_Y)
	            {
		            M[1,0] *= -1f;
		            M[1,1] *= -1f;
		            M[1,2] *= -1f;
	            }
	            else if(FlipAxis == EAxis.AXIS_Z)
	            {
		            M[2,0] *= -1f;
		            M[2,1] *= -1f;
		            M[2,2] *= -1f;
	            }
            }
            
            public readonly Vector GetOrigin()
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
            public readonly Matrix Inverse()
            {
                Matrix Result = default;
                Matrix thiss = this;
                VectorMatrixInverse( &Result, &thiss );
                return Result;
            }
            public readonly float RotDeterminant()
            {
	            return	
		            M[0,0] * (M[1,1] * M[2,2] - M[1,2] * M[2,1]) -
		            M[1,0] * (M[0,1] * M[2,2] - M[0,2] * M[2,1]) +
		            M[2,0] * (M[0,1] * M[1,2] - M[0,2] * M[1,1]);
            }
            
            public void SetOrigin( in Vector NewOrigin )
            {
	            M[3,0] = NewOrigin.X;
	            M[3,1] = NewOrigin.Y;
	            M[3,2] = NewOrigin.Z;
            }
            public readonly Vector4 TransformNormal(in Vector V)
            {
	            return TransformFVector4(this, new Vector4(V.X,V.Y,V.Z,0.0f));
            }
            public readonly Vector InverseTransformNormal(in Vector V)
            {
	            return Inverse().TransformNormal(V);
            }
            public readonly bool ContainsNaN()
            {
	            for(int i=0; i<4; i++)
	            {
		            for(int j=0; j<4; j++)
		            {
			            if(float.IsNaN(M[i,j]) || !float.IsFinite(M[i,j]))
			            {
				            return TRUE;
			            }
		            }
	            }

	            return FALSE;
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



            public override string ToString() => $"{{{X}, {Y}, {Z}, {W}}}";
        };



        public partial struct Box
        {
	        public Box( in Vector InMin, in Vector InMax )
	        {
		        this.Min = InMin;
		        this.Max = InMax;
		        IsValid = 1;
	        }



	        public static Box operator +( Box thiss, Box Other )
	        {
		        if( thiss.IsValid != 0 && Other.IsValid != 0 )
		        {
			        thiss.Min.X = FMin( thiss.Min.X, Other.Min.X );
			        thiss.Min.Y = FMin( thiss.Min.Y, Other.Min.Y );
			        thiss.Min.Z = FMin( thiss.Min.Z, Other.Min.Z );

			        thiss.Max.X = FMax( thiss.Max.X, Other.Max.X );
			        thiss.Max.Y = FMax( thiss.Max.Y, Other.Max.Y );
			        thiss.Max.Z = FMax( thiss.Max.Z, Other.Max.Z );
		        }
		        else if( Other.IsValid != 0 )
		        {
			        return Other;
		        }
		        return thiss;
	        }
	        
	        public unsafe Box TransformBy(in Matrix M)
	        {
				VectorRegister* Vertices = stackalloc VectorRegister[8];
				VectorRegister m0 = VectorLoadAligned( M.PlaneX );
				VectorRegister m1 = VectorLoadAligned( M.PlaneY );
				VectorRegister m2 = VectorLoadAligned( M.PlaneZ );
				VectorRegister m3 = VectorLoadAligned( M.PlaneW );
				Vertices[0]   = VectorLoadFloat3( Min );
				Vertices[1]   = VectorSetFloat3( Min.X, Min.Y, Max.Z );
				Vertices[2]   = VectorSetFloat3( Min.X, Max.Y, Min.Z );
				Vertices[3]   = VectorSetFloat3( Max.X, Min.Y, Min.Z );
				Vertices[4]   = VectorSetFloat3( Max.X, Max.Y, Min.Z );
				Vertices[5]   = VectorSetFloat3( Max.X, Min.Y, Max.Z );
				Vertices[6]   = VectorSetFloat3( Min.X, Max.Y, Max.Z );
				Vertices[7]   = VectorLoadFloat3( Max );
				VectorRegister r0 = VectorMultiply( VectorReplicate(Vertices[0],0), m0 );
				VectorRegister r1 = VectorMultiply( VectorReplicate(Vertices[1],0), m0 );
				VectorRegister r2 = VectorMultiply( VectorReplicate(Vertices[2],0), m0 );
				VectorRegister r3 = VectorMultiply( VectorReplicate(Vertices[3],0), m0 );
				VectorRegister r4 = VectorMultiply( VectorReplicate(Vertices[4],0), m0 );
				VectorRegister r5 = VectorMultiply( VectorReplicate(Vertices[5],0), m0 );
				VectorRegister r6 = VectorMultiply( VectorReplicate(Vertices[6],0), m0 );
				VectorRegister r7 = VectorMultiply( VectorReplicate(Vertices[7],0), m0 );

				r0 = VectorMultiplyAdd( VectorReplicate(Vertices[0],1), m1, r0 );
				r1 = VectorMultiplyAdd( VectorReplicate(Vertices[1],1), m1, r1 );
				r2 = VectorMultiplyAdd( VectorReplicate(Vertices[2],1), m1, r2 );
				r3 = VectorMultiplyAdd( VectorReplicate(Vertices[3],1), m1, r3 );
				r4 = VectorMultiplyAdd( VectorReplicate(Vertices[4],1), m1, r4 );
				r5 = VectorMultiplyAdd( VectorReplicate(Vertices[5],1), m1, r5 );
				r6 = VectorMultiplyAdd( VectorReplicate(Vertices[6],1), m1, r6 );
				r7 = VectorMultiplyAdd( VectorReplicate(Vertices[7],1), m1, r7 );

				r0 = VectorMultiplyAdd( VectorReplicate(Vertices[0],2), m2, r0 );
				r1 = VectorMultiplyAdd( VectorReplicate(Vertices[1],2), m2, r1 );
				r2 = VectorMultiplyAdd( VectorReplicate(Vertices[2],2), m2, r2 );
				r3 = VectorMultiplyAdd( VectorReplicate(Vertices[3],2), m2, r3 );
				r4 = VectorMultiplyAdd( VectorReplicate(Vertices[4],2), m2, r4 );
				r5 = VectorMultiplyAdd( VectorReplicate(Vertices[5],2), m2, r5 );
				r6 = VectorMultiplyAdd( VectorReplicate(Vertices[6],2), m2, r6 );
				r7 = VectorMultiplyAdd( VectorReplicate(Vertices[7],2), m2, r7 );

				r0 = VectorAdd( r0, m3 );
				r1 = VectorAdd( r1, m3 );
				r2 = VectorAdd( r2, m3 );
				r3 = VectorAdd( r3, m3 );
				r4 = VectorAdd( r4, m3 );
				r5 = VectorAdd( r5, m3 );
				r6 = VectorAdd( r6, m3 );
				r7 = VectorAdd( r7, m3 );

				Box NewBox = new();
				VectorRegister min0 = VectorMin( r0, r1 );
				VectorRegister min1 = VectorMin( r2, r3 );
				VectorRegister min2 = VectorMin( r4, r5 );
				VectorRegister min3 = VectorMin( r6, r7 );
				VectorRegister max0 = VectorMax( r0, r1 );
				VectorRegister max1 = VectorMax( r2, r3 );
				VectorRegister max2 = VectorMax( r4, r5 );
				VectorRegister max3 = VectorMax( r6, r7 );
				min0 = VectorMin( min0, min1 );
				min1 = VectorMin( min2, min3 );
				max0 = VectorMax( max0, max1 );
				max1 = VectorMax( max2, max3 );
				min0 = VectorMin( min0, min1 );
				max0 = VectorMax( max0, max1 );
				VectorStoreFloat3( min0, ref NewBox.Min );
				VectorStoreFloat3( max0, ref NewBox.Max );
				NewBox.IsValid = 1;

				return NewBox;
			}
        }
    }
}