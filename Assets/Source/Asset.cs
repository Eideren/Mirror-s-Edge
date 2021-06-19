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

			if( resourceAsset is IAsset iAsset )
				return (TClass) iAsset.GetRuntimeAsset();
			else if( resourceAsset is TClass == false )
			{
				if( typeof(TClass) == typeof(SkeletalMesh) 
				    && resourceAsset is UnityEngine.GameObject go 
				    && go.GetComponent<UnityEngine.SkinnedMeshRenderer>() is UnityEngine.SkinnedMeshRenderer smr )
				{
					lock( UScriptToUnity )
					{
						var obj = new TClass();
						UScriptToUnity.Add( obj, smr );
						return obj;
					}
				}
			}

			#warning LoadAsset not implemented yet
			LogError($"{nameof(LoadAsset)} not implemented yet, requesting '{assetPath}'");

			return new TClass();
		}
	}
}