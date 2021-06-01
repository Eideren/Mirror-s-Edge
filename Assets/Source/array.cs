﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MEdge
{

    /// <summary>
    /// This type might not entirely reflect how Unreal Engine's UScript array works, still wip
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class array<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 4;
        private static readonly T[] s_emptyArray = new T[0];

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
                        _items = s_emptyArray;
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

        internal T[] _items;
        internal int _size;
        private int _version;
        
        
        /// <summary>
        /// DO NOT KEEP REF IF YOU MIGHT BE CALLING ADD()
        /// </summary>
        public ref T this[int i]
        {
            #warning If you store a ref then swap, reorder or resize the array your ref might not match the right thing anymore
            get
            {
                while(i >= Length)
                    Add(default);
                return ref _items[i];
            }
        }
        
        /*public T this[System.Enum i]
        {
            #warning This is very hack-y, fix this asap
            get => this[i.GetHashCode()];
            set => this[i.GetHashCode()] = value;
        }*/
        
        public array()
        {
            _items = s_emptyArray;
        }

        public int Find(T val) => Array.IndexOf(_items, val, 0, _size);

        /// <summary>
        /// Returns the index of item.<paramref name="tMemberName"/> whose value matches <paramref name="tMemberValue"/>
        /// </summary>
        public int Find(string tMemberName, object tMemberValue) => throw new NotImplementedException();

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

        public void AddItem(T item) => Add(item);



        public void Add(T item)
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
        }

        public void Insert(int i, int count)
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

        public Enumerator GetEnumerator() => new Enumerator();

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