using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public Animator backAnim;
    //public Animator pauseAnim;
    public Animator restartAnim;
    public Animator skipAnim;
    AudioManager audioManagerInstance;

    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
    }

    public void BackAnim()
    {
        backAnim.SetTrigger("Play");
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().Play("Bub");
        }
            
    }
    public void PauseAnim()
    {
        //pauseAnim.SetTrigger("Pause");
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().Play("Bub");
        }
            

    }
    public void RestartAnim()
    {
        restartAnim.SetTrigger("Play");
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().Play("Bub");
        }
            
    }
    public void SkipAnim()
    {
        skipAnim.SetTrigger("Play");
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().Play("Bub");
        }
            
    }
    
}
