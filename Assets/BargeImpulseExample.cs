using MEdge.TdGame;
using UnityEngine;

namespace MEdge
{
    public class BargeImpulseExample : MonoBehaviour
    {
        public float Force = 60f;
        public Rigidbody Body;

        public void ApplyImpulseOnBody(TdPlayerController controller, Vector3 impactPos, Vector3 impactDir)
        {
            Body.AddForce( (impactDir + Vector3.up * 0.25f) * Force, ForceMode.Impulse );
        }
    }
}
