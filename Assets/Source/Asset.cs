namespace MEdge.Source
{
	using System.Runtime.CompilerServices;
	using Core;
	using Engine;
	using static UnityEngine.Debug;


	public static partial class Asset
	{
		public static ConditionalWeakTable<object, object> UnrealToUnityAsset = new ConditionalWeakTable<object, object>();
		public static TClass LoadAsset<TClass>( String assetPath ) where TClass : new()
		{
			#warning LoadAsset not implemented yet
			LogError($"{nameof(LoadAsset)} not implemented yet, requesting '{assetPath}'");

			var instance = new TClass();
			lock( UnrealToUnityAsset )
				UnrealToUnityAsset.Add(instance, assetPath);
			

			return instance;
		}
	}
}