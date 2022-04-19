using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CyberHogg.UI
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("MainScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
