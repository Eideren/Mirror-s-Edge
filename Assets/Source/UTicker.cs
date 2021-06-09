namespace MEdge.Assets.Source
{
	using Engine;
	using UnityEngine;
	
	public class UTicker : MonoBehaviour
	{
		public Actor ObjectToTick;
		
		void Update()
		{
			ObjectToTick?.Tick(Time.deltaTime);
		}
	}
}