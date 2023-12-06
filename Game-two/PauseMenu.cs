using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool pauseOpen = false;

    public void OpenPause()
    {
        if (!pauseOpen)
        {
            pauseMenu.SetActive(true);
            pauseOpen = true;
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            pauseOpen = false;
            Time.timeScale = 1;
        }
    }
}
