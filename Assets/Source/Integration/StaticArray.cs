namespace MEdge.Core
{
    public interface IStaticArray
    {
        public int Length{ get; }
    }



    public interface IStaticArray<T0> : IStaticArray
    {
        public T0 this[ int i ]{ get; set; }
    }



public struct StaticArray<T0> : IStaticArray<T0> 
{
    T0 _0;
    public int Length => 1;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0>(T0 t) => new StaticArray<T0>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1> : IStaticArray<T0> where T1 : T0
{
    T0 _0, _1;
    public int Length => 2;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1>(T0 t) => new StaticArray<T0, T1>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2> : IStaticArray<T0> where T1 : T0 where T2 : T0
{
    T0 _0, _1, _2;
    public int Length => 3;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2>(T0 t) => new StaticArray<T0, T1, T2>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0
{
    T0 _0, _1, _2, _3;
    public int Length => 4;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3>(T0 t) => new StaticArray<T0, T1, T2, T3>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0
{
    T0 _0, _1, _2, _3, _4;
    public int Length => 5;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4>(T0 t) => new StaticArray<T0, T1, T2, T3, T4>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0
{
    T0 _0, _1, _2, _3, _4, _5;
    public int Length => 6;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5, T6> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0 where T6 : T0
{
    T0 _0, _1, _2, _3, _4, _5, _6;
    public int Length => 7;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                case 6: return _6;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                case 6: _6 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5, T6>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5, T6>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5, T6, T7> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0 where T6 : T0 where T7 : T0
{
    T0 _0, _1, _2, _3, _4, _5, _6, _7;
    public int Length => 8;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                case 6: return _6;
                case 7: return _7;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                case 6: _6 = value; return;
                case 7: _7 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5, T6, T7>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5, T6, T7>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0 where T6 : T0 where T7 : T0 where T8 : T0
{
    T0 _0, _1, _2, _3, _4, _5, _6, _7, _8;
    public int Length => 9;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                case 6: return _6;
                case 7: return _7;
                case 8: return _8;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                case 6: _6 = value; return;
                case 7: _7 = value; return;
                case 8: _8 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0 where T6 : T0 where T7 : T0 where T8 : T0 where T9 : T0
{
    T0 _0, _1, _2, _3, _4, _5, _6, _7, _8, _9;
    public int Length => 10;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                case 6: return _6;
                case 7: return _7;
                case 8: return _8;
                case 9: return _9;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                case 6: _6 = value; return;
                case 7: _7 = value; return;
                case 8: _8 = value; return;
                case 9: _9 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0 where T6 : T0 where T7 : T0 where T8 : T0 where T9 : T0 where T10 : T0
{
    T0 _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10;
    public int Length => 11;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                case 6: return _6;
                case 7: return _7;
                case 8: return _8;
                case 9: return _9;
                case 10: return _10;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                case 6: _6 = value; return;
                case 7: _7 = value; return;
                case 8: _8 = value; return;
                case 9: _9 = value; return;
                case 10: _10 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0 where T6 : T0 where T7 : T0 where T8 : T0 where T9 : T0 where T10 : T0 where T11 : T0
{
    T0 _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11;
    public int Length => 12;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                case 6: return _6;
                case 7: return _7;
                case 8: return _8;
                case 9: return _9;
                case 10: return _10;
                case 11: return _11;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                case 6: _6 = value; return;
                case 7: _7 = value; return;
                case 8: _8 = value; return;
                case 9: _9 = value; return;
                case 10: _10 = value; return;
                case 11: _11 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0 where T6 : T0 where T7 : T0 where T8 : T0 where T9 : T0 where T10 : T0 where T11 : T0 where T12 : T0
{
    T0 _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12;
    public int Length => 13;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                case 6: return _6;
                case 7: return _7;
                case 8: return _8;
                case 9: return _9;
                case 10: return _10;
                case 11: return _11;
                case 12: return _12;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                case 6: _6 = value; return;
                case 7: _7 = value; return;
                case 8: _8 = value; return;
                case 9: _9 = value; return;
                case 10: _10 = value; return;
                case 11: _11 = value; return;
                case 12: _12 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0 where T6 : T0 where T7 : T0 where T8 : T0 where T9 : T0 where T10 : T0 where T11 : T0 where T12 : T0 where T13 : T0
{
    T0 _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13;
    public int Length => 14;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                case 6: return _6;
                case 7: return _7;
                case 8: return _8;
                case 9: return _9;
                case 10: return _10;
                case 11: return _11;
                case 12: return _12;
                case 13: return _13;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                case 6: _6 = value; return;
                case 7: _7 = value; return;
                case 8: _8 = value; return;
                case 9: _9 = value; return;
                case 10: _10 = value; return;
                case 11: _11 = value; return;
                case 12: _12 = value; return;
                case 13: _13 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0 where T6 : T0 where T7 : T0 where T8 : T0 where T9 : T0 where T10 : T0 where T11 : T0 where T12 : T0 where T13 : T0 where T14 : T0
{
    T0 _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14;
    public int Length => 15;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                case 6: return _6;
                case 7: return _7;
                case 8: return _8;
                case 9: return _9;
                case 10: return _10;
                case 11: return _11;
                case 12: return _12;
                case 13: return _13;
                case 14: return _14;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                case 6: _6 = value; return;
                case 7: _7 = value; return;
                case 8: _8 = value; return;
                case 9: _9 = value; return;
                case 10: _10 = value; return;
                case 11: _11 = value; return;
                case 12: _12 = value; return;
                case 13: _13 = value; return;
                case 14: _14 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>() { [ 0 ] = t };
}

public struct StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : IStaticArray<T0> where T1 : T0 where T2 : T0 where T3 : T0 where T4 : T0 where T5 : T0 where T6 : T0 where T7 : T0 where T8 : T0 where T9 : T0 where T10 : T0 where T11 : T0 where T12 : T0 where T13 : T0 where T14 : T0 where T15 : T0
{
    T0 _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15;
    public int Length => 16;

    public T0 this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return _0;
                case 1: return _1;
                case 2: return _2;
                case 3: return _3;
                case 4: return _4;
                case 5: return _5;
                case 6: return _6;
                case 7: return _7;
                case 8: return _8;
                case 9: return _9;
                case 10: return _10;
                case 11: return _11;
                case 12: return _12;
                case 13: return _13;
                case 14: return _14;
                case 15: return _15;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
        set
        {
            switch(i)
            {
                case 0: _0 = value; return;
                case 1: _1 = value; return;
                case 2: _2 = value; return;
                case 3: _3 = value; return;
                case 4: _4 = value; return;
                case 5: _5 = value; return;
                case 6: _6 = value; return;
                case 7: _7 = value; return;
                case 8: _8 = value; return;
                case 9: _9 = value; return;
                case 10: _10 = value; return;
                case 11: _11 = value; return;
                case 12: _12 = value; return;
                case 13: _13 = value; return;
                case 14: _14 = value; return;
                case 15: _15 = value; return;
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
	public static implicit operator StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T0 t) => new StaticArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>() { [ 0 ] = t };
}

}