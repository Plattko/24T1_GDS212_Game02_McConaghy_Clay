using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class MomentumDamage : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D triggerCollider;
        [SerializeField] private BoxCollider2D boxCollider;
        private Rigidbody2D pickaxeRB;

        private float mass;
        private float angularVelocity;
        private float momentumDamage;
        private float power = 0.05f;

        private void Start()
        {
            pickaxeRB = transform.parent.GetComponent<Rigidbody2D>();
            mass = pickaxeRB.mass;

            //InvokeRepeating("AngularVelocity", 0f, 2f);
        }

        private void FixedUpdate()
        {
            angularVelocity = Mathf.Abs(pickaxeRB.angularVelocity);
        }

        private void AngularVelocity()
        {
            Debug.Log("<color=green>Angular velocity is: </color>" + Mathf.Abs(pickaxeRB.angularVelocity));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("<color=red>Trigger velocity was: </color>" + angularVelocity);
            Health health = collision.GetComponent<Health>();

            momentumDamage = mass * angularVelocity * 0.001f;

            if (health != null && angularVelocity > 250f && health.currentHealth < momentumDamage)
            {
                health.TakeDamage(momentumDamage);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("<color=red>Collision velocity was: </color>" + angularVelocity);
            Health health = collision.gameObject.GetComponent<Health>();

            momentumDamage = mass * angularVelocity * 0.001f * (1 + power);

            if (health != null && angularVelocity > 250f)
            {
                health.TakeDamage(momentumDamage);
            }
        }
    }
}
