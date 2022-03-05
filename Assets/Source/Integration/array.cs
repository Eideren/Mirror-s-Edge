using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MEdge
{
    /// <summary>
    /// This type might not entirely reflect how Unreal Engine's UScript array works,
    /// mainly the fact that unreal script's array are more like weird structs;
    /// "[...](They can be) passed as function parameters and returned as function results,
    /// but every time the entire array is copied." - https://wiki.beyondunreal.com/Types#Composite_types
    /// Use the <see cref="NewCopy()"/> function to manually replicate this behavior
    /// </summary>
    public partial struct array<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 4;


        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, newItems, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = Array.Empty<T>();
                    }
                }
            }
        }

        public int Length
        {
            get => _size;
            set
            {
                while(_size < value)
                    AddItem(default);
                if (_size > value)
                    Remove(value, _size - value);
            }
        }


        public int Count => Length;

        public int Num() => Length;


        internal T[] Data => __items;


        internal T[] _items
        {
            get => __items ?? Array.Empty<T>();
            set => __items = value;
        }
        internal int _size;
        private int _version;

        T[] __items;
        
        
        /// <summary>
        /// DO NOT KEEP REF IF YOU MIGHT BE CALLING ADD()
        /// </summary>
        public ref T this[int i]
        {
            #warning If you store a ref then swap, reorder or resize the array your ref might not match the right thing anymore
            get
            {
                while(i >= Length)
                    Add(default(T));
                return ref _items[i];
            }
        }
        public ref T this[uint i]
        {
            #warning If you store a ref then swap, reorder or resize the array your ref might not match the right thing anymore
            get => ref this[ (int) i ];
        }



        /// <summary>
        /// DO NOT KEEP REF IF YOU MIGHT BE CALLING ADD()
        /// </summary>
        public ref T this[Enum e]
        {
            #warning If you store a ref then swap, reorder or resize the array your ref might not match the right thing anymore
            #warning this is garbage, let's replace this asap
            get
            {
                var i = e.GetHashCode();
                UnityEngine.Debug.Assert( Enum.ToObject( e.GetType(), i ).Equals( e ) );
                while(i >= Length)
                    Add(default(T));
                return ref _items[i];
            }
        }

        public int Find(T val) => Array.IndexOf(_items, val, 0, _size);

        /// <summary>
        /// Returns the index of item.<paramref name="tMemberName"/> whose value matches <paramref name="tMemberValue"/>
        /// </summary>
        public int Find(string tMemberName, object tMemberValue) => throw new NotImplementedException();



        public bool FindItem(in T item, ref int Index)
        {
            for( Index=0; Index<Count; Index++ )
                if( EqualityComparer<T>.Default.Equals( __items[ Index ], item ) )
                    return true;
            Index = -1;
            return false;
        }



        public int FindItemIndex(in T item)
        {
            var index = -1;
            FindItem( item, ref index );
            return index;
        }



        public void Remove(int index, int count)
        {
            while (--count >= 0)
            {
                RemoveAt(index);
            }
        }
        
        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                throw new ArgumentOutOfRangeException();
            }
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            //if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                _items[_size] = default!;
            }
            _version++;
        }



        public void RemoveItem(T item)
        {
            int i;
            while((i = Array.IndexOf( _items, item, 0, Length )) != -1)
                RemoveAt( i );
        }



        public int Add(T item)
        {
            _version++;
            T[] array = _items;
            int size = _size;
            if ((uint)size < (uint)array.Length)
            {
                _size = size + 1;
                array[size] = item;
            }
            else
            {
                AddWithResize(item);
            }

            return size;
        }
        
        
        
        public int AddZeroed(int amount = 1)
        {
            int ret = this.Count;
            for( int i = 0; i < amount; i++ )
                Add(default(T));
            return ret;
        }



        public void AddItem(T item) => Add(item);
        public int AddCount( int count ) => AddZeroed(count);
        public int Add( int Count, int ElementSize, int Alignment ) => AddZeroed(Count);



        public void InsertZeroed(int index, int count=1) => Insert(index, count);



        public int AddUniqueItem(T item)
        {
            var index = FindItemIndex( item );
            if( index != - 1 )
                return index;
            Add( item );
            return Length - 1;
        }



        public void Insert(int i, int count = 1)
        {
            while (--count >= 0)
            {
                Insert(i, default(T));
            }
        }
        
        public void Insert(int index, T item)
        {
            // Note that insertions at the end are legal.
            if ((uint)index > (uint)_size)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = item;
            _size++;
            _version++;
        }



        public bool ContainsItem( T item )
        {
            return Array.IndexOf( _items, item, 0, Length ) != -1;
        }



        public void Reserve( int length )
        {
            if( length > Capacity )
                Capacity = length;
        }
        public void Empty(int slack = 0)
        {
            Reset();
        }
        public void Reset()
        {
            Remove(0, Count);
        }



        public array<T> NewCopy()
        {
            var newArr = new T[Length];
            Array.Copy( _items, newArr, Length );
            var cpy = this;
            cpy.__items = newArr;
            return cpy;
        }



        // Non-inline from List.Add to improve its code quality as uncommon path
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void AddWithResize(T item)
        {
            int size = _size;
            EnsureCapacity(size + 1);
            _size = size + 1;
            _items[size] = item;
        }
        
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
                // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
                // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
                if ((uint)newCapacity > /*Array.MaxArrayLength*/int.MaxValue) newCapacity = /*Array.MaxArrayLength*/int.MaxValue;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }

        public Enumerator GetEnumerator() => new Enumerator( this );

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public struct Enumerator : IEnumerator<T>
        {
            private readonly array<T> _list;
            private int _index;
            private readonly int _version;
            private T _current;

            internal Enumerator(array<T> list)
            {
                _list = list;
                _index = 0;
                _version = list._version;
                _current = default;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                var localList = _list;

                if (_version == localList._version && ((uint)_index < (uint)localList.Length))
                {
                    _current = localList._items[_index];
                    _index++;
                    return true;
                }
                return MoveNextRare();
            }

            private bool MoveNextRare()
            {
                if (_version != _list._version)
                {
                    throw new InvalidOperationException("Collection modified while enumerating");
                }

                _index = _list.Length + 1;
                _current = default;
                return false;
            }

            public T Current => _current!;

            object IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || _index == _list.Length + 1)
                    {
                        throw new InvalidOperationException("Collection modified while enumerating");
                    }
                    return Current;
                }
            }

            void IEnumerator.Reset()
            {
                if (_version != _list._version)
                {
                    throw new InvalidOperationException("Collection modified while enumerating");
                }

                _index = 0;
                _current = default;
            }
        }
    }
}