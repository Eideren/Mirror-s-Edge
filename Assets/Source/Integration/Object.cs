namespace MEdge.Core
{
	using System;
	using System.Reflection;
	using Engine;
	using static UnityEngine.Debug;


	[Serializable]
	public partial class Object
	{
		public static readonly name NAME_None = default;
		public const bool GIsGame = true;
		public const bool TRUE = true;
		public const bool FALSE = false;
		public const object NULL = null;
	
		public const float ZERO_ANIMWEIGHT_THRESH = (0.00001f);
		public static void verify(bool b) => UnityEngine.Debug.Assert( b );
		public static void check(bool b) => UnityEngine.Debug.Assert(b);
		public static void checkf( bool b, params object[] os ) => UnityEngine.Debug.Assert(b);
		public static void checkSlow(bool b) => UnityEngine.Debug.Assert(b);
		public static void debugf( string str, params object[] p ) => UnityEngine.Debug.Log( str );
		public static string TEXT( string s ) => s;
		
		public static implicit operator bool(Object o) => o != null;
		
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
		public virtual /*native final function */ bool IsPendingKill() => HasAnyFlags(EObjectFlags.RF_PendingKill);
		
		public bool HasAnyFlags( EObjectFlags FlagsToCheck )
		{
			return (ObjectFlags & FlagsToCheck) != 0 || FlagsToCheck == EObjectFlags.RF_AllFlags;
		}
		
		[Flags]
		public enum EObjectFlags : ulong
		{
			RF_InSingularFunc = (0x0000000000000002),		// In a singular function.
			RF_StateChanged = (0x0000000000000004),		// Object did a state change.
			RF_DebugPostLoad = (0x0000000000000008),		// For debugging PostLoad calls.
			RF_DebugSerialize = (0x0000000000000010),		// For debugging Serialize calls.
			RF_DebugFinishDestroyed = (0x0000000000000020),		// For debugging FinishDestroy calls.
			RF_EdSelected = (0x0000000000000040),		// Object is selected in one of the editors browser windows.
			RF_ZombieComponent = (0x0000000000000080),		// This component's template was deleted, so should not be used.
			RF_Protected = (0x0000000000000100),		// Property is protected (may only be accessed from its owner class or subclasses)
			RF_ClassDefaultObject = (0x0000000000000200),		// this object is its class's default object
			RF_ArchetypeObject = (0x0000000000000400),		// this object is a template for another object - treat like a class default object
			RF_ForceTagExp = (0x0000000000000800),		// Forces this object to be put into the export table when saving a package regardless of outer
			RF_TokenStreamAssembled = (0x0000000000001000),		// Set if reference token stream has already been assembled
			RF_MisalignedObject = (0x0000000000002000),		// Object's size no longer matches the size of its C++ class (only used during make, for native classes whose properties have changed)
			RF_RootSet = (0x0000000000004000),		// Object will not be garbage collected, even if unreferenced.
			RF_BeginDestroyed = (0x0000000000008000),		// BeginDestroy has been called on the object.
			RF_FinishDestroyed = (0x0000000000010000),		// FinishDestroy has been called on the object.
			RF_DebugBeginDestroyed = (0x0000000000020000),		// Whether object is rooted as being part of the root set (garbage collection)
			RF_MarkedByCooker = (0x0000000000040000),		// Marked by content cooker.
			RF_LocalizedResource = (0x0000000000080000),		// Whether resource object is localized.
			RF_InitializedProps = (0x0000000000100000),		// whether InitProperties has been called on this object
			RF_PendingFieldPatches = (0x0000000000200000),		//@script patcher: indicates that this struct will receive additional member properties from the script patcher
			// unused							DECLARE_UINT64(0x0000000000400000)
			// unused							DECLARE_UINT64(0x0000000000800000)
			// unused							DECLARE_UINT64(0x0000000001000000)
			// unused							DECLARE_UINT64(0x0000000002000000)
			// unused							DECLARE_UINT64(0x0000000004000000)
			// unused							DECLARE_UINT64(0x0000000008000000)
			// unused							DECLARE_UINT64(0x0000000010000000)
			// unused							DECLARE_UINT64(0x0000000020000000)
			// unused							DECLARE_UINT64(0x0000000040000000)
			RF_Saved = (0x0000000080000000),		// Object has been saved via SavePackage. Temporary.
			RF_Transactional = (0x0000000100000000),		// Object is transactional.
			RF_Unreachable = (0x0000000200000000),		// Object is not reachable on the object graph.
			RF_Public = (0x0000000400000000),		// Object is visible outside its package.
			RF_TagImp = (0x0000000800000000),		// Temporary import tag in load/save.
			RF_TagExp = (0x0000001000000000),		// Temporary export tag in load/save.
			RF_Obsolete = (0x0000002000000000),		// Object marked as obsolete and should be replaced.
			RF_TagGarbage = (0x0000004000000000),		// Check during garbage collection.
			RF_DisregardForGC = (0x0000008000000000),		// Object is being disregard for GC as its static and itself and all references are always loaded.
			RF_PerObjectLocalized = (0x0000010000000000),		// Object is localized by instance name, not by class.
			RF_NeedLoad = (0x0000020000000000),		// During load, indicates object needs loading.
			RF_AsyncLoading = (0x0000040000000000),		// Object is being asynchronously loaded.
			RF_NeedPostLoadSubobjects = (0x0000080000000000),		// During load, indicates that the object still needs to instance subobjects and fixup serialized component references
			RF_Suppress = (0x0000100000000000),		// @warning: Mirrored in UnName.h. Suppressed log name.
			RF_InEndState = (0x0000200000000000),		// Within an EndState call.
			RF_Transient = (0x0000400000000000),		// Don't save object.
			RF_Cooked = (0x0000800000000000),		// Whether the object has already been cooked
			RF_LoadForClient = (0x0001000000000000),		// In-file load for client.
			RF_LoadForServer = (0x0002000000000000),		// In-file load for client.
			RF_LoadForEdit = (0x0004000000000000),		// In-file load for client.
			RF_Standalone = (0x0008000000000000),		// Keep object around for editing even if unreferenced.
			RF_NotForClient = (0x0010000000000000),		// Don't load this object for the game client.
			RF_NotForServer = (0x0020000000000000),		// Don't load this object for the game server.
			RF_NotForEdit = (0x0040000000000000),		// Don't load this object for the editor.
			// unused							DECLARE_UINT64(0x0080000000000000)
			RF_NeedPostLoad = (0x0100000000000000),		// Object needs to be postloaded.
			RF_HasStack = (0x0200000000000000),		// Has execution stack.
			RF_Native = (0x0400000000000000),		// Native (UClass only).
			RF_Marked = (0x0800000000000000),		// Marked (for debugging).
			RF_ErrorShutdown = (0x1000000000000000),		// ShutdownAfterError called.
			RF_PendingKill = (0x2000000000000000),		// Objects that are pending destruction (invalid for gameplay but valid objects)
			// unused							DECLARE_UINT64(0x4000000000000000)
			// unused							DECLARE_UINT64(0x8000000000000000)
			RF_AllFlags = 0xFFFFFFFFFFFFFFFF,
		};

	
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
	        // UObject::execStringToBool in UnCorSc
	        return s == "TRUE" || s == "true" || s == "True" || s == "Yes" || (int.TryParse(s, out var intV) && intV != 0);
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