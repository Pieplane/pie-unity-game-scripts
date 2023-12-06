using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameMaster : MonoBehaviour
{
    public static bool MusicLoad = false;
    public AudioMixer audioMixer;
    public AudioSource audion;
    private void Update()
    {
        audion = GetComponent<AudioSource>();
        if (MusicLoad)
        {
            

        }
        else
        {
            audion.pitch = 0;
        }
        
    }

    private void Awake()
    {
        MusicLoad = true;

        

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");

        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

}
