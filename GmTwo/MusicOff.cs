using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicOff : MonoBehaviour
{
    public Animator anim;
    public Button musoff;
    public Button muson;
    public static bool off = false;

    private void Start()
    {
        if (off)
        {
            musoff.interactable = false;
            muson.interactable = true;
        }
        else
        {
            musoff.interactable = true;
            muson.interactable = false;
        }
    }
    public void SetAnim()
    {
            anim.SetTrigger("Play");
            FindObjectOfType<AudioManager>().Play("Bub");
    }
    public void DontMusic()
    {
            FindObjectOfType<AudioManager>().OffMusic();
            musoff.interactable = false;
            muson.interactable = true;
            off = true;
    }
    public void GoMusic()
    {
            FindObjectOfType<AudioManager>().OnMusic();
            musoff.interactable = true;
            muson.interactable = false;
            off = false;
    }
}
