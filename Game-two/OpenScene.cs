using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public int level;
    AudioManager audioManagerInstance;
    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
    }
    public void OpenScenes()
    {
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().Play("Bub");
        }
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
