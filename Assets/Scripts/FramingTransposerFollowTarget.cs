using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class FramingTransposerFollowTarget : MonoBehaviour
    {
        private Vector2 screenCentre;

        [SerializeField] private float followSpeed;

        // Update is called once per frame
        void Update()
        {
            screenCentre = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));

            transform.position = screenCentre + ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - screenCentre).normalized * followSpeed;
            screenCentre = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2), 0);

            //Vector3 vector = screenCentre + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - screenCentre);
            //float length = vector.magnitude;
            //length = Mathf.Clamp(length, 0, followSpeed);
            //transform.position = screenCentre + (vector.normalized * length);
            ////transform.position = screenCentre + ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - screenCentre).normalized * followSpeed;

        }
    }
}
