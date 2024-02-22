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
        [SerializeField] private TextMeshProUGUI pointsAddedText;
        [SerializeField] private Animator pointsAddedAnimator;

        private Coroutine PointsTextC2;
        private Coroutine PointsAddedC2;

        private float pointsTextCountDuration = 1f;
        private float currentPoints = 0f;
        private float targetPoints = 0f;

        private float pointsAddedCountDuration = 0.2f;
        private float currentPointsAdded = 0f;
        private float targetPointsAdded = 0f;

        private void Start()
        {
            pointsAddedText.alpha = 0f;
        }

        private void OnEnable()
        {
            PointsManager.OnPointUpdate += UpdatePointsText;
            PointsManager.OnPointUpdate += UpdatePointsAddedText;
        }

        private void OnDisable()
        {
            PointsManager.OnPointUpdate -= UpdatePointsText;
            PointsManager.OnPointUpdate -= UpdatePointsAddedText;
        }

        private void UpdatePointsText(int pointsRewarded)
        {
            // Get target point value
            targetPoints += pointsRewarded;
            
            // Stop the current count to new points coroutine
            if (PointsTextC2 != null)
            {
                StopCoroutine(PointsTextC2);
            }

            // Start the count to new points coroutine and assign it to the CountTo coroutine
            PointsTextC2 = StartCoroutine(CountToNewPoints(targetPoints));
        }

        private IEnumerator CountToNewPoints(float targetPoints)
        {
            // Set the rate to increase the points within the count duration
            float rate = Mathf.Abs(targetPoints - currentPoints) / pointsTextCountDuration;

            while (currentPoints != targetPoints)
            {
                currentPoints = Mathf.MoveTowards(currentPoints, targetPoints, rate * Time.deltaTime);
                pointsText.text = ((int)currentPoints).ToString();
                yield return null;
            }
        }

        private void UpdatePointsAddedText(int pointsRewarded)
        {
            // Update points added value
            targetPointsAdded += pointsRewarded;

            // Stop the current count to points added coroutine
            if (PointsAddedC2 != null)
            {
                StopCoroutine(PointsAddedC2);
            }

            // Start the count to new points coroutine and assign it to the CountTo coroutine
            PointsAddedC2 = StartCoroutine(CountToAddedPoints(targetPointsAdded));
        }

        private IEnumerator CountToAddedPoints(float targetPointsAdded)
        {
            // Play the points added animation
            if (!pointsAddedAnimator.enabled)
            {
                pointsAddedAnimator.enabled = true;
            }
            else
            {
                pointsAddedAnimator.Play("PointsAddedNumber", -1, 0);
                Debug.Log("Else statement");
            }

            // Set the rate to increase the points within the count duration
            float rate = Mathf.Abs(targetPointsAdded - currentPointsAdded) / pointsAddedCountDuration;

            while (currentPointsAdded != targetPointsAdded)
            {
                currentPointsAdded = Mathf.MoveTowards(currentPointsAdded, targetPointsAdded, rate * Time.deltaTime);
                pointsAddedText.text = ("+" + (int)currentPointsAdded).ToString();
                yield return null;
            }
        }

        public void ResetPointsAdded()
        {
            currentPointsAdded = 0f;
            targetPointsAdded = 0f;
            Debug.Log("ResetPointsAdded was called.");
        }
    }
}
