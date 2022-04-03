using MEdge.Core;
using MEdge.Engine;
using MEdge.TdGame;
using UnityEngine;
using UnityEngine.Events;

namespace MEdge.Source
{
    /// <summary> This doesn't exist in source, just for level design in unity </summary>
    public class Unity_BargeTarget : VolumeProxy<UnityBargeProxy>
    {
        /// <summary>
        /// First vector is the position of impact and second is the direction
        /// </summary>
        public UnityEvent<TdPlayerController, Vector3, Vector3> OnBarge;
        protected override void SyncVolume(UnityBargeProxy volume)
        {
            volume.LinkedUnityObject = this;
            volume.bInteractable = true;
        }
    }

    public class UnityBargeProxy : PhysicsVolume
    {
        public Unity_BargeTarget LinkedUnityObject;
        public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? Proxy_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
        public override TakeDamage_del global_TakeDamage => Proxy_TakeDamage;

        public /*event */ void Proxy_TakeDamage(int DamageAmount, Controller EventInstigator,
            Core.Object.Vector HitLocation, Core.Object.Vector Momentum,
            Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */
            Actor _DamageCauser = default)
        {
            LinkedUnityObject.OnBarge.Invoke( (TdPlayerController)EventInstigator, HitLocation.ToUnityPos(), Momentum.ToUnityDir() );
        }
    }
}
