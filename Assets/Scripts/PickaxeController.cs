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

        [SerializeField] private float maxStationarySpin = 300f;
        [SerializeField] private float stationaryAngularDrag = 10f;
        private float defaultAngularDrag = 0.05f;
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            targetJoint = GetComponent<TargetJoint2D>();
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
            //Debug.Log(cursorPointRB.velocity.magnitude);
            if (cursorPointRB.velocity.magnitude < 30f)
            {
                rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxStationarySpin, maxStationarySpin);
            }

            //if (cursorPointRB.velocity.magnitude > 30f)
            //{
            //    Debug.Log("<color=purple>Cursor velocity: </color>" + cursorPointRB.velocity.magnitude);
            //}

            // Increase the pickaxe's gravity scale when stationary to make it rest at the bottom more quickly
            if (cursorPointRB.velocity.magnitude < 0.1f)
            {
                rb.gravityScale = 3f;

                // Additional angular drag when the pickaxe is rotated almost straight down to prevent an endless pendulum swing
                //Debug.Log(NormaliseAngle(rb.rotation));
                if (NormaliseAngle(rb.rotation) > 160f && NormaliseAngle(rb.rotation) < 200f)
                {
                    rb.angularDrag = stationaryAngularDrag;
                }
                else
                {
                    rb.angularDrag = defaultAngularDrag;
                }
            }
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
    }
}
