using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Plattko
{
    public class DamageNumber : MonoBehaviour
    {
        [SerializeField] private GameObject damageNumberPrefab;

        public void SpawnDamageNumber(float damage)
        {
            Debug.Log("Spawned damage number.");
            // Set spawn position to slightly above the transform position
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + 1f);
            // Instantiate the damage number at the spawn position
            GameObject damageNumber = Instantiate(damageNumberPrefab, spawnPosition, Quaternion.identity);
            // Set the damage number text to the damage dealt
            damageNumber.transform.GetChild(0).GetComponent<TextMeshPro>().text = Mathf.RoundToInt(damage).ToString();
            // Destroy the damage number after 2 seconds
            Destroy(damageNumber, 2f);
        }
    }
}
