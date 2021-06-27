namespace MEdge.Source
{
	using System.Runtime.CompilerServices;
	using Core;
	using Engine;
	using static UnityEngine.Debug;


	public static partial class Asset
	{
		public static ConditionalWeakTable<object, object> UScriptToUnity = new ConditionalWeakTable<object, object>();
		public static TClass LoadAsset<TClass>( String assetPath ) where TClass : new()
		{
			switch( assetPath.ToString() )
			{
				case "AS_C1P_Unarmed.AS_C1P_Unarmed":
					return (TClass)(object)Get_AS_C1P_Unarmed;
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
				if( resourceAsset is UnityEngine.Object o )
					resourceAsset = UnityEngine.Object.Instantiate( o );
			}

			if( resourceAsset is IAsset iAsset )
				return (TClass) iAsset.GetRuntimeAsset();
			else if( resourceAsset is TClass == false )
			{
				UnityEngine.Object associatedUnityObject = null;
				if( typeof(TClass) == typeof(SkeletalMesh) 
				    && resourceAsset is UnityEngine.GameObject go 
				    && go.GetComponentInChildren<UnityEngine.SkinnedMeshRenderer>() is UnityEngine.SkinnedMeshRenderer smr )
				{
					associatedUnityObject = smr;
				}

				if( associatedUnityObject != null )
				{
					var obj = new TClass();
					lock( UScriptToUnity )
						UScriptToUnity.Add( obj, associatedUnityObject );
					if( obj is Actor a && resourceAsset is UnityEngine.GameObject go2 )
					{
						var c = go2.AddComponent<ActorDrivenTransform>();
						c.Actor = a;
					}
					return obj;
				}
			}

			LogWarning($"{nameof(LoadAsset)} not implemented yet, requesting '{assetPath}'");
			return new TClass();
		}
	}
}