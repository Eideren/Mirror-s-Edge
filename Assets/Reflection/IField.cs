namespace MEdge.Reflection
{
	using System.Reflection;



	public delegate ref T2 ReturnRef<T, T2>( ref T o );



	/// <summary>
	/// Get and set object field values, cast to <see cref="IField{T}"/> to access faster and non-alloc versions of functions
	/// </summary>
	public interface IField
	{
		public FieldInfo Info{ get; }

		/// <summary> This object is of type <see cref="ReturnRef{T, T2}"/> </summary>
		public object RawFunction{ get; }

		/// <summary> Is the field's type a reference type </summary>
		public bool IsReferenceType{ get; }



		/// <summary> One unbox + one boxing, allocates </summary>
		public object GetValueSlowAndBox( object container );



		/// <summary> One boxing, allocates </summary>
		public object GetValueSlowAndBox( CachedContainer container );



		/// <summary> Two unbox + one boxing, allocates </summary>
		public void SetValueSlow( ref object container, object fieldValue );



		/// <summary> One unbox </summary>
		public void SetValueSlow( CachedContainer container, object fieldValue );
	}



	public interface IField<T> : IField
	{
		/// <summary> One unbox + one boxing, allocates </summary>
		public void SetValueSlow( ref object container, T fieldValue );



		/// <summary> One unbox </summary>
		public T GetValueSlow( object container );



		/// <summary>
		/// Direct reference to the actual field, fast path, don't forget to retrieve the container afterwards
		/// since you can't pass value types by reference here
		/// </summary>
		public ref T Ref( CachedContainer container );
	}
}