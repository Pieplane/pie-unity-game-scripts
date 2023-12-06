using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSettings : MonoBehaviour
{
    public Slider slider;

    public float sliderValue;


    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("save", sliderValue);
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("save", sliderValue);
    }


}
