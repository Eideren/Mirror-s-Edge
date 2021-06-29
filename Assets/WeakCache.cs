namespace MEdge
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;



	public class WeakCache<T1, T2> where T1 : class where T2 : class, new()
	{
		ConditionalWeakTable<T1, T2> _b = new ConditionalWeakTable<T1, T2>();
		public T2 this[T1 key]
		{
			get
			{
				if(_b.TryGetValue( key, out var o ) == false)
					_b.Add( key, o = new T2() );
				return o;
			}
			set
			{
				_b.Remove( key );
				_b.Add( key, value );
			}
		}



		public bool TryGetValue(T1 key, out T2 v) => _b.TryGetValue( key, out v );
	}



	public class WeakCacheEnum<T1, T2> : IEnumerable<(T1, T2)> where T1 : class where T2 : class, new()
	{
		ConditionalWeakTable<T1, T2> _b = new ConditionalWeakTable<T1, T2>();
		List<WeakReference<T1>> _list = new List<WeakReference<T1>>();
		public T2 this[T1 key]
		{
			get
			{
				CleanupList();
				if( _b.TryGetValue( key, out var o ) == false )
				{
					_b.Add( key, o = new T2() );
					_list.Add( new WeakReference<T1>( key ) );
				}

				return o;
			}
			set
			{
				if( _b.Remove( key ) == false )
				{
					_list.Add( new WeakReference<T1>( key ) );
				}

				_b.Add( key, value );
				CleanupList();
			}
		}



		public bool TryGetValue(T1 key, out T2 v) => _b.TryGetValue( key, out v );



		public bool Remove( T1 key )
		{
			var result = _b.Remove( key );
			CleanupList();
			return result;
		}



		void CleanupList()
		{
			for( int i = _list.Count - 1; i >= 0; i-- )
			{
				var wRef = _list[ i ];
				if( wRef.TryGetTarget( out var targ ) == false || _b.TryGetValue( targ, out _ ) == false )
					_list.RemoveAt( i );
			}
		}



		public Enumerator GetEnumerator() => new Enumerator( this );
		IEnumerator<(T1, T2)> IEnumerable<(T1, T2)>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();



		public struct Enumerator : IEnumerator<(T1, T2)>
		{
			WeakCacheEnum<T1, T2> _v;
			List<WeakReference<T1>>.Enumerator _internalEnum;
			
			public (T1, T2) Current{ get; private set; }
			
			object IEnumerator.Current => Current;

			public Enumerator( WeakCacheEnum<T1, T2> v )
			{
				_v = v;
				Current = default;
				_internalEnum = _v._list.GetEnumerator();
			}
			
			public bool MoveNext()
			{
				while( _internalEnum.MoveNext() )
				{
					if( _internalEnum.Current.TryGetTarget( out var trgt ) && _v.TryGetValue( trgt, out var val ) )
					{
						Current = ( trgt, val );
						return true; 
					}
				}

				Current = default; // Make sure to release references asap
				return false;
			}
			
			public void Reset() => (_internalEnum as IEnumerator).Reset();
			
			public void Dispose() => _internalEnum.Dispose();
		}
	}
}