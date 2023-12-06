using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    public AudioClip menumus;

    // Start is called before the first frame update
    void Start()
    {
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().clip = menumus;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().loop = true;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }
}
