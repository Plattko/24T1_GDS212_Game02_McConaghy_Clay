using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class PointsManager : MonoBehaviour
    {
        public delegate void PointUpdateEventHandler(int newPoints);
        public static event PointUpdateEventHandler OnPointUpdate;
        
        public static void UpdatePoints(int points)
        {
            OnPointUpdate?.Invoke(points);
        }
    }
}
