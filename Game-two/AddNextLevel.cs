using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddNextLevel : MonoBehaviour
{
    public Animator anim;
    int levelToUnlock = 0;
    int levelalready;
    AudioManager audioManagerInstance;

    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
        levelToUnlock = SceneManager.GetActiveScene().buildIndex;
    }
    public void SetAnim()
    {
        anim.SetTrigger("Play");
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().Play("Bub");
        }
            
    }
    public void NextLevel()
    {
        levelalready = PlayerPrefs.GetInt("levelReached");
        if(levelToUnlock > levelalready)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().StopPlay("Happy");
        }
        
    }
}
