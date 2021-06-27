namespace MEdge.Core
{
	using System;
	using System.Reflection;
	using Engine;
	using static UnityEngine.Debug;


	[Serializable]
	public partial class Object
	{
		/// <summary>
		/// IN UE3:
		/// TCLASS'Package.Group(s)+.Name'
		/// </summary>
		public static TClass LoadAsset<TClass>( String assetPath ) where TClass : new() => UWorldBridge.GetUWorld().LoadAsset<TClass>( assetPath );

        // Export UObject::execDynamicLoadObject(FFrame&, void* const)
        public /*native final function */static Object DynamicLoadObject(String ObjectName, Core.Class ObjectClass, /*optional */bool? MayFail = default)
        {
	        if( ObjectClass != ClassT<Class>() )
		        throw new InvalidOperationException( $"{ObjectClass} not implemented yet" );
	        
	        var namespaces = new String[]
	        {
		        "MEdge.Engine",
		        "MEdge.TdGame",
		        "MEdge.Core",
		        "MEdge.GameFramework",
		        "MEdge.TdMenuContent",
		        "MEdge.TdMpContent",
		        "MEdge.TdSharedContent",
		        "MEdge.TdSpBossContent",
		        "MEdge.TdSpContent",
		        "MEdge.TdTTContent",
		        "MEdge.TdTuContent",
		        "MEdge.Fp",
		        "MEdge.Tp",
		        "MEdge.Ts",
		        "MEdge.IpDrv",
		        "MEdge.TdEditor",
		        "MEdge.Editor",
		        "MEdge.UnrealEd",
	        };

	        Type type = Type.GetType( ObjectName );
	        for( int i = 0; i < namespaces.Length && type == null; i++ )
	        {
		        type = Type.GetType( $"{namespaces[i]}.{ObjectName}" );
	        }

	        if( type == null )
	        {
		        LogError( $"Could not {nameof(DynamicLoadObject)}({ObjectName}, {ObjectClass}), type '{ObjectName}' not found" );
		        return null;
	        }

	        // This should never throw, if it does the logic below is not setup properly or the type does not derive from Object
	        var genType = typeof(_classImp<>)!.MakeGenericType( type )!;
	        var prop = genType.GetField( nameof( _classImp<Object>.Singleton ), BindingFlags.Static | BindingFlags.Public )!;
	        var val = prop.GetValue( genType );
	        return val as Object;
        }

        /// <summary>
        /// Ex in UE3: soundcue'Gun_Body'
        /// </summary>
        public static TClass ObjectConst<TClass>(String name) where TClass : new()
        {
	        if( typeof(TClass) == typeof(Enum) )
	        {
		        foreach( Type type in Assembly.GetExecutingAssembly().ExportedTypes )
		        {
			        if( type.IsEnum && type.Name == name )
			        {
				        return (TClass)(object)new Enum{ CSharpEnum = type };
			        }
		        }
		        LogWarning($"Could not find enum {name}");
		        System.Diagnostics.Debugger.Break();
		        return default;
	        }
	        else if( typeof(Property).IsAssignableFrom( typeof(TClass) ) )
	        {
		        #warning not too sure what to do here right now, will investigate later
		        System.Diagnostics.Debugger.Break();
		        LogWarning( "not too sure what to do here right now, will investigate later" );
		        return new TClass();
	        }
	        else
	        {
		        return LoadAsset<TClass>( name );
	        }
        }

        // Export UObject::execClassIsChildOf(FFrame&, void* const)
        public /*native(258) final function */static bool ClassIsChildOf<T>( Core.Class TestClass, Core.ClassT<T> ParentClass )
        {
	        return ParentClass.IsBaseOf(TestClass);
        }



        // Export UObject::execIsA(FFrame&, void* const)
        public virtual /*native(197) final function */bool IsA(name typeName) => Class.IsA( typeName );


        static bool _trace = true;
        // Export UObject::execSetUTracing(FFrame&, void* const)
        public /*native final function */static void SetUTracing( bool bShouldUTrace ) => _trace = bShouldUTrace;
        
        // Export UObject::execIsUTracing(FFrame&, void* const)
        public /*native final function */static bool IsUTracing() => _trace;
        
        // Export UObject::execScriptTrace(FFrame&, void* const)
        public /*native final function */static void ScriptTrace()
        {
	        if(_trace)
		        Log($"{nameof(ScriptTrace)}:\n{new System.Diagnostics.StackTrace()}");
        }
        
        public void assert( bool b ) => Assert(b);
        
        

		// Export UObject::execIsPendingKill(FFrame&, void* const)
		/// <summary>
		/// Returns whether the object is pending kill and about to have references to it NULLed by the garbage collector.
		/// </summary>
		public virtual /*native final function */ bool IsPendingKill() => ( this as Actor )?.bPendingDelete ?? throw new NotImplementedException(); // Probably ?
	
        // Export UObject::execSaveConfig(FFrame&, void* const)
        public virtual /*native(536) final function */ void SaveConfig() => LogWarning($"{nameof(SaveConfig)} not implemented");



        // Export UObject::execLocalize(FFrame&, void* const)
        public /*native function */static String Localize( String SectionName, String KeyName, String PackageName )
        {
	        LogWarning($"{nameof(Localize)} not implemented");
	        return $"'localize not implemented, {SectionName}:{KeyName}:{PackageName}'";
        }

        public bool EqualEqual_InterfaceInterface(object a, object b) => ReferenceEquals(a, b);
        public bool NotEqual_InterfaceInterface(object a, object b) => ReferenceEquals(a, b) == false;

        // Export UObject::execInStr(FFrame&, void* const)
        /// <summary>
        /// Returns the position of the first (with bSearchFromRight specified as True: the last) occurrence of S in T or -1 if T does not contain S. This function is case-sensitive. The position of the first character is 0.
        /// </summary>
        public /*native(126) final function */static int InStr( /*coerce */ String S, /*coerce */String T, /*optional */bool? bSearchFromRight = default )
        {
	        if(bSearchFromRight??false)
		        return S.ToString().LastIndexOf( T );
	        return S.ToString().IndexOf( T );
        }



        // Export UObject::execLeft(FFrame&, void* const)
        /// <summary>
        /// Returns the i left-most characters of S. If S has less than or equal to i characters, the entire value is returned.
        /// </summary>
        public /*native(128) final function */static String Left( /*coerce */ String S, int I ) => I > 0 && I <= S.ToString().Length ? (String)S.ToString().Substring(0, I) : S;
	
        // Export UObject::execRight(FFrame&, void* const)
        /// <summary>
        /// Returns the num rightmost characters of S or all of them if S contains less than num characters.
        /// </summary>
        public /*native(234) final function */static String Right( /*coerce */ String S, int I ) => I > 0 && I <= S.ToString().Length ? (String)S.ToString().Remove(0, S.ToString().Length - I) : S;

        // Export UObject::execMid(FFrame&, void* const)
        /// <summary>
        /// Returns up to j characters from string S, starting with the ith character. If j is omitted or greater than the number of characters after position i, all remaining characters are returned.
        /// </summary>
        public /*native(127) final function */static String Mid( /*coerce */ String S, int I, /*optional */int? J = default )
        {
	        var s = S.ToString().Remove( 0, I );
	        return J == default ? s : s.Substring( 0, Min(J.Value, s.Length) );
        }



        // Export UObject::execLen(FFrame&, void* const)
        /// <summary>
        /// Returns the length of the String, i.e. the number of characters in it.
        /// </summary>
        public /*native(125) final function */static int Len( /*coerce */ String S ) => S.ToString().Length;
        
        
	
        // Export UObject::execCaps(FFrame&, void* const)
        /// <summary>
        /// Converts all letters in S to uppercase and returns the result.
        /// </summary>
        public /*native(235) final function */static String Caps( /*coerce */ String S ) => S.ToString().ToUpperInvariant();



        // Export UObject::execRepl(FFrame&, void* const)
        /// <summary>
        /// Replaces all occurrences of Match in Src with With and returns the result. Any occurrences created as a result of a replacement are ignored. By default Match is matched case-insensitively, unless bCaseSensitive is specified as True.
        /// </summary>
        public /*native(201) final function */static String Repl( /*coerce */ String Src, /*coerce */String Match, /*coerce */String With, /*optional */bool? bCaseSensitive = default )
        {
	        if( Match == "" )
		        throw new InvalidOperationException();
	        
	        string s = Src.ToString();
	        int prevIndex = 0;
	        while(true)
	        {
		        var r = s.IndexOf(Match, prevIndex, StringComparison.InvariantCultureIgnoreCase);
		        if( r != - 1 )
		        {
			        s = s.Remove( r, Match.ToString().Length ).Insert( r, With );
			        prevIndex = r + With.ToString().Length;
			        continue;
		        }

		        break;
	        }

	        return s;
        }



        public virtual /*final function */ name GetPackageName()
        {
	        var n = this.GetType().Namespace;
	        return n.Remove( 0, n.LastIndexOf( '.' ) + 1 );
        }



        public static bool StringToBool( String s )
        {
	        LogError( $"Parsing String to bool not verified, input value:'{s}'" );
	        return s == "TRUE" || s == "true" || s == "True";
        }



        public static float StringToFloat( String s )
        {
	        LogError( $"Parsing String to float not verified, input value:'{s}'" );
	        return float.TryParse( s, out var f ) ? f : 0f;
        }



        public static int StringToInt( String s )
        {
	        LogError( $"Parsing String to int not verified, input value:'{s}'" );
	        return int.TryParse( s, out var f ) ? f : 0;
        }



        public static bool ByteToBool( byte b ) => b != 0;



        public static name GetEnum( Enum e, int index ) => System.Enum.GetNames( e.CSharpEnum )[index];



        public static MEdge.Engine.ChildConnection AsChildConnection( MEdge.Engine.Player p )
        {
	        #warning not implemented
	        return null;
        }



        public static MEdge.Engine.NetConnection AsNetConnection( MEdge.Engine.Player p )
        {
	        #warning not implemented
	        return null;
        }



        public static bool GIsEditor => false;
    }
}