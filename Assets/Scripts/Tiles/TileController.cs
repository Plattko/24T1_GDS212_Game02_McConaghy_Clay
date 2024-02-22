using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class TileController : MonoBehaviour
    {
        [SerializeField] private Sprite[] sprites;
        private BoxCollider2D boxCollider;
        private SpriteRenderer spriteRenderer;

        [SerializeField] private int maxPoints;
        private int pointsRewarded;
        private int timesHitCounter = 0;
        private float destroyDelay = 2f;
        
        void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            pointsRewarded = maxPoints;
        }

        public void UpdateTile(float maxHealth, float currentHealth)
        {
            float healthPercentage = currentHealth / maxHealth;
            
            // Update the sprite to represent how damaged the tile is
            if (healthPercentage < 1f && healthPercentage > 0.67f)
            {
                spriteRenderer.sprite = sprites[1];

                // Play destruction SFX
            }
            else if (healthPercentage <= 0.67f && healthPercentage > 0.33f)
            {
                spriteRenderer.sprite = sprites[2];

                // Play destruction SFX
            }
            else if (healthPercentage <= 0.33f && healthPercentage > 0f)
            {
                spriteRenderer.sprite = sprites[3];

                // Play destruction SFX
            }

            // Increase the number of times the tile has been hit
            timesHitCounter++;
        }

        public void DestroyTile()
        {
            // Disable collider and sprite renderer
            boxCollider.enabled = false;
            spriteRenderer.enabled = false;

            // Play destruction SFX

            // Play destruction particle effect

            // Give points based on number of times the tile was hit and its max point reward
            for (int i = 0; i < timesHitCounter - 1; i++)
            {
                pointsRewarded = Mathf.RoundToInt(pointsRewarded * 0.9f);
                Debug.Log(i);
            }
            pointsRewarded = Mathf.Clamp(pointsRewarded, Mathf.RoundToInt(maxPoints * 0.5f), maxPoints);

            PointsManager.UpdatePoints(pointsRewarded);
            
            Debug.Log("Times hit: " + timesHitCounter);
            Debug.Log("Points rewarded: " + pointsRewarded);

            // Destroy tile after delay
            Destroy(gameObject, destroyDelay);
        }
    }
}
