using System.Runtime.InteropServices;

#if CSHARP_7_3_OR_NEWER
using UnityEngine;
#endif

namespace MEdge.Core
{
    public partial class Object
    {
        

    public partial struct Vector
    {
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

        public static bool operator ==(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Vector a, Vector b) => (a == b) == false;
    }
    }
}