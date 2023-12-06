using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceEat : MonoBehaviour
{
    AudioManager audioManagerInstance;

    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().Play("Eat");
        }
            
    }
}
