using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Plattko
{
    public class PointsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pointsText;

        private Coroutine CountTo;

        private float countDuration = 1f;
        private float currentPoints = 0f;
        private float targetPoints = 0f;

        private void OnEnable()
        {
            PointsManager.OnPointUpdate += UpdatePointsText;
        }

        private void OnDisable()
        {
            PointsManager.OnPointUpdate -= UpdatePointsText;
        }

        private void UpdatePointsText(int pointsRewarded)
        {
            // Get target point value
            targetPoints += pointsRewarded;
            
            // Stop the current count to new points coroutine
            if (CountTo != null)
            {
                StopCoroutine(CountTo);
            }

            // Start the count to new points coroutine and assign it to the CountTo coroutine
            CountTo = StartCoroutine(CountToNewPoints(targetPoints));
        }

        private IEnumerator CountToNewPoints(float targetPoints)
        {
            // Set the rate to increase the points within the count duration
            float rate = Mathf.Abs(targetPoints - currentPoints) / countDuration;

            while (currentPoints != targetPoints)
            {
                currentPoints = Mathf.MoveTowards(currentPoints, targetPoints, rate * Time.deltaTime);
                pointsText.text = ((int)currentPoints).ToString();
                yield return null;
            }
        }
    }
}
