namespace MEdge.T3D
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Runtime.CompilerServices;
	using Core;
	using JetBrains.Annotations;
	using Reflection;
	using Enum = System.Enum;



	public static class T3DSerialization
	{
		static readonly string StartOfStaticArrayTypeName;



		static T3DSerialization()
		{
			var v = typeof(StaticArray<>).FullName;
			v = v!.Substring( 0, v.IndexOf( '`' ) );
			StartOfStaticArrayTypeName = v;
			Types = new();
			foreach( Type type in typeof(MEdge.Core.Object).Assembly.GetTypes() )
			{
				if( type.Namespace == null || type.Namespace.StartsWith( nameof(MEdge) ) == false )
					continue;
				
				if( type.BaseType == typeof(MulticastDelegate) || type.GetCustomAttribute<CompilerGeneratedAttribute>() != null )
					continue;
				
				var typeName = type.IsNested ? $"{type.DeclaringType.Name}:{type.Name}" : type.Name;
				Types.Add( (name)typeName, type );
			}
		}



		/// <summary> Deserialize a node and its children into usable c# objects, not very optimized. </summary>
		/// <param name="root"></param>
		/// <param name="ignoreException">Test to see if the deserializer should ignore an encountered exception, when null all exceptions will be thrown</param>
		/// <param name="onNodeDeserialized">Will be called once a node is fully deserialized into its c# object</param>
		/// <returns>The deserialized root</returns>
		public static object Deserialize( T3DNode root, [ CanBeNull ] Func<Exception, bool> ignoreException, [ CanBeNull ] Action<object> onNodeDeserialized )
		{
			var utility = new Utility { IgnoreException = ignoreException, OnNodeDeserialized = onNodeDeserialized };
			
			var rootInstance = AllocInstance( root, out _ );
			Recurse( root, rootInstance, utility );

			return rootInstance;
			

			static void Recurse( T3DNode node, object instance, Utility utility )
			{
				// Prepare child object first
				(string, object)[] children = new (string, object)[node.Children.Count];
				for( int i = 0; i < node.Children.Count; i++ )
				{
					var child = node.Children[i];
					var obj = AllocInstance( child, out var fullname );
					try
					{
						utility.NamedReferences.Add( (name)fullname, obj );
					}
					catch( Exception e )
					{
						if( utility == null || utility.IgnoreException( e ) == false )
							throw;
					}
					children[i] = (fullname, obj);
				}
				for( int i = 0; i < children.Length; i++ )
				{
					Recurse( node.Children[i], children[i].Item2, utility );
				}

				// Deserialize properties now that child and their refs have been setup
				var classType = instance.GetType();
				var typeData = ReflectionData.GetDataFor( classType );
				var cache = typeData.NewCache( instance );
				foreach( var prop in node.Properties )
					HandleProp( prop, classType, typeData, cache, utility );

				if( classType.IsValueType )
					throw new InvalidOperationException( "Did not expect value type for node object" );
				
				utility.OnNodeDeserialized?.Invoke(instance);
				
				// We're leaving this scope, remove refs we added in
				for( int i = 0; i < node.Children.Count; i++ )
					utility.NamedReferences.Remove( (name)children[ i ].Item1 );
			}

			static object AllocInstance( T3DNode node, out string fullname )
			{
				var className = node.Definition.Between( " Class=", " ", true );
				var classType = Types[(name)(className??"")];
				var classInstance = Activator.CreateInstance( classType );
				var objName = node.Definition.Between( " ObjName=", " ", true );
				fullname = $"{className}'{objName}'";
				return classInstance;
			}
		}



		static void InlineStructureDeserialization( ref object structure, ReadOnlySpan<char> content, Utility utility )
		{
			if( (content.StartsWith( "(" ) && content.EndsWith( ")" )) == false )
			{
				try
				{
					throw new InvalidOperationException( $"'{content.ToString()}' is not a valid value to assign to a '{structure.GetType()}'" );
				}
				catch( Exception e )
				{
					if( utility.IgnoreException == null || utility.IgnoreException( e ) == false )
						throw;
				}
				return;
			}

			// Remove '(' & ')'
			content = content.Slice( 1, content.Length - 2 );
			var classType = structure.GetType();
			var typeData = ReflectionData.GetDataFor( classType );
			var cache = typeData.NewCache( structure );

			foreach( var value in ExtractValues( content.ToString() ) )
				HandleProp( value, classType, typeData, cache, utility );

			structure = cache.ContainerAsObj;
		}
		
		
		



		static void HandleProp( ReadOnlySpan<char> prop, Type classType, ReflectionData typeData, CachedContainer cache, Utility utility )
		{
			var equalSignPos = prop.IndexOf( '=' );
			var propName = prop[ ..equalSignPos ];

			int? arrayIndex = null;
			if( propName.EndsWith( ")" ) )
			{
				var fullName = propName;
				propName = propName[ ..propName.LastIndexOf( '(' ) ];
				var indexAndParen = fullName[ propName.Length.. ];
				arrayIndex = int.Parse(indexAndParen.Slice( 1, indexAndParen.Length - 2 ));
			}

			var matchingField = typeData.FindField( propName.ToString() );
			if( matchingField == null )
			{
				try
				{
					throw new MissingFieldException( $"Could not find field '{propName.ToString()}' within '{classType}'" );
				}
				catch( Exception e )
				{
					if( utility.IgnoreException == null || utility.IgnoreException( e ) == false )
						throw;
				}
				return;
			}

			var value = prop[ (equalSignPos + 1).. ];
			AssignToField( matchingField, value, arrayIndex, cache, utility );
		}



		static unsafe void AssignToField( IField field, ReadOnlySpan<char> value, int? arrayIndex, CachedContainer cache, Utility utility )
		{
			if( value.Length == 0 )
			{
				field.SetValueToDefault( cache );
				return;
			}
			
			switch( field )
			{
				case IField<Boolean> fBoolean: fBoolean.Ref( cache ) = Boolean.Parse( value ); return;
				case IField<Byte> fByte: fByte.Ref( cache ) = Byte.Parse( value ); return;
				case IField<Int16> fInt16: fInt16.Ref( cache ) = Int16.Parse( value ); return;
				case IField<Int32> fInt32: fInt32.Ref( cache ) = Int32.Parse( value ); return;
				case IField<Int64> fInt64: fInt64.Ref( cache ) = Int64.Parse( value ); return;
				case IField<SByte> fSByte: fSByte.Ref( cache ) = SByte.Parse( value ); return;
				case IField<UInt16> fUInt16: fUInt16.Ref( cache ) = UInt16.Parse( value ); return;
				case IField<UInt32> fUInt32: fUInt32.Ref( cache ) = UInt32.Parse( value ); return;
				case IField<UInt64> fUInt64: fUInt64.Ref( cache ) = UInt64.Parse( value ); return;
				case IField<Single> fSingle: fSingle.Ref( cache ) = Single.Parse( value ); return;
				case IField<Double> fDouble: fDouble.Ref( cache ) = Double.Parse( value ); return;
				case IField<Char> fChar: fChar.Ref( cache ) = value.Length == 1 ? value[0] : throw new Exception(); return;
				case IField<DateTime> fDateTime: fDateTime.Ref( cache ) = DateTime.Parse( value ); return;
				case IField<Decimal> fDecimal: fDecimal.Ref( cache ) = Decimal.Parse( value ); return;
				case IField<MEdge.Core.name> fName: fName.Ref( cache ) = StripQuotes(value).ToString(); return;
				case IField<MEdge.Core.String> fString: fString.Ref( cache ) = StripQuotes(value).ToString(); return;
				case IField<string> fString: fString.Ref( cache ) = StripQuotes(value).ToString(); return;
				default: break;
			}
			
			// Structs and classes
			
			var fieldType = field.Info.FieldType;
			if( field.IsReferenceType )
			{
				char* testingData2 = stackalloc char[ value.Length ];
				// Reference to object
				if( utility.NamedReferences.TryGetValue( unsafe_namePtr.PrepareStackallocForUnsafeTest(value, testingData2), out var nodeRef ) )
				{
					field.SetValueSlow( cache, nodeRef );
				}
				else if( value.Equals("none", StringComparison.InvariantCultureIgnoreCase) )
				{
					field.SetValueToDefault( cache );
				}
				// new default object or asset reference
				else if( value.IndexOf( '\'' ) is int firstQuote 
				         && firstQuote != - 1 
				         && value[ ^1 ] == '\'' 
				         && firstQuote != value.Length - 1 )
				{
					var paramFull = value.Slice( firstQuote + 1, value.Length - firstQuote - 2 );
					if( paramFull.Contains( ".Default__", StringComparison.InvariantCultureIgnoreCase ) )
					{
						var partialType = FromLastIndexOf( paramFull, '.' );
						if( partialType.Contains( "Default__", StringComparison.InvariantCultureIgnoreCase ) )
							partialType = partialType[ (partialType.IndexOf( "Default__" ) + "Default__".Length).. ];

						char* testingData = stackalloc char[ partialType.Length ];
						if( Types.TryGetValue( unsafe_namePtr.PrepareStackallocForUnsafeTest(partialType, testingData), out var type ) == false )
						{
							try
							{
								throw new MissingMemberException( $"Could not find type '{partialType.ToString()}' inside assembly '{nameof(MEdge)}'" );
							}
							catch( Exception e )
							{
								if( utility.IgnoreException == null || utility.IgnoreException( e ) == false )
									throw;
							}
							return;
						}

						field.SetValueSlow( cache, Activator.CreateInstance( type ) );
					}
					else
					{
						var partialType = FromLastIndexOf( value[ ..firstQuote ], '.');
						
						char* testingData = stackalloc char[ partialType.Length ];
						if( Types.TryGetValue( unsafe_namePtr.PrepareStackallocForUnsafeTest(partialType, testingData), out var type ) == false )
						{
							try
							{
								throw new MissingMemberException( $"Could not find type '{partialType.ToString()}' inside assembly '{nameof(MEdge)}'" );
							}
							catch( Exception e )
							{
								if( utility.IgnoreException == null || utility.IgnoreException( e ) == false )
									throw;
							}
							return;
						}
						MethodInfo method = typeof(MEdge.Source.Asset).GetMethod(nameof(MEdge.Source.Asset.LoadAsset), BindingFlags.Static | BindingFlags.Public);
						MethodInfo generic = method.MakeGenericMethod(type);
						var returnValue = generic.Invoke(typeof(MEdge.Source.Asset), new object[]{ (MEdge.Core.String) paramFull.ToString() } );

						field.SetValueSlow( cache, returnValue );
					}
				}
				else
				{
					throw new InvalidOperationException( $"Unknown value scheme '{value.ToString()}', attempted to assign it to {field}" );
				}
			}
			else if( fieldType.IsEnum )
			{
				field.SetValueSlow( cache, Enum.Parse( field.Info.FieldType, value.ToString() ) );
			}
			else if( fieldType.IsGenericType 
			         && fieldType.FullName!.StartsWith( StartOfStaticArrayTypeName ) )
			{
				var array = field.GetValueSlowAndBox( cache );
				var arrayTypeData = ReflectionData.GetDataFor( array.GetType() );
				var arrayInCache = arrayTypeData.NewCache( array );
				var fieldName = $"_{arrayIndex}";
				var arrayFieldRef = arrayTypeData.FindField( fieldName ) 
				                    ?? throw new InvalidOperationException( $"Could not find field '{fieldName}' within type '{array.GetType()}'" );
				AssignToField( arrayFieldRef, value, null, arrayInCache, utility );
				field.SetValueSlow( cache, arrayInCache.ContainerAsObj );
			}
			else if( fieldType.IsGenericType && fieldType.GetGenericTypeDefinition() == typeof(array<>) )
			{
				// This is so slow and ugly but whatever
				object v = field.GetValueSlowAndBox( cache ); // this might be null, ArrayFacilitator takes care of initializing it
				var itemType = fieldType.GenericTypeArguments[ 0 ];
				// For each values in array, make a proxy single field, retrieve value, set CallAssignToField
				ArrayFacilitator.GetForType( itemType ).AssignToArrayIndex( ref v, arrayIndex, value, utility );
				field.SetValueSlow(cache, v);
			}
			else // struct
			{
				var v = field.GetValueSlowAndBox( cache );
				InlineStructureDeserialization( ref v, value, utility );
				field.SetValueSlow( cache, v );
			}
		}



		static ReadOnlySpan<char> StripQuotes( ReadOnlySpan<char> s ) => s.StartsWith( "\"" ) && s.EndsWith( "\"" ) ? s.Slice( 1, s.Length - 2 ) : s;



		static ReadOnlySpan<char> FromLastIndexOf( ReadOnlySpan<char> s, char c )
		{
			var i = s.LastIndexOf( c );
			return i != -1 ? s[ (i+1).. ] : s;
		}



		static IEnumerable<string> ExtractValues(string s)
		{
			int start = 0;
			int stack = 0;
			for( int i = 0; i < s.Length; i++ )
			{
				var c = s[ i ];
				if( c == '(' )
				{
					stack++;
					continue;
				}
				else if( c == ')' )
				{
					stack--;
					continue;
				}

				if( stack > 0 )
					continue;

				if( c == ',' )
				{
					yield return s.Substring( start, i - start );
					start = i + 1;
				}
			}
			yield return s.Substring( start, s.Length - start );
		}



		abstract class ArrayFacilitator
		{
			[ThreadStatic]
			static Dictionary<Type, ArrayFacilitator> _arrayFacilitators;
			public static ArrayFacilitator GetForType( Type t )
			{
				_arrayFacilitators ??= new Dictionary<Type, ArrayFacilitator>();
				if( _arrayFacilitators.TryGetValue( t, out var facilitator ) )
					return facilitator;
				_arrayFacilitators.Add( t, facilitator = (ArrayFacilitator) Activator.CreateInstance( typeof(ArrayFacilitator<>).MakeGenericType( t ) ) );
				return facilitator;
			}



			public abstract void AssignToArrayIndex( ref object array, int? index, ReadOnlySpan<char> value, Utility utility );
		}



		class ArrayFacilitator<T> : ArrayFacilitator
		{
			public struct FieldContainer
			{
				public T LooseField;
			}



			public override void AssignToArrayIndex( ref object objArray, int? index, ReadOnlySpan<char> value, Utility utility )
			{
				array<T> outputArray = (array<T>)(objArray ?? new array<T>());
				var typeData = ReflectionData.GetDataFor<FieldContainer>();
				var cache = typeData.NewCache( new FieldContainer() );
				var field = typeData.Fields[ 0 ];
				

				var arrayCopy = outputArray.NewCopy();
				if( index == null && value.StartsWith( "(" ) && value.EndsWith( ")" ) ) // This is most likely an inline multi-value assignment
				{
					value = value.Slice( 1, value.Length - 2 );

					outputArray.Remove(0, outputArray.Length);
					foreach( var subValue in ExtractValues( value.ToString() ) )
					{
						// Start from the initial constructor values, use serialized data to overwrite those when it has data on it,
						// it seems like that's how T3D operates, it doesn't print values that are set to default/initial values and expect the engine to fill those in
						cache.Container.LooseField = outputArray.Length < arrayCopy.Length ? arrayCopy[ outputArray.Length ] : default;
						AssignToField( field, subValue, null, cache, utility );
						outputArray.Add(cache.Container.LooseField);
					}
				}
				else // This is a specific array index assignment
				{
					// Start from the initial constructor values, use serialized data to overwrite those when it has data on it,
					// it seems like that's how T3D operates, it doesn't print values that are set to default/initial values and expect the engine to fill those in
					cache.Container.LooseField = index < arrayCopy.Length ? arrayCopy[ index.Value ] : default;
					AssignToField( field, value, null, cache, utility );
					while( outputArray.Length <= index )
						outputArray.Add(default);
					outputArray[index ?? 0] = cache.Container.LooseField;
				}
				
				objArray = outputArray;
			}
		}



		class Utility
		{
			public Func<Exception, bool> IgnoreException;
			public Action<object> OnNodeDeserialized;
			public Dictionary<unsafe_namePtr, object> NamedReferences = new();
		}
		static readonly Dictionary<unsafe_namePtr, Type> Types;



		readonly unsafe struct unsafe_namePtr : IEquatable<unsafe_namePtr>
		{
			readonly name name;
			readonly char* ptr;
			readonly int ptrLength;



			unsafe_namePtr( name pName, char* pPtr, int pPtrLength)
			{
				name = pName;
				ptr = pPtr;
				ptrLength = pPtrLength;
			}



			public static unsafe_namePtr PrepareStackallocForUnsafeTest( ReadOnlySpan<char> ros, char* pPtr )
			{
				if( name.LooksLikeANone( ros ) )
				{
					return new unsafe_namePtr( "", default, default );
				}
				
				for( int i = 0; i < ros.Length; i++ )
					pPtr[ i ] = ros[ i ];
				
				return new unsafe_namePtr(default, pPtr, ros.Length);
			}



			public static implicit operator unsafe_namePtr( name n )
			{
				return new unsafe_namePtr(n, default, default);
			}



			public bool Equals( unsafe_namePtr other )
			{
				ReadOnlySpan<char> thisSpan = ptr != null ? new ReadOnlySpan<char>( ptr, ptrLength ) : name.Value.ToString();
				ReadOnlySpan<char> otherSpan = other.ptr != null ? new ReadOnlySpan<char>( other.ptr, other.ptrLength ) : other.name.Value.ToString();

				return otherSpan.Equals( thisSpan, StringComparison.InvariantCultureIgnoreCase );
			}



			public override bool Equals( object obj ) => obj is unsafe_namePtr other && Equals( other );



			public override int GetHashCode()
			{
				ReadOnlySpan<char> thisSpan = ptr != null ? new ReadOnlySpan<char>( ptr, ptrLength ) : name.Value.ToString();

				int hc = 0;
				foreach( char c in thisSpan )
				{
					var lc = char.ToLowerInvariant( c );
					hc = HashCode.Combine( hc, lc );
				}

				return hc;
			}
		}
	}
}