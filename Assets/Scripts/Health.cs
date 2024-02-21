using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class Health : MonoBehaviour
    {
        private SFXManager sfxManager;
        
        private DamageNumber damageNumber;
        private TileController tileController;
        private SFXHolder sfxHolder;
        
        public int maxHealth;
        public float currentHealth { get; private set; }

        private float invincibilityTime = 0.1f;
        private bool canBeHit = true;

        private void Start()
        {
            sfxManager = GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SFXManager>();
            
            damageNumber = GetComponent<DamageNumber>();
            tileController = GetComponent<TileController>();
            sfxHolder = GetComponent<SFXHolder>();

            currentHealth = maxHealth;
            Debug.Log("Current health: " + currentHealth);
        }

        public void TakeDamage(float damage)
        {
            if (!canBeHit) return;
            
            Debug.Log("Damage: " + damage);
            currentHealth -= damage;
            Debug.Log("Current health: " + currentHealth);

            // Spawn damage number
            if (damageNumber != null)
            {
                damageNumber.SpawnDamageNumber(damage);
            }

            if (sfxHolder != null)
            {
                sfxManager.PlayRandomSoundEffect(sfxHolder.collisionSFX, transform, 1f);
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

            StartCoroutine(TemporaryInvincibility());
        }

        private IEnumerator TemporaryInvincibility()
        {
            canBeHit = false;
            yield return new WaitForSeconds(invincibilityTime);
            canBeHit = true;
        }
    }
}
