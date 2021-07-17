namespace MEdge.Core
{
    using System.Runtime.InteropServices;



    public partial class Object
    {
        public unsafe partial struct Matrix
        {
            public MatrixM M;




            [StructLayout(LayoutKind.Explicit)]
            public struct MatrixM
            {
                [FieldOffset(0)]Vector4 X;
                [FieldOffset(4)]Vector4 Y;
                [FieldOffset(8)]Vector4 Z;
                [FieldOffset(12)]Vector4 W;
                public float this[ int x, int y ]
                {
                    get
                    {
                        var index = x * 4 + y;
                        if(index > 15 || index < 0)
                            throw new System.IndexOutOfRangeException();
                        fixed( void* ptr = & X )
                        {
                            return ((float*)ptr)[ index ];
                        }
                    }
                    set
                    {
                        var index = x * 4 + y;
                        if(index > 15 || index < 0)
                            throw new System.IndexOutOfRangeException();
                        fixed( void* ptr = & X )
                        {
                            ((float*)ptr)[ index ] = value;
                        }
                    }
                }
                
                
                
                
                public float this[ int index ]
                {
                    get
                    {
                        if(index > 15 || index < 0)
                            throw new System.IndexOutOfRangeException();
                        fixed( void* ptr = & X )
                        {
                            return ((float*)ptr)[ index ];
                        }
                    }
                    set
                    {
                        if(index > 15 || index < 0)
                            throw new System.IndexOutOfRangeException();
                        fixed( void* ptr = & X )
                        {
                            ((float*)ptr)[ index ] = value;
                        }
                    }
                }
            }
        }
    }
}