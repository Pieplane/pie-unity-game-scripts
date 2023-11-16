using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NewTimer : MonoBehaviour
{
    bool stopwatchActive = false;
    float currentTime;
    public TMP_Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("time", currentTime) != 0)
        {
            currentTime = PlayerPrefs.GetFloat("time", currentTime);
            stopwatchActive = true;
        }
        else
        {
            currentTime = 0;
            stopwatchActive = true;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if(stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            PlayerPrefs.SetFloat("time", currentTime);
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss");
    }
}
