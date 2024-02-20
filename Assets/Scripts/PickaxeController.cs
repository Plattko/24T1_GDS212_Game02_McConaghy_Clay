using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class PickaxeController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D cursorPointRB;
        [SerializeField] private TargetJoint2D cursorPointTargetJoint;

        private Rigidbody2D rb;
        private TargetJoint2D targetJoint;

        private Vector3 mouseWorldPos;

        [SerializeField] private float maxSpin = 300f;
        [SerializeField] private float stationaryAngularDrag = 10f;
        private float defaultAngularDrag = 0.05f;

        private float previousRotation;
        public float rotationSpeed;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            targetJoint = GetComponent<TargetJoint2D>();
            previousRotation = GetRotation();
        }

        void Update()
        {
            // Get mouse position
            mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            // Set target position of both the cursor point and pickaxe to the mouse's world position
            targetJoint.target = mouseWorldPos;
            cursorPointTargetJoint.target = mouseWorldPos;

            // Clamp the pickaxe's maximum angular velocity to prevent it from spinning too much
            rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxSpin, maxSpin);

            // Increase the pickaxe's gravity scale when stationary to make it rest at the bottom more quickly
            if (cursorPointRB.velocity.magnitude < 0.1f)
            {
                rb.gravityScale = 3f;

                // Additional angular drag when the pickaxe is rotated almost straight down to prevent an endless pendulum swing
                if (NormaliseAngle(rb.rotation) > 160f && NormaliseAngle(rb.rotation) < 200f)
                {
                    rb.angularDrag = stationaryAngularDrag;
                }
                else
                {
                    rb.angularDrag = defaultAngularDrag;
                }
            }

            float currentRotation = GetRotation();
            float rotationChange = Mathf.DeltaAngle(currentRotation, previousRotation);
            rotationSpeed = Mathf.Abs(rotationChange / Time.deltaTime);

            //Debug.Log("Rotation speed: " + rotationSpeed);

            // Update previous rotation for the next update
            previousRotation = currentRotation;
        }

        private float NormaliseAngle(float angle)
        {
            // Use modulo to get the remainder when divided by 360
            angle %= 360;

            // If the angle is negative, make it positive
            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }

        private float GetRotation()
        {
            Vector2 directionToTarget = targetJoint.target - (Vector2)transform.position;
            // Get the angle in degrees 
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

            return angle;
        }
    }
}
