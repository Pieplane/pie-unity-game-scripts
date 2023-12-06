using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class What : MonoBehaviour
{
    public GameObject loseCanvas;
    public GameObject winCanvas;
    bool startWha = false;
    bool startHappy = false;
    AudioManager audioManagerInstance;

    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if (loseCanvas.activeSelf && !startWha)
        {
            startWha = true;
            if (audioManagerInstance != null)
            {
                PlayWha();
                winCanvas.SetActive(false);
            }
                
            Debug.Log("OpenLoseCanvas");
        }  
        else if (winCanvas.activeSelf && !startHappy)
        {
            startHappy = true;
            if (audioManagerInstance != null)
            {
                PlayHappy();
                loseCanvas.SetActive(false);
            }
                
        }
    }

    void PlayWha()
    {
        FindObjectOfType<AudioManager>().Play("Wha");
    }
    void PlayHappy()
    {
        FindObjectOfType<AudioManager>().Play("Happy");
    }
}
