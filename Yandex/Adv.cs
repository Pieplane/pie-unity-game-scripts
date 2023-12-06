using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adv : MonoBehaviour
{
    public static Adv Instance;
    //FULLSCREEN-------------------
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnOpen()
    {
        AudioListener.volume = 0;
        Debug.Log("AudioListener = 0");
    }

    public void OnClose()
    {
        AudioListener.volume = 1;
    }

    public void OnError()
    {
        OnClose();
    }

    public void OnOffline()
    {
        OnClose();
    }

    //REWARD-----------------------

    public void OnOpenReward()
    {
        AudioListener.volume = 0;
    }

    public void OnRewarded()
    {
        //¬Œ«Õ¿√–¿∆ƒ¿≈Ã
    }

    public void OnCloseReward()
    {
        AudioListener.volume = 1;
    }

    public void OnErrorReward()
    {
        OnCloseReward();
    }
}
