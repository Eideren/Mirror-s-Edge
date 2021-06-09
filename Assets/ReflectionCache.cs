namespace MEdge
{
	using System;
	using System.Reflection;
	using System.Reflection.Emit;
	using System.Runtime.CompilerServices;



	public static class ReflectionCache
	{
		public delegate void Set(ref object objectContainingField, object? fieldValue);
		public delegate object Get(object objectContainingField);
		
		// I don't expect this field to be often accessed by multiple threads at the same time, so just use a lock
		static readonly ConditionalWeakTable<Type, (FieldInfo info, Get get, Set set)[]> TYPE_TO_FIELDS = new ConditionalWeakTable<Type, (FieldInfo, Get, Set)[]>();
		
		/// <summary>
		/// Fetch all the instance fields, even backing fields, output is ordered deterministically.
		/// Using this effectively gives you access to any data stored within a class instance.
		/// This operation is cached: next call with the same parameter will be faster.
		/// </summary>
		public static (FieldInfo info, Get get, Set set)[] GetAllFieldsForSerialization( Type objType )
		{
			// Try fetch from cache
			lock(TYPE_TO_FIELDS)
				if( TYPE_TO_FIELDS.TryGetValue( objType, out var fields ) )
					return fields;
			// Else, continue below

			// This type hasn't been processed yet, do so here
			return ProcessTypeAndSubtype( objType );
		}



		static (FieldInfo, Get, Set)[] ProcessTypeAndSubtype( Type objType )
		{
			const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;
			
			// Is this sub-type already cached ?
			lock( TYPE_TO_FIELDS )
				if( TYPE_TO_FIELDS.TryGetValue( objType, out var fields ) )
					return fields;

			(FieldInfo, Get, Set)[]? subFields = null;
			if( objType.BaseType != null )
				subFields = ProcessTypeAndSubtype( objType.BaseType );

			var localFields = objType.GetFields( flags );
			
			(FieldInfo, Get, Set)[] allFields = new (FieldInfo, Get, Set)[ localFields.Length + (subFields?.Length ?? 0) ];
			
			int i = 0;
			foreach( FieldInfo info in localFields/*.OrderBy( x => x.Name )*/ )
			{
				allFields[i++] = ( info, GenerateGetMethod( info ), GenerateSetMethod( info ));
			}
			
			
			if( subFields != null )
				Array.Copy( subFields, 0, allFields, i, subFields.Length );

			
			// We are finished processing it, add it to our cache
			lock( TYPE_TO_FIELDS )
				TYPE_TO_FIELDS.Add( objType, allFields );
			
			return allFields;
		}
		
		

		static Get GenerateGetMethod( FieldInfo member )
		{
			var method = new DynamicMethod( "FieldGetter", typeof(object), new[] { typeof(object) }, true );
			var il = method.GetILGenerator();
			il.Emit( OpCodes.Ldarg_0 );

			il.Emit( member.DeclaringType!.IsValueType ? OpCodes.Unbox : OpCodes.Castclass, member.DeclaringType );
			il.Emit( OpCodes.Ldfld, member );
            
			if( member.FieldType.IsValueType )
				il.Emit( OpCodes.Box, member.FieldType );
            
			il.Emit( OpCodes.Ret );
			return (Get) method.CreateDelegate( typeof(Get) );
		}



		static Set GenerateSetMethod( FieldInfo member )
		{
			var method = new DynamicMethod( "FieldSetter", typeof(object), new[] { typeof(object), typeof(object) }, true );
			var il = method.GetILGenerator();

			// Cast first parameter to right type and store result
			var a = il.DeclareLocal( member.DeclaringType! );
			il.Emit( OpCodes.Ldarg_0 );
			il.Emit( member.DeclaringType!.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, member.DeclaringType );
			il.Emit( OpCodes.Stloc_0 );
            
			// Set field of struct/class to second parameter
			if( member.DeclaringType.IsValueType )
				il.Emit( OpCodes.Ldloca_S, a );
			else
				il.Emit( OpCodes.Ldloc_0 );
			il.Emit( OpCodes.Ldarg_1 );
			il.Emit( member.FieldType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, member.FieldType );
			il.Emit( OpCodes.Stfld, member );
            
			// Unbox and return modified struct/class (first parameter)
			il.Emit( OpCodes.Ldloc_0 );
			if( member.DeclaringType.IsValueType )
				il.Emit( OpCodes.Box, member.DeclaringType );
			il.Emit( OpCodes.Ret );

			var f = (Func<object, object?, object>) method.CreateDelegate( typeof(Func<object, object?, object>) );
			
			return SetValueOfField;
			void SetValueOfField(ref object structOrClass, object? fieldValue)
			{
				structOrClass = f(structOrClass, fieldValue);
			}
		}
	}
}