namespace MEdge
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;
	using JetBrains.Annotations;



	public class TempBuffer<T> : IDisposable, IList<T>
	{
		[ ThreadStatic, CanBeNull ] static Stack<TempBuffer<T>> _buffers;

		List<T> _internals;
		bool _stored;



		TempBuffer(){}



		public static TempBuffer<T> Borrow()
		{
			_buffers ??= new Stack<TempBuffer<T>>();
			if(_buffers.Count == 0)
				_buffers.Push( new TempBuffer<T>() );
			var v = _buffers.Pop();
			v._stored = false;
			return v;
		}



		public List<T>.Enumerator GetEnumerator() => _internals.GetEnumerator();

		IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();



		public int Count => _internals.Count;
		public bool IsReadOnly => false;



		public void Dispose()
		{
			if(_stored)
				return;
			_stored = true;
			_internals.Clear();
			if( _internals.Capacity > 4096 )
				_internals.Capacity = 4096;
			_buffers!.Push( this );
		}



		[ MethodImpl( MethodImplOptions.AggressiveInlining ) ] void StoreSafeGuard()
		{
			if( _stored )
				throw new InvalidOperationException( $"Usage of {GetType()} is not permitted after disposing of it" );
		}



		public T this[ int index ]
		{
			get => _internals[ index ];
			set
			{
				StoreSafeGuard();
				_internals[ index ] = value;
			}
		}


		public void Add( T item )
		{
			StoreSafeGuard();
			_internals.Add( item );
		}



		public void Clear()
		{
			StoreSafeGuard();
			_internals.Clear();
		}



		public bool Contains( T item )
		{
			StoreSafeGuard();
			return _internals.Contains( item );
		}



		public void CopyTo( T[] array, int arrayIndex )
		{
			StoreSafeGuard();
			_internals.CopyTo( array, arrayIndex );
		}



		public bool Remove( T item )
		{
			StoreSafeGuard();
			return _internals.Remove( item );
		}
		
		
		
		public int IndexOf( T item )
		{
			StoreSafeGuard();
			return _internals.IndexOf( item );
		}



		public void Insert( int index, T item )
		{
			StoreSafeGuard();
			_internals.Insert( index, item );
		}



		public void RemoveAt( int index )
		{
			StoreSafeGuard();
			_internals.RemoveAt( index );
		}
	}
}