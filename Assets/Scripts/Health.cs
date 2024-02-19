using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class Health : MonoBehaviour
    {
        public int maxHealth;
        public float currentHealth { get; private set; }

        private void Start()
        {
            currentHealth = maxHealth;
            Debug.Log("Current health: " + currentHealth);
        }

        public void TakeDamage(float damage)
        {
            Debug.Log("Damage: " + damage);
            currentHealth -= damage;
            Debug.Log("Current health: " + currentHealth);

            // Spawn damage number
            DamageNumber damageNumber = GetComponent<DamageNumber>();
            if (damageNumber != null)
            {
                GetComponent<DamageNumber>().SpawnDamageNumber(damage);
            }

            if (currentHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
