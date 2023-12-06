using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackLevels : MonoBehaviour
{
    AudioManager audioManagerInstance;
    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
    }
    public void LoadLevels()
    {
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().StopPlay("BananaCry");
            FindObjectOfType<AudioManager>().StopPlay("Happy");
            FindObjectOfType<AudioManager>().StopPlay("Wha");
            FindObjectOfType<AudioManager>().StopPlay("Eat");
            FindObjectOfType<AudioManager>().StopPlay("Upd");
            FindObjectOfType<AudioManager>().StopPlay("Upd1");
            FindObjectOfType<AudioManager>().Play("MainMusic");

        }
        SceneManager.LoadScene("LevelSelect");
    }
}
