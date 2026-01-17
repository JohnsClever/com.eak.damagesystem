using UnityEngine;
using UnityEngine.Events;
using com.eak.charactermovement;
namespace com.eak.damagesystem
{
    public class HurtBoxController : MonoBehaviour, IDamageReceive
    {
        public UnityEvent<HitData> OnHurt;
        public Vector3 GetDirectionToAttacker(Vector3 attackerPosition)
        {
            return (transform.position - attackerPosition).normalized;
        }

        public void ReceiveDamage(HitData hitData)
        {
            OnHurt?.Invoke(hitData);
        }
    }
}