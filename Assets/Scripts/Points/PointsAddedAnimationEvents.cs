using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plattko
{
    public class PointsAddedAnimationEvents : MonoBehaviour
    {
        [SerializeField] PointsUI pointsUI;
        
        public void AnimationEnded()
        {
            pointsUI.ResetPointsAdded();
        }
    }
}
