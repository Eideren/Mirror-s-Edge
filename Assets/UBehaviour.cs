namespace MEdge
{
	using Engine;
	using UnityEngine;



	public class UBehaviour : MonoBehaviour
	{
		protected virtual void Start()
		{
			UWorld.EnsureStart();
		}



		protected virtual void Update()
		{
			
		}
	}
}