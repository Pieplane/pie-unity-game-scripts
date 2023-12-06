using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtown : MonoBehaviour
{
    AudioManager audioManagerInstance;
    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
    }
    public void Restart()
    {
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().StopPlay("Happy");
            FindObjectOfType<AudioManager>().StopPlay("Wha");
            FindObjectOfType<AudioManager>().StopPlay("Upd");
            FindObjectOfType<AudioManager>().StopPlay("Upd1");
            FindObjectOfType<AudioManager>().StopPlay("BananaCry");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
