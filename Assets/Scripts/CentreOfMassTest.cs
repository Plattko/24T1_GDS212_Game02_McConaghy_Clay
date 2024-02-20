using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class CentreOfMassTest : MonoBehaviour
    {
        Rigidbody2D rb;
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            //Debug.DrawLine(transform.position, new Vector2(transform.position.x + 1, transform.position.y));
            Debug.DrawLine(transform.TransformPoint(rb.centerOfMass), transform.TransformPoint(new Vector3(rb.centerOfMass.x + 1, rb.centerOfMass.y, 0)));
        }
    }
}
