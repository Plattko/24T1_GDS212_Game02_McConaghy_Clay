using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class Health : MonoBehaviour
    {
        private DamageNumber damageNumber;
        private TileController tileController;
        
        public int maxHealth;
        public float currentHealth { get; private set; }

        private void Start()
        {
            damageNumber = GetComponent<DamageNumber>();
            tileController = GetComponent<TileController>();

            currentHealth = maxHealth;
            Debug.Log("Current health: " + currentHealth);
        }

        public void TakeDamage(float damage)
        {
            Debug.Log("Damage: " + damage);
            currentHealth -= damage;
            Debug.Log("Current health: " + currentHealth);

            // Spawn damage number
            if (damageNumber != null)
            {
                damageNumber.SpawnDamageNumber(damage);
            }

            // If script is attached to a tile, update tile
            if (tileController != null)
            {
                tileController.UpdateTile(maxHealth, currentHealth);

                if (currentHealth <= 0f)
                {
                    tileController.DestroyTile();
                }
            }
        }
    }
}
