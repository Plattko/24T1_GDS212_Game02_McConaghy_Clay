using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class RotationVelocityTest : MonoBehaviour
    {
        private TargetJoint2D targetJoint;
        private float previousRotation;
        
        private void Start()
        {
            targetJoint = GetComponent<TargetJoint2D>();
            previousRotation = GetRotation();
        }

        private void Update()
        {
            float currentRotation = GetRotation();
            float rotationChange = Mathf.DeltaAngle(currentRotation, previousRotation);
            float rotationSpeed = Mathf.Abs(rotationChange / Time.deltaTime);

            Debug.Log("Rotation speed: " + rotationSpeed);  

            // Update previous rotation for the next fixed update
            previousRotation = currentRotation;
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
