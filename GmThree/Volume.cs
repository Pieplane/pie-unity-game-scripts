using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public Slider sliderSounds;
    public AudioMixer audioMixer;

    private void Start()
    {
        sliderSounds.value = PlayerPrefs.GetFloat("savesounds");
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("savesounds", volume);
    }
}
