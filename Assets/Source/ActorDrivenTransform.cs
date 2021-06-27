namespace MEdge
{
    using Core;
    using Engine;
    using UnityEngine;

    

    public class ActorDrivenTransform : MonoBehaviour
    {
        public Actor Actor;
        void Update()
        {
            transform.SetPositionAndRotation( Actor.Location.ToUnityPos(), (Quaternion)Actor.Rotation );
        }
    }
}
