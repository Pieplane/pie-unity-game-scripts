using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipLevel : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowReward();
    //VideoSkip videoSkip;
    AudioManager audioManagerInstance;

    public static bool wantnext = false;
    private void Start()
    {
        wantnext = false;
        audioManagerInstance = FindObjectOfType<AudioManager>();
        //videoSkip = FindObjectOfType<VideoSkip>();
    }

    void SkipForAd()
    {
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().StopPlay("Happy");
            FindObjectOfType<AudioManager>().StopPlay("Eat");
            FindObjectOfType<AudioManager>().StopPlay("BananaCry");
            FindObjectOfType<AudioManager>().StopPlay("Wha");
            FindObjectOfType<AudioManager>().StopPlay("Upd");
            FindObjectOfType<AudioManager>().StopPlay("Upd1");
        }
            
        wantnext = true;
        Time.timeScale = 0;
        ShowReward();
        //videoSkip.StartLevelAfterVideo();
    }
    
}
