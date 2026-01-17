using UnityEngine;

namespace com.eak.damagesystem
{
    public interface IDamageDealt
    {
        void DealDamage(IDamageReceive receiver, HitData hitData);
    }
}