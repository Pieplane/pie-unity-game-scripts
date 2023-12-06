using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    public static bool plaing = false;
    private void Start()
    {
        if (!plaing)
        {
            FindObjectOfType<AudioManager>().Play("MainMusic");
            plaing = true;
        }
        
    }
}
