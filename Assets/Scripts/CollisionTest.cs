using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class CollisionTest : MonoBehaviour
    {
        Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("<color=red>Angular velocity was: </color>" + rb.angularVelocity);
            Debug.Log("<color=red>Velocity was: </color>" + rb.velocity);
        }
    }
}
