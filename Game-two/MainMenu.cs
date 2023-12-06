using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    AudioManager audioManagerInstance;

    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
    }
    public void PlayAnim()
    {
        anim.SetTrigger("Play");
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().Play("Bub");
        }
            
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
