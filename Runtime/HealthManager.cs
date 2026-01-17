using UnityEngine;
using UnityEngine.Events;

namespace com.eak.damagesystem
{
    public class HealthManager : MonoBehaviour
    {
        public bool verbose = false;
        public float maxHealth = 10;
        public float health = 10f;
        public UnityEvent OnDeath;
        public void ReceiveDamage(HitData hitData)
        {
            health -= hitData.damage;
            if (verbose) Debug.Log($"Received {hitData.damage} damage. Remaining health: {health}");
            if (health <= 0)
            {
                health = 0;
                Die();
            }
        }
        public void RestoreHealth(float amount)
        {
            health += amount;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            if (verbose) Debug.Log($"Restored {amount} health. Current health: {health}");
        }
        public void Die()
        {
            OnDeath?.Invoke();
            if (verbose) Debug.Log("Entity has died.");
        }
    }
}