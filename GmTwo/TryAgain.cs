using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public GameObject loseCanvas;
    public Animator anim;
    AudioManager audioManagerInstance;

    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
    }

    public void SetAnim()
    {
        anim.SetTrigger("Play");
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().Play("Bub");
        }
            
    }

    public void RestartLevel()
    {
        loseCanvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().StopPlay("Wha");
            FindObjectOfType<AudioManager>().StopPlay("BananaCry");
            FindObjectOfType<AudioManager>().StopPlay("Upd");
            FindObjectOfType<AudioManager>().StopPlay("Upd1");
        }
            
    }
}
