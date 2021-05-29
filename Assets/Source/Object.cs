namespace MEdge.Core
{
	using System;
	using System.Reflection;
	using static UnityEngine.Debug;



	public partial class Object
    {
        //public /*private native const noexport */Object.Pointer VfTableObject;
        //public /*private native const noexport */int ObjectInternalInteger;
        //public /*private native const */Object.QWord ObjectFlags;
        //public /*private native const */Object.Pointer HashNext;
        //public /*private native const */Object.Pointer HashOuterNext;
        //public /*private native const */Object.Pointer StateFrame;
        //public /*private native const noexport */Object Linker;
        //public /*private native const noexport */Object.Pointer LinkerIndex;
        //public /*private native const noexport */int NetIndex;
        #error Bind this properly
        public /*native const */Object Outer;
        public/*()*/ /*native const editconst */name Name;
        //public /*native const */Core.Class Class;
        //public/*()*/ /*native const editconst */Object ObjectArchetype;

        /// <summary>
        /// IN UE3:
        /// TCLASS'Package.Group(s)+.Name'
        /// </summary>
        public static TClass LoadAsset<TClass>( string assetPath ) where TClass : new()
        {
	        #warning LoadAsset not implemented yet
	        LogError($"{nameof(LoadAsset)} not implemented yet, requesting '{assetPath}'");
	        return new TClass();
        }

        // Export UObject::execDynamicLoadObject(FFrame&, void* const)
        public /*native final function */static Object DynamicLoadObject(string ObjectName, Core.Class ObjectClass, /*optional */bool MayFail = default)
        {
	        var namespaces = new string[]
	        {
		        "Engine",
		        "TdGame",
		        "Core",
		        "GameFramework",
		        "TdMenuContent",
		        "TdMpContent",
		        "TdSharedContent",
		        "TdSpBossContent",
		        "TdSpContent",
		        "TdTTContent",
		        "TdTuContent",
		        "Fp",
		        "Tp",
		        "Ts",
		        "IpDrv",
		        "TdEditor",
		        "Editor",
		        "UnrealEd",
	        };

	        Type type = Type.GetType( ObjectName );
	        for( int i = 0; i < namespaces.Length && type == null; i++ )
	        {
		        type = Type.GetType( $"{namespaces[i]}.{ObjectName}" );
	        }

	        if( type == null )
	        {
		        LogError( $"Could not {nameof(DynamicLoadObject)}({ObjectName}, {ObjectClass}), type '{ObjectName}' not found" );
		        Break();
		        return null;
	        }

	        // This should never throw, if it does the logic below is not setup properly or the type does not derive from Object
	        return typeof(_classImp<>)!
		        .MakeGenericType( type )!
		        .GetProperty( nameof(_classImp<Object>.Singleton), BindingFlags.Static | BindingFlags.Public )!
		        .GetValue( null ) as Object;
        }

        /// <summary>
        /// Ex in UE3: soundcue'Gun_Body'
        /// </summary>
        public static TClass ObjectConst<TClass>(string name) where TClass : new()
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
		        Break();
		        return default;
	        }
	        else if( typeof(Property).IsAssignableFrom( typeof(TClass) ) )
	        {
		        #warning not too sure what to do here right now, will investigate later
		        Break();
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
	        return ParentClass.IsParentOf(TestClass);
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
		public virtual /*native final function */ bool IsPendingKill();
	
        // Export UObject::execSaveConfig(FFrame&, void* const)
        public virtual /*native(536) final function */ void SaveConfig();
        
	
        // Export UObject::execLocalize(FFrame&, void* const)
        public /*native function */static string Localize(string SectionName, string KeyName, string PackageName);
	
        public delegate void BeginState_del(name PreviousStateName);
        public virtual BeginState_del BeginState { get => bfield_BeginState ?? Object_BeginState; set => bfield_BeginState = value; } BeginState_del bfield_BeginState;
        public virtual BeginState_del global_BeginState => Object_BeginState;
        public  /*event */void Object_BeginState(name PreviousStateName)
        {
			#error implement this stuff
        }
	
        public delegate void EndState_del(name NextStateName);
        public virtual EndState_del EndState { get => bfield_EndState ?? Object_EndState; set => bfield_EndState = value; } EndState_del bfield_EndState;
        public virtual EndState_del global_EndState => Object_EndState;
        public  /*event */void Object_EndState(name NextStateName)
        {
			#error implement this stuff
        }

        public bool EqualEqual_InterfaceInterface(object a, object b) => ReferenceEquals(a, b);
        public bool NotEqual_InterfaceInterface(object a, object b) => ReferenceEquals(a, b) == false;

        // Export UObject::execInStr(FFrame&, void* const)
        /// <summary>
        /// If the string needle is found inside haystack, the number of characters in haystack before the first occurance of needle is returned. That is, if the needle is found right at the beginning of haystack, 0 is returned. If haystack doesn't contain needle, InStr returns -1.
        /// </summary>
        public /*native(126) final function */static int InStr( /*coerce */ string S, /*coerce */string T, /*optional */bool bSearchFromRight = default);
	
        // Export UObject::execLeft(FFrame&, void* const)
        /// <summary>
        /// Returns the num leftmost characters of S or all of them if S contains less than num characters.
        /// </summary>
        public /*native(128) final function */static string Left( /*coerce */ string S, int I);
	
        // Export UObject::execRight(FFrame&, void* const)
        /// <summary>
        /// Returns the num rightmost characters of S or all of them if S contains less than num characters.
        /// </summary>
        public /*native(234) final function */static string Right( /*coerce */ string S, int I);

        /// Returns a substring of S, skipping skip characters and returning the next num characters or all remaining if the third parameter is left out. Mid("hello", 0, 2) returns "he", Mid("hello", 1) returns "ello", i.e. all but the first character.

        // Export UObject::execMid(FFrame&, void* const)
        public /*native(127) final function */static string Mid( /*coerce */ string S, int I, /*optional */int J = default);
        
	
        // Export UObject::execLen(FFrame&, void* const)
        /// <summary>
        /// Returns the length of the string, i.e. the number of characters in it.
        /// </summary>
        public /*native(125) final function */static int Len( /*coerce */ string S);
        
        
	
        // Export UObject::execCaps(FFrame&, void* const)
        public /*native(235) final function */static string Caps( /*coerce */ string S );
	
		public virtual /*final function */name GetPackageName()



        public static bool StringToBool( string s )
        {
	        LogError( $"Parsing string to bool not verified, input value:'{s}'" );
	        return s == "TRUE" || s == "true" || s == "True";
        }



        public static float StringToFloat( string s )
        {
	        LogError( $"Parsing string to float not verified, input value:'{s}'" );
	        return float.TryParse( s, out var f ) ? f : 0f;
        }



        public static int StringToInt( string s )
        {
	        LogError( $"Parsing string to int not verified, input value:'{s}'" );
	        return int.TryParse( s, out var f ) ? f : 0;
        }



        public static bool ByteToBool( byte b )
        {
	        
        }



        public static name GetEnum( Enum e, int index ) => System.Enum.GetNames( e.CSharpEnum )[index];
        
        
        public static MEdge.Engine.ChildConnection AsChildConnection(MEdge.Engine.Player p)
        
        
        public static MEdge.Engine.NetConnection AsNetConnection(MEdge.Engine.Player p)
	
        // Export UObject::execRepl(FFrame&, void* const)
        /// <summary>
        /// Replaces all occurrences of Match in string Src. Specify true for bCaseSensitive if matching should be case-sensitive.
        /// </summary>
        public /*native(201) final function */static string Repl(/*coerce */string Src, /*coerce */string Match, /*coerce */string With, /*optional */bool bCaseSensitive = default)
    }
}