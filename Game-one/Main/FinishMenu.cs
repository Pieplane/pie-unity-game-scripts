using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class FinishMenu : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void RateGame();

    public AudioClip musicFinish;
    public AudioClip musicMenu;

    public Animator win;
    float gameTime;
    public TMP_Text gameTimer;

    public Animator star01;
    public Animator star02;
    public Animator star03;

    public Animator drop01;
    public Animator drop02;
    public Animator drop03;

    private void Awake()
    {
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().clip = musicFinish;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().loop = false;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Play();
        win.SetBool("Win", true);

        gameTime = PlayerPrefs.GetFloat("time", gameTime);
        TimeSpan time = TimeSpan.FromSeconds(gameTime);
        gameTimer.text = time.ToString(@"mm\:ss");

        if (gameTime < 120f)
        {
            Invoke("StarFirst", 2.2f);
            Invoke("StarSecond", 3.2f);
            Invoke("StarThird", 4.2f);
            Invoke("DropFirst", 5.6f);
            Invoke("DropSecond", 6.6f);
            Invoke("DropThird", 7.6f);
        }
        else if (gameTime < 300f)
        {
            Invoke("StarFirst", 2.2f);
            Invoke("StarSecond", 3.2f);
            Invoke("DropFirst", 4.6f);
            Invoke("DropSecond", 5.6f);
        }
        else
        {
            Invoke("StarFirst", 2.2f);
            Invoke("DropFirst", 3.6f);
        }

    }

    public void LoadMenu()
    {
        MainMenu.music = false;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().clip = musicMenu;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().loop = true;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Pause();
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        FindKey.keyPicked = false;

    }
    public void RateMenu()
    {
        RateGame();
    }

    void StarFirst()
    {
        FindObjectOfType<AudioManager>().Play("Star");
        star01.SetTrigger("Star01");
    }
    void StarSecond()
    {
        FindObjectOfType<AudioManager>().Play("Star");
        star02.SetTrigger("Star02");
    }
    void StarThird()
    {
        FindObjectOfType<AudioManager>().Play("Star");
        star03.SetTrigger("Star03");
    }

    void DropFirst()
    {
        FindObjectOfType<AudioManager>().Play("Drop");
        drop01.SetTrigger("Drop01");
    }
    void DropSecond()
    {
        FindObjectOfType<AudioManager>().Play("Drop");
        drop02.SetTrigger("Drop02");
    }
    void DropThird()
    {
        FindObjectOfType<AudioManager>().Play("Drop");
        drop03.SetTrigger("Drop03");
    }

}
