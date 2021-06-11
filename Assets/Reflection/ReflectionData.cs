namespace MEdge.Reflection
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Reflection.Emit;
	using System.Runtime.CompilerServices;
	using JetBrains.Annotations;



	/// <summary>
	/// Stores a container (boxed struct or class object) in a way which avoids boxing and unboxing when getting and setting it's fields values
	/// Retrieve its content once you have finished modifying the object, this is really important for value types as otherwise your object won't be modified.
	/// </summary>
	public interface CachedContainer
	{
		public object ContainerAsObj{ get; set; }
	}


	
	public abstract class ReflectionData
	{
		// I don't expect this field to be often accessed by multiple threads at the same time, so just use a lock
		static readonly ConditionalWeakTable<Type, ReflectionData> TYPE_TO_FIELDS = new ConditionalWeakTable<Type, ReflectionData>();
		
		public static ReflectionData GetDataFor<T>() => ReflectionDataImpl<T>.Instance;
		
		public static ReflectionData GetDataFor( Type t )
		{
			lock( TYPE_TO_FIELDS )
			{
				if( TYPE_TO_FIELDS.TryGetValue( t, out var v ) )
					return v;
			}

			RuntimeHelpers.RunClassConstructor(typeof(ReflectionDataImpl<>).MakeGenericType( t ).TypeHandle);
			
			lock( TYPE_TO_FIELDS )
			{
				TYPE_TO_FIELDS.TryGetValue( t, out var v );
				return v ?? throw new InvalidOperationException();
			}
		}



		/// <summary> Calls <paramref name="inspect"/> on all fields contained inside <see cref="container"/>  </summary>
		public static void ForeachField<TContainer>( ref TContainer container, Action<IField, CachedContainer> inspect )
		{
			// Value type cannot inherit, don't need to include inherited fields
			if( typeof(TContainer).IsValueType )
			{
				ReflectionDataImpl<TContainer>.Instance.ForeachField( ref container, inspect );
				return;
			}

			// The generic type provided is the exact type of the object
			var asObj = (object) container;
			var actualObjType = asObj.GetType();
			if( actualObjType == typeof(TContainer) )
			{
				ReflectionDataImpl<TContainer>.Instance.ForeachField( ref container, inspect );
				return;
			}

			// Fallback to slower version
			GetDataFor( actualObjType ).ForeachField( ref asObj, inspect );
			container = (TContainer)asObj;
		}



		public abstract IField[] Fields{ get; }

		public abstract CachedContainer NewCache(object o);


		/// <summary> Calls <see cref="inspect"/> on all fields contained inside <see cref="container"/> </summary>
		public abstract void ForeachField( ref object container, Action<IField, CachedContainer> inspect );


		/// <summary> Name must match exactly </summary>
		[ CanBeNull ]
		public abstract IField FindField( string name );



		class ReflectionDataImpl<TContainer> : ReflectionData
		{
			public static readonly ReflectionDataImpl<TContainer> Instance = new ReflectionDataImpl<TContainer>();
			[ThreadStatic]
			static Stack<CachedContainerImpl> _cache;
			readonly IField[] fields;
			Dictionary<string, IField> nameToField;



			public override CachedContainer NewCache( object o ) => new CachedContainerImpl{ Container = (TContainer)o };
			
			
			
			public override IField[] Fields => fields;



			[ CanBeNull ]
			public override IField FindField( string name )
			{
				if( nameToField == null )
				{
					nameToField = new Dictionary<string, IField>(fields.Length);
					foreach( var field in fields )
					{
						if( nameToField.ContainsKey( field.Info.Name ) )
							continue;
						nameToField.Add( field.Info.Name, field );
					}
				}
				
				return nameToField.TryGetValue( name, out var matchingField ) ? matchingField : null;
			}



			public override void ForeachField( ref object container, Action<IField, CachedContainer> Setter )
			{
				_cache ??= new Stack<CachedContainerImpl>();
				if(_cache.Count == 0)
					_cache.Push(new CachedContainerImpl());
				
				var cache = _cache.Pop();
				cache.Container = (TContainer) container;
				for( int i = 0; i < fields.Length; i++ )
				{
					Setter( fields[ i ], cache );
				}
				container = cache.Container;
				
				_cache.Push(cache);
			}



			public void ForeachField( ref TContainer container, Action<IField, CachedContainer> Setter )
			{
				_cache ??= new Stack<CachedContainerImpl>();
				if(_cache.Count == 0)
					_cache.Push(new CachedContainerImpl());
				
				var cache = _cache.Pop();
				cache.Container = container;
				for( int i = 0; i < fields.Length; i++ )
					Setter( fields[ i ], cache );
				container = cache.Container;
				
				_cache.Push(cache);
			}
			
			
			
			ReflectionDataImpl()
			{
				// Create functions to retrieve all instance fields of this type by reference
				
				const BindingFlags declaredFields = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;
				const BindingFlags anyField = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

				var listOfFieldInfo = new List<FieldInfo>();
				for( var t = typeof(TContainer); t != null; t = t.BaseType )
					listOfFieldInfo.AddRange( t.GetFields( declaredFields ) );

				fields = new IField[ listOfFieldInfo.Count ];
				for( int i = 0; i < listOfFieldInfo.Count; i++ )
				{
					var fieldInfo = listOfFieldInfo[ i ];
					
					var method = new DynamicMethod( "FieldRefGetter", fieldInfo.FieldType, new[] { typeof(TContainer).MakeByRefType() }, typeof(TContainer), true );
					try
					{
						// workaround for mono. Under that runtime providing the ctor with a byref return type will throw an exception even though c# supports it.
						method.GetType().GetField("returnType", anyField).SetValue(method, fieldInfo.FieldType.MakeByRefType());
					}
					catch( Exception e )
					{
						throw new InvalidOperationException( $"{nameof(ReflectionData)} exception, unable to set the return type to 'ByRef'. "
						                                     + "This is most likely because the private field used for the workaround changed name. "
						                                     + "Systems dependant on reflection won't work without this.", e );
					}

					var il = method.GetILGenerator();

					il.Emit( OpCodes.Ldarg_0 );
					if( typeof(TContainer).IsValueType == false )
						il.Emit( OpCodes.Ldind_Ref );
					il.Emit( OpCodes.Ldflda, fieldInfo );
					il.Emit( OpCodes.Ret );

					var returnMethod = method.CreateDelegate( typeof(ReturnRef<,>).MakeGenericType(typeof(TContainer), fieldInfo.FieldType) );
					var fieldContainer = Activator.CreateInstance( typeof(FieldImpl<>).MakeGenericType( typeof(TContainer), fieldInfo.FieldType ), returnMethod, fieldInfo ) as IField ?? throw new InvalidOperationException();
					fields[ i ] = fieldContainer;
				}
		
				// We are finished processing it, add it to our cache
				lock( TYPE_TO_FIELDS )
					TYPE_TO_FIELDS.Add( typeof(TContainer), this );
			}



			class CachedContainerImpl : CachedContainer
			{
				public TContainer Container;
				public object ContainerAsObj
				{
					get => Container;
					set => Container = (TContainer)value;
				}
			}



			class FieldImpl<TField> : IField<TField>
			{
				public readonly ReturnRef<TContainer, TField> Func;
				
				public FieldInfo Info{ get; }
				public object RawFunction => Func;
				public bool IsReferenceType{ get; }



				public FieldImpl( ReturnRef<TContainer, TField> func, FieldInfo fi )
				{
					Func = func;
					Info = fi;
					IsReferenceType = typeof(TField).IsValueType == false;
				}
				
				
				
				public ref TField Ref( CachedContainer container )
				{
					var cc = (CachedContainerImpl) container;
					return ref Func( ref cc.Container );
				}



				public void SetValueSlow( ref object container, TField fieldValue )
				{
					var tContainer = (TContainer) container;
					Func( ref tContainer ) = fieldValue;
					container = tContainer;
				}



				public object GetValueSlowAndBox( object container ) => GetValueSlow( container );
				public object GetValueSlowAndBox( CachedContainer container ) => Ref( container );



				public void SetValueSlow( ref object container, object fieldValue )
				{
					var tContainer = (TContainer) container;
					Func( ref tContainer ) = (TField)fieldValue;
					container = tContainer;
				}



				public void SetValueSlow( CachedContainer container, object fieldValue ) => Ref( container ) = (TField)fieldValue;



				public TField GetValueSlow( object container )
				{
					var tContainer = (TContainer) container;
					return Func( ref tContainer );
				}



				public override string ToString() => $"{typeof(TField)} {typeof(TContainer)}.{Info.Name}";
			}
		}
	}
}