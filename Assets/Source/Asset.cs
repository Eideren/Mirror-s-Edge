namespace MEdge.Source
{
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;
	using Core;
	using Engine;
	using static UnityEngine.Debug;


	public static partial class Asset
	{
		public static HashSet<string> NotImplementedFor = new HashSet<string>();
		public static ConditionalWeakTable<object, UnityEngine.Object> UScriptToUnity = new();



		public static TClass LoadAsset<TClass>( String assetPath ) where TClass : new()
		{
			switch( assetPath.ToString() )
			{
				case "AS_C1P_Unarmed.AS_C1P_Unarmed":
					return (TClass)(object)Get_AS_C1P_Unarmed();
				case "AS_F3P_Unarmed.AS_F3P_Unarmed":
					return (TClass)(object)Get_AS_F3P_Unarmed();
			}
			

			var splits = assetPath.ToString().Split( '.' );
			string path = assetPath.ToString();
			// Ex: 'AT_C1P.AT_C1P'
			if( splits.Length == 2 && splits[ 0 ] == splits[ 1 ] )
			{
				path = splits[ 0 ];
			}

			object resourceAsset;
			try
			{
				resourceAsset = UnityEngine.Resources.Load( path.Replace( '.', '/' ) );
			}
			catch(System.Exception e)
			{
				LogError( e );
				return new TClass();
			}

			if( Class.InSpawningDefault == 0 )
			{
				if( resourceAsset is UnityEngine.Object asUnityObj )
					resourceAsset = UnityEngine.Object.Instantiate( asUnityObj );
			}

			if( resourceAsset is IAsset iAsset )
				return (TClass) iAsset.GetRuntimeAsset();
			else if( resourceAsset is TClass == false )
			{
				UnityEngine.Object associatedUnityObject = null;
				if( typeof(TClass) == typeof(SkeletalMesh) 
				    && resourceAsset is UnityEngine.GameObject prefabRoot 
				    && prefabRoot.GetComponentInChildren<UnityEngine.SkinnedMeshRenderer>() is UnityEngine.SkinnedMeshRenderer smr )
				{
					associatedUnityObject = smr;
				}

				if( associatedUnityObject != null )
				{
					var unrealObj = new TClass();
					lock( UScriptToUnity )
						UScriptToUnity.Add( unrealObj, associatedUnityObject );
					return unrealObj;
				}
			}

			NotImplementedFor.Add( assetPath );
			LogWarning($"{nameof(LoadAsset)} not implemented yet, requesting '{assetPath}'");
			return new TClass();
		}
	}
}