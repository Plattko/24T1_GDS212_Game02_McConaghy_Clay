using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Plattko
{
    public class MomentumDamage : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D triggerCollider;
        [SerializeField] private BoxCollider2D boxCollider;
        private Rigidbody2D pickaxeRB;
        private PickaxeController pickaxeController;

        // Damage variables
        private float mass;
        private float momentumDamage;
        private float velocityToDamage = 0.0002f;
        private float pickaxePower = 0.05f;

        [SerializeField] private float minimumRotationSpeed = 500f;

        private List<float> averageTriggerVelocity = new List<float>();
        private List<float> averageCollisionVelocity = new List<float>();

        void Start()
        {
            pickaxeRB = transform.parent.GetComponent<Rigidbody2D>();
            pickaxeController = transform.parent.GetComponent<PickaxeController>();
            mass = pickaxeRB.mass;
        }

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    Debug.Log("<color=orange>[Momentum Damage] Trigger velocity was: </color>" + pickaxeController.rotationSpeed);
        //    //float velocityValue = pickaxeController.rotationSpeed;
        //    //averageTriggerVelocity.Add(velocityValue);
        //    //Debug.Log("<color=orange>[Momentum Damage] Average trigger velocity: </color>" + averageTriggerVelocity.Average());

        //    // Get the other collider's Health script
        //    Health health = collision.GetComponent<Health>();

        //    // Calculate momentum damage
        //    momentumDamage = mass * pickaxeController.rotationSpeed * velocityToDamage * (1 + pickaxePower);

        //    // Deal damage
        //    if (health != null && pickaxeController.rotationSpeed > minimumRotationSpeed && health.currentHealth < momentumDamage)
        //    {
        //        health.TakeDamage(momentumDamage);
        //    }
        //}

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("<color=red>[Momentum Damage] Collision velocity was: </color>" + pickaxeController.rotationSpeed);
            //float velocityValue = pickaxeController.rotationSpeed;
            //averageCollisionVelocity.Add(velocityValue);
            //Debug.Log("<color=red>[Momentum Damage] Average collision velocity: </color>" + averageCollisionVelocity.Average());

            // Get the other collider's Health script
            Health health = collision.gameObject.GetComponent<Health>();

            // Calculate momentum damage
            momentumDamage = mass * pickaxeController.rotationSpeed * velocityToDamage * (1 + pickaxePower);

            // Deal damage
            if (health != null && pickaxeController.rotationSpeed > minimumRotationSpeed)
            {
                health.TakeDamage(momentumDamage);
            }
        }
    }
}
