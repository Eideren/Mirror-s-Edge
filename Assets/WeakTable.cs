namespace MEdge
{
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
				if( _b.TryGetValue( key, out var v ) )
					_b.Remove( key );
				_b.Add( key, value );
			}
		}



		public bool TryGetValue(T1 key, out T2 v) => _b.TryGetValue( key, out v );
	}
}