﻿using System.Runtime.InteropServices;

#if CSHARP_7_3_OR_NEWER
using UnityEngine;
#endif

namespace MEdge.Core
{
    public partial class Object
    {
        

    public partial struct Vector
    {
        public Vector( float x, float y, float z )
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
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
        
        public float Size()
        {
            return Sqrt( X*X + Y*Y + Z*Z );
        }
        
        public float SizeSquared()
        {
            return X*X + Y*Y + Z*Z;
        }
        public Vector SafeNormal(float Tolerance = SMALL_NUMBER)
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


        /// <summary> Also known as the '|' operator between two vectors in unreal c++ or 'x Dot y' in unreal script </summary>
        public float Dot( Vector V ) => X*V.X + Y*V.Y + Z*V.Z;
        public Vector Cross( Vector V ) => new Vector
        (
            Y * V.Z - Z * V.Y, 
            Z * V.X - X * V.Z, 
            X * V.Y - Y * V.X
        );



        public static bool operator ==(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Vector a, Vector b) => (a == b) == false;
    }
    }
}