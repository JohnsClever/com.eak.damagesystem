using com.eak.damagesystem;
using UnityEngine;

namespace com.eak.damagesystem
{
    public class TrapDamage : MonoBehaviour, IDamageDealt
    {
        public float damageAmount = 1;
        public float knockBackForce = 3;
        public void DealDamage(IDamageReceive receiver, HitData hitData)
        {
            receiver.ReceiveDamage(hitData);
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamageReceive>(out var damageReceiver))
            {
                HitData hitData = new HitDataKnockBackBuilder()
                .SetDamage(damageAmount)
                .SetHitDirection(damageReceiver.GetDirectionToAttacker(transform.position))
                .SetHitPoint(other.ClosestPoint(transform.position))
                .SetKnockbackForce(knockBackForce)
                .Build();

                DealDamage(damageReceiver, hitData);
            }
        }
    }
}