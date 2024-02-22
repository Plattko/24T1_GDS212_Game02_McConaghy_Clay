using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class MainMenuParallax : MonoBehaviour
    {
        [SerializeField] private float offsetMultiplier = 1f;
        [SerializeField] private float smoothTime = 0.5f;
        
        private Vector2 startPosition;
        private Vector3 velocity;
        
        void Start()
        {
            // Set the background's start position
            startPosition = transform.position;
        }

        void Update()
        {
            // Convert the mouse position in screen space to normalised viewport coordinates
            Vector2 offset = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            // Smoothly move the background towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, startPosition + (offset * offsetMultiplier), ref velocity, smoothTime);
        }
    }
}
