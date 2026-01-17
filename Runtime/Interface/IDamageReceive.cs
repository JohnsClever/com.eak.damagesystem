using UnityEngine;
namespace com.eak.damagesystem
{
    public interface IDamageReceive
    {
        void ReceiveDamage(HitData hitData);
        Vector3 GetDirectionToAttacker(Vector3 attackerPosition);
    }
}