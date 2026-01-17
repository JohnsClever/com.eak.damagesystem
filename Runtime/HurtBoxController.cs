using UnityEngine;
using UnityEngine.Events;

namespace com.eak.damagesystem
{
    public class HurtBoxController : MonoBehaviour, IDamageReceive
    {
        [SerializeField] CharacterMovementController characterMovementController;
        public UnityEvent<HitData> OnHurt;
        public Vector3 GetDirectionToAttacker(Vector3 attackerPosition)
        {
            return (transform.position - attackerPosition).normalized;
        }

        public void ReceiveDamage(HitData hitData)
        {
            OnHurt?.Invoke(hitData);
            if (hitData is HitDataKnockBack hitDataDirection && characterMovementController != null)
            {
                characterMovementController.AddForce(hitDataDirection.hitDirection * hitDataDirection.knockbackForce, 0.2f);
            }
        }
    }
}