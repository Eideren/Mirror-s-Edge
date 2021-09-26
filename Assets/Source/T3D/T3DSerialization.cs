namespace MEdge.T3D
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
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
		}



		/// <summary> Deserialize a node and its children into usable c# objects, not very optimized. </summary>
		/// <param name="root"></param>
		/// <param name="ignoreException">Test to see if the deserializer should ignore an encountered exception, when null all exceptions will be thrown</param>
		/// <param name="onNodeDeserialized">Will be called once a node is fully deserialized into its c# object</param>
		/// <returns>The deserialized root</returns>
		public static object Deserialize( T3DNode root, [ CanBeNull ] Func<Exception, bool> ignoreException, [ CanBeNull ] Action<object> onNodeDeserialized )
		{
			var utility = new Utility { IgnoreException = ignoreException, OnNodeDeserialized = onNodeDeserialized };
			var output = PrepareClassesRef( root, typeof(MEdge.Core.Object).Assembly.GetTypes(), utility );

			foreach( var kvp in utility.NameToObject )
			{
				var( obj, objNode, classType ) = kvp.Value;
				
				var typeData = ReflectionData.GetDataFor( classType );
				var cache = typeData.NewCache( obj );
			
				foreach( var prop in objNode.Properties )
					HandleProp( prop, classType, typeData, cache, utility );

				if( classType.IsValueType )
					throw new InvalidOperationException( "Did not expect value type for node object" );
				
				utility.OnNodeDeserialized?.Invoke(obj);
			}
			
			return output;
		}



		static object PrepareClassesRef(T3DNode node, Type[] types, Utility utility)
		{
			var className = node.Definition.Between( " Class=", " ", true );
			var classType = types.First( t => t.Name == className );
			var classInstance = Activator.CreateInstance( classType );
			var objName = node.Definition.Between( " Name=", " ", true );
			var fullname = $"{className}'{objName}'";

			try
			{
				utility.NameToObject.Add( fullname, (classInstance, node, classType) );
			}
			catch( Exception e )
			{
				if( utility == null || utility.IgnoreException( e ) == false )
					throw;
			}

			foreach( T3DNode child in node.Children )
				PrepareClassesRef( child, types, utility );
			
			return classInstance;
		}



		static void InlineStructureDeserialization( ref object structure, string content, Utility utility )
		{
			if( (content.StartsWith( "(" ) && content.EndsWith( ")" )) == false )
			{
				try
				{
					throw new InvalidOperationException( $"'{content}' is not a valid value to assign to a '{structure.GetType()}'" );
				}
				catch( Exception e )
				{
					if( utility.IgnoreException == null || utility.IgnoreException( e ) == false )
						throw;
				}
				return;
			}

			// Remove '(' & ')'
			content = content.Substring( 1, content.Length - 2 );
			var classType = structure.GetType();
			var typeData = ReflectionData.GetDataFor( classType );
			var cache = typeData.NewCache( structure );

			foreach( var value in ExtractValues( content ) )
				HandleProp( value, classType, typeData, cache, utility );

			structure = cache.ContainerAsObj;
		}
		
		
		



		static void HandleProp( string prop, Type classType, ReflectionData typeData, CachedContainer cache, Utility utility )
		{
			var equalSignPos = prop.IndexOf( '=' );
			var propName = prop.Substring( 0, equalSignPos );

			int? arrayIndex = null;
			if( propName.EndsWith( ")" ) )
			{
				var fullName = propName;
				propName = propName.Substring( 0, propName.LastIndexOf( '(' ) );
				var indexAndParen = fullName.Remove( 0, propName.Length );
				arrayIndex = int.Parse(indexAndParen.Substring( 1, indexAndParen.Length - 2 ));
			}

			var matchingField = typeData.FindField( propName );
			if( matchingField == null )
			{
				try
				{
					throw new MissingFieldException( $"Could not find field '{propName}' within '{classType}'" );
				}
				catch( Exception e )
				{
					if( utility.IgnoreException == null || utility.IgnoreException( e ) == false )
						throw;
				}
				return;
			}

			var value = prop.Substring( equalSignPos + 1 );
			AssignToField( matchingField, value, arrayIndex, cache, utility );
		}



		static void AssignToField( IField field, string value, int? arrayIndex, CachedContainer cache, Utility utility )
		{
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
				case IField<Char> fChar: fChar.Ref( cache ) = Char.Parse( value ); return;
				case IField<DateTime> fDateTime: fDateTime.Ref( cache ) = DateTime.Parse( value ); return;
				case IField<Decimal> fDecimal: fDecimal.Ref( cache ) = Decimal.Parse( value ); return;
				case IField<MEdge.Core.name> fName: fName.Ref( cache ) = StripQuotes(value); return;
				case IField<MEdge.Core.String> fString: fString.Ref( cache ) = StripQuotes(value); return;
				case IField<string> fString: fString.Ref( cache ) = StripQuotes(value); return;
				default: break;
			}
			
			// Structs and classes
			
			var fieldType = field.Info.FieldType;
			if( field.IsReferenceType )
			{
				// Reference to object
				if( utility.NameToObject.TryGetValue( value, out var nodeRef ) )
				{
					field.SetValueSlow( cache, nodeRef.obj );
				} 
				// new default object or asset reference
				else if( value.IndexOf( '\'' ) is int firstQuote 
				         && firstQuote != - 1 
				         && value[ value.Length - 1 ] == '\'' 
				         && firstQuote != value.Length - 1 )
				{
					var paramFull = value.Substring( firstQuote + 1, value.Length - firstQuote - 2 );
					var assemblyToSearchIn = typeof(Core.Object).Assembly;
					if( paramFull.Contains( ".Default__" ) )
					{
						var partialType = paramFull.Replace( ".Default__", "." );
						var param = $"{nameof( MEdge )}.{partialType}";
						var type = assemblyToSearchIn.GetType( param ) ?? assemblyToSearchIn.GetTypes().FirstOrDefault( x => x.Name == partialType );
						if( type == null )
						{
							try
							{
								throw new MissingMemberException( $"Could not find type '{param}' inside assembly '{assemblyToSearchIn}'" );
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
						var partialType = value.Substring( 0, firstQuote );
						var prefixType = $"{nameof( MEdge )}.{partialType}";;
						var genericType = assemblyToSearchIn.GetType( prefixType ) ?? assemblyToSearchIn.GetTypes().FirstOrDefault( x => x.Name == partialType );
						if( genericType == null )
						{
							try
							{
								throw new MissingMemberException( $"Could not find type '{prefixType}' inside assembly '{assemblyToSearchIn}'" );
							}
							catch( Exception e )
							{
								if( utility.IgnoreException == null || utility.IgnoreException( e ) == false )
									throw;
							}
							return;
						}
						MethodInfo method = typeof(MEdge.Source.Asset).GetMethod(nameof(MEdge.Source.Asset.LoadAsset), BindingFlags.Static | BindingFlags.Public);
						MethodInfo generic = method.MakeGenericMethod(genericType);
						var returnValue = generic.Invoke(typeof(MEdge.Source.Asset), new object[]{ (MEdge.Core.String) paramFull } );

						field.SetValueSlow( cache, returnValue );
					}
				}
				else
				{
					throw new InvalidOperationException( $"Unknown value scheme '{value}', attempted to assign it to {field}" );
				}
			}
			else if( fieldType.IsEnum )
			{
				field.SetValueSlow( cache, Enum.Parse( field.Info.FieldType, value ) );
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



		static string StripQuotes( string s ) => s.StartsWith( "\"" ) && s.EndsWith( "\"" ) ? s.Substring( 1, s.Length - 2 ) : s;



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



			public abstract void AssignToArrayIndex( ref object array, int? index, string value, Utility utility );
		}



		class ArrayFacilitator<T> : ArrayFacilitator
		{
			public struct FieldContainer
			{
				public T LooseField;
			}



			public override void AssignToArrayIndex( ref object objArray, int? index, string value, Utility utility )
			{
				array<T> outputArray = (array<T>)(objArray ?? new array<T>());
				var typeData = ReflectionData.GetDataFor<FieldContainer>();
				var cache = typeData.NewCache( new FieldContainer() );
				var field = typeData.Fields[ 0 ];
				

				var arrayCopy = outputArray.NewCopy();
				if( index == null && value.StartsWith( "(" ) && value.EndsWith( ")" ) ) // This is most likely an inline multi-value assignment
				{
					value = value.Substring( 1, value.Length - 2 );

					outputArray.Remove(0, outputArray.Length);
					foreach( var subValue in ExtractValues( value ) )
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
			public Dictionary<string, (object obj, T3DNode node, Type type)> NameToObject = new Dictionary<string, (object, T3DNode, Type)>();
		}
	}
}