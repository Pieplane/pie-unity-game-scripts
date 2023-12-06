using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoSkip : MonoBehaviour
{
    int levelToUnlock = 0;
    int levelalready;
    public GameObject giveMe;

    private void Start()
    {
        levelToUnlock = SceneManager.GetActiveScene().buildIndex;
        levelalready = PlayerPrefs.GetInt("levelReached");
    }

    public void StartLevelAfterVideo()
    {
        if (SkipLevel.wantnext && !HalpMe.halpwant)
        {
            Time.timeScale = 1;
            if(levelalready < levelToUnlock)
            {
                PlayerPrefs.SetInt("levelReached", levelToUnlock);
            }
            SkipLevel.wantnext = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (!SkipLevel.wantnext && HalpMe.halpwant)
        {
            Time.timeScale = 1;
            giveMe.SetActive(true);
            HalpMe.halpwant = false;
        }
        else
            return;
        
    }
}
