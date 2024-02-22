using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class PlayerPoints : MonoBehaviour
    {
        [SerializeField] private int momentumPoints = 0;

        private void OnEnable()
        {
            PointsManager.OnPointUpdate += UpdatePlayerPoints;
        }

        private void OnDisable()
        {
            PointsManager.OnPointUpdate -= UpdatePlayerPoints;
        }

        private void UpdatePlayerPoints(int pointsRewarded)
        {
            // Increase the player's momentum points by the number of points rewarded
            momentumPoints += pointsRewarded;
        }
    }
}
