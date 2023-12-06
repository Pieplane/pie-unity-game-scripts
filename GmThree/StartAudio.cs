using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().StopPlay("Game");
        FindObjectOfType<AudioManager>().StopPlay("GameTwo");
        FindObjectOfType<AudioManager>().StopPlay("GameThree");
        FindObjectOfType<AudioManager>().StopPlay("Cry");
        FindObjectOfType<AudioManager>().Play("Happy");
    }
}
