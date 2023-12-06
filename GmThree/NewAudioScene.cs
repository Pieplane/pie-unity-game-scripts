using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAudioScene : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().StopPlay("Happy");
        FindObjectOfType<AudioManager>().StopPlay("GameTwo");
        FindObjectOfType<AudioManager>().StopPlay("Cry");
        FindObjectOfType<AudioManager>().Play("Happy");
        Invoke("GameMusic", 2.5f);
    }
    public void GameMusic()
    {
        FindObjectOfType<AudioManager>().StopPlay("Happy");
        FindObjectOfType<AudioManager>().Play("GameTwo");
    }
}
