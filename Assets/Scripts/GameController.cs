using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Plattko
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(2) && pauseMenu.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
            }
            else if (Input.GetMouseButtonDown(2) && pauseMenu.activeInHierarchy == true)
            {
                pauseMenu.SetActive(false);
            }
        }

        public void OptionsButton()
        {
            pauseMenu.SetActive(true);
        }

        public void BackButton()
        {
            pauseMenu.SetActive(false);
        }
    }
}
