using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Animator anim;

    public void SetAnim()
    {
        anim.SetTrigger("Play");
    }
    public void LoadEndLevels()
    {
        SceneManager.LoadScene("LevelSelect");
        FindObjectOfType<AudioManager>().StopPlay("Happy");
    }
}
