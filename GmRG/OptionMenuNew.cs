using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionMenuNew : MonoBehaviour
{

    public AudioMixer audioMixer;
    public AudioMixer soundsMixer;

    public Slider sliderMusic;
    public Slider sliderSounds;

    public void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("save");
        sliderSounds.value = PlayerPrefs.GetFloat("savesounds");
    }

    public void SetVolue(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("save", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetVolueSounds(float volume)
    {
        soundsMixer.SetFloat("volumeSounds", volume);
        PlayerPrefs.SetFloat("savesounds", volume);
    }
}
